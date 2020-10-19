using System;
using System.Windows.Forms;

namespace Zambon.Alura.CertificacaoCSharp.MemoryManagement.TypeIDisposable
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void _Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmMensagem());
        }
    }
}