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
            // Actualiza el estado de la barra de herramientas
            RefreshToolBar();

            // Actualiza la informacion de la barra de estado
            RefreshStatusBar();
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
            AbrirFormularioHijo<FrmEmisores>();
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

        private void RefreshToolBar()
        {
            if (Program.appDAM.estadoApp == EstadoApp.Conectado)
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
                                item.Enabled = (Program.appDAM.estadoApp == EstadoApp.ConectadoSinEmisor) ? true : false;
                                break;
                            default:
                                item.Enabled = false;
                                break;
                        }
                    }
                }
            }
        }

        private void RefreshStatusBar()
        {
            if
        }
    }
}
