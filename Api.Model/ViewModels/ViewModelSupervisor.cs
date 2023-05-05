using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Model.ViewModels
{
    public class ViewModelSupervisor
    {
        
        [StringLength(25)]
        public string Supervisor { get; set; }      
        [Required]
        [StringLength(1)]
        public string SuperUsuario { get; set; }
       
        [StringLength(6)]
        public string Sucursal { get; set; }   
        public string NombreSucursal { get; set; }
        [Required]
        public DateTime CreateDate { get; set; }
    }
}
