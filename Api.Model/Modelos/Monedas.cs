using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Model.Modelos
{
    public class Monedas
    {
        [Required]
        [StringLength(4)]
        public string Moneda { get; set; }
        [Required]
        [StringLength(40)]
        public string Nombre { get; set; }


    }
}
