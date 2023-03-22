using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Model.Modelos
{
    //listo
    public class Denominacion
    {
        [Required]
        [Column(TypeName = "varchar")]
        [StringLength(1)]
        public string Tipo { get; set; }
        [Required]
        [Column(TypeName = "Decimal")]
        public decimal Denom_Monto { get; set; }

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
    }
}
