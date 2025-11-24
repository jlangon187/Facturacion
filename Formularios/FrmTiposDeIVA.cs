using FacturacionDAM.Modelos;
using FacturacionDAM.Utils;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace FacturacionDAM.Formularios
{
    public partial class FrmTiposDeIVA : Form
    {
        private Tabla _tabla;       // Tabla de Tipos de IVA
        private BindingSource _bs;  // Para comunicación con los controles
        public bool edicion = false;

        public FrmTiposDeIVA(BindingSource bs, Tabla tabla)
        {
            InitializeComponent();
            _bs = bs;
            _tabla = tabla;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
            {
                ForzarValoresNoNulos();
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

        private void FrmTiposDeIVA_Load(object sender, EventArgs e)
        {
            if (!edicion)
            {
                var row = (DataRowView)_bs.Current;
                row["activo"] = true;
            }

            txtDescripcion.DataBindings.Add("Text", _bs, "descripcion");
            nUDPorcentaje.DataBindings.Add("Value", _bs, "porcentaje", true, DataSourceUpdateMode.OnPropertyChanged, 0m);
            cBActivo.DataBindings.Add("Checked", _bs, "activo", true, DataSourceUpdateMode.OnPropertyChanged, false);
        }

        private void FrmTiposDeIVA_FormClosing(object sender, FormClosingEventArgs e)
        {
            _bs.CancelEdit(); // Cancelar cambios si se cierra con la X
        }

        private bool ValidarCampos()
        {
            // Validar que los campos obligatorios no estén vacíos
            if (string.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                MessageBox.Show("El campo 'Descripción' es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDescripcion.Focus();
                return false;
            }
            // No se repite el porcentaje de IVA
            int? idActual = edicion ? (int?)Convert.ToInt32(((DataRowView)_bs.Current)["id"]) : null;
            if (!Validaciones.EsValorCampoUnico("tiposiva", "porcentaje", nUDPorcentaje.Value.ToString(), idActual))
            {
                MessageBox.Show("El porcentaje de IVA ya existe. Debe ser único.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                nUDPorcentaje.Focus();
                return false;
            }
            return true;
        }

        private void ForzarValoresNoNulos()
        {
            if (_bs.Current is DataRowView row)
            {
                if (row["activo"] == DBNull.Value)
                {
                    row["activo"] = false;
                }
            }
        }
    }
}
