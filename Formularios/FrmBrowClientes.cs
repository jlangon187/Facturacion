using FacturacionDAM.Modelos;
using MySql.Data.MySqlClient;
using System.Data;
using System.Text;

namespace FacturacionDAM.Formularios
{
    public partial class FrmBrowClientes : Form
    {
        private Tabla _tabla;       // Tabla de clientes
        private BindingSource _bs;  // Para comunicación con los controles

        public FrmBrowClientes()
        {
            InitializeComponent();
            _bs = new BindingSource();
            _tabla = new Tabla(Program.appDAM.LaConexion);
        }

        private void FrmBrowClientes_Load(object sender, EventArgs e)
        {
            if (_tabla.InicializarDatos("SELECT * FROM clientes;"))
            {
                _bs.DataSource = _tabla.LaTabla;    // Asigna la tabla de datos al BindingSource
                dgTabla.DataSource = _bs;           // Enlaza el DataGridView al BindingSource
                personalizarDataGrid();             // Personaliza el DataGridView
            }
            else
            {
                MessageBox.Show("No se han podido cargar los clientes.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            ActualizarEstado();
        }

        private void FrmBrowClientes_Shown(object sender, EventArgs e)
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

            FrmCliente frm = new FrmCliente(_bs, _tabla);
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
                FrmCliente frm = new FrmCliente(_bs, _tabla);
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
                if (MessageBox.Show("¿Estás seguro de que deseas eliminar este cliente?", "Confirmar eliminación",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        _bs.RemoveCurrent();
                        _tabla.GuardarDatos();
                        ActualizarEstado();
                    }
                    catch (Exception ex)
                    {
                        Program.appDAM.RegistrarLog("Error al eliminar cliente", ex.Message);
                        return;
                    }
                }
            }
        }

        /// <summary>
        /// Evento del cierre del formulario para guardar el estado de la ventana.
        /// </summary>
        private void FrmBrowClientes_FormClosing(object sender, FormClosingEventArgs e)
        {
            GuardarEstadoVentana();     // Guardar el estado de la ventana
        }

        /*********** Métodos privados ***********/

        /// <summary>
        /// Guarda el estado de la ventana (tamaño, posición, columnas, etc.)
        /// </summary>
        private void GuardarEstadoVentana()
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                Properties.Settings.Default.BrowClientesLocation = this.Location;
                Properties.Settings.Default.BrowClientesSize = this.Size;
            }

            Properties.Settings.Default.BrowClientesState = this.WindowState.ToString();
            Properties.Settings.Default.Save();
        }

        /// <summary>
        /// Restaura el estado de la ventana (tamaño, posición, columnas, etc.)
        /// </summary>
        private void RestaurarEstadoVentana()
        {
            string estado = Properties.Settings.Default.BrowClientesState;
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

            if (Properties.Settings.Default.BrowClientesState == "Normal")
            {
                this.Location = Properties.Settings.Default.BrowClientesLocation;
                this.Size = Properties.Settings.Default.BrowClientesSize;
            }
        }

        private void ActualizarEstado()
        {
            tsStatusLabel.Text = $"Nº de Registros: {_bs.Count}";
        }

        private void dgTabla_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            btnEdit_Click(sender, e);
        }

        /// <summary>
        /// Personaliza el DataGridView para clientes
        /// </summary>
        private void personalizarDataGrid()
        {
            // Cambiar títulos y anchos de columnas
            dgTabla.Columns["nifcif"].HeaderText = "NIF/CIF";
            dgTabla.Columns["nifcif"].Width = 100;
            dgTabla.Columns["nombre"].HeaderText = "Nombre";
            dgTabla.Columns["nombre"].Width = 120;
            dgTabla.Columns["apellidos"].HeaderText = "Apellidos";
            dgTabla.Columns["apellidos"].Width = 160;
            dgTabla.Columns["nombrecomercial"].HeaderText = "Nombre Comercial";
            dgTabla.Columns["nombrecomercial"].Width = 180;
            dgTabla.Columns["direccion"].HeaderText = "Dirección";
            dgTabla.Columns["direccion"].Width = 200;
            dgTabla.Columns["poblacion"].HeaderText = "Población";
            dgTabla.Columns["poblacion"].Width = 120;
            dgTabla.Columns["cpostal"].HeaderText = "Código Postal";
            dgTabla.Columns["cpostal"].Width = 120;
            dgTabla.Columns["telefono"].HeaderText = "Teléfono";
            dgTabla.Columns["telefono"].Width = 100;
            dgTabla.Columns["email"].HeaderText = "Correo Electrónico";
            dgTabla.Columns["email"].Width = 250;

            // Crear columna Provincia mostrando el nombre
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

            dgTabla.Columns.Add(provinciaCol);
            provinciaCol.DisplayIndex = 8;

            // Ocultar columnas innecesarias
            dgTabla.Columns["id"].Visible = false;
            dgTabla.Columns["idprovincia"].Visible = false;

            // Alternar color de filas
            dgTabla.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.LightGray;

            // Estilo de encabezados
            dgTabla.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(185, 218, 247);
            dgTabla.EnableHeadersVisualStyles = false;
            dgTabla.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font(dgTabla.Font.FontFamily, 10, FontStyle.Bold);
            dgTabla.ColumnHeadersHeight = 40;
            dgTabla.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
        }

        /// <summary>
        /// Exporta los datos a un archivo CSV.
        /// </summary>
        /// <param name="rutaArchivo">Nombre del archivo de destino.</param>
        private void Export_A_CSV(string rutaArchivo)
        {
            try
            {
                DataTable dt = (DataTable)_bs.DataSource;
                List<string> lines = new List<string>();

                // Encabezados
                var columns = dt.Columns.Cast<DataColumn>().Select(col => col.ColumnName);
                lines.Add(string.Join(",", columns));
                // Filas
                foreach (DataRow row in dt.Rows)
                {
                    // Reemplaza las posibles ; por , para evitar conflictos
                    var fields = row.ItemArray.Select(field => field?.ToString()?.Replace(";", ","));
                    lines.Add(string.Join(";", fields));
                }
                // Guarda en un archivo CSV
                System.IO.File.WriteAllLines(rutaArchivo, lines, Encoding.UTF8);
                MessageBox.Show("Datos exportados a CSV correctamente.", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                Program.appDAM.RegistrarLog("Error al exportar a CSV", ex.Message);
                MessageBox.Show("Error al exportar los datos a CSV.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Exporta los datos a un archivo XML.
        /// </summary>
        /// <param name="rutaArchivo">Nombre del archivo de destino.</param>
        private void Export_A_XML(string rutaArchivo)
        {
            try
            {
                DataTable dt = (DataTable)_bs.DataSource;
                dt.TableName = "Clientes"; // Nombre de la tabla en el XML
                dt.WriteXml(rutaArchivo, XmlWriteMode.WriteSchema);
                MessageBox.Show("Datos exportados a XML correctamente", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                Program.appDAM.RegistrarLog("Error al exportar a XML", ex.Message);
                MessageBox.Show("Error al exportar los datos a XML.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExportCSV_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "CSV files (*.csv)|*.csv";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                Export_A_CSV(saveFileDialog.FileName);
        }

        private void btnExportXML_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "XML files (*.xml)|*.xml";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
                Export_A_XML(saveFileDialog.FileName);
        }
    }
}
