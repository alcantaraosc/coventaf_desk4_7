using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Model.Modelos
{
    public class Orden_Compras
    {
        [Required]
        [StringLength(10)]
        public string Orden_Compra { get; set; }
   
        [Required]
        [StringLength(25)]
        public string Usuario { get; set; }
        [Required]
        public DateTime Fecha_Registro { get; set; }
        [Required]
        [StringLength(20)]
        public string Proveedor { get; set; }
        [NotMapped]
        public string Nombre_Proveedor { get; set; }
        [Required]
        [StringLength(4)]
        public string Bodega { get; set; }
        [NotMapped]
        public string Nombre_Bodega { get; set; }        
        [Required]
        [StringLength(4)]
        public string Condicion_Pago { get; set; }

        [StringLength(300)]
        public string Nota { get; set; }
  
        [Required]
        public DateTime Fecha_Pedido { get; set; }
        
        public DateTime? Fecha_Entrega { get; set; }
        [Required]
        public decimal Sub_Total { get; set; }   
        [Required]
        public decimal Monto_Desc { get; set; }
        [Required]
        public decimal Monto_ISC { get; set; }
        [Required]
        public decimal Monto_IVA { get; set; }
        [Required]
        public decimal Monto_Total { get; set; }
      
        public string Usuario_Edita { get; set; }
        public DateTime? Fecha_Edita { get; set; }
        [Required]
        public int EstadoID { get; set; }
        [NotMapped]
        public string Estado { get; set; }
        [Required]
        public decimal Total_Item { get; set; }
        [Required]
        public decimal Total_Unidades { get; set; }
    }
}
