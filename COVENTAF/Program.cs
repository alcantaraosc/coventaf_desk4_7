using Api.Service.DataService;
using Api.Setting;
using COVENTAF.Descuentos;
using COVENTAF.ModuloAcceso;
using COVENTAF.ModuloCliente;
using COVENTAF.PuntoVenta;
using COVENTAF.Security;
using System;
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
            ConectionContext.Server = Properties.Settings.Default.Servidor;
            //esta es otra manera
            //ConectionContext.Server = (string)Properties.Settings.Default["Servidor"];
            ConectionContext.DataBase = Properties.Settings.Default.BaseDato;
            ConectionContext.User = Properties.Settings.Default.Usuario;
            ConectionContext.Password = Properties.Settings.Default.Password;
        
            #endregion

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmLogIn());
        }
    }
}
