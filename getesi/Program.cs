using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using getesi.Frames;
using getesi.DAO;
namespace getesi
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            frmLogin frmLogin = new frmLogin();
            frmPrincipal frmPrincipal = new Frames.frmPrincipal();
             Application.Run(frmLogin);
            if (frmLogin.DialogResult == DialogResult.OK)
                Application.Run(new frmPrincipal());
            
        }
    }
}
