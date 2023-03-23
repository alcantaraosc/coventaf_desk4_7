using System;

namespace Api.Model.View
{
    public class ViewFactura
    {
        public string Factura { get; set; }
        public string Caja { get; set; }
        public string Cliente { get; set; }
        public string Nombre_Cliente { get; set; }
        public decimal Total_Factura { get; set; }
        public string Usuario { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Total_Unidades { get; set; }
        public string Num_Cierre { get; set; }
        public string Tipo_Documento { get; set; }
        public string Estado_Caja { get; set; }
        public string Estado_Cajero { get; set; }
        public string Tienda_Enviado { get; set; }
        public string UnidadNegocio { get; set; }

    }
}
