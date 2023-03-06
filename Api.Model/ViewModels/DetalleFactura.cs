using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Model.ViewModels
{
    public class DetalleFactura
    {        
        public int Consecutivo { get; set; }
        public string ArticuloId { get; set; }        
        public string CodigoBarra { get; set; }
        public decimal Cantidad { get; set; }
        public decimal PorCentajeDescXArticulo { get; set; }
        public string Descripcion { get; set; }
        public string Unidad { get; set; }
        
        public decimal CantidadExistencia { get; set; }
        public string UnidadFraccion { get; set; }
        public decimal PrecioDolar { get; set; }        
        public decimal PrecioCordobas { get; set; }
        public char Moneda { get; set; }
        public string BodegaID { get; set; }
        public string NombreBodega { get; set; }
        public decimal SubTotalDolar { get; set; }
        public decimal SubTotalCordobas { get; set; }               
        public decimal DescuentoPorLineaDolar { get; set; }        
        public decimal DescuentoPorLineaCordoba { get; set; }
        
        public decimal MontoDescGeneralCordoba { get; set; }
        public decimal MontoDescGeneralDolar { get; set; }
        public decimal TotalDolar { get; set; }       
        public decimal TotalCordobas { get; set; }
        public decimal Cost_Prom_Dol { get; set; }
        public decimal Cost_Prom_Loc { get; set; }
        

    }
}
