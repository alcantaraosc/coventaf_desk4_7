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


        private LineaImpresion AgregarUnaLinea(string linea, int posX, int posY, bool saltoProxLinea = true, bool tieneMasLinea=true)
        {
            var lineaImpresion = new LineaImpresion()
            {
                Linea = linea,
                PosX = posX,
                PosY = posY,
                SaltoProxLinea = saltoProxLinea,
                TieneMasLinea = tieneMasLinea
            };

            return lineaImpresion;
        }            

        private void SepararDireccion(List<LineaImpresion> lineaImpresion, string texto, int posX,  int posY)
        {
            string[] textoImprimir = texto.Split('*');


            //comprobar si tiene mas de 2 registro el arreglo                               
            if (textoImprimir.Length >= 2)
            {
                //posY += incrementoY;
                //e.Graphics.DrawString(textoImprimir[0], fuente, Brushes.Black, posX + incrementoX, posY);

                for (var rows = 0; rows < textoImprimir.Length; rows++)
                {                    
                    lineaImpresion.Add(AgregarUnaLinea(textoImprimir[rows], posX , posY));
                    //e.Graphics.DrawString(textoImprimir[rows], fuente, Brushes.Black, posX + incrementoX, posY);
                }
            }
            else
            {                
                lineaImpresion.Add(AgregarUnaLinea(texto, posX, posY));
                //e.Graphics.DrawString(texto, fuente, Brushes.Black, posX + incrementoX, posY);
            }
        }

        public List<LineaImpresion> GenerarLineasTicketFactura(List<DetalleFactura> _listDetFactura, Encabezado _encabezadoFact, List<DetallePagosPos> _listMetodoPago)
        {
            int posX = 2;
            int posY = 0;
            
            List<LineaImpresion> lineaImpresion = new List<LineaImpresion>();

            try
            {

                lineaImpresion.Add(AgregarUnaLinea("EJERCITO DE NICARAGUA", 85, posY));
                //identificar si es tienda electrodomestico                
                posX = User.TiendaID == "T01" ? 74 : 108;               
                posY = 17;
                lineaImpresion.Add(AgregarUnaLinea(User.NombreTienda, posX, posY));
                //imprimir la direccion
                posX = 70;
                SepararDireccion(lineaImpresion, User.DireccionTienda, posX, posY);
                //posY = 15;
                //e.Graphics.DrawString($"Tel.: {User.TelefonoTienda}", fuente, Brushes.Black, posX + 60, posY);
                lineaImpresion.Add(AgregarUnaLinea($"TELF.: {User.TelefonoTienda}", 100, posY));

                //posY = 17;
                //e.Graphics.DrawString("N° RUC: J1330000001272", fuente, Brushes.Black, posX + 55, posY);
                lineaImpresion.Add(AgregarUnaLinea("N° RUC: J1330000001272", 90, posY));

                //factura
                posX = 2;
                posY = 40;
                //e.Graphics.DrawString("N° Factura: " + _encabezadoFact.NoFactura, fuenteRegular, Brushes.Black, posX, posY);
                lineaImpresion.Add(AgregarUnaLinea("N° FACTURA: " + _encabezadoFact.NoFactura, posX, posY));
                posY = 17;
                //e.Graphics.DrawString("Codigo Cliente: " + _encabezadoFact.codigoCliente, fuenteRegular, Brushes.Black, posX, posY);
                lineaImpresion.Add(AgregarUnaLinea("CLIENTE: " + _encabezadoFact.codigoCliente, posX, posY));
              
                //posY = 15;
                //e.Graphics.DrawString("Fecha: " + _encabezadoFact.cliente, fuenteRegular, Brushes.Black, posX, posY);
                lineaImpresion.Add(AgregarUnaLinea(_encabezadoFact.cliente, posX + 30, posY));
                lineaImpresion.Add(AgregarUnaLinea("FECHA: " + _encabezadoFact.fecha, posX, posY));                               
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
                lineaImpresion.Add(AgregarUnaLinea("Codigo", posX, posY, false));
               
                posX += 60;
                //e.Graphics.DrawString("Cant", fuente, Brushes.Black, posX, posY);
                lineaImpresion.Add(AgregarUnaLinea("Cant", posX, 0, false));                
                posX += 50;
                //e.Graphics.DrawString("Precio", fuente, Brushes.Black, posX, posY);
                lineaImpresion.Add(AgregarUnaLinea("Precio", posX, 0, false));                
                
                posX += 50;
                //e.Graphics.DrawString("Desc", fuente, Brushes.Black, posX, posY);
                lineaImpresion.Add(AgregarUnaLinea("Desc", posX, 0, false));
                
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
                    lineaImpresion.Add(AgregarUnaLinea(detalleFactura.ArticuloId, posX, posY, false));

                    posX += 60;
                    //e.Graphics.DrawString(detalleFactura.Cantidad_d.ToString("N2"), fuenteRegular, Brushes.Black, posX, posY);
                    lineaImpresion.Add(AgregarUnaLinea(detalleFactura.Cantidad_d.ToString("N2"), posX, 0, false));

                    posX += 45;
                    //e.Graphics.DrawString(detalleFactura.PrecioCordobas.ToString("N2"), fuenteRegular, Brushes.Black, posX, posY);
                    lineaImpresion.Add(AgregarUnaLinea(detalleFactura.PrecioCordobas.ToString("N2"), posX, 0, false));

                    posX += 60;
                    //e.Graphics.DrawString(Convert.ToDecimal(detalleFactura.DescuentoPorLineaCordoba).ToString("N2"), fuenteRegular, Brushes.Black, posX, posY);
                    lineaImpresion.Add(AgregarUnaLinea(detalleFactura.DescuentoPorLineaCordoba.ToString("N2"), posX, 0, false));

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
                    lineaImpresion.Add(AgregarUnaLinea(listPagos.DescripcionFormaPago, posX, posY, false));

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
                        lineaImpresion.Add(AgregarUnaLinea("SU CAMBIO: ", posX, posY, false));

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
                lineaImpresion.Add(AgregarUnaLinea("GRACIAS POR SU COMPRA", posX, posY));
                posX = 2;
                lineaImpresion.Add(AgregarUnaLinea(User.Demo, posX, posY + 40));
                lineaImpresion.Add(AgregarUnaLinea("", posX, posY+40, true, false));



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

        private List<LineaImpresion> GenerarLineasEncabezado(ViewModelCierre reporteCierre)
        {
            int posX = 2;
            int posY = 2;
            int posXtemp = 0;
            List<LineaImpresion> lineaImpresion = new List<LineaImpresion>();

            try
            {
                //identificar si es tienda electrodomestico
                posXtemp = User.TiendaID == "T01" ? 84 : 108;
                posY = 17;
                lineaImpresion.Add(AgregarUnaLinea("TIENDA ELECTRODOMESTICO", 84, posY));
                lineaImpresion.Add(AgregarUnaLinea("DESGLOSE VENTAS CON TARJETA", 75, posY));
                //lineaImpresion.Add(AgregarUnaLinea("DOCUMENTO DE AJUSTE", 84, posY));

                posX = 108;
                //posY = 15;
                //e.Graphics.DrawString($"Tel.: {User.TelefonoTienda}", fuente, Brushes.Black, posX + 60, posY);
                lineaImpresion.Add(AgregarUnaLinea("CIERRE DE CAJERO", posX, posY));
                lineaImpresion.Add(AgregarUnaLinea("KM 6 C. NORTE, PASO A DESNIVEL", 70, posY));
                lineaImpresion.Add(AgregarUnaLinea("DESGLOSE VENTAS CON TARJETA", 75, posY));
                lineaImpresion.Add(AgregarUnaLinea($"Telf.: {User.TelefonoTienda}", 100, posY));
                lineaImpresion.Add(AgregarUnaLinea("N° RUC: J1330000001272", 90, posY));
                posY = 44;
                lineaImpresion.Add(AgregarUnaLinea($"No. CIERRE: { reporteCierre.Cierre_Pos.Num_Cierre}", posX, posY));

               

                lineaImpresion.Add(AgregarUnaLinea("", posX, posY, true, false));

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return lineaImpresion;

        }

        private List<LineaImpresion> GenerarLineasReporteCierreCajero(ViewModelCierre reporteCierre)
        {
            int posX = 2;
            int posY = 2;
            int posXtemp = 0;
            List<LineaImpresion> lineaImpresion = new List<LineaImpresion>();

            try
            {
                lineaImpresion.Add(AgregarUnaLinea("EJERCITO DE NICARAGUA", 85, posY));         
                //identificar si es tienda electrodomestico
                posXtemp = User.TiendaID == "T01" ? 74 : 108;
                posY = 17;
                lineaImpresion.Add(AgregarUnaLinea(User.NombreTienda, posXtemp, posY));
                posX = 2;
                //posY = 15;
                //e.Graphics.DrawString($"Tel.: {User.TelefonoTienda}", fuente, Brushes.Black, posX + 60, posY);
                lineaImpresion.Add(AgregarUnaLinea("CIERRE DE CAJERO", 100, posY));

                posY = 44;
                lineaImpresion.Add(AgregarUnaLinea($"No. CIERRE: { reporteCierre.Cierre_Pos.Num_Cierre}", posX, posY));

                posY = 17;
                lineaImpresion.Add(AgregarUnaLinea($"CONSECUTIVO: { reporteCierre.Cierre_Pos.Documento}", posX, posY));
                lineaImpresion.Add(AgregarUnaLinea($"CAJA: { reporteCierre.Cierre_Pos.Caja}", posX, posY));
                lineaImpresion.Add(AgregarUnaLinea($"CAJERO: { reporteCierre.Cierre_Pos.Cajero}", posX, posY));
                lineaImpresion.Add(AgregarUnaLinea($"BODEGA: { reporteCierre.Cierre_Pos.Nombre_Vendedor}", posX, posY));
                lineaImpresion.Add(AgregarUnaLinea("ESTADO: CERRADO", posX, posY));
                lineaImpresion.Add(AgregarUnaLinea($"FECHA APERTURA: {reporteCierre.Cierre_Pos.Fecha_Hora_Inicio?.ToString("dd/MM/yyyy hh:mm tt")}", posX, posY));
                lineaImpresion.Add(AgregarUnaLinea($"FECHA CIERRE: { reporteCierre.Cierre_Pos.Fecha_Hora.ToString("dd/MM/yyyy hh:mm tt")}", posX, posY));
                lineaImpresion.Add(AgregarUnaLinea($"TIPO CAMBIO: { reporteCierre.Cierre_Pos.Tipo_Cambio.ToString("N2")}", posX, posY));
                posY = 20;
                lineaImpresion.Add(AgregarUnaLinea("_______________________________________________________________________________________________________", posX, posY));


                lineaImpresion.Add(AgregarUnaLinea("TOTAL CORDOBAS EN CAJA: ", posX, posY, false));
                posX += 170;
                lineaImpresion.Add(AgregarUnaLinea($"C$ {reporteCierre.Cierre_Pos.Total_Local.ToString("N2")}", posX, 0));

                posX = 2;
                posY = 17;
                lineaImpresion.Add(AgregarUnaLinea("TOTAL DOLAR EN CAJA: ", posX, posY, false));
                posX += 170;
                lineaImpresion.Add(AgregarUnaLinea($"U$ {reporteCierre.Cierre_Pos.Total_Dolar.ToString("N2")}", posX, 0));

                posX = 2;
                lineaImpresion.Add(AgregarUnaLinea("MONTO APERTURA: ", posX, posY, false));
                posX += 170;
                lineaImpresion.Add(AgregarUnaLinea($"C$ {reporteCierre.Cierre_Pos.Monto_Apertura.ToString("N2")}", posX, 0));

                posX = 2;
                lineaImpresion.Add(AgregarUnaLinea("COBRO EFECTIVO CORDOBAS: ", posX, posY, false));
                posX += 170;
                lineaImpresion.Add(AgregarUnaLinea($"C$ {reporteCierre.Cierre_Pos.Ventas_Efectivo.ToString("N2")}", posX, 0));

                posX = 2;
                lineaImpresion.Add(AgregarUnaLinea("COBRO EFECTIVO DOLAR: ", posX, posY, false));
                posX += 170;
                lineaImpresion.Add(AgregarUnaLinea($"C$ {reporteCierre.Cierre_Pos.Cobro_Efectivo_Rep.ToString("N2")}", posX, 0));

                foreach (var item in reporteCierre.Cierre_Det_Pago)
                {
                    posY = 25;
                    posX = 2;
                    lineaImpresion.Add(AgregarUnaLinea(item.Tipo_Pago, posX, posY, false));
                    posX += 170;
                    lineaImpresion.Add(AgregarUnaLinea(item.Moneda == "L" ? $"C$ {item.Total_Sistema.ToString("N2")}" : $"U$ {item.Total_Sistema.ToString("N2")}", posX, 0));

                    posY = 17;
                    posX = 2;
                    lineaImpresion.Add(AgregarUnaLinea("REPORTADO", posX + 10, posY, false));
                    posX += 170;
                    lineaImpresion.Add(AgregarUnaLinea(item.Moneda == "L" ? $"C$ {item.Total_Usuario.ToString("N2")}" : $"U$ {item.Total_Usuario.ToString("N2")}", posX, 0));


                    posX = 2;
                    lineaImpresion.Add(AgregarUnaLinea("DIFERENCIA", posX + 10, posY, false));
                    posX += 170;
                    lineaImpresion.Add(AgregarUnaLinea(item.Moneda == "L" ? $"C$ {item.Diferencia.ToString("N2")}" : $"U$ {item.Diferencia.ToString("N2")}", posX, 0));
                }

                posX = 2;
                posY = 10;
                lineaImpresion.Add(AgregarUnaLinea("_____________________________________________________________________________________", posX, posY));


                posX = 2;
                posY = 17;
                lineaImpresion.Add(AgregarUnaLinea("TOTAL DIFERENCIA:", posX, posY, false));

                posX += 170;
                lineaImpresion.Add(AgregarUnaLinea($"C$ {reporteCierre.Cierre_Pos.Total_Diferencia.ToString("N2")}", posX, 0));


                if (reporteCierre.Cierre_Pos.Documento_Ajuste?.Length > 0)
                {
                    posX = 2;
                    lineaImpresion.Add(AgregarUnaLinea("DOCUMENTO AJUSTE:", posX, posY, false));
                    posX += 140;
                    lineaImpresion.Add(AgregarUnaLinea(reporteCierre.Cierre_Pos.Documento_Ajuste, posX, 0));
                }


                posX = 2;
                lineaImpresion.Add(AgregarUnaLinea("NOTAS:", posX, posY));

                posY = 20;
                lineaImpresion.Add(AgregarUnaLinea(reporteCierre.Cierre_Pos.Notas, posX, posY));

                posY = 200;                
                lineaImpresion.Add(AgregarUnaLinea("", posX, posY));


                posX = 2;
                //identificar si es tienda electrodomestico
                posX = User.TiendaID == "T01" ? 74 : 108;
                posY = 17;
                lineaImpresion.Add(AgregarUnaLinea(User.NombreTienda, posX, posY));
                lineaImpresion.Add(AgregarUnaLinea("DESGLOSE VENTAS CON TARJETA", 70, posY));

                posY = 44;
                posX = 2;
                lineaImpresion.Add(AgregarUnaLinea($"No. CIERRE: { reporteCierre.Cierre_Pos.Num_Cierre}", posX, posY));
                posY = 17;
                lineaImpresion.Add(AgregarUnaLinea($"CAJA: { reporteCierre.Cierre_Pos.Caja}", posX, posY));
                lineaImpresion.Add(AgregarUnaLinea($"CAJERO: { reporteCierre.Cierre_Pos.Cajero}", posX, posY));
                lineaImpresion.Add(AgregarUnaLinea(reporteCierre.Cierre_Pos.Nombre_Vendedor, posX + 50, posY));
                lineaImpresion.Add(AgregarUnaLinea($"FECHA: { reporteCierre.Cierre_Pos.Fecha_Hora.ToString("dd/MM/yyyy hh:mm:ss tt")}", posX, posY));

                //agrupar por el tipo de tarjeta 
                var tarjetasAgrupad = from d in reporteCierre.Cierre_Desg_Tarj
                                      group d by d.Tipo_Tarjeta into tabl_desglose
                                      select new
                                      {
                                          TipoTarjeta = tabl_desglose.Key,
                                          TotalMontoPorTarjeta = tabl_desglose.Sum(x => x.Monto),
                                          Cantidad = tabl_desglose.Count()
                                      };

                foreach (var x in tarjetasAgrupad)
                {
                    //obtengo el nombre de la tarjeta
                    var nombreTarjeta = x.TipoTarjeta;
                    var cantidad = x.Cantidad;
                    var totalMontoTarjet = x.TotalMontoPorTarjeta;

                    posY = 20;
                    lineaImpresion.Add(AgregarUnaLinea("_______________________________________________________________________________________________________", posX, posY));

                    //imprimo el nombre de la tarjeta                    
                    lineaImpresion.Add(AgregarUnaLinea($"TARJETA     {nombreTarjeta}", posX, posY));
                    posY = 20;
                    lineaImpresion.Add(AgregarUnaLinea("_______________________________________________________________________________________________________", posX, posY - 13));
                    posX = 2;
                    lineaImpresion.Add(AgregarUnaLinea("FACTURA", posX, posY, false));
                    lineaImpresion.Add(AgregarUnaLinea("MONTO", posX + 140, 0));


                    foreach (var item in reporteCierre.Cierre_Desg_Tarj)
                    {
                        //mostrar las facturas y monto de la tarjeta
                        if (item.Tipo_Tarjeta == nombreTarjeta)
                        {
                            //imprimir el numero de factura                            
                            lineaImpresion.Add(AgregarUnaLinea(item.Documento, posX, posY, false));
                            //imprimir el monto de la factura                           
                            lineaImpresion.Add(AgregarUnaLinea($"C$ {item.Monto.ToString("N2")}", posX + 140, 0));
                        }
                    }


                    lineaImpresion.Add(AgregarUnaLinea($"TOTAL         {nombreTarjeta}", posX, posY, false));
                    lineaImpresion.Add(AgregarUnaLinea($"C$ {totalMontoTarjet.ToString("N2")}", posX + 140, 0));
                }


                /***********************  DOCUMENTO DE AJUSTE******************************************************/
                if (reporteCierre.Cierre_Pos.Documento_Ajuste?.Length > 0)
                {
                    posX = 2;
                    //identificar si es tienda electrodomestico
                    posXtemp = User.TiendaID == "T01" ? 74 : 108;
                    posY = 200;
                    lineaImpresion.Add(AgregarUnaLinea(User.NombreTienda, posXtemp, posY));

                    posY = 20;
                    lineaImpresion.Add(AgregarUnaLinea("DOCUMENTO DE AJUSTE", 84, posY));
                    posY = 44;
                    lineaImpresion.Add(AgregarUnaLinea($"No. CIERRE: { reporteCierre.Cierre_Pos.Num_Cierre}", posX, posY));
                    posY = 17;
                    lineaImpresion.Add(AgregarUnaLinea($"CAJA: { reporteCierre.Cierre_Pos.Caja}", posX, posY));
                    lineaImpresion.Add(AgregarUnaLinea($"CAJERO: { reporteCierre.Cierre_Pos.Cajero}", posX, posY));
                    lineaImpresion.Add(AgregarUnaLinea(reporteCierre.Cierre_Pos.Nombre_Vendedor, posX + 50, posY));
                    lineaImpresion.Add(AgregarUnaLinea($"FECHA: { reporteCierre.Cierre_Pos.Fecha_Hora.ToString("dd/MM/yyyy hh:mm:ss tt")}", posX, posY));

                    posY = 20;
                    lineaImpresion.Add(AgregarUnaLinea("_______________________________________________________________________________________________________", posX, posY));

                    //imprimo el nombre de la tarjeta                    
                    lineaImpresion.Add(AgregarUnaLinea("MONTO DE DIFERENCIA", posX, posY, false));
                    lineaImpresion.Add(AgregarUnaLinea(reporteCierre.Cierre_Pos.Total_Diferencia.ToString("N2"), posX + 170, 0));
                    posY = 20;
                    lineaImpresion.Add(AgregarUnaLinea("_______________________________________________________________________________________________________", posX, posY - 13));
                }

                posX = 2;
                lineaImpresion.Add(AgregarUnaLinea(User.Demo, posX, posY+40));
                lineaImpresion.Add(AgregarUnaLinea("", posX, posY, true, false));

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return lineaImpresion;

        }

        private List<LineaImpresion> GenerarLineasReporteCierreCaja(ViewModelCierre reporteCierre)
        {
            int posX = 2;
            int posY = 2;            
            List<LineaImpresion> lineaImpresion = new List<LineaImpresion>();

            try
            {
                            

                lineaImpresion.Add(AgregarUnaLinea("EJERCITO DE NICARAGUA", 85, posY));
                //identificar si es tienda electrodomestico                
                posX = User.TiendaID == "T01" ? 74 : 108;
                posY = 17;
                lineaImpresion.Add(AgregarUnaLinea(User.NombreTienda, posX, posY));           
                posX = 2;
                //posY = 15;
                //e.Graphics.DrawString($"Tel.: {User.TelefonoTienda}", fuente, Brushes.Black, posX + 60, posY);
                lineaImpresion.Add(AgregarUnaLinea("CIERRE DE CAJA", 108, posY));
                posY = 44;
                lineaImpresion.Add(AgregarUnaLinea($"No. CIERRE: { reporteCierre.Cierre_Pos.Num_Cierre_Caja}", posX, posY));

                posY = 20;
                lineaImpresion.Add(AgregarUnaLinea($"CONSECUTIVO: { reporteCierre.DetalleFacturaCierreCaja[0].Documento}", posX, posY));
                lineaImpresion.Add(AgregarUnaLinea($"CAJA: { reporteCierre.Cierre_Pos.Caja}", posX, posY));
                lineaImpresion.Add(AgregarUnaLinea($"CAJERO: { reporteCierre.Cierre_Pos.Cajero}", posX, posY));

                lineaImpresion.Add(AgregarUnaLinea($"FECHA: {reporteCierre.Cierre_Pos.Fecha_Hora.ToString("dd/MM/yyyy")}", posX, posY));
                lineaImpresion.Add(AgregarUnaLinea($"HORA: { reporteCierre.Cierre_Pos.Fecha_Hora.ToString("hh:mm tt")}", posX, posY));

                //la factura Inicial
                var facturaInicial = reporteCierre.DetalleFacturaCierreCaja[0].Factura;
                var maxIndice = reporteCierre.DetalleFacturaCierreCaja.Count() - 1;
                var facturaFinal = reporteCierre.DetalleFacturaCierreCaja[maxIndice].Factura;

                lineaImpresion.Add(AgregarUnaLinea($"FACTURA INICIAL: {facturaInicial}", posX, posY));
                lineaImpresion.Add(AgregarUnaLinea($"FACTURA FINAL: {facturaFinal}", posX, posY));

                posY = 25;
                lineaImpresion.Add(AgregarUnaLinea("DOCUMENTO", posX, posY));
                posY = 25;
                lineaImpresion.Add(AgregarUnaLinea("FACTURA", posX, posY));

                posY = 25;
                posX = 2;
                lineaImpresion.Add(AgregarUnaLinea("DOCUMENTO", posX, posY, false));

                //posY = 17;
                posX += 70;
                lineaImpresion.Add(AgregarUnaLinea("SUBTOTAL", posX, 0, false));

                posX += 70;
                lineaImpresion.Add(AgregarUnaLinea("IVA", posX, 0, false));

                posX += 70;
                lineaImpresion.Add(AgregarUnaLinea("TOTAL", posX, 0));
                                    

                foreach (var item in reporteCierre.DetalleFacturaCierreCaja)
                {
                    posY = 17;
                    posX = 2;
                    lineaImpresion.Add(AgregarUnaLinea(item.Factura, posX, posY, false));

                    //posY = 17;
                    posX += 70;
                    lineaImpresion.Add(AgregarUnaLinea($"C$ {item.SubTotal.ToString("N2")}", posX, 0, false));
                    
                    posX +=70;                                        
                    lineaImpresion.Add(AgregarUnaLinea($"C$ {item.Impuesto.ToString("N2")}", posX, 0, false));

                    posX += 70;
                    lineaImpresion.Add(AgregarUnaLinea($"C$ { item.TotalPagar.ToString("N2")}", posX, 0));                                                       
                }

                posX =2;
                posY = 40;
                lineaImpresion.Add(AgregarUnaLinea("TOTALES DEL DIA", posX, posY));

                /***************************subtotal***********************************/
                posX = 2;
                posY = 20;
                lineaImpresion.Add(AgregarUnaLinea("SUBTOTAL:", posX, posY, false));               
                var sumaSubTotal = reporteCierre.DetalleFacturaCierreCaja.Sum(x => x.SubTotal);
                posX += 160;
                lineaImpresion.Add(AgregarUnaLinea($"C$ { sumaSubTotal.ToString("N2")}", posX, 0));


                /***************************descuentos***********************************/
                posX = 2;
                posY = 20;
                lineaImpresion.Add(AgregarUnaLinea("DESCUENTOS:", posX, posY, false));
                var sumaDescuento = reporteCierre.DetalleFacturaCierreCaja.Sum(x => x.Descuento);
                posX += 160;
                lineaImpresion.Add(AgregarUnaLinea($"C$ {sumaDescuento.ToString("N2")}", posX, 0));

                posX = 2;
                posY = 10;
                lineaImpresion.Add(AgregarUnaLinea("_____________________________________________________________________________________", posX, posY));

                /***************************suma subtotal - descuentos ***********************************/
                posX = 2;
                posY = 20;
                lineaImpresion.Add(AgregarUnaLinea("SUBTOTAL DESCONTADO:", posX, posY, false));             
                posX += 160;
                lineaImpresion.Add(AgregarUnaLinea($"C$ {(sumaSubTotal - sumaDescuento).ToString("N2")}", posX, 0));

                posX = 2;
                posY = 20;
                lineaImpresion.Add(AgregarUnaLinea("IVA:", posX, posY, false));
                posX += 160;
                lineaImpresion.Add(AgregarUnaLinea($"C$ {(0.00M).ToString("N2")}", posX, 0));

                var sumaRetencion= reporteCierre.DetalleFacturaCierreCaja.Sum(x => x.MontoRetencion);

                posX = 2;
                posY = 20;
                lineaImpresion.Add(AgregarUnaLinea("RETENCION:", posX, posY, false));
                posX += 160;
                lineaImpresion.Add(AgregarUnaLinea($"C$ {sumaRetencion.ToString("N2")}", posX, 0));
                posX = 2;
                posY = 10;
                lineaImpresion.Add(AgregarUnaLinea("_____________________________________________________________________________________", posX, posY));

                posX = 2;
                posY = 20;
                lineaImpresion.Add(AgregarUnaLinea("TOTAL:", posX, posY, false));
                posX += 160;
                lineaImpresion.Add(AgregarUnaLinea($"C$ {(sumaSubTotal - sumaDescuento - sumaRetencion).ToString("N2")}", posX, 0));


                posX = 2;
                posY = 40;
                lineaImpresion.Add(AgregarUnaLinea("DETALLE DE CAJA", posX, posY, false));

                foreach (var item in reporteCierre.Cierre_Det_Pago)
                {
                    posY = 25;
                    posX = 2;
                    lineaImpresion.Add(AgregarUnaLinea(item.Tipo_Pago, posX, posY, false));
                    posX += 170;
                    lineaImpresion.Add(AgregarUnaLinea(item.Moneda == "L" ? $"C$ {item.Total_Sistema.ToString("N2")}" : $"U$ {item.Total_Sistema.ToString("N2")}", posX, 0));

                    posY = 17;
                    posX = 2;
                    lineaImpresion.Add(AgregarUnaLinea("REGISTRO USUARIO", posX + 10, posY, false));
                    posX += 170;
                    lineaImpresion.Add(AgregarUnaLinea(item.Moneda == "L" ? $"C$ {item.Total_Usuario.ToString("N2")}" : $"U$ {item.Total_Usuario.ToString("N2")}", posX, 0));


                    posX = 2;
                    lineaImpresion.Add(AgregarUnaLinea("DIFERENCIA", posX + 10, posY, false));
                    posX += 170;
                    lineaImpresion.Add(AgregarUnaLinea(item.Moneda == "L" ? $"C$ {item.Diferencia.ToString("N2")}" : $"U$ {item.Diferencia.ToString("N2")}", posX, 0));
                }


         

                //agrupar por el tipo de tarjeta 
                var tarjetasAgrupad = from d in reporteCierre.Cierre_Desg_Tarj
                                      group d by d.Tipo_Tarjeta into tabl_desglose
                                      select new
                                      {
                                          TipoTarjeta = tabl_desglose.Key,
                                          TotalMontoPorTarjeta = tabl_desglose.Sum(x => x.Monto),
                                          Cantidad = tabl_desglose.Count()
                                      };


                posX = 2;
                posY = 40;
                lineaImpresion.Add(AgregarUnaLinea("DETALLE DE TARJETA", posX, posY, false));

                posX = 2;
                lineaImpresion.Add(AgregarUnaLinea("TARJETA", posX, posY, false));
                lineaImpresion.Add(AgregarUnaLinea("MONTO", posX + 170, 0));
                posY = 20;
                lineaImpresion.Add(AgregarUnaLinea("_______________________________________________________________________________________________________", posX, posY - 13));

                foreach (var x in tarjetasAgrupad)
                {
                    //obtengo el nombre de la tarjeta
                    var nombreTarjeta = x.TipoTarjeta;
                    var cantidad = x.Cantidad;
                    var totalMontoTarjet = x.TotalMontoPorTarjeta;

                    posY = 20;                    
       
                    lineaImpresion.Add(AgregarUnaLinea(nombreTarjeta, posX, posY, false));                    
                    lineaImpresion.Add(AgregarUnaLinea($"C$ {totalMontoTarjet.ToString("N2")}", posX + 170, 0));
                }


                /***********************  DOCUMENTO DE AJUSTE******************************************************/

                if (reporteCierre.Cierre_Pos.Documento_Ajuste?.Length > 0)
                {
                    posX = 2;                
                    posY = 40;
                    lineaImpresion.Add(AgregarUnaLinea("DETALLE DE AJUSTES", posX, posY));              
                    posY = 20;                                        
                    lineaImpresion.Add(AgregarUnaLinea("DOCUMENTO", posX, posY, false));
                    lineaImpresion.Add(AgregarUnaLinea("AJUSTE", posX + 170, 0));
                    posY = 20;
                    lineaImpresion.Add(AgregarUnaLinea("_______________________________________________________________________________________________________", posX, posY - 13));

                    posY = 20;
                    lineaImpresion.Add(AgregarUnaLinea(reporteCierre.Cierre_Pos.Documento_Ajuste, posX, posY, false));
                    lineaImpresion.Add(AgregarUnaLinea($"C$ {reporteCierre.Cierre_Pos.Total_Diferencia.ToString("N2")}", posX + 170, 0));                   
                }

                posY = 40;
                lineaImpresion.Add(AgregarUnaLinea("CIERRE:", posX, posY, false));
                lineaImpresion.Add(AgregarUnaLinea(reporteCierre.Cierre_Pos.Num_Cierre, posX + 170, 0));







                //posY = 20;
                //lineaImpresion.Add(AgregarUnaLinea("_______________________________________________________________________________________________________", posX, posY));








                //lineaImpresion.Add(AgregarUnaLinea("TOTAL CORDOBAS EN CAJA: ", posX, posY, false));
                //posX += 170;
                //lineaImpresion.Add(AgregarUnaLinea($"C$ {reporteCierre.Cierre_Pos.Total_Local.ToString("N2")}", posX, 0));

                //posX = 2;
                //posY = 17;
                //lineaImpresion.Add(AgregarUnaLinea("TOTAL DOLAR EN CAJA: ", posX, posY, false));
                //posX += 170;
                //lineaImpresion.Add(AgregarUnaLinea($"U$ {reporteCierre.Cierre_Pos.Total_Dolar.ToString("N2")}", posX, 0));

                //posX = 2;
                //lineaImpresion.Add(AgregarUnaLinea("MONTO APERTURA: ", posX, posY, false));
                //posX += 170;
                //lineaImpresion.Add(AgregarUnaLinea($"C$ {reporteCierre.Cierre_Pos.Monto_Apertura.ToString("N2")}", posX, 0));

                //posX = 2;
                //lineaImpresion.Add(AgregarUnaLinea("COBRO EFECTIVO CORDOBAS: ", posX, posY, false));
                //posX += 170;
                //lineaImpresion.Add(AgregarUnaLinea($"C$ {reporteCierre.Cierre_Pos.Ventas_Efectivo.ToString("N2")}", posX, 0));

                //posX = 2;
                //lineaImpresion.Add(AgregarUnaLinea("COBRO EFECTIVO DOLAR: ", posX, posY, false));
                //posX += 170;
                //lineaImpresion.Add(AgregarUnaLinea($"C$ {reporteCierre.Cierre_Pos.Cobro_Efectivo_Rep.ToString("N2")}", posX, 0));

                //foreach (var item in reporteCierre.Cierre_Det_Pago)
                //{
                //    posY = 25;
                //    posX = 2;
                //    lineaImpresion.Add(AgregarUnaLinea(item.Tipo_Pago, posX, posY, false));
                //    posX += 170;
                //    lineaImpresion.Add(AgregarUnaLinea(item.Moneda == "L" ? $"C$ {item.Total_Sistema.ToString("N2")}" : $"U$ {item.Total_Sistema.ToString("N2")}", posX, 0));

                //    posY = 17;
                //    posX = 2;
                //    lineaImpresion.Add(AgregarUnaLinea("REPORTADO", posX + 10, posY, false));
                //    posX += 170;
                //    lineaImpresion.Add(AgregarUnaLinea(item.Moneda == "L" ? $"C$ {item.Total_Usuario.ToString("N2")}" : $"U$ {item.Total_Usuario.ToString("N2")}", posX, 0));


                //    posX = 2;
                //    lineaImpresion.Add(AgregarUnaLinea("DIFERENCIA", posX + 10, posY, false));
                //    posX += 170;
                //    lineaImpresion.Add(AgregarUnaLinea(item.Moneda == "L" ? $"C$ {item.Diferencia.ToString("N2")}" : $"U$ {item.Diferencia.ToString("N2")}", posX, 0));
                //}

                //posX = 2;
                //posY = 10;
                //lineaImpresion.Add(AgregarUnaLinea("_____________________________________________________________________________________", posX, posY));


                //posX = 2;
                //posY = 17;
                //lineaImpresion.Add(AgregarUnaLinea("TOTAL DIFERENCIA:", posX, posY, false));

                //posX += 170;
                //lineaImpresion.Add(AgregarUnaLinea($"C$ {reporteCierre.Cierre_Pos.Total_Diferencia.ToString("N2")}", posX, 0));


                //if (reporteCierre.Cierre_Pos.Documento_Ajuste?.Length > 0)
                //{
                //    posX = 2;
                //    lineaImpresion.Add(AgregarUnaLinea("DOCUMENTO AJUSTE:", posX, posY, false));
                //    posX += 140;
                //    lineaImpresion.Add(AgregarUnaLinea(reporteCierre.Cierre_Pos.Documento_Ajuste, posX, 0));
                //}


                //posX = 2;
                //lineaImpresion.Add(AgregarUnaLinea("NOTAS:", posX, posY));

                //posY = 20;
                //lineaImpresion.Add(AgregarUnaLinea(reporteCierre.Cierre_Pos.Notas, posX, posY));

                ////posY = 200;                
                //lineaImpresion.Add(AgregarUnaLinea("", posX, posY));


                //posX = 2;
                ////identificar si es tienda electrodomestico
                //posXtemp = User.TiendaID == "T01" ? 84 : 108;
                //posY = 17;
                //lineaImpresion.Add(AgregarUnaLinea(User.NombreTienda, posXtemp, posY));

                //posY = 20;
                //lineaImpresion.Add(AgregarUnaLinea("DESGLOSE VENTAS CON TARJETA", posX + 70, posY));

                //posY = 44;
                //lineaImpresion.Add(AgregarUnaLinea($"No. CIERRE: { reporteCierre.Cierre_Pos.Num_Cierre}", posX, posY));
                //posY = 17;
                //lineaImpresion.Add(AgregarUnaLinea($"CAJA: { reporteCierre.Cierre_Pos.Caja}", posX, posY));
                //lineaImpresion.Add(AgregarUnaLinea($"CAJERO: { reporteCierre.Cierre_Pos.Cajero}", posX, posY));
                //lineaImpresion.Add(AgregarUnaLinea(reporteCierre.Cierre_Pos.Nombre_Vendedor, posX + 50, posY));
                //lineaImpresion.Add(AgregarUnaLinea($"FECHA: { reporteCierre.Cierre_Pos.Fecha_Hora.ToString("dd/MM/yyyy hh:mm:ss tt")}", posX, posY));

                ////agrupar por el tipo de tarjeta 
                //var tarjetasAgrupad = from d in reporteCierre.Cierre_Desg_Tarj
                //                      group d by d.Tipo_Tarjeta into tabl_desglose
                //                      select new
                //                      {
                //                          TipoTarjeta = tabl_desglose.Key,
                //                          TotalMontoPorTarjeta = tabl_desglose.Sum(x => x.Monto),
                //                          Cantidad = tabl_desglose.Count()
                //                      };

                //foreach (var x in tarjetasAgrupad)
                //{
                //    //obtengo el nombre de la tarjeta
                //    var nombreTarjeta = x.TipoTarjeta;
                //    var cantidad = x.Cantidad;
                //    var totalMontoTarjet = x.TotalMontoPorTarjeta;

                //    posY = 20;
                //    lineaImpresion.Add(AgregarUnaLinea("_______________________________________________________________________________________________________", posX, posY));

                //    //imprimo el nombre de la tarjeta                    
                //    lineaImpresion.Add(AgregarUnaLinea($"TARJETA     {nombreTarjeta}", posX, posY));
                //    posY = 20;
                //    lineaImpresion.Add(AgregarUnaLinea("_______________________________________________________________________________________________________", posX, posY - 13));
                //    posX = 2;
                //    lineaImpresion.Add(AgregarUnaLinea("FACTURA", posX, posY, false));
                //    lineaImpresion.Add(AgregarUnaLinea("MONTO", posX + 140, 0));


                //    foreach (var item in reporteCierre.Cierre_Desg_Tarj)
                //    {
                //        //mostrar las facturas y monto de la tarjeta
                //        if (item.Tipo_Tarjeta == nombreTarjeta)
                //        {
                //            //imprimir el numero de factura                            
                //            lineaImpresion.Add(AgregarUnaLinea(item.Documento, posX, posY, false));
                //            //imprimir el monto de la factura                           
                //            lineaImpresion.Add(AgregarUnaLinea(item.Monto.ToString("N2"), posX + 140, 0));
                //        }
                //    }


                //    lineaImpresion.Add(AgregarUnaLinea($"TOTAL         {nombreTarjeta}", posX, posY, false));
                //    lineaImpresion.Add(AgregarUnaLinea(totalMontoTarjet.ToString("N2"), posX + 140, 0));

                //}


                ///***********************  DOCUMENTO DE AJUSTE******************************************************/

                //if (reporteCierre.Cierre_Pos.Documento_Ajuste?.Length > 0)
                //{
                //    posX = 2;
                //    //identificar si es tienda electrodomestico
                //    posXtemp = User.TiendaID == "T01" ? 84 : 108;
                //    posY = 200;
                //    lineaImpresion.Add(AgregarUnaLinea(User.NombreTienda, posXtemp, posY));

                //    posY = 20;
                //    lineaImpresion.Add(AgregarUnaLinea("DOCUMENTO DE AJUSTE", 84, posY));
                //    posY = 44;
                //    lineaImpresion.Add(AgregarUnaLinea($"No. CIERRE: { reporteCierre.Cierre_Pos.Num_Cierre}", posX, posY));
                //    posY = 17;
                //    lineaImpresion.Add(AgregarUnaLinea($"CAJA: { reporteCierre.Cierre_Pos.Caja}", posX, posY));
                //    lineaImpresion.Add(AgregarUnaLinea($"CAJERO: { reporteCierre.Cierre_Pos.Cajero}", posX, posY));
                //    lineaImpresion.Add(AgregarUnaLinea(reporteCierre.Cierre_Pos.Nombre_Vendedor, posX + 50, posY));
                //    lineaImpresion.Add(AgregarUnaLinea($"FECHA: { reporteCierre.Cierre_Pos.Fecha_Hora.ToString("dd/MM/yyyy hh:mm:ss tt")}", posX, posY));

                //    posY = 20;
                //    lineaImpresion.Add(AgregarUnaLinea("_______________________________________________________________________________________________________", posX, posY));

                //    //imprimo el nombre de la tarjeta                    
                //    lineaImpresion.Add(AgregarUnaLinea("MONTO DE DIFERENCIA", posX, posY, false));
                //    lineaImpresion.Add(AgregarUnaLinea(reporteCierre.Cierre_Pos.Total_Diferencia.ToString("N2"), posX + 170, 0));
                //    posY = 20;
                //    lineaImpresion.Add(AgregarUnaLinea("_______________________________________________________________________________________________________", posX, posY - 13));
                //}


                posX = 2;
                lineaImpresion.Add(AgregarUnaLinea(User.Demo, posX, posY + 40));

                lineaImpresion.Add(AgregarUnaLinea("", posX, posY, true, false));

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return lineaImpresion;

        }

        public void ImprimirReporteCierreCajero(ViewModelCierre reporteCierre)
        {            
            //Generar las Lineas de la factura
            lineaImp = new List<LineaImpresion>();
            lineaImp = GenerarLineasReporteCierreCajero(reporteCierre);
            //lineaImp = GenerarLineasEncabezado(reporteCierre);
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

        public void ImprimirReporteCierreCaja(ViewModelCierre reporteCierre)
        {
            //Generar las Lineas de la factura
            lineaImp = new List<LineaImpresion>();
            lineaImp = GenerarLineasReporteCierreCaja(reporteCierre);
            //lineaImp = GenerarLineasEncabezado(reporteCierre);
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
            bool saltoProxLinea = false;
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

                ev.Graphics.DrawString(line, printFont, Brushes.Black, xPos, yPos, new StringFormat());
                tieneMasLinea = lineaImp[index].TieneMasLinea;

                if (!saltoProxLinea) row++;
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
