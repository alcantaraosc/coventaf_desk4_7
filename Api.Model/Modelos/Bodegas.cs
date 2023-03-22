using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Model.Modelos
{
    //Listo
    public class Bodegas
    {
        [Required]
        [StringLength(4)]
        public string Bodega { get; set; }
        [Required]
        [StringLength(40)]
        public string Nombre { get; set; }
        [Required]
        [StringLength(1)]
        public string Tipo { get; set; }
        [Required]
        [StringLength(15)]
        public string Telefono { get; set; }

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
        [Required]
        [StringLength(3)]
        public string U_Tienda_Madre { get; set; }
        public bool? Activo { get; set; }


    }
}
