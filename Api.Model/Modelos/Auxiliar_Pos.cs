using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Model.Modelos
{
    //estar atento con esta tabla  Miercoles 22/02/2023
    //aqui se guardan las devoluciones Miercoles 08/03/2023
    public class Auxiliar_Pos
    {
        [Required]
        [StringLength(50)]
        public string Docum_Aplica { get; set; }
        [Required]
        [StringLength(1)]
        public string Tipo_Aplica { get; set; }
        [Required]
        [StringLength(6)]
        public string Caja_Docum_Aplica { get; set; }
        [Required]
        [StringLength(50)]
        public string Documento { get; set; }
        [Required]
        [StringLength(1)]
        public string Tipo { get; set; }
        [Required]
        [StringLength(6)]
        public string Caja { get; set; }
        [Required]       
        public decimal Monto_Aplicado { get; set; }
        [Required]
        [StringLength(1)]
        public string Cargado { get; set; }              
        public DateTime? Fecha_Aplicacion { get; set; }       
        [StringLength(50)]
        public string Doc_cc_Aplicado { get; set; }       
        [StringLength(3)]
        public string Tipo_Doc_cc_Aplicado { get; set; }
        [Required]
        [StringLength(1)]
        public string Cargado_Cg { get; set; }
        [StringLength(10)]
        public string Asiento_Aplicacion { get; set; }
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
