using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Model.ViewModels
{
    public class ViewModelCajero
    {
        [Required]
        [StringLength(25)]
        public string Cajero { get; set; }

        [Required]
        [StringLength(4)]
        public string Vendedor { get; set; }

        [Required]
        [StringLength(1)]
        public string Rotativo { get; set; }
        [Required]
        public DateTime CreateDate { get; set; }
        [StringLength(6)]
        public string Sucursal { get; set; }       
        public string NombreSucursal { get; set; }
    }
}
