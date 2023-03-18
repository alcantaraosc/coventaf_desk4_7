using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Model.View
{
    public class ViewDevoluciones
    {
        public string Factura { get; set; }
        public string Tipo_Documento { get; set; }
        public decimal Saldo { get; set; }
        public decimal Monto_Local { get; set; }
        public decimal Monto_Dolar { get; set; }
        public decimal Anulada { get; set; }
        public string Cliente { get; set; }
        public string FormaPago { get; set; }
        public string Cobrado { get; set; }
 
    }
}
