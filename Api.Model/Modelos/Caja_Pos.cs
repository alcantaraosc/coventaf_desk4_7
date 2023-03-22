using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Model.Modelos
{
    public class Caja_Pos
    {
        [Required]
        [StringLength(6)]
        public string Caja { get; set; }
        [Required]
        [StringLength(2)]
        public string Codigo_Corto { get; set; }
        [Required]
        [StringLength(6)]
        public string Sucursal { get; set; }
        [Required]
        [StringLength(4)]
        public string Bodega { get; set; }
        [StringLength(40)]
        public string Ubicacion { get; set; }
        [Required]
        [StringLength(1)]
        public string Asignado { get; set; }
        [StringLength(20)]
        public string Identificador { get; set; }

        [StringLength(25)]
        public string Centro_Costo { get; set; }
        [Required]
        [StringLength(20)]
        public string Cons_Cierre_Caja { get; set; }

        [StringLength(20)]
        public string Consec_Doc_Espera { get; set; }
        [Required]
        [StringLength(1)]
        public string Estado { get; set; }
        [Column(TypeName = "text")]
        public string Firma { get; set; }
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
        [StringLength(10)]
        public string Actividad_Comercial { get; set; }
    }
}
