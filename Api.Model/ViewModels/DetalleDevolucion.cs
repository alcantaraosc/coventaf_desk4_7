using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Model.ViewModels
{
    public class DetalleDevolucion
    {
        public int Consecutivo { get; set; }
        public int Linea { get; set; }
        public string ArticuloId { get; set; }
        public string Descripcion { get; set; }

        //columna (3)
        public decimal Cantidad { get; set; }
        //columna (4)
        public decimal PorcentDescuentArticulo { get; set; }   
        public string Lote { get; set; }
        public string UnidadFraccion { get; set; }
        public decimal PrecioCordobas { get; set; }
        public decimal PrecioDolar { get; set; }
        public char Moneda { get; set; }

        public string CantidadDevolver { get; set; }
    
        public decimal SubTotalCordobas { get; set; }
        public decimal SubTotalDolar { get; set; }

        public decimal DescuentoPorLineaCordoba { get; set; }
        public decimal DescuentoPorLineaDolar { get; set; }

        public decimal MontoDescGeneralDolar { get; set; }
        public decimal MontoDescGeneralCordoba { get; set; }
        public decimal TotalCordobas { get; set; }
        public decimal TotalDolar { get; set; }

        public decimal Cost_Prom_Loc { get; set; }
        public decimal Cost_Prom_Dol { get; set; }

  
    }
}
