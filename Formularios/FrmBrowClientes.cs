using FacturacionDAM.Modelos;
using FacturacionDAM.Utils;
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
            ConfiguracionVentana.Restaurar(this, "BrowClientes");
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
            ConfiguracionVentana.Guardar(this, "BrowClientes");
        }

        /*********** Métodos privados ***********/

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
            dgTabla.Columns["telefono1"].HeaderText = "Teléfono";
            dgTabla.Columns["telefono1"].Width = 100;
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
            dgTabla.Columns["telefono2"].Visible = false;

            // Alternar color de filas
            dgTabla.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.LightGray;

            // Estilo de encabezados
            dgTabla.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(185, 218, 247);
            dgTabla.EnableHeadersVisualStyles = false;
            dgTabla.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font(dgTabla.Font.FontFamily, 10, FontStyle.Bold);
            dgTabla.ColumnHeadersHeight = 40;
            dgTabla.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
        }

        private void btnExportCSV_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "CSV files (*.csv)|*.csv";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                ExportarDatos.ExportarCSV((DataTable)_bs.DataSource, saveFileDialog.FileName);
        }

        private void btnExportXML_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "XML files (*.xml)|*.xml";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
                ExportarDatos.ExportarXML((DataTable)_bs.DataSource, saveFileDialog.FileName, "clientes");
        }
    }
}
