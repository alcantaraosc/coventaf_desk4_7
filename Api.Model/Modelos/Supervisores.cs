using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Model.Modelos
{
    public class Supervisores
    {
        [Required]
        [StringLength(25)]
        public string Supervisor { get; set; }
        [StringLength(6)]
        public string Grupo { get; set; }

        /*Permite efectuar autorizaciones independientemente de la tienda donde se encuentre*/
        [Required]
        [StringLength(1)]
        public string SuperUsuario { get; set; }
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
        [StringLength(6)]
        public string Sucursal { get; set; }
    }
}
