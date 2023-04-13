using Api.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace COVENTAF.Services
{
    public class FuncionMetodoPago
    {
        //public string ObtenerDetallePago(List<MetodoPagosPos> viewModelPagosPos,  string formaPago, string descripcionFormaPago, decimal montoDolar, decimal tipoCambio, string documento = null,
        //    string entidadFinanciera = null, string tipoTarjeta = null, string DescripcionCondicionPago = null)
       public string ObtenerDetallePago(List<DetallePagosPos> viewModelPagosPos, int index, decimal tipoCambio)
        {
            //si el monto es Efectivo Cordoba, Efectivo Dolar, Credito

            var pago_Pos = viewModelPagosPos.Where(x => x.Pago == index.ToString()).FirstOrDefault();


            string detallePago = "";
            if (pago_Pos.FormaPago == "0001" && pago_Pos.DescripcionFormaPago  == "EFECTIVO (DOLAR)")
            {
                var montoDolar = viewModelPagosPos.Where(x => x.DescripcionTecla == pago_Pos.DescripcionTecla).Sum(x => x.MontoDolar);
                detallePago = $"Monto en dolares: U${montoDolar.ToString("N2")} Tipo Cambio: {tipoCambio.ToString("N2")}";
            }
            else if (pago_Pos.FormaPago == "0002" && pago_Pos.DescripcionFormaPago == "CHEQUE")
            {
                detallePago = $"Entidad financiera: {pago_Pos.EntidadFinanciera}, No. cheque: {pago_Pos.Numero}";
            }
            else if (pago_Pos.FormaPago == "0002" && pago_Pos.DescripcionFormaPago == "CHEQUE (DOLAR)")
            {
                detallePago = $"Monto en dolares: U${pago_Pos.MontoDolar.ToString("N2")} Tipo Cambio: {tipoCambio.ToString("N2")}, Entidad financiera: {pago_Pos.EntidadFinanciera} numero de cheque: {pago_Pos.Numero}";
            }
            else if (pago_Pos.FormaPago == "0003" && pago_Pos.DescripcionFormaPago == "TARJETA")
            {
                detallePago = $"Tarjeta: { pago_Pos.TipoTarjeta} ";
            }

            else if (pago_Pos.FormaPago == "0003" && pago_Pos.DescripcionFormaPago == "TARJETA (DOLAR)")
            {
                detallePago = $"Monto en dolares: U${pago_Pos.MontoDolar.ToString("N2")} Tipo Cambio: {tipoCambio.ToString("N2")} Tarjeta: {pago_Pos.TipoTarjeta } ";
            }

            else if (pago_Pos.FormaPago  == "0004")
            {

                detallePago = $"Condicion Pago: {pago_Pos.DescripcionCondicionPago } Documento: { pago_Pos.Numero } ";
            }

            //DEVOLUCION-VALE
            else if (pago_Pos.FormaPago == "0005")
            {
                
                detallePago = $"{pago_Pos.DescripcionFormaPago} Devolucion N° : {pago_Pos.Numero} ";
            }

            //GIFTCARD CORDOBAS

            else if (pago_Pos.FormaPago == "FP01" && pago_Pos.DescripcionFormaPago == "GIFTCARD")
            {
                detallePago = $"Documento: {pago_Pos.Numero} ";
            }

            //GIFTCARD DOLARES
            else if (pago_Pos.FormaPago == "FP01" && pago_Pos.DescripcionFormaPago == "GIFTCARD (DOLAR)")
            {
                detallePago = $"Monto en dólares: U${pago_Pos.MontoDolar.ToString("N2")} Tipo Cambio: {tipoCambio.ToString("N2")} No. Tarjeta: { pago_Pos.Numero } ";
            }
            else if (pago_Pos.FormaPago != "0001")
            {
                detallePago = $"Documento: {pago_Pos.Numero} ";
            }

            return detallePago;
        }



        public bool PreCalculoExisteVueltoCliente(decimal montoCobrar,  decimal  montoRestante, char moneda, decimal tipoCambio)
        {
            if (moneda=='D')
            {
                montoCobrar = Math.Round(montoCobrar * tipoCambio, 2);
            }

            var vuelto = (montoRestante - montoCobrar );

            return vuelto < 0 ? true : false;           
        }

    }
}
