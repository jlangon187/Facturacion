using FacturacionDAM.Modelos;
using System.Data;

namespace FacturacionDAM.Formularios
{
    public partial class FrmBrowEmisores : Form
    {
        private Tabla _tabla;       // Tabla de emisores
        private BindingSource _bs;  // Para comnunicación con los controles
        public FrmBrowEmisores()
        {
            InitializeComponent();
            _bs = new BindingSource();
            _tabla = new Tabla(Program.appDAM.LaConexion);
        }

        private void FrmBrowEmisores_Load(object sender, EventArgs e)
        {
            if (_tabla.InicializarDatos("SELECT * FROM emisores;"))
            {
                _bs.DataSource = _tabla.LaTabla;
                dgTabla.DataSource = _bs;

                // Cambiar títulos de columnas
                dgTabla.Columns["nifcif"].HeaderText = "NIF/CIF";
                dgTabla.Columns["nombre"].HeaderText = "Nombre";
                dgTabla.Columns["apellido"].HeaderText = "Apellidos";
                dgTabla.Columns["nombrecomercial"].HeaderText = "Nombre Comercial";
                dgTabla.Columns["domicilio"].HeaderText = "Dirección";
                dgTabla.Columns["codigopostal"].HeaderText = "Código Postal";
                dgTabla.Columns["poblacion"].HeaderText = "Población";
                dgTabla.Columns["telefono1"].HeaderText = "Teléfono 1";
                dgTabla.Columns["telefono2"].HeaderText = "Teléfono 2";
                dgTabla.Columns["email"].HeaderText = "Correo Electrónico";
                dgTabla.Columns["descripcion"].HeaderText = "Descripción";
                dgTabla.Columns["nextnumfac"].HeaderText = "Siguiente Nº Factura";
                dgTabla.Columns["prefixfac"].HeaderText = "Prefijo Factura";

                // Crear columna Provincia mostrando el nombre en lugar del ID
                DataGridViewComboBoxColumn provinciaCol = new DataGridViewComboBoxColumn
                {
                    DataPropertyName = "idprovincia",
                    HeaderText = "Provincia",
                    Name = "Provincia",
                    DataSource = _tabla.ObtenerTablaProvincias(),
                    DisplayMember = "nombreprovincia",
                    ValueMember = "id",
                    Width = 150,
                    DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing,
                    FlatStyle = FlatStyle.Flat
                };

                // Insertar en posición deseada
                dgTabla.Columns.Add(provinciaCol);
                provinciaCol.DisplayIndex = 8;

                // Ocultar columnas innecesarias
                dgTabla.Columns["id"].Visible = false;
                dgTabla.Columns["descripcion"].Visible = false;
                dgTabla.Columns["idprovincia"].Visible = false;

                // Ajustar columnas al final, después de personalizarlas y añadir la de Provincia
                this.BeginInvoke((MethodInvoker)(() => AjustarColumnasPorEncabezadoYContenido()));
            }
            else
            {
                MessageBox.Show("No se han podido cargar los emisores.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            ActualizarEstado();
        }


        private void btnFirst_Click(object sender, EventArgs e) => _bs.MoveFirst();

        private void btnPrev_Click(object sender, EventArgs e) => _bs.MovePrevious();

        private void btnNext_Click(object sender, EventArgs e) => _bs.MoveNext();

        private void btnLast_Click(object sender, EventArgs e) => _bs.MoveLast();

        private void btnNew_Click(object sender, EventArgs e)
        {
            _bs.AddNew();

            FrmEmisor frm = new FrmEmisor(_bs, _tabla);
            frm.edicion = false;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                _tabla.Refrescar();
                ActualizarEstado();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (_bs.Current is DataRowView row)
            {
                FrmEmisor frm = new FrmEmisor(_bs, _tabla);
                frm.edicion = true;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    _tabla.Refrescar();
                    ActualizarEstado();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_bs.Current is DataRowView row)
            {
                if (MessageBox.Show("¿Estás seguro de que deseas eliminar este emisor?", "Confirmar eliminación", 
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    // Si el emisor está en uso, no se puede eliminar
                    try
                    {
                        if (_tabla.EmisorEnUso("emisores", "emisor_id", (int)row["id"]))
                        {
                            MessageBox.Show("No se puede eliminar este emisor porque está en uso.", "Error", 
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        else
                        {
                            _bs.RemoveCurrent();
                            _tabla.GuardarDatos();
                            ActualizarEstado();
                        }
                    }
                    catch (Exception ex)
                    {
                        Program.appDAM.RegistrarLog("Error al comprobar si el emisor está en uso", ex.Message);
                        return;
                    }

                }
            }
        }

        /*********** Métodos privados ***********/

        private void ActualizarEstado()
        {
            tsStatusLabel.Text = $"Nº de Registros: {_bs.Count}";   // Actualiza la barra de estado
        }

        private void dgTabla_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            btnEdit_Click(sender, e);
        }

        private void AjustarColumnasPorEncabezadoYContenido()
        {
            // No envolver texto en encabezados ni celdas
            dgTabla.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;
            foreach (DataGridViewColumn c in dgTabla.Columns)
                c.DefaultCellStyle.WrapMode = DataGridViewTriState.False;

            // Fijar modo para que no autosizee mientras medimos
            dgTabla.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

            // 1) Medir por encabezado
            dgTabla.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.ColumnHeader);
            var anchoPorEncabezado = new Dictionary<string, int>();
            foreach (DataGridViewColumn c in dgTabla.Columns)
                anchoPorEncabezado[c.Name] = c.Width;

            // 2) Medir por contenido (sin contar encabezado)
            dgTabla.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader);
            foreach (DataGridViewColumn c in dgTabla.Columns)
            {
                int anchoEncabezado = anchoPorEncabezado[c.Name];
                int anchoContenido = c.Width;
                c.Width = Math.Max(anchoEncabezado, anchoContenido);
                c.AutoSizeMode = DataGridViewAutoSizeColumnMode.None; // fijar ancho
            }
        }


        private bool TieneFacturasEmitidas(string nifcif) 
        {
            return false;
        }

        private bool TieneFacturasRecibidas(string nifcif)
        {
            return false;
        }

    }
}
