using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Model.ViewModels
{
    public class TicketFacturaLinea
    {
        //detalles de la Devolucion, Factura Linea
        public decimal Cantidad { get; set; }
        public decimal Precio { get; set; }
        public decimal DescuentoLinea { get; set; }
        public decimal Monto { get; set; }
        public string DescripcionArticulo { get; set; }
    }
}
