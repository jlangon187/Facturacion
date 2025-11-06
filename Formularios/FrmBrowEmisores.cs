using FacturacionDAM.Modelos;
using MySql.Data.MySqlClient;
using System.Data;
using System.Security.Cryptography.Xml;

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
                _bs.DataSource = _tabla.LaTabla;    // Asigna la tabla de datos al BindingSource
                dgTabla.DataSource = _bs;           // Enlaza el DataGridView al BindingSource
                personalizarDataGrid();             // Personaliza el DataGridView
            }
            else
            {
                MessageBox.Show("No se han podido cargar los emisores.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            ActualizarEstado();
        }

        private void FrmBrowEmisores_Shown(object sender, EventArgs e)
        {
            RestaurarEstadoVentana();
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

        /// <summary>
        /// Evento del cierre del formulario para guardar el estado de la ventana.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmBrowEmisores_FormClosing(object sender, FormClosingEventArgs e)
        {
            GuardarEstadoVentana();     // Guardar el estado de la ventana
        }

        /*********** Métodos privados ***********/

        /// <summary>
        /// Guarda el estado de la ventana (tamaño, posición, columnas, etc.)
        /// </summary>
        private void GuardarEstadoVentana()
        {
            // Guardar tamaño y posición solo si la ventana está en estado normal
            if (this.WindowState == FormWindowState.Normal)
            {
                Properties.Settings.Default.BrowEmisoresLocation = this.Location;
                Properties.Settings.Default.BrowEmisoresSize = this.Size;
            }

            // Guardar estado de la ventana
            Properties.Settings.Default.BrowEmisoresState = this.WindowState.ToString();

            // Guarda el estado
            Properties.Settings.Default.Save();
        }

        private void RestaurarEstadoVentana()
        {
            // Restaurar tamaño y posición
            string estado = Properties.Settings.Default.BrowEmisoresState;
            switch (estado)
            {
                case "Maximized":
                    this.WindowState = FormWindowState.Maximized;
                    break;
                case "Minimized":
                    this.WindowState = FormWindowState.Minimized;
                    break;
                default:
                    this.WindowState = FormWindowState.Normal;
                    break;
            }
            // Solo restaurar tamaño y posición si la ventana está en estado normal
            if (Properties.Settings.Default.BrowEmisoresState == "Normal")
            {
                this.Location = Properties.Settings.Default.BrowEmisoresLocation;
                this.Size = Properties.Settings.Default.BrowEmisoresSize;
            }
        }

        private void ActualizarEstado()
        {
            tsStatusLabel.Text = $"Nº de Registros: {_bs.Count}";   // Actualiza la barra de estado
        }

        private void dgTabla_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            btnEdit_Click(sender, e);
        }

        /// <summary>
        /// Metodo para personalizar el DataGridView dgTabla.
        /// </summary>
        private void personalizarDataGrid()
        {
            // Cambiar títulos de columnas
            dgTabla.Columns["nifcif"].HeaderText = "NIF/CIF";
            dgTabla.Columns["nifcif"].Width = 100;
            dgTabla.Columns["nombre"].HeaderText = "Nombre";
            dgTabla.Columns["nombre"].Width = 120;
            dgTabla.Columns["apellido"].HeaderText = "Apellidos";
            dgTabla.Columns["apellido"].Width = 160;
            dgTabla.Columns["nombrecomercial"].HeaderText = "Razón Social";
            dgTabla.Columns["nombrecomercial"].Width = 200;
            dgTabla.Columns["codigopostal"].HeaderText = "Código Postal";
            dgTabla.Columns["codigopostal"].Width = 140;
            dgTabla.Columns["poblacion"].HeaderText = "Población";
            dgTabla.Columns["poblacion"].Width = 100;
            dgTabla.Columns["telefono1"].HeaderText = "Teléfono";
            dgTabla.Columns["telefono1"].Width = 100;
            dgTabla.Columns["email"].HeaderText = "Correo Electrónico";
            dgTabla.Columns["email"].Width = 350;

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
            dgTabla.Columns["domicilio"].Visible = false;
            dgTabla.Columns["telefono2"].Visible = false;
            dgTabla.Columns["descripcion"].Visible = false;
            dgTabla.Columns["nextnumfac"].Visible = false;
            dgTabla.Columns["prefixfac"].Visible = false;

            // Alternamos color de filas
            dgTabla.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.LightGray;

            // Estilo de los encabezados de las columnas
            dgTabla.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(185, 218, 247);
            dgTabla.EnableHeadersVisualStyles = false;

            // Tamaño de las letras de los encabezados de las columnas
            dgTabla.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font(dgTabla.Font.FontFamily, 10, FontStyle.Bold);
        }

        /// <summary>
        /// Determina si el emisor tiene facturas emitidas.
        /// </summary>
        /// <param name="nifcif"></param>
        /// <returns>Devuelve true si tiene facturas emitidas, false en caso contrario.</returns>
        private bool TieneFacturasEmitidas(string nifcif)
        {
            return false;
        }

        /// <summary>
        /// Determina si el emisor tiene facturas recibidas.
        /// </summary>
        /// <param name="nifcif"></param>
        /// <returns>Devuelve true si tiene facturas recibidas, false en caso contrario.</returns>
        private bool TieneFacturasRecibidas(string nifcif)
        {
            return false;
        }
    }
}
