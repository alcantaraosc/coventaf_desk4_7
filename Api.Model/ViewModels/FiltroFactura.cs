using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Model.ViewModels
{
    public class FiltroFactura
    {
        [Required]
        public string Tipofiltro { get; set; }
        [Column(TypeName = "date")]
        public DateTime? FechaInicio { get; set; }
        [Column(TypeName = "date")]
        public DateTime? FechaFinal { get; set; }
        public string Cajero { get; set; }
        public string Caja { get; set; }
        public string FacturaDesde { get; set; }
        public string FacturaHasta { get; set; }
        public string Busqueda { get; set; }
    }
}
