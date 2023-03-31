namespace Api.Model.ViewModels
{
    public class DetalleFactura
    {
        public int Consecutivo { get; set; }
        public string ArticuloId { get; set; }
        public string CodigoBarra { get; set; }
        //columna (3)
        public string Cantidad { get; set; }
        //columna (4)

        public string PorcentDescuentArticulo { get; set; }
        public string Descripcion { get; set; }
        public string Unidad { get; set; }

        public decimal Existencia { get; set; }
        public string UnidadFraccion { get; set; }
        public decimal PrecioCordobas { get; set; }
        public decimal PrecioDolar { get; set; }
        
        public char Moneda { get; set; }
        public string BodegaId { get; set; }
        public string NombreBodega { get; set; }
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

        //columna 24
        public decimal Cantidad_d { get; set; }
        //columna 25
        public decimal PorcentDescuentArticulo_d { get; set; }

       
    }
}
