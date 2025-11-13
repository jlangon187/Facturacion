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
    public partial class FrmSeleccionarEmisor : Form
    {
        private Tabla _tablaEmisores;
        private BindingSource _bsEmisores = new BindingSource();
        public FrmSeleccionarEmisor()
        {
            InitializeComponent();
        }

        private void FrmSeleccionarEmisor_Load(object sender, EventArgs e)
        {
            // Cargar los emisores desde la base de datos
            _tablaEmisores = new Tabla(Program.appDAM.LaConexion);
            if (_tablaEmisores.InicializarDatos("SELECT * FROM emisores"))
            {
                _bsEmisores.DataSource = _tablaEmisores.LaTabla;
                cbEmisor.DataSource = _bsEmisores;
                cbEmisor.DisplayMember = "nombrecomercial";
                cbEmisor.ValueMember = "id";
            }
            else
            {
                MessageBox.Show("No se han podido cargar los emisores desde la base de datos.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Program.appDAM.estadoApp = EstadoApp.Error;
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }

        /// <summary>
        /// Metodo que se ejecuta al hacer clic en el botón de selección de emisor.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelection_Click(object sender, EventArgs e)
        {
            // Obtener el emisor seleccionado
            if (_bsEmisores.Current is DataRowView row)
            {
                Emisor emisorSeleccionado = new Emisor
                {
                    id = Convert.ToInt32(row["id"]),
                    nifcif = row["nifcif"].ToString(),
                    nombre = row["nombre"].ToString(),
                    apellidos = row["apellidos"].ToString(),
                    nombreComercial = row["nombrecomercial"].ToString()
                };

                Program.appDAM.emisor = emisorSeleccionado;
                Program.appDAM.estadoApp = EstadoApp.Conectado;

                // Refresca directamente la ventana principal si está abierta
                if (this.Owner is FrmMain frmMain)
                    frmMain.RefrescarControles();

                this.DialogResult = DialogResult.OK;
                this.Close();
            }

            else
            {
                MessageBox.Show("No se ha seleccionado ningún emisor.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Metodo que se ejecuta al hacer clic en el botón de cancelar selección de emisor.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Program.appDAM.estadoApp = EstadoApp.ConectadoSinEmisor;
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
