using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Model.ViewModels
{
    public class TicketFactura
    {
        //encabezado
        public string Titulo { get; set; }
        public string NombreTienda { get; set; }

        //datos de la devolucion
        public DateTime FechaDevolucion { get; set; }
        public string NoDevolucion { get; set; }
        public string Caja { get; set; }
        public string BodegaId { get; set; }
        public string NombreBodega { get; set; }
        public string Cliente { get; set; }
        public string NombreCliente { get; set; }

        /*VALE*/
        public DateTime FechaVencimiento { get; set; }
        //averiguar por que dice saldo restante
        public string SaldoRestante { get; set; }
        public string FacturaDevuelta { get; set; }
        public string CajaDevolucion { get; set; }


        //Totales
        public decimal SubTotal { get; set; }
        public decimal DescuentoGeneral { get; set; }
        public decimal Total { get; set; }
        public decimal Vale { get; set; }

    }
}
