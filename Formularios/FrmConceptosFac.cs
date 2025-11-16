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
    }
}
