using FacturacionDAM.Modelos;
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
    public partial class FrmBrowEmisores : Form
    {
        private Tabla _tabla;       // Tabla de emisores
        private BindingSource _bs;  // Para comnunicación con los controles
        public FrmBrowEmisores()
        {
            InitializeComponent();
            _bs = new BindingSource();
            _tabla = new Tabla(Program.appDAM.LaConexion);
        }

        private void FrmBrowEmisores_Load(object sender, EventArgs e)
        {
            if (_tabla.InicializarDatos("SELECT * FROM emisores;"))
            {
                _bs.DataSource = _tabla.LaTabla;
                dgTabla.DataSource = _bs;
            }
            else
            {
                MessageBox.Show("No se han podido cargar los emisores.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
            ActualizarEstado();
        }

        private void btnFirst_Click(object sender, EventArgs e) => _bs.MoveFirst();

        private void btnPrev_Click(object sender, EventArgs e) => _bs.MovePrevious();

        private void btnNext_Click(object sender, EventArgs e) => _bs.MoveNext();

        private void btnLast_Click(object sender, EventArgs e) => _bs.MoveLast();

        private void btnNew_Click(object sender, EventArgs e)
        {
            _bs.AddNew();
            /*
            FrmEmisor frm = new FrmEmisor(_bs, _tabla);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                _tabla.Refrescar();
                ActualizarEstado();
            }
            */
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (_bs.Current is DataRowView row)
            {
                /*
                FrmEmisor frm = new FrmEmisor(_bs, _tabla);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    _tabla.Refrescar();
                    ActualizarEstado();
                }
                */
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_bs.Current is DataRowView row)
            {
                if (MessageBox.Show("¿Estás seguro de que deseas eliminar este emisor?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    _bs.RemoveCurrent();
                    _tabla.GuardarDatos();
                    ActualizarEstado();
                }
            }
        }

        /*********** Métodos privados ***********/

        private void ActualizarEstado()
        {
            tsStatusLabel.Text = $"Nº de Registros: {_bs.Count}";   // Actualiza la barra de estado
        }
    }
}
