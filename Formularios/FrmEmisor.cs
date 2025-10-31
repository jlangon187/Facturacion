using FacturacionDAM.Modelos;
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
            txtApellidos.DataBindings.Add("Text", _bs, "apellido");
            txtDomicilio.DataBindings.Add("Text", _bs, "domicilio");
            txtPoblacion.DataBindings.Add("Text", _bs, "poblacion");
            txtCodigoPostal.DataBindings.Add("Text", _bs, "codigopostal");
            cbProvincia.DataBindings.Add("Text", _bs, "idprovincia");
            txtRazonSocial.DataBindings.Add("Text", _bs, "nombrecomercial");
            txtTelefono1.DataBindings.Add("Text", _bs, "telefono1");
            txtTelefono2.DataBindings.Add("Text", _bs, "telefono2");
            txtEmail.DataBindings.Add("Text", _bs, "email");
            txtPrefijo.DataBindings.Add("Text", _bs, "prefixfac");
            txtSiguientenumero.DataBindings.Add("Text", _bs, "nextnumfac");
            rTBoxDescripcion.DataBindings.Add("Text", _bs, "descripcion");

            // Cargar provincias en el ComboBox
            Tabla tablaProvincias = new Tabla(Program.appDAM.LaConexion);
            tablaProvincias.InicializarDatos("SELECT * FROM provincias;");
            cbProvincia.DataSource = tablaProvincias.LaTabla;
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
                try
                {
                    var addr = new System.Net.Mail.MailAddress(txtEmail.Text);
                    if (addr.Address != txtEmail.Text)
                    {
                        throw new Exception();
                    }
                }
                catch
                {
                    MessageBox.Show("El campo Email no tiene un formato válido.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtEmail.Focus();
                    return false;
                }
            }
            // Validar que nif/cif sea único
            if (NifDuplicado(txtNifCif.Text.Trim()))
            {
                MessageBox.Show("El NIF/CIF ya existe en otro emisor. Debe ser único.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNifCif.Focus();
                return false;
            }
            return true; // Todos los datos son válidos
        }

        private bool NifDuplicado(string aNifCif)
        {
            MySqlCommand cmd = new MySqlCommand("SELECT COUNT(*) FROM emisores WHERE nifcif = @nifcif", Program.appDAM.LaConexion);
            cmd.Parameters.AddWithValue("@nifcif", aNifCif);
            if (edicion && _bs.Current is DataRowView currentRow)
            {
                int id = (int)currentRow["id"];
                cmd.CommandText += " AND id <> @id";
                cmd.Parameters.AddWithValue("@id", id);
            }
            int count = Convert.ToInt32(cmd.ExecuteScalar());
            return (count > 0);
        }
    }
}
