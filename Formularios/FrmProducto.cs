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
            if (!edicion)
            {
                var row = (DataRowView)_bs.Current;
                row["activo"] = true;
            }

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
            if (!ValidarDatos())
            {
                return; // Si los datos no son válidos, no continuar
            }
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

        private bool ValidarDatos()
        {
            // Validar que el código no esté vacío
            if (string.IsNullOrWhiteSpace(txtCodigo.Text))
            {
                MessageBox.Show("El código del producto no puede estar vacío.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCodigo.Focus();
                return false;
            }
            // Validar que el código sea único
            int? idActual = edicion ? (int?)Convert.ToInt32(((DataRowView)_bs.Current)["id"]) : null;
            if (!Validaciones.EsValorCampoUnico("productos", "codigo", txtCodigo.Text.Trim(), idActual))
            {
                MessageBox.Show("El código del producto ya existe. Debe ser único.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCodigo.Focus();
                return false;
            }
            // Validar que la descripción no esté vacía
            if (string.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                MessageBox.Show("La descripción del producto no puede estar vacía.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDescripcion.Focus();
                return false;
            }
            // Validar que el precio sea un número válido mayor o igual a cero
            if (!decimal.TryParse(txtPrecio.Text.Trim(), out decimal precio) || precio < 0)
            {
                MessageBox.Show("El precio del producto debe ser un número válido mayor o igual a cero.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPrecio.Focus();
                return false;
            }
            // Validar que se haya seleccionado un tipo de IVA
            if (cbIVA.SelectedValue == null)
            {
                MessageBox.Show("Debe seleccionar un tipo de IVA.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbIVA.Focus();
                return false;
            }
            return true; // Todos los datos son válidos
        }
    }
}
