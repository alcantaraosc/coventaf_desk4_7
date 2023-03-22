using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Model.Modelos
{
    public class Cierre_Det_Pago
    {
        [NotMapped]
        public string Identificacion { get; set; }

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
        [StringLength(40)]
        public string Tipo_Pago { get; set; }

        [Required]
        public decimal Total_Sistema { get; set; }
        [Required]
        public decimal Total_Usuario { get; set; }

        [Required]
        public decimal Diferencia { get; set; }

        [Required]
        public int Orden { get; set; }
    }
}
