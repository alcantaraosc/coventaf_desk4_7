using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Model.Modelos
{
    public class Retenciones
    {
        [Required]
        [StringLength(8)]
        public string Codigo_Retencion { get; set; }

        [Required]
        [StringLength(40)]
        public string Descripcion { get; set; }

        [Required]
        [Column(TypeName = "Decimal")]
        public decimal Porcentaje { get; set; }
        [Required]
        [StringLength(1)]
        public string Estado { get; set; }

        [StringLength(1)]
        public string Es_AutoRetenedor { get; set; }

    }
}
