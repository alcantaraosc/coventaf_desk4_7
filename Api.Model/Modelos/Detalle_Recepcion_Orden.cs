using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Model.Modelos
{
    public class Detalle_Recepcion_Orden
    {
        [Required]
        [StringLength(10)]
        public string Orden_Compra { get; set; }
        [Required]
        public int Linea { get; set; }
        [Required]
        [StringLength(20)]
        public string Articulo { get; set; }
        [Required]
        [StringLength(50)]
        public string Codigo_Barra { get; set; }
        [Required]
        [StringLength(300)]
        public string Descripcion { get; set; }
        [Required]
        public decimal Cantidad_Ordenada { get; set; }
        [Required]
        public decimal Cantidad_Recibida { get; set; }

        [Required]
        public decimal Diferencia { get; set; }

        //[Required]
        //public decimal Precio { get; set; }
        //[Required]
        //public decimal Porcentaje_Desc { get; set; }
        //[Required]
        //public decimal Porcentajae_Isc { get; set; }
        //[Required]
        //public decimal Porcentaje_Iva { get; set; }
        //[Required]
        //public decimal Monto_Descuento { get; set; }
        //[Required]
        //public decimal Monto_Isc { get; set; }
        //[Required]
        //public decimal Monto_Iva { get; set; }
        //[Required]
        //public decimal Total_Linea { get; set; }
        [Required]
        [StringLength(25)]
        public string Usuario_Recibe { get; set; }
        public DateTime Fecha_Recibe { get; set; }
        [StringLength(25)]
        public string Usuario_Edita { get; set; }
        public DateTime? Fecha_Edita { get; set; }
    }
}
