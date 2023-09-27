using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Model.ViewModels
{
    public class ViewModelArticulo
    {
       
        public string ArticuloID { get; set; }
        public string CodigoBarra { get; set; } = "";
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public string Activo { get; set; }
        public decimal Existencia { get; set; }
        public string BodegaID { get; set; }
        public string NombreBodega { get; set; }
        public string NivelPrecio { get; set; }
        public string UnidadVenta { get; set; }
        public string UnidadFraccion { get; set; }
        public char Moneda { get; set; }
        public string Lote { get; set; } 
        public DateTime? FechaVencimiento {get; set;}
        public decimal Descuento { get; set; }
        public string Localizacion { get; set; } 
        public decimal ExistenciaPorLote { get; set; } 
        public string UsaLote { get; set; }
        public decimal Cost_Prom_Dol { get; set; }
        public decimal Costo_Prom_Loc { get; set; }
        public string Articulo_Del_Prov { get; set; }
        //aqui me indica si es un articulo para pesar.
        public string Es_Articulo_Peso { get; set; }
        public decimal Cantidad { get; set; }
        public decimal Costo_Ult_Loc { get; set; } = 0.0000M;
    }
}
