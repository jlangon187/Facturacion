using FacturacionDAM.Modelos;
using FacturacionDAM.Utils;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace FacturacionDAM.Formularios
{
    public partial class FrmConceptosFac : Form
    {
        private Tabla _tabla;       // Tabla de datos asociada
        private BindingSource _bs;  // Para comunicación con los controles
        public bool edicion = false;

        public FrmConceptosFac(BindingSource bs, Tabla tabla)
        {
            InitializeComponent();
            _bs = bs;
            _tabla = tabla;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
            {
                return; // Si los datos no son válidos, no continuar
            }
            _bs.EndEdit();             // Termina la edición en el BindingSource
            _tabla.GuardarDatos();     // Guarda los datos en la tabla
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            _bs.CancelEdit();
            this.Close();
        }

        private void FrmConceptosFac_Load(object sender, EventArgs e)
        {
            txtCodigo.DataBindings.Add("Text", _bs, "codigo");
            txtDescripcion.DataBindings.Add("Text", _bs, "descripcion");
        }

        private void FrmConceptosFac_FormClosing(object sender, FormClosingEventArgs e)
        {
            _bs.CancelEdit(); // Cancelar cambios si se cierra con la X
        }

        private bool ValidarCampos()
        {
            // Validar que los campos obligatorios no estén vacíos
            if (string.IsNullOrWhiteSpace(txtCodigo.Text))
            {
                MessageBox.Show("El campo 'Código' es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCodigo.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                MessageBox.Show("El campo 'Descripción' es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDescripcion.Focus();
                return false;
            }
            // Validar que el código sea único
            int? idActual = edicion ? (int?)Convert.ToInt32(((DataRowView)_bs.Current)["id"]) : null;
            if (!Validaciones.EsValorCampoUnico("conceptosfac", "codigo", txtCodigo.Text.Trim(), idActual))
            {
                MessageBox.Show("El código del concepto de facturación ya existe. Debe ser único.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCodigo.Focus();
                return false;
            }
            // El nombre también debe ser único
            if (!Validaciones.EsValorCampoUnico("conceptosfac", "descripcion", txtDescripcion.Text.Trim(), idActual))
            {
                MessageBox.Show("La descripción del concepto de facturación ya existe. Debe ser única.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDescripcion.Focus();
                return false;
            }
            return true;
        }
    }
}
