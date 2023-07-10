using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Model.View
{
    public class ViewRecibo
    {
        public string Factura { get; set; }
        public string Caja { get; set; }
        public string Cliente { get; set; }
        public string Nombre_Cliente { get; set; }
        public decimal Saldo { get; set; }
        public decimal Total_Anticipo { get; set; }
        public string Cajero { get; set; }
        public DateTime Fecha { get; set; }        
        public string Num_Cierre { get; set; }
        public string Tipo_Documento { get; set; }
        public string Estado_Caja { get; set; }
        //public string Estado_Cajero { get; set; }
        public string Tienda_Enviado { get; set; }
        public string UnidadNegocio { get; set; }
    }
}
