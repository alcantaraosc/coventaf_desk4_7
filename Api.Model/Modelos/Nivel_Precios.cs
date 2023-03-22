using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Model.Modelos
{
    public class Nivel_Precios
    {
        [Required]
        [StringLength(12)]
        public string Nivel_Precio { get; set; }
        [Required]
        [StringLength(1)]
        public string Moneda { get; set; }

        [StringLength(4)]
        public string Condicion_Pago { get; set; }

        [Required]
        [StringLength(1)]
        public string Esquema_Trabajo { get; set; }
        [Required]
        [StringLength(1)]
        public string Descuentos { get; set; }
        [Required]
        [StringLength(1)]
        public string Sugerir_Descuento { get; set; }
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
