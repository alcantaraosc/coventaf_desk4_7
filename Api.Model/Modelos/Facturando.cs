﻿
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Model.Modelos
{
    public class Facturando
    {
        [Required]
        [StringLength(50)]
        public string Factura { get; set; }
        [Required]
        [StringLength(50)]
        public string ArticuloID { get; set; }
        [Required]
        [StringLength(50)]
        public string CodigoCliente { get; set; }
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
        public DateTime FechaRegistro { get; set; }
        /* [Required]
         [Column(TypeName = "decimal(28, 8)")]
         public decimal TipoCambio { get; set; }*/
        [Required]        
        public decimal TipoCambio { get; set; }
        [Required]
        [StringLength(50)]
        public string BodegaID { get; set; }
        [Required]
        public int Consecutivo { get; set; }
        [Required]
        [StringLength(50)]
        public string CodigoBarra { get; set; }
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
    }
}
