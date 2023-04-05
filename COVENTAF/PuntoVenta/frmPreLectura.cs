using Api.Model.Modelos;
using Api.Model.ViewModels;
using Api.Service.DataService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COVENTAF.PuntoVenta
{
    public partial class frmPreLectura : Form
    {
        //esta variable guardar true si se guardo correctamente el cierre de caja
        public bool CierreCajaExitosamente = false;
        private decimal EfectivoCordoba = 0.00M;
        private decimal EfectivoDolar=0.00M;
        private decimal montoApertura = 0.00M;
        private decimal ventasEfectivo = 0.00M;

        List<Denominacion> denominacion = new List<Denominacion>();
        ServiceCaja_Pos _serviceCajaPos;
        List<ViewModelCierreCaja> _datosCierreCaja ;
        VariableCierreCaja _listVarCierreCaja = new VariableCierreCaja();
        private string idActual = "";
        private decimal cantidadGrid;
        private decimal totatCajeroCordobas = 0.00M;
        private decimal totalCajeroDolares = 0.00M;

        private PrintDocument doc = new PrintDocument();
        private PrintPreviewDialog vista = new PrintPreviewDialog();
        // Construct the PrintPreviewControl.
        PrintPreviewControl PrintPreviewControl1 = new PrintPreviewControl();

        public frmPreLectura()
        {
            InitializeComponent();
            _serviceCajaPos = new ServiceCaja_Pos();
        }

        private void frmPreLectura_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Recorda que falta hacer los calculos entren otros");
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

            }

            this.lblTitulo.Text = $"Prelectura de Caja: {User.Caja}.  Numero de Cierre: {User.ConsecCierreCT}";
            
        }



        public async void PrepararPrelectura(string caja, string cajero, string numeroCierre)
        {
            this.Cursor = Cursors.WaitCursor;

            ResponseModel responseModel = new ResponseModel();
            _datosCierreCaja = new List<ViewModelCierreCaja>();

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
            this.Cursor = Cursors.Default;
        }

        private void LlenarGridReportadoXSistema(List<ViewModelCierreCaja> _datosCierreCaja)
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
                    
                    _listVarCierreCaja.VentaEfectivoCordoba += itemSistema.Monto;
                }
                //comprobar si existe forma de pago 0001=Efectivo dolar
                if (itemSistema.Forma_Pago == "0001" && itemSistema.Moneda == "D")
                {
                    
                    _listVarCierreCaja.VentaEfectivoDolar += itemSistema.Monto;
                }
            }

            //this.txtTotalCordobasSistema.Text = _listVarCierreCaja.TotalCordoba.ToString("N2");
            //this.txtTotalDolaresSistema.Text = _listVarCierreCaja.TotalDolar.ToString("N2");

        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            doc.PrinterSettings.PrinterName = doc.DefaultPageSettings.PrinterSettings.PrinterName;

            doc.PrintPage += new PrintPageEventHandler(ImprimirPreLectura);
            // Set the zoom to 25 percent.
            //this.PrintPreviewControl1.Zoom = 0.25;            
            //vista.Controls.Add(this.PrintPreviewControl1);

            vista.Document = doc;
            //doc.Print();
            vista.ShowDialog();
        }

        public void ImprimirPreLectura(object sender, PrintPageEventArgs e)
        {

            //en una linea son 40 caracteres.


            int posX = 0, posY = 0;
            //Font fuente = new Font("consola", 8, FontStyle.Bold);
            //Font fuenteRegular = new Font("consola", 8, FontStyle.Regular);
            //Font fuenteRegular_7 = new Font("consola", 7, FontStyle.Regular);
            Font fuente = new Font("Courier", 9, FontStyle.Bold);
            Font fuenteRegular = new Font("Courier", 9, FontStyle.Regular);
            Font fuenteRegular_7 = new Font("Courier", 9, FontStyle.Regular);
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

                posX = 2;
                posY += 20;
                e.Graphics.DrawString("CIERRE DE PELECTURA", fuente, Brushes.Black, posX + 53, posY);
                posY += 20;

                ////factura
                posY += 24;
                e.Graphics.DrawString("CAJA: " + User.Caja, fuenteRegular, Brushes.Black, posX, posY);
                posY += 15;
                e.Graphics.DrawString("CAJERO: " + User.Usuario, fuenteRegular, Brushes.Black, posX, posY);
                posY += 15;
                e.Graphics.DrawString("FECHA: aqui va la fecha" , fuenteRegular, Brushes.Black, posX, posY);
                posY += 15;
                e.Graphics.DrawString("TIPO CAMBIO: aqui va el tipo cambio" , fuenteRegular, Brushes.Black, posX, posY);
             
                posY += 15;             
                e.Graphics.DrawString("_______________________________________________________________________________________________________", fuente, Brushes.Black, posX, posY);


                posX = 2;
                posY += 15;                
                e.Graphics.DrawString("EFECTIVO CORDOBAS:", fuenteRegular, Brushes.Black, posX, posY);
                posX += 170;
                e.Graphics.DrawString("C$ " + EfectivoCordoba.ToString("N2"), fuenteRegular, Brushes.Black, posX, posY);

                posX = 2;
                posY += 15;               
                e.Graphics.DrawString("EFECTIVO DOLAR:", fuenteRegular, Brushes.Black, posX, posY);
                posX += 170;
                e.Graphics.DrawString("U$ " + EfectivoDolar.ToString("N2"), fuenteRegular, Brushes.Black, posX, posY);

                posX = 2;
                posY += 15;                
                e.Graphics.DrawString("MONTO APERTURA:", fuenteRegular, Brushes.Black, posX, posY);
                posX += 170;
                e.Graphics.DrawString("C$ " + montoApertura.ToString("N2"), fuenteRegular, Brushes.Black, posX, posY);

                posX = 2;
                posY += 15;                
                e.Graphics.DrawString("VENTAS EFECTIVO:", fuenteRegular, Brushes.Black, posX, posY);
                posX += 170;
                e.Graphics.DrawString("C$ " + ventasEfectivo.ToString("N2"), fuenteRegular, Brushes.Black, posX, posY);

                posX = 2;
                posY += 3;
                e.Graphics.DrawString("_______________________________________________________________________________________________________", fuenteRegular, Brushes.Black, posX, posY);


                foreach (var item in _datosCierreCaja)
                {
                    posY += 15;
                    posX = 2;
                    e.Graphics.DrawString(item.Descripcion, fuenteRegular, Brushes.Black, posX, posY);

                    posX += 170;
                    e.Graphics.DrawString(item.Moneda == "L" ? $"C${item.Monto.ToString("N2")}" : $"U${item.Monto.ToString("N2")}", fuenteRegular, Brushes.Black, posX, posY);                                      
                }

                posX = 2;
                posY += 8;
                e.Graphics.DrawString("_____________________________________________________________________________________", fuente, Brushes.Black, posX, posY);

                posX = 2;
                posY += 15;
                e.Graphics.DrawString("TOTAL DEL SISTEMA:", fuenteRegular, Brushes.Black, posX, posY);
                posX += 140;
                e.Graphics.DrawString("C$120,457,360.45" + ventasEfectivo.ToString("N2"), fuenteRegular, Brushes.Black, posX, posY);
          

                posY += 200;
                posX = 120;
                e.Graphics.DrawString(" ", fuenteRegular, Brushes.Black, posX, posY);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
