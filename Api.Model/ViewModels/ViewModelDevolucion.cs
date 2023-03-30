using Api.Model.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Model.ViewModels
{
    public class ViewModelDevolucion
    {

        public TicketFactura TicketFactura { get; set; }
        public List<TicketFacturaLinea> TicketFacturaLineas { get; set; }

        //encabezado
        public string EjercitoNicaragua { get; set; }
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

        //detalles de la Devolucion
        public decimal Cantidad { get; set; }
        public decimal Precio { get; set; }
        public decimal DescuentoLinea { get; set; }
        public decimal Monto { get; set; }
        public string DescripcionArticulo { get; set; }

        //Totales
        public decimal SubTotal { get; set; }
        public decimal DescuentoGeneral { get; set; }

        public decimal Total { get; set; }
        public decimal Vale { get; set; }

        public static implicit operator ViewModelDevolucion(ViewDevoluciones v)
        {
            throw new NotImplementedException();
        }
    }
}
