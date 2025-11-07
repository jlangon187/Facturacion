using FacturacionDAM.Modelos;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace FacturacionDAM.Formularios
{
    public partial class FrmCliente : Form
    {
        private Tabla _tabla;       // Tabla de clientes
        private BindingSource _bs;  // Para comunicación con los controles
        public bool edicion = false;

        public FrmCliente(BindingSource bs, Tabla tabla)
        {
            InitializeComponent();
            _bs = bs;
            _tabla = tabla;
        }

        /*private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (!ValidarDatos())
                return;

            _bs.EndEdit();             // Termina la edición en el BindingSource
            _tabla.GuardarDatos();     // Guarda los datos en la tabla
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            _bs.CancelEdit();
            this.Close();
        }*/

        /*private void FrmCliente_Load(object sender, EventArgs e)
        {
            txtNifCif.DataBindings.Add("Text", _bs, "nifcif");
            txtNombre.DataBindings.Add("Text", _bs, "nombre");
            txtApellidos.DataBindings.Add("Text", _bs, "apellidos");
            txtNombreComercial.DataBindings.Add("Text", _bs, "nombrecomercial");
            txtDireccion.DataBindings.Add("Text", _bs, "direccion");
            txtPoblacion.DataBindings.Add("Text", _bs, "poblacion");
            txtCodigoPostal.DataBindings.Add("Text", _bs, "cpostal");
            cbProvincia.DataBindings.Add("SelectedValue", _bs, "idprovincia");
            txtTelefono.DataBindings.Add("Text", _bs, "telefono");
            txtEmail.DataBindings.Add("Text", _bs, "email");

            // Cargar provincias
            Tabla tablaProvincias = new Tabla(Program.appDAM.LaConexion);
            tablaProvincias.InicializarDatos("SELECT * FROM provincias;");
            cbProvincia.DataSource = tablaProvincias.LaTabla;
            cbProvincia.DisplayMember = "nombreprovincia";
            cbProvincia.ValueMember = "id";
            cbProvincia.SelectedIndex = 0;

            // Desactivar AcceptButton si usas algún campo multilinea (opcional)
        }

        private void FrmCliente_FormClosing(object sender, FormClosingEventArgs e)
        {
            _bs.CancelEdit(); // Cancelar cambios si se cierra con la X
        }

        private bool ValidarDatos()
        {
            // Validar que NIF/CIF no esté vacío
            if (string.IsNullOrWhiteSpace(txtNifCif.Text))
            {
                MessageBox.Show("El campo NIF/CIF no puede estar vacío.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNifCif.Focus();
                return false;
            }

            // Validar que el nombre comercial no esté vacío
            if (string.IsNullOrWhiteSpace(txtNombreComercial.Text))
            {
                MessageBox.Show("El campo Nombre Comercial no puede estar vacío.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombreComercial.Focus();
                return false;
            }

            // Validar formato del email (si no está vacío)
            if (!string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                try
                {
                    var addr = new System.Net.Mail.MailAddress(txtEmail.Text);
                    if (addr.Address != txtEmail.Text)
                        throw new FormatException();
                }
                catch
                {
                    MessageBox.Show("El correo electrónico no tiene un formato válido.",
                        "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtEmail.Focus();
                    return false;
                }
            }

            // Comprobar duplicado del NIF/CIF
            if (NifDuplicado(txtNifCif.Text.Trim()))
            {
                MessageBox.Show("El NIF/CIF ya existe en otro cliente. Debe ser único.",
                    "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNifCif.Focus();
                return false;
            }

            return true;
        }

        private bool NifDuplicado(string aNifCif)
        {
            MySqlCommand cmd = new MySqlCommand("SELECT COUNT(*) FROM clientes WHERE nifcif = @nifcif", Program.appDAM.LaConexion);
            cmd.Parameters.AddWithValue("@nifcif", aNifCif);

            if (edicion && _bs.Current is DataRowView currentRow)
            {
                int id = (int)currentRow["id"];
                cmd.CommandText += " AND id <> @id";
                cmd.Parameters.AddWithValue("@id", id);
            }

            int count = Convert.ToInt32(cmd.ExecuteScalar());
            return count > 0;
        }*/
    }
}
