using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Balanza.Configs;

namespace Balanza
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Logger log = new Logger();
            DAL datos = new DAL();
            
            if (!datos.licenciaValida(datos.obtenerParametro("LICENCIA")))
            {
                log.LogMessage("Licencia expirada!");
            }
            else
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new frmBalanza());
            }

        }
    }
}
