using FacturacionDAM.Modelos;
using FacturacionDAM.Utils;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FacturacionDAM.Formularios
{
    public partial class FrmEmisor : Form
    {
        private Tabla _tabla;       // Tabla de emisores
        private BindingSource _bs;  // Para comnunicación con los controles
        public bool edicion = false;

        public FrmEmisor(BindingSource bs, Tabla tabla)
        {
            InitializeComponent();
            _bs = bs;
            _tabla = tabla;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (!ValidarDatos())
            {
                return; // Si los datos no son válidos, no continuar
            }
            _bs.EndEdit();                      // Termina la edición en el BindingSource
            _tabla.GuardarDatos();              // Guarda los datos en la tabla

            Program.appDAM.emisor.ActualizarEmisor(_bs); // Actualiza el emisor en la aplicación

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            _bs.CancelEdit();                   // Cancela la edición en el BindingSource
            this.Close();
        }

        private void FrmEmisor_Load(object sender, EventArgs e)
        {
            rTBoxDescripcion.Enter += rTBoxDescripcion_Enter;
            rTBoxDescripcion.Leave += rTBoxDescripcion_Leave;

            txtNifCif.DataBindings.Add("Text", _bs, "nifcif");
            txtNombre.DataBindings.Add("Text", _bs, "nombre");
            txtApellidos.DataBindings.Add("Text", _bs, "apellidos");
            txtDomicilio.DataBindings.Add("Text", _bs, "domicilio");
            txtPoblacion.DataBindings.Add("Text", _bs, "poblacion");
            txtCodigoPostal.DataBindings.Add("Text", _bs, "codigopostal");
            txtRazonSocial.DataBindings.Add("Text", _bs, "nombrecomercial");
            txtTelefono1.DataBindings.Add("Text", _bs, "telefono1");
            txtTelefono2.DataBindings.Add("Text", _bs, "telefono2");
            txtEmail.DataBindings.Add("Text", _bs, "email");
            txtPrefijo.DataBindings.Add("Text", _bs, "prefixfac");
            txtSiguientenumero.DataBindings.Add("Text", _bs, "nextnumfac");
            rTBoxDescripcion.DataBindings.Add("Text", _bs, "descripcion");

            // Cargar provincias en el ComboBox
            cbProvincia.DataSource = _tabla.ObtenerTablaProvincias();
            cbProvincia.DisplayMember = "nombreprovincia";
            cbProvincia.ValueMember = "id";
            cbProvincia.SelectedIndex = 0;
            cbProvincia.DataBindings.Add("SelectedValue", _bs, "idprovincia");
        }

        private void rTBoxDescripcion_Enter(object sender, EventArgs e)
        {
            this.AcceptButton = null;  // Desactiva el botón aceptar temporalmente
        }

        private void rTBoxDescripcion_Leave(object sender, EventArgs e)
        {
            this.AcceptButton = btnAceptar;  // Lo vuelve a activar al salir
        }

        private void FrmEmisor_FormClosing(object sender, FormClosingEventArgs e)
        {
            _bs.CancelEdit();                   // Cancela la edición en el BindingSource
        }


        private bool ValidarDatos()
        {
            // Validar que Nif/Cif y Nombre Comercial no estén vacíos
            if (string.IsNullOrWhiteSpace(txtNifCif.Text))
            {
                MessageBox.Show("El campo NIF/CIF no puede estar vacío.");
                txtNifCif.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtRazonSocial.Text))
            {
                MessageBox.Show("El campo Nombre Comercial no puede estar vacío.");
                txtRazonSocial.Focus();
                return false;
            }

            // Validar que el email tenga un formato correcto si no está vacío
            if (!string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                bool emailValido = true;

                try
                {
                    Validaciones.EsEmailValido(txtEmail.Text.Trim());
                }
                catch
                {
                    emailValido = false;
                }

                if (!emailValido)
                {
                    MessageBox.Show("El campo Email no tiene un formato válido.",
                        "Error de validación",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    txtEmail.Focus();
                    return false;
                }
            }

            int? idParaValidar = null;
            if (edicion && _bs.Current is DataRowView currentRow)
            {
                // Si es DBNull, se queda en null. Si tiene valor, lo convertimos.
                idParaValidar = (currentRow["id"] == DBNull.Value) ? (int?)null : Convert.ToInt32(currentRow["id"]);
            }

            // Validar que nif/cif sea único
            if (Validaciones.EsValorCampoUnico("emisores", "nifcif", txtNifCif.Text.Trim(), idParaValidar) == false)
            {
                MessageBox.Show("El NIF/CIF ya existe en otro emisor. Debe ser único.",
                    "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNifCif.Focus();
                return false;
            }

            // Validar código postal es correcto sin comprobar si está vacío
            if (!Validaciones.CodigoPostalValido(txtCodigoPostal.Text.Trim()))
            {
                MessageBox.Show("El código postal no es válido.",
                    "Error de validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                txtCodigoPostal.Focus();
                return false;
            }

            // Validar que el nextnumfac no esté vacío y sea un número entero positivo
            if (string.IsNullOrWhiteSpace(txtSiguientenumero.Text) ||
                !int.TryParse(txtSiguientenumero.Text.Trim(), out int nextNum) ||
                nextNum < 0)
            {
                MessageBox.Show("El campo Siguiente Número de Factura debe ser un número entero positivo.",
                    "Error de validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                txtSiguientenumero.Focus();
                return false;
            }

            return true; // Todos los datos son válidos
        }
    }
}
