using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Model.Modelos
{

    //[TIENDA].[DOC_POS_RETENCION].[DOCUMENTO]
    //En las devoluciones no guarda nada en DOC_POS_RETENCION o mejor dicho FACTURA_RETENCION
    public class Factura_Retencion
    {
        [Required]
        [StringLength(1)]
        public string Tipo_Documento { get; set; }
        [Required]
        [StringLength(50)]
        public string Factura { get; set; }
        [Required]
        [StringLength(4)]
        public string Codigo_Retencion { get; set; }
        [Required]
        
        public decimal Monto { get; set; }
        [Required]
        [StringLength(50)]
        public string Doc_Referencia { get; set; }
        [Required]
        
        public decimal Base { get; set; }
        [Required]
        [StringLength(1)]
        public string AutoRetenedora { get; set; }
        public DateTime? Fecha_Documento { get; set; }
        public DateTime? Fecha_Rige { get; set; }

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
