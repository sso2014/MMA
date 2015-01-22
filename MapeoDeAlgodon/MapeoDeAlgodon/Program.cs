using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Data;

namespace MapeoDeAlgodon
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
        //    Application.EnableVisualStyles();
        //    Application.SetCompatibleTextRenderingDefault(false);
            //FrmLogin login = new FrmLogin();
            //Application.Run(login);
            var view = new FrmMain();
            var repositorio = new Repository();    
            var presenter = new Presentador(view, repositorio);
            Application.Run(view);
        }
    }
}
