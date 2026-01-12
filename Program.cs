using FacturacionDAM.Modelos;
using FacturacionDAM.Formularios;

namespace FacturacionDAM
{
    internal static class Program
    {
        public static AppDAM appDAM;

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            FrmMain fr = new FrmMain();
            appDAM = new AppDAM();
            appDAM.frmMain = fr;
            Application.Run(fr);
        }
    }
}