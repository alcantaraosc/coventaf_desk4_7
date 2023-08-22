using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Model.Modelos
{
    public class Tipo_Estado
    {
        [Required]
        public int Estado_ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre_Estado { get; set; }
    }
}
