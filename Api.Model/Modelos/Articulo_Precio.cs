using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Model.Modelos
{
    public class Articulo_Precio
    {

        //[Key]
        //[Column(Order = 0)]
        [StringLength(12)]
        public string Nivel_Precio { get; set; }

        //[Key]
        //[Column(Order = 1)]
        [StringLength(1)]
        public string Moneda { get; set; }

        //[Key]
        //[Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Version { get; set; }

        //[Key]
        //[Column(Order = 3)]
        [StringLength(20)]
        public string Articulo { get; set; }

        //[Key]
        //[Column(Order = 4)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Version_Articulo { get; set; }

        [Required]
        public decimal Precio { get; set; }

        [Required]
        [StringLength(1)]
        public string Esquema_Trabajo { get; set; }

        public decimal? MARGEN_MULR { get; set; }
        [Required]
        public decimal MARGEN_UTILIDAD { get; set; }
        [Required]
        public DateTime FECHA_INICIO { get; set; }
        [Required]
        public DateTime FECHA_FIN { get; set; }

        public DateTime? FECHA_ULT_MODIF { get; set; }

        [StringLength(25)]
        public string USUARIO_ULT_MODIF { get; set; }

        public decimal? MARGEN_UTILIDAD_MIN { get; set; }

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

        //public virtual ARTICULO ARTICULO1 { get; set; }

        //public virtual VERSION_NIVEL VERSION_NIVEL { get; set; }
    }
}
