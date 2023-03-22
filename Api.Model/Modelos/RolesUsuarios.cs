using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Model.Modelos
{
    public class RolesUsuarios
    {
        [Required]
        [StringLength(20)]
        public string RolID { get; set; }
        [Required]
        [StringLength(25)]
        public string UsuarioID { get; set; }

        [NotMapped]
        public string NombreRol { get; set; }
        public DateTime FechaCreacion { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? FechaModificacion { get; set; }

        //[ForeignKey("RolID")]
        public virtual Roles Roles { get; set; }
        //[ForeignKey("UsuarioID")]
        //public virtual Usuarios Usuarios { get; set; }
    }
}
