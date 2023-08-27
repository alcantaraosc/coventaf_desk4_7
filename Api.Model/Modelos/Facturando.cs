
using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Model.Modelos
{
    public class Facturando
    {

        [Required]
        [StringLength(50)]
        public string Factura { get; set; }
        [Required]
        public int Consecutivo { get; set; }
        [Required]
        [StringLength(50)]
        public string ArticuloID { get; set; }
        [Required]
        [StringLength(50)]
        public string CodigoBarra { get; set; }
        [Required]
        [StringLength(50)]
        public string CodigoCliente { get; set; }       
        [StringLength(15)]
        public string Lote { get; set; }      
        [StringLength(8)]
        public string Localizacion { get; set; }
        [Required]
        public bool FacturaEnEspera { get; set; }
  
        [Required]
        [StringLength(50)]
        public string Cajero { get; set; }
        [Required]
        [StringLength(50)]
        public string Caja { get; set; }
        [Required]
        [StringLength(50)]
        public string NumCierre { get; set; }
        [Required]
        [StringLength(50)]
        public string TiendaID { get; set; }

        /* [Required]
         [Column(TypeName = "decimal(28, 8)")]
         public decimal TipoCambio { get; set; }*/
        [Required]
        public decimal TipoCambio { get; set; }

        [Required]
        [StringLength(50)]
        public string BodegaID { get; set; }
        [Required]
        public decimal Cantidad { get; set; }
        [Required]
        [StringLength(200)]
        public string Descripcion { get; set; }
        [Required]
        [StringLength(50)]
        public string Unidad { get; set; }
        [Required]
        public decimal Precio { get; set; }
        [Required]
        [StringLength(1)]
        public string Moneda { get; set; }
        [Required]
        public decimal DescuentoLinea { get; set; }
        [Required]
        public decimal DescuentoGeneral { get; set; }
        [Required]
        public bool AplicarDescuento { get; set; }
        public string Observaciones { get; set; }
        [Required]
        public DateTime FechaRegistro { get; set; }
    }
}
