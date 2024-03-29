﻿
using Api.Helpers;
using Api.Model.Modelos;
using Api.Model.View;
using Api.Model.ViewModels;
using Api.Service.DataService;
using COVENTAF.Metodos;
using COVENTAF.Services;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace COVENTAF.PuntoVenta
{
    public partial class frmDevoluciones : Form
    {
        private ViewModelFacturacion _devolucion;
        private List<DetalleDevolucion> _detalleDevolucion ;
        private ServiceDevolucion _serviceDevolucion = new ServiceDevolucion();
        private ViewModelDevolucion ticketImpresion = new ViewModelDevolucion();

        public string factura;
        public string numeroCierre;
        public string caja;

    
        //MONTO DEL DESCUENTO GENERAL DE LA FACTURA
        private decimal montDescuentoGeneral = 0.00M;
        private decimal porcentajeDescGeneral = 0.00M;
        private decimal totalMercaderia = 0.00M;
        private decimal descuentoLinea = 0.00M;
         
        private decimal totalUnidades = 0.000M;
        private decimal subTotalCordoba = 0.00M;
        private decimal subTotalDolar = 0.00M;
        private decimal totalFactura = 0.0000M;
        private decimal total_FacturaOriginal = 0.00M;
        private decimal subTotalDescuentoCordoba = 0.00M;
        private decimal tipoCambioCon2Decimal = 0.00M;


        private string NoDevolucion;
        private string documento_Origen;
        private string tipo_Origen;
        private string formaPagoDevolucion;

        #region codigo para mover pantalla
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        #endregion
        public frmDevoluciones()
        {
            InitializeComponent();
        }


        private void barraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnBuscarFactura_Click(object sender, EventArgs e)
        {
            //var frmBuscarFactura = new frmAnularFactura(this);
            //frmBuscarFactura.ShowDialog();
        }

        private void btnCierre_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        public void CargarDatosFactura(ViewFactura datosFactura)
        {
        }

        private void btnAnularFactura_Click(object sender, EventArgs e)
        {

        }


        private async void frmDevoluciones_Load(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            foreach (DataGridViewColumn column in dgvDetalleDevolucion.Columns)    //deshabilitar el click y  reordenamiento por columnas
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }


            _detalleDevolucion = new List<DetalleDevolucion>();

            ResponseModel responseModel = new ResponseModel();
            responseModel.Data = new ViewModelFacturacion();

            _devolucion = new ViewModelFacturacion();
            _devolucion.Factura = new Facturas();
            _devolucion.FacturaLinea = new List<Factura_Linea>();
            _devolucion.PagoPos = new List<Pago_Pos>();
            _devolucion.FacturaRetenciones = new List<Factura_Retencion>();

            try
            {
                responseModel = await _serviceDevolucion.BuscarFacturaPorNoFactura(factura, caja, numeroCierre, responseModel);
                if (responseModel.Exito == 1)
                {
                    _devolucion = responseModel.Data as ViewModelFacturacion;
                    //obtiene el descuento 
                    porcentajeDescGeneral = _devolucion.Factura.Porc_Descuento1;
                    documento_Origen = _devolucion.Factura.Factura;
                    tipo_Origen = _devolucion.Factura.Tipo_Documento;
                    NoDevolucion = _devolucion.NoDevolucion;
                    total_FacturaOriginal = _devolucion.Factura.Total_Factura;
                    tipoCambioCon2Decimal = Utilidades.RoundApproximate(_devolucion.Factura.Tipo_Cambio, 2);
                    this.lblTipoCambio.Text = $"Tipo Cambio: {_devolucion.Factura.Tipo_Cambio.ToString("N4")}";

                    //mostrar la informacion basica al usuario
                    this.lblNoDevolucion.Text = $"No. Devolución: {_devolucion.NoDevolucion}";
                    this.lblNoFactura.Text = $"No. Factura: {factura}";
                    this.lblCaja.Text = $"Caja: {_devolucion.Factura.Caja}";                    
                    this.lblCliente.Text = $"Cliente: ({_devolucion.Factura.Cliente}) {_devolucion.Factura.Nombre_Cliente}";
                              
                    //Devolucion Vale por defecto
                    formaPagoDevolucion = "0005";

                    //primero obtener el registro de la forma de pago al credito para luego verificar si existe el registro
                    var formaPagoCredito = _devolucion.PagoPos.Where(x => x.Forma_Pago == "0004").FirstOrDefault();
                    //luego obtener el registro de la forma de pago al credito a corto plazo para luego verificar si existe el registro
                    var formaPagoCreditoCortPlz = _devolucion.PagoPos.Where(x => x.Forma_Pago == "FP17").FirstOrDefault();

                    //verificar si la forma de pago 0004 (Credito)
                    if (formaPagoCredito != null)
                    {
                        //asignar la forma de pago al credito (0004)
                        formaPagoDevolucion = "0004";
                    }
                    //verificar si la forma de pago es Credito a Corto Plazo (FP17)
                    else if (formaPagoCreditoCortPlz != null)
                    {
                        //asignar la forma de pago al credito a corto plazo (FP17)
                        formaPagoDevolucion = "FP17";
                    }
                                 

                    //llenar el combox forma de pago y luego buscar si existe la forma de pago al credito
                    this.cboTipoPago.ValueMember = "Forma_Pago";
                    this.cboTipoPago.DisplayMember = "Descripcion";
                    this.cboTipoPago.DataSource = _devolucion.FormasPagos;
                    this.cboTipoPago.SelectedValue = formaPagoDevolucion;
                    cboTipoPago.Enabled = false;


                    int consecutivo = 0;
                    foreach (var factLinea in _devolucion.FacturaLinea)
                    {
                        //luego restar la cantidad - la cantidad devuelta
                        var cantidadRestante = factLinea.Cantidad - factLinea.Cantidad_Devuelt;

                        if (cantidadRestante > 0)
                        {
                            //si Porc_Desc_Linea es null entonces se lo pone cero
                            factLinea.Porc_Desc_Linea = factLinea.Porc_Desc_Linea == null ? 0.00M : factLinea.Porc_Desc_Linea;

                            //Desc_Tot_Linea (monto descuento) tiene monto y el % del descuento es null o es cero (0) entonces hago el calculo para sacar el porcentaje
                            if (factLinea.Desc_Tot_Linea > 0 && factLinea.Porc_Desc_Linea == 0)
                            {
                                //(DESC_TOT_LINEA * 100)/(DESC_TOT_LINEA + PRECIO_TOTAL)
                                factLinea.Porc_Desc_Linea = (factLinea.Desc_Tot_Linea * 100) / (factLinea.Desc_Tot_Linea + factLinea.Precio_Total);
                            }
                                                                                                           
                            //el consecutivo de la linea no funciona cuando ya existe una devolucion
                            _detalleDevolucion.Add(new DetalleDevolucion()
                            {
                                Linea= factLinea.Linea,
                                Consecutivo = consecutivo,
                                ArticuloId = factLinea.Articulo,
                                Descripcion = factLinea.Descripcion,
                                Cantidad = cantidadRestante,
                                Lote = factLinea.Lote,
                                PorcentDescuentArticulo =  Convert.ToDecimal(factLinea.Porc_Desc_Linea),
                                PrecioCordobas = factLinea.Precio_Unitario, //Utilidades.RoundApproximate(factLinea.Precio_Unitario, 4),
                                CantidadDevolver = "0",
                                SubTotalCordobas = 0.00M,
                                DescuentoPorLineaCordoba = 0.00M,
                                MontoDescGeneralDolar = 0.00M,
                                TotalCordobas = 0.00M,
                                Cost_Prom_Loc = factLinea.Costo_Total_Local / factLinea.Cantidad,  ///.Cost_Prom_Loc Utilidades.RoundApproximate(factLinea.Costo_Total_Local / factLinea.Cantidad, 4),
                                Cost_Prom_Dol = factLinea.Costo_Total_Dolar / factLinea.Cantidad, //Cost_Prom_Dol  Utilidades.RoundApproximate(factLinea.Costo_Total_Dolar / factLinea.Cantidad, 4),
                            });


                            factLinea.Cantidad = cantidadRestante;

                            //el poner en cero ya que puede ser que ese mismo articulo se haiga realizado una devolucion parcial
                            //entonces va afectar al momento de guardar
                            factLinea.Cantidad_Devuelt = 0.00M;

                            this.dgvDetalleDevolucion.Rows.Add(consecutivo, factLinea.Articulo, factLinea.Descripcion, Utilidades.RoundApproximate(factLinea.Precio_Unitario, 4), factLinea.Lote, Utilidades.RoundApproximate(cantidadRestante, 2),
                                0.00, /*cantidad devolver*/
                                0.00, /*Subtotal*/
                                Utilidades.RoundApproximate(Convert.ToDecimal(factLinea.Porc_Desc_Linea), 2), //Por centaje descuento de linea del articulo
                                0.00, /* Monto del Descuento del articulo*/
                                0.00, /*Total*/
                                factLinea.Linea); 
                            
                            //incrementar 
                            consecutivo += 1;
                        }
                    }

                }
                else
                {
                    MessageBox.Show(responseModel.Mensaje, "Sistema COVENTAF");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Sistema COVENTAF");
            }
            finally
            {
                this.Cursor = Cursors.Default;
                this.dgvDetalleDevolucion.Cursor = default;                
            }
            
        }

        void BuscarFactura()
        {

        }

        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.btnRestaurar.Visible = false;
            this.btnMaximizar.Visible = true;
        }

        private void btnMiminizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.btnMaximizar.Visible = false;
            this.btnRestaurar.Visible = true;
        }



        private void btnDevolverTodo_Click(object sender, EventArgs e)
        {
            //llamar al metodo calcular y le paso por parametro true indicandole que ejecute toda la lista articulo a Devolucion
            CalcularTotales(true);
            this.btnAceptar.Enabled = true;     
        }

        
        private void CalcularTotales(bool devolverTodo = false)
        {
            //inicializar valor de la       
            //_procesoFacturacion.InicializarVariableTotales(listVarFactura);
            int consecutivo = 0;
            subTotalCordoba = 0.00M;
            totalUnidades = 0.00M;
            descuentoLinea = 0.00M;

            foreach (var detfact in _detalleDevolucion)
            {
                //obtener el consecutivo
                consecutivo = detfact.Consecutivo;

                detfact.CantidadDevolver = (devolverTodo ? detfact.Cantidad.ToString() : detfact.CantidadDevolver.ToString());



                #region calculos detallados por cada articulo
                /***************************************************************** calculos detallados por cada articulo  *******************************************************************/
                /*********************** cantidad por precios dolares y cordobas *************************************************************/
                //precio cordobas 
                detfact.SubTotalCordobas = Convert.ToDecimal(detfact.CantidadDevolver) * detfact.PrecioCordobas; //Utilidades.RoundApproximate(Convert.ToDecimal(detfact.CantidadDevolver) * detfact.PrecioCordobas, 2);
                //cantidad * precio en Dolares  por cada fila
                detfact.SubTotalDolar = detfact.SubTotalCordobas / tipoCambioCon2Decimal; //Utilidades.RoundApproximate(detfact.SubTotalCordobas / tipoCambioCon2Decimal, 2);
                /***************************************************************************************************************************/

                /*********************** descuento por cada articulo articulo en dolares y cordobas ****************************************************/
                //asignar el descuento por cada fila para el descuentoCordoba
                detfact.DescuentoPorLineaCordoba = (detfact.SubTotalCordobas * (detfact.PorcentDescuentArticulo / 100)); //Utilidades.RoundApproximate((detfact.SubTotalCordobas * (detfact.PorcentDescuentArticulo / 100)), 2);
                //asignar el descuento por cada fila para el descuentoDolar
                detfact.DescuentoPorLineaDolar = detfact.DescuentoPorLineaCordoba / tipoCambioCon2Decimal; //Utilidades.RoundApproximate(detfact.DescuentoPorLineaCordoba / tipoCambioCon2Decimal, 2);
                descuentoLinea += detfact.DescuentoPorLineaCordoba;
                /*************************************************************************************************************************/

                /*********************** total (restando el descuento x articulo) por articulo en dolares y cordobas ****************************************************/
                //la resta del subTotal menos y subTotal de descuento cordoba
                detfact.TotalCordobas = detfact.SubTotalCordobas - detfact.DescuentoPorLineaCordoba;
                //la resta del subTotal menos y subTotal de descuento            
                detfact.TotalDolar = detfact.TotalCordobas / tipoCambioCon2Decimal; //Utilidades.RoundApproximate(detfact.TotalCordobas / tipoCambioCon2Decimal, 2);
                /*************************************************************************************************************************/

                /************************ descuento general por linea dolares y cordobas ************************************************/
                //aplicar el descuento general si existe. esto solo aplica para cordobas
                detfact.MontoDescGeneralCordoba = detfact.TotalCordobas * (porcentajeDescGeneral / 100.00M); //Utilidades.RoundApproximate(detfact.TotalCordobas * (porcentajeDescGeneral / 100.00M), 2);
                //aplicar el descuento general si existe.
                detfact.MontoDescGeneralDolar = detfact.MontoDescGeneralCordoba / tipoCambioCon2Decimal; // Utilidades.RoundApproximate(detfact.MontoDescGeneralCordoba / tipoCambioCon2Decimal, 2);
                /***********************************************************************************************************************/
                /***************************************************************** fin *******************************************************************/
                #endregion


                /********************** sub totales en cordobas y dolares  ****************************************************************/
                //suma de los subTotales de la lista de articulos en cordobas
                subTotalCordoba += detfact.TotalCordobas;
                //suma de los subTotales de la lista de articulos en dolares
                subTotalDolar =subTotalCordoba / tipoCambioCon2Decimal; //Utilidades.RoundApproximate(subTotalCordoba / tipoCambioCon2Decimal, 2);
                /*************************************************************************************************************************/


                //sumar el total de las unidades
                totalUnidades += Convert.ToDecimal(detfact.CantidadDevolver);
                /***** softland hace lo siguiente: para dolar toma 2 decimales. para cordobas toma 4 decimales. */
                //establecer dos decimales a la variable de tipo decimal

                //se puso en comentario para que no tome solo dos decimales
                //detfact.SubTotalCordobas = Utilidades.RoundApproximate(detfact.SubTotalCordobas, 2);
                //detfact.SubTotalDolar = Utilidades.RoundApproximate(detfact.SubTotalDolar, 2);
                //detfact.PorcentDescuentArticulo = Utilidades.RoundApproximate(detfact.PorcentDescuentArticulo, 2);
                //detfact.DescuentoPorLineaCordoba = Utilidades.RoundApproximate(detfact.DescuentoPorLineaCordoba, 2);
                //detfact.DescuentoPorLineaDolar = Utilidades.RoundApproximate(detfact.DescuentoPorLineaDolar, 2);

                //detfact.MontoDescGeneralDolar = Utilidades.RoundApproximate(detfact.MontoDescGeneralDolar, 2);
                //detfact.MontoDescGeneralCordoba = Utilidades.RoundApproximate(detfact.MontoDescGeneralCordoba, 2);
                //detfact.TotalCordobas = Utilidades.RoundApproximate(detfact.TotalCordobas, 2);
                //detfact.TotalDolar = Utilidades.RoundApproximate(detfact.TotalDolar, 2);

                #region actualizar el registro de cada fila del grid                                                                            
                //this.dgvDetalleFactura.Rows[consecutivo].Cells["UnidadFraccion"].Value = detfact.UnidadFraccion;

                this.dgvDetalleDevolucion.Rows[consecutivo].Cells["CantidadDevolver"].Value = Convert.ToDecimal(detfact.CantidadDevolver).ToString("N2");
                this.dgvDetalleDevolucion.Rows[consecutivo].Cells["SubTotal"].Value = detfact.SubTotalCordobas.ToString("N2");
                //this.dgvDetalleDevolucion.Rows[consecutivo].Cells["SubTotalDolar"].Value = detfact.SubTotalDolar.ToString("N2");
                this.dgvDetalleDevolucion.Rows[consecutivo].Cells["DescuentoArticulo"].Value = detfact.DescuentoPorLineaCordoba.ToString("N2");
                //this.dgvDetalleDevolucion.Rows[consecutivo].Cells["DescuentoPorLineaDolar"].Value = detfact.DescuentoPorLineaDolar.ToString("N2");                                              
                this.dgvDetalleDevolucion.Rows[consecutivo].Cells["Total"].Value = detfact.TotalCordobas.ToString("N2");
                //this.dgvDetalleDevolucion.Rows[consecutivo].Cells["Total"].Value = detfact.TotalDolar.ToString("N2");
                               
                #endregion
            }

                                  

            /******* TEXTBOX DESCUENTO GENERAL  DOLAR Y CORDOBA ********************************************/
            //hacer el calculo para el descuento general            
            montDescuentoGeneral = subTotalCordoba * (porcentajeDescGeneral / 100); //Utilidades.RoundApproximate(subTotalCordoba * (porcentajeDescGeneral / 100), 2);
           

            this.txtDescuento.Text = $"C$ {montDescuentoGeneral.ToString("N2")}";
            //this.txtDescuentoDolares.Text = $"U$ {listVarFactura.DescuentoGeneralDolar.ToString("N2")}";
            /*****************************************************************************************************/


            /******* TEXTBOX SUB TOTAL DESCUENTO DOLARES Y CORDOBAS *************************************************/
            ///restar del subtotal descuento Cordoba - descuento del beneficio Cordoba
            subTotalDescuentoCordoba = subTotalCordoba - montDescuentoGeneral;
     
            /*************************************************************************************************************/

            /******* TEXTBOX IVA DOLARES Y CORDOBAS **********************************************************************************/                     
            decimal IvaCordoba = subTotalDescuentoCordoba * 0;
            //listVarFactura.IvaDolar = Utilidades.RoundApproximate(listVarFactura.IvaCordoba / listVarFactura.TipoCambioCon2Decimal, 2);
            this.txtIVA.Text = $"C$ {IvaCordoba.ToString("N2")}";          
            /*************************************************************************************************************************/

            /*********************TEXTBOX TOTAL EN DOLARES Y CORDOBAS ****************************************************************/
            totalFactura = subTotalDescuentoCordoba + IvaCordoba;
           
            this.txtTotalAcumulado.Text = "C$ " + totalFactura.ToString("N2");            
            /*************************************************************************************************************************/

            totalMercaderia = totalFactura + montDescuentoGeneral;
        }

        private async void btnAceptar_Click(object sender, EventArgs e)
        {
            if (VerificacionCantidadesExitosa())
            {
                ObtenerRegistroDevolucion();

                if (! UtilidadesMain.AutorizacionExitosa()) return;
                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    this.dgvDetalleDevolucion.Cursor = Cursors.WaitCursor;

                    ResponseModel responseModel = new ResponseModel();
                    responseModel = await _serviceDevolucion.GuardarDevolucion(_devolucion, responseModel);

                    //si la respuesta del servidor es diferente de 1
                    if (responseModel.Exito !=1)
                    {
                        MessageBox.Show(responseModel.Mensaje);
                        return;
                    }

                    ViewModelFacturacion modelDevolucion;
                    //modelDevolucion.Factura = new Facturas();
                    //modelDevolucion.FacturaLinea = new List<Factura_Linea>();
                    //modelDevolucion.NoDevolucion = _devolucion.NoDevolucion;

                    responseModel = await _serviceDevolucion.BuscarDevolucion(_devolucion.NoDevolucion, responseModel);
                    //si la respuesta del servidor es diferente de 1
                    if (responseModel.Exito == 1)
                    {                        
                        modelDevolucion = responseModel.Data as ViewModelFacturacion;
                        new Metodos.MetodoImprimir().ImprimirDevolucion(modelDevolucion);
                        //new FuncionDevolucion().ImprimirTicketDevolucion(ticketImpresion);
                        MessageBox.Show("La Devolucion se ha guardado exitosamente", "Sistema COVENTAF");
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Sistema COVENTAF");
                }
                finally
                {
                    this.Cursor = Cursors.Default;                    
                    this.dgvDetalleDevolucion.Cursor = Cursors.Default;
                }
            }
            
        }
         
        private void ObtenerRegistroDevolucion()
        {
            DateTime fechaVencimiento = DateTime.Now;
            fechaVencimiento = fechaVencimiento.AddDays(30);

            ticketImpresion.TicketFactura = new TicketFactura();
            ticketImpresion.TicketFacturaLineas = new List<TicketFacturaLinea>();

            ticketImpresion.TicketFactura.CajaDevolucion = _devolucion.Factura.Caja;

            _devolucion.Factura.Caja = User.Caja;
            _devolucion.Factura.Usuario = User.Usuario;
            _devolucion.Factura.Num_Cierre = User.ConsecCierreCT;
            _devolucion.Factura.Tipo_Original = _devolucion.Factura.Tipo_Documento;
            _devolucion.Factura.Total_Factura = Utilidades.RoundApproximate(totalFactura, 2);
            //monto del descuento general
            _devolucion.Factura.Monto_Descuento1 = montDescuentoGeneral;  
            _devolucion.Factura.Total_Mercaderia = totalMercaderia;
            _devolucion.Factura.Total_Unidades = totalUnidades;
            _devolucion.Factura.Observaciones = this.txtObservaciones.Text;
            _devolucion.Factura.Forma_Pago = this.cboTipoPago.SelectedValue.ToString();
            _devolucion.Factura.Fecha_Vence  = Convert.ToDateTime(fechaVencimiento);
            //Cargado_Cxc debe ser "N",  ya que luego en softland se ejecuta un proceso contable y este campo tiene que tener "N" obligatoriamente
            _devolucion.Factura.Cargado_Cxc = "N";

            //si la formar de pago de la devolucion es al Credito(0004) o credito a corto plazo (FP17)
            if (formaPagoDevolucion == "0004" || formaPagoDevolucion == "FP17")
            {                              
                _devolucion.Factura.Saldo = 0.00M;
                _devolucion.Factura.Cobrada = "S";
            }
            //de lo contrario significa que se va a pagar con Vale Devolucion
            else
            {
                _devolucion.Factura.Saldo = _devolucion.Factura.Total_Factura;
                _devolucion.Factura.Cobrada = "N";
            }

            ticketImpresion.TicketFactura.FechaDevolucion = _devolucion.Factura.Fecha;
            ticketImpresion.TicketFactura.NoDevolucion = _devolucion.NoDevolucion;
            ticketImpresion.TicketFactura.Caja = User.Caja;
            ticketImpresion.TicketFactura.BodegaId = _devolucion.Factura.Vendedor;
            ticketImpresion.TicketFactura.NombreBodega = _devolucion.Factura.Vendedor;
            ticketImpresion.TicketFactura.Cliente = _devolucion.Factura.Cliente;
            ticketImpresion.TicketFactura.NombreCliente = _devolucion.Factura.Nombre_Cliente;
            ticketImpresion.TicketFactura.FechaVencimiento =  fechaVencimiento.ToString("dd/MM/yyyy");
            ticketImpresion.TicketFactura.SaldoRestante = _devolucion.Factura.Total_Factura;
            ticketImpresion.TicketFactura.FacturaDevuelta = _devolucion.Factura.Factura;
            ticketImpresion.TicketFactura.DescuentoLinea = descuentoLinea;
            ticketImpresion.TicketFactura.DescuentoGeneral = montDescuentoGeneral;
            ticketImpresion.TicketFactura.SubTotal = subTotalCordoba;
            ticketImpresion.TicketFactura.Total = _devolucion.Factura.Total_Factura;
            ticketImpresion.TicketFactura.Vale = _devolucion.Factura.Total_Factura;

            foreach(var detDevolucion in _detalleDevolucion)
            {
                int linea = detDevolucion.Linea;
                string articuloId = detDevolucion.ArticuloId;
                //comprobar que el usuario realizo devolucion para esta linea
                if( Convert.ToDecimal(detDevolucion.CantidadDevolver) > 0)
                {
                    //obtener el registro del articulo del numero de linea
                    var devFacturaLinea = _devolucion.FacturaLinea.Where(x => x.Articulo == articuloId && x.Linea == linea).FirstOrDefault();
                                        
                    devFacturaLinea.Cantidad_Devuelt = Convert.ToDecimal(detDevolucion.CantidadDevolver);
                    devFacturaLinea.Documento_Origen = factura;
                    devFacturaLinea.Caja = User.Caja;
                    devFacturaLinea.Desc_Tot_Linea = detDevolucion.DescuentoPorLineaCordoba;// Convert.ToDecimal(this.dgvDetalleDevolucion.Rows[fila].Cells["Desc_Tot_Linea_Dev"].Value);
                    devFacturaLinea.Costo_Total_Dolar = Utilidades.RoundApproximate(detDevolucion.Cost_Prom_Dol * Convert.ToDecimal(detDevolucion.CantidadDevolver), 4); //Convert.ToDecimal(this.dgvDetalleDevolucion.Rows[fila].Cells["Costo_Total_Dolar_Dev"].Value);
                    devFacturaLinea.Costo_Total = Utilidades.RoundApproximate(detDevolucion.Cost_Prom_Loc * Convert.ToDecimal(detDevolucion.CantidadDevolver), 4);//Convert.ToDecimal(this.dgvDetalleDevolucion.Rows[fila].Cells["Costo_Total_Dev"].Value);
                    devFacturaLinea.Costo_Total_Local = Utilidades.RoundApproximate(detDevolucion.Cost_Prom_Loc * Convert.ToDecimal(detDevolucion.CantidadDevolver), 4); //Convert.ToDecimal(this.dgvDetalleDevolucion.Rows[fila].Cells["Costo_Total_Local_Dev"].Value);
                    devFacturaLinea.Costo_Total_Comp = Utilidades.RoundApproximate(detDevolucion.Cost_Prom_Loc * Convert.ToDecimal(detDevolucion.CantidadDevolver), 4); //Convert.ToDecimal(this.dgvDetalleDevolucion.Rows[fila].Cells["Costo_Total_Comp_Dev"].Value);
                    devFacturaLinea.Costo_Total_Comp_Local = Utilidades.RoundApproximate(detDevolucion.Cost_Prom_Loc * Convert.ToDecimal(detDevolucion.CantidadDevolver), 4); //Convert.ToDecimal(this.dgvDetalleDevolucion.Rows[fila].Cells["Costo_Total_Comp_Local_Dev"].Value);
                    //comparando con softlando observo que Costo_Total_Comp_Dolar=0
                    devFacturaLinea.Costo_Total_Comp_Dolar = Utilidades.RoundApproximate(detDevolucion.Cost_Prom_Dol * Convert.ToDecimal(detDevolucion.CantidadDevolver), 4);//Convert.ToDecimal(this.dgvDetalleDevolucion.Rows[fila].Cells["Costo_Total_Comp_Dolar_Dev"].Value);
                    devFacturaLinea.Precio_Total = detDevolucion.TotalCordobas;
                    devFacturaLinea.Desc_Tot_General = detDevolucion.MontoDescGeneralCordoba;
                    devFacturaLinea.Documento_Origen = _devolucion.Factura.Factura;
                    devFacturaLinea.Tipo_Origen = _devolucion.Factura.Tipo_Documento;

                    var _datosTicketFactLinea = new TicketFacturaLinea()
                    {
                        Articulo = devFacturaLinea.Articulo,
                        Cantidad = devFacturaLinea.Cantidad_Devuelt,
                        Precio = devFacturaLinea.Precio_Unitario,
                        //monto del descuento
                        DescuentoLinea = devFacturaLinea.Desc_Tot_Linea,
                        TotalLinea = devFacturaLinea.Precio_Total,
                        Descripcion = devFacturaLinea.Descripcion
                    };
                    ticketImpresion.TicketFacturaLineas.Add(_datosTicketFactLinea);                   
                }

            }
                      

        }

        private bool VerificacionCantidadesExitosa()
        {
            int contadorCero = 0;
            bool verificacionCantidades = true;

            foreach(var detDevolucion in _detalleDevolucion)
            {
                //obtener las cantidades a devolver
                decimal cantidadDevolver = Convert.ToDecimal(detDevolucion.CantidadDevolver);
                //obtener las cantidades originales de la factura
                decimal cantidad = Convert.ToDecimal(detDevolucion.Cantidad);

                //verificar que el usuario ha digitado las cantidades a devoler
                if (cantidadDevolver > 0) contadorCero += 1;

                //comprobar si cantidadDevolver es mayor que cero
                if (cantidadDevolver > cantidad)
                {
                    MessageBox.Show("Ante de guardar la devolucion revise las cantidades", "Devoluciones");
                    verificacionCantidades = false;
                    break;
                }
            }

   
            //si contador cero
            if (contadorCero == 0)
            {
                verificacionCantidades = false;
                this.btnAceptar.Enabled = false;
                MessageBox.Show("No hay nada que Devolver", "Sistema COVENTAF");
            }

            return verificacionCantidades;

        }
              

        private void dgvDetalleFacturaOriginal_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.BeginInvoke(new MethodInvoker(() =>
                {
                    //si la columna es cantidad a Devolver(6) 
                    if (e.ColumnIndex == 6)
                    {
                        //asignar el consucutivo para indicar en que posicion estas
                        int rowsGrid = e.RowIndex;
                        UtilidadesPuntoVenta.ValidarGridDevolucion(rowsGrid, e.ColumnIndex, dgvDetalleDevolucion, btnAceptar, _detalleDevolucion);
                        //calcular totales
                        CalcularTotales();

                        this.btnAceptar.Enabled = true;
                        this.btnDevolverTodo.Enabled = true;

                    }
                }));
                
            } 
            catch (Exception ex)
            {              
                XtraMessageBox.Show(ex.Message, "Sistema COVENTAF");
            }             
        }


        private void dgvDetalleDevolucion_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            this.btnAceptar.Enabled = false;
            this.btnDevolverTodo.Enabled = false;
        }

        private void dgvDetalleFactura_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnMinizar_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void btnCerraVentana_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
