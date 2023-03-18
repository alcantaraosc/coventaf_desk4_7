using Api.Model.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Model.ViewModels
{
    public class ViewModelFacturacion
    {
        public Facturas Factura { get; set; }
        public List<Factura_Linea> FacturaLinea { get; set; }
        public List<Pago_Pos> PagoPos { get; set; }
        public List<Factura_Retencion> FacturaRetenciones { get; set; }

        public List<Forma_Pagos> FormasPagos { get; set; }

        public string NoDevolucion { get; set; }
    }
}
