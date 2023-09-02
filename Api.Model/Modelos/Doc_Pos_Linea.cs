using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Model.Modelos
{
    public class Doc_Pos_Linea
    {
       
        [Required]
        [StringLength(50)]
        public string Documento { get; set; }
        [Required]
        [StringLength(1)]
        public string Tipo { get; set; }
        [Required]
        [StringLength(6)]
        public string Caja { get; set; }
        [Required]
        [StringLength(4)]
        public string Linea { get; set; }
        [Required]
        [StringLength(20)]
        public string Articulo { get; set; }
        [StringLength(254)]
        public string Descripcion { get; set; }
        [Required]
        public decimal Cantidad { get; set; }
        [Required]
        public decimal Precio_Venta { get; set; }
        [Required]
        public decimal Descuento_Linea { get; set; }
        [Required]
        [StringLength(4)]
        public string Bodega { get; set; }



    }
}
