﻿using Api.Model.Modelos;
using Api.Model.View;
using Api.Model.ViewModels;
using Api.Service.DataService;
using COVENTAF.Services;
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

        public string factura="0381137";
        public string numeroCierre="CT1000000006687";
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

                    this.lblNoDevolucion.Text = $"No. Devolución: {_devolucion.NoDevolucion}";
                    this.lblNoFactura.Text = $"No. Factura: {factura}";
                    this.lblCaja.Text = $"Caja: {_devolucion.Factura.Caja}";
                    this.lblPagoCliente.Text = $"Metodo de Pago que hizo el cliente con la factura: {_devolucion.Factura}";



                    //llenar el combox de la bodega
                    this.cboTipoPago.ValueMember = "Forma_Pago";
                    this.cboTipoPago.DisplayMember = "Descripcion";
                    this.cboTipoPago.DataSource = _devolucion.FormasPagos;
                    this.cboTipoPago.SelectedValue = "0005";

                    int consecutivo = 0;

                    foreach (var factLinea in _devolucion.FacturaLinea)
                    {
                        //luego restar la cantidad - la cantidad devuelta
                        var cantidadRestante = factLinea.Cantidad - factLinea.Cantidad_Devuelt;

                        if (cantidadRestante > 0)
                        {
                            //el consecutivo de la linea no funciona cuando ya existe una devolucion
                            _detalleDevolucion.Add(new DetalleDevolucion()
                            {
                                Consecutivo = consecutivo,
                                ArticuloId = factLinea.Articulo,
                                Descripcion = factLinea.Descripcion,
                                Cantidad = cantidadRestante,
                                PorcentDescuentArticulo = Convert.ToDecimal(factLinea.Porc_Desc_Linea),
                                PrecioCordobas = Utilidades.RoundApproximate(factLinea.Precio_Unitario, 4),
                                CantidadDevolver = "0",
                                SubTotalCordobas = 0.00M,
                                DescuentoPorLineaCordoba = 0.00M,
                                MontoDescGeneralDolar = 0.00M,
                                TotalCordobas = 0.00M,
                                Cost_Prom_Loc = Utilidades.RoundApproximate(factLinea.Costo_Total_Local / factLinea.Cantidad, 4),  ///.Cost_Prom_Loc
                                Cost_Prom_Dol = Utilidades.RoundApproximate(factLinea.Costo_Total_Dolar / factLinea.Cantidad, 4), //Cost_Prom_Dol
                            });


                            factLinea.Cantidad = cantidadRestante;

                            //el poner en cero ya que puede ser que ese mismo articulo se haiga realizado una devolucion parcial
                            //entonces va afectar al momento de guardar
                            factLinea.Cantidad_Devuelt = 0.00M;

                            this.dgvDetalleDevolucion.Rows.Add(consecutivo, factLinea.Articulo, factLinea.Descripcion, Utilidades.RoundApproximate(factLinea.Precio_Unitario, 4), Utilidades.RoundApproximate(cantidadRestante, 2),
                                0.00, /*cantidad devolver*/
                                0.00, /*Subtotal*/
                                Utilidades.RoundApproximate(Convert.ToDecimal(factLinea.Porc_Desc_Linea), 2), //Por centaje descuento de linea del articulo
                                0.00, /* Monto del Descuento del articulo*/
                                0.00); /*Total*/
                            
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
            //decimal _precioUnitario = 0, _cantidad = 0, _cantidadDevolver = 0, _descTotLineaDev = 0, _costTotalDolarDev = 0;
            //decimal _costoTotalDev = 0, _costoTotalLocalDev = 0, _costoTotalCompDev = 0, _costoTotalCompLocalDev = 0, _costoTotalCompDolarDev = 0;
            //decimal _precioTotalDev = 0;

            //totalUnidades = 0;
            //montDescuentoGeneral = 0;
            //totalFacturaDevuelta = 0;


            //// ArticuloId;
            ////     Descripcion;
            ////     Cantidad;
            ////     PrecioUnitario;
            ////     SubTotal = Precio_Total;
            ////     CantidadDevolver;
            ////     Costo_Total_Dolar_Dev;
            ////     Costo_Total_Dev;
            ////     Costo_Total_Local_Dev;
            ////     Costo_Total_Comp_Dev;
            ////     Costo_Total_Comp_Local_Dev;
            ////     Costo_Total_Comp_Dolar_Dev;
            ////     Desc_Tot_Linea;

            ////     ;
            ////     Precio_Total_Dev;





            //for (var rows = 0; rows < dgvDetalleFacturaOriginal.RowCount; rows++)
            //{
            //    _precioUnitario = Convert.ToDecimal(this.dgvDetalleFacturaOriginal.Rows[rows].Cells["PrecioUnitario"].Value);
            //    _cantidad = Convert.ToDecimal(this.dgvDetalleFacturaOriginal.Rows[rows].Cells["Cantidad"].Value);
            //    this.dgvDetalleFacturaOriginal.Rows[rows].Cells["CantidadDevolver"].Value = _cantidad.ToString();
            //    //obtener la cantidad devuelta
            //    _cantidadDevolver = Convert.ToDecimal(this.dgvDetalleFacturaOriginal.Rows[rows].Cells["CantidadDevolver"].Value);
            //    //obtener el valor del descuento por linea del producto
            //    _descTotLineaDev = Convert.ToDecimal(this.dgvDetalleFacturaOriginal.Rows[rows].Cells["Desc_Tot_Linea"].Value);
            //    _costTotalDolarDev = Convert.ToDecimal(this.dgvDetalleFacturaOriginal.Rows[rows].Cells["Costo_Total_Dolar"].Value);
            //    _costoTotalDev = Convert.ToDecimal(this.dgvDetalleFacturaOriginal.Rows[rows].Cells["Costo_Total"].Value);
            //    _costoTotalLocalDev = Convert.ToDecimal(this.dgvDetalleFacturaOriginal.Rows[rows].Cells["Costo_Total_Local"].Value);
            //    _costoTotalCompDev = Convert.ToDecimal(this.dgvDetalleFacturaOriginal.Rows[rows].Cells["Costo_Total_Comp"].Value);
            //    _costoTotalCompLocalDev = Convert.ToDecimal(this.dgvDetalleFacturaOriginal.Rows[rows].Cells["Costo_Total_Comp_Local"].Value);
            //    _costoTotalCompDolarDev = Convert.ToDecimal(this.dgvDetalleFacturaOriginal.Rows[rows].Cells["Costo_Total_Comp_Dolar"].Value);
            //    _precioTotalDev = Convert.ToDecimal(this.dgvDetalleFacturaOriginal.Rows[rows].Cells["Precio_Total"].Value);

            //    this.dgvDetalleFacturaOriginal.Rows[rows].Cells["Costo_Total_Dolar_Dev"].Value = ((_costTotalDolarDev / _cantidad) * _cantidadDevolver).ToString("N2");
            //    this.dgvDetalleFacturaOriginal.Rows[rows].Cells["Costo_Total_Dev"].Value = ((_costoTotalDev / _cantidad) * _cantidadDevolver).ToString("N4");
            //    this.dgvDetalleFacturaOriginal.Rows[rows].Cells["Costo_Total_Local_Dev"].Value = ((_costoTotalLocalDev / _cantidad) * _cantidadDevolver).ToString("N4");
            //    this.dgvDetalleFacturaOriginal.Rows[rows].Cells["Costo_Total_Comp_Dev"].Value = ((_costoTotalCompDev / _cantidad) * _cantidadDevolver).ToString("N4");
            //    this.dgvDetalleFacturaOriginal.Rows[rows].Cells["Costo_Total_Comp_Local_Dev"].Value = ((_costoTotalCompLocalDev / _cantidad) * _cantidadDevolver).ToString("N4");
            //    this.dgvDetalleFacturaOriginal.Rows[rows].Cells["Costo_Total_Comp_Dolar_Dev"].Value = ((_costoTotalCompDolarDev / _cantidad) * _cantidadDevolver).ToString("N2");

            //    _descTotLineaDev = ((_descTotLineaDev / _cantidad) * _cantidadDevolver);
            //    _precioTotalDev = (_precioUnitario * _cantidadDevolver) - _descTotLineaDev;
            //    this.dgvDetalleFacturaOriginal.Rows[rows].Cells["Desc_Tot_Linea_Dev"].Value = _descTotLineaDev.ToString("N4");

            //    this.dgvDetalleFacturaOriginal.Rows[rows].Cells["Desc_Tot_General_Dev"].Value = (_precioTotalDev * (porCentajeDescGeneral / 100)).ToString("N4");
            //    this.dgvDetalleFacturaOriginal.Rows[rows].Cells["Precio_Total_Dev"].Value = _precioTotalDev.ToString("N4");



            //    //sumar el total de las unidades
            //    totalUnidades += _cantidad;
            //    totalFacturaDevuelta += _precioTotalDev;
            //}

            ////obtener el descuento 
            //montDescuentoGeneral = Utilidades.RoundApproximate(totalFacturaDevuelta * (porCentajeDescGeneral / 100), 4);

            ////obtener el total de la factura - descuento
            //totalFacturaDevuelta = Utilidades.RoundApproximate(totalFacturaDevuelta - montDescuentoGeneral, 2);

            //totalMercaderia = totalFacturaDevuelta + montDescuentoGeneral;

            ////mostrar en pantalla el descuento
            //this.txtDescuento.Text = montDescuentoGeneral.ToString("N2");
            ////obtener el total de la factura - descuento;
            //this.txtTotalAcumulado.Text = totalFacturaDevuelta.ToString("N2");

            //this.btnAceptar.Enabled = true;
        }

        //private void Calcular(bool ejecutDevolverTodo=false)        
        //{
        //    decimal _precioUnitario = 0, _cantidad=0, _cantidadDevolver = 0, _descTotLineaDev = 0, _costTotalDolarDev = 0;
        //    decimal _costoTotalDev = 0, _costoTotalLocalDev = 0, _costoTotalCompDev = 0, _costoTotalCompLocalDev = 0, _costoTotalCompDolarDev = 0;
        //    decimal _precioTotalDev = 0, _descTotGeneralDev = 0;

        //    totalUnidades = 0;
        //    montDescuentoGeneral = 0.00M;
        //    subTotalFacturaDevuelta = 0.00M;
        //    totalFactura = 0.00M;

        //    for (var rows = 0; rows < dgvDetalleDevolucion.RowCount; rows++)
        //    {
        //        //obtener la cantidada del articulo a devolver.               
        //        _cantidadDevolver = Convert.ToDecimal(ejecutDevolverTodo ? this.dgvDetalleDevolucion.Rows[rows].Cells["Cantidad"].Value : this.dgvDetalleDevolucion.Rows[rows].Cells["CantidadDevolver"].Value);

        //        if (_cantidadDevolver > 0)
        //        {

        //            _precioUnitario = Convert.ToDecimal(this.dgvDetalleDevolucion.Rows[rows].Cells["PrecioUnitario"].Value);
        //            //obtengo la cantidad original de la factura por linea para luego realizar algunos calculos necesarios
        //            _cantidad = Convert.ToDecimal(this.dgvDetalleDevolucion.Rows[rows].Cells["Cantidad"].Value);
                                                           
        //            this.dgvDetalleDevolucion.Rows[rows].Cells["CantidadDevolver"].Value = _cantidadDevolver.ToString();

        //            //obtener el valor del descuento por linea del producto
        //            _descTotLineaDev = Convert.ToDecimal(this.dgvDetalleDevolucion.Rows[rows].Cells["Desc_Tot_Linea"].Value);
        //            _costTotalDolarDev = Convert.ToDecimal(this.dgvDetalleDevolucion.Rows[rows].Cells["Costo_Total_Dolar"].Value);
        //            _costoTotalDev = Convert.ToDecimal(this.dgvDetalleDevolucion.Rows[rows].Cells["Costo_Total"].Value);
        //            _costoTotalLocalDev = Convert.ToDecimal(this.dgvDetalleDevolucion.Rows[rows].Cells["Costo_Total_Local"].Value);
        //            _costoTotalCompDev = Convert.ToDecimal(this.dgvDetalleDevolucion.Rows[rows].Cells["Costo_Total_Comp"].Value);
        //            _costoTotalCompLocalDev = Convert.ToDecimal(this.dgvDetalleDevolucion.Rows[rows].Cells["Costo_Total_Comp_Local"].Value);
        //            _costoTotalCompDolarDev = Convert.ToDecimal(this.dgvDetalleDevolucion.Rows[rows].Cells["Costo_Total_Comp_Dolar"].Value);
        //            _precioTotalDev = Convert.ToDecimal(this.dgvDetalleDevolucion.Rows[rows].Cells["Precio_Total"].Value);

        //            this.dgvDetalleDevolucion.Rows[rows].Cells["Costo_Total_Dolar_Dev"].Value = ((_costTotalDolarDev / _cantidad) * _cantidadDevolver).ToString("N2");
        //            this.dgvDetalleDevolucion.Rows[rows].Cells["Costo_Total_Dev"].Value = ((_costoTotalDev / _cantidad) * _cantidadDevolver).ToString("N4");
        //            this.dgvDetalleDevolucion.Rows[rows].Cells["Costo_Total_Local_Dev"].Value = ((_costoTotalLocalDev / _cantidad) * _cantidadDevolver).ToString("N4");
        //            this.dgvDetalleDevolucion.Rows[rows].Cells["Costo_Total_Comp_Dev"].Value = ((_costoTotalCompDev / _cantidad) * _cantidadDevolver).ToString("N4");
        //            this.dgvDetalleDevolucion.Rows[rows].Cells["Costo_Total_Comp_Local_Dev"].Value = ((_costoTotalCompLocalDev / _cantidad) * _cantidadDevolver).ToString("N4");
        //            this.dgvDetalleDevolucion.Rows[rows].Cells["Costo_Total_Comp_Dolar_Dev"].Value = ((_costoTotalCompDolarDev / _cantidad) * _cantidadDevolver).ToString("N2");




        //            _descTotLineaDev = ((_descTotLineaDev / _cantidad) * _cantidadDevolver);
        //            _precioTotalDev = (_precioUnitario * _cantidadDevolver) - _descTotLineaDev;
        //            _descTotGeneralDev = (_precioTotalDev * (porcentajeDescGeneral / 100));


        //            this.dgvDetalleDevolucion.Rows[rows].Cells["Desc_Tot_Linea_Dev"].Value = _descTotLineaDev.ToString("N4");
        //            this.dgvDetalleDevolucion.Rows[rows].Cells["Desc_Tot_General_Dev"].Value = _descTotGeneralDev.ToString("N4");
        //            this.dgvDetalleDevolucion.Rows[rows].Cells["Precio_Total_Dev"].Value = _precioTotalDev.ToString("N4");

        //            //sumar el total de las unidades
        //            totalUnidades += _cantidadDevolver;
        //            subTotalFacturaDevuelta += _precioTotalDev;

        //        }
        //        else
        //        {
        //            this.dgvDetalleDevolucion.Rows[rows].Cells["Costo_Total_Dolar_Dev"].Value = 0;
        //            this.dgvDetalleDevolucion.Rows[rows].Cells["Costo_Total_Dev"].Value = 0;
        //            this.dgvDetalleDevolucion.Rows[rows].Cells["Costo_Total_Local_Dev"].Value = 0;
        //            this.dgvDetalleDevolucion.Rows[rows].Cells["Costo_Total_Comp_Dev"].Value = 0;
        //            this.dgvDetalleDevolucion.Rows[rows].Cells["Costo_Total_Comp_Local_Dev"].Value = 0;
        //            this.dgvDetalleDevolucion.Rows[rows].Cells["Costo_Total_Comp_Dolar_Dev"].Value = 0;
        //            this.dgvDetalleDevolucion.Rows[rows].Cells["Desc_Tot_Linea_Dev"].Value = 0;
        //            this.dgvDetalleDevolucion.Rows[rows].Cells["Desc_Tot_General_Dev"].Value = 0;
        //            this.dgvDetalleDevolucion.Rows[rows].Cells["Precio_Total_Dev"].Value = 0;
        //        }

        //    }

        //    montDescuentoGeneral = Utilidades.RoundApproximate(subTotalFacturaDevuelta * (porcentajeDescGeneral / 100), 2);
        //    //obtener el total de la factura - descuento
        //    totalFactura = Utilidades.RoundApproximate(subTotalFacturaDevuelta - montDescuentoGeneral, 2);
        //    totalMercaderia = totalFactura + montDescuentoGeneral;

        //    //mostrar en pantalla el descuento
        //    this.txtDescuento.Text = $"C$ {montDescuentoGeneral.ToString("N2")}";
        //    //obtener el total de la factura - descuento;
        //    this.txtTotalAcumulado.Text = $"C$ {totalFactura.ToString("N2")}";

        //    this.txtTotalDevolver.Text = $"C$ {totalFactura.ToString("N2")}";
        //    this.txtDiferencia.Text = $"C$ {(total_FacturaOriginal - totalFactura).ToString("N2")}";
            

        //    if (ejecutDevolverTodo) this.btnAceptar.Enabled = true;


        //    ////obtener el descuento 
        //    //montDescuentoGeneral = Utilidades.RoundApproximate(totalFacturaDevuelta * (porCentajeDescGeneral / 100), 4);

        //    ////obtener el total de la factura - descuento
        //    //totalFacturaDevuelta = Utilidades.RoundApproximate(totalFacturaDevuelta - montDescuentoGeneral, 2);

        //    //totalMercaderia = totalFacturaDevuelta + montDescuentoGeneral;

        //    ////mostrar en pantalla el descuento
        //    //this.txtDescuento.Text = montDescuentoGeneral.ToString("N2");
        //    ////obtener el total de la factura - descuento;
        //    //this.txtTotalAcumulado.Text = totalFacturaDevuelta.ToString("N2");
        //}

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
                detfact.SubTotalCordobas = Utilidades.RoundApproximate(Convert.ToDecimal(detfact.CantidadDevolver) * detfact.PrecioCordobas, 2);
                //cantidad * precio en Dolares  por cada fila
                detfact.SubTotalDolar = Utilidades.RoundApproximate(detfact.SubTotalCordobas / tipoCambioCon2Decimal, 2);
                /***************************************************************************************************************************/

                /*********************** descuento por cada articulo articulo en dolares y cordobas ****************************************************/
                //asignar el descuento por cada fila para el descuentoCordoba
                detfact.DescuentoPorLineaCordoba = Utilidades.RoundApproximate((detfact.SubTotalCordobas * (detfact.PorcentDescuentArticulo / 100)), 2);
                //asignar el descuento por cada fila para el descuentoDolar
                detfact.DescuentoPorLineaDolar = Utilidades.RoundApproximate(detfact.DescuentoPorLineaCordoba / tipoCambioCon2Decimal, 2);
                descuentoLinea += detfact.DescuentoPorLineaCordoba;
                /*************************************************************************************************************************/

                /*********************** total (restando el descuento x articulo) por articulo en dolares y cordobas ****************************************************/
                //la resta del subTotal menos y subTotal de descuento cordoba
                detfact.TotalCordobas = detfact.SubTotalCordobas - detfact.DescuentoPorLineaCordoba;
                //la resta del subTotal menos y subTotal de descuento            
                detfact.TotalDolar = Utilidades.RoundApproximate(detfact.TotalCordobas / tipoCambioCon2Decimal, 2);
                /*************************************************************************************************************************/

                /************************ descuento general por linea dolares y cordobas ************************************************/
                //aplicar el descuento general si existe. esto solo aplica para cordobas
                detfact.MontoDescGeneralCordoba = Utilidades.RoundApproximate(detfact.TotalCordobas * (porcentajeDescGeneral / 100.00M), 2);
                //aplicar el descuento general si existe.
                detfact.MontoDescGeneralDolar = Utilidades.RoundApproximate(detfact.MontoDescGeneralCordoba / tipoCambioCon2Decimal, 2);
                /***********************************************************************************************************************/
                /***************************************************************** fin *******************************************************************/
                #endregion


                /********************** sub totales en cordobas y dolares  ****************************************************************/
                //suma de los subTotales de la lista de articulos en cordobas
                subTotalCordoba += detfact.TotalCordobas;
                //suma de los subTotales de la lista de articulos en dolares
                subTotalDolar = Utilidades.RoundApproximate(subTotalCordoba / tipoCambioCon2Decimal, 2);
                /*************************************************************************************************************************/


                //sumar el total de las unidades
                totalUnidades += Convert.ToDecimal(detfact.CantidadDevolver);
                /***** softland hace lo siguiente: para dolar toma 2 decimales. para cordobas toma 4 decimales. */
                //establecer dos decimales a la variable de tipo decimal
                                
                
                detfact.SubTotalCordobas = Utilidades.RoundApproximate(detfact.SubTotalCordobas, 2);
                detfact.SubTotalDolar = Utilidades.RoundApproximate(detfact.SubTotalDolar, 2);
                detfact.PorcentDescuentArticulo = Utilidades.RoundApproximate(detfact.PorcentDescuentArticulo, 2);
                detfact.DescuentoPorLineaCordoba = Utilidades.RoundApproximate(detfact.DescuentoPorLineaCordoba, 2);
                detfact.DescuentoPorLineaDolar = Utilidades.RoundApproximate(detfact.DescuentoPorLineaDolar, 2);

                detfact.MontoDescGeneralDolar = Utilidades.RoundApproximate(detfact.MontoDescGeneralDolar, 2);
                detfact.MontoDescGeneralCordoba = Utilidades.RoundApproximate(detfact.MontoDescGeneralCordoba, 2);
                detfact.TotalCordobas = Utilidades.RoundApproximate(detfact.TotalCordobas, 2);
                detfact.TotalDolar = Utilidades.RoundApproximate(detfact.TotalDolar, 2);

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

            /******* TEXTBOX SUB TOTALES DOLARES Y CORDOBAS ***************************************************/
            //this.txtSubTotalCordobas.Text = $"C$ {listVarFactura.SubTotalCordoba.ToString("N2") }";
            //this.txtSubTotalDolares.Text = $"U$ {listVarFactura.SubTotalDolar.ToString("N2") }";
            /*****************************************************************************************************/
                        


            /******* TEXTBOX DESCUENTO GENERAL  DOLAR Y CORDOBA ********************************************/
            //hacer el calculo para el descuento general            
            montDescuentoGeneral = Utilidades.RoundApproximate(subTotalCordoba * (porcentajeDescGeneral / 100), 2);
            //listVarFactura.DescuentoGeneralDolar = Utilidades.RoundApproximate(listVarFactura.DescuentoGeneralCordoba / listVarFactura.TipoCambioCon2Decimal, cantidadDecimal);

            this.txtDescuento.Text = $"C$ {montDescuentoGeneral.ToString("N2")}";
            //this.txtDescuentoDolares.Text = $"U$ {listVarFactura.DescuentoGeneralDolar.ToString("N2")}";
            /*****************************************************************************************************/


            /******* TEXTBOX SUB TOTAL DESCUENTO DOLARES Y CORDOBAS *************************************************/
            ////restar del subtotal descuento Cordoba - descuento del beneficio Cordoba
            subTotalDescuentoCordoba = subTotalCordoba - montDescuentoGeneral;
            //restar del subtotal descuento Dolar - descuento del beneficio Dolar
            //listVarFactura.SubTotalDescuentoDolar = Utilidades.RoundApproximate(listVarFactura.SubTotalDescuentoCordoba / listVarFactura.TipoCambioCon2Decimal, 2);

            //this.txtSubTotalDescuentoCordobas.Text = $"C$ {listVarFactura.SubTotalDescuentoCordoba.ToString("N2")}";
            //this.txtSubTotalDescuentoDolares.Text = $"U$ {listVarFactura.SubTotalDescuentoDolar.ToString("N2")}";
            /*************************************************************************************************************/

            /******* TEXTBOX IVA DOLARES Y CORDOBAS **********************************************************************************/
            //llamar al metodo obtener iva para identificar si al cliente se le cobra iva            
            decimal IvaCordoba = subTotalDescuentoCordoba * 0;
            //listVarFactura.IvaDolar = Utilidades.RoundApproximate(listVarFactura.IvaCordoba / listVarFactura.TipoCambioCon2Decimal, 2);
            this.txtIVA.Text = $"C$ {IvaCordoba.ToString("N2")}";
            //this.txtIVADolares.Text = $"U$ {listVarFactura.IvaDolar.ToString("N2")}";
            /*************************************************************************************************************************/

            /*********************TEXTBOX TOTAL EN DOLARES Y CORDOBAS ****************************************************************/
            totalFactura = subTotalDescuentoCordoba + IvaCordoba;
            //listVarFactura.TotalDolar = Utilidades.RoundApproximate(listVarFactura.TotalCordobas / listVarFactura.TipoCambioCon2Decimal, 2);

            this.txtTotalAcumulado.Text = "C$ " + totalFactura.ToString("N2");
            //this.txtTotalDolares.Text = "U$ " + listVarFactura.TotalDolar.ToString("N2");
            /*************************************************************************************************************************/

            totalMercaderia = totalFactura + montDescuentoGeneral;
        }

        private async void btnAceptar_Click(object sender, EventArgs e)
        {
            if (VerificacionCantidadesExitosa())
            {
                ObtenerRegistroDevolucion();

                if (! Utilidades.AutorizacionExitosa()) return;
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

                        MessageBox.Show("La Devolucion se ha regitrado exitosamente", "Sistema COVENTAF");
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
                int fila = detDevolucion.Consecutivo;
                string articuloId = detDevolucion.ArticuloId;
                //comprobar que el usuario realizo devolucion para esta linea
                if( Convert.ToDecimal(detDevolucion.CantidadDevolver) > 0)
                {
                    var devFacturaLinea = _devolucion.FacturaLinea.Where(x => x.Articulo == articuloId).FirstOrDefault();
                    
                    
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

        private void calculoMatematico()
        {
            /*************** tabla FACTURA*******************************************
             MONTO_DESCUENTO1= MONTO DEL DESCUENTO GENERAL DE LA FACTURA
             PORC_DESCUENTO1 = % DESCUENTO GENERAL DE LA FACTURA
             // total de cordobas = es el total de la factura + el monto del descuento General
             TOTAL_MERCADERIA = listVarFactura.TotalCordobas + listVarFactura.DescuentoGeneralCordoba   
            tota_unidades = total de unidades a devolver
             
             */




            /****************************tabla FACTURA LINEA  *********************************
             
            DESC_TOT_LINEA = (DESC_TOT_LINEA /cantidadVendida)* CantidadDevuelta
            COSTO_TOTAL_DOLAR= ((COSTO_TOTAL_DOLAR / FACT_LIN.CANTIDAD) * DEV.CantidadDevolver), 
            COSTO_TOTAL=((COSTO_TOTAL/CANTIDAD) * CantidadDevolver),
            COSTO_TOTAL_LOCAL=((COSTO_TOTAL_LOCAL / CANTIDAD) * CantidadDevolver)
            COSTO_TOTAL_COMP=((COSTO_TOTAL_COMP/CANTIDAD)* CantidadDevolver),
            COSTO_TOTAL_COMP_LOCAL=((COSTO_TOTAL_COMP_LOCAL/CANTIDAD)*CantidadDevolver),
            COSTO_TOTAL_COMP_DOLAR=((COSTO_TOTAL_COMP_DOLAR/CANTIDAD)* CantidadDevolver)
            //aqui ya tiene restado el descuento por linea. precio_total_x_linea. ya lo verifique con softland
            Precio_Total = (CantidadDevolver * PRECIO_VENTA)-DESC_TOT_LINEA
            DOCUMENTO_ORIGEN=NoFactura
            TIPO_ORIGEN= TipoDocumento
            //descuento general. el % se encuentra en la tabla Factura en el campo Porc_Descuento1 (Porc_Descuento1=% DEL DESCUENTO DE LOS MILITARES)
            DESC_TOT_GENERAL = Precio_Total *  Porc_Descuento1; (

                                                     
            */

        }

        private void dgvDetalleFacturaOriginal_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // dgvDetalleFacturaOriginal.Rows[0]
            //si la columna es cantidad a Devolver(14) 
            if (e.ColumnIndex == 5)
            {
                string mensaje = "";
                bool CantidadConDecimal = false;
                string cantidadDevolver = dgvDetalleDevolucion.Rows[e.RowIndex].Cells["CantidadDevolver"].Value.ToString();
                //obtener la cantidad del DataGridView
                decimal cantidadFactura = Convert.ToDecimal(dgvDetalleDevolucion.Rows[e.RowIndex].Cells["Cantidad"].Value);
                //verificar si la unidad de medida del articulo permite punto decimal (ej.: 3.5)
                // bool CantidadConDecimal = (dgvDetalleFactura.Rows[consecutivoActualFactura].Cells["UnidadFraccion"].Value.ToString() == "S" ? true : false);
                if (!new FuncionFacturacion().CantidadIsValido(dgvDetalleDevolucion.Rows[e.RowIndex].Cells["CantidadDevolver"].Value.ToString(), CantidadConDecimal, ref mensaje))
                {
                    MessageBox.Show(mensaje, "Sistema COVENTAF", MessageBoxButtons.OK);
                    //asignarle la cantidad que tenia antes de editarla
                    dgvDetalleDevolucion.Rows[e.RowIndex].Cells["CantidadDevolver"].Value = "0";
                }
                else if (Convert.ToDecimal(cantidadDevolver) > cantidadFactura)
                {
                    MessageBox.Show("La cantidad a devolver excede a la cantidad del articulo de la factura", "Sistema COVENTAF", MessageBoxButtons.OK);
                    //asignarle la cantidad que tenia antes de editarla
                    dgvDetalleDevolucion.Rows[e.RowIndex].Cells["CantidadDevolver"].Value = "0";
                }
                else if (Convert.ToDecimal(cantidadDevolver) < 0)
                {
                    MessageBox.Show("La cantidad del articulo Devolver no puede ser negativo", "Sistema COVENTAF", MessageBoxButtons.OK);
                    //asignarle la cantidad que tenia antes de editarla
                    dgvDetalleDevolucion.Rows[e.RowIndex].Cells["CantidadDevolver"].Value = "0";
                }
                else
                {
                    _detalleDevolucion[e.RowIndex].CantidadDevolver = dgvDetalleDevolucion.Rows[e.RowIndex].Cells["CantidadDevolver"].Value.ToString();                    
                    //hacer el calculo
                    CalcularTotales();
                    this.btnAceptar.Enabled = true;
                }



            }
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

        private async void button1_Click(object sender, EventArgs e)
        {
            ResponseModel responseModel = new ResponseModel();
            
            ViewModelFacturacion modelDevolucion;
            //modelDevolucion.Factura = new Facturas();
            //modelDevolucion.FacturaLinea = new List<Factura_Linea>();
            //modelDevolucion.NoDevolucion = _devolucion.NoDevolucion;


            responseModel = await _serviceDevolucion.BuscarDevolucion("T1C07-DEV-0000000", responseModel);
            //si la respuesta del servidor es diferente de 1
            if (responseModel.Exito == 1)
            {
                modelDevolucion = responseModel.Data as ViewModelFacturacion;

                new Metodos.MetodoImprimir().ImprimirDevolucion(modelDevolucion);

                //new FuncionDevolucion().ImprimirTicketDevolucion(ticketImpresion);

                //MessageBox.Show("La Devolucion se ha regitrado exitosamente", "Sistema COVENTAF");
                //this.Close();

            }


            //new FuncionDevolucion().ImprimirTicketDevolucion(ticketImpresion);

        }
    }
}
