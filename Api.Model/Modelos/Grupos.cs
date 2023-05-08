using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Model.Modelos
{
    /*aqui estan el nombre de la tienda, TIENDA OUTLET supermercado Es la sucursales*/
    public class Grupos
    {
        [Required]
        [StringLength(6)]
        public string Grupo { get; set; }

        [StringLength(40)]
        public string Descripcion { get; set; }
        [Required]
        [StringLength(1)]
        public string Sucursal { get; set; }
        [Required]
        [StringLength(1)]
        public string Abono_Aprt_Vencido { get; set; }
        [Required]
        [StringLength(12)]
        public string Nivel_Precio { get; set; }
        [Required]
        [StringLength(1)]
        public string Moneda_Nivel { get; set; }
        [StringLength(20)]
        public string Cadena { get; set; }
        [StringLength(10)]
        public string Consecutivo_Ci { get; set; }
        [StringLength(20)]
        public string Consec_Cierre { get; set; }
        [StringLength(50)]
        public string Ncf_Unico { get; set; }
        [Required]
        public byte NoteExistsFlag { get; set; }
        [Required]
        public DateTime RecordDate { get; set; }
        [Required]
        public Guid RowPointer { get; set; }
        [Required]
        [StringLength(30)]
        public string CreatedBy { get; set; }
        [Required]
        [StringLength(30)]
        public string UpdatedBy { get; set; }
        [Required]
        public DateTime CreateDate { get; set; }
        [StringLength(100)]
        public string Direccion { get; set; }
        [StringLength(50)]
        public string Telefono { get; set; }

        [StringLength(6)]
        public string UnidadNegocio { get; set; }
        [StringLength(6)]
        public string GrupoAdministrado { get; set; }


    }
}
