using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Model.Modelos
{
    public class Entidad_Financieras
    {
        [Required]
        [StringLength(8)]
        public string Entidad_Financiera { get; set; }

        [StringLength(20)]
        public string Nit { get; set; }

        [Required]
        [StringLength(40)]
        public string Descripcion { get; set; }

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
