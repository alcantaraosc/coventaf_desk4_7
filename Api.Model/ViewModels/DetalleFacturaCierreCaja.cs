using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Model.ViewModels
{
    public class DetalleFacturaCierreCaja
    {
        public string Factura { get; set; }
        public decimal Impuesto { get; set; }
        public string Caja { get; set; }
        public decimal Descuento { get; set; }
        public string Cobrado { get; set; }
        public decimal TotalPagar { get; set; }
        public decimal MontoRetencion { get; set; }
        //este es el documento de cierre de caja que se encuentra en la tabla CIERRE_CAJA
        public string Documento { get; set; }

    }
}
