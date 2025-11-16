using FacturacionDAM.Modelos;
using FacturacionDAM.Utils;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace FacturacionDAM.Formularios
{
    public partial class FrmProducto : Form
    {
        private Tabla _tabla;           // tabla "producto"
        private BindingSource _bs;      // BS del producto
        public bool edicion = false;    // Indica si es edición o alta

        public FrmProducto(BindingSource bs, Tabla tabla)
        {
            InitializeComponent();
            _bs = bs;
            _tabla = tabla;
        }

        private void FrmProducto_Load(object sender, EventArgs e)
        {
            txtCodigo.DataBindings.Add("Text", _bs, "codigo", true);
            txtDescripcion.DataBindings.Add("Text", _bs, "descripcion", true);
            txtPrecio.DataBindings.Add("Text", _bs, "preciounidad", true, DataSourceUpdateMode.OnPropertyChanged, 0, "N2");
            txtPrecio.KeyPress += Validaciones.ValidarPrecio;
            cBActivo.DataBindings.Add("Checked", _bs, "activo", true);

            // Cargar tipos de IVA en el ComboBox
            cbIVA.DataSource = _tabla.ObtenerTablaTiposDeIVA();
            cbIVA.DisplayMember = "descripcion";
            cbIVA.ValueMember = "id";
            cbIVA.SelectedIndex = 0;
            cbIVA.DataBindings.Add("SelectedValue", _bs, "idtipoiva");
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            _bs.EndEdit();
            _tabla.GuardarDatos();

            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            _bs.CancelEdit();
            this.Close();
        }

        private void FrmProducto_FormClosing(object sender, FormClosingEventArgs e)
        {
            _bs.CancelEdit();
        }
    }
}
