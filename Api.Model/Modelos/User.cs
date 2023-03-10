using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Model.Modelos
{
    public static class User
    {
        public static string Usuario { get; set; } = "GERNESTO";
        public static string NombreUsuario { get; set; }
        public static string Token { get; set; }
        public static string TiendaID { get; set; }
        public static string NombreTienda { get; set; } = "tienda";
        public static string TelefonoTienda { get; set; }
        public static string DireccionTienda { get; set; }     
        public static DateTime expireAt { get; set; }
        public static string BodegaID { get; set; } = "EXHI";
        public static string NombreBodega { get; set; }
        public static string ConsecCierreCT { get; set; }
        public static string Caja { get; set; }
        public static string NivelPrecio { get; set; } = "";
        public static string MonedaNivel { get; set; } = "L";
        //public List<Roles> roles { get; set; }

    }
}
