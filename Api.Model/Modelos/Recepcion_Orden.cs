using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Model.Modelos
{
    public class Recepcion_Orden
    {
        [Required]
        [StringLength(10)]
        public string Orden_Compra { get; set; }
        [Required]
        [StringLength(50)]
        public string Factura { get; set; }
        [Required]
        [StringLength(25)]
        public string Usuario { get; set; }
        [Required]
        public DateTime Fecha_Registra { get; set; }
        [Required]
        [StringLength(20)]
        public string Proveedor { get; set; }
        [Required]
        [StringLength(4)]
        public string Bodega { get; set; }
        [Required]
        public decimal Tipocambio { get; set; }
        [Required]
        [StringLength(4)]
        public string Condicion_Pago { get; set; }

        [StringLength(300)]
        public string Nota { get; set; }
        [Required]
        public DateTime Fecha_Recepcion { get; set; }
        [Required]
        public decimal Sub_Total { get; set; }
        [Required]
        public decimal Por_Descuento { get; set; }
        [Required]
        public decimal Monto_Desc { get; set; }
        [Required]
        public decimal Monto_Isc { get; set; }
        [Required]
        public decimal Monto_Iva { get; set; }
        [Required]
        public decimal Costo { get; set; }
        [Required]
        public decimal Monto_Total { get; set; }
        [Required]
        public decimal Monto_Factura { get; set; }
        [Required]
        public decimal Total_Item { get; set; }
        [Required]
        public decimal Total_Item_Recibido { get; set; }
        [Required]
        public decimal Total_Unidades { get; set; }
        [Required]
        public decimal Total_Unidades_Recibido { get; set; }
        [StringLength(25)]
        public string Usuario_Edita { get; set; }
        public DateTime? Fecha_Edita { get; set; }
        public int EstadoID { get; set; }
   
    }
}
