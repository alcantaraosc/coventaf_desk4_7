using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Model.Modelos
{
    //tabla de tipo de cambio
    public class Moneda_Hist
    {

        [StringLength(4)]
        //Key
        public string Moneda { get; set; }
        //key
        [Column(TypeName = "Date")]
        public DateTime Fecha { get; set; }
        [Required]
        [StringLength(25)]
        public string Usuario { get; set; }
        [Required]
        public decimal Monto { get; set; }
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
