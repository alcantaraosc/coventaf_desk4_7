using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Model.Modelos
{
    public class Globales_co
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(4)]
        public string Tipo_Cambio { get; set; }
        [StringLength(4)]
        public string Bodega_Default { get; set; }
        [StringLength(10)]
        public string Ult_Orden_Compra {get; set;}
        [StringLength(10)]
        public string Ult_Embarque { get; set;}
        [StringLength(15)]
        public string Ult_Liquidacion { get; set; }

    }
}
