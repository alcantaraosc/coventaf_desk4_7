using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Model.Modelos
{
    public class Cierre_Desg_Tarj
    {
        [Required]
        [StringLength(20)]        
        public string Num_Cierre { get; set; }
        [Required]
        [StringLength(25)]
        public string Cajero { get; set; }
        [Required]
        [StringLength(6)]        
        public string Caja { get; set; }
        [Required]
        public int Consecutivo { get; set; }
        [Required]
        [StringLength(12)]        
        public string Tipo_Tarjeta { get; set; }
        [Required]
        [StringLength(50)]        
        public string Documento { get; set; }
        [Required]
        [StringLength(1)]        
        public string Tipo { get; set; }        
        [StringLength(80)]        
        public string Autorizacion { get; set; }        
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
