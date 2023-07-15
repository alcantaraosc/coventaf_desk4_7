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
        public string TipoDocumento { get; set; }
        public string CodigoCliente { get; set; }
        public string NombreCliente { get; set; }
        public string CodigoArticulo { get; set; }
        public string NombreArticulo { get; set; }
        public bool Cobradas { get; set; }
        public bool Anuladas { get; set; }
        public bool FacturaCredito { get; set; }
        public string Busqueda { get; set; }
    }
}
