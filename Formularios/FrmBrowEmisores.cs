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
                AjustarColumnasPorEncabezadoYContenido();

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

                // Mostrar el nombre de la provincia en lugar del ID
                // Cambiar el encabezado
                dgTabla.Columns["idprovincia"].HeaderText = "ID Provincia";

                // Crear una nueva columna para mostrar el nombre
                if (!dgTabla.Columns.Contains("provinciaNombre"))
                {
                    dgTabla.Columns.Add("provinciaNombre", "Provincia");
                }

                // Cargar la tabla de provincias
                Tabla tablaProvincias = new Tabla(Program.appDAM.LaConexion);
                tablaProvincias.InicializarDatos("SELECT id, nombreprovincia FROM provincias;");

                // Rellenar el nombre de provincia
                foreach (DataGridViewRow row in dgTabla.Rows)
                {
                    if (row.IsNewRow) continue;

                    if (int.TryParse(row.Cells["idprovincia"].Value?.ToString(), out int idProvincia))
                    {
                        DataRow[] provincia = tablaProvincias.LaTabla.Select($"id = {idProvincia}");
                        if (provincia.Length > 0)
                        {
                            row.Cells["provinciaNombre"].Value = provincia[0]["nombreprovincia"].ToString();
                        }
                    }
                }

                // Ocultar columnas innecesarias
                dgTabla.Columns["id"].Visible = false;
                dgTabla.Columns["descripcion"].Visible = false;
                dgTabla.Columns["idprovincia"].Visible = false;
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
                if (MessageBox.Show("¿Estás seguro de que deseas eliminar este emisor?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    // Si el emisor está en uso, no se puede eliminar
                    try
                    {
                        if (_tabla.EmisorEnUso("emisores", "emisor_id", (int)row["id"]))
                        {
                            MessageBox.Show("No se puede eliminar este emisor porque está en uso.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            dgTabla.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

            foreach (DataGridViewColumn col in dgTabla.Columns)
            {
                // Ajustar primero según el contenido
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                int anchoContenido = col.Width;

                // Ajustar después según el encabezado
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                int anchoEncabezado = col.Width;

                // Tomar el mayor valor
                col.Width = Math.Max(anchoContenido, anchoEncabezado);

                // Fijar tamaño final (evita que cambie al cambiar de fila)
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            }
        }
    }
}
