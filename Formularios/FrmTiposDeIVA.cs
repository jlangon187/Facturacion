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
            txtDescripcion.DataBindings.Clear();
            nUDPorcentaje.DataBindings.Clear();
            cBActivo.DataBindings.Clear();

            txtDescripcion.DataBindings.Add("Text", _bs, "descripcion", true, DataSourceUpdateMode.OnPropertyChanged, string.Empty);
            nUDPorcentaje.DataBindings.Add("Value", _bs, "porcentaje", true, DataSourceUpdateMode.OnPropertyChanged, 0m);
            cBActivo.DataBindings.Add("Checked", _bs, "activo", true, DataSourceUpdateMode.OnPropertyChanged, false);
        }

        private void FrmTiposDeIVA_FormClosing(object sender, FormClosingEventArgs e)
        {
            _bs.CancelEdit(); // Cancelar cambios si se cierra con la X
        }
    }
}
