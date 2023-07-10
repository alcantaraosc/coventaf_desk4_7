using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Model.Modelos
{
    public class Cs_Acompanante
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }               
      
        public int? Visita { get; set; }
        public string Cedula { get; set; }

        [StringLength(300)]
        public string Nombre_Visitar { get; set; }

        [StringLength(500)]
        public string Observacion { get; set; }  
    }
}
