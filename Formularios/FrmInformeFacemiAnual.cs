using System;
using System.Windows.Forms;

namespace FacturacionDAM.Formularios
{
    public partial class FrmInformeFacemiAnual : Form
    {
        public FrmInformeFacemiAnual()
        {
            InitializeComponent();
        }

        private void btnInforme_Click(object sender, EventArgs e)
        {
            // Validamos que las fechas tengan sentido antes de cerrar
            if (dTPAnoInicio.Value > dTPAnoFin.Value)
            {
                MessageBox.Show("La fecha de inicio no puede ser mayor que la fecha de fin.", "Error en fechas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Simplemente indicamos que todo está OK y cerramos.
            // Los datos (las fechas) los leerá FrmBrowFacemi accediendo a los controles publicos.
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        // Si tienes un botón cancelar (opcional), asegúrate de que haga esto:
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}