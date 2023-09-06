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
        public string tipoDocumento = "";
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

            //si el tipo documento es diferente de Recibo
            if (tipoDocumento != "R") this.tbcDetalleFactura.TabPages.Remove(tpgDetalleAnticipo);
            if (tipoDocumento == "R")
            {
                this.tbcDetalleFactura.TabPages.Remove(tbpFactura);
                this.tbcDetalleFactura.TabPages.Remove(tbpRetenciones);
            }

            if (tipoDocumento=="R")
            {
                this.lblFacturaOriginal.Visible = false;
                BuscarAnticipo();
            }
            else
            {
                //si el tipo de documento es una Devolucion entonces mostrarla
                this.lblFacturaOriginal.Visible = tipoDocumento == "D" ? true : false;
                //llamar al metodo para buscar la factura
                BuscarFactura();
            }
            
        }

        private async void BuscarAnticipo()
        {
            this.Cursor = Cursors.WaitCursor;
            this.dgvDetalleFactura.Cursor = Cursors.WaitCursor;

            var _serviceFactura = new ServiceFactura();

            ResponseModel responseModel = new ResponseModel();
            ViewModelFacturacion viewModelFactura;

            try
            {
                responseModel = await _serviceFactura.BuscarNoRecibo(factura, responseModel);
                //si la respuesta del servidor es diferente de 1
                if (responseModel.Exito == 1)
                {

                    viewModelFactura = responseModel.Data as ViewModelFacturacion;
                    
                    //new Metodos.MetodoImprimir().ImprimirTicketFactura(viewModelFactura, true);
                    decimal tipoCambio = Convert.ToDecimal(viewModelFactura.Documento_Pos.Tipo_Cambio.ToString("N2"));
                    this.lblFactura.Text = $"Recibo: {viewModelFactura.Documento_Pos.Documento}";
                    this.lblTipoDocumento.Text = $"Tipo Documento: {viewModelFactura.Documento_Pos.Tipo}";
                    this.txtFechaAnticipo.Text = viewModelFactura.Documento_Pos.Fch_Hora_Creacion.ToString("dd/MM/yyyy");
                    this.txtCajaAnticipo.Text = viewModelFactura.Documento_Pos.Caja;
                    this.lblTipoCambio.Text = $"Tipo Cambio: {viewModelFactura.Documento_Pos.Tipo_Cambio.ToString("N4")}";
                    this.txtCodigoClienteAnticipo.Text = viewModelFactura.Documento_Pos.Cliente;
                    this.txtNombreClienteAnticipo.Text = viewModelFactura.Documento_Pos.Nombre_Cliente;
                    this.txtTotalAnticipo.Text =$"C$ {viewModelFactura.Documento_Pos.Total_Pagar.ToString("N2")}";
                    this.txtSaldo.Text = $"C$ {viewModelFactura.Documento_Pos.Saldo.ToString("N2")}";
                    this.txtObservacionAnticipo.Text = viewModelFactura.Documento_Pos.Notas;
                    this.txtCajeroAnticipo.Text = viewModelFactura.Documento_Pos.NombreCajero;
                    this.dgvAnticipoAplicado.DataSource = viewModelFactura.ListAuxiliarPos;
                                                       

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
            finally
            {
                this.Cursor = Cursors.Default;
                this.dgvDetalleFactura.Cursor = Cursors.Default;
            }
        }

        //buscar la factura
        private async void BuscarFactura()
        {
            this.Cursor = Cursors.WaitCursor;
            this.dgvDetalleFactura.Cursor = Cursors.WaitCursor;

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
                    this.lblFacturaOriginal.Text = $"Factura Original: {viewModelFactura.Factura.Factura_Original}";
                    this.lblTipoDocumento.Text = $"Tipo Documento: {viewModelFactura.Factura.Tipo_Documento}";
                    this.txtFecha.Text = viewModelFactura.Factura.Fecha.ToString("dd/MM/yyyy");
                    this.txtCaja.Text = viewModelFactura.Factura.Caja;
                    this.lblTipoCambio.Text = $"Tipo Cambio: {viewModelFactura.Factura.Tipo_Cambio.ToString("N4")}";
                    this.txtCodigoCliente.Text = viewModelFactura.Factura.Cliente;
                    this.txtNombreCliente.Text = viewModelFactura.Factura.Nombre_Cliente;
                    this.txtObservaciones.Text = viewModelFactura.Factura.Observaciones;
                    this.txtCajero.Text = viewModelFactura.Factura.NombreCajero;
                    this.txtSubTotal.Text = $"C$ {viewModelFactura.Factura.Total_Mercaderia.ToString("N2")}";
                    this.txtDescuento.Text = $"C$ {viewModelFactura.Factura.Monto_Descuento1.ToString("N2")}";
                    this.txtIVA.Text = $"C$ 0.00";
                    this.txtTotal.Text =$"C$ {viewModelFactura.Factura.Total_Factura.ToString("N2")}";

                    foreach (var detFactura in viewModelFactura.FacturaLinea)
                    {

                        //si Porc_Desc_Linea es null entonces se lo pone cero
                        detFactura.Porc_Desc_Linea = detFactura.Porc_Desc_Linea == null ? 0.00M : detFactura.Porc_Desc_Linea;                                             
                       
                        //Desc_Tot_Linea (monto descuento) tiene monto y el % del descuento es null o es cero (0) entonces hago el calculo para sacar el porcentaje
                        if (detFactura.Desc_Tot_Linea > 0 &&  detFactura.Porc_Desc_Linea == 0)
                        {
                            //(DESC_TOT_LINEA * 100)/(DESC_TOT_LINEA + PRECIO_TOTAL)
                            detFactura.Porc_Desc_Linea = (detFactura.Desc_Tot_Linea * 100) / (detFactura.Desc_Tot_Linea + detFactura.Precio_Total);
                        }
                                             

                        this.dgvDetalleFactura.Rows.Add(detFactura.Linea, detFactura.Articulo, detFactura.Cantidad.ToString("N2"), $"{ detFactura.Porc_Desc_Linea.Value.ToString("N2")} %", detFactura.Descripcion, detFactura.Lote,
                            $"C$ {detFactura.Precio_Unitario.ToString("N4")}", $"U$ {(detFactura.Precio_Unitario / viewModelFactura.Factura.Tipo_Cambio).ToString("N2")}",  /*Precio unitario*/
                            detFactura.Bodega, /*bodega*/
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

                    foreach(var item in viewModelFactura.FacturaRetenciones )
                    {
                        var descripcion = viewModelFactura.Retenciones.Where(x => x.Codigo_Retencion == item.Codigo_Retencion).Select(x=>x.Descripcion).FirstOrDefault();
                        this.dgvDetalleRetenciones.Rows.Add(item.Codigo_Retencion, descripcion, item.Monto.ToString("N2"), item.Base.ToString("N2"), item.Doc_Referencia,(item.AutoRetenedora=="S" ? true: false));
                    }

                    var totalRetenciones = viewModelFactura.FacturaRetenciones.Sum(x => x.Monto);
                    this.lblTotalRetenciones.Text = $"Total de Retenciones: C$ {totalRetenciones.ToString("N2")}";

                    if(viewModelFactura.FacturaRetenciones.Count == 0) { this.tbcDetalleFactura.TabPages.Remove(tbpRetenciones); }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Sistema COVENTAF", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }      
            finally
            {
                this.Cursor = Cursors.Default;
                this.dgvDetalleFactura.Cursor = Cursors.Default;
            }
        }

        private void tmTransition_Tick(object sender, EventArgs e)
        {
            UtilidadesMain.tmTransition_Tick(ref Transition, this.tmTransition, this);

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            tmTransition.Start();
        }

     
        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
            }
        }
    }
}
