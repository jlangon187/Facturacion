using System.Xml.Serialization;
using FacturacionDAM.Modelos;

namespace FacturacionDAM.Formularios
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (Program.appDAM.conectado)
            {
                var resultado = MessageBox.Show(
                    "Hay una conexión abierta. ¿Deseas cerrarla y salir?",
                    "Conexión abierta",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (resultado == DialogResult.Yes)
                {
                    Program.appDAM.DesconectarDB();
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            // Refresca los controles de la ventana principal
            RefrescarControles();
            SeleccionarEmisor();

#if DEBUG
            tsMenuConsola.Visible = true;
#else
                    tsMenuConsola.Visible = false;
#endif
        }

        private void tsBtnConfig_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<FrmConfig>();

            foreach (Form frm in this.MdiChildren)
            {
                if (frm is FrmConfig)
                {

                    if (frm.WindowState == FormWindowState.Minimized)
                        frm.WindowState = FormWindowState.Normal;

                    frm.Activate();
                    return;
                }
            }

            FrmConfig newForm = new FrmConfig();
            newForm.MdiParent = this;
            newForm.Show();
        }

        private void tsBtnSalir_Click(object sender, EventArgs e)
        {
            CerrarFormulariosHijos();
            this.Close();
        }

        private void tsBtnEmisores_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo<FrmBrowEmisores>();
        }

        /*********** METODOS PRIVADOS ***********/

        private void CerrarFormulariosHijos()
        {
            foreach (Form frm in this.MdiChildren)
            {
                frm.Close();
            }
        }

        /// <summary>
        /// Abre un formulario hijo MDI del tipo especificado.
        /// Si el formulario ya esta abierto, lo activa en lugar de abrir uno nuevo.
        /// </summary>
        /// <typeparam name="T"> El tipo concreto del formulario </typeparam>
        private void AbrirFormularioHijo<T>() where T : Form, new()
        {
            foreach (Form frm in this.MdiChildren)
            {
                if (frm is T)
                {
                    // Si la ventana esta minimizada, la restauro
                    if (frm.WindowState == FormWindowState.Minimized)
                        frm.WindowState = FormWindowState.Normal;
                    frm.Activate();
                    return;
                }
            }
            T nuevoForm = new T();
            nuevoForm.MdiParent = this;
            // nuevoForm.WindowState = FormWindowState.Maximized;
            nuevoForm.Show();
        }

        public void RefreshToolBar()
        {
            foreach (ToolStripItem item in tsToolMain.Items)
            {
                if (item is ToolStripButton btn)
                {
                    switch (item.Name)
                    {
                        case "tsBtnConfig":
                            item.Enabled = true;
                            break;

                        case "tsBtnSalir":
                            item.Enabled = true;
                            break;

                        case "tsBtnEmisores":
                            // Habilitado solo si el estado es ConectadoSinEmisor
                            item.Enabled = ((Program.appDAM.estadoApp == EstadoApp.ConectadoSinEmisor)
                                || (Program.appDAM.estadoApp == EstadoApp.Conectado));
                            break;

                        default:
                            // Solo habilitamos otros botones si hay conexión
                            item.Enabled = (Program.appDAM.estadoApp == EstadoApp.Conectado);
                            break;
                    }
                }
            }
        }


        public void RefreshStatusBar()
        {
            if (Program.appDAM.emisor == null)
            {
                tsLbEmisor.Text = "Sin emisor seleccionado";
            }
            else
            {
                tsLbEmisor.Text = $"{Program.appDAM.emisor.nombre} - NIF: {Program.appDAM.emisor.nifcif}";
            }
            switch (Program.appDAM.estadoApp)
            {
                case EstadoApp.Conectado:
                    tsLbEstado.Text = "Conectado a la base de datos";
                    break;
                case EstadoApp.SinConexion:
                    tsLbEstado.Text = "No conectado a la base de datos";
                    break;
                case EstadoApp.ConectadoSinEmisor:
                    tsLbEstado.Text = "Conectado a la base de datos";
                    break;
                case EstadoApp.Error:
                    if (Program.appDAM.ultimoError != "")
                        tsLbEstado.Text = "Se ha producido un error, revisa el log";
                    else
                        tsLbEstado.Text = "Se ha producido un error";
                    break;
            }
        }
        public void RefrescarControles()
        {
            RefreshToolBar();
            RefreshStatusBar();
        }

        private void tsMenuConsola_Click(object sender, EventArgs e)
        {
#if DEBUG
            AbrirFormularioHijo<FrmConsola>();
#else

            // Opcional: mensaje si alguien lo ejecuta de alguna manera
            MessageBox.Show("Esta consola solo está disponible en modo Depuración.",
                            "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Program.appDAM.RegistrarLog("FrmMain", "Intento de abrir consola en modo no depuración.");
#endif
        }

        private void SeleccionarEmisor()
        {
            if (Program.appDAM.estadoApp == EstadoApp.ConectadoSinEmisor || Program.appDAM.estadoApp == EstadoApp.Conectado)
            {
                using (var frm = new FrmSeleccionarEmisor())
                {
                    frm.Owner = this;
                    var result = frm.ShowDialog();

                    if (result == DialogResult.OK)
                    {
                        Program.appDAM.estadoApp = EstadoApp.Conectado;
                        RefrescarControles();
                    }
                }
            }
        }

        private void seleccionarEmisorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CerrarFormulariosHijos();
            SeleccionarEmisor();
        }
    }
}
