using System;

namespace Api.Model.View
{
    public class ViewUsuarios
    {
        //[Required]
        // [Column(TypeName = "varchar(25)")]
        public string Usuario { get; set; }

        //[Required]
        //[Column(TypeName = "varchar(100)")]
        public string NombreUsuario { get; set; }

        public DateTime RecordDate { get; set; }
        //[Required]
        //[Column(TypeName = "varchar(1)")]
        public string Activo { get; set; }

        // [Column(TypeName = "varchar(6)")]
        public string SucursalID { get; set; }
        // [Column(TypeName = "varchar(40)")]

        public string NombreSucursal { get; set; }
    }
}
