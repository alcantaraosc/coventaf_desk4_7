using Api.Model.Modelos;
using Api.Model.ViewModels;
using Api.Service.DataService;
using COVENTAF.Metodos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COVENTAF.PuntoVenta
{
    public partial class frmPreLectura : Form
    {
        //esta variable guardar true si se guardo correctamente el cierre de caja
        public bool CierreCajaExitosamente = false;
        //solo efectivo en Cordobas
        private decimal EfectivoCordoba = 0.00M;
        //solo efectivo Doloar
        private decimal EfectivoDolar=0.00M;
        //monto de apertura esta en la tabla Cierre_Pos
        private decimal montoApertura = 0.00M;
        //ventasEfectivo = es la suma de EfectivoCordoba + EfectivoDolar(Primero convertirlo en cordoba al tipo cambio que dice la tabla Cierre_Pos y usando 2 decimales ej.: 36.29)
        private decimal ventasEfectivo = 0.00M;
        
        ServiceCaja_Pos _serviceCajaPos;
        List<DetallesCierreCaja> _datosCierreCaja ;
        VariableCierreCaja _listVarCierreCaja = new VariableCierreCaja();
        Cierre_Pos cierre_Pos;
 

        private PrintDocument doc = new PrintDocument();
        private PrintPreviewDialog vista = new PrintPreviewDialog();
        // Construct the PrintPreviewControl.
        PrintPreviewControl PrintPreviewControl1 = new PrintPreviewControl();


        #region codigo para mover pantalla
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        #endregion

        public frmPreLectura()
        {
            InitializeComponent();
            _serviceCajaPos = new ServiceCaja_Pos();
        }

        private void barraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void frmPreLectura_Load(object sender, EventArgs e)
        {            
            try
            {
                if (User.ConsecCierreCT.Length != 0)
                {
                    //
                    PrepararPrelectura(User.Caja, User.Usuario, User.ConsecCierreCT);
                }
                else
                {
                    MessageBox.Show("No existe el numero de cierre para el cajero", "Sistema COVENTAF");
                    this.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Sistema COVENTAF");
            }



            this.lblTitulo.Text = $"Prelectura de Caja: {User.Caja}.";
            this.lblNoCierre.Text = $"No. Cierre: {User.ConsecCierreCT}";            
        }



        public async void PrepararPrelectura(string caja, string cajero, string numeroCierre)
        {
            this.Cursor = Cursors.WaitCursor;

            ResponseModel responseModel = new ResponseModel();
            _datosCierreCaja = new List<DetallesCierreCaja>();

            try
            {
                _datosCierreCaja = await _serviceCajaPos.ObtenerDatosParaCierreCaja(caja, cajero, numeroCierre, responseModel);
                if (responseModel.Exito == 1)
                {
                    //llenar el grid reportado por el sistema
                    LlenarGridReportadoXSistema(_datosCierreCaja);                   
                }
                else
                {
                    MessageBox.Show(responseModel.Mensaje, "Sistema COVENTAF");
                }
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show(ex.Message);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
           
        }

        private void LlenarGridReportadoXSistema(List<DetallesCierreCaja> _datosCierreCaja)
        {
            _listVarCierreCaja.TotalCordoba = 0.00M;
            _listVarCierreCaja.TotalDolar = 0.00M;
            _listVarCierreCaja.VentaEfectivoCordoba = 0.00M;
            _listVarCierreCaja.VentaEfectivoDolar = 0.00M;

            foreach (var itemSistema in _datosCierreCaja)
            {

                this.dgvGridReportadoPorSistema.Rows.Add(itemSistema.Id, itemSistema.Descripcion,
                    (itemSistema.Moneda == "L" ? $"C$ {itemSistema.Monto.ToString("N2")}" : $"U$ {itemSistema.Monto.ToString("N2")}"),
                    itemSistema.Moneda);
                //comprobar si la moneda es Local =L (C$)
                if (itemSistema.Moneda == "L")
                {
                    _listVarCierreCaja.TotalCordoba += itemSistema.Monto;
                }
                //comprobar si la moneda es Dolar =D (U$)
                else if (itemSistema.Moneda == "D")
                {
                    _listVarCierreCaja.TotalDolar += itemSistema.Monto;
                }

                //comprobar si existe forma de pago 0001=Efectivo cordoba
                if (itemSistema.Forma_Pago == "0001" && itemSistema.Moneda == "L")
                {
                    //Efectivo Cordobas = Efectivo Local
                    EfectivoCordoba += itemSistema.Monto;
                    _listVarCierreCaja.VentaEfectivoCordoba += itemSistema.Monto;
                }
                //comprobar si existe forma de pago 0001=Efectivo dolar
                if (itemSistema.Forma_Pago == "0001" && itemSistema.Moneda == "D")
                {
                    EfectivoDolar += itemSistema.Monto;
                    _listVarCierreCaja.VentaEfectivoDolar += itemSistema.Monto;
                }
            }

            //this.txtTotalCordobasSistema.Text = _listVarCierreCaja.TotalCordoba.ToString("N2");
            //this.txtTotalDolaresSistema.Text = _listVarCierreCaja.TotalDolar.ToString("N2");

        }




        private async void btnImprimir_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            cierre_Pos = null;
            cierre_Pos = new Cierre_Pos();

            ResponseModel responseModel = new ResponseModel();

            try
            {
                //aqui es oscar
                responseModel = await _serviceCajaPos.ObtenerCierrePos(User.Caja, User.Usuario, User.ConsecCierreCT, responseModel);
                if (responseModel.Exito == 1)
                {

                    cierre_Pos = responseModel.Data as Cierre_Pos;
                    //veri
                    if (cierre_Pos.Estado == "C")
                    {
                                             
                        MessageBox.Show("No se puede imprimir, el estado del Cierre está cerrado", "Sistema COVENTAF");                       
                    }                    
                    else
                    {
                        montoApertura = cierre_Pos.Monto_Apertura;
                        //restar el monto de la apertura, ya que en la consulta que se genera la iniciar el form obtengo sumando el monto de apertura.
                        EfectivoCordoba = EfectivoCordoba - montoApertura;
                       // cierre_Pos.Tipo_Cambio = Utilidades.RoundApproximate(cierre_Pos.Tipo_Cambio, 2);
                        //var calculoEfectivoDolar_Cordoba = EfectivoDolar * cierre_Pos.Tipo_Cambio;
                        //ventasEfectivo = EfectivoCordoba + calculoEfectivoDolar_Cordoba;

                        //                          Efectivo Cordoba + Efectivo en Dolar al tipo de cambio de la tabla cierre_Pos usando 4 decimales                        
                        ventasEfectivo = UtilidadesMain.RoundApproximate(EfectivoCordoba + (EfectivoDolar * UtilidadesMain.RoundApproximate(cierre_Pos.Tipo_Cambio, 2)), 2);

                        //Thread hilo = new Thread(new ThreadStart(this.CargarDatosHilo));
                        //hilo.Start();

                        doc.PrinterSettings.PrinterName = doc.DefaultPageSettings.PrinterSettings.PrinterName;

                        doc.PrintPage += new PrintPageEventHandler(ImprimirPreLectura);
                        // Set the zoom to 25 percent.
                        //this.PrintPreviewControl1.Zoom = 0.25;            
                        //vista.Controls.Add(this.PrintPreviewControl1);

                        vista.Document = doc;
                     

                        if (User.VistaPrevia)
                        {
                            vista.ShowDialog();
                        }
                        else
                        {
                            doc.Print();
                        }
                    }

                }
                else
                {                    
                    MessageBox.Show("COVENTAF no encuentró el resto de informacion para imprimir", "Sistema COVENTAF");                    
                }
                        
            }
            catch (Exception ex )
            {
                MessageBox.Show(ex.Message, "Sistema COVENTAF");
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
           
           
        }

        public void ImprimirPreLectura(object sender, PrintPageEventArgs e)
        {
            decimal sumaTotalCordobas = 0.00M;
            decimal sumaTotaDolar = 0.00M;
            decimal totalSistema = 0.00M;

            //en una linea son 40 caracteres.


            int posX = 0, posY = 0;
            //Bahnschrift Light Condensed
            //Courier 9
            //Agency FB
            //Bahnschrift Light Condensed
            Font fuente = new Font("Agency FB", 12, FontStyle.Regular);
            Font fuenteRegular = new Font("Agency FB", 12, FontStyle.Regular);
            Font fuenteRegular_7 = new Font("Agency FB", 12, FontStyle.Regular);
            //var ClientRectangle = new Point(4, 200);


            // Dim sfCenter As New StringFormat With _
            //{
            //     _
            //       .Alignment = StringAlignment.Near, _
            //       .LineAlignment = StringAlignment.Center _
            //}
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
                e.Graphics.DrawString("EJERCITO DE NICARAGUA", fuente, Brushes.Black, 85, posY);
                posY += 17;

                //TIENDA ELECTRODOMESTICO
                posX = User.TiendaID == "T01" ? 74 : 108;
                e.Graphics.DrawString(User.NombreTienda, fuente, Brushes.Black, posX, posY);
                posX = 2;
                posY += 17;
                e.Graphics.DrawString("CIERRE DE PELECTURA", fuente, Brushes.Black, posX + 87, posY);
                posY += 20;

                ////factura
                posY += 44;
                e.Graphics.DrawString("CAJA: " + User.Caja, fuenteRegular, Brushes.Black, posX, posY);
                posY += 17;
                e.Graphics.DrawString("CAJERO: " + User.Usuario, fuenteRegular, Brushes.Black, posX, posY);
                posY += 17;
                e.Graphics.DrawString($"FECHA: {DateTime.Now.ToString("dd/MM/yyyy")}" , fuenteRegular, Brushes.Black, posX, posY);
                posY += 17;
                e.Graphics.DrawString($"TIPO CAMBIO: {cierre_Pos.Tipo_Cambio.ToString("N2")}" , fuenteRegular, Brushes.Black, posX, posY);
             
                posY += 17;             
                e.Graphics.DrawString("_______________________________________________________________________________________________________", fuente, Brushes.Black, posX, posY);


                posX = 2;
                posY += 25;                
                e.Graphics.DrawString("EFECTIVO CORDOBAS:", fuenteRegular, Brushes.Black, posX, posY);
                posX += 170;
                e.Graphics.DrawString("C$ " + EfectivoCordoba.ToString("N2"), fuenteRegular, Brushes.Black, posX, posY);

                posX = 2;
                posY += 17;               
                e.Graphics.DrawString("EFECTIVO DOLAR:", fuenteRegular, Brushes.Black, posX, posY);
                posX += 170;
                e.Graphics.DrawString("U$ " + EfectivoDolar.ToString("N2"), fuenteRegular, Brushes.Black, posX, posY);

                posX = 2;
                posY += 17;                
                e.Graphics.DrawString("MONTO APERTURA: ", fuenteRegular, Brushes.Black, posX, posY);
                posX += 170;
                e.Graphics.DrawString("C$ " + cierre_Pos.Monto_Apertura.ToString("N2"), fuenteRegular, Brushes.Black, posX, posY);

                posX = 2;
                posY += 17;                
                e.Graphics.DrawString("VENTAS EFECTIVO:", fuenteRegular, Brushes.Black, posX, posY);
                posX += 170;
                e.Graphics.DrawString("C$ " + ventasEfectivo.ToString("N2"), fuenteRegular, Brushes.Black, posX, posY);

                posX = 2;
                posY += 3;
                e.Graphics.DrawString("_______________________________________________________________________________________________________", fuenteRegular, Brushes.Black, posX, posY);


                foreach (var item in _datosCierreCaja)
                {
                    posY += 17;
                    posX = 2;
                    e.Graphics.DrawString(item.Descripcion, fuenteRegular, Brushes.Black, posX, posY);

                    posX += 170;

                    if (item.TipoDocumento == "D")
                    {
                        e.Graphics.DrawString(item.Moneda == "L" ? $"C$ 0.00" : $"U$ 0.00", fuenteRegular, Brushes.Black, posX, posY);
                    }
                    else
                    {

                        e.Graphics.DrawString(item.Moneda == "L" ? $"C$ {item.Monto.ToString("N2")}" : $"U$ {item.Monto.ToString("N2")}", fuenteRegular, Brushes.Black, posX, posY);
                    }

                    
                    //verificar si la moneda es cordobas (L (Local)= cordobas)
                    if (item.Moneda =="L" && item.TipoDocumento =="F") sumaTotalCordobas += item.Monto;
                    //vrificar si la moneda es Dolar (D= Dolar)
                    if (item.Moneda == "D" && item.TipoDocumento == "F") sumaTotaDolar += item.Monto;
                }

                posX = 2;
                posY += 8;
                e.Graphics.DrawString("_____________________________________________________________________________________", fuente, Brushes.Black, posX, posY);

                //hacer la suma total
                totalSistema = sumaTotalCordobas + montoApertura + (sumaTotaDolar * UtilidadesMain.RoundApproximate(cierre_Pos.Tipo_Cambio, 2));

                posX = 2;
                posY += 20;
                e.Graphics.DrawString("TOTAL DEL SISTEMA:", fuenteRegular, Brushes.Black, posX, posY);
                posX += 140;
                e.Graphics.DrawString($"C$ {totalSistema.ToString("N2")}", fuenteRegular, Brushes.Black, posX, posY);

               

                posY += 40;
                posX = 120;
                e.Graphics.DrawString("", fuenteRegular, Brushes.Black, posX, posY);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnCierre_Click(object sender, EventArgs e)
        {
            this.Close();
        }

     
    }
}
