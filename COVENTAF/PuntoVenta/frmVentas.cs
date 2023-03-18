using Api.Model.Modelos;
using Api.Model.ViewModels;
using Api.Service.DataService;
using Controladores;
using COVENTAF.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COVENTAF.PuntoVenta
{
    public partial class frmVentas : Form
    {
        public bool cancelarFactura = false;
        public bool facturaGuardada = false;


        #region codigo para mover pantalla
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        #endregion

        #region logica para facturar
        //declaracion de las variables en una sola clase
        public varFacturacion listVarFactura = new varFacturacion();
        //campos del grid
        public List<DetalleFactura> listDetFactura = new List<DetalleFactura>();
        public List<Bodegas> listaBodega = new List<Bodegas>();


        public Clientes datosCliente = new Clientes();

        private int consecutivoActualFactura;
        private int columnaIndex;
        private decimal cantidadGrid;
        private decimal descuentoGrid;
        private bool AccederEventoCombox;

        private readonly ProcesoFacturacion _procesoFacturacion;
        #endregion

        private string TiendaID;
        private string BodegaID;
        private string NivelPrecio;
        private string MonedaNivel;

        
        private FacturaController _facturaController;
        private ServiceCliente _serviceCliente;
        private ArticulosController _articulosController;

        private ServiceFactura _serviceFactura = new ServiceFactura();

        ViewModelFacturacion _modelFactura = new ViewModelFacturacion();

        public frmVentas()
        {
            
            InitializeComponent();
           
            this._facturaController = new FacturaController();
            this._serviceCliente = new ServiceCliente();
            this._articulosController = new ArticulosController();
            this._procesoFacturacion = new ProcesoFacturacion();

        }

        #region codigo del diseño del formulario
        //private void barraTitulo_Paint(object sender, PaintEventArgs e)
        //{
        //    ReleaseCapture();
        //    SendMessage(this.Handle, 0x112, 0xf012, 0);
        //}


        private void barraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private async void btnCerrar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show($"¿ Estas seguro de abandonar factura {listVarFactura.NoFactura} ?", "Sistema COVENTAF", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Cursor = Cursors.WaitCursor;
                ResponseModel responseModel = new ResponseModel();
                responseModel = await _facturaController.CancelarNoFacturaBloqueada(listVarFactura.NoFactura);
                cancelarFactura = true;
                this.Cursor = Cursors.Default;
                this.Close();
            }
        }

        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.btnMaximizar.Visible = false;
            this.btnRestaurar.Visible = true;
        }

        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.btnRestaurar.Visible = false;
            this.btnMaximizar.Visible = true;
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }


        #endregion


        private void frmVentas_Load(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            TiendaID = User.TiendaID;
            BodegaID = User.BodegaID;
            NivelPrecio = User.NivelPrecio;
            MonedaNivel = User.MonedaNivel;

            //es una bandera para detener el evento al momento de iniciar el formulario
            AccederEventoCombox = false;
            //llenar los combox de la base de datos
            MostrarInformacionInicioFact();
            //inicializar todas las variables de la facturacion
            _procesoFacturacion.InicializarTodaslasVariable(listVarFactura);

            //agregar una nueva fila
            AddNewRow(listDetFactura);

            // Initialize and bind the DataGridView.
            this.dgvDetalleFactura.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetalleFactura.AutoGenerateColumns = true;
            //asignar la lista
            dgvDetalleFactura.DataSource = listDetFactura;

            listDetFactura.RemoveAt(0);
            dgvDetalleFactura.DataSource = null;
            dgvDetalleFactura.DataSource = listDetFactura;

            _procesoFacturacion.configurarDataGridView(this.dgvDetalleFactura);


            this.btnCobrar.Enabled = false;
            this.txtDescuentoGeneral.Enabled = this.chkDescuentoGeneral.Checked;
            this.Cursor = Cursors.Default;
        }




        //agregar un registro en el arreglo
        void AddNewRow(List<DetalleFactura> listDetFactura)
        {

            //obtener el numero consecutivo del
            var numConsecutivo = listDetFactura.Count;
            var datosd_ = new DetalleFactura()
            {
                Consecutivo = numConsecutivo,
                ArticuloId = "",
                //inputArticuloDesactivado = true,
                CodigoBarra = "",
                Cantidad = "1.00",
                Cantidadd = 1.00M,
                PorCentajeDescXArticulo = "0.00",               
                PorCentajeDescXArticulod = 0.00M,
                Unidad = "",
                Descripcion = "",
                CantidadExistencia = 0,
                //InputCantidadDesactivado = false,
                PrecioDolar = 0.00M,
                PrecioCordobas = 0.00M,
                Moneda = '-',
                SubTotalDolar = 0.00M,
                SubTotalCordobas = 0.00M,
                
                //descuentoInactivo = 0.00M,
                DescuentoPorLineaDolar = 0.00M,
                DescuentoPorLineaCordoba = 0.00M,
                MontoDescGeneralDolar = 0.0000M,
                MontoDescGeneralCordoba = 0.0000M,
                TotalDolar = 0.00M,
                TotalCordobas = 0.00M,
                Cost_Prom_Dol = 0.0000M,
                Cost_Prom_Loc = 0.0000M
                //inputActivoParaBusqueda = true,
                //botonEliminarDesactivado = true
            };

            //agregar push para agregar un nuevo registro en los arreglos.
            listDetFactura.Add(datosd_);

        }



        public async void MostrarInformacionInicioFact()
        {
            var listarDatosFactura = new ListarDatosFactura();
            //se refiere a la bodega. mal configurado en base de datos
            listarDatosFactura.bodega = new List<Bodegas>();
            listarDatosFactura.NoFactura = "";

            try
            {
                listarDatosFactura = await _serviceFactura.ListarInformacionInicioFactura();
                if (listarDatosFactura.Exito == 1)
                {
                    listVarFactura.TipoDeCambio = Math.Round(listarDatosFactura.tipoDeCambio, 4);
                    this.lblNoFactura.Text = $"No. Factura: {listarDatosFactura.NoFactura}";
                    listVarFactura.NoFactura = listarDatosFactura.NoFactura;
                    this.lblFecha.Text = $"Fecha: {DateTime.Now.ToString("dd/MM/yyyy")}";
                    //asignar el tipo de cambio
                    this.lblTipoCambio.Text = $"Tipo Cambio: {listarDatosFactura.tipoDeCambio.ToString("N4")}";
                    //asignar la lista de bodega
                    this.listaBodega = listarDatosFactura.bodega;


                    //llenar el combox de la bodega
                    this.cboBodega.ValueMember = "Bodega";
                    this.cboBodega.DisplayMember = "Nombre";
                    this.cboBodega.DataSource = listaBodega;

                    //asignar la bodega por defecto
                    this.cboBodega.SelectedValue = User.BodegaID;
                    AccederEventoCombox = true;

                    this.txtCodigoCliente.SelectionStart = 0;
                    this.txtCodigoCliente.SelectionLength = this.txtCodigoCliente.Text.Length;
                    this.txtCodigoCliente.Focus();
                }
                else
                {
                    MessageBox.Show(listarDatosFactura.Mensaje, "Sistema COVENTAF");
                    this.Close();
                }

                this.Cursor = Cursors.Default;

            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                //-1 indica que existe algun error del servidor
                listarDatosFactura.Exito = -1;
                listarDatosFactura.Mensaje = ex.Message;
            }
        }

        //evento KeyPress para buscar el codigo del cliente.
        private async void txtCodigoCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            //comprobar si presionaste la tecla enter
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                if (this.txtCodigoCliente.Text.Trim().Length != 0)
                {
                    this.Cursor = Cursors.WaitCursor;
                    e.Handled = true;                    
                    var responseModel = new ResponseModel();
                    responseModel = await this._serviceCliente.ObtenerClientePorIdAsync(this.txtCodigoCliente.Text, responseModel);

                    if (responseModel.Exito == 1)
                    {
                        datosCliente = responseModel.Data as Clientes;
                        //asignar los datos del cliente
                        _procesoFacturacion.asignarDatoClienteParaVisualizarHtml(datosCliente, listVarFactura);
                        //asignar el codigo del cliente
                        listVarFactura.CodigoCliente = datosCliente.Cliente;
                        this.txtNombreCliente.Text = datosCliente.Nombre;
                        this.txtDisponibleCliente.Text = "C$ " + Convert.ToDecimal(datosCliente.U_U_SaldoDisponible).ToString("N2");
                        this.txtDescuentoCliente.Text = Convert.ToDecimal(datosCliente.U_U_Descuento/100).ToString("P2");                        
                        this.txtCreditoCortoPlazo.Text = Convert.ToDecimal(datosCliente.U_U_Credito2Disponible).ToString("N2");

                        //desactivar el input de busqueda de cliente
                        this.txtCodigoCliente.Enabled = false;
                        //poner el focus en el textboxarticulo              
                        this.txtCodigoBarra.Focus();
                    }                   
                    else
                    {
                        MessageBox.Show(responseModel.Mensaje, "Sistema COVENTAF");
                    }

                    this.Cursor = Cursors.Default;
                }
                else
                {
                    MessageBox.Show("Debes de digitar el codigo del cliente", "Sistema COVENTAF");
                }

            }
        }

        //buscar el articulo en la base de datos
        private async void onBuscarArticulo()
        {           
            //obtener el codigo de barra del datgrid
            var codigoArticulo = txtCodigoBarra.Text;

            try
            {
                if (codigoArticulo.Trim().Length != 0)
                {
                    this.Cursor = Cursors.WaitCursor;
                    //desactivar la bodega
                    this.cboBodega.Enabled = false;
                    var responseModel = new ResponseModel();

                    responseModel = await this._articulosController.ObtenerArticuloPorIdAsync(codigoArticulo, this.cboBodega.SelectedValue.ToString(), User.NivelPrecio);
                    //respuesta exitosa
                    if (responseModel.Exito == 1)
                    {
                        
                        ViewModelArticulo articulo = new ViewModelArticulo();
                        //obtener los datos de la vista del articulo
                        articulo = responseModel.Data as ViewModelArticulo;
                        this.txtDescripcionArticulo.Text = articulo.Descripcion;

                        //comprobar si hay en existencia
                        if (articulo.Existencia > 0)
                        {
                            //agregar a la tabla del detalle de la factura
                            onAgregarArticuloDetalleFactura(articulo);
                            chkDescuentoGeneral.Enabled = true;

                        }
                        else
                        {
                            MessageBox.Show("No existe en el inventario el articulo", "Sistema COVENTAF");
                            LimpiarTextBoxBusquedaArticulo();
                        }
                    }
                    //si el servidor responde exito con 0 (0= el articulo no existe en la base de dato)         
                    else if (responseModel.Exito == 0)
                    {
                        //mostrar un mensaje de notificacion                  
                        MessageBox.Show(responseModel.Mensaje, "Sistema COVENTAF");

                    }
                    else
                    {
                        //notifica cualquier error que el servidor envia
                        MessageBox.Show(responseModel.Mensaje, "Sistema COVENTAF");
                    }
                    this.Cursor = Cursors.Default;
                }
                else
                {
                    MessageBox.Show("Ingrese el codigo del articulo", "Sistema COVENTAF");
                }
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show(ex.Message, "Sistema COVENTAF");
            }

           
        }



        //este evento se ejecuta cuando intenta cambiar un valor en la columna del grid
        private void dgvDetalleFactura_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            ////columna Cantidad
            //if (e.ColumnIndex == 4)
            //{
            //    //verifica si el valor es Double
            //    bool isDouble = double.TryParse(e.FormattedValue.ToString(), out double resultadoNumerico);

            //    if (isDouble)
            //    {

            //    }
            //    else
            //    {
            //        e.Cancel = true;
            //    }
            //}
        }



        //actualizar las cantidades
        //void ActualizarCantidades(decimal cantidad)
        //{

        //    //validar la existencia en inventario.
        //    if (listDetFactura[consecutivoActualFactura].CantidadExistencia < cantidad)
        //    {                
        //        MessageBox.Show("La cantidad digitada supera la existencia", "Sistema COVENTAF");
        //        return;
        //    }

        //    listDetFactura[consecutivoActualFactura].Cantidadd = cantidad;
        //    listDetFactura[consecutivoActualFactura].Cantidad = cantidad.ToString();

        //    //hacer los calculos de totales
        //    onCalcularTotales();

        //    GuardarBaseDatosFacturaTemp();
        //}

        //metodo para calcular los totales. la variable calculoIsAutomatico es automatico es para que el sistema tome desiciones 
        void onCalcularTotales(bool calculoIsAutomatico = true)
        {

            bool calcularOtraVez;

            do
            {
                //es una bandera para detener el ciclo
                calcularOtraVez = false;
                //inicializar valor de la       
                _procesoFacturacion.InicializarVariableTotales(listVarFactura);
                /* subTotalDolar=0.0000; subTotalCordoba=0.0000;
                 //let descuento:number=0.00;
                 descuentoDolar=0.0000; descuentoCordoba = 0.0000;    
                 subTotalDescuentoDolar=0.0000; subTotalDescuentoCordoba =0.0000;
                 ivaCordoba = 0.0000; ivaDolar= 0.0000;    
                 totalDolar= 0.0000; totalCordobas=0.0000;
                 totalUnidades=0; */


                foreach (var detfact in listDetFactura)
                {
                    #region calculos detallados por cada articulo
                    /***************************************************************** calculos detallados por cada articulo  *******************************************************************/
                    /*********************** cantidad por precios dolares y cordobas *************************************************************/
                    //cantidad * precio en Dolares  por cada fila
                    detfact.SubTotalDolar = detfact.Cantidadd * detfact.PrecioDolar;
                    //precio cordobas 
                    detfact.SubTotalCordobas = detfact.Cantidadd * detfact.PrecioCordobas;
                    /***************************************************************************************************************************/

                    /*********************** descuento por cada articulo articulo en dolares y cordobas ****************************************************/
                    //asignar el descuento por cada fila para el descuentoDolar
                    detfact.DescuentoPorLineaDolar = (detfact.SubTotalDolar * (detfact.PorCentajeDescXArticulod / 100));
                    //asignar el descuento por cada fila para el descuentoCordoba
                    detfact.DescuentoPorLineaCordoba = (detfact.SubTotalCordobas * (detfact.PorCentajeDescXArticulod / 100));
                    /*************************************************************************************************************************/

                    /*********************** total (restando el descuento x articulo) por articulo en dolares y cordobas ****************************************************/
                    //la resta del subTotal menos y subTotal de descuento            
                    detfact.TotalDolar = detfact.SubTotalDolar - detfact.DescuentoPorLineaDolar;
                    //la resta del subTotal menos y subTotal de descuento cordoba
                    detfact.TotalCordobas = detfact.SubTotalCordobas - detfact.DescuentoPorLineaCordoba;
                    /*************************************************************************************************************************/

                    /************************ descuento general por linea dolares y cordobas ************************************************/
                    //aplicar el descuento general si existe.
                    detfact.MontoDescGeneralDolar = detfact.TotalDolar * (listVarFactura.PorCentajeDescGeneral / 100.00M);
                    //aplicar el descuento general si existe. esto solo aplica para cordobas
                    detfact.MontoDescGeneralCordoba = detfact.TotalCordobas * (listVarFactura.PorCentajeDescGeneral / 100.00M);
                    /***********************************************************************************************************************/
                    /***************************************************************** fin *******************************************************************/
                    #endregion


                    /********************** sub totales en cordobas y dolares  ****************************************************************/
                    //suma de los subTotales de la lista de articulos en dolares
                    listVarFactura.SubTotalDolar += detfact.TotalDolar;
                    //suma de los subTotales de la lista de articulos en cordobas
                    listVarFactura.SubTotalCordoba += detfact.TotalCordobas;
                    /*************************************************************************************************************************/


                    //yo lo desactive ahora 15/02/2023
                    /************************ descuento general por linea dolares y cordobas ************************************************/
                    //aplicar el descuento general si existe. esto solo aplica para cordobas
                    //detfact.descuentoGeneralDolar = detfact.subTotalDolar * (listVarFactura.AplicarDescuentoGeneral/100.00M);                    
                    //aplicar el descuento general si existe. esto solo aplica para cordobas
                    //detfact.descuentoGeneralCordoba = detfact.subTotalCordobas * (listVarFactura.AplicarDescuentoGeneral/100.00M);
                    /***********************************************************************************************************************/


                    ////obtener la suma de los descuento x cada articulo de la lista
                    //listVarFactura.DescuentoDolar += detfact.descuentoDolar  ;
                    ////obtener la suma de los descuento de la lista
                    //listVarFactura.DescuentoCordoba += detfact.descuentoCordoba;





                    /************************ sumar el descuento general (beneficio del cliente) dolares y cordobas ************************************************/
                    //sumar el descuento general en dolares
                    //listVarFactura.DescuentoGeneralDolar += detfact.descuentoGeneralDolar;
                    ////sumar el descuento general en cordobas
                    //listVarFactura.DescuentoGeneralCordoba += detfact.descuentoGeneralCordoba;
                    /***********************************************************************************************************************/

                    ////suma total dolar
                    //sumaTotalDolar += detfact.totalDolar;
                    ////suma total cordobas
                    //sumaTotalCordoba += detfact.totalCordobas;

                    //sumar el total de las unidades
                    listVarFactura.TotalUnidades += detfact.Cantidadd;

                    //establecer dos decimales a la variable de tipo decimal
                    detfact.CantidadExistencia = Math.Round(detfact.CantidadExistencia, 2);
                    detfact.PrecioDolar = Math.Round(detfact.PrecioDolar, 2);
                    detfact.PrecioCordobas = Math.Round(detfact.PrecioCordobas, 4);
                    detfact.SubTotalDolar = Math.Round(detfact.SubTotalDolar, 2);
                    detfact.SubTotalCordobas = Math.Round(detfact.SubTotalCordobas, 4);
                    detfact.PorCentajeDescXArticulod = Math.Round(detfact.PorCentajeDescXArticulod, 2);
                    //detfact.descuentoInactivo = Math.Round(detfact.descuentoInactivo, 2);
                    detfact.DescuentoPorLineaDolar = Math.Round(detfact.DescuentoPorLineaDolar, 2);
                    detfact.DescuentoPorLineaCordoba = Math.Round(detfact.DescuentoPorLineaCordoba, 4);
                    detfact.MontoDescGeneralDolar = Math.Round(detfact.MontoDescGeneralDolar, 2);
                    detfact.MontoDescGeneralCordoba = Math.Round(detfact.MontoDescGeneralCordoba, 4);
                    detfact.TotalDolar = Math.Round(detfact.TotalDolar, 2);
                    detfact.TotalCordobas = Math.Round(detfact.TotalCordobas, 4);

                }

                /******* TEXTBOX SUB TOTALES DOLARES Y CORDOBAS ***************************************************/
                this.txtSubTotalDolares.Text = $"U$ {listVarFactura.SubTotalDolar.ToString("N2") }";
                this.txtSubTotalCordobas.Text = $"C$ {listVarFactura.SubTotalCordoba.ToString("N2") }";
                /*****************************************************************************************************/

                /******* TEXTBOX DESCUENTO GENERAL  DOLAR Y CORDOBA ********************************************/
                //hacer el calculo para el descuento general
                listVarFactura.DescuentoGeneralDolar = listVarFactura.SubTotalDolar * (listVarFactura.PorCentajeDescGeneral / 100);
                listVarFactura.DescuentoGeneralCordoba = listVarFactura.SubTotalCordoba * (listVarFactura.PorCentajeDescGeneral / 100);

                this.txtDescuentoDolares.Text = $"U$ {listVarFactura.DescuentoGeneralDolar.ToString("N2")}";
                this.txtDescuentoCordobas.Text = $"C$ {listVarFactura.DescuentoGeneralCordoba.ToString("N2")}";
                /*****************************************************************************************************/


                /******* TEXTBOX SUB TOTAL DESCUENTO DOLARES Y CORDOBAS *************************************************/
                //restar del subtotal descuento Dolar - descuento del beneficio Dolar
                listVarFactura.SubTotalDescuentoDolar = listVarFactura.SubTotalDolar - listVarFactura.DescuentoGeneralDolar;
                ////restar del subtotal descuento Cordoba - descuento del beneficio Cordoba
                listVarFactura.SubTotalDescuentoCordoba = listVarFactura.SubTotalCordoba - listVarFactura.DescuentoGeneralCordoba;

                this.txtSubTotalDescuentoDolares.Text = $"U$ {listVarFactura.SubTotalDescuentoDolar.ToString("N2")}";
                this.txtSubTotalDescuentoCordoba.Text = $"C$ {listVarFactura.SubTotalDescuentoCordoba.ToString("N2")}";
                /*************************************************************************************************************/

                /******* TEXTBOX IVA DOLARES Y CORDOBAS **********************************************************************************/
                //llamar al metodo obtener iva para identificar si al cliente se le cobra iva
                listVarFactura.IvaDolar = listVarFactura.SubTotalDescuentoDolar * obtenerIVA(datosCliente);
                listVarFactura.IvaCordoba = listVarFactura.SubTotalDescuentoCordoba * obtenerIVA(datosCliente);
                this.txtIVADolares.Text = $"U$ {listVarFactura.IvaDolar.ToString("N2")}";
                this.txtIVACordobas.Text = $"C$ {listVarFactura.IvaCordoba.ToString("N2")}";
                /*************************************************************************************************************************/

                /*********************TEXTBOX TOTAL EN DOLARES Y CORDOBAS ****************************************************************/
                listVarFactura.TotalDolar = listVarFactura.SubTotalDescuentoDolar + listVarFactura.IvaDolar;
                listVarFactura.TotalCordobas = listVarFactura.SubTotalDescuentoCordoba + listVarFactura.IvaCordoba;

                this.txtTotalDolares.Text = "U$ " + listVarFactura.TotalDolar.ToString("N2");
                this.txtTotalCordobas.Text = "C$ " + listVarFactura.TotalCordobas.ToString("N2");
                /*************************************************************************************************************************/


            } while (calcularOtraVez);

            try
            {
                //actualizar el datagridView      
                LlenarGridviewDetalleFactura();
                _procesoFacturacion.configurarDataGridView(this.dgvDetalleFactura);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Sistema COVENTAF");
            }
        }

        //actualiza el estado e intercambia con los descuento de los registro del detalle de factura
        //void activarIntercambiarDescuentoLinea(varFacturacion listVarFactura, List<DetalleFactura> detallefact)
        //{
        //    //verifico que el estado de la variable descuentoActivo este desactivada
        //    if (!listVarFactura.DescuentoActivo)
        //    {
        //        //activar
        //        listVarFactura.DescuentoActivo = true;
        //        //intercarmbiar los descuentos si existiera 
        //        setAcitvoOrDesactivoDescPorLinea(detallefact, listVarFactura.DescuentoActivo);
        //    }

        //}

        //agregar el articulo al detalle de la factura
        private void onAgregarArticuloDetalleFactura(ViewModelArticulo articulo)
        {
            //comprobar si existe el articulo
            if (onExisteArticuloDetFactura(listDetFactura, articulo.CodigoBarra, articulo.BodegaID) == "NO_EXIST_ARTICULO")
            {
               
                //crear una nueva fila en el datagrid
                AddNewRow(listDetFactura);
                consecutivoActualFactura = dgvDetalleFactura.RowCount;

                //cantidad del articulo
                decimal cantidad = Convert.ToDecimal(listDetFactura[consecutivoActualFactura].Cantidadd);

                //precio del articulo
                decimal precioDolar = 0.0000M;
                decimal precioCordoba = 0.0000M;

                //si la moneda es Dolar
                if (articulo.Moneda == 'D')
                {
                    precioDolar = articulo.Precio;
                    precioCordoba = articulo.Precio * listVarFactura.TipoDeCambio;
                }
                else if (articulo.Moneda == 'L')
                {
                    //precio del articulo
                    precioCordoba = articulo.Precio;
                    precioDolar = articulo.Precio / listVarFactura.TipoDeCambio;
                }

                //agregar a la lista los calculos realizados
                listDetFactura[consecutivoActualFactura].ArticuloId = articulo.ArticuloID;
                listDetFactura[consecutivoActualFactura].CodigoBarra = articulo.CodigoBarra;               
                listDetFactura[consecutivoActualFactura].Descripcion = articulo.Descripcion;
                listDetFactura[consecutivoActualFactura].Unidad = articulo.UnidadVenta;
                listDetFactura[consecutivoActualFactura].UnidadFraccion = articulo.UnidadFraccion;
                listDetFactura[consecutivoActualFactura].Cantidad = cantidad.ToString();
                listDetFactura[consecutivoActualFactura].Cantidadd = cantidad;
                //existencia en inventario
                listDetFactura[consecutivoActualFactura].CantidadExistencia = articulo.Existencia;
                //listDetFactura[consecutivoActualFactura].inputCantidadDesactivado = true;
                listDetFactura[consecutivoActualFactura].PrecioDolar = precioDolar;
                listDetFactura[consecutivoActualFactura].PrecioCordobas = precioCordoba;
                listDetFactura[consecutivoActualFactura].PorCentajeDescXArticulo = Math.Round(articulo.Descuento, 2).ToString();
                listDetFactura[consecutivoActualFactura].PorCentajeDescXArticulod = Math.Round(articulo.Descuento, 2);
                //listDetFactura[consecutivoActualFactura].DescuentoInactivo = (listVarFactura.DescuentoActivo ? 0.00M : articulo.Descuento);
                //moneda D(Dolar) L(Local =Cordoba)
                listDetFactura[consecutivoActualFactura].Moneda = articulo.Moneda;
                //bodega
                listDetFactura[consecutivoActualFactura].BodegaID = articulo.BodegaID;
                //nombre de bodega
                listDetFactura[consecutivoActualFactura].NombreBodega = articulo.NombreBodega;
                listDetFactura[consecutivoActualFactura].Cost_Prom_Dol = articulo.Cost_Prom_Dol;
                listDetFactura[consecutivoActualFactura].Cost_Prom_Loc = articulo.Costo_Prom_Loc;

  
                //guardar la factura temporalmente                   
                GuardarBaseDatosFacturaTemp(consecutivoActualFactura);

                //llenar el grid detalle Factura
                LlenarGridviewDetalleFactura();

                LimpiarTextBoxBusquedaArticulo();                
            }
            else
            {
                /*
                //limpiar el textbox del grid
                dgvDetalleFactura.Rows[consecutivoActualFactura].Cells[3].Value = "";
                //poner el cursor en la siguiente celda de busqueda.
                dgvDetalleFactura.CurrentCell = dgvDetalleFactura.Rows[consecutivoActualFactura].Cells[3];*/
                LimpiarTextBoxBusquedaArticulo();

            }

            //hacer los calculos
            onCalcularTotales();
        }



        //comprobar si existe el articulo en detalle factura (datagrid)
        private string onExisteArticuloDetFactura(List<DetalleFactura> listDetFactura, string codigoBarra, string BodegaID)
        {
            int consecutivoLocalizado = 0;
            //esta variable indica si existe el articulo en la lista
            string resultado = "NO_EXIST_ARTICULO";

            foreach (var detFact in listDetFactura)
            {
                //comprobar si existe el codigo de barra en la lista y la bodega
                if (detFact.CodigoBarra == codigoBarra && detFact.BodegaID == BodegaID)
                {
                    consecutivoLocalizado = detFact.Consecutivo;
                    //asignar el indice localizado de la lista.
                    consecutivoActualFactura = consecutivoLocalizado;

                    //asignar las cantidad 
                    decimal cantidad = detFact.Cantidadd + 1.00M;
                    if (detFact.CantidadExistencia >= cantidad)
                    {
                        //sumarle un producto mas
                        detFact.Cantidadd = detFact.Cantidadd + 1.00M;
                        detFact.Cantidad = detFact.Cantidadd.ToString();
                        //obtener el subtotal en dolares
                        detFact.SubTotalDolar = Convert.ToDecimal(detFact.PrecioDolar * detFact.Cantidadd);

                        //obtener el subtotal en cordoba
                        detFact.SubTotalCordobas = detFact.PrecioCordobas * detFact.Cantidadd;
                        detFact.TotalDolar = detFact.SubTotalDolar;
                        detFact.TotalCordobas = detFact.SubTotalCordobas;
                        detFact.TotalCordobas = Math.Round(detFact.TotalCordobas, 2);

                        //indicador para saber que existe el articulo en la lista
                        resultado = "ARTICULO_EXISTE";
                        //rompe el ciclo
                    }
                    else
                    {
                        dgvDetalleFactura.CurrentCell = dgvDetalleFactura[3, consecutivoActualFactura];
                        //'Pinta de color azul la fila para indicar al usuario que esa celda está seleccionada (Opcional)
                        dgvDetalleFactura.Rows[consecutivoActualFactura].Selected = true;

                        resultado = "NO_EXISTE_INVENTARIO";
                        MessageBox.Show("Este articulo se ha agotado", "Sistema COVENTAF");
                    }
                    break;
                }
            }

            if (resultado == "ARTICULO_EXISTE")
            {
                //actualizar la informacion del grid
                /*dgvDetalleFactura.DataSource = null;
                dgvDetalleFactura.DataSource = listDetFactura;*/

                LlenarGridviewDetalleFactura();
                //configurar el grid
                _procesoFacturacion.configurarDataGridView(this.dgvDetalleFactura);
                //guardar en base datos informacion del registro actual
                GuardarBaseDatosFacturaTemp(consecutivoLocalizado);
            }

            return resultado;
        }

        private void LlenarGridviewDetalleFactura()
        {
            //limpiar el grid
            dgvDetalleFactura.DataSource = null;
            //dgvDetalleFactura.Columns.Clear();
            //asignar la lista detalle del articulo
            dgvDetalleFactura.DataSource = listDetFactura;
            //configurar Grid
            //configurarDataGridView();

            //dgvDetalleFactura.Columns["NombreDeUsuario"].Index;
            //comprobar si tiene registro la lista de detalle de factura
            if (listDetFactura.Count > 0)
            {
                // 'Mueve el cursor a dicha fila               
                //dgvDetalleFactura.CurrentCell = dgvDetalleFactura[3, consecutivoActualFactura];
                //'Pinta de color azul la fila para indicar al usuario que esa celda está seleccionada (Opcional)
                dgvDetalleFactura.Rows[consecutivoActualFactura].Selected = true;
            }
        }

        //poner el descuento
        //private decimal setDescuentoDetalleFactura(decimal descuento, bool descuentoActivo, bool activarDSD = false)
        //{
        //    decimal valorDescuento = 0.0000M;

        //    //si descuentoActivo es true y activar descuento sobre descuento (activarDSD) es true
        //    if ((descuentoActivo) || (activarDSD))
        //    {
        //        valorDescuento = (descuento / 100.0000M);
        //    }
        //    else if ((descuentoActivo) && !(activarDSD))
        //    {
        //        valorDescuento = 0.00M;
        //    }

        //    return valorDescuento;
        //}

        //activa o desactiva (intercambiar) los descuento por linea
      /*  void setAcitvoOrDesactivoDescPorLinea(List<DetalleFactura> detallefact, bool descuentoActivo)
        {
            foreach (var detFactura in detallefact)
            {
                //comprobar si se van activar los descuentos est
                if (descuentoActivo)
                {
                    var descuentoTemp = detFactura.DescuentoInactivo;
                    detFactura.DescuentoInactivo = detFactura.PorCentajeDescXArticulo;
                    detFactura.PorCentajeDescXArticulo = descuentoTemp;
                }
                else
                {
                    var descuentoTemp = detFactura.PorCentajeDescXArticulo;
                    detFactura.PorCentajeDescXArticulo = detFactura.DescuentoInactivo;
                    detFactura.DescuentoInactivo = descuentoTemp;
                }

            }
        }*/

        //verificar el saldo Disponible
        bool montoDescuentoBeneficioIsOk(decimal saldoDisponible, decimal descuentoFactura)
        {
            if (descuentoFactura <= saldoDisponible)
                return true;
            else //if (descuentoFactura > saldoDisponible)
                return false;
        }

        //verificar si el cliente paga IVA
        private decimal obtenerIVA(Clientes datosCliente)
        {
            decimal IVA = 0.0000M;
            if (datosCliente.Codigo_Impuesto == "IVA")
            {
                IVA = 0.15M;
            }

            return IVA;
        }

        ////verifico si existe en el detalle de factura el proximo input unico para ingresar el 
        //private bool onExisteInputUnicoParaProximaArticulo(List<DetalleFactura> listDetFactura)
        //{
        //    var existeInput = false;
        //    foreach (var detFact in listDetFactura)
        //    {
        //        //verifico si ya existe el unico input para hacer la busqueda en el detalle factura
        //        if (detFact.inputActivoParaBusqueda)
        //        {
        //            //indico que existe el input unico en el detalle de factura.
        //            existeInput = true;
        //            //romper el ciclo
        //            break;
        //        }
        //    }

        //    return existeInput;
        //}

        //guardar el registro temporalmente mientra esta haciendo la factura
        private async void GuardarBaseDatosFacturaTemp(int consecutivo )
        {
            //si la variable del parametro es (-1) entoneces toma el valor de la variable consecutivoActualFactura
            //de lo contrario toma el valor que viene del parametro y ese sera el consecutivo
            //var consecut = consecutivo == -1 ? consecutivoActualFactura : consecutivo;

            //comprobar si no si es inputUnicoSigArticulo activo
            //if (!listDetFactura[consecut].inputActivoParaBusqueda)
            //{
                var facturaTemporal = new Facturando
                {
                    Factura = listVarFactura.NoFactura,
                    ArticuloID = listDetFactura[consecutivo].ArticuloId,

                    CodigoCliente = this.txtCodigoCliente.Text,
                    //aqui le indico que no es una factura en espera
                    FacturaEnEspera = false,
                    Cajero = User.Usuario,
                    Caja = User.Caja,
                    NumCierre = User.ConsecCierreCT,
                    TiendaID = User.TiendaID,
                    FechaRegistro = DateTime.Now,
                    TipoCambio = listVarFactura.TipoDeCambio,

                    BodegaID = listDetFactura[consecutivo].BodegaID,
                    Consecutivo = Convert.ToInt32(listDetFactura[consecutivo].Consecutivo),

                    CodigoBarra = listDetFactura[consecutivo].CodigoBarra,

                    Cantidad = listDetFactura[consecutivo].Cantidadd,
                    Descripcion = listDetFactura[consecutivo].Descripcion,
                    Unidad = listDetFactura[consecutivo].Unidad,
                    Precio = listDetFactura[consecutivo].Moneda == 'L' ? listDetFactura[consecutivo].PrecioCordobas : listDetFactura[consecutivo].PrecioDolar,
                    Moneda = listDetFactura[consecutivo].Moneda.ToString(),
                    DescuentoLinea = listDetFactura[consecutivo].PorCentajeDescXArticulod,
                    DescuentoGeneral = listVarFactura.PorCentajeDescGeneral,
                    AplicarDescuento = this.chkDescuentoGeneral.Checked,
                    Observaciones = this.txtObservaciones.Text

                };

                ResponseModel responseModel = new ResponseModel();
                responseModel = await _serviceFactura.InsertOrUpdateFacturaTemporal(facturaTemporal, responseModel);

            //}

        }



        /* private void dgvDetalleFactura_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
         {
             TextBox textbox = e.Control as TextBox;
             if (textbox != null)
             {
                 textbox.KeyPress -= new KeyPressEventHandler(dgvDetalleFactura_KeyPress);
                 textbox.KeyPress += new KeyPressEventHandler(dgvDetalleFactura_KeyPress);
             }
         }*/

        //evento KeyPress del Grid
        /* private void dgvDetalleFactura_KeyPress(object sender, KeyPressEventArgs e)
         {
             //identificar el numero de la columna                 
             int numColumn = dgvDetalleFactura.CurrentCell.ColumnIndex;
             //identificar el numero de la fila
             int numRow = dgvDetalleFactura.CurrentCell.RowIndex;
             //asignar el numero de fila en donde esta ubicado el cursor. 
             consecutivoActualFactura = numColumn;

             //3 es codigo de barra del articulo
            if (numColumn == 3)
             {
                 if (e.KeyChar == (char)13) // Si es un enter
                 {
                     onBuscarArticulo();
                     e.Handled = true; //Interceptamos la pulsación
                     SendKeys.Send("{TAB}"); //Pulsamos la tecla Tabulador por código
                 }
             }

             //if (numColumn == dataGridView1.Columncount - 1)
             //{
             //    if (dataGridView1.RowCount > (numRow + 1))
             //    {
             //        dataGridView1.CurrentCell = dataGridView1[1, numRow + 1];
             //    }
             //}
             //else
             //    dataGridView1.CurrentCell = dataGridView1[numColumn + 1, numRow];

         }*/



        private void txtCodigoBarra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13) // Si es un enter
            {
                e.Handled = true;
                onBuscarArticulo();
            }
        }



        //eliminar el articulo de la lista de detalle de factura
        private void onEliminarArticulo(string articuloId, int consecutivo)
        {
            this.btnCobrar.Enabled = false;

            //asignar el numero consecutivo del articulo
            consecutivoActualFactura = consecutivo;

            //proceder a eliminar el articulo        
            eliminarProductoFactura(listDetFactura, listVarFactura.NoFactura, articuloId, consecutivo);
            //calcular los totales        
            onCalcularTotales();

            LimpiarTextBoxBusquedaArticulo();
        }


        public async void eliminarProductoFactura(List<DetalleFactura> detalleFactura, string noFactura, string articuloId, int consecutivo)
        {
            //eliminar el registro de la lista.
            detalleFactura.RemoveAt(consecutivo);
            int rows = 0;

            foreach (var prod in detalleFactura)
            {
                //actualizar el consecutivo de la lista
                prod.Consecutivo = rows;
                rows += 1;
            }
            //actualizar el consecutivo
            consecutivoActualFactura = detalleFactura.Count - 1;

            ResponseModel responseModel = new ResponseModel();
            //eliminar de la tabla temporal el articulo
            responseModel = await _facturaController.EliminarArticuloDetalleFacturaAsync(noFactura, articuloId);

            /*dgvDetalleFactura.DataSource = null;
            dgvDetalleFactura.DataSource = listDetFactura;*/
            //lenar el grid 
            LlenarGridviewDetalleFactura();
            _procesoFacturacion.configurarDataGridView(this.dgvDetalleFactura);
        }

        private void LimpiarTextBoxBusquedaArticulo()
        {
            txtDescripcionArticulo.Text = "";
            //limpiar el buscador del articulo
            txtCodigoBarra.Text = "";
            //poner el focus en txtCodigoBarra
            txtCodigoBarra.Focus();
        }

        private void dgvDetalleFactura_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

            //si la columna es cantidad (3) o descuento(4)
            if (e.ColumnIndex == 3 || e.ColumnIndex == 4)
            {
                btnCobrar.Enabled = false;
                //asignar el consucutivo para indicar en que posicion estas
                consecutivoActualFactura = e.RowIndex;
                validarCantidadGrid();
                //calcular totales
                onCalcularTotales();
            }
        }


        private void dgvDetalleFactura_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnCobrar.Enabled = false;
            //obtener el consecutivo
            int index = e.RowIndex;
            int columna = e.ColumnIndex;

            consecutivoActualFactura = index;
            columnaIndex = columna;

            if (index != -1 && columna != -1)
            {
                //(columna 3) es cantidad
                //columna Cantidad del DataGridView (columna=4)

                if (columnaIndex == 3)                
                //if (dgvDetalleFactura.Columns["Cantidad"].HeaderText == "Cantidad")
                {
                    //antes de editar guardar temporalmente la cantidad en la variable  cantidadGrid por si la cantidad excede lo que digita el cajero, entonce regresa al valor 
                    cantidadGrid = Convert.ToDecimal(dgvDetalleFactura.Rows[consecutivoActualFactura].Cells[columnaIndex].Value);
                }
                
                //(columna 4) es descuento
                else if (columnaIndex == 4)
                //else if (dgvDetalleFactura.Columns["Descuento %"].HeaderText == "Descuento %")
                {
                    //antes de editar guardar temporalmente la cantidad en la variable  cantidadGrid
                    descuentoGrid = Convert.ToDecimal(dgvDetalleFactura.Rows[consecutivoActualFactura].Cells[columnaIndex].Value);
                }
            }
        }

        void validarCantidadGrid()
        {
            //verificar que los consecutivoActualFactura y columnaIndex no tenga
            if (consecutivoActualFactura != -1 && columnaIndex != -1)
            {
                string mensaje = "";

                switch (columnaIndex)
                {
                    //3
                    //columna Cantidad del DataGridView (columna=3)                   
                    case 3:
                        //obtener la cantidad del DataGridView
                        string cantidad = dgvDetalleFactura.Rows[consecutivoActualFactura].Cells[columnaIndex].Value.ToString();
                        //obtener la existencia del DataGridView
                        decimal existencia = Convert.ToDecimal(dgvDetalleFactura.Rows[consecutivoActualFactura].Cells[7].Value);
                        //verificar si la unidad de medida del articulo permite punto decimal (ej.: 3.5)
                        bool CantidadConDecimal = (dgvDetalleFactura.Rows[consecutivoActualFactura].Cells["UnidadFraccion"].Value.ToString() == "S" ? true : false);
                        if (!_procesoFacturacion.CantidadIsValido(dgvDetalleFactura.Rows[consecutivoActualFactura].Cells[columnaIndex].Value.ToString(), CantidadConDecimal, ref mensaje ))
                        {
                            MessageBox.Show(mensaje, "Sistema COVENTAF", MessageBoxButtons.OK);
                            //asignarle la cantidad que tenia antes de editarla
                            dgvDetalleFactura.Rows[consecutivoActualFactura].Cells[columnaIndex].Value = dgvDetalleFactura.Rows[consecutivoActualFactura].Cells[24].Value.ToString();
                        }
                        else if (Convert.ToDecimal(cantidad) > existencia)
                        {
                            MessageBox.Show("La cantidad digitada excede a la existencia del articulo", "Sistema COVENTAF", MessageBoxButtons.OK);
                            //asignarle la cantidad que tenia antes de editarla
                            dgvDetalleFactura.Rows[consecutivoActualFactura].Cells[columnaIndex].Value = cantidadGrid;
                        }
                        else if (Convert.ToDecimal(cantidad)< 0)
                        {
                            MessageBox.Show("La cantidad del articulo no puede ser negativo", "Sistema COVENTAF", MessageBoxButtons.OK);
                            //asignarle la cantidad que tenia antes de editarla
                            dgvDetalleFactura.Rows[consecutivoActualFactura].Cells[columnaIndex].Value = dgvDetalleFactura.Rows[consecutivoActualFactura].Cells[24].Value.ToString();
                        }
                        else if (Convert.ToDecimal(cantidad) == 0)
                        {
                            MessageBox.Show("La cantidad del articulo no puede ser cero", "Sistema COVENTAF", MessageBoxButtons.OK);
                            //asignarle la cantidad que tenia antes de editarla
                            dgvDetalleFactura.Rows[consecutivoActualFactura].Cells[columnaIndex].Value = dgvDetalleFactura.Rows[consecutivoActualFactura].Cells[24].Value.ToString();
                        }
                        else
                        {
                            //de lo contrario actualizar la cantidad de tipo decimal
                            dgvDetalleFactura.Rows[consecutivoActualFactura].Cells["cantidadd"].Value = Convert.ToDecimal(dgvDetalleFactura.Rows[consecutivoActualFactura].Cells[3].Value);
                            GuardarBaseDatosFacturaTemp(consecutivoActualFactura);
                        }
                        break;

                    //columna descuento
                    case 4:
                        //asignar en la varibla el descuento que tiene el DataGridView
                        string descuento = dgvDetalleFactura.Rows[consecutivoActualFactura].Cells[columnaIndex].Value.ToString();
                        if (!_procesoFacturacion.PorCentajeIsValido(dgvDetalleFactura.Rows[consecutivoActualFactura].Cells[columnaIndex].Value.ToString(), ref mensaje))
                        {
                            MessageBox.Show(mensaje, "Sistema COVENTAF", MessageBoxButtons.OK);
                            //asignarle la cantidad que tenia antes de editarla
                            dgvDetalleFactura.Rows[consecutivoActualFactura].Cells[columnaIndex].Value = dgvDetalleFactura.Rows[consecutivoActualFactura].Cells[25].Value;
                        }
                        //comprobar que el descuento no sea negativo
                        else if (Convert.ToDecimal(descuento) < 0)
                        {
                            MessageBox.Show("El descuento del articulo no puede ser negativo", "Sistema COVENTAF", MessageBoxButtons.OK);
                            //asignarle la cantidad que tenia antes de editarla
                            dgvDetalleFactura.Rows[consecutivoActualFactura].Cells[columnaIndex].Value = dgvDetalleFactura.Rows[consecutivoActualFactura].Cells[25].Value;
                        }
                        //validar que el descuento no exceda del 100%
                        else if (Convert.ToDecimal(descuento) > 100)
                        {
                            MessageBox.Show("El descuento del articulo no puede ser mayor del 100%", "Sistema COVENTAF", MessageBoxButtons.OK);
                            //asignarle la cantidad que tenia antes de editarla
                            dgvDetalleFactura.Rows[consecutivoActualFactura].Cells[columnaIndex].Value = dgvDetalleFactura.Rows[consecutivoActualFactura].Cells[25].Value;
                        }
                        else
                        {
                            //de lo contrario significa que el descuento que digito el cajero esta correcto y actualiza el descuento 
                            dgvDetalleFactura.Rows[consecutivoActualFactura].Cells[25].Value = dgvDetalleFactura.Rows[consecutivoActualFactura].Cells[4].Value;
                            GuardarBaseDatosFacturaTemp(consecutivoActualFactura);
                        }
                        break;
                }

            }
        }


        #region evento del formulario facturacion

        private void chkDescuentoGeneral_Click(object sender, EventArgs e)
        {
            onChange_CheckDescuentoGeneral();
        }


        //evento cuando cambiar el chech en HTML
        void onChange_CheckDescuentoGeneral()
        {
            this.btnCobrar.Enabled = false;
            //desactivar el boton guardar           
            var descuentoGeneral = this.chkDescuentoGeneral.Checked;
            this.txtDescuentoGeneral.Enabled = descuentoGeneral;


            //comprobar si el descuento general esta en lectura
            if (this.txtDescuentoGeneral.ReadOnly)
            {
                //asignar el descuento general
                listVarFactura.PorCentajeDescGeneral = descuentoGeneral ? listVarFactura.PorCentajeDescCliente : 0;
                this.txtDescuentoGeneral.Text = listVarFactura.PorCentajeDescGeneral.ToString("P2");
                //_procesoFacturacion.changeCheckDSD(listVarFactura, listDetFactura, activoDSD);
            }
            else
            {
                listVarFactura.PorCentajeDescGeneral = 0.00M;
                this.txtDescuentoGeneral.Text = "0.00 %";
                this.txtDescuentoGeneral.Focus();
            }

            onCalcularTotales();
        }

        void onClickValidarDescuento()
        {
            onCalcularTotales();
            this.btnCobrar.Enabled = true;
        }

        #endregion



        private void btnMminizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnEliminarArticulo_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvDetalleFactura.RowCount > 0)
                {
                    int NumeroFilaSeleccionada = dgvDetalleFactura.CurrentRow.Index;
                    if (MessageBox.Show("¿ Estas seguro de eliminar el articulo seleccionado ?", "Sistema COVENTAF", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        
                        var articuloId = dgvDetalleFactura.Rows[NumeroFilaSeleccionada].Cells[1].Value.ToString();
                        onEliminarArticulo(articuloId, NumeroFilaSeleccionada);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Sistema COVENTAF");
            }
        }

        private void btnValidarDescuento_Click(object sender, EventArgs e)
        {
            // BODEGA b;
            //  b = cboBodega.SelectedItem;

            // object b = cboBodega.SelectedItem;
            //object be = cboBodega.GetItemText(b);

            //MessageBox.Show(cboBodega.SelectedValue.ToString());

            //MessageBox.Show("The value of your selected item is:" + be);

            if (this.txtCodigoCliente.Text.Trim().Length == 0)
            {
                MessageBox.Show("Debes de Ingresar el codigo de clientes", "Sistema COVENTAF");
                this.txtCodigoCliente.Focus();
            }
            else if (this.dgvDetalleFactura.RowCount == 0)
            {
                MessageBox.Show("Debes de Ingresar el articulo", "Sistema COVENTAF");
                this.txtCodigoBarra.Focus();
            }
            else
            {
                ///AQUI VOLVER A VALIDAR EL GRID EN CANTIDADES, EXISTENCIA
                MessageBox.Show("AQUI VOLVER A REVISAR EL GRID TANTO CANTIDADES, EXISTENCIA DESCUENTO");
                onClickValidarDescuento();
            }

        }

        private void btnCobrar_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            bool GuardarFactura = false;
            //modelo de factura para guardar
            _modelFactura.Factura = new Facturas();
            _modelFactura.FacturaLinea = new List<Factura_Linea>();
            _modelFactura.PagoPos = new List<Pago_Pos>();
            _modelFactura.FacturaRetenciones = new List<Factura_Retencion>();
                       
            //List<ViewMetodoPago> metodoPago;
            //List<DetalleRetenciones> detalleRetenciones;

            //primero recolectar la informacion de la factura
            RecolectarDatosFactura();

            var datoEncabezadoFact = new Encabezado()
            {
                noFactura = listVarFactura.NoFactura,
                fecha = listVarFactura.FechaFactura,
                bodega = this.cboBodega.SelectedValue.ToString(),
                caja = User.Caja,
                tipoCambio = listVarFactura.TipoDeCambio,
                codigoCliente = this.txtCodigoCliente.Text,
                cliente = listVarFactura.NombreCliente,
               
                //subTotalDolar = listVarFactura.SubTotalDolar,
                //descuentoDolar = listVarFactura.DescuentoGeneralDolar,
                //ivaDolar = listVarFactura.IvaDolar,

                subTotalCordoba = listVarFactura.SubTotalCordoba,
                descuentoCordoba = listVarFactura.DescuentoGeneralCordoba,
                MontoRetencion = listVarFactura.TotalRetencion,
                ivaCordoba = listVarFactura.IvaCordoba,
                //restar la retencion para mostrar en la factura y guardar en la base de datos con el total de la factura
                totalCordoba = listVarFactura.TotalCordobas,
                totalDolar = listVarFactura.TotalDolar,
                atentidoPor = User.NombreUsuario,
                formaDePago = listVarFactura.TicketFormaPago,
                observaciones = txtObservaciones.Text
            };


            this.Cursor = Cursors.Default;

            //llamar la ventana de metodo de pago.
            var frmCobrarFactura = new frmMetodoPago( _modelFactura, listVarFactura, datoEncabezadoFact, listDetFactura);
            frmCobrarFactura.TotalCobrar = Math.Round(listVarFactura.TotalCordobas, 2);
            frmCobrarFactura.tipoCambioOficial = listVarFactura.TipoDeCambio;

            frmCobrarFactura.ShowDialog();
            ////obtener informacion si el cajero cancelo o dio guardar factura
            GuardarFactura = frmCobrarFactura.facturaGuardada;
            ////si el cajero presiono el boton guardar factura obtengo el registro del metodo de pago 
            //metodoPago = GuardarFactura ? frmCobrarFactura.metodoPago : null;
            //detalleRetenciones = GuardarFactura ? frmCobrarFactura.detalleRetenciones : null;
            //liberar recursos
            frmCobrarFactura.Dispose();

            //verificar si el sistema guardo la factura o esta cancelando la ventana metodo de pago
            if (GuardarFactura)
            {
                //cerrar la ventana
                this.Close();
                facturaGuardada = true;                             
            }
                        
        }



        private async void GuardarDatosFacturaBaseDatos()
        {
            var datoEncabezadoFact = new Encabezado()
            {
                noFactura = listVarFactura.NoFactura,
                fecha = listVarFactura.FechaFactura,
                bodega = this.cboBodega.SelectedValue.ToString(),
                caja = User.Caja,
                tipoCambio = listVarFactura.TipoDeCambio,
                codigoCliente = this.txtCodigoCliente.Text,
                cliente = listVarFactura.NombreCliente,
                //subTotalDolar = listVarFactura.SubTotalDolar,
                //descuentoDolar = listVarFactura.DescuentoGeneralDolar,
                //ivaDolar = listVarFactura.IvaDolar,

                subTotalCordoba = listVarFactura.SubTotalCordoba,
                descuentoCordoba = listVarFactura.DescuentoGeneralCordoba,
                MontoRetencion = listVarFactura.TotalRetencion,
                ivaCordoba = listVarFactura.IvaCordoba,
                //restar la retencion para mostrar en la factura y guardar en la base de datos con el total de la factura
                totalCordoba = listVarFactura.TotalCordobas,
                totalDolar = listVarFactura.TotalDolar,
                atentidoPor = User.NombreUsuario,
                formaDePago = listVarFactura.TicketFormaPago,
                observaciones = txtObservaciones.Text
            };

            //si existe la retencion, entonces restar la retencion solo para la factura
            if (datoEncabezadoFact.MontoRetencion > 0)
            {
                decimal totalRetencionDolar = listVarFactura.TotalRetencion / listVarFactura.TipoDeCambio;
                datoEncabezadoFact.totalCordoba = datoEncabezadoFact.totalCordoba - listVarFactura.TotalRetencion;
                datoEncabezadoFact.totalDolar = datoEncabezadoFact.totalDolar - totalRetencionDolar;
            }

            //llamar al servidor para guardar la factura
            var responseModel = new ResponseModel();
           // responseModel = await _facturaController.GuardarFacturaAsync(_modelFactura);

            //comprobar si el servidor respondio con exito (1)
            if (responseModel.Exito == 1)
            {
                //imprimir la factura
                _procesoFacturacion.ImprimirTicketFactura(listDetFactura, datoEncabezadoFact);
                MessageBox.Show(responseModel.Mensaje, "Sistema COVENTAF");
                facturaGuardada = true;                
                this.Close();
            }
            else
            {              
                //this.btnGuardarFactura.Enabled = true;
                this.Cursor = Cursors.Default;
                MessageBox.Show(responseModel.Mensaje, "Sistema COVENTAF");
            }
        }


        public void RecopilarDatosMetodoPago(List<ViewMetodoPago> metodoPago, List<DetalleRetenciones> _detalleRetencion)
        {
            string TarjetaCredito = "0";
            string Condicion_Pago = "0";

            listVarFactura.TicketFormaPago = "";

            //var modelFactura = new ViewModelFacturacion();
            //modelFactura.Factura = new Facturas();
            //modelFactura.FacturaLinea = new List<Factura_Linea>();
            //_modelFactura.PagoPos = new List<Pago_Pos>();

           
            


            //asingar la tarjeta de credito por el metodo de pago que selecciono el cliente
            _modelFactura.Factura.Tarjeta_Credito = TarjetaCredito;
            _modelFactura.Factura.Condicion_Pago = Condicion_Pago;
        }


        private void RecolectarDatosFactura()
        {
            listVarFactura.FechaFactura = DateTime.Now;

            // Getting Ip address of local machine…
            // First get the host name of local machine.
            string strNombreEquipo = string.Empty;
            // Getting Ip address of local machine…
            // First get the host name of local machine.
            strNombreEquipo = Dns.GetHostName();

            _modelFactura.Factura.Tipo_Documento = "F";
            _modelFactura.Factura.Factura = listVarFactura.NoFactura;
            _modelFactura.Factura.Caja = User.Caja;
            _modelFactura.Factura.Num_Cierre = User.ConsecCierreCT;
            _modelFactura.Factura.Audit_Trans_Inv = null;
            _modelFactura.Factura.Esta_Despachado = "N";
            _modelFactura.Factura.En_Investigacion = "N";
            _modelFactura.Factura.Trans_Adicionales = "N";
            _modelFactura.Factura.Estado_Remision = "N";
            _modelFactura.Factura.Asiento_Documento = null;
            _modelFactura.Factura.Descuento_Volumen = 0.00000000M;
            _modelFactura.Factura.Moneda_Factura = "L";
            _modelFactura.Factura.Comentario_Cxc = null;
            _modelFactura.Factura.Fecha_Despacho = listVarFactura.FechaFactura;
            _modelFactura.Factura.Clase_Documento = "N";
            _modelFactura.Factura.Fecha_Recibido = listVarFactura.FechaFactura;
            _modelFactura.Factura.Pedido = null;
            _modelFactura.Factura.Factura_Original = null;
            _modelFactura.Factura.Tipo_Original = null;
            _modelFactura.Factura.Comision_Cobrador = 0.00000000M;
            //aqui es la tarjeta (Tipo de tarjeta)
            //_modelFactura.Factura.Tarjeta_Credito = ((this.cboFormaPago.SelectedValue.ToString() == "0003") ? this.cboTipoTarjeta.SelectedValue.ToString() : null);

            _modelFactura.Factura.Total_Volumen = 0.00000000M;
            _modelFactura.Factura.Numero_Autoriza = null;
            _modelFactura.Factura.Total_Peso = 0.00000000M;
            _modelFactura.Factura.Monto_Cobrado = 0.00000000M;
            _modelFactura.Factura.Total_Impuesto1 = 0.00000000M;
            _modelFactura.Factura.Fecha = listVarFactura.FechaFactura;
            _modelFactura.Factura.Fecha_Entrega = listVarFactura.FechaFactura;
            _modelFactura.Factura.Total_Impuesto2 = 0.00000000M;
            _modelFactura.Factura.Porc_Descuento2 = 0.00000000M;
            _modelFactura.Factura.Monto_Flete = 0.00000000M;
            _modelFactura.Factura.Monto_Seguro = 0.00000000M;
            _modelFactura.Factura.Monto_Documentacio = 0.00000000M;
            _modelFactura.Factura.Tipo_Descuento1 = "P";
            _modelFactura.Factura.Tipo_Descuento2 = "P";
            //investigando y comparando encontre q este es el monto del descuento general
            _modelFactura.Factura.Monto_Descuento1 = listVarFactura.DescuentoGeneralCordoba;
            //investigando con softland tiene cero
            _modelFactura.Factura.Monto_Descuento2 = 0.00000000M;
            //investigando y comparando con softland encontre q este es el % del descuento general (5%)
            _modelFactura.Factura.Porc_Descuento1 = listVarFactura.PorCentajeDescGeneral;
            //
            _modelFactura.Factura.Total_Factura = listVarFactura.TotalCordobas;
            _modelFactura.Factura.Fecha_Pedido = listVarFactura.FechaFactura;
            _modelFactura.Factura.Fecha_Hora_Anula = null;
            _modelFactura.Factura.Fecha_Orden = listVarFactura.FechaFactura;
            //softland dice en su diccionario: El monto total de la mercadería contempla las cantidades por los precios; menos los descuentos por línea
            // total de cordobas = es el total de la factura + el monto del descuento General
            _modelFactura.Factura.Total_Mercaderia = listVarFactura.TotalCordobas + listVarFactura.DescuentoGeneralCordoba;
            _modelFactura.Factura.Comision_Vendedor = 0.00000000M;
            _modelFactura.Factura.Orden_Compra = null;
            _modelFactura.Factura.Fecha_Hora = listVarFactura.FechaFactura;
            _modelFactura.Factura.Total_Unidades = listVarFactura.TotalUnidades;
            _modelFactura.Factura.Numero_Paginas = 1;
            _modelFactura.Factura.Tipo_Cambio = listVarFactura.TipoDeCambio;
            _modelFactura.Factura.Anulada = "N";
            _modelFactura.Factura.Modulo = "FA";
            //PREGUNTARAJUAN;
            _modelFactura.Factura.Cargado_Cg = "S";
            //PREGUNTARaJUAN;
            _modelFactura.Factura.Cargado_Cxc = "N";
            _modelFactura.Factura.Embarcar_A = listVarFactura.NombreCliente;
            _modelFactura.Factura.Direc_Embarque = "ND";
            _modelFactura.Factura.Direccion_Factura = "";
            _modelFactura.Factura.Multiplicador_Ev = 1;
            _modelFactura.Factura.Observaciones = this.txtObservaciones.Text;
            _modelFactura.Factura.Rubro1 = null;
            _modelFactura.Factura.Rubro2 = null;
            _modelFactura.Factura.Rubro3 = null;
            _modelFactura.Factura.Rubro4 = null;
            _modelFactura.Factura.Rubro5 = null;
            _modelFactura.Factura.Version_Np = 1;
            _modelFactura.Factura.Moneda = User.MonedaNivel;
            _modelFactura.Factura.Nivel_Precio = User.NivelPrecio;
            _modelFactura.Factura.Cobrador = "ND";
            _modelFactura.Factura.Ruta = "ND";

            _modelFactura.Factura.Usuario = User.Usuario;
            _modelFactura.Factura.Usuario_Anula = null;
            //silacondiciondepagoesCREDITOentoncesseleccionarlacondiciondepagosinopordefectoescontado(0);
            //_modelFactura.Factura.Condicion_Pago = (this.cboFormaPago.SelectedValue.ToString() == "0004" ? this.cboCondicionPago.SelectedValue.ToString() : "0");

            _modelFactura.Factura.Zona = this.datosCliente.Zona;
            _modelFactura.Factura.Vendedor = this.cboBodega.SelectedValue.ToString();
            _modelFactura.Factura.Doc_Credito_Cxc = "";
            _modelFactura.Factura.Cliente_Direccion = datosCliente.Cliente;
            _modelFactura.Factura.Cliente_Corporac = datosCliente.Cliente;
            _modelFactura.Factura.Cliente_Origen = datosCliente.Cliente;
            _modelFactura.Factura.Cliente = datosCliente.Cliente;
            _modelFactura.Factura.Pais = "505";
            _modelFactura.Factura.Subtipo_Doc_Cxc = 0;
            //preguntarajuan;
            _modelFactura.Factura.Tipo_Credito_Cxc = null;
            _modelFactura.Factura.Tipo_Doc_Cxc = "FAC";
            //monto_AnticipoESVARIABLE;
            _modelFactura.Factura.Monto_Anticipo = 0.00000000M;
            _modelFactura.Factura.Total_Peso_Neto = 0.00000000M;
            _modelFactura.Factura.Fecha_Rige = listVarFactura.FechaFactura;
            //contrato=null;
            _modelFactura.Factura.Porc_Intcte = 0.00000000M;
            _modelFactura.Factura.Usa_Despachos = "N";
            _modelFactura.Factura.Cobrada = "S";
            _modelFactura.Factura.Descuento_Cascada = "N";
            _modelFactura.Factura.Direccion_Embarque = "ND";
            _modelFactura.Factura.Consecutivo = null;
            _modelFactura.Factura.Reimpreso = 0;
            _modelFactura.Factura.Division_Geografica1 = null;
            _modelFactura.Factura.Division_Geografica2 = null;
            _modelFactura.Factura.Base_Impuesto1 = 0.00000000M;
            _modelFactura.Factura.Base_Impuesto2 = 0.00000000M;
            _modelFactura.Factura.Nombre_Cliente = this.datosCliente.Nombre;
            _modelFactura.Factura.Doc_Fiscal = null;
            _modelFactura.Factura.Nombremaquina = strNombreEquipo;
            _modelFactura.Factura.Serie_Resolucion = null;
            _modelFactura.Factura.Consec_Resolucion = null;
            _modelFactura.Factura.Genera_Doc_Fe = "N";
            _modelFactura.Factura.Tasa_Impositiva = null;
            _modelFactura.Factura.Tasa_Impositiva_Porc = 0.00000000M;
            _modelFactura.Factura.Tasa_Cree1 = null;
            _modelFactura.Factura.Tasa_Cree1_Porc = 0.00000000M;
            _modelFactura.Factura.Tasa_Cree2 = null;
            _modelFactura.Factura.Tasa_Cree2_Porc = 0.00000000M;
            _modelFactura.Factura.Tasa_Gan_Ocasional_Porc = 0.00000000M;
            _modelFactura.Factura.Contrato_Ac = null;
            _modelFactura.Factura.Ajuste_Redondeo = null;
            _modelFactura.Factura.Uso_Cfdi = null;
            _modelFactura.Factura.Forma_Pago = null;
            _modelFactura.Factura.Clave_Referencia_De = null;
            _modelFactura.Factura.Fecha_Referencia_De = null;
            _modelFactura.Factura.Justi_Dev_Haciend = null;
            _modelFactura.Factura.Incoterms = null;
            _modelFactura.Factura.U_Ad_Wm_Numero_Vendedor = null;
            _modelFactura.Factura.U_Ad_Wm_Enviar_Gln = null;
            _modelFactura.Factura.U_Ad_Wm_Numero_Recepcion = null;
            _modelFactura.Factura.U_Ad_Wm_Numero_Reclamo = null;
            _modelFactura.Factura.U_Ad_Wm_Fecha_Reclamo = null;
            _modelFactura.Factura.U_Ad_Pc_Numero_Vendedor = null;
            _modelFactura.Factura.U_Ad_Pc_Enviar_Gln = null;
            _modelFactura.Factura.U_Ad_Gs_Numero_Vendedor = null;
            _modelFactura.Factura.U_Ad_Gs_Enviar_Gln = null;
            _modelFactura.Factura.U_Ad_Gs_Numero_Recepcion = null;
            _modelFactura.Factura.U_Ad_Gs_Fecha_Recepcion = null;
            _modelFactura.Factura.U_Ad_Am_Numero_Proveedor = null;
            _modelFactura.Factura.U_Ad_Am_Enviar_Gln = null;
            _modelFactura.Factura.U_Ad_Am_Numero_Recepcion = null;
            _modelFactura.Factura.U_Ad_Am_Numero_Reclamo = null;
            _modelFactura.Factura.U_Ad_Am_Fecha_Reclamo = null;
            _modelFactura.Factura.U_Ad_Am_Fecha_Recepcion = null;
            _modelFactura.Factura.Tipo_Operacion = null;
            _modelFactura.Factura.NoteExistsFlag = 0;
            _modelFactura.Factura.RecordDate = listVarFactura.FechaFactura;            
            //_modelFactura.Factura.RowPointer = "F1929B9E-5CB4-476D-AFCC-0CC3D7D0D159";
            _modelFactura.Factura.CreatedBy = User.Usuario;
            _modelFactura.Factura.UpdatedBy = User.Usuario;
            _modelFactura.Factura.CreateDate = listVarFactura.FechaFactura;
            _modelFactura.Factura.Clave_De = null;
            _modelFactura.Factura.Actividad_Comercial = null;
            _modelFactura.Factura.Monto_Otro_Cargo = null;
            _modelFactura.Factura.Monto_Total_Iva_Devuelto = null;
            _modelFactura.Factura.Codigo_Referencia_De = null;
            _modelFactura.Factura.Tipo_Referencia_De = null;
            _modelFactura.Factura.Cancelacion = null;
            _modelFactura.Factura.Estado_Cancelacion = null;
            _modelFactura.Factura.Tiene_Relacionados = null;
            _modelFactura.Factura.Prefijo = null;
            _modelFactura.Factura.Fecha_Inicio_Resolucion = null;
            _modelFactura.Factura.Fecha_Final_Resolucion = null;
            _modelFactura.Factura.Clave_Tecnica = null;
            _modelFactura.Factura.Matricula_Mercantil = null;
            _modelFactura.Factura.Es_Factura_Reemplazo = null;
            _modelFactura.Factura.Factura_Original_Reemplazo = null;
            _modelFactura.Factura.Consecutivo_Ftc = null;
            _modelFactura.Factura.Numero_Ftc = null;
            _modelFactura.Factura.Nit_Transportador = null;
            _modelFactura.Factura.Ncf_Modificado = null;
            _modelFactura.Factura.Num_Oc_Exenta = null;
            _modelFactura.Factura.Num_Cons_Reg_Exo = null;
            _modelFactura.Factura.Num_Irsede_Agr_Gan = null;
            _modelFactura.Factura.U_Ad_Wm_Tipo_Nc = null;
            _modelFactura.Factura.Cuenta_Asiento = null;
            _modelFactura.Factura.Tipo_Pago = null;
            _modelFactura.Factura.Tipo_Descuento_Global = null;
            _modelFactura.Factura.Tipo_Factura = null;
            _modelFactura.Factura.Tipo_Nc = null;
            _modelFactura.Factura.Tipo_Detrac = null;
            _modelFactura.Factura.Act_Detrac = null;
            _modelFactura.Factura.Porc_Detrac = null;
            _modelFactura.Factura.Tienda_Enviado = User.TiendaID;

            //detalle de la factura
            foreach (var detFactura in listDetFactura)
            {
                if (detFactura.ArticuloId != "")
                {
                    var datosModel_ = new Factura_Linea()
                    {
                        Factura = listVarFactura.NoFactura,
                        Tipo_Documento = "F",
                        Linea = (short)detFactura.Consecutivo,
                        Bodega = detFactura.BodegaID,
                        
                        //ya revise en softland y no hay informacion [COSTO_PROM_DOL] * cantidad
                        Costo_Total_Dolar = detFactura.Cost_Prom_Dol * detFactura.Cantidadd, 
                        //pedido?=string
                        Articulo = detFactura.ArticuloId,
                        //localizacion?:string
                        //lote?:string
                        Anulada = "N",
                        Fecha_Factura = listVarFactura.FechaFactura,
                        Cantidad = detFactura.Cantidadd,
                        Precio_Unitario = detFactura.PrecioCordobas,
                        Total_Impuesto1 = 0.00000000M,
                        Total_Impuesto2 = 0.00000000M,
                        //monto descuento por linea de cada articulo en 
                        Desc_Tot_Linea = detFactura.DescuentoPorLineaCordoba,
                        //este es el descuento general (el famoso 5% q le dan a los militares)
                        Desc_Tot_General = detFactura.MontoDescGeneralCordoba,
                        //revisar [COSTO_PROM_LOC] * cantidad
                        Costo_Total = detFactura.Cost_Prom_Loc * detFactura.Cantidadd,
                        //aqui ya tiene restado el descuento por linea. precio_total_x_linea. ya lo verifique con softland
                        Precio_Total = detFactura.TotalCordobas,
                        Descripcion = detFactura.Descripcion,
                        //comentario?=string
                        Cantidad_Devuelt = 0.00000000M,
                        Descuento_Volumen = 0.00000000M,
                        Tipo_Linea = "N",
                        Cantidad_Aceptada = 0.00000000M,
                        Cant_No_Entregada = 0.00000000M,
                        //revisar [COSTO_PROM_LOC] * cantidad
                        Costo_Total_Local = detFactura.Cost_Prom_Loc * detFactura.Cantidadd,
                        Pedido_Linea = 0,
                        Multiplicador_Ev = 1,
                        /*serie_Cadena?=number
                        Serie_Cad_No_Acept?=number
                        Serie_Cad_Aceptada?=number
                        Documento_Origen?=string
                        Linea_Origen?=number
                        Tipo_Origen?=string
                        Unidad_Distribucio?=string*/
                        Cant_Despachada = 0.00000000M,
                        Costo_Estim_Local = 0.00000000M,
                        Costo_Estim_Dolar = 0.00000000M,
                        Cant_Anul_Pordespa = 0.00000000M,
                        Monto_Retencion = 0.00000000M,
                        Base_Impuesto1 = 0.00000000M,
                        Base_Impuesto2 = 0.00000000M,
                        /*proyecto?=string
                        Fase?=string
                        Centro_Costo?=string
                        Cuenta_Contable?=string*/
                        //revisar [COSTO_PROM_LOC] * cantidad
                        Costo_Total_Comp = detFactura.Cost_Prom_Loc * detFactura.Cantidadd,
                        //revisar [COSTO_PROM_LOC] * cantidad
                        Costo_Total_Comp_Local = detFactura.Cost_Prom_Loc * detFactura.Cantidadd,
                        //revisar [COSTO_PROM_DOL] * cantidad
                        Costo_Total_Comp_Dolar = detFactura.Cost_Prom_Dol * detFactura.Cantidadd,
                        Costo_Estim_Comp_Local = 0.00000000M,
                        Costo_Estim_Comp_Dolar = 0.00000000M,
                        Cant_Dev_Proceso = 0.00000000M,
                        NoteExistsFlag = 0,
                        RecordDate = listVarFactura.FechaFactura,
                        //RowPointer = "D083E752-86BD-41E9-BDAC-12A0B2D865E7",                        
                        CreatedBy = User.Usuario,                        
                        UpdatedBy = User.Usuario,
                        CreateDate = listVarFactura.FechaFactura,
                        Caja = User.Caja,
                        Porc_Desc_Linea = detFactura.PorCentajeDescXArticulod,
                        

                        /*tipo_Impuesto1? = string
                        tipo_Tarifa1? = string
                        tipo_Impuesto2? = string
                        tipo_Tarifa2? = string
                        porc_Exoneracion? = number
                        monto_Exoneracion? = number
                        es_Otro_Cargo? = string
                        es_Canasta_Basica? = string
                        es_Servicio_Medico? = string
                        monto_Devuelto_Iva? = number
                        porc_Exoneracion2? = number
                        monto_Exoneracion2? = number
                        tipo_Descuento_Linea? = string */
                    };
                    //agregar nuevo registro a la clase FacturaLinea.
                    _modelFactura.FacturaLinea.Add(datosModel_);
                }
            }
        }



        private void frmVentas_KeyDown(object sender, KeyEventArgs e)
        {
            //comprobar si el usuario presiono la tecla f5 y ademas si el boton esta habilitado
            if (e.KeyCode == Keys.F1 && this.btnValidarDescuento.Enabled)
            {
                btnValidarDescuento_Click(null, null);
            }

            //comprobar si el usuario presiono la tecla f5 y ademas si el boton esta habilitado
            else if (e.KeyCode == Keys.F3 && this.btnCobrar.Enabled)
            {
                btnCobrar_Click(null, null);
            }
            //F6 y chkDescuentoGeneral este habilitado
            else if (e.KeyCode == Keys.F6 && this.chkDescuentoGeneral.Enabled)
            {
                this.chkDescuentoGeneral.Checked = !this.chkDescuentoGeneral.Checked;
                chkDescuentoGeneral_Click(null, null);
            }

            else if (e.KeyCode == Keys.F5)
            {
                this.txtObservaciones.Focus();
            }

            else if (e.KeyCode == Keys.F8)
            {
                btnLimpiarFactura_Click(null, null);
            }

            //else if (e.KeyCode == Keys.F10 && this.btnGuardarFactura.Visible)
            //{
            //    btnGuardarFactura_Click(null, null);
            //}

            else if (e.KeyCode == Keys.Delete)
            {
                btnEliminarArticulo_Click(null, null);
            }
            //ubicar el cursor el textbox codigo de barra
            else if (e.KeyCode == Keys.F12)
            {
                this.txtCodigoBarra.Focus();
            }

            else if (e.KeyCode == Keys.Escape)
            {
                btnCerrar_Click(null, null);
            }

        }


        private void txtDescuentoGeneral_KeyPress(object sender, KeyPressEventArgs e)
        {
            //desactivar el boton cobar para obligar al usuario volver a ejecutar el boto validar
            this.btnCobrar.Enabled = false;
            if (e.KeyChar == 13)
            {
                if (txtDescuentoGeneral.Text.Trim().Length > 0)
                {
                    AplicarDescuentoGeneralFactura();
                    this.txtDescuentoGeneral.Focus();
                }
                else
                {
                    MessageBox.Show("Debes de ingresar el descuento", "Sistema COVENTAF");
                }
            }
        }

        private void AplicarDescuentoGeneralFactura()
        {
            bool continuar = true;
            while (continuar)
            {

                var existeCaractePorcentaje = false;
                //quitar el simbolo del porcentaje en caso que caso que existiera.
                string valorPorCentaje = _procesoFacturacion.QuitarSimboloPorCentaje(this.txtDescuentoGeneral.Text, ref existeCaractePorcentaje);
                //comprobar si existe el caracter del %, si existe reasignarse y si no existe se asigna al textbox del descuento general
                this.txtDescuentoGeneral.Text = existeCaractePorcentaje ? this.txtDescuentoGeneral.Text : $"{this.txtDescuentoGeneral.Text} %";
                decimal porCentajeDescuento = Convert.ToDecimal(valorPorCentaje);
                listVarFactura.PorCentajeDescGeneral = porCentajeDescuento;
                //realizar calculo
                onCalcularTotales();

                //aqui seria agregar el codigo, en caso que el techo del descuento sea menor que el descuento 
                if ((listVarFactura.DescuentoGeneralCordoba > listVarFactura.SaldoDisponible) && (listVarFactura.DescuentoGeneralCordoba - listVarFactura.SaldoDisponible) >= 1)
                {
                    //obtener el nuevo porcentaje de descuento
                    this.txtDescuentoGeneral.Text = _procesoFacturacion.CalcularNuevoPorCentajeDescuentoGeneral(listVarFactura.SubTotalCordoba, listVarFactura.SaldoDisponible, listVarFactura.PorCentajeDescGeneral).ToString("N2");
                }
                else
                {
                    continuar = false;
                }

            } 



            //listVarFactura.NombreCliente = datosCliente.Nombre;
            ////saldo disponible del cliente del descuento
            //listVarFactura.SaldoDisponible = Convert.ToDecimal(datosCliente.U_U_SaldoDisponible is null ? 0.00M : datosCliente.U_U_SaldoDisponible);
            ////porcentaje del cliente
            //listVarFactura.PorCentajeDescCliente = Convert.ToDecimal(datosCliente.U_U_Descuento is null ? 0.00M : datosCliente.U_U_Descuento);
            //listVarFactura.PorCentajeDescGeneral = 0.00M;

        }



        private void cboBodega_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnGuardarFactura_Click(object sender, EventArgs e)
        {
            GuardarDatosFacturaBaseDatos();
        }

        private async void btnLimpiarFactura_Click(object sender, EventArgs e)
        {
            ResponseModel responseModel = new ResponseModel();
            responseModel = await _facturaController.CancelarNoFacturaBloqueada(listVarFactura.NoFactura);
            facturaGuardada = true;
            this.Close();

            /*

            //falta eliminar de la tabla facturando
            _procesoFacturacion.InicializarTodaslasVariable(listVarFactura);
            this.txtCodigoCliente.Enabled = true;
            this.txtCodigoCliente.Text = "";
            this.txtNombreCliente.Text = "";
            this.txtDisponibleCliente.Text = "";
            this.txtDescuentoCliente.Text = "";
            this.cboBodega.SelectedValue = User.BodegaID;
            listDetFactura = null;
            listDetFactura = new List<DetalleFactura>();
            this.txtObservaciones.Text = "";
            this.chkDescuentoGeneral.Enabled = false;
            this.chkDescuentoGeneral.Checked = false;
            this.txtDescuentoGeneral.Text = "0.00%";
            this.txtCodigoBarra.Text = "";
            this.txtDescripcionArticulo.Text = "";
            onCalcularTotales();
            this.btnValidarDescuento.Enabled = true;
            this.btnCobrar.Enabled = false;
            this.txtCodigoCliente.Focus();
            this.lblFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");*/
        }

        private void txtCodigoBarra_Enter(object sender, EventArgs e)
        {
            this.btnCobrar.Enabled = false;
        }

        private void txtDescuentoGeneral_Leave(object sender, EventArgs e)
        {
            if (this.txtDescuentoGeneral.Text.Trim().Length == 0)
            {
                this.txtDescuentoGeneral.Text = "0";
            }

            AplicarDescuentoGeneralFactura();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //oscar revisa esto urgente 16/02/2023
            var datoEncabezadoFact = new Encabezado()
            {
                noFactura = listVarFactura.NoFactura,
                fecha = listVarFactura.FechaFactura,
                bodega = this.cboBodega.SelectedValue.ToString(),
                caja = User.Caja,
                tipoCambio = listVarFactura.TipoDeCambio,
                codigoCliente = this.txtCodigoCliente.Text,
                cliente = listVarFactura.NombreCliente,
                //subTotalDolar = listVarFactura.SubTotalDolar,
                //descuentoDolar = listVarFactura.DescuentoGeneralDolar,
                //ivaDolar = listVarFactura.IvaDolar,                
                subTotalCordoba = listVarFactura.SubTotalCordoba,
                descuentoCordoba = listVarFactura.DescuentoGeneralCordoba,
                ivaCordoba = listVarFactura.IvaCordoba,
                totalCordoba = listVarFactura.TotalCordobas,
                totalDolar = listVarFactura.TotalDolar,
                atentidoPor = User.NombreUsuario,
                formaDePago = listVarFactura.TicketFormaPago,
                observaciones = txtObservaciones.Text
            };




            _procesoFacturacion.ImprimirTicketFacturaDemo(listDetFactura, datoEncabezadoFact);
        }

        //tiene lugar cuando la celda pierde el foco
        private void dgvDetalleFactura_CellLeave(object sender, DataGridViewCellEventArgs e)
        {

        }

        //tiene lugar cuando recibe el foco
        private void dgvDetalleFactura_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dgvDetalleFactura_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e != null)
            {
                if (this.dgvDetalleFactura.Columns[e.ColumnIndex].Name == "cantidadd")
                {
                    if (e.Value != null)
                    {
                        try
                        {
                            e.Value = e.Value.ToString();
                            e.FormattingApplied = true;
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("{0} is not a valid date.", e.Value.ToString());
                        }
                    }
                }
            }
        }
    }
}


