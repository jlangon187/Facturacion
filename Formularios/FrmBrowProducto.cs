using FacturacionDAM.Modelos;
using FacturacionDAM.Utils;
using MySql.Data.MySqlClient;
using System.Data;
using System.Text;

namespace FacturacionDAM.Formularios
{
    public partial class FrmBrowProducto : Form
    {
        private Tabla _tabla;
        private BindingSource _bs;

        public FrmBrowProducto()
        {
            InitializeComponent();
            _bs = new BindingSource();
            _tabla = new Tabla(Program.appDAM.LaConexion);
        }

        private void FrmBrowProducto_Load(object sender, EventArgs e)
        {
            if (_tabla.InicializarDatos(@"SELECT * FROM productos;"))
            {
                _bs.DataSource = _tabla.LaTabla;
                dgTabla.DataSource = _bs;
                personalizarDataGrid();
            }
            else
            {
                MessageBox.Show("No se han podido cargar los productos.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            ActualizarEstado();
        }

        private void FrmBrowProducto_Shown(object sender, EventArgs e)
        {
            ConfiguracionVentana.Restaurar(this, "BrowProducto");
        }

        private void FrmBrowProducto_FormClosing(object sender, FormClosingEventArgs e)
        {
            ConfiguracionVentana.Guardar(this, "BrowProducto");
        }

        private void btnFirst_Click(object sender, EventArgs e) => _bs.MoveFirst();
        private void btnPrev_Click(object sender, EventArgs e) => _bs.MovePrevious();
        private void btnNext_Click(object sender, EventArgs e) => _bs.MoveNext();
        private void btnLast_Click(object sender, EventArgs e) => _bs.MoveLast();

        private void btnNew_Click(object sender, EventArgs e)
        {
            _bs.AddNew();
            FrmProducto frm = new FrmProducto(_bs, _tabla);
            frm.edicion = false;

            if (frm.ShowDialog() == DialogResult.OK)
            {
                _tabla.Refrescar();
                ActualizarEstado();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (_bs.Current is DataRowView)
            {
                FrmProducto frm = new FrmProducto(_bs, _tabla);
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
            if (_bs.Current is DataRowView)
            {
                if (MessageBox.Show("¿Deseas eliminar este producto?", "Confirmar eliminación",
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
                        Program.appDAM.RegistrarLog("Error al eliminar producto", ex.Message);
                    }
                }
            }
        }

        private void dgTabla_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            btnEdit_Click(sender, e);
        }

        private void ActualizarEstado()
        {
            tsStatusLabel.Text = $"Nº de Registros: {_bs.Count}";
        }

        private void personalizarDataGrid()
        {
            // Cambiar títulos y anchos de columnas
            dgTabla.Columns["codigo"].HeaderText = "Código";
            dgTabla.Columns["codigo"].Width = 120;
            dgTabla.Columns["descripcion"].HeaderText = "Descripción";
            dgTabla.Columns["descripcion"].Width = 300;
            dgTabla.Columns["preciounidad"].HeaderText = "Precio (€)";
            dgTabla.Columns["preciounidad"].Width = 120;
            dgTabla.Columns["preciounidad"].DefaultCellStyle.Format = "0.00";

            // Crear columna IVA mostrando el IVA en lugar del ID
            DataGridViewComboBoxColumn ivaCol = new DataGridViewComboBoxColumn
            {
                DataPropertyName = "idtipoiva",
                HeaderText = "IVA %",
                Name = "IVA %",
                DataSource = _tabla.ObtenerTablaTiposDeIVA(),
                DisplayMember = "porcentaje",
                ValueMember = "id",
                Width = 150,
                DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing,
                FlatStyle = FlatStyle.Flat
            };

            // Insertar la columna IVA en la posición correcta
            dgTabla.Columns.Add(ivaCol);
            ivaCol.DisplayIndex = 4;

            // Oculta las columnas innecesarias
            dgTabla.Columns["activo"].HeaderText = "Activo";
            dgTabla.Columns["activo"].Width = 80;
            dgTabla.Columns["id"].Visible = false;
            dgTabla.Columns["idtipoiva"].Visible = false;

            dgTabla.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;

            dgTabla.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(185, 218, 247);
            dgTabla.ColumnHeadersDefaultCellStyle.Font = new Font(dgTabla.Font.FontFamily, 10, FontStyle.Bold);
            dgTabla.EnableHeadersVisualStyles = false;
            dgTabla.ColumnHeadersHeight = 40;
            dgTabla.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
        }

        private void btnExportCSV_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "CSV (*.csv)|*.csv";

            if (sfd.ShowDialog() == DialogResult.OK)
                ExportarDatos.ExportarCSV((DataTable)_bs.DataSource, sfd.FileName);
        }

        private void btnExportXML_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "XML (*.xml)|*.xml";

            if (sfd.ShowDialog() == DialogResult.OK)
                ExportarDatos.ExportarXML((DataTable)_bs.DataSource, sfd.FileName, "productos");
        }
    }
}
