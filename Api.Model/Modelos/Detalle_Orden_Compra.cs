using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Model.Modelos
{
    public class Detalle_Orden_Compra
    {
        [NotMapped]
        public bool Nuevo { get; set; }

        [Required]
        [StringLength(10)]
        public string Orden_Compra { get; set;}
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
        public decimal Cantidad_Orden { get; set; }
        [Required]
        public decimal Cantidad_Recibida { get; set; } = 0.00M;
        [Required]
        public decimal Precio { get; set; }
        [Required]
        public decimal Porcentaje_Desc { get; set; }
        [Required]
        public decimal Porcentajae_Isc { get; set; }
        [Required]
        public decimal Porcentaje_Iva { get; set; }
        [Required]
        public decimal Monto_Desc { get; set; }
        [Required]
        public decimal Monto_Isc { get; set; }
        [Required]
        public decimal Monto_Iva { get; set; }
        [Required]
        public decimal Costo { get; set; }
        [Required]
        public decimal Total_Linea { get; set; }

        [Required]
        public string Usuario { get; set; }
        [Required]
        public DateTime Fecha_Registro { get; set; }       
        public string Usuario_Edita { get; set; }
        public DateTime? Fecha_Edita { get; set; }
    }
}
