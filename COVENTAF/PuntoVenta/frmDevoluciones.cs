using Api.Model.Modelos;
using Api.Model.View;
using Api.Model.ViewModels;
using Api.Service.DataService;
using COVENTAF.Services;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace COVENTAF.PuntoVenta
{
    public partial class frmDevoluciones : Form
    {
        private ViewModelFacturacion _devolucion;
        private ServiceDevolucion _serviceDevolucion = new ServiceDevolucion();

        public string factura;
        public string numeroCierre;

        //MONTO DEL DESCUENTO GENERAL DE LA FACTURA
        private decimal montDescuento = 0.00M;
        private decimal porCentajeDescGeneral = 0.00M;
        private decimal totalMercaderia = 0.00M;
        private decimal totalUnidades = 0.000M;
        private decimal totalFacturaDevuelta = 0.0000M;


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
            this.WindowState = FormWindowState.Maximized;

            ResponseModel responseModel = new ResponseModel();
            responseModel.Data = new ViewModelFacturacion();

            _devolucion = new ViewModelFacturacion();
            _devolucion.Factura = new Facturas();
            _devolucion.FacturaLinea = new List<Factura_Linea>();
            _devolucion.PagoPos = new List<Pago_Pos>();
            _devolucion.FacturaRetenciones = new List<Factura_Retencion>();

            responseModel = await _serviceDevolucion.BuscarFacturaPorNoFactura(factura, numeroCierre, responseModel);
            if (responseModel.Exito == 1)
            {
                _devolucion = responseModel.Data as ViewModelFacturacion;
                //obtiene el descuento 
                porCentajeDescGeneral = _devolucion.Factura.Porc_Descuento1;
                documento_Origen = _devolucion.Factura.Factura;
                tipo_Origen = _devolucion.Factura.Tipo_Documento;
                NoDevolucion = _devolucion.NoDevolucion;
                this.lblNoDevolucion.Text = $"No. Devolución: {_devolucion.NoDevolucion}";
                this.lblNoFactura.Text = $"No. Factura: {factura}";
                this.lblCaja.Text = $"Caja: {_devolucion.Factura.Factura}";
                this.lblPagoCliente.Text = $"Metodo de Pago que hizo el cliente con la factura: {_devolucion.Factura}";



                //llenar el combox de la bodega
                this.cboTipoPago.ValueMember = "Forma_Pago";
                this.cboTipoPago.DisplayMember = "Descripcion";
                this.cboTipoPago.DataSource = _devolucion.FormasPagos;
                this.cboTipoPago.SelectedValue = "0005";

                foreach (var factLinea in _devolucion.FacturaLinea)
                {
                    this.dgvDetalleFacturaOriginal.Rows.Add(factLinea.Articulo, factLinea.Descripcion, Math.Round(factLinea.Cantidad, 2), Math.Round(factLinea.Precio_Unitario, 4),


                         factLinea.Costo_Total_Dolar, //Costo_Total_Dolar_Dev
                        factLinea.Costo_Total, //Costo_Total_Dev
                        factLinea.Costo_Total_Local, //Costo_Total_Local_Dev
                        factLinea.Costo_Total_Comp, //Costo_Total_Comp_Dev
                        factLinea.Costo_Total_Comp_Local, //Costo_Total_Comp_Local_Dev
                        factLinea.Costo_Total_Comp_Dolar, //Costo_Total_Comp_Dolar_Dev
                       factLinea.Desc_Tot_Linea, //DescTot_Linea
                       factLinea.Desc_Tot_General, //Desc_Tot_General_Dev
                        factLinea.Precio_Total, /*SubTotal = Precio_Total*/

                        0 /*CantidadDevolver*/,
                        0, //Costo_Total_Dolar_Dev
                        0, //Costo_Total_Dev
                        0, //Costo_Total_Local_Dev
                        0, //Costo_Total_Comp_Dev
                        0, //Costo_Total_Comp_Local_Dev
                        0, //Costo_Total_Comp_Dolar_Dev
                        0, //DescTot_Linea
                        0, //Desc_Tot_General_Dev
                        0);//Precio_Total_Dev
                }


                ////agregar un tipo de retencion al grid
                //this.dgvDetalleRetenciones.Rows.Add(this.cboRetenciones.SelectedValue.ToString(), this.cboRetenciones.Text, Math.Round(montoTotal * (_datos.Porcentaje / 100), 2),
                //                                    montoTotal, $"RET-#{longitudGrid + 1}", (_datos.Es_AutoRetenedor == "S" ? true : false));

            }
            else
            {
                MessageBox.Show(responseModel.Mensaje, "Sistema COVENTAF");
                this.Close();
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
            decimal _precioUnitario = 0, _cantidad = 0, _cantidadDevolver = 0, _descTotLineaDev = 0, _costTotalDolarDev = 0;
            decimal _costoTotalDev = 0, _costoTotalLocalDev = 0, _costoTotalCompDev = 0, _costoTotalCompLocalDev = 0, _costoTotalCompDolarDev = 0;
            decimal _precioTotalDev = 0;

            totalUnidades = 0;
            montDescuento = 0;
            totalFacturaDevuelta = 0;


            // ArticuloId;
            //     Descripcion;
            //     Cantidad;
            //     PrecioUnitario;
            //     SubTotal = Precio_Total;
            //     CantidadDevolver;
            //     Costo_Total_Dolar_Dev;
            //     Costo_Total_Dev;
            //     Costo_Total_Local_Dev;
            //     Costo_Total_Comp_Dev;
            //     Costo_Total_Comp_Local_Dev;
            //     Costo_Total_Comp_Dolar_Dev;
            //     Desc_Tot_Linea;

            //     ;
            //     Precio_Total_Dev;





            for (var rows = 0; rows < dgvDetalleFacturaOriginal.RowCount; rows++)
            {
                _precioUnitario = Convert.ToDecimal(this.dgvDetalleFacturaOriginal.Rows[rows].Cells["PrecioUnitario"].Value);
                _cantidad = Convert.ToDecimal(this.dgvDetalleFacturaOriginal.Rows[rows].Cells["Cantidad"].Value);
                this.dgvDetalleFacturaOriginal.Rows[rows].Cells["CantidadDevolver"].Value = _cantidad.ToString();
                //obtener la cantidad devuelta
                _cantidadDevolver = Convert.ToDecimal(this.dgvDetalleFacturaOriginal.Rows[rows].Cells["CantidadDevolver"].Value);
                //obtener el valor del descuento por linea del producto
                _descTotLineaDev = Convert.ToDecimal(this.dgvDetalleFacturaOriginal.Rows[rows].Cells["Desc_Tot_Linea"].Value);
                _costTotalDolarDev = Convert.ToDecimal(this.dgvDetalleFacturaOriginal.Rows[rows].Cells["Costo_Total_Dolar"].Value);
                _costoTotalDev = Convert.ToDecimal(this.dgvDetalleFacturaOriginal.Rows[rows].Cells["Costo_Total"].Value);
                _costoTotalLocalDev = Convert.ToDecimal(this.dgvDetalleFacturaOriginal.Rows[rows].Cells["Costo_Total_Local"].Value);
                _costoTotalCompDev = Convert.ToDecimal(this.dgvDetalleFacturaOriginal.Rows[rows].Cells["Costo_Total_Comp"].Value);
                _costoTotalCompLocalDev = Convert.ToDecimal(this.dgvDetalleFacturaOriginal.Rows[rows].Cells["Costo_Total_Comp_Local"].Value);
                _costoTotalCompDolarDev = Convert.ToDecimal(this.dgvDetalleFacturaOriginal.Rows[rows].Cells["Costo_Total_Comp_Dolar"].Value);
                _precioTotalDev = Convert.ToDecimal(this.dgvDetalleFacturaOriginal.Rows[rows].Cells["Precio_Total"].Value);

                this.dgvDetalleFacturaOriginal.Rows[rows].Cells["Costo_Total_Dolar_Dev"].Value = ((_costTotalDolarDev / _cantidad) * _cantidadDevolver).ToString("N2");
                this.dgvDetalleFacturaOriginal.Rows[rows].Cells["Costo_Total_Dev"].Value = ((_costoTotalDev / _cantidad) * _cantidadDevolver).ToString("N4");
                this.dgvDetalleFacturaOriginal.Rows[rows].Cells["Costo_Total_Local_Dev"].Value = ((_costoTotalLocalDev / _cantidad) * _cantidadDevolver).ToString("N4");
                this.dgvDetalleFacturaOriginal.Rows[rows].Cells["Costo_Total_Comp_Dev"].Value = ((_costoTotalCompDev / _cantidad) * _cantidadDevolver).ToString("N4");
                this.dgvDetalleFacturaOriginal.Rows[rows].Cells["Costo_Total_Comp_Local_Dev"].Value = ((_costoTotalCompLocalDev / _cantidad) * _cantidadDevolver).ToString("N4");
                this.dgvDetalleFacturaOriginal.Rows[rows].Cells["Costo_Total_Comp_Dolar_Dev"].Value = ((_costoTotalCompDolarDev / _cantidad) * _cantidadDevolver).ToString("N2");

                _descTotLineaDev = ((_descTotLineaDev / _cantidad) * _cantidadDevolver);
                _precioTotalDev = (_precioUnitario * _cantidadDevolver) - _descTotLineaDev;
                this.dgvDetalleFacturaOriginal.Rows[rows].Cells["Desc_Tot_Linea_Dev"].Value = _descTotLineaDev.ToString("N4");

                this.dgvDetalleFacturaOriginal.Rows[rows].Cells["Desc_Tot_General_Dev"].Value = (_precioTotalDev * (porCentajeDescGeneral / 100)).ToString("N4");
                this.dgvDetalleFacturaOriginal.Rows[rows].Cells["Precio_Total_Dev"].Value = _precioTotalDev.ToString("N4");



                //sumar el total de las unidades
                totalUnidades += _cantidad;
                totalFacturaDevuelta += _precioTotalDev;
            }

            //obtener el descuento 
            montDescuento = Math.Round(totalFacturaDevuelta * (porCentajeDescGeneral / 100), 4);

            //obtener el total de la factura - descuento
            totalFacturaDevuelta = Math.Round(totalFacturaDevuelta - montDescuento, 4);

            totalMercaderia = totalFacturaDevuelta + montDescuento;

            //mostrar en pantalla el descuento
            this.txtDescuento.Text = montDescuento.ToString("N2");
            //obtener el total de la factura - descuento;
            this.txtTotalAcumulado.Text = totalFacturaDevuelta.ToString("N2");

            this.btnAceptar.Enabled = true;
        }

        private void Calcular()
        {
            decimal _precioUnitario = 0, _cantidad = 0, _cantidadDevolver = 0, _descTotLineaDev = 0, _costTotalDolarDev = 0;
            decimal _costoTotalDev = 0, _costoTotalLocalDev = 0, _costoTotalCompDev = 0, _costoTotalCompLocalDev = 0, _costoTotalCompDolarDev = 0;
            decimal _precioTotalDev = 0, _descTotGeneralDev = 0;

            totalUnidades = 0;
            montDescuento = 0;
            totalFacturaDevuelta = 0;

            for (var rows = 0; rows < dgvDetalleFacturaOriginal.RowCount; rows++)
            {

                _cantidadDevolver = Convert.ToDecimal(this.dgvDetalleFacturaOriginal.Rows[rows].Cells["CantidadDevolver"].Value);

                if (_cantidadDevolver > 0)
                {

                    _precioUnitario = Convert.ToDecimal(this.dgvDetalleFacturaOriginal.Rows[rows].Cells["PrecioUnitario"].Value);
                    _cantidad = Convert.ToDecimal(this.dgvDetalleFacturaOriginal.Rows[rows].Cells["Cantidad"].Value);

                    //obtener el valor del descuento por linea del producto
                    _descTotLineaDev = Convert.ToDecimal(this.dgvDetalleFacturaOriginal.Rows[rows].Cells["Desc_Tot_Linea"].Value);
                    _costTotalDolarDev = Convert.ToDecimal(this.dgvDetalleFacturaOriginal.Rows[rows].Cells["Costo_Total_Dolar"].Value);
                    _costoTotalDev = Convert.ToDecimal(this.dgvDetalleFacturaOriginal.Rows[rows].Cells["Costo_Total"].Value);
                    _costoTotalLocalDev = Convert.ToDecimal(this.dgvDetalleFacturaOriginal.Rows[rows].Cells["Costo_Total_Local"].Value);
                    _costoTotalCompDev = Convert.ToDecimal(this.dgvDetalleFacturaOriginal.Rows[rows].Cells["Costo_Total_Comp"].Value);
                    _costoTotalCompLocalDev = Convert.ToDecimal(this.dgvDetalleFacturaOriginal.Rows[rows].Cells["Costo_Total_Comp_Local"].Value);
                    _costoTotalCompDolarDev = Convert.ToDecimal(this.dgvDetalleFacturaOriginal.Rows[rows].Cells["Costo_Total_Comp_Dolar"].Value);
                    _precioTotalDev = Convert.ToDecimal(this.dgvDetalleFacturaOriginal.Rows[rows].Cells["Precio_Total"].Value);

                    this.dgvDetalleFacturaOriginal.Rows[rows].Cells["Costo_Total_Dolar_Dev"].Value = ((_costTotalDolarDev / _cantidad) * _cantidadDevolver).ToString("N2");
                    this.dgvDetalleFacturaOriginal.Rows[rows].Cells["Costo_Total_Dev"].Value = ((_costoTotalDev / _cantidad) * _cantidadDevolver).ToString("N4");
                    this.dgvDetalleFacturaOriginal.Rows[rows].Cells["Costo_Total_Local_Dev"].Value = ((_costoTotalLocalDev / _cantidad) * _cantidadDevolver).ToString("N4");
                    this.dgvDetalleFacturaOriginal.Rows[rows].Cells["Costo_Total_Comp_Dev"].Value = ((_costoTotalCompDev / _cantidad) * _cantidadDevolver).ToString("N4");
                    this.dgvDetalleFacturaOriginal.Rows[rows].Cells["Costo_Total_Comp_Local_Dev"].Value = ((_costoTotalCompLocalDev / _cantidad) * _cantidadDevolver).ToString("N4");
                    this.dgvDetalleFacturaOriginal.Rows[rows].Cells["Costo_Total_Comp_Dolar_Dev"].Value = ((_costoTotalCompDolarDev / _cantidad) * _cantidadDevolver).ToString("N2");

                    _descTotLineaDev = ((_descTotLineaDev / _cantidad) * _cantidadDevolver);
                    _precioTotalDev = (_precioUnitario * _cantidadDevolver) - _descTotLineaDev;
                    _descTotGeneralDev = (_precioTotalDev * (porCentajeDescGeneral / 100));


                    this.dgvDetalleFacturaOriginal.Rows[rows].Cells["Desc_Tot_Linea_Dev"].Value = _descTotLineaDev.ToString("N4");
                    this.dgvDetalleFacturaOriginal.Rows[rows].Cells["Desc_Tot_General_Dev"].Value = _descTotGeneralDev.ToString("N4");
                    this.dgvDetalleFacturaOriginal.Rows[rows].Cells["Precio_Total_Dev"].Value = _precioTotalDev.ToString("N4");

                    //sumar el total de las unidades
                    totalUnidades += _cantidad;
                    totalFacturaDevuelta += _precioTotalDev;

                }
                else
                {
                    this.dgvDetalleFacturaOriginal.Rows[rows].Cells["Costo_Total_Dolar_Dev"].Value = 0;
                    this.dgvDetalleFacturaOriginal.Rows[rows].Cells["Costo_Total_Dev"].Value = 0;
                    this.dgvDetalleFacturaOriginal.Rows[rows].Cells["Costo_Total_Local_Dev"].Value = 0;
                    this.dgvDetalleFacturaOriginal.Rows[rows].Cells["Costo_Total_Comp_Dev"].Value = 0;
                    this.dgvDetalleFacturaOriginal.Rows[rows].Cells["Costo_Total_Comp_Local_Dev"].Value = 0;
                    this.dgvDetalleFacturaOriginal.Rows[rows].Cells["Costo_Total_Comp_Dolar_Dev"].Value = 0;
                    this.dgvDetalleFacturaOriginal.Rows[rows].Cells["Desc_Tot_Linea_Dev"].Value = 0;
                    this.dgvDetalleFacturaOriginal.Rows[rows].Cells["Desc_Tot_General_Dev"].Value = 0;
                    this.dgvDetalleFacturaOriginal.Rows[rows].Cells["Precio_Total_Dev"].Value = 0;
                }

            }

            montDescuento = Math.Round(totalFacturaDevuelta * (porCentajeDescGeneral / 100), 4);
            //obtener el total de la factura - descuento
            totalFacturaDevuelta = Math.Round(totalFacturaDevuelta - montDescuento, 4);
            totalMercaderia = totalFacturaDevuelta + montDescuento;

            //mostrar en pantalla el descuento
            this.txtDescuento.Text = montDescuento.ToString("N2");
            //obtener el total de la factura - descuento;
            this.txtTotalAcumulado.Text = totalFacturaDevuelta.ToString("N2");
        }


        private async void btnAceptar_Click(object sender, EventArgs e)
        {
            if (VerificacionCantidadesExitosa())
            {
                RecolectarRegistroDevolucion();

                if (MessageBox.Show("¿ Desea Guardar la Devolucion ?", "Sistema COVENTAF", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (AutorizacionExitosa())
                    {
                        try
                        {
                            ResponseModel responseModel = new ResponseModel();
                            responseModel = await _serviceDevolucion.GuardarDevolucion(_devolucion, responseModel);
                            if (responseModel.Exito == 1)
                            {
                                MessageBox.Show("La Devolucion se ha regitrado exitosamente", "Sistema COVENTAF");
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show(responseModel.Mensaje);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Sistema COVENTAF");
                        }

                    }
                }
            }
        }


        private bool AutorizacionExitosa()
        {
            var frmAutorizacion = new frmAutorizacion();
            frmAutorizacion.ShowDialog();
            if (frmAutorizacion.resultExitoso)
                return true;
            else
                return false;

        }

        private void RecolectarRegistroDevolucion()
        {

            _devolucion.Factura.Caja = User.Caja;
            _devolucion.Factura.Usuario = User.Usuario;
            _devolucion.Factura.Num_Cierre = User.ConsecCierreCT;
            _devolucion.Factura.Tipo_Original = _devolucion.Factura.Tipo_Documento;
            _devolucion.Factura.Total_Factura = Math.Round(totalFacturaDevuelta, 4);
            _devolucion.Factura.Monto_Descuento1 = montDescuento;
            _devolucion.Factura.Total_Mercaderia = totalMercaderia;
            _devolucion.Factura.Total_Unidades = totalUnidades;
            _devolucion.Factura.Observaciones = this.txtObservaciones.Text;
            _devolucion.Factura.Forma_Pago = this.cboTipoPago.SelectedValue.ToString();

            for (var rows = 0; rows < dgvDetalleFacturaOriginal.RowCount; rows++)
            {
                string articuloId = this.dgvDetalleFacturaOriginal.Rows[rows].Cells["ArticuloId"].Value.ToString();
                decimal cantidadDevolver = Convert.ToDecimal(this.dgvDetalleFacturaOriginal.Rows[rows].Cells["CantidadDevolver"].Value);


                //comprobar si cantidadDevolver es mayor que cero
                if (cantidadDevolver > 0)
                {

                    for (var fila = 0; fila < _devolucion.FacturaLinea.Count; fila++)
                    {
                        if (_devolucion.FacturaLinea[fila].Articulo == articuloId)
                        {
                            _devolucion.FacturaLinea[fila].Cantidad_Devuelt = cantidadDevolver;
                            _devolucion.FacturaLinea[fila].Documento_Origen = factura;
                            _devolucion.FacturaLinea[fila].Caja = User.Caja;
                            _devolucion.FacturaLinea[fila].Desc_Tot_Linea = Convert.ToDecimal(this.dgvDetalleFacturaOriginal.Rows[fila].Cells["Desc_Tot_Linea_Dev"].Value);
                            _devolucion.FacturaLinea[fila].Costo_Total_Dolar = Convert.ToDecimal(this.dgvDetalleFacturaOriginal.Rows[fila].Cells["Costo_Total_Dolar_Dev"].Value);
                            _devolucion.FacturaLinea[fila].Costo_Total = Convert.ToDecimal(this.dgvDetalleFacturaOriginal.Rows[fila].Cells["Costo_Total_Dev"].Value);
                            _devolucion.FacturaLinea[fila].Costo_Total_Local = Convert.ToDecimal(this.dgvDetalleFacturaOriginal.Rows[fila].Cells["Costo_Total_Local_Dev"].Value);
                            _devolucion.FacturaLinea[fila].Costo_Total_Comp = Convert.ToDecimal(this.dgvDetalleFacturaOriginal.Rows[fila].Cells["Costo_Total_Comp_Dev"].Value);
                            _devolucion.FacturaLinea[fila].Costo_Total_Comp_Local = Convert.ToDecimal(this.dgvDetalleFacturaOriginal.Rows[fila].Cells["Costo_Total_Comp_Local_Dev"].Value);
                            _devolucion.FacturaLinea[fila].Costo_Total_Comp_Dolar = Convert.ToDecimal(this.dgvDetalleFacturaOriginal.Rows[fila].Cells["Costo_Total_Comp_Dolar_Dev"].Value);
                            _devolucion.FacturaLinea[fila].Precio_Total = Convert.ToDecimal(this.dgvDetalleFacturaOriginal.Rows[fila].Cells["Precio_Total_Dev"].Value);
                            _devolucion.FacturaLinea[fila].Desc_Tot_General = Convert.ToDecimal(this.dgvDetalleFacturaOriginal.Rows[fila].Cells["Desc_Tot_General_Dev"].Value);
                            _devolucion.FacturaLinea[fila].Documento_Origen = _devolucion.Factura.Factura;
                            _devolucion.FacturaLinea[fila].Tipo_Origen = _devolucion.Factura.Tipo_Documento;
                            break;
                        }
                    }
                }
            }

        }




        private bool VerificacionCantidadesExitosa()
        {
            int contadorCero = 0;
            bool verificacionCantidades = true;


            for (var rows = 0; rows < dgvDetalleFacturaOriginal.RowCount; rows++)
            {

                decimal cantidadDevolver = Convert.ToDecimal(this.dgvDetalleFacturaOriginal.Rows[rows].Cells["CantidadDevolver"].Value);
                decimal cantidad = Convert.ToDecimal(this.dgvDetalleFacturaOriginal.Rows[rows].Cells["Cantidad"].Value);

                if (cantidadDevolver > 0)
                {
                    contadorCero += 1;
                }

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
            //si la columna es cantidad a Devolver(13) 
            if (e.ColumnIndex == 13)
            {
                string mensaje = "";
                bool CantidadConDecimal = false;
                string cantidadDevolver = dgvDetalleFacturaOriginal.Rows[e.RowIndex].Cells["CantidadDevolver"].Value.ToString();
                //obtener la existencia del DataGridView
                decimal existencia = Convert.ToDecimal(dgvDetalleFacturaOriginal.Rows[e.RowIndex].Cells["Cantidad"].Value);
                //verificar si la unidad de medida del articulo permite punto decimal (ej.: 3.5)
                // bool CantidadConDecimal = (dgvDetalleFactura.Rows[consecutivoActualFactura].Cells["UnidadFraccion"].Value.ToString() == "S" ? true : false);
                if (!new ProcesoFacturacion().CantidadIsValido(dgvDetalleFacturaOriginal.Rows[e.RowIndex].Cells["CantidadDevolver"].Value.ToString(), CantidadConDecimal, ref mensaje))
                {
                    MessageBox.Show(mensaje, "Sistema COVENTAF", MessageBoxButtons.OK);
                    //asignarle la cantidad que tenia antes de editarla
                    dgvDetalleFacturaOriginal.Rows[e.RowIndex].Cells["CantidadDevolver"].Value = "0";
                }
                else if (Convert.ToDecimal(cantidadDevolver) > existencia)
                {
                    MessageBox.Show("La cantidad a devolver excede a la cantidad del articulo de la factura", "Sistema COVENTAF", MessageBoxButtons.OK);
                    //asignarle la cantidad que tenia antes de editarla
                    dgvDetalleFacturaOriginal.Rows[e.RowIndex].Cells["CantidadDevolver"].Value = "0";
                }
                else if (Convert.ToDecimal(cantidadDevolver) < 0)
                {
                    MessageBox.Show("La cantidad del articulo Devolver no puede ser negativo", "Sistema COVENTAF", MessageBoxButtons.OK);
                    //asignarle la cantidad que tenia antes de editarla
                    dgvDetalleFacturaOriginal.Rows[e.RowIndex].Cells["CantidadDevolver"].Value = "0";
                }
                {
                    //hacer el calculo
                    Calcular();
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
    }
}
