using Api.Model.Modelos;
using System.Collections.Generic;

namespace Api.Model.ViewModels
{
    public class ViewModelFacturacion
    {
        public Facturas Factura { get; set; }
        public List<Factura_Linea> FacturaLinea { get; set; }
        public List<Pago_Pos> PagoPos { get; set; }
        public List<Factura_Retencion> FacturaRetenciones { get; set; }
        public List<Forma_Pagos> FormasPagos { get; set; }
        public Auxiliar_Pos AuxiliarPos { get; set; }
        public List<Auxiliar_Pos> ListAuxiliarPos { get; set; }
        public Documento_Pos Documento_Pos { get; set; }
        public string NoDevolucion { get; set; }        
        public List<Retenciones> Retenciones { get; set; }
    }
}
