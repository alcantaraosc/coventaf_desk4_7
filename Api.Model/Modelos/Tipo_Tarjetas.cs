using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Model.Modelos
{
    public class Tipo_Tarjetas
    {
        [StringLength(12)]
        public string Tipo_Tarjeta { get; set; }

        [Required]
        [StringLength(1)]
        public string Tipo_Cobro { get; set; }
        [StringLength(100)]
        public string Assembly_Invocacion { get; set; }
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
