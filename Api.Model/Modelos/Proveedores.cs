using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Model.Modelos
{
    public class Proveedores
    {
        [Required]
        [StringLength(20)]
        public string Proveedor { get; set; }
        [Required]
        [StringLength(150)]
        public string Nombre { get; set; }
        [Required]
        public string Moneda { get; set; }
        [Required]
        [StringLength(1)]
        public string Activo { get; set; }
        [Required]
        [StringLength(1)]
        public string MultiMoneda { get; set; }
        [Required]
        [StringLength(4)]
        public string Condicion_Pago { get; set; }
    }
}
