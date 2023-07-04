using Api.Model.ViewModels;
using Api.Service.DataService;
using COVENTAF.Metodos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COVENTAF.PuntoVenta
{
    public partial class frmDetalleFactura : Form
    {
        public string factura = "";
        string Transition; 
        public bool resultExitosa = false;

        #region codigo para mover pantalla
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        #endregion

        public frmDetalleFactura()
        {
            InitializeComponent();
        }

        private void barraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void frmDetalleFactura_Load(object sender, EventArgs e)
        {
            Transition = "FadeIn";
            tmTransition.Start();
            this.Top = this.Top + 15;
            //llamar al metodo para buscar la factura
            BuscarFactura();
        }

        //buscar la factura
        private async void BuscarFactura()
        {
            var _serviceFactura = new ServiceFactura();

            ResponseModel responseModel = new ResponseModel();
            ViewModelFacturacion viewModelFactura;

            try
            {
                responseModel = await _serviceFactura.BuscarNoFactura(factura, responseModel);
                //si la respuesta del servidor es diferente de 1
                if (responseModel.Exito == 1)
                {

                    viewModelFactura = responseModel.Data as ViewModelFacturacion;
                    //new Metodos.MetodoImprimir().ImprimirTicketFactura(viewModelFactura, true);
                    decimal tipoCambio = Convert.ToDecimal(viewModelFactura.Factura.Tipo_Cambio.ToString("N2"));
                    this.lblFactura.Text = $"Factura: {viewModelFactura.Factura.Factura}";
                    this.lblFecha.Text = $"Fecha: {viewModelFactura.Factura.Fecha.ToString("dd/MM/yyyy")}";
                    this.lblCaja.Text = $"Caja: {viewModelFactura.Factura.Caja}";
                    this.lblTipoCambio.Text = $"Tipo Cambio: {viewModelFactura.Factura.Tipo_Cambio.ToString("N4")}";
                    this.lblCodigoCliente.Text = $"Codigo: {viewModelFactura.Factura.Cliente}";
                    this.lblCliente.Text = $"Cliente: {viewModelFactura.Factura.Nombre_Cliente}";
                    this.lblObservacion2.Text = viewModelFactura.Factura.Observaciones;
                    this.lblCajero.Text = $"Cajero: {viewModelFactura.Factura.NombreCajero}";
                    this.lblSubTotal.Text = $"Sub Total: C$ {viewModelFactura.Factura.Total_Mercaderia.ToString("N2")}";
                    this.lblDescuento.Text = $"Descuento: C$ {viewModelFactura.Factura.Monto_Descuento1.ToString("N2")}";
                    this.lblTotal.Text = $"Total: C$ {viewModelFactura.Factura.Total_Factura.ToString("N2")}";

                    foreach (var detFactura in viewModelFactura.FacturaLinea)
                    {
                        this.dgvDetalleFactura.Rows.Add(detFactura.Linea, detFactura.Articulo, detFactura.Cantidad.ToString("N2"), $"{ detFactura.Porc_Desc_Linea.Value.ToString("N2")} %", detFactura.Descripcion, detFactura.Lote,
                            $"C$ {detFactura.Precio_Unitario.ToString("N4")}", $"U$ {(detFactura.Precio_Unitario / viewModelFactura.Factura.Tipo_Cambio).ToString("N2")}",  /*Precio unitario*/
                            detFactura.Bodega, "", /*bodega*/
                            $"C$ {(detFactura.Precio_Total + detFactura.Desc_Tot_Linea).ToString("N2")}", $"U$ {((detFactura.Precio_Total + detFactura.Desc_Tot_Linea) / tipoCambio).ToString("N2")}", /*Subtotal */
                            $"C$ {detFactura.Desc_Tot_Linea.ToString("N2")}", $"U$ {(detFactura.Desc_Tot_Linea / tipoCambio).ToString("N2")}", /*Descuento*/
                            $"C$ {detFactura.Precio_Total.ToString("N2")}", $"U$ {(detFactura.Precio_Total / tipoCambio).ToString("N2")}");
                    }


                    foreach (var detPagoPos in viewModelFactura.PagoPos)
                    {
                        if (detPagoPos.Pago == "-1")
                        {
                            this.dgvDetallePago.Rows.Add("Vuelto", $"C$ {(detPagoPos.Monto_Local * (-1)).ToString("N2")}");
                        }
                        else
                        {
                            /***************   *****/

                            string documento = "";
                            switch (detPagoPos.Forma_Pago)
                            {
                                case "0002":
                                    documento = detPagoPos.Entidad_Financiera == null || detPagoPos.Entidad_Financiera.Length == 0 ? "" : detPagoPos.Entidad_Financiera;
                                    break;

                                case "0003":
                                    documento = detPagoPos.Tipo_Tarjeta == null || detPagoPos.Tipo_Tarjeta.Length == 0 ? "" : detPagoPos.Tipo_Tarjeta;
                                    break;

                                case "0004":
                                    documento = detPagoPos.Condicion_Pago == null || detPagoPos.Condicion_Pago.Length == 0 ? "" : detPagoPos.Condicion_Pago;
                                    documento = detPagoPos.Numero == null || detPagoPos.Numero.Length == 0 ? documento : $"{documento} {detPagoPos.Numero}";
                                    break;

                                case "0005":
                                    documento = detPagoPos.Numero == null || detPagoPos.Numero.Length == 0 ? "" : detPagoPos.Numero;
                                    break;

                                //Recibos Anticipo
                                case "FP11":
                                    documento = detPagoPos.Numero == null || detPagoPos.Numero.Length == 0 ? " ANTICIPO" : $" (ANTICIPO) {detPagoPos.Numero}";
                                    break;
                            }

                            var DescripcionFormaPago = viewModelFactura.FormasPagos.Where(fp => fp.Forma_Pago == detPagoPos.Forma_Pago).Select(x => x.Descripcion).FirstOrDefault();

                            //veficar si el monto es en Dolar entonces agregar la palabra (DOLAR) 
                            DescripcionFormaPago = detPagoPos.Monto_Dolar > 0 ? $"{DescripcionFormaPago} (DOLAR)" : DescripcionFormaPago;

                            this.dgvDetallePago.Rows.Add(DescripcionFormaPago, $"C$ {detPagoPos.Monto_Local.ToString("N2")}", $"U$ {detPagoPos.Monto_Dolar.ToString("N2")}", documento);

                            /**********************/
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Sistema COVENTAF", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }

        private void tmTransition_Tick(object sender, EventArgs e)
        {
            Utilidades.tmTransition_Tick(ref Transition, this.tmTransition, this);

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            tmTransition.Start();
        }
    }
}
