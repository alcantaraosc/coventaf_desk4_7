using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Model.ViewModels
{
    public class DetalleListOrdenCompra
    {
        public int Consecutivo { get; set; }
        public int Linea { get; set; }       
        public string ArticuloId { get; set; }
        public string CodigoBarra { get; set; }
        public string ArticuloProveedor { get; set; }
        public string Descripcion { get; set; }
        //columna (5)
        public decimal Cantidad { get; set; }
        //columna (6)
        public decimal Precio { get; set; }
        //columna (7)
        public decimal PorcentajeDescuento { get; set; }
        //columna (8)
        public decimal PorcentajeISC { get; set; }
        //columna (9)
        public decimal PorcentajeIVA { get; set; }

        public decimal CantidadRecibida { get; set; }

        public decimal Diferencia { get; set; }

        //cantidad * precio
        public decimal SubTotalLinea { get; set; }
        
        //DESCUENTO        
        public decimal DescuentoUnidad { get; set; }
        //descuento total
        public decimal MontoDesc { get; set; }
        public decimal CostoUnitDescuento { get; set; }
       
        //ISC
        public decimal ISCUnidad { get; set; }
        public decimal MontoISC { get; set; }
        public decimal CostoUnitISC { get; set; }

        //IVA
        public decimal IVAUnidad { get; set; }
        public decimal MontoIVA { get; set; }
        public decimal CostoIVA { get; set; }


        public decimal TotalLinea { get; set; }

        //public string Unidad { get; set; }

        public string UnidadFraccion { get; set; }                
  
        public bool Nuevo { get; set; }
              
    }
}
