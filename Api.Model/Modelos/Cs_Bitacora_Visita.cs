using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Model.Modelos
{
    public class Cs_Bitacora_Visita
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Numero_Visita { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? Fecha_Visita { get; set; }
        [StringLength(20)]
        public string Cliente { get; set; }

        [StringLength(20)]
        public string Titular { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? Fecha_Registro { get; set; }

        [StringLength(50)]
        public string Usuario_Registro { get; set; }
        public int? Contador { get; set; }
        public string Compañia { get; set; }
    }
}
