using Api.Service.DataService;
using Api.Setting;
using COVENTAF.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COVENTAF
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {

            //Registramos el DbContext
            #region cadena de conexion
            //declara una variable (conection) que esta llamando a la clase ConectionContext (dicha clase se encuentra en Api.Setting)

            string strConection = $"Server={ConectionContext.Server}; Database={ConectionContext.DataBase}; user id={ConectionContext.User}; password={ConectionContext.Password}";
            //asignar la cadena de conexion para adonet
            ADONET.strConnect = strConection;
            #endregion

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmLogIn());
        }
    }
}
