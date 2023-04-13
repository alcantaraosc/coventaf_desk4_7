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

namespace COVENTAF.Services
{
    public class FuncionDevolucion
    {
        private PrintDocument doc = new PrintDocument();
        private PrintPreviewDialog vista = new PrintPreviewDialog();
        // Construct the PrintPreviewControl.
        PrintPreviewControl PrintPreviewControl1 = new PrintPreviewControl();
        private ViewModelDevolucion _modelDevolucion;

        public void ImprimirTicketDevolucion(ViewModelDevolucion viewModelDevolucion)
        {
            this._modelDevolucion = viewModelDevolucion;
            _modelDevolucion.TicketFactura = viewModelDevolucion.TicketFactura;
            _modelDevolucion.TicketFacturaLineas = viewModelDevolucion.TicketFacturaLineas;
            //this._listMetodoPago = new List<ViewMetodoPago>();
            //this._listDetFactura = listDetFactura;
            //this._listMetodoPago = viewModelMetodoPago;
            //this._encabezadoFact = new Encabezado();
            //this._encabezadoFact = encabezadoFact;

            doc.PrinterSettings.PrinterName = doc.DefaultPageSettings.PrinterSettings.PrinterName;

            doc.PrintPage += new PrintPageEventHandler(ImprimirDevolucion);
            // Set the zoom to 25 percent.
            //this.PrintPreviewControl1.Zoom = 0.25;            
            //vista.Controls.Add(this.PrintPreviewControl1);

            vista.Document = doc;
            //doc.Print();
            vista.ShowDialog();
        }



        public void ImprimirDevolucion(object sender, PrintPageEventArgs e)
        {

            //en una linea son 40 caracteres.


            int posX = 0, posY = 0;
            //Font fuente = new Font("consola", 8, FontStyle.Bold);
            //Font fuenteRegular = new Font("consola", 8, FontStyle.Regular);
            //Font fuenteRegular_7 = new Font("consola", 7, FontStyle.Regular);
            //Courier
            Font fuente = new Font("Bahnschrift Light Condensed", 11, FontStyle.Regular);
            Font fuenteRegular = new Font("Bahnschrift Light Condensed", 11, FontStyle.Regular);
            Font fuenteRegular_7 = new Font("Bahnschrift Light Condensed", 11, FontStyle.Regular);
         
            var sfCenter = new StringFormat()
            {
                Alignment = StringAlignment.Near,
                LineAlignment = StringAlignment.Center
            };

            StringFormat sf = new StringFormat();
            sf.LineAlignment = StringAlignment.Center;
            sf.Alignment = StringAlignment.Center;


            try
            {
                posX = 2;
                e.Graphics.DrawString("EJERCITO DE NICARAGUA", fuente, Brushes.Black, posX + 53, posY);               
                posY += 15;
                //TIENDA ELECTRODOMESTICO
                if (User.TiendaID == "T01")
                {
                    e.Graphics.DrawString(User.NombreTienda, fuente, Brushes.Black, posX + 45, posY);
                }
                else
                {
                    e.Graphics.DrawString(User.NombreTienda, fuente, Brushes.Black, posX + 80, posY);
                }

                //ImprimirPorReferenciaCaracter(ref e, User.DireccionTienda, fuente, ref posX, 20, ref posY, 15);


                //posY += 15;
                //e.Graphics.DrawString($"Tel.: {User.TelefonoTienda}", fuente, Brushes.Black, posX + 60, posY);

                //posY += 15;
                //e.Graphics.DrawString("N° RUC: J1330000001272", fuente, Brushes.Black, posX + 55, posY);

                ////factura
                posY += 24;
                e.Graphics.DrawString("Devolución No: " + _modelDevolucion.TicketFactura.NoDevolucion, fuenteRegular, Brushes.Black, posX, posY);
                posY += 15;
                e.Graphics.DrawString("Fecha: " + _modelDevolucion.TicketFactura.FechaDevolucion, fuenteRegular, Brushes.Black, posX, posY);
                posY += 15;
                e.Graphics.DrawString("Caja: " + _modelDevolucion.TicketFactura.Caja, fuenteRegular, Brushes.Black, posX, posY);
                posY += 15;
                e.Graphics.DrawString("Bodega: " + _modelDevolucion.TicketFactura.BodegaId, fuenteRegular, Brushes.Black, posX, posY);
                posY += 15;
                e.Graphics.DrawString( _modelDevolucion.TicketFactura.NombreBodega, fuenteRegular, Brushes.Black, posX, posY);
                posY += 15;
                e.Graphics.DrawString("Cliente: " + _modelDevolucion.TicketFactura.Cliente, fuenteRegular, Brushes.Black, posX, posY);
                posY += 15;
                e.Graphics.DrawString(_modelDevolucion.TicketFactura.NombreCliente, fuenteRegular, Brushes.Black, posX, posY);
                posY += 30;
                e.Graphics.DrawString("*** VALE ***", new Font("Courier", 11, FontStyle.Bold), Brushes.Black, posX+90, posY);
                posY += 25;
                e.Graphics.DrawString("Fecha Vencimiento: " + _modelDevolucion.TicketFactura.FechaVencimiento, fuenteRegular, Brushes.Black, posX, posY);
                posY += 15;
                e.Graphics.DrawString("Saldo Restante: " + _modelDevolucion.TicketFactura.SaldoRestante, fuenteRegular, Brushes.Black, posX, posY);
                posY += 15;
                e.Graphics.DrawString("Fact. Devuelta: " + _modelDevolucion.TicketFactura.FacturaDevuelta, fuenteRegular, Brushes.Black, posX, posY);

                posY += 15;
                e.Graphics.DrawString("Caja Devolucion: " + _modelDevolucion.TicketFactura.CajaDevolucion, fuenteRegular, Brushes.Black, posX, posY);

                posY += 18;
                e.Graphics.DrawString("-------------------------------------------------------------------------", fuente, Brushes.Black, posX, posY);                
                posY += 10;
                e.Graphics.DrawString("Codigo", fuente, Brushes.Black, posX, posY);
                //posY += 15;
                posX += 90;
                e.Graphics.DrawString("Cant.", fuente, Brushes.Black, posX, posY);
                //posY += 15;
                //posX += 50;
                //e.Graphics.DrawString("Precio", fuente, Brushes.Black, posX, posY);
                //// posY += 15;
                //posX += 60;
                //e.Graphics.DrawString("Desc", fuente, Brushes.Black, posX, posY);
                //posY += 15;
                posX += 110;
                e.Graphics.DrawString("Monto", fuente, Brushes.Black, posX, posY);
                posY += 10;
                //reiniciar la posicionX
                posX = 2;
                e.Graphics.DrawString("-------------------------------------------------------------------------", fuente, Brushes.Black, posX, posY);
                

                foreach (var detalleFactura in _modelDevolucion.TicketFacturaLineas)
                {
                    posY += 10;
                    e.Graphics.DrawString(detalleFactura.Articulo, fuenteRegular, Brushes.Black, posX, posY);

                    posX += 90;
                    e.Graphics.DrawString(detalleFactura.Cantidad.ToString("N2"), fuenteRegular, Brushes.Black, posX, posY);

                    //posX += 50;
                    //e.Graphics.DrawString(detalleFactura.Precio.ToString("N2"), fuenteRegular, Brushes.Black, posX, posY);

                    //posX += 60;
                    //e.Graphics.DrawString(Convert.ToDecimal(detalleFactura.DescuentoLinea).ToString("N2"), fuenteRegular, Brushes.Black, posX, posY);

                    posX += 100;
                    e.Graphics.DrawString(detalleFactura.TotalLinea.ToString("N2"), fuenteRegular, Brushes.Black, posX, posY);

                    //salto a la siguiente linea
                    posY += 15;
                    posX = 2;
                    e.Graphics.DrawString(detalleFactura.Descripcion, fuenteRegular_7, Brushes.Black, posX, posY);

                    posY += 15;

                }

                posY += 5;
                e.Graphics.DrawString("-------------------------------------------------------------------------", fuente, Brushes.Black, posX, posY);

                posY += 15;                
                posX = 80;
                e.Graphics.DrawString("Sub Total:", fuente, Brushes.Black, posX, posY);


                posX += 100;
                e.Graphics.DrawString("C$ " + _modelDevolucion.TicketFactura.SubTotal.ToString("N2"), fuenteRegular, Brushes.Black, posX, posY);

                posY += 15;
                posX = 80;
                e.Graphics.DrawString("Desc. Linea:", fuente, Brushes.Black, posX, posY);

                posX += 100;
                e.Graphics.DrawString("C$ " + _modelDevolucion.TicketFactura.DescuentoLinea.ToString("N2"), fuenteRegular, Brushes.Black, posX, posY);


                posY += 15;                
                posX = 80;
                e.Graphics.DrawString("Desc. Gen:", fuente, Brushes.Black, posX, posY);

                posX += 100;
                e.Graphics.DrawString("C$ " + _modelDevolucion.TicketFactura.DescuentoGeneral.ToString("N2"), fuenteRegular, Brushes.Black, posX, posY);

                ///************************* RETENCIONES ************************************************************************/
                //if (_encabezadoFact.MontoRetencion > 0)
                //{
                //    posY += 15;
                //    posX = 2;
                //    posX += 140;
                //    e.Graphics.DrawString("Retencion:", fuente, Brushes.Black, posX, posY);

                //    posX += 65;
                //    e.Graphics.DrawString("C$ " + _encabezadoFact.MontoRetencion.ToString("N2"), fuenteRegular, Brushes.Black, posX, posY);
                //}
                ///****************************************************************************************************************/


                posY += 15;
                posX = 80;
                e.Graphics.DrawString("IVA:", fuente, Brushes.Black, posX, posY);

                posX += 100;
                e.Graphics.DrawString("C$ " + _modelDevolucion.TicketFactura.IVA.ToString("N2"), fuenteRegular, Brushes.Black, posX, posY);

                posY += 30;                
                posX = 80;
                e.Graphics.DrawString("Total:", fuente, Brushes.Black, posX, posY);

                posX += 100;
                e.Graphics.DrawString("C$ " + _modelDevolucion.TicketFactura.Total.ToString("N2"), fuenteRegular, Brushes.Black, posX, posY);


                posY += 15;                
                posX = 80;
                e.Graphics.DrawString("Vale:", fuente, Brushes.Black, posX, posY);

                posX += 100;
                e.Graphics.DrawString("C$ " + _modelDevolucion.TicketFactura.Vale.ToString("N2"), fuenteRegular, Brushes.Black, posX, posY);


                posX = 2;
                e.Graphics.DrawString(User.Demo, fuenteRegular, Brushes.Black, posX, posY + 40);

                posY += 200;
                posX = 120;
                e.Graphics.DrawString("*******", fuenteRegular, Brushes.Black, posX, posY);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


    }
}
