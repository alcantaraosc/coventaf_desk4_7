using Api.Model.Modelos;
using System.Collections.Generic;

namespace Api.Model.ViewModels
{
    public class ListarDatosFactura
    {
        public int Exito { get; set; }
        public string Mensaje { get; set; }
        public string NoFactura { get; set; }
        public decimal tipoDeCambio { get; set; }
        //Vendedores se refiere a la bodega
        public List<Bodegas> bodega { get; set; }
        public List<Forma_Pagos> FormaPagos { get; set; }
        public List<Tipo_Tarjeta_Pos> TipoTarjeta { get; set; }
        public List<Condicion_Pagos> CondicionPago { get; set; }
        public List<Entidad_Financieras> EntidadFinanciera { get; set; }
        public Clientes Clientes { get; set; }
    }
}
