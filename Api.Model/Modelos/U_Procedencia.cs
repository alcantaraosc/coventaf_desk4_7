using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Model.Modelos
{
    public class U_Procedencia
    {
        [Required]
        [StringLength(10)]
        public string U_Codigo { get; set; }
        [StringLength(200)]
        public string U_Descrip { get; set; }
    }
}
