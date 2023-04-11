using Api.Model.Modelos;
using Api.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COVENTAF.Metodos
{
    public class MetodoImpresion
    {
        public static System.Drawing.Font printFont;

        private PrintDocument doc = new PrintDocument();
        private PrintPreviewDialog vista = new PrintPreviewDialog();
        // Construct the PrintPreviewControl.
        PrintPreviewControl PrintPreviewControl1 = new PrintPreviewControl();

        private List<DetalleFactura> _listDetFactura;
        private List<DetallePagosPos> _listMetodoPago;
        private Encabezado _encabezadoFact;

        private  List<LineaImpresion> lineaImp;
        int index = 0;


        private LineaImpresion AgregarUnaLinea(string linea, int posX, int posY, bool tieneMasLinea=true)
        {
            var lineaImpresion = new LineaImpresion()
            {
                Linea = linea,
                PosX = posX,
                PosY = posY,
                TieneMasLinea = tieneMasLinea
            };

            return lineaImpresion;
        }

              


        private void ImprimirPorReferenciaCaracter(List<LineaImpresion> lineaImpresion, string texto, int posX, int incrementoX,  int posY, int incrementoY = 0)
        {
            string[] textoImprimir = texto.Split('*');


            //comprobar si tiene mas de 2 registro el arreglo                               
            if (textoImprimir.Length >= 2)
            {
                //posY += incrementoY;
                //e.Graphics.DrawString(textoImprimir[0], fuente, Brushes.Black, posX + incrementoX, posY);

                for (var rows = 0; rows < textoImprimir.Length; rows++)
                {
                    posY = incrementoY;
                    lineaImpresion.Add(AgregarUnaLinea(textoImprimir[rows], posX + incrementoX, posY));
                    //e.Graphics.DrawString(textoImprimir[rows], fuente, Brushes.Black, posX + incrementoX, posY);
                }
            }
            else
            {
                posY = incrementoY;
                lineaImpresion.Add(AgregarUnaLinea(texto, posX + incrementoX, posY));
                //e.Graphics.DrawString(texto, fuente, Brushes.Black, posX + incrementoX, posY);
            }
        }


        public List<LineaImpresion> GenerarLineasTicketFactura(List<DetalleFactura> _listDetFactura, Encabezado _encabezadoFact, List<DetallePagosPos> _listMetodoPago)
        {
            int posX = 2;
            int posY = 0;
            int posXtemp = 0;
            List<LineaImpresion> lineaImpresion = new List<LineaImpresion>();

            try
            {

                lineaImpresion.Add(AgregarUnaLinea("     EJERCITO DE NICARAGUA", posX + 53, posY));
                //identificar si es tienda electrodomestico
                posXtemp = User.TiendaID == "T01" ? posX + 45 : posX + 80;
                posY = 17;
                lineaImpresion.Add(AgregarUnaLinea(User.NombreTienda, posXtemp, posY));
                //imprimir la direccion
                ImprimirPorReferenciaCaracter(lineaImpresion, User.DireccionTienda, posX, 20, posY, 15);
                //posY = 15;
                //e.Graphics.DrawString($"Tel.: {User.TelefonoTienda}", fuente, Brushes.Black, posX + 60, posY);
                lineaImpresion.Add(AgregarUnaLinea($"Tel.: {User.TelefonoTienda}", posX + 70, posY));

                //posY = 17;
                //e.Graphics.DrawString("N° RUC: J1330000001272", fuente, Brushes.Black, posX + 55, posY);
                lineaImpresion.Add(AgregarUnaLinea("N° RUC: J1330000001272", posX + 65, posY));
       
                //factura
                posY = 40;
                //e.Graphics.DrawString("N° Factura: " + _encabezadoFact.NoFactura, fuenteRegular, Brushes.Black, posX, posY);
                lineaImpresion.Add(AgregarUnaLinea("N° FACTURA: " + _encabezadoFact.NoFactura, posX, posY));
                posY = 17;
                //e.Graphics.DrawString("Codigo Cliente: " + _encabezadoFact.codigoCliente, fuenteRegular, Brushes.Black, posX, posY);
                lineaImpresion.Add(AgregarUnaLinea("CODIGO CLIENTE: " + _encabezadoFact.codigoCliente, posX, posY));
              
                //posY = 15;
                //e.Graphics.DrawString("Fecha: " + _encabezadoFact.cliente, fuenteRegular, Brushes.Black, posX, posY);
                lineaImpresion.Add(AgregarUnaLinea("CLIENTE: " + _encabezadoFact.cliente, posX, posY));
                //posY = 15;
                //e.Graphics.DrawString("Bodega: " + _encabezadoFact.bodega, fuenteRegular, Brushes.Black, posX, posY);
                lineaImpresion.Add(AgregarUnaLinea("BODEGA: " + _encabezadoFact.bodega,  posX, posY));
                //posY = 15;
                //e.Graphics.DrawString("Caja: " + _encabezadoFact.caja, fuenteRegular, Brushes.Black, posX, posY);
                lineaImpresion.Add(AgregarUnaLinea("CAJA: " + _encabezadoFact.caja,  posX, posY));
                //posY = 15;
                //e.Graphics.DrawString("Tipo Cambio: " + _encabezadoFact.tipoCambio.ToString("N2"), fuenteRegular, Brushes.Black, posX, posY);
                lineaImpresion.Add(AgregarUnaLinea("TIPO CAMBIO: " + _encabezadoFact.tipoCambio.ToString("N2"), posX, posY));
                posY = 18;
                //e.Graphics.DrawString("-------------------------------------------------------------------------", fuente, Brushes.Black, posX, posY);
                lineaImpresion.Add(AgregarUnaLinea("-------------------------------------------------------------------------", posX, posY));
                
                posY = 10;
                //e.Graphics.DrawString("Codigo", fuente, Brushes.Black, posX, posY);
                lineaImpresion.Add(AgregarUnaLinea("Codigo", posX, posY));
               
                posX += 60;
                //e.Graphics.DrawString("Cant", fuente, Brushes.Black, posX, posY);
                lineaImpresion.Add(AgregarUnaLinea("Cant", posX, 0));                
                posX += 50;
                //e.Graphics.DrawString("Precio", fuente, Brushes.Black, posX, posY);
                lineaImpresion.Add(AgregarUnaLinea("Precio", posX, 0));                
                
                posX += 50;
                //e.Graphics.DrawString("Desc", fuente, Brushes.Black, posX, posY);
                lineaImpresion.Add(AgregarUnaLinea("Desc", posX, 0));
                
                posX += 55;
                //e.Graphics.DrawString("Monto", fuente, Brushes.Black, posX, posY);
                lineaImpresion.Add(AgregarUnaLinea("Monto", posX, 0));
                
                posY = 10;
                //reiniciar la posicionX
                posX = 2;
                //e.Graphics.DrawString("-------------------------------------------------------------------------", fuente, Brushes.Black, posX, posY);
                lineaImpresion.Add(AgregarUnaLinea("-------------------------------------------------------------------------", posX, posY));



                //e.Graphics.DrawString("8721160000939", fuenteRegular, Brushes.Black, posX, posY);
                //_listDetFactura

                foreach (var detalleFactura in _listDetFactura)
                {
                    posY = 20;
                    //e.Graphics.DrawString(detalleFactura.ArticuloId, fuenteRegular, Brushes.Black, posX, posY);
                    lineaImpresion.Add(AgregarUnaLinea(detalleFactura.ArticuloId, posX, posY));

                    posX += 60;
                    //e.Graphics.DrawString(detalleFactura.Cantidad_d.ToString("N2"), fuenteRegular, Brushes.Black, posX, posY);
                    lineaImpresion.Add(AgregarUnaLinea(detalleFactura.Cantidad_d.ToString("N2"), posX, 0));

                    posX += 45;
                    //e.Graphics.DrawString(detalleFactura.PrecioCordobas.ToString("N2"), fuenteRegular, Brushes.Black, posX, posY);
                    lineaImpresion.Add(AgregarUnaLinea(detalleFactura.PrecioCordobas.ToString("N2"), posX, 0));

                    posX += 60;
                    //e.Graphics.DrawString(Convert.ToDecimal(detalleFactura.DescuentoPorLineaCordoba).ToString("N2"), fuenteRegular, Brushes.Black, posX, posY);
                    lineaImpresion.Add(AgregarUnaLinea(detalleFactura.DescuentoPorLineaCordoba.ToString("N2"), posX, 0));

                    posX += 50;
                    //e.Graphics.DrawString(detalleFactura.TotalCordobas.ToString("N2"), fuenteRegular, Brushes.Black, posX, posY);
                    lineaImpresion.Add(AgregarUnaLinea(detalleFactura.TotalCordobas.ToString("N2"), posX, 0));

                    //salto a la siguiente linea
                    posY = 17;
                    posX = 2;
                    //e.Graphics.DrawString(detalleFactura.Descripcion, fuenteRegular_7, Brushes.Black, posX, posY);
                    lineaImpresion.Add(AgregarUnaLinea(detalleFactura.Descripcion, posX, posY));

                    //posY = 15;

                }

                posY = 15;
                //e.Graphics.DrawString("-------------------------------------------------------------------------", fuente, Brushes.Black, posX, posY);
                lineaImpresion.Add(AgregarUnaLinea("-------------------------------------------------------------------------", posX, posY));

                posY = 17;                
                posX = 130;
                //e.Graphics.DrawString("Sub Total:", fuente, Brushes.Black, posX, posY);
                lineaImpresion.Add(AgregarUnaLinea($"SUB TOTAL:         C$ {_encabezadoFact.subTotalCordoba.ToString("N2")}", posX, posY));

                //posX += 65;
                ////e.Graphics.DrawString("C$ " + _encabezadoFact.subTotalCordoba.ToString("N2"), fuenteRegular, Brushes.Black, posX, posY);
                //lineaImpresion.Add(AgregarUnaLinea("C$ " + _encabezadoFact.subTotalCordoba.ToString("N2"), posX, posY));



                //posY = 15;
                posX = 130;                
                //e.Graphics.DrawString("Descuento:", fuente, Brushes.Black, posX, posY);
                lineaImpresion.Add(AgregarUnaLinea($"DESCUENTO:        C$ {_encabezadoFact.descuentoCordoba.ToString("N2")}", posX, posY));

                //posX += 65;
                ////e.Graphics.DrawString("C$ " + _encabezadoFact.descuentoCordoba.ToString("N2"), fuenteRegular, Brushes.Black, posX, posY);
                //lineaImpresion.Add(AgregarUnaLinea("C$ " + _encabezadoFact.descuentoCordoba.ToString("N2"), posX, posY));


                /************************* RETENCIONES ************************************************************************/
                if (_encabezadoFact.MontoRetencion > 0)
                {
                    //posY = 17;
                    posX = 130;                    
                    //e.Graphics.DrawString("Retencion:", fuente, Brushes.Black, posX, posY);
                    lineaImpresion.Add(AgregarUnaLinea($"RETENCION:         C$ {_encabezadoFact.MontoRetencion.ToString("N2")}", posX, posY));

                    //posX += 65;
                    ////e.Graphics.DrawString("C$ " + _encabezadoFact.MontoRetencion.ToString("N2"), fuenteRegular, Brushes.Black, posX, posY);
                    //lineaImpresion.Add(AgregarUnaLinea("C$ " + _encabezadoFact.MontoRetencion.ToString("N2"), posX, posY));
                }
                /****************************************************************************************************************/


               // posY = 15;
                posX = 130;               
                //e.Graphics.DrawString("IVA:", fuente, Brushes.Black, posX, posY);
                lineaImpresion.Add(AgregarUnaLinea($"IVA:                     C$ {_encabezadoFact.ivaCordoba.ToString("N2")}", posX, posY));

                //posX += 65;
                ////e.Graphics.DrawString("C$ " + _encabezadoFact.ivaCordoba.ToString("N2"), fuenteRegular, Brushes.Black, posX, posY);
                //lineaImpresion.Add(AgregarUnaLinea("C$ " + _encabezadoFact.ivaCordoba.ToString("N2"), posX, posY));

                //posY = 15;
                posX = 130;                
                //e.Graphics.DrawString("Total a Pagar:", fuente, Brushes.Black, posX, posY);
                lineaImpresion.Add(AgregarUnaLinea($"TOTAL A PAGAR: C$ {_encabezadoFact.totalCordoba.ToString("N2")}", posX, posY));

               // posX += 65;
               //// e.Graphics.DrawString("C$ " + _encabezadoFact.totalCordoba.ToString("N2"), fuenteRegular, Brushes.Black, posX, posY);
               // lineaImpresion.Add(AgregarUnaLinea("C$ " + _encabezadoFact.totalCordoba.ToString("N2"), posX, posY));


                //posY = 15;
                posX = 130;                
                //e.Graphics.DrawString("Total a Pagar:", fuente, Brushes.Black, posX, posY);
                lineaImpresion.Add(AgregarUnaLinea($"TOTAL A PAGAR: U$ {_encabezadoFact.totalDolar.ToString("N2")}", posX, posY));

                //posX += 65;
                ////e.Graphics.DrawString("U$ " + _encabezadoFact.totalDolar.ToString("N2"), fuenteRegular, Brushes.Black, posX, posY);
                //lineaImpresion.Add(AgregarUnaLinea("U$ " + _encabezadoFact.totalDolar.ToString("N2"), posX, posY));

                /************************************************************************************/
                string[] stringSeparators = new string[] { "\r\n" };

                //convertir el registro en arreglo
                //string[] newformaDePago = _encabezadoFact.formaDePago.Split(stringSeparators, StringSplitOptions.None);


                ////comprobar si tiene mas de 2 registro el arreglo                               
                //if (newformaDePago.Length >= 2)
                //{
                //    posY = 20;
                //    e.Graphics.DrawString($"FORMA DE PAGO: {newformaDePago[0]}", fuenteRegular, Brushes.Black, posX, posY);

                //    for (var rows = 1; rows < newformaDePago.Length; rows++)
                //    {
                //        posY = 20;
                //        e.Graphics.DrawString(newformaDePago[rows], fuenteRegular, Brushes.Black, posX, posY);
                //    }
                //}
                //else
                //{
                //    posY = 20;
                //    e.Graphics.DrawString("FORMA DE PAGO: " + _encabezadoFact.formaDePago, fuenteRegular, Brushes.Black, posX, posY);
                //}

                //reiniciar en la posicion X
                posX = 2;
                //posY = 15;
                //e.Graphics.DrawString("-------------------------------------------------------------------------", fuente, Brushes.Black, posX, posY);
                lineaImpresion.Add(AgregarUnaLinea("-------------------------------------------------------------------------", posX, posY));

                //posY = 10;
                //e.Graphics.DrawString("FORMA DE PAGO: ", fuenteRegular, Brushes.Black, posX + 90, posY);
                lineaImpresion.Add(AgregarUnaLinea("FORMA DE PAGO: ", posX, posY));

                foreach (var listPagos in _listMetodoPago)
                {

                    //reiniciar con 2
                    posX = 2;
                    posY = 17;
                    //e.Graphics.DrawString(listPagos.DescripcionFormaPago, fuenteRegular, Brushes.Black, posX, posY);
                    lineaImpresion.Add(AgregarUnaLinea(listPagos.DescripcionFormaPago, posX, posY));

                    //sumar 160
                    posX = 220;
                    //e.Graphics.DrawString((listPagos.Moneda == 'D' ? $"U${listPagos.MontoDolar.ToString("N2")}" : $"C${listPagos.MontoCordoba.ToString("N2")}"), fuenteRegular, Brushes.Black, posX, posY);
                    lineaImpresion.Add(AgregarUnaLinea((listPagos.Moneda == 'D' ? $"U${listPagos.MontoDolar.ToString("N2")}" : $"C${listPagos.MontoCordoba.ToString("N2")}"), posX, 0));
                    
                    //si existe vuelto
                    if (listPagos.VueltoCliente < 0)
                    {
                        //reiniciar con 2
                        posX = 2;
                        //posY = 15;
                        //e.Graphics.DrawString("SU CAMBIO: ", fuenteRegular, Brushes.Black, posX, posY);
                        lineaImpresion.Add(AgregarUnaLinea("SU CAMBIO: ", posX, posY));

                        //sumar 160
                        posX = 220;
                        //e.Graphics.DrawString($"C${(listPagos.VueltoCliente * (-1)).ToString("N2")}", fuenteRegular, Brushes.Black, posX, posY);
                        lineaImpresion.Add(AgregarUnaLinea($"C${(listPagos.VueltoCliente * (-1)).ToString("N2")}", posX, 0));
                    }

                }

                posX = 2;
                posY = 50;
                string[] newObservacion = _encabezadoFact.observaciones.Split(stringSeparators, StringSplitOptions.None);

                //e.Graphics.DrawString("OBSERVACIONES: ", fuenteRegular, Brushes.Black, posX, posY);
                lineaImpresion.Add(AgregarUnaLinea("OBSERVACIONES: ", posX, posY));

                if (newObservacion.Length >= 2)
                {
                    for (var fila = 0; fila < newObservacion.Length; fila++)
                    {
                        posY = 17;
                        //e.Graphics.DrawString(newObservacion[fila], fuenteRegular, Brushes.Black, posX + 10, posY);
                       lineaImpresion.Add(AgregarUnaLinea(newObservacion[fila], posX+10, posY));
                }
                }
                else
                {
                    posY = 17;
                    //e.Graphics.DrawString(_encabezadoFact.observaciones, fuenteRegular, Brushes.Black, posX, posY);
                    lineaImpresion.Add(AgregarUnaLinea(_encabezadoFact.observaciones, posX, posY));
                }


                posY = 50;
                //e.Graphics.DrawString("ATENDIDO POR: ", fuenteRegular, Brushes.Black, posX, posY);
                lineaImpresion.Add(AgregarUnaLinea("ATENDIDO POR: ", posX, posY));
                
                posY = 17;
                //e.Graphics.DrawString(_encabezadoFact.atentidoPor, fuenteRegular, Brushes.Black, posX + 15, posY);
                lineaImpresion.Add(AgregarUnaLinea(_encabezadoFact.atentidoPor, posX + 15, posY));

                posY = 70;
                //e.Graphics.DrawString("ENTREGADO: ", fuenteRegular, Brushes.Black, posX, posY);
                lineaImpresion.Add(AgregarUnaLinea("ENTREGADO: ", posX, posY));

                posY = 70;
                //e.Graphics.DrawString("RECIBIDO: ", fuenteRegular, Brushes.Black, posX, posY);
                lineaImpresion.Add(AgregarUnaLinea("RECIBIDO: ", posX, posY));

                posY = 70;
                posX = 50;
                //e.Graphics.DrawString("NO SE ACEPTAN CAMBIOS DESPUES DE", fuenteRegular, Brushes.Black, posX, posY);
                lineaImpresion.Add(AgregarUnaLinea("NO SE ACEPTAN CAMBIOS DESPUES DE", posX, posY));

                posY = 17;
                //e.Graphics.DrawString("48 HORAS. *APLICAN RESTRICCIONES*", fuenteRegular, Brushes.Black, posX, posY);
                lineaImpresion.Add(AgregarUnaLinea("48 HORAS. *APLICAN RESTRICCIONES*", posX, posY));

                posY = 40;
                posX += 23;
                //e.Graphics.DrawString("GRACIAS POR SU COMPRA", fuenteRegular, Brushes.Black, posX, posY);
                lineaImpresion.Add(AgregarUnaLinea("GRACIAS POR SU COMPRA", posX, posY, false));

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return lineaImpresion;

        }

        private List<LineaImpresion> GenerarLineasTicketFactura_Respaldo(List<DetalleFactura> _listDetFactura, Encabezado _encabezadoFact, List<DetallePagosPos> _listMetodoPago)
        {
            int posX = 2;
            int posY = 0;
            int posXtemp = 0;
            List<LineaImpresion> lineaImpresion = new List<LineaImpresion>();

            try
            {

                lineaImpresion.Add(AgregarUnaLinea("EJERCITO DE NICARAGUA", posX + 53, posY));
                //identificar si es tienda electrodomestico
                posXtemp = User.TiendaID == "T01" ? posX + 45 : posX + 80;

                lineaImpresion.Add(AgregarUnaLinea(User.NombreTienda, posXtemp, posY));
                //imprimir la direccion
                //ImprimirPorReferenciaCaracter(lineaImpresion, User.DireccionTienda, ref posX, 20, ref posY, 15);
                posY += 15;
                //e.Graphics.DrawString($"Tel.: {User.TelefonoTienda}", fuente, Brushes.Black, posX + 60, posY);
                lineaImpresion.Add(AgregarUnaLinea($"Tel.: {User.TelefonoTienda}", posX + 60, posY));

                posY += 15;
                //e.Graphics.DrawString("N° RUC: J1330000001272", fuente, Brushes.Black, posX + 55, posY);
                lineaImpresion.Add(AgregarUnaLinea("N° RUC: J1330000001272", posX + 55, posY));

                //factura
                posY += 24;
                //e.Graphics.DrawString("N° Factura: " + _encabezadoFact.NoFactura, fuenteRegular, Brushes.Black, posX, posY);
                lineaImpresion.Add(AgregarUnaLinea("N° Factura: " + _encabezadoFact.NoFactura, posX, posY));
                posY += 15;
                //e.Graphics.DrawString("Codigo Cliente: " + _encabezadoFact.codigoCliente, fuenteRegular, Brushes.Black, posX, posY);
                lineaImpresion.Add(AgregarUnaLinea("Codigo Cliente: " + _encabezadoFact.codigoCliente, posX, posY));

                posY += 15;
                //e.Graphics.DrawString("Fecha: " + _encabezadoFact.cliente, fuenteRegular, Brushes.Black, posX, posY);
                lineaImpresion.Add(AgregarUnaLinea("Cliente: " + _encabezadoFact.cliente, posX, posY));
                posY += 15;
                //e.Graphics.DrawString("Bodega: " + _encabezadoFact.bodega, fuenteRegular, Brushes.Black, posX, posY);
                lineaImpresion.Add(AgregarUnaLinea("Bodega: " + _encabezadoFact.bodega, posX, posY));
                posY += 15;
                //e.Graphics.DrawString("Caja: " + _encabezadoFact.caja, fuenteRegular, Brushes.Black, posX, posY);
                lineaImpresion.Add(AgregarUnaLinea("Caja: " + _encabezadoFact.caja, posX, posY));
                posY += 15;
                //e.Graphics.DrawString("Tipo Cambio: " + _encabezadoFact.tipoCambio.ToString("N2"), fuenteRegular, Brushes.Black, posX, posY);
                lineaImpresion.Add(AgregarUnaLinea("Tipo Cambio: " + _encabezadoFact.tipoCambio.ToString("N2"), posX, posY));
                posY += 18;
                //e.Graphics.DrawString("-------------------------------------------------------------------------", fuente, Brushes.Black, posX, posY);
                lineaImpresion.Add(AgregarUnaLinea("-------------------------------------------------------------------------", posX, posY));

                posY += 10;
                //e.Graphics.DrawString("Codigo", fuente, Brushes.Black, posX, posY);
                lineaImpresion.Add(AgregarUnaLinea("Codigo", posX, posY));

                posX += 60;
                //e.Graphics.DrawString("Cant", fuente, Brushes.Black, posX, posY);
                lineaImpresion.Add(AgregarUnaLinea("Cant", posX, posY));
                posX += 50;
                //e.Graphics.DrawString("Precio", fuente, Brushes.Black, posX, posY);
                lineaImpresion.Add(AgregarUnaLinea("Precio", posX, posY));

                posX += 50;
                //e.Graphics.DrawString("Desc", fuente, Brushes.Black, posX, posY);
                lineaImpresion.Add(AgregarUnaLinea("Desc", posX, posY));

                posX += 55;
                //e.Graphics.DrawString("Monto", fuente, Brushes.Black, posX, posY);
                lineaImpresion.Add(AgregarUnaLinea("Monto", posX, posY));

                posY += 10;
                //reiniciar la posicionX
                posX = 2;
                //e.Graphics.DrawString("-------------------------------------------------------------------------", fuente, Brushes.Black, posX, posY);
                lineaImpresion.Add(AgregarUnaLinea("-------------------------------------------------------------------------", posX, posY));



                //e.Graphics.DrawString("8721160000939", fuenteRegular, Brushes.Black, posX, posY);
                //_listDetFactura

                foreach (var detalleFactura in _listDetFactura)
                {
                    posY += 10;
                    //e.Graphics.DrawString(detalleFactura.ArticuloId, fuenteRegular, Brushes.Black, posX, posY);
                    lineaImpresion.Add(AgregarUnaLinea(detalleFactura.ArticuloId, posX, posY));

                    posX += 60;
                    //e.Graphics.DrawString(detalleFactura.Cantidad_d.ToString("N2"), fuenteRegular, Brushes.Black, posX, posY);
                    lineaImpresion.Add(AgregarUnaLinea(detalleFactura.Cantidad_d.ToString("N2"), posX, posY));

                    posX += 45;
                    //e.Graphics.DrawString(detalleFactura.PrecioCordobas.ToString("N2"), fuenteRegular, Brushes.Black, posX, posY);
                    lineaImpresion.Add(AgregarUnaLinea(detalleFactura.PrecioCordobas.ToString("N2"), posX, posY));

                    posX += 60;
                    //e.Graphics.DrawString(Convert.ToDecimal(detalleFactura.DescuentoPorLineaCordoba).ToString("N2"), fuenteRegular, Brushes.Black, posX, posY);
                    lineaImpresion.Add(AgregarUnaLinea(detalleFactura.DescuentoPorLineaCordoba.ToString("N2"), posX, posY));

                    posX += 50;
                    //e.Graphics.DrawString(detalleFactura.TotalCordobas.ToString("N2"), fuenteRegular, Brushes.Black, posX, posY);
                    lineaImpresion.Add(AgregarUnaLinea(detalleFactura.TotalCordobas.ToString("N2"), posX, posY));

                    //salto a la siguiente linea
                    posY += 15;
                    posX = 2;
                    //e.Graphics.DrawString(detalleFactura.Descripcion, fuenteRegular_7, Brushes.Black, posX, posY);
                    lineaImpresion.Add(AgregarUnaLinea(detalleFactura.Descripcion, posX, posY));

                    posY += 7;

                }

                posY += 5;
                //e.Graphics.DrawString("-------------------------------------------------------------------------", fuente, Brushes.Black, posX, posY);
                lineaImpresion.Add(AgregarUnaLinea("-------------------------------------------------------------------------", posX, posY));

                posY += 15;
                posX = 2;
                posX += 140;
                //e.Graphics.DrawString("Sub Total:", fuente, Brushes.Black, posX, posY);
                lineaImpresion.Add(AgregarUnaLinea("Sub Total:", posX, posY));

                posX += 65;
                //e.Graphics.DrawString("C$ " + _encabezadoFact.subTotalCordoba.ToString("N2"), fuenteRegular, Brushes.Black, posX, posY);
                lineaImpresion.Add(AgregarUnaLinea("C$ " + _encabezadoFact.subTotalCordoba.ToString("N2"), posX, posY));



                posY += 15;
                posX = 2;
                posX += 140;
                //e.Graphics.DrawString("Descuento:", fuente, Brushes.Black, posX, posY);
                lineaImpresion.Add(AgregarUnaLinea("Descuento", posX, posY));

                posX += 65;
                //e.Graphics.DrawString("C$ " + _encabezadoFact.descuentoCordoba.ToString("N2"), fuenteRegular, Brushes.Black, posX, posY);
                lineaImpresion.Add(AgregarUnaLinea("C$ " + _encabezadoFact.descuentoCordoba.ToString("N2"), posX, posY));


                /************************* RETENCIONES ************************************************************************/
                if (_encabezadoFact.MontoRetencion > 0)
                {
                    posY += 15;
                    posX = 2;
                    posX += 140;
                    //e.Graphics.DrawString("Retencion:", fuente, Brushes.Black, posX, posY);
                    lineaImpresion.Add(AgregarUnaLinea("Retencion:", posX, posY));

                    posX += 65;
                    //e.Graphics.DrawString("C$ " + _encabezadoFact.MontoRetencion.ToString("N2"), fuenteRegular, Brushes.Black, posX, posY);
                    lineaImpresion.Add(AgregarUnaLinea("C$ " + _encabezadoFact.MontoRetencion.ToString("N2"), posX, posY));
                }
                /****************************************************************************************************************/


                posY += 15;
                posX = 142;
                //e.Graphics.DrawString("IVA:", fuente, Brushes.Black, posX, posY);
                lineaImpresion.Add(AgregarUnaLinea("IVA:", posX, posY));

                posX += 65;
                //e.Graphics.DrawString("C$ " + _encabezadoFact.ivaCordoba.ToString("N2"), fuenteRegular, Brushes.Black, posX, posY);
                lineaImpresion.Add(AgregarUnaLinea("C$ " + _encabezadoFact.ivaCordoba.ToString("N2"), posX, posY));

                posY += 15;
                posX = 2;
                posX += 140;
                //e.Graphics.DrawString("Total a Pagar:", fuente, Brushes.Black, posX, posY);
                lineaImpresion.Add(AgregarUnaLinea("Total a Pagar ", posX, posY));

                posX += 65;
                // e.Graphics.DrawString("C$ " + _encabezadoFact.totalCordoba.ToString("N2"), fuenteRegular, Brushes.Black, posX, posY);
                lineaImpresion.Add(AgregarUnaLinea("C$ " + _encabezadoFact.totalCordoba.ToString("N2"), posX, posY));


                posY += 15;
                posX = 142;

                //e.Graphics.DrawString("Total a Pagar:", fuente, Brushes.Black, posX, posY);
                lineaImpresion.Add(AgregarUnaLinea("Total a Pagar: ", posX, posY));

                posX += 65;
                //e.Graphics.DrawString("U$ " + _encabezadoFact.totalDolar.ToString("N2"), fuenteRegular, Brushes.Black, posX, posY);
                lineaImpresion.Add(AgregarUnaLinea("U$ " + _encabezadoFact.totalDolar.ToString("N2"), posX, posY));

                /************************************************************************************/
                string[] stringSeparators = new string[] { "\r\n" };

                //convertir el registro en arreglo
                //string[] newformaDePago = _encabezadoFact.formaDePago.Split(stringSeparators, StringSplitOptions.None);


                ////comprobar si tiene mas de 2 registro el arreglo                               
                //if (newformaDePago.Length >= 2)
                //{
                //    posY += 20;
                //    e.Graphics.DrawString($"FORMA DE PAGO: {newformaDePago[0]}", fuenteRegular, Brushes.Black, posX, posY);

                //    for (var rows = 1; rows < newformaDePago.Length; rows++)
                //    {
                //        posY += 20;
                //        e.Graphics.DrawString(newformaDePago[rows], fuenteRegular, Brushes.Black, posX, posY);
                //    }
                //}
                //else
                //{
                //    posY += 20;
                //    e.Graphics.DrawString("FORMA DE PAGO: " + _encabezadoFact.formaDePago, fuenteRegular, Brushes.Black, posX, posY);
                //}

                //reiniciar en la posicion X
                posX = 2;
                posY += 15;
                //e.Graphics.DrawString("-------------------------------------------------------------------------", fuente, Brushes.Black, posX, posY);
                lineaImpresion.Add(AgregarUnaLinea("-------------------------------------------------------------------------", posX, posY));

                posY += 10;
                //e.Graphics.DrawString("FORMA DE PAGO: ", fuenteRegular, Brushes.Black, posX + 90, posY);
                lineaImpresion.Add(AgregarUnaLinea("FORMA DE PAGO: ", posX, posY));

                foreach (var listPagos in _listMetodoPago)
                {

                    //reiniciar con 2
                    posX = 2;
                    posY += 15;
                    //e.Graphics.DrawString(listPagos.DescripcionFormaPago, fuenteRegular, Brushes.Black, posX, posY);
                    lineaImpresion.Add(AgregarUnaLinea(listPagos.DescripcionFormaPago, posX, posY));

                    //sumar 160
                    posX = 220;
                    //e.Graphics.DrawString((listPagos.Moneda == 'D' ? $"U${listPagos.MontoDolar.ToString("N2")}" : $"C${listPagos.MontoCordoba.ToString("N2")}"), fuenteRegular, Brushes.Black, posX, posY);
                    lineaImpresion.Add(AgregarUnaLinea((listPagos.Moneda == 'D' ? $"U${listPagos.MontoDolar.ToString("N2")}" : $"C${listPagos.MontoCordoba.ToString("N2")}"), posX, posY));
                    //si
                    if (listPagos.VueltoCliente < 0)
                    {
                        //reiniciar con 2
                        posX = 2;
                        posY += 15;
                        //e.Graphics.DrawString("SU CAMBIO: ", fuenteRegular, Brushes.Black, posX, posY);
                        lineaImpresion.Add(AgregarUnaLinea("SU CAMBIO: ", posX, posY));

                        //sumar 160
                        posX = 220;
                        //e.Graphics.DrawString($"C${(listPagos.VueltoCliente * (-1)).ToString("N2")}", fuenteRegular, Brushes.Black, posX, posY);
                        lineaImpresion.Add(AgregarUnaLinea($"C${(listPagos.VueltoCliente * (-1)).ToString("N2")}", posX, posY));
                    }

                }

                posX = 2;
                posY += 50;
                string[] newObservacion = _encabezadoFact.observaciones.Split(stringSeparators, StringSplitOptions.None);

                //e.Graphics.DrawString("OBSERVACIONES: ", fuenteRegular, Brushes.Black, posX, posY);
                lineaImpresion.Add(AgregarUnaLinea("OBSERVACIONES: ", posX, posY));

                if (newObservacion.Length >= 2)
                {
                    for (var fila = 0; fila < newObservacion.Length; fila++)
                    {
                        posY += 15;
                        //e.Graphics.DrawString(newObservacion[fila], fuenteRegular, Brushes.Black, posX + 10, posY);
                        lineaImpresion.Add(AgregarUnaLinea(newObservacion[fila], posX + 10, posY));
                    }
                }
                else
                {
                    posY += 15;
                    //e.Graphics.DrawString(_encabezadoFact.observaciones, fuenteRegular, Brushes.Black, posX, posY);
                    lineaImpresion.Add(AgregarUnaLinea(_encabezadoFact.observaciones, posX, posY));
                }


                posY += 50;
                //e.Graphics.DrawString("ATENDIDO POR: ", fuenteRegular, Brushes.Black, posX, posY);
                lineaImpresion.Add(AgregarUnaLinea("ATENDIDO POR: ", posX, posY));

                posY += 15;
                //e.Graphics.DrawString(_encabezadoFact.atentidoPor, fuenteRegular, Brushes.Black, posX + 15, posY);
                lineaImpresion.Add(AgregarUnaLinea(_encabezadoFact.atentidoPor, posX + 15, posY));

                posY += 70;
                //e.Graphics.DrawString("ENTREGADO: ", fuenteRegular, Brushes.Black, posX, posY);
                lineaImpresion.Add(AgregarUnaLinea("ENTREGADO: ", posX, posY));

                posY += 70;
                //e.Graphics.DrawString("RECIBIDO: ", fuenteRegular, Brushes.Black, posX, posY);
                lineaImpresion.Add(AgregarUnaLinea("RECIBIDO: ", posX, posY));

                posY += 70;
                posX = 30;
                //e.Graphics.DrawString("NO SE ACEPTAN CAMBIOS DESPUES DE", fuenteRegular, Brushes.Black, posX, posY);
                lineaImpresion.Add(AgregarUnaLinea("NO SE ACEPTAN CAMBIOS DESPUES DE", posX, posY));

                posY += 15;
                //e.Graphics.DrawString("48 HORAS. *APLICAN RESTRICCIONES*", fuenteRegular, Brushes.Black, posX, posY);
                lineaImpresion.Add(AgregarUnaLinea("48 HORAS. *APLICAN RESTRICCIONES*", posX, posY));

                posY += 40;
                posX += 23;
                //e.Graphics.DrawString("GRACIAS POR SU COMPRA", fuenteRegular, Brushes.Black, posX, posY);
                lineaImpresion.Add(AgregarUnaLinea("GRACIAS POR SU COMPRA", posX, posY, false));

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return lineaImpresion;

        }

        public void ImprimirTicketFactura(List<DetalleFactura> listDetFactura, Encabezado encabezadoFact, List<DetallePagosPos> viewModelMetodoPago)
        {
            this._listDetFactura = new List<DetalleFactura>();
            this._listMetodoPago = new List<DetallePagosPos>();
            this._listDetFactura = listDetFactura;
            this._listMetodoPago = viewModelMetodoPago;
            this._encabezadoFact = new Encabezado();
            this._encabezadoFact = encabezadoFact;

            //Generar las Lineas de la factura
            lineaImp = new List<LineaImpresion>();
            lineaImp = GenerarLineasTicketFactura(_listDetFactura, encabezadoFact, viewModelMetodoPago);
            printFont= new Font("Bahnschrift Light Condensed", 11, FontStyle.Regular);
            //indice para recorrer la clase
            index = 0;
            doc.PrinterSettings.PrinterName = doc.DefaultPageSettings.PrinterSettings.PrinterName;

            doc.PrintPage += new PrintPageEventHandler(pd_PrintPage);
            // Set the zoom to 25 percent.
            //this.PrintPreviewControl1.Zoom = 0.25;            
            //vista.Controls.Add(this.PrintPreviewControl1);

            vista.Document = doc;
            //doc.Print();
            vista.ShowDialog();
        }


        public void ImprimirTicketFactura_Prueba()
        {
            index = 0;

            //Generar las Lineas de la factura
            lineaImp = new List<LineaImpresion>();
            for(var fila=1; fila < 50; fila++)
            {
                lineaImp.Add(AgregarUnaLinea($"Estamos probando {fila}", 2, 15));
            }

            for (var fila = 1; fila < 50; fila++)
            {
                lineaImp.Add(AgregarUnaLinea($" HOLA OSCAR QUE TE PARECE TYU NUEVO INVENTO? {fila}", 2, 15));
            }
            lineaImp.Add(AgregarUnaLinea("soy la ultima linea", 2, 15, false));

           
            printFont = new Font("Tahoma", 8, FontStyle.Regular);

            doc.PrinterSettings.PrinterName = doc.DefaultPageSettings.PrinterSettings.PrinterName;

            doc.PrintPage += new PrintPageEventHandler(pd_PrintPage);
            // Set the zoom to 25 percent.
            //this.PrintPreviewControl1.Zoom = 0.25;            
            //vista.Controls.Add(this.PrintPreviewControl1);

            vista.Document = doc;
            //doc.Print();
            vista.ShowDialog();
        }


        private void hacerAlgo()
        {


            //try
            //{



                //posX = 2;
                //e.Graphics.DrawString("EJERCITO DE NICARAGUA", fuente, Brushes.Black, posX + 53, posY);
                //posY += 15;
                ////TIENDA ELECTRODOMESTICO
                //if (User.TiendaID == "T01")
                //{
                //    e.Graphics.DrawString(User.NombreTienda, fuente, Brushes.Black, posX + 45, posY);
                //}
                //else
                //{
                //    e.Graphics.DrawString(User.NombreTienda, fuente, Brushes.Black, posX + 80, posY);
                //}

                //posX = 2;
                //posY += 20;
                //e.Graphics.DrawString("CIERRE DE CAJERO", fuente, Brushes.Black, posX + 53, posY);
                //posY += 20;

              
                //posY += 24;
                //e.Graphics.DrawString($"No. CIERRE: { viewModelCierre.Cierre_Pos.Num_Cierre}", fuenteRegular, Brushes.Black, posX, posY);
                //posY += 15;
                //e.Graphics.DrawString($"CONSEC: { viewModelCierre.Cierre_Pos.Documento}", fuenteRegular, Brushes.Black, posX, posY);
                //posY += 15;
                //e.Graphics.DrawString($"CAJA: {viewModelCierre.Cierre_Pos.Caja}", fuenteRegular, Brushes.Black, posX, posY);
                //posY += 15;
                //e.Graphics.DrawString($"CAJERO: { viewModelCierre.Cierre_Pos.Cajero}", fuenteRegular, Brushes.Black, posX, posY);
                //posY += 15;
                //e.Graphics.DrawString($"BODEGA: { viewModelCierre.Cierre_Pos.Nombre_Vendedor}", fuenteRegular, Brushes.Black, posX, posY);
                //posY += 15;
                //e.Graphics.DrawString($"ESTADO: CERRADO", fuenteRegular, Brushes.Black, posX, posY);
                //posY += 15;
                //e.Graphics.DrawString($"FECHA APERTURA: { viewModelCierre.Cierre_Pos.Fecha_Hora_Inicio?.ToString("dd/MM/yyyy hh:mm tt")}", fuenteRegular, Brushes.Black, posX, posY);
                //posY += 15;
                //e.Graphics.DrawString($"FECHA CIERRE: { viewModelCierre.Cierre_Pos.Fecha_Hora.ToString("dd/MM/yyyy hh:mm tt")}", fuenteRegular, Brushes.Black, posX, posY);
                //posY += 15;
                //e.Graphics.DrawString($"TIPO CAMBIO: {viewModelCierre.Cierre_Pos.Tipo_Cambio.ToString("N2")}", fuenteRegular, Brushes.Black, posX, posY);



                ///OSCAR POR AQUI VOY

            //    posY += 25;
            //    e.Graphics.DrawString("_______________________________________________________________________________________________________", fuente, Brushes.Black, posX, posY);

            //    posX = 2;
            //    posY += 25;
            //    e.Graphics.DrawString("TOTAL CORDOBAS EN CAJA:", fuenteRegular, Brushes.Black, posX, posY);
            //    posX += 170;
            //    e.Graphics.DrawString($"C$ {viewModelCierre.Cierre_Pos.Total_Local.ToString("N2")}", fuenteRegular, Brushes.Black, posX, posY);

            //    posX = 2;
            //    posY += 15;
            //    e.Graphics.DrawString("TOTAL DOLAR EN CAJA:", fuenteRegular, Brushes.Black, posX, posY);
            //    posX += 170;
            //    e.Graphics.DrawString($"U$ {viewModelCierre.Cierre_Pos.Total_Dolar.ToString("N2")}", fuenteRegular, Brushes.Black, posX, posY);


            //    posX = 2;
            //    posY += 15;
            //    e.Graphics.DrawString("MONTO APERTURA: ", fuenteRegular, Brushes.Black, posX, posY);
            //    posX += 170;
            //    e.Graphics.DrawString($"C$ {viewModelCierre.Cierre_Pos.Monto_Apertura.ToString("N2")}", fuenteRegular, Brushes.Black, posX, posY);

            //    posX = 2;
            //    posY += 25;
            //    e.Graphics.DrawString("COBRO EFECTIVO CORDOBAS:", fuenteRegular, Brushes.Black, posX, posY);
            //    posX += 170;
            //    e.Graphics.DrawString($"C$ {viewModelCierre.Cierre_Pos.Ventas_Efectivo.ToString("N2")}", fuenteRegular, Brushes.Black, posX, posY);

            //    posX = 2;
            //    posY += 15;
            //    e.Graphics.DrawString("COBRO EFECTIVO DOLAR:", fuenteRegular, Brushes.Black, posX, posY);
            //    posX += 170;
            //    e.Graphics.DrawString($"U$ {viewModelCierre.Cierre_Pos.Cobro_Efectivo_Rep.ToString("N2")}", fuenteRegular, Brushes.Black, posX, posY);


            //    foreach (var item in viewModelCierre.Cierre_Det_Pago)
            //    {
            //        posY += 15;
            //        posX = 2;
            //        e.Graphics.DrawString(item.Tipo_Pago, fuenteRegular, Brushes.Black, posX, posY);

            //        posX += 170;
            //        e.Graphics.DrawString(item.Moneda == "L" ? $"C${item.Total_Sistema.ToString("N2")}" : $"U${item.Total_Sistema.ToString("N2")}", fuenteRegular, Brushes.Black, posX, posY);

            //        posY += 15;
            //        posX = 2;
            //        e.Graphics.DrawString("REPORTADO: ", fuenteRegular, Brushes.Black, posX + 15, posY);

            //        posX += 170;
            //        e.Graphics.DrawString(item.Moneda == "L" ? $"C${item.Total_Usuario.ToString("N2")}" : $"U${item.Total_Usuario.ToString("N2")}", fuenteRegular, Brushes.Black, posX, posY);

            //        posY += 15;
            //        posX = 2;
            //        e.Graphics.DrawString("DIFERENCIA: ", fuenteRegular, Brushes.Black, posX + 15, posY);

            //        posX += 170;
            //        e.Graphics.DrawString(item.Moneda == "L" ? $"C${item.Diferencia.ToString("N2")}" : $"U${item.Diferencia.ToString("N2")}", fuenteRegular, Brushes.Black, posX, posY);


            //    }

            //    posX = 2;
            //    posY += 8;
            //    e.Graphics.DrawString("_____________________________________________________________________________________", fuente, Brushes.Black, posX, posY);


            //    posX = 2;
            //    posY += 15;
            //    e.Graphics.DrawString("TOTAL DIFERENCIA:", fuenteRegular, Brushes.Black, posX, posY);
            //    posX += 140;
            //    e.Graphics.DrawString($"C$ {viewModelCierre.Cierre_Pos.Total_Diferencia.ToString("N2")}", fuenteRegular, Brushes.Black, posX, posY);


            //    posX = 2;
            //    posY += 15;
            //    e.Graphics.DrawString("DOCUMENTO AJUSTE:", fuenteRegular, Brushes.Black, posX, posY);
            //    posX += 140;
            //    e.Graphics.DrawString(viewModelCierre.Cierre_Pos.Documento_Ajuste, fuenteRegular, Brushes.Black, posX, posY);

            //    posX = 2;
            //    posY += 15;
            //    e.Graphics.DrawString("NOTAS:", fuenteRegular, Brushes.Black, posX, posY);

            //    posX = 2;
            //    posY += 20;
            //    e.Graphics.DrawString(viewModelCierre.Cierre_Pos.Notas, fuenteRegular, Brushes.Black, posX, posY);


            //    posY += 200;
            //    posX = 120;
            //    e.Graphics.DrawString(" ", fuenteRegular, Brushes.Black, posX, posY);

            //    numPagina += 1;


            //    posX = 2;
            //    posY = 15;
            //    //TIENDA ELECTRODOMESTICO
            //    if (User.TiendaID == "T01")
            //    {
            //        e.Graphics.DrawString(User.NombreTienda, fuente, Brushes.Black, posX + 45, posY);
            //    }
            //    else
            //    {
            //        e.Graphics.DrawString(User.NombreTienda, fuente, Brushes.Black, posX + 80, posY);
            //    }

            //    posX = 2;
            //    posY += 20;
            //    e.Graphics.DrawString("DESGLOSE VENTAS CON TARJETA", fuente, Brushes.Black, posX + 53, posY);
            //    posY += 20;


            //    posY += 24;
            //    e.Graphics.DrawString($"No. CIERRE: { viewModelCierre.Cierre_Pos.Num_Cierre}", fuenteRegular, Brushes.Black, posX, posY);
            //    posY += 15;
            //    e.Graphics.DrawString($"CAJA: {viewModelCierre.Cierre_Pos.Caja}", fuenteRegular, Brushes.Black, posX, posY);
            //    posY += 15;
            //    e.Graphics.DrawString($"CAJERO: { viewModelCierre.Cierre_Pos.Cajero}", fuenteRegular, Brushes.Black, posX, posY);
            //    posY += 15;
            //    e.Graphics.DrawString(viewModelCierre.Cierre_Pos.Nombre_Vendedor, fuenteRegular, Brushes.Black, posX, posY);
            //    posY += 15;
            //    e.Graphics.DrawString($"FECHA: { viewModelCierre.Cierre_Pos.Fecha_Hora.ToString("dd/MM/yyyy hh:mm:ss tt")}", fuenteRegular, Brushes.Black, posX, posY);
            //    posY += 15;



            //    // Check to see if more pages are to be printed.
            //    //e.HasMorePages = true;

            //    //// If there are no more pages, reset the string to be printed.
            //    //if (!e.HasMorePages)
            //    //    stringToPrint = documentContents;

            //    var tarjetasAgrupad = from d in viewModelCierre.Cierre_Desg_Tarj
            //                          group d by d.Tipo_Tarjeta into tabl_desglose
            //                          select new
            //                          {
            //                              TipoTarjeta = tabl_desglose.Key,
            //                              TotalMontoPorTarjeta = tabl_desglose.Sum(x => x.Monto),
            //                              Cantidad = tabl_desglose.Count()
            //                          };

            //    foreach (var x in tarjetasAgrupad)
            //    {
            //        //obtengo el nombre de la tarjeta
            //        var nombreTarjeta = x.TipoTarjeta;
            //        var cantidad = x.Cantidad;
            //        var totalMontoTarjet = x.TotalMontoPorTarjeta;

            //        posY += 20;
            //        e.Graphics.DrawString("_______________________________________________________________________________________________________", fuente, Brushes.Black, posX, posY);
            //        posY += 15;
            //        //imprimo el nombre de la tarjeta
            //        e.Graphics.DrawString($"TARJETA     {nombreTarjeta}", fuenteRegular, Brushes.Black, posX, posY);
            //        posY += 20;
            //        e.Graphics.DrawString("_______________________________________________________________________________________________________", fuente, Brushes.Black, posX, posY);

            //        posX = 2;
            //        posY += 15;
            //        e.Graphics.DrawString("Factura", fuenteRegular, Brushes.Black, posX, posY);
            //        e.Graphics.DrawString("Monto", fuenteRegular, Brushes.Black, posX + 140, posY);

            //        foreach (var item in viewModelCierre.Cierre_Desg_Tarj)
            //        {
            //            //mostrar las facturas y monto de la tarjeta
            //            if (item.Tipo_Tarjeta == nombreTarjeta)
            //            {
            //                posX = 2;
            //                posY += 15;
            //                //imprimir el numero de factura
            //                e.Graphics.DrawString(item.Documento, fuenteRegular, Brushes.Black, posX, posY);
            //                //imprimir el monto de la factura
            //                e.Graphics.DrawString(item.Monto.ToString("N2"), fuenteRegular, Brushes.Black, posX + 140, posY);
            //            }
            //        }

            //        posY += 15;
            //        //imprimo el nombre de la tarjeta
            //        e.Graphics.DrawString($"TOTAL      {nombreTarjeta}", fuenteRegular, Brushes.Black, posX, posY);
            //        e.Graphics.DrawString(totalMontoTarjet.ToString("N2"), fuenteRegular, Brushes.Black, posX + 140, posY);
            //        posY += 15;




            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}




        }
        private List<LineaImpresion> GenerarLineasReporteCierre(ViewModelCierre reporteCierre)
        {
            int posX = 2;
            int posY = 2;
            int posXtemp = 0;
            List<LineaImpresion> lineaImpresion = new List<LineaImpresion>();

            try
            {

              
                //identificar si es tienda electrodomestico
                posXtemp = User.TiendaID == "T01" ? posX + 45 : posX + 80;
                posY = 17;
                lineaImpresion.Add(AgregarUnaLinea(User.NombreTienda, posXtemp, posY));

                posX = 2;
                //posY = 15;
                //e.Graphics.DrawString($"Tel.: {User.TelefonoTienda}", fuente, Brushes.Black, posX + 60, posY);
                lineaImpresion.Add(AgregarUnaLinea("CIERRE DE CAJERO", posX + 53, posY));

                posY = 44;                
                lineaImpresion.Add(AgregarUnaLinea($"No. CIERRE: { reporteCierre.Cierre_Pos.Num_Cierre}", posX, posY));

                posY = 17;
                lineaImpresion.Add(AgregarUnaLinea($"CONSEC: { reporteCierre.Cierre_Pos.Documento}", posX, posY));
                lineaImpresion.Add(AgregarUnaLinea($"CAJA: { reporteCierre.Cierre_Pos.Caja}", posX, posY));             
                lineaImpresion.Add(AgregarUnaLinea($"CAJERO: { reporteCierre.Cierre_Pos.Cajero}", posX, posY));
                lineaImpresion.Add(AgregarUnaLinea($"BODEGA: { reporteCierre.Cierre_Pos.Nombre_Vendedor}", posX, posY));
                lineaImpresion.Add(AgregarUnaLinea("ESTADO: CERRADO", posX, posY));
                lineaImpresion.Add(AgregarUnaLinea($"FECHA APERTURA: {reporteCierre.Cierre_Pos.Fecha_Hora_Inicio?.ToString("dd/MM/yyyy hh:mm tt")}", posX, posY));
                lineaImpresion.Add(AgregarUnaLinea($"FECHA CIERRE: { reporteCierre.Cierre_Pos.Fecha_Hora.ToString("dd/MM/yyyy hh:mm tt")}", posX, posY));
                lineaImpresion.Add(AgregarUnaLinea($"TIPO CAMBIO: { reporteCierre.Cierre_Pos.Tipo_Cambio.ToString("N2")}", posX, posY));
                posY = 25;
                lineaImpresion.Add(AgregarUnaLinea("_______________________________________________________________________________________________________", posX, posY));




                //factura
                posY = 40;
                //e.Graphics.DrawString("N° Factura: " + _encabezadoFact.NoFactura, fuenteRegular, Brushes.Black, posX, posY);
                lineaImpresion.Add(AgregarUnaLinea("N° FACTURA: " + _encabezadoFact.NoFactura, posX, posY));
                posY = 17;
                //e.Graphics.DrawString("Codigo Cliente: " + _encabezadoFact.codigoCliente, fuenteRegular, Brushes.Black, posX, posY);
                lineaImpresion.Add(AgregarUnaLinea("CODIGO CLIENTE: " + _encabezadoFact.codigoCliente, posX, posY));

                //posY = 15;
                //e.Graphics.DrawString("Fecha: " + _encabezadoFact.cliente, fuenteRegular, Brushes.Black, posX, posY);
                lineaImpresion.Add(AgregarUnaLinea("CLIENTE: " + _encabezadoFact.cliente, posX, posY));
                //posY = 15;
                //e.Graphics.DrawString("Bodega: " + _encabezadoFact.bodega, fuenteRegular, Brushes.Black, posX, posY);
                lineaImpresion.Add(AgregarUnaLinea("BODEGA: " + _encabezadoFact.bodega, posX, posY));
                //posY = 15;
                //e.Graphics.DrawString("Caja: " + _encabezadoFact.caja, fuenteRegular, Brushes.Black, posX, posY);
                lineaImpresion.Add(AgregarUnaLinea("CAJA: " + _encabezadoFact.caja, posX, posY));
                //posY = 15;
                //e.Graphics.DrawString("Tipo Cambio: " + _encabezadoFact.tipoCambio.ToString("N2"), fuenteRegular, Brushes.Black, posX, posY);
                lineaImpresion.Add(AgregarUnaLinea("TIPO CAMBIO: " + _encabezadoFact.tipoCambio.ToString("N2"), posX, posY));
                posY = 18;
                //e.Graphics.DrawString("-------------------------------------------------------------------------", fuente, Brushes.Black, posX, posY);
                lineaImpresion.Add(AgregarUnaLinea("-------------------------------------------------------------------------", posX, posY));

                posY = 10;
                //e.Graphics.DrawString("Codigo", fuente, Brushes.Black, posX, posY);
                lineaImpresion.Add(AgregarUnaLinea("Codigo", posX, posY));

                posX += 60;
                //e.Graphics.DrawString("Cant", fuente, Brushes.Black, posX, posY);
                lineaImpresion.Add(AgregarUnaLinea("Cant", posX, 0));
                posX += 50;
                //e.Graphics.DrawString("Precio", fuente, Brushes.Black, posX, posY);
                lineaImpresion.Add(AgregarUnaLinea("Precio", posX, 0));

                posX += 50;
                //e.Graphics.DrawString("Desc", fuente, Brushes.Black, posX, posY);
                lineaImpresion.Add(AgregarUnaLinea("Desc", posX, 0));

                posX += 55;
                //e.Graphics.DrawString("Monto", fuente, Brushes.Black, posX, posY);
                lineaImpresion.Add(AgregarUnaLinea("Monto", posX, 0));

                posY = 10;
                //reiniciar la posicionX
                posX = 2;
                //e.Graphics.DrawString("-------------------------------------------------------------------------", fuente, Brushes.Black, posX, posY);
                lineaImpresion.Add(AgregarUnaLinea("-------------------------------------------------------------------------", posX, posY));



                //e.Graphics.DrawString("8721160000939", fuenteRegular, Brushes.Black, posX, posY);
                //_listDetFactura

                foreach (var detalleFactura in _listDetFactura)
                {
                    posY = 20;
                    //e.Graphics.DrawString(detalleFactura.ArticuloId, fuenteRegular, Brushes.Black, posX, posY);
                    lineaImpresion.Add(AgregarUnaLinea(detalleFactura.ArticuloId, posX, posY));

                    posX += 60;
                    //e.Graphics.DrawString(detalleFactura.Cantidad_d.ToString("N2"), fuenteRegular, Brushes.Black, posX, posY);
                    lineaImpresion.Add(AgregarUnaLinea(detalleFactura.Cantidad_d.ToString("N2"), posX, 0));

                    posX += 45;
                    //e.Graphics.DrawString(detalleFactura.PrecioCordobas.ToString("N2"), fuenteRegular, Brushes.Black, posX, posY);
                    lineaImpresion.Add(AgregarUnaLinea(detalleFactura.PrecioCordobas.ToString("N2"), posX, 0));

                    posX += 60;
                    //e.Graphics.DrawString(Convert.ToDecimal(detalleFactura.DescuentoPorLineaCordoba).ToString("N2"), fuenteRegular, Brushes.Black, posX, posY);
                    lineaImpresion.Add(AgregarUnaLinea(detalleFactura.DescuentoPorLineaCordoba.ToString("N2"), posX, 0));

                    posX += 50;
                    //e.Graphics.DrawString(detalleFactura.TotalCordobas.ToString("N2"), fuenteRegular, Brushes.Black, posX, posY);
                    lineaImpresion.Add(AgregarUnaLinea(detalleFactura.TotalCordobas.ToString("N2"), posX, 0));

                    //salto a la siguiente linea
                    posY = 17;
                    posX = 2;
                    //e.Graphics.DrawString(detalleFactura.Descripcion, fuenteRegular_7, Brushes.Black, posX, posY);
                    lineaImpresion.Add(AgregarUnaLinea(detalleFactura.Descripcion, posX, posY));

                    //posY = 15;

                }

                posY = 15;
                //e.Graphics.DrawString("-------------------------------------------------------------------------", fuente, Brushes.Black, posX, posY);
                lineaImpresion.Add(AgregarUnaLinea("-------------------------------------------------------------------------", posX, posY));

                posY = 17;
                posX = 130;
                //e.Graphics.DrawString("Sub Total:", fuente, Brushes.Black, posX, posY);
                lineaImpresion.Add(AgregarUnaLinea($"SUB TOTAL:         C$ {_encabezadoFact.subTotalCordoba.ToString("N2")}", posX, posY));

                //posX += 65;
                ////e.Graphics.DrawString("C$ " + _encabezadoFact.subTotalCordoba.ToString("N2"), fuenteRegular, Brushes.Black, posX, posY);
                //lineaImpresion.Add(AgregarUnaLinea("C$ " + _encabezadoFact.subTotalCordoba.ToString("N2"), posX, posY));



                //posY = 15;
                posX = 130;
                //e.Graphics.DrawString("Descuento:", fuente, Brushes.Black, posX, posY);
                lineaImpresion.Add(AgregarUnaLinea($"DESCUENTO:        C$ {_encabezadoFact.descuentoCordoba.ToString("N2")}", posX, posY));

                //posX += 65;
                ////e.Graphics.DrawString("C$ " + _encabezadoFact.descuentoCordoba.ToString("N2"), fuenteRegular, Brushes.Black, posX, posY);
                //lineaImpresion.Add(AgregarUnaLinea("C$ " + _encabezadoFact.descuentoCordoba.ToString("N2"), posX, posY));


                /************************* RETENCIONES ************************************************************************/
                if (_encabezadoFact.MontoRetencion > 0)
                {
                    //posY = 17;
                    posX = 130;
                    //e.Graphics.DrawString("Retencion:", fuente, Brushes.Black, posX, posY);
                    lineaImpresion.Add(AgregarUnaLinea($"RETENCION:         C$ {_encabezadoFact.MontoRetencion.ToString("N2")}", posX, posY));

                    //posX += 65;
                    ////e.Graphics.DrawString("C$ " + _encabezadoFact.MontoRetencion.ToString("N2"), fuenteRegular, Brushes.Black, posX, posY);
                    //lineaImpresion.Add(AgregarUnaLinea("C$ " + _encabezadoFact.MontoRetencion.ToString("N2"), posX, posY));
                }
                /****************************************************************************************************************/


                // posY = 15;
                posX = 130;
                //e.Graphics.DrawString("IVA:", fuente, Brushes.Black, posX, posY);
                lineaImpresion.Add(AgregarUnaLinea($"IVA:                     C$ {_encabezadoFact.ivaCordoba.ToString("N2")}", posX, posY));

                //posX += 65;
                ////e.Graphics.DrawString("C$ " + _encabezadoFact.ivaCordoba.ToString("N2"), fuenteRegular, Brushes.Black, posX, posY);
                //lineaImpresion.Add(AgregarUnaLinea("C$ " + _encabezadoFact.ivaCordoba.ToString("N2"), posX, posY));

                //posY = 15;
                posX = 130;
                //e.Graphics.DrawString("Total a Pagar:", fuente, Brushes.Black, posX, posY);
                lineaImpresion.Add(AgregarUnaLinea($"TOTAL A PAGAR: C$ {_encabezadoFact.totalCordoba.ToString("N2")}", posX, posY));

                // posX += 65;
                //// e.Graphics.DrawString("C$ " + _encabezadoFact.totalCordoba.ToString("N2"), fuenteRegular, Brushes.Black, posX, posY);
                // lineaImpresion.Add(AgregarUnaLinea("C$ " + _encabezadoFact.totalCordoba.ToString("N2"), posX, posY));


                //posY = 15;
                posX = 130;
                //e.Graphics.DrawString("Total a Pagar:", fuente, Brushes.Black, posX, posY);
                lineaImpresion.Add(AgregarUnaLinea($"TOTAL A PAGAR: U$ {_encabezadoFact.totalDolar.ToString("N2")}", posX, posY));

                //posX += 65;
                ////e.Graphics.DrawString("U$ " + _encabezadoFact.totalDolar.ToString("N2"), fuenteRegular, Brushes.Black, posX, posY);
                //lineaImpresion.Add(AgregarUnaLinea("U$ " + _encabezadoFact.totalDolar.ToString("N2"), posX, posY));

                /************************************************************************************/
                string[] stringSeparators = new string[] { "\r\n" };

                //convertir el registro en arreglo
                //string[] newformaDePago = _encabezadoFact.formaDePago.Split(stringSeparators, StringSplitOptions.None);


                ////comprobar si tiene mas de 2 registro el arreglo                               
                //if (newformaDePago.Length >= 2)
                //{
                //    posY = 20;
                //    e.Graphics.DrawString($"FORMA DE PAGO: {newformaDePago[0]}", fuenteRegular, Brushes.Black, posX, posY);

                //    for (var rows = 1; rows < newformaDePago.Length; rows++)
                //    {
                //        posY = 20;
                //        e.Graphics.DrawString(newformaDePago[rows], fuenteRegular, Brushes.Black, posX, posY);
                //    }
                //}
                //else
                //{
                //    posY = 20;
                //    e.Graphics.DrawString("FORMA DE PAGO: " + _encabezadoFact.formaDePago, fuenteRegular, Brushes.Black, posX, posY);
                //}

                //reiniciar en la posicion X
                posX = 2;
                //posY = 15;
                //e.Graphics.DrawString("-------------------------------------------------------------------------", fuente, Brushes.Black, posX, posY);
                lineaImpresion.Add(AgregarUnaLinea("-------------------------------------------------------------------------", posX, posY));

                //posY = 10;
                //e.Graphics.DrawString("FORMA DE PAGO: ", fuenteRegular, Brushes.Black, posX + 90, posY);
                lineaImpresion.Add(AgregarUnaLinea("FORMA DE PAGO: ", posX, posY));

                foreach (var listPagos in _listMetodoPago)
                {

                    //reiniciar con 2
                    posX = 2;
                    posY = 17;
                    //e.Graphics.DrawString(listPagos.DescripcionFormaPago, fuenteRegular, Brushes.Black, posX, posY);
                    lineaImpresion.Add(AgregarUnaLinea(listPagos.DescripcionFormaPago, posX, posY));

                    //sumar 160
                    posX = 220;
                    //e.Graphics.DrawString((listPagos.Moneda == 'D' ? $"U${listPagos.MontoDolar.ToString("N2")}" : $"C${listPagos.MontoCordoba.ToString("N2")}"), fuenteRegular, Brushes.Black, posX, posY);
                    lineaImpresion.Add(AgregarUnaLinea((listPagos.Moneda == 'D' ? $"U${listPagos.MontoDolar.ToString("N2")}" : $"C${listPagos.MontoCordoba.ToString("N2")}"), posX, 0));

                    //si existe vuelto
                    if (listPagos.VueltoCliente < 0)
                    {
                        //reiniciar con 2
                        posX = 2;
                        //posY = 15;
                        //e.Graphics.DrawString("SU CAMBIO: ", fuenteRegular, Brushes.Black, posX, posY);
                        lineaImpresion.Add(AgregarUnaLinea("SU CAMBIO: ", posX, posY));

                        //sumar 160
                        posX = 220;
                        //e.Graphics.DrawString($"C${(listPagos.VueltoCliente * (-1)).ToString("N2")}", fuenteRegular, Brushes.Black, posX, posY);
                        lineaImpresion.Add(AgregarUnaLinea($"C${(listPagos.VueltoCliente * (-1)).ToString("N2")}", posX, 0));
                    }

                }

                posX = 2;
                posY = 50;
                string[] newObservacion = _encabezadoFact.observaciones.Split(stringSeparators, StringSplitOptions.None);

                //e.Graphics.DrawString("OBSERVACIONES: ", fuenteRegular, Brushes.Black, posX, posY);
                lineaImpresion.Add(AgregarUnaLinea("OBSERVACIONES: ", posX, posY));

                if (newObservacion.Length >= 2)
                {
                    for (var fila = 0; fila < newObservacion.Length; fila++)
                    {
                        posY = 17;
                        //e.Graphics.DrawString(newObservacion[fila], fuenteRegular, Brushes.Black, posX + 10, posY);
                        lineaImpresion.Add(AgregarUnaLinea(newObservacion[fila], posX + 10, posY));
                    }
                }
                else
                {
                    posY = 17;
                    //e.Graphics.DrawString(_encabezadoFact.observaciones, fuenteRegular, Brushes.Black, posX, posY);
                    lineaImpresion.Add(AgregarUnaLinea(_encabezadoFact.observaciones, posX, posY));
                }


                posY = 50;
                //e.Graphics.DrawString("ATENDIDO POR: ", fuenteRegular, Brushes.Black, posX, posY);
                lineaImpresion.Add(AgregarUnaLinea("ATENDIDO POR: ", posX, posY));

                posY = 17;
                //e.Graphics.DrawString(_encabezadoFact.atentidoPor, fuenteRegular, Brushes.Black, posX + 15, posY);
                lineaImpresion.Add(AgregarUnaLinea(_encabezadoFact.atentidoPor, posX + 15, posY));

                posY = 70;
                //e.Graphics.DrawString("ENTREGADO: ", fuenteRegular, Brushes.Black, posX, posY);
                lineaImpresion.Add(AgregarUnaLinea("ENTREGADO: ", posX, posY));

                posY = 70;
                //e.Graphics.DrawString("RECIBIDO: ", fuenteRegular, Brushes.Black, posX, posY);
                lineaImpresion.Add(AgregarUnaLinea("RECIBIDO: ", posX, posY));

                posY = 70;
                posX = 50;
                //e.Graphics.DrawString("NO SE ACEPTAN CAMBIOS DESPUES DE", fuenteRegular, Brushes.Black, posX, posY);
                lineaImpresion.Add(AgregarUnaLinea("NO SE ACEPTAN CAMBIOS DESPUES DE", posX, posY));

                posY = 17;
                //e.Graphics.DrawString("48 HORAS. *APLICAN RESTRICCIONES*", fuenteRegular, Brushes.Black, posX, posY);
                lineaImpresion.Add(AgregarUnaLinea("48 HORAS. *APLICAN RESTRICCIONES*", posX, posY));

                posY = 40;
                posX += 23;
                //e.Graphics.DrawString("GRACIAS POR SU COMPRA", fuenteRegular, Brushes.Black, posX, posY);
                lineaImpresion.Add(AgregarUnaLinea("GRACIAS POR SU COMPRA", posX, posY, false));

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return lineaImpresion;

        }

        public void ImprimirReporteCierre(ViewModelCierre reporteCierre)
        {
            

            //Generar las Lineas de la factura
            lineaImp = new List<LineaImpresion>();
            lineaImp = GenerarLineasReporteCierre(reporteCierre);
            printFont = new Font("Bahnschrift Light Condensed", 11, FontStyle.Regular);
            //indice para recorrer la clase
            index = 0;
            doc.PrinterSettings.PrinterName = doc.DefaultPageSettings.PrinterSettings.PrinterName;

            doc.PrintPage += new PrintPageEventHandler(pd_PrintPage);
            // Set the zoom to 25 percent.
            //this.PrintPreviewControl1.Zoom = 0.25;            
            //vista.Controls.Add(this.PrintPreviewControl1);

            vista.Document = doc;
            //doc.Print();
            vista.ShowDialog();
        }


        public void pd_PrintPage(object sender, PrintPageEventArgs ev)
        {
            bool tieneMasLinea=true;
            float linesPerPage = 0;
            float xPos = 0;
            float yPos = 0;
            int row = 0;     
            string line = null;

            var x = printFont.GetHeight(ev.Graphics);
            var y = ev.MarginBounds.Height;

            // Calculate the number of lines per page.
            linesPerPage = ev.MarginBounds.Height / printFont.GetHeight(ev.Graphics);
                    
            while (row < linesPerPage && tieneMasLinea)
            {
                line = lineaImp[index].Linea.ToString();
                xPos = lineaImp[index].PosX;
                yPos += lineaImp[index].PosY;

                //OSCAR, AYER ESTABA ANALIZANDO QUE CUANDO yPos tenga cero, y el siguiente tambien vale cero y el siguiente vale (osea ir haciendo estas comprobaciones
                //en ciclo para cuando y =0 para imprimir todas se impriman en la misma fila. dejo esto como observacion para mejorarlas
               
                ev.Graphics.DrawString(line, printFont, Brushes.Black, xPos, yPos, new StringFormat());
                tieneMasLinea = lineaImp[index].TieneMasLinea;              
                row++;
                index++;
            }

            // If more lines exist, print another page.
            if (tieneMasLinea)
            {
                ev.HasMorePages = true;
            }               
            else
            {
                ev.HasMorePages = false;
                index = 0;
            }
                
        }



    }
}
