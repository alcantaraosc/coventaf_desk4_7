using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Model.Modelos
{
    //Listo
    public class Roles
    {
        public Roles()
        {
            //FuncionesRoles = new HashSet<FuncionesRoles>();
            //RolesUsuarios = new HashSet<RolesUsuarios>();
        }

        [Key]
        [StringLength(20)]
        public string RolID { get; set; }

        [Required]
        [Column(TypeName = "varchar")]

        public string NombreRol { get; set; }
        [Required]
        [Column(TypeName = "varchar")]
        [MaxLength(50)]
        public string Descripcion { get; set; }
        [Required]
        public bool Activo { get; set; }
        [Column(TypeName = "datetime")]
        [Required]
        public DateTime FechaCreacion { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? FechaModificacion { get; set; }


        //public virtual ICollection<FuncionesRoles> FuncionesRoles { get; set; }
        //public virtual ICollection<RolesUsuarios> RolesUsuarios { get; set; }
    }
}
