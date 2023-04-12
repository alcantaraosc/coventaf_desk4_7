using Api.Model.Modelos;
using Api.Model.View;
using Api.Model.ViewModels;
using Api.Service.DataService;
using COVENTAF.Services;
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
    public partial class frmPagosPos : Form
    {
   
        //esta variable me indica si el cajero presiono la tecla guardar factura
        public bool facturaGuardada = false;
        public List<DetallePagosPos> detallePagosPos;
        private FuncionFacturacion _procesoFactura = new FuncionFacturacion();

        public decimal TotalCobrar;
        public decimal tipoCambioOficial;
        public decimal nuevoTipoCambioAproximado;
        //esta variable lleva el control si el cliente ya hizo el pago de la factura de dos forma x ejemplo
        private bool bloquearMetodoPago = false;
        //esta variable lleva el control de la tecla que el cajero presiono. x ejemplo el cajero presiono F1 y luego F3, entonces si primero presion F1 y despues F3
        //el sistema tiene que saber que el usuario ahora quiere el metodo de pago F3, quizas porque se confundio, por lo tanto el sistema tiene que ser capaz de limpiar el textbox
        private string teclaPresionadaXCajero = "";
        bool bandera = true;
        private bool cobrasteCordobas = false;
        private decimal montoFinalCobrarDolar;
        private decimal VueltoCliente = 0;

        private string codigoTipoPago = "";
        private string tipoPago = "";
        private char moneda = 'L';

        private int Index = -1;
        private decimal totalCobrarCordoba = 0.0000M;
        private decimal totalCobrarDolar = 0.00M;
        private decimal montoPagadoCordoba = 0.0000M;
        private decimal montoPagadoDolar = 0.00M;
        private decimal diferenciaCordoba = 0.0000M;
        private decimal diferenciaDolar = 0;
        public decimal totalRetenciones = 0.00M;
        private decimal TotalCobrarAux = 0.00M;
        private bool ejecutarEventoSelect = false;
        //el 1er credito que se autoriza
        private decimal montoCredito = 0;
        //2do credito q se acredita por defecto quincenal para los militares Empleados y otros
        private decimal montoCreditCrtPlz = 0;
        bool DesactivarOpCredito, DesactivarOpCredCortPlz;
        private List<ViewDevoluciones> listDevCliente = new List<ViewDevoluciones>();
       
        private decimal MontoFavorCliente;


        private ViewModelFacturacion _modelFactura;
        private VariableFact _listVarFactura;
        private Encabezado _datoEncabezadoFact;
        private ServiceFactura _serviceFactura = new ServiceFactura();
        private List<DetalleRetenciones> detalleRetenciones;
        private List<DetalleFactura> _listDetFactura;
        ListarDatosFactura listarDrownListModel;

        #region codigo para mover pantalla
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        #endregion


        public frmPagosPos(ViewModelFacturacion modelFactura, VariableFact listVarFactura, Encabezado datoEncabezadoFact, List<DetalleFactura> listDetFactura)
        {
            InitializeComponent();
            this.Cursor = Cursors.WaitCursor;

            detallePagosPos = new List<DetallePagosPos>();
            this._listVarFactura = listVarFactura;
            this._modelFactura = modelFactura;
            this._datoEncabezadoFact = datoEncabezadoFact;
            this._listDetFactura = listDetFactura;
            detalleRetenciones = new List<DetalleRetenciones>();
        }


        private void barraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }


        private void btnCerrar_Click(object sender, EventArgs e)
        {            
            this.Close();
        }


        void EstablecerMontosInicio()
        {
            totalCobrarCordoba = TotalCobrar;
            totalCobrarDolar = Math.Round((TotalCobrar / tipoCambioOficial), 2);
            montoPagadoCordoba = 0.0000M;
            montoPagadoDolar = 0.00M;
            diferenciaCordoba = TotalCobrar - montoPagadoCordoba;
            diferenciaDolar = totalCobrarDolar - montoPagadoDolar;


            this.lblTotalPagar.Text = $"C${TotalCobrar.ToString("N2")} = U${(TotalCobrar / tipoCambioOficial).ToString("N2")}";
            this.txtPendientePagarCliente.Text = TotalCobrar.ToString("N2");

            this.txtEfectivoCordoba.Text = string.Format("{0:n}", this.txtEfectivoCordoba.Text);//1.234,35
        }


        void AddNuevaFilaMetodoPago()
        {
            var datosd_ = new DetallePagosPos()
            {
                MontoCordoba = 0.0000M,
                MontoDolar = 0.0000M,
                TeclaPresionaXCajero = false,
                Monto = 0.00M,
            };

            //agregar push para agregar un nuevo registro
            detallePagosPos.Add(datosd_);
            Index = detallePagosPos.Count - 1;
            //aumentar el idice
            //= Index + 1;
        }

        private void btnCierre_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPagosPos_KeyDown(object sender, KeyEventArgs e)
        {
            //comprobar si el usuario presiono la tecla F6 y ademas si el boton esta habilitado
            if (e.KeyCode == Keys.F1)
            {
                //llamar al evento efectivo
                btnEfectivoCordobas_Click(null, null);
            }
            if (e.KeyCode == Keys.F2)
            {
                //llamar al evento efectivo
                btnChequeCordobas_Click(null, null);
            }

            //comprobar si el usuario presiono la tecla F6 y ademas si el boton esta habilitado
            else if (e.KeyCode == Keys.F3)
            {
                btnTarjetaCordobas_Click(null, null);
            }

            else if (e.KeyCode == Keys.F5 && btnCredito.Enabled)
            {
                btnCredito_Click(null, null);
            }

            else if (e.KeyCode == Keys.F6 && btnCreditoCortoPlazo.Enabled)
            {
                BtnCreditoCortoPlazo_Click(null, null);
            }
            else if (e.KeyCode == Keys.F7)
            {
                btnGiftCardCordobar_Click(null, null);
            }
            //comprobar si presiono la tecla F11 y el label efectivo dolar esta visible
            else if (e.KeyCode == Keys.F11 && this.lblEfectivoDolar.Visible)
            {
                lblEfectivoDolar_Click(null, null);
            }
            //comprobar si presiono la tecla F11 y el label Cheque dolar esta visible
            else if (e.KeyCode == Keys.F11 && this.lblChequeDolar.Visible)
            {
                lblChequeDolar_Click(null, null);
            }
            //comprobar si presiono la tecla F11 y el label Tarjeta dolar esta visible
            else if (e.KeyCode == Keys.F11 && this.lblTarjetaDolar.Visible)
            {
                lblTarjetaDolar_Click(null, null);
            }
            //comprobar si presiono la tecla F11 y el label GiftCard dolar esta visible
            else if (e.KeyCode == Keys.F11 && this.lblGiftCardDolar.Visible)
            {
                lblGiftCardDolar_Click(null, null);
            }

            //presionar la tecla F8 y el boton Guardar este activo
            else if (e.KeyCode == Keys.F8 && this.btnGuardar.Enabled)
            {
                btnGuardar_Click(null, null);
            }

            else if (e.KeyCode == Keys.F10)
            {
                btnOtros_Click(null, null);
            }

            else if (e.KeyCode == Keys.F12)
            {
                btnResetear_Click(null, null);
            }

            else if (e.KeyCode == Keys.Escape)
            {
                btnCerrar_Click(null, null);
            }
        }

        //void VerificarMontoDolar(decimal montoDolarCobrar)
        //{

        //      //  metodoPago[0].MontoCordoba

        //    //comprobar si el cliente pago en cordoba y adema si el monto a pagar es el monto final en dolares
        //        if (cobrasteCordobas & montoDolarCobrar == montoFinalCobrarDolar)
        //    {
        //        //metodoPago[0].Diferencia


        //        //este es el monto con error
        //        decimal montoConError = (montoDolarCobrar * tipoCambioOficial);
        //        montoConError = Math.Round(montoConError, 2);

        //        //este es el monto al que tengo q llegar
        //        decimal montoTotalCobrar = metodoPago[0].Diferencia;

        //        if (montoConError == montoTotalCobrar)
        //        {
        //            nuevoTipoCambioAproximado = tipoCambioOficial;
        //        }
        //        else
        //        {
        //            nuevoTipoCambioAproximado = ObtenerNuevoTipoCambioExcto(montoTotalCobrar, montoConError, montoDolarCobrar);
        //        }

        //    }
        //}

        void VerificarMontoDolar(decimal montoDolarCobrar)
        {

            if (montoDolarCobrar == diferenciaDolar)
            {
                //este es el monto con error
                decimal montoConError = (montoDolarCobrar * tipoCambioOficial);
                montoConError = Math.Round(montoConError, 2);

                //este es el monto al que tengo q llegar en cordobas
                decimal montoTotalCobrar = Math.Round(diferenciaCordoba, 2);

                if (montoConError == montoTotalCobrar)
                {
                    nuevoTipoCambioAproximado = tipoCambioOficial;
                }
                else
                {
                    nuevoTipoCambioAproximado = ObtenerNuevoTipoCambioExcto(montoTotalCobrar, montoConError, montoDolarCobrar);
                }
            }
            /*
            //comprobar si el cliente pago en cordoba y adema si el monto a pagar es el monto final en dolares
            if (cobrasteCordobas & montoDolarCobrar == montoFinalCobrarDolar)
            {
                //metodoPago[0].Diferencia


                //este es el monto con error
                decimal montoConError = (montoDolarCobrar * tipoCambioOficial);
                montoConError = Math.Round(montoConError, 2);

                //este es el monto al que tengo q llegar
                decimal montoTotalCobrar = metodoPago[0].Diferencia;

                if (montoConError == montoTotalCobrar)
                {
                    nuevoTipoCambioAproximado = tipoCambioOficial;
                }
                else
                {
                    nuevoTipoCambioAproximado = ObtenerNuevoTipoCambioExcto(montoTotalCobrar, montoConError, montoDolarCobrar);
                }

            }*/
        }

        void VerificarMonto(decimal montoDolarCobrar)
        {
            //var valorMontoDolar = Math.Round((metodoPago[0].MontoCordoba / tipoCambioOficial),2);

            //comprobar si el cliente pago en cordoba y adema si el monto a pagar es el monto final en dolares
            if (cobrasteCordobas & montoDolarCobrar == montoFinalCobrarDolar)
            {
                //metodoPago[0].Diferencia


                //este es el monto con error
                decimal montoConError = (montoDolarCobrar * tipoCambioOficial);
                montoConError = Math.Round(montoConError, 2);

                //este es el monto al que tengo q llegar
                decimal montoTotalCobrar = diferenciaCordoba;

                if (montoConError == montoTotalCobrar)
                {
                    nuevoTipoCambioAproximado = tipoCambioOficial;
                }
                else
                {
                    nuevoTipoCambioAproximado = ObtenerNuevoTipoCambioExcto(montoTotalCobrar, montoConError, montoDolarCobrar);
                }

            }
        }

        //esto hay q revisarlo.. q pasa si el cliente hay un pago con 2 tarjeta de cordobas y 2 tarjeta de dolares con diferente banco.. 


        /// <summary>
        /// 
        /// </summary>
        /// <param name="formaPago">codigo de la forma de pago</param>
        /// <param name="nombreFormaPago"></param>
        /// <param name="monto">monto total o parcial del pago</param>
        /// <param name="moneda">L=Cordoba o D=Dolar</param>
        /// <param name="TeclaPresionaXCajero"></param>
        /// <param name="tecla">Nombre de la tecla que presiono el cajero para el tipo de pago que esta usando (F1, F2....) </param>
        /// <param name="entidadFinanciera">entidad financiera del cheque </param>
        /// <param name="tipoTarjeta">Tipo de Tarjeta</param>
        /// <param name="codigoCondicionPago">codigo del credito</param>
        /// <param name="DescripcionCondicionPago">Descripcion del credito</param>
        void Asginar_Pago_Pos(string formaPago, string nombreFormaPago, decimal monto, char moneda, bool TeclaPresionaXCajero, string tecla, string entidadFinanciera = null,
            string tipoTarjeta = null, string codigoCondicionPago = null, string DescripcionCondicionPago = null, string noDocumento = null)
        {
            decimal montoDolar = 0;
            decimal montoCordoba = 0;
            bool nuevoRegistro = true;

            switch (moneda)
            {
                //comprobar si la monedad es local(L=Local=C$)
                case 'L':
                    monto = Math.Round(monto, 2);
                    //si el cliente paga con cordobas y luego dolares, entonces en el tipo de cambio existe un restante
                    //o faltante de centavo por el tipo de cambio, de modo que aqui controlo si el usuario hizo pago en cordobas y reajusto el nuevo tipo de cambio para que sea exacto.
                    //aqui le indico al sistema que el cliente realizo un pago en cordobas.
                    cobrasteCordobas = true;
                    montoCordoba = monto;
                    montoDolar = monto / tipoCambioOficial;
                    montoDolar = Math.Round(montoDolar, 2);
                    break;

                //comprobar si la monedad es Dolaar(D=Dolar=U$)
                case 'D':

                    monto = Math.Round(monto, 2);
                    //aqui tendria que ver q tipo de cambio usar
                    VerificarMontoDolar(monto);
                    montoDolar = monto;
                    montoCordoba = monto * nuevoTipoCambioAproximado;
                    montoCordoba = Math.Round(montoCordoba, 2);
                    break;
            }

            //obtener el indice si ya existe el metodo de pago
            //si la forma de pago es Efectivo (0001= Efectivo Cordobas o Dolares) Credito o Credito a corto plazo entonces buscar si existe la forma de pago Efectivo
            var datoMetPago = formaPago == "0001" || formaPago=="0004" || formaPago == "FP17" ? detallePagosPos.Where(mp => mp.DescripcionFormaPago == nombreFormaPago).Select(mp => new { mp.Indice, mp.Pago }).FirstOrDefault() : null;

            if (datoMetPago is null)
            {
                AddNuevaFilaMetodoPago();
            }
            else
            {
                //obtener el indice de la consulta
                Index = datoMetPago.Indice;
                nuevoRegistro = false;
            }


            /****************************************** informacion para el sistema al guardar **************************************************/
            detallePagosPos[Index].Indice = Index;
            detallePagosPos[Index].Pago = Index.ToString();
            //codigo del metodo de pago ej.:(0001, 0002, 0003 .....)
            detallePagosPos[Index].FormaPago = formaPago;
     
            //cheque
            detallePagosPos[Index].EntidadFinanciera = entidadFinanciera;
            //el tipo de tarjeta que se ha seleccionado con el metodo de pago tarjeta
            detallePagosPos[Index].TipoTarjeta = tipoTarjeta;
            //Credito
            detallePagosPos[Index].CondicionPago = codigoCondicionPago;
            //Credito
            detallePagosPos[Index].DescripcionCondicionPago = DescripcionCondicionPago;
            detallePagosPos[Index].Numero = noDocumento;

            detallePagosPos[Index].MontoCordoba += montoCordoba;
            detallePagosPos[Index].Moneda = moneda;
            detallePagosPos[Index].MontoDolar += montoDolar;
            detallePagosPos[Index].TeclaPresionaXCajero = TeclaPresionaXCajero;
            detallePagosPos[Index].DescripcionTecla = tecla;
            detallePagosPos[Index].VueltoCliente = 0;
            /************************************************************************************************************************************/

            /****************************************** informacion para el usuario *************************************************************/
            //descripcion metodo de pago. ej.:(Efectivo, Cheque, Tarjeta)
            detallePagosPos[Index].DescripcionFormaPago = nombreFormaPago;
            detallePagosPos[Index].Monto = Math.Round(detallePagosPos[Index].MontoCordoba, 2);
       
            detallePagosPos[Index].Detalle = new FuncionMetodoPago().ObtenerDetallePago(detallePagosPos, Index, tipoCambioOficial);
            /************************************************************************************************************************************/

            ///// realizar los calculos
            ///sumar el monto pagado
            montoPagadoCordoba += montoCordoba;
            montoPagadoDolar += montoDolar;
            //this.txtPendientePagarCliente.Text = montoPagadoCordoba.ToString("N2");
            //calcular la diferencia, en este caso si existe una diferencia
            var diferencia = totalCobrarCordoba - montoPagadoCordoba;

            diferencia = Math.Round(diferencia, 2);
            diferenciaCordoba = diferencia;
            diferenciaDolar = Math.Round((diferencia / tipoCambioOficial), 2);
            //validar si la diferencia es negativa entonces existe un cambio para el cliente
            if (diferencia < 0.00M)
            {
                decimal Cambio = (-1) * diferencia;
                lblCambioCliente.Text = $"C${Cambio.ToString("N2")} = U${(Cambio / tipoCambioOficial).ToString("N2")}";
                this.txtPendientePagarCliente.Text = "0.00";
                bloquearMetodoPago = true;
                this.btnGuardar.Enabled = bloquearMetodoPago;
                VueltoCliente = diferencia;
                detallePagosPos[Index].VueltoCliente = diferencia;          
            }
            else
            {

                var valorPendientePagar = GetMontoCobrar();
                bloquearMetodoPago = (valorPendientePagar > 0 ? false : true);
                this.btnGuardar.Enabled = bloquearMetodoPago;
                this.txtPendientePagarCliente.Text = $"C${valorPendientePagar.ToString("N2")}";
            }

            AgregarPagosPosGrid(nuevoRegistro, Index);
          
        }


        private void AgregarPagosPosGrid(bool nuevoRegistro, int index )
        {
            var _pagoPos = detallePagosPos.Where(x => x.Indice == index).FirstOrDefault();

            if (nuevoRegistro)
            {
                this.dgvDetallePago.Rows.Add(_pagoPos.Indice, _pagoPos.Pago, _pagoPos.FormaPago, _pagoPos.DescripcionFormaPago, _pagoPos.EntidadFinanciera,
                    _pagoPos.TipoTarjeta, _pagoPos.CondicionPago, _pagoPos.DescripcionCondicionPago, _pagoPos.Numero, $"C${_pagoPos.MontoCordoba.ToString("N2")}",
                     _pagoPos.Moneda, $"U${_pagoPos.MontoDolar}", $"C${_pagoPos.Monto.ToString("N2")}", _pagoPos.Detalle);
            }
            else
            {

                this.dgvDetallePago.Rows[index].Cells["MontoCordoba"].Value = _pagoPos.MontoCordoba;
                this.dgvDetallePago.Rows[index].Cells["MontoDolar"].Value = _pagoPos.MontoDolar;
                                
                this.dgvDetallePago.Rows[index].Cells["Monto"].Value = _pagoPos.Monto;
                this.dgvDetallePago.Rows[index].Cells["Detalle"].Value = _pagoPos.Detalle;
            }
               
        }


        decimal GetMontoCobrar()
        {
            var montoPagado = totalCobrarCordoba - montoPagadoCordoba;
            montoPagado = Math.Round(montoPagado, 2);
            //si el monto pagado es negativo significa que el cliente ya pago la factura
            if (montoPagado < 0)
            {
                return 0.00M;
            }
            else
            {
                return montoPagado;
            }
        }


        //boton reiniciar el cobro
        private void btnResetear_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿ Estas seguro de Resetear el metodo de pago ?", "Sistema COVENTAF", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                setCambiarEstadoTextBoxMetodoPago("sinInf", false);
                this.lblConvertidorDolares.Visible = false;

                /************** reiniciar credito del cliente ******/
                //resetear el vuelto del cliente
                VueltoCliente = 0;

                //activar o desactivar el boton del credito
                this.btnCredito.Enabled = DesactivarOpCredito;
                this.lblCredito.Enabled = DesactivarOpCredito;
                //activar o desactivar el credito
                this.btnCreditoCortoPlazo.Enabled = DesactivarOpCredCortPlz;
                this.lblCreditoCortoPlazo.Enabled = DesactivarOpCredCortPlz;

                //reiniciar el monto del credito
                montoCredito = Convert.ToDecimal(listarDrownListModel.Clientes.Limite_Credito);
                //reiniciar el monto del credito a corto plazo
                montoCreditCrtPlz = Convert.ToDecimal(listarDrownListModel.Clientes.U_U_Credito2Disponible);


                /***********************************************************/

                montoFinalCobrarDolar = 0;
                cobrasteCordobas = false;
                this.btnGuardar.Enabled = false;
                bloquearMetodoPago = false;
                teclaPresionadaXCajero = "";

                detallePagosPos = null;
                Index = -1;
                codigoTipoPago = "";
                tipoPago = "";
                moneda = 'L';

                SetCambiarEstadoVisibleLableF11Dolar("", false);

                detallePagosPos = new List<DetallePagosPos>();
                //limpiar las filas del gridView
                this.dgvDetallePago.Rows.Clear();
                             

                EstablecerMontosInicio();

                this.txtEfectivoCordoba.Text = "C$0.00";
                this.txtEfectivoCordoba.Enabled = false;
                this.txtEfectivoDolar.Text = "U$0.00";
                this.txtEfectivoDolar.Enabled = false;
                this.lblEfectivoDolar.Visible = false;

                this.txtChequeCordoba.Text = "C$0.00";
                this.txtChequeCordoba.Enabled = false;
                this.txtChequeDolar.Text = "U$0.00";
                this.txtChequeCordoba.Enabled = false;
                this.lblChequeDolar.Visible = false;

                this.txtTarjetaCordoba.Text = "C$0.00";
                this.txtTarjetaCordoba.Enabled = false;
                this.txtTarjetaDolar.Text = "U$0.00";
                this.txtTarjetaDolar.Enabled = false;
                this.lblTarjetaDolar.Visible = false;

                this.txtCredito.Text = "C$0.00";
                this.txtCredito.Enabled = false;


                this.txtCreditoCortoPlz.Text = "C$0.00";
                this.txtCreditoCortoPlz.Enabled = false;

                this.txtGiftCardCordoba.Text = "C$0.00";
                this.txtGiftCardCordoba.Enabled = false;
                this.txtGiftCardDolar.Text = "U$0.00";
                this.txtGiftCardDolar.Enabled = false;
                this.lblGiftCardDolar.Visible = false;

                txtPendientePagarCliente.Text = TotalCobrar.ToString("N2");

                this.lblCambioCliente.Text = "C$0.00";
            }
        }


        private void frmPagosPos_Load(object sender, EventArgs e)
        {
            //asignarla a una variable temporal
            TotalCobrarAux = TotalCobrar;


            ListarCombox();

            tipoCambioOficial = Math.Round(tipoCambioOficial, 4);
            nuevoTipoCambioAproximado = tipoCambioOficial;

            var montoTotalCobrar = Math.Round(TotalCobrar, 2);

            lblTitulo.Text = $"Cobrar Factura. Tipo de Cambio: {tipoCambioOficial}";
            //inicializar los datos
            EstablecerMontosInicio();

            this.Cursor = Cursors.Default;
        }

     
        public async void ListarCombox()
        {
            listarDrownListModel = new ListarDatosFactura();

            try
            {
                listarDrownListModel = await new ServiceFormaPago().llenarComboxMetodoPagoAsync(_listVarFactura.CodigoCliente);

                if (listarDrownListModel.Exito == 1)
                {
                    //asignar los montos del credito
                    montoCredito = Convert.ToDecimal(listarDrownListModel.Clientes.Limite_Credito);
                    //asignar el monto del credito a corto plazo
                    montoCreditCrtPlz = Convert.ToDecimal(listarDrownListModel.Clientes.U_U_Credito2Disponible);

                    DesactivarOpCredito = listarDrownListModel.Clientes.Limite_Credito > 0 ? true : false;
                    DesactivarOpCredCortPlz = listarDrownListModel.Clientes.U_U_Credito2Disponible > 0 ? true : false;

                    //activar o desactivar el boton del credito
                    this.btnCredito.Enabled = DesactivarOpCredito;
                    this.lblCredito.Enabled = DesactivarOpCredito;
                    //activar o desactivar el credito
                    this.btnCreditoCortoPlazo.Enabled = DesactivarOpCredCortPlz;
                    this.lblCreditoCortoPlazo.Enabled = DesactivarOpCredCortPlz;


                    if (!DesactivarOpCredito)
                    {
                        //obtener la fila del elemento a quita
                        var formPago = listarDrownListModel.FormaPagos.Where(fp => fp.Forma_Pago == "0004").FirstOrDefault();
                        //int indice = listarDrownListModel.FormaPagos.LastIndexOf(x)
                        //luego indico cual es la fila a quita
                        listarDrownListModel.FormaPagos.Remove(formPago);
                    }

                    if (!DesactivarOpCredCortPlz)
                    {
                        //obtener la fila del elemento a quita
                        var formPago = listarDrownListModel.FormaPagos.Where(fp => fp.Forma_Pago == "FP17").FirstOrDefault();
                        //int indice = listarDrownListModel.FormaPagos.LastIndexOf(x)
                        //luego indico cual es la fila a quita
                        listarDrownListModel.FormaPagos.Remove(formPago);
                    }




                    //llenar el combox forma de pago
                    this.cboFormaPago.ValueMember = "Forma_Pago";
                    this.cboFormaPago.DisplayMember = "Descripcion";
                    this.cboFormaPago.DataSource = listarDrownListModel.FormaPagos;

                    //llenar el combox tipo de tarjeta
                    this.cboTipoTarjeta.ValueMember = "Tipo_Tarjeta";
                    this.cboTipoTarjeta.DisplayMember = "Tipo_Tarjeta";
                    this.cboTipoTarjeta.DataSource = listarDrownListModel.TipoTarjeta;

                    //llenar el combox condicion de pago
                    this.cboCondicionPago.ValueMember = "Condicion_Pago";
                    this.cboCondicionPago.DisplayMember = "Descripcion";
                    this.cboCondicionPago.DataSource = listarDrownListModel.CondicionPago;

                    //llenar el combox condicion de pago
                    this.cboEntidadFinanciera.ValueMember = "Entidad_Financiera";
                    this.cboEntidadFinanciera.DisplayMember = "Descripcion";
                    this.cboEntidadFinanciera.DataSource = listarDrownListModel.EntidadFinanciera;

                    //indicar que se puede ejecutar al evento Select de Forma de pago
                    ejecutarEventoSelect = true;

                }
                else
                {
                    MessageBox.Show(listarDrownListModel.Mensaje, "Sistema COVENTAF");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Sistema COVENTAF");
            }
        }


        private void txtTarjetaCordoba_TextChanged(object sender, EventArgs e)
        {

        }

        //private void txtEfectivoDolar_TextChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (this.txtEfectivoDolar.Enabled)
        //        {
        //            //obtener el valor del textbox, ademas valida por si el textbox esta vacio
        //            decimal valor = this.txtEfectivoDolar.Text.Trim().Length == 0 ? 0.00M : Convert.ToDecimal(this.txtEfectivoDolar.Text);
        //            //hacer la conversion al tipo de  cambio del dia             
        //            this.lblConvertidorDolares.Text = $"U${valor.ToString("N2")} = C${(valor * tipoCambioOficial).ToString("N2")}";
        //        }
        //    }
        //    catch
        //    {

        //    }
        //}

        /*************************************************   EVENTO CLICK ***********************************************************************************************************************/
        #region Evento Click
        private void btnEfectivoCordobas_Click(object sender, EventArgs e)
        {
            //comprobar si no esta bloqueado el metodo de pago
            if (!bloquearMetodoPago)
            {
                this.cboFormaPago.SelectedValue = "0001";
                this.lblTituloMontoGeneral.Text = "Monto - Efectivo C$:";
                this.lblTituloCombox.Visible = false;
                this.lblTituloDocumento.Visible = false;
                this.lblConvertidorDolares.Visible = false;

                //poner visible el label F11 Tarjeta Dolar
                SetCambiarEstadoVisibleLableF11Dolar("F11_ED", true);
                //cambiar de estado solo si el cajero decidio cambiar el modo de pago
                setCambiarEstadoTextBoxMetodoPago(teclaPresionadaXCajero, false);
                //indicar que el cajero presiono F1;
                teclaPresionadaXCajero = "F1";
                //cambiar el estado del textbox y habilitarlo
                setCambiarEstadoTextBoxMetodoPago(teclaPresionadaXCajero, true);

                txtEfectivoCordoba.SelectionStart = 0;
                txtEfectivoCordoba.SelectionLength = this.txtEfectivoCordoba.Text.Length;
                txtEfectivoCordoba.Focus();

                ActivarfocusMontoGeneral();
            }
            else
            {
                MessageBox.Show("Ya se cobró el total de la factura", "Sistema COVENTAF");
            }
        }

        private void lblEfectivoCordobas_Click(object sender, EventArgs e)
        {
            btnEfectivoCordobas_Click(null, null);
        }

        private void lblEfectivoDolar_Click(object sender, EventArgs e)
        {
            //comprobar si no esta bloqueado el metodo de pago
            if (!bloquearMetodoPago)
            {
                this.cboFormaPago.SelectedValue = "0001";

                this.lblTituloMontoGeneral.Text = "Monto - Efectivo U$:";
                //desactivar el texbox y mostrar la suma pagado por el cliente en caso que existen varios tipo de pago
                setCambiarEstadoTextBoxMetodoPago(teclaPresionadaXCajero, false);
                //indicar la ultima tecla ejecutado por el cajero
                teclaPresionadaXCajero = "F11_ED";
                //
                SetCambiarEstadoVisibleLableF11Dolar(teclaPresionadaXCajero, false);
                //actualizar el estado del textbox ademas mostrar el monto a pagar en dolares
                setCambiarEstadoTextBoxMetodoPago(teclaPresionadaXCajero, true);

                this.lblConvertidorDolares.Visible = true;
                this.txtEfectivoDolar.SelectionStart = 0;
                this.txtEfectivoDolar.SelectionLength = this.txtEfectivoDolar.Text.Length;
                this.txtEfectivoDolar.Focus();

                ActivarfocusMontoGeneral();
            }
            else
            {
                MessageBox.Show("Ya se cobró el total de la factura", "Sistema COVENTAF");
            }
        }

        private void btnChequeCordobas_Click(object sender, EventArgs e)
        {
            //comprobar si no esta bloqueado el metodo de pago
            if (!bloquearMetodoPago)
            {
                this.cboFormaPago.SelectedValue = "0002";

                this.lblTituloCombox.Text = "Entidad Financiera:";
                this.lblTituloMontoGeneral.Text = "Monto Cheque C$:";
                //  this.lblTituloCom
                //this.pnlTipoTarjeta.Visible = false;
                //this.pnlTipoCredito.Visible = false;
                this.lblConvertidorDolares.Visible = false;


                //cambiar de estado solo si el cajero decidio cambiar el modo de pago
                setCambiarEstadoTextBoxMetodoPago(teclaPresionadaXCajero, false);

                //poner visible el label F11 Tarjeta Dolar
                SetCambiarEstadoVisibleLableF11Dolar("F11_CHD", true);
                //indicar que el cajero presiono F2;
                teclaPresionadaXCajero = "F2";
                //cambiar el estado del textbox y habilitarlo
                setCambiarEstadoTextBoxMetodoPago(teclaPresionadaXCajero, true);

                this.txtChequeCordoba.SelectionStart = 0;
                this.txtChequeCordoba.SelectionLength = this.txtChequeCordoba.Text.Length;
                this.txtChequeCordoba.Focus();

                ActivarfocusMontoGeneral();
            }
            else
            {
                MessageBox.Show("Ya se cobró el total de la factura", "Sistema COVENTAF");
            }
        }
        private void lblChequeCordobas_Click(object sender, EventArgs e)
        {
            btnChequeCordobas_Click(null, null);
        }

        private void lblChequeDolar_Click(object sender, EventArgs e)
        {
            //comprobar si no esta bloqueado el metodo de pago
            if (!bloquearMetodoPago)
            {
                this.cboFormaPago.SelectedValue = "0002";

                this.lblTituloMontoGeneral.Text = "Monto Cheque U$:";
                //desactivar el texbox y mostrar la suma pagado por el cliente en caso que existen varios tipo de pago
                setCambiarEstadoTextBoxMetodoPago(teclaPresionadaXCajero, false);
                //indicar la ultima tecla ejecutado por el cajero
                teclaPresionadaXCajero = "F11_CHD";
                //
                SetCambiarEstadoVisibleLableF11Dolar(teclaPresionadaXCajero, false);
                //actualizar el estado del textbox ademas mostrar el monto a pagar en dolares
                setCambiarEstadoTextBoxMetodoPago(teclaPresionadaXCajero, true);

                this.lblConvertidorDolares.Visible = true;
                this.txtChequeDolar.SelectionStart = 0;
                this.txtChequeDolar.SelectionLength = this.txtChequeDolar.Text.Length;
                this.txtChequeDolar.Focus();

                ActivarfocusMontoGeneral();
            }
            else
            {
                MessageBox.Show("Ya se cobró el total de la factura", "Sistema COVENTAF");
            }
        }

        private void btnTarjetaCordobas_Click(object sender, EventArgs e)
        {

            if (!bloquearMetodoPago)
            {
                this.cboFormaPago.SelectedValue = "0003";

                this.lblTituloMontoGeneral.Text = "Monto Tarjeta C$:";
                //this.pnlTipoTarjeta.Visible = true;
                //this.pnlTipoCredito.Visible = false;
                this.lblConvertidorDolares.Visible = false;

                //cambiar el estado de visible al label F11 Tarjeta Dolar
                setCambiarEstadoTextBoxMetodoPago(teclaPresionadaXCajero, false);

                //activo obligatoriamente por haber presionado F11 para Tarjeta para Dolares (F11 )
                SetCambiarEstadoVisibleLableF11Dolar("F11_TD", true);

                //cambiar el estado e indicar que se presiono F3
                teclaPresionadaXCajero = "F3";
                setCambiarEstadoTextBoxMetodoPago(teclaPresionadaXCajero, true);

                //poner el foco en el textbox
                this.txtTarjetaCordoba.SelectionStart = 0;
                this.txtTarjetaCordoba.SelectionLength = this.txtTarjetaCordoba.Text.Length;
                this.txtTarjetaCordoba.Focus();

                ActivarfocusMontoGeneral();
            }
            else
            {
                MessageBox.Show("Ya se cobró el total de la factura", "Sistema COVENTAF");
            }
        }

        private void lblTarjetaCordobas_Click(object sender, EventArgs e)
        {
            btnTarjetaCordobas_Click(null, null);
        }

        private void lblTarjetaDolar_Click(object sender, EventArgs e)
        {
            if (!bloquearMetodoPago)
            {
                this.cboFormaPago.SelectedValue = "0003";
                this.lblTituloMontoGeneral.Text = "Monto Tarjeta U$:";
                //desactivar el texbox y mostrar la suma pagado por el cliente en caso que existen varios tipo de pago
                setCambiarEstadoTextBoxMetodoPago(teclaPresionadaXCajero, false);
                //actualizar el estado. indicar la ultima tecla ejecutado por el cajero
                teclaPresionadaXCajero = "F11_TD";
                SetCambiarEstadoVisibleLableF11Dolar(teclaPresionadaXCajero, false);
                //actualizar el estado del textbox ademas mostrar el monto a pagar en Cordobas y dolares
                setCambiarEstadoTextBoxMetodoPago(teclaPresionadaXCajero, true);
                this.lblConvertidorDolares.Visible = true;

                this.txtTarjetaDolar.SelectionStart = 0;
                this.txtTarjetaDolar.SelectionLength = this.txtTarjetaDolar.Text.Length;
                this.txtTarjetaDolar.Focus();

                ActivarfocusMontoGeneral();
            }
            else
            {
                MessageBox.Show("Ya se cobró el total de la factura", "Sistema COVENTAF");
            }
        }

        private void btnCredito_Click(object sender, EventArgs e)
        {
            if (!bloquearMetodoPago)
            {
                this.cboFormaPago.SelectedValue = "0004";
                this.lblTituloMontoGeneral.Text = "Monto Credito C$:";
                //this.pnlTipoTarjeta.Visible = false;
                //this.pnlTipoCredito.Visible = true;
                this.lblConvertidorDolares.Visible = false;
                SetCambiarEstadoVisibleLableF11Dolar("", false);

                //cambiar el estado de visible al label F11 Tarjeta Dolar
                setCambiarEstadoTextBoxMetodoPago(teclaPresionadaXCajero, false);
                //cambiar el estado e indicar que se presiono F3
                teclaPresionadaXCajero = "F5";
                setCambiarEstadoTextBoxMetodoPago(teclaPresionadaXCajero, true);

                this.txtCredito.SelectionStart = 0;
                this.txtCredito.SelectionLength = this.txtCredito.Text.Length;
                this.txtCredito.Focus();

                ActivarfocusMontoGeneral();

            }
            else
            {
                MessageBox.Show("Ya se cobró el total de la factura", "Sistema COVENTAF");
            }
        }

        private void lblCredito_Click(object sender, EventArgs e)
        {
            btnCredito_Click(null, null);
        }

        private void Devolucion_Vale()
        {
            //revisar si esta pagado
            if (!bloquearMetodoPago)
            {







                //this.lblTituloMontoGeneral.Text = "Monto del Vale C$:";

                //this.lblConvertidorDolares.Visible = true;
                SetCambiarEstadoVisibleLableF11Dolar("", false);

                //cambiar el estado e indicar que se presiono F6
                teclaPresionadaXCajero = "Vale";
                setCambiarEstadoTextBoxMetodoPago(teclaPresionadaXCajero, true);



                ListarDevolucionesCliente();

            }
            else
            {
                MessageBox.Show("Ya se cobró el total de la factura", "Sistema COVENTAF");
            }
        }


        private void BtnCreditoCortoPlazo_Click(object sender, EventArgs e)
        {
            if (!bloquearMetodoPago)
            {
                this.cboFormaPago.SelectedValue = "FP17";

                this.lblTituloMontoGeneral.Text = "Cred Cort. Plz C$:";
                //this.pnlTipoTarjeta.Visible = false;
                //this.pnlTipoCredito.Visible = false;
                this.lblConvertidorDolares.Visible = false;
                SetCambiarEstadoVisibleLableF11Dolar("", false);

                //cambiar el estado de visible 
                setCambiarEstadoTextBoxMetodoPago(teclaPresionadaXCajero, false);
                //cambiar el estado e indicar que se presiono F6
                teclaPresionadaXCajero = "F6";
                setCambiarEstadoTextBoxMetodoPago(teclaPresionadaXCajero, true);


                this.txtCreditoCortoPlz.SelectionStart = 0;
                this.txtCreditoCortoPlz.SelectionLength = this.txtCreditoCortoPlz.Text.Length;
                this.txtCreditoCortoPlz.Focus();

                ActivarfocusMontoGeneral();

            }
            else
            {
                MessageBox.Show("Ya se cobró el total de la factura", "Sistema COVENTAF");
            }
        }

        private void lblCreditoCortoPlazo_Click(object sender, EventArgs e)
        {
            BtnCreditoCortoPlazo_Click(null, null);
        }

        private void btnGiftCardCordobar_Click(object sender, EventArgs e)
        {
            if (!bloquearMetodoPago)
            {
                this.cboFormaPago.SelectedValue = "FP01";
                this.lblTituloMontoGeneral.Text = "Monto Gift Card C$:";
                //this.pnlTipoTarjeta.Visible = false;
                //this.pnlTipoCredito.Visible = false;
                this.lblConvertidorDolares.Visible = false;

                //cambiar el estado de visible al label F11 Tarjeta Dolar
                setCambiarEstadoTextBoxMetodoPago(teclaPresionadaXCajero, false);

                //activo por defecto el evento F11 para Tarjeta para Dolares (F11 )
                SetCambiarEstadoVisibleLableF11Dolar("F11_GCD", true);

                //cambiar el estado e indicar que se presiono F6
                teclaPresionadaXCajero = "F7";
                setCambiarEstadoTextBoxMetodoPago(teclaPresionadaXCajero, true);

                //poner el foco en el textbox
                this.txtGiftCardCordoba.SelectionStart = 0;
                this.txtGiftCardCordoba.SelectionLength = this.txtGiftCardCordoba.Text.Length;
                this.txtGiftCardCordoba.Focus();

                ActivarfocusMontoGeneral();
            }
            else
            {
                MessageBox.Show("Ya se cobró el total de la factura", "Sistema COVENTAF");
            }
        }

        private void lblGiftCardCordoba_Click(object sender, EventArgs e)
        {
            btnGiftCardCordobar_Click(null, null);
        }

        private void lblGiftCardDolar_Click(object sender, EventArgs e)
        {
            if (!bloquearMetodoPago)
            {
                this.lblTituloMontoGeneral.Text = "Monto Gift Card U$:";
                //desactivar el texbox y mostrar la suma pagado por el cliente en caso que existen varios tipo de pago
                setCambiarEstadoTextBoxMetodoPago(teclaPresionadaXCajero, false);
                //actualizar el estado. indicar la ultima tecla ejecutado por el cajero
                teclaPresionadaXCajero = "F11_GCD";
                SetCambiarEstadoVisibleLableF11Dolar(teclaPresionadaXCajero, false);
                //actualizar el estado del textbox ademas mostrar el monto a pagar en Cordobas y dolares
                setCambiarEstadoTextBoxMetodoPago(teclaPresionadaXCajero, true);
                this.lblConvertidorDolares.Visible = true;

                this.txtGiftCardDolar.SelectionStart = 0;
                this.txtGiftCardDolar.SelectionLength = this.txtGiftCardDolar.Text.Length;
                this.txtGiftCardDolar.Focus();

                ActivarfocusMontoGeneral();
            }
            else
            {
                MessageBox.Show("Ya se cobró el total de la factura", "Sistema COVENTAF");
            }
        }

        private void btnOtros_Click(object sender, EventArgs e)
        {
            if (!bloquearMetodoPago)
            {
                this.cboFormaPago.Enabled = true;
                this.lblTituloMontoGeneral.Text = "Monto C$:";
                this.lblConvertidorDolares.Visible = false;

                ////cambiar el estado de visible al label F11 Dolar
                setCambiarEstadoTextBoxMetodoPago(teclaPresionadaXCajero, false);

                ////activo por defecto el evento F11 para Tarjeta para Dolares (F11 )
                //SetCambiarEstadoVisibleLableF11Dolar("F11_GCD", true);

                ////cambiar el estado e indicar que se presiono F10
                teclaPresionadaXCajero = "F10";
                setCambiarEstadoTextBoxMetodoPago(teclaPresionadaXCajero, true);

                ////poner el foco en el textbox
                //this.txtGiftCardCordoba.SelectionStart = 0;
                //this.txtGiftCardCordoba.SelectionLength = this.txtGiftCardCordoba.Text.Length;
                //this.txtGiftCardCordoba.Focus();

                // desplegar el combox automaticamente
                cboFormaPago.DroppedDown = true;
            }
            else
            {
                MessageBox.Show("Ya se cobró el total de la factura", "Sistema COVENTAF");
            }
        }

        private void lblOtros_Click(object sender, EventArgs e)
        {
            btnOtros_Click(null, null);
        }

        #endregion fin Click
        /***************************************************************************************************************************************************************************************/



        /*************************************** EVENTOS KEYPRESS ************************************************************************************************************************************/
        #region eventos de los textBox KEYPRRESS

        //txtEfectivoCordoba_KeyPress
        private void txtEfectivoCordoba_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Services.Utilidades.UnPunto(e, this.txtEfectivoCordoba.Text.Trim(), ref bandera);

            //if (e.KeyChar == 13 && this.txtEfectivoCordoba.Text.Trim().Length > 0)
            //{
            //    //llamar el metodo asignar pago
            //    AsginarMetodoPago("0001", "EFECTIVO", Convert.ToDecimal(this.txtEfectivoCordoba.Text), 'L', true, "F1", null);
            //    setCambiarEstadoTextBoxMetodoPago(teclaPresionadaXCajero, false);
            //    this.txtEfectivoCordoba.Enabled = false;
            //    teclaPresionadaXCajero = "";
            //    this.btnGuardar.Focus();
            //}

        }

        //txtEfectivoDolar_KeyPress
        private void txtEfectivoDolar_KeyPress(object sender, KeyPressEventArgs e)
        {
            Services.Utilidades.UnPunto(e, this.txtEfectivoDolar.Text.Trim(), ref bandera);
            if (e.KeyChar == 13)
            {

                //asignar el metodo de pago
                Asginar_Pago_Pos("0001", "EFECTIVO (DOLAR)", Convert.ToDecimal(this.txtEfectivoDolar.Text), 'D', true, "F11_ED", null);

                //desactivar el texbox y mostrar la suma pagado por el cliente en caso que existen varios tipo de pago
                setCambiarEstadoTextBoxMetodoPago(teclaPresionadaXCajero, false);

                SetCambiarEstadoVisibleLableF11Dolar("F11_ED", false);
                this.lblConvertidorDolares.Visible = false;
                //cambiar el estado ya que fue utilizado
                teclaPresionadaXCajero = "";
            }
        }



        private void txtChequeDolar_KeyPress(object sender, KeyPressEventArgs e)
        {
            Services.Utilidades.UnPunto(e, this.txtChequeDolar.Text.Trim(), ref bandera);
            if (e.KeyChar == 13)
            {
                //asignar el metodo de pago
                Asginar_Pago_Pos("0002", "CHEQUE (DOLAR)", Convert.ToDecimal(this.txtChequeDolar.Text), 'D', true, "F11_ED", this.cboEntidadFinanciera.SelectedValue.ToString(), null, null, null, this.txtDocumento.Text);

                //desactivar el texbox y mostrar la suma pagado por el cliente en caso que existen varios tipo de pago
                setCambiarEstadoTextBoxMetodoPago(teclaPresionadaXCajero, false);

                SetCambiarEstadoVisibleLableF11Dolar("F11_ED", false);
                this.lblConvertidorDolares.Visible = false;
                //cambiar el estado ya que fue utilizado
                teclaPresionadaXCajero = "";
            }
        }

        private void txtTarjetaCordoba_KeyPress(object sender, KeyPressEventArgs e)
        {
            Services.Utilidades.UnPunto(e, this.txtTarjetaCordoba.Text.Trim(), ref bandera);

            if (e.KeyChar == 13 && txtTarjetaCordoba.Text.Trim().Length > 0)
            {

                //llamar el metodo asignar pago
                Asginar_Pago_Pos("0003", "TARJETA", Convert.ToDecimal(this.txtTarjetaCordoba.Text), 'L', true, "F3", null, this.cboTipoTarjeta.SelectedValue.ToString(), null, null, this.txtDocumento.Text);
                setCambiarEstadoTextBoxMetodoPago(teclaPresionadaXCajero, false);
                //cambiar el estado ya que fue utilizado
                teclaPresionadaXCajero = "";
            }
        }

        private void txtTarjetaDolar_KeyPress(object sender, KeyPressEventArgs e)
        {
            Services.Utilidades.UnPunto(e, this.txtTarjetaDolar.Text.Trim(), ref bandera);

            //if (e.KeyChar == 13 && this.txtTarjetaDolar.Text.Length > 0 && !char.IsDigit(e.KeyChar))
            //{

            //    //llamar el metodo asignar pago
            //    //oscar esta es la correcta
            //    //AsginarMetodoPago("Tarjeta (Dolar)", Convert.ToDecimal(this.txtTarjetaDolar.Text), 'D', true, "F11_TD", this.cboTipoTarjeta.SelectedValue.ToString());
            //    //aqui falta el parametro el tipo de tarjeta
            //    AsginarMetodoPago("0003", "TARJETA (DOLAR)", Convert.ToDecimal(this.txtTarjetaDolar.Text), 'D', true, "F11_TD", null, this.cboTipoTarjeta.SelectedValue.ToString(), null, null, this.txtDocumento.Text);
            //    //cambiar el estado
            //    setCambiarEstadoTextBoxMetodoPago(teclaPresionadaXCajero, false);
            //    //cambiar el estado ya que fue utilizado
            //    teclaPresionadaXCajero = "";
            //    this.lblConvertidorDolares.Visible = false;
            //}

        }

        private void txtCredito_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Services.Utilidades.UnPunto(e, this.txtCredito.Text.Trim(), ref bandera);

            //if (e.KeyChar == 13 && this.txtCredito.Text.Length > 0 && !char.IsDigit(e.KeyChar))
            //{
            //    //llamar el metodo asignar pago                                           
            //    AsginarMetodoPago("0004", "CREDITO", Convert.ToDecimal(this.txtCredito.Text), 'L', true, teclaPresionadaXCajero, null, null, this.cboCondicionPago.SelectedValue.ToString(), this.cboCondicionPago.Text, this.txtDocumento.Text);
            //    //cambiar el estado
            //    setCambiarEstadoTextBoxMetodoPago(teclaPresionadaXCajero, false);
            //    //cambiar el estado ya que fue utilizado
            //    teclaPresionadaXCajero = "";
            //    this.lblConvertidorDolares.Visible = false;
            //}
        }

        //private void txtBono_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    Services.Utilidades.UnPunto(e, this.txtCreditoCortoPlz.Text.Trim(), ref bandera);
        //    if (e.KeyChar == 13 && this.txtCreditoCortoPlz.Text.Length > 0 && !char.IsDigit(e.KeyChar))
        //    {
        //        //llamar el metodo asignar pago                                           
        //        AsginarMetodoPago("0006", "BONO", Convert.ToDecimal(this.txtCreditoCortoPlz.Text), 'L', true, teclaPresionadaXCajero, null, null, null, null, this.txtDocumento.Text);
        //        //cambiar el estado
        //        setCambiarEstadoTextBoxMetodoPago(teclaPresionadaXCajero, false);
        //        //cambiar el estado ya que fue utilizado
        //        teclaPresionadaXCajero = "";
        //        this.lblConvertidorDolares.Visible = false;
        //    }
        //}

        private void txtGiftCardCordoba_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Services.Utilidades.UnPunto(e, this.txtGiftCardCordoba.Text.Trim(), ref bandera);
            //if (e.KeyChar == 13 && this.txtGiftCardCordoba.Text.Length > 0 && !char.IsDigit(e.KeyChar))
            //{
            //    //llamar el metodo asignar pago                                           
            //    AsginarMetodoPago("FP01", "GIFTCARD", Convert.ToDecimal(this.txtGiftCardCordoba.Text), 'L', true, teclaPresionadaXCajero, null, null, null, null, this.txtDocumento.Text);
            //    //cambiar el estado
            //    setCambiarEstadoTextBoxMetodoPago(teclaPresionadaXCajero, false);
            //    //cambiar el estado ya que fue utilizado
            //    teclaPresionadaXCajero = "";
            //    this.lblConvertidorDolares.Visible = false;
            //}
        }

        private void txtGiftCardDolar_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Services.Utilidades.UnPunto(e, this.txtGiftCardDolar.Text.Trim(), ref bandera);
            //if (e.KeyChar == 13 && this.txtGiftCardDolar.Text.Length > 0 && !char.IsDigit(e.KeyChar))
            //{
            //    //llamar el metodo asignar pago                                           
            //    AsginarMetodoPago("FP01", "GIFTCARD (DOLAR)", Convert.ToDecimal(this.txtGiftCardDolar.Text), 'D', true, teclaPresionadaXCajero, null, null, null, null, this.txtDocumento.Text);
            //    //cambiar el estado
            //    setCambiarEstadoTextBoxMetodoPago(teclaPresionadaXCajero, false);
            //    //cambiar el estado ya que fue utilizado
            //    teclaPresionadaXCajero = "";
            //    this.lblConvertidorDolares.Visible = false;
            //}
        }

        #endregion
        /********************************************************************************************************************************************************************************************/

        /// <summary>
        /// cmabiar el estado de visibilidad a los label F11
        /// </summary>
        /// <param name="labelName"></param>
        /// <param name="visible"></param>
        void SetCambiarEstadoVisibleLableF11Dolar(string labelName, bool visible)
        {
            this.lblEfectivoDolar.Visible = false;
            this.lblChequeDolar.Visible = false;
            this.lblTarjetaDolar.Visible = false;
            this.lblGiftCardDolar.Visible = false;

            switch (labelName)
            {
                case "F11_ED":
                    this.lblEfectivoDolar.Visible = visible;
                    break;
                case "F11_CHD":
                    this.lblChequeDolar.Visible = visible;
                    break;
                case "F11_TD":
                    this.lblTarjetaDolar.Visible = visible;
                    break;

                case "F11_GCD":
                    this.lblGiftCardDolar.Visible = visible;
                    break;
            }
        }


        /// <summary>
        /// cambiar el estado 
        /// </summary>
        /// <param name="textBoxName"></param>
        /// <param name="enable"></param>
        void setCambiarEstadoTextBoxMetodoPago(string textBoxName, bool enable)
        {
            decimal valorMonto = 0.0000M;

            //en caso textBoxName igual a cero terminar el proceso 
            if (textBoxName.Length == 0) return;

            this.txtEfectivoCordoba.Enabled = false;
            this.txtEfectivoDolar.Enabled = false;
            this.txtChequeCordoba.Enabled = false;
            this.txtChequeDolar.Enabled = false;
            this.txtTarjetaCordoba.Enabled = false;
            this.txtTarjetaDolar.Enabled = false;
            this.txtCredito.Enabled = false;
            this.txtCreditoCortoPlz.Enabled = false;
            this.txtGiftCardCordoba.Enabled = false;
            this.txtGiftCardDolar.Enabled = false;
            this.lblTituloCombox.Visible = false;
            this.lblTituloDocumento.Visible = false;
            this.txtDocumento.Visible = false;
            this.txtMontoGeneral.ReadOnly = false;

            this.cboCondicionPago.Visible = false;
            this.cboTipoTarjeta.Visible = false;
            this.cboEntidadFinanciera.Visible = false;
            this.cboValeCliente.Visible = false;
            //
            switch (textBoxName)
            {
                //F1= Efectivo Cordoba
                case "F1":
                    valorMonto = (enable ? GetMontoCobrar() : GetMontoMontoPorMetodoPagoX(textBoxName));
                    //revisar si estoy habilitando para obtener el monto a pagar, de lo contrario revisar si ya pago                   
                    this.txtEfectivoCordoba.Text = (enable ? valorMonto.ToString("N2") : $"C${ valorMonto.ToString("N2")}");
                    //this.txtEfectivoDolar.Text =$"U${(valorMonto / tipoCambio).ToString("N2")}";
                    this.txtEfectivoCordoba.Enabled = enable;
                    codigoTipoPago = "0001";
                    tipoPago = "EFECTIVO";
                    moneda = 'L';
                    break;

                //F11=Efectivo Dolar
                case "F11_ED":
                    //obtener el monto a pagar o el monto pagado por el cliente siempre en cordobas
                    valorMonto = (enable ? GetMontoCobrar() : GetMontoMontoPorMetodoPagoX(textBoxName));
                    montoFinalCobrarDolar = Math.Round((valorMonto / tipoCambioOficial), 2);
                    this.txtEfectivoDolar.Text = (enable ? (valorMonto / tipoCambioOficial).ToString("N2") : $"U${(valorMonto / tipoCambioOficial).ToString("N2")}");
                    this.lblConvertidorDolares.Text = $"U${(valorMonto / tipoCambioOficial).ToString("N2")} = C${valorMonto.ToString("N2")} ";
                    //this.txtEfectivoCordoba.Text = $"C${ valorMonto.ToString("N2")}";
                    this.txtEfectivoDolar.Enabled = enable;
                    valorMonto = valorMonto / tipoCambioOficial;
                    codigoTipoPago = "0001";
                    tipoPago = "EFECTIVO (DOLAR)";
                    moneda = 'D';
                    break;

                //F2=Efectivo Cordoba
                case "F2":
                    valorMonto = (enable ? GetMontoCobrar() : GetMontoMontoPorMetodoPagoX(textBoxName));
                    //obtener el monto a pagar o el monto pagado por el cliente                
                    this.txtChequeCordoba.Text = (enable ? valorMonto.ToString("N2") : $"C${valorMonto.ToString("N2")}");
                    this.txtChequeCordoba.Enabled = enable;
                    this.lblTituloCombox.Text = "Entidad Financiera:";
                    this.lblTituloCombox.Visible = enable;
                    this.cboEntidadFinanciera.Visible = enable;
                    this.lblTituloDocumento.Text = "Numero de cheque:";
                    this.lblTituloDocumento.Visible = enable;
                    this.txtDocumento.Visible = enable;
                    codigoTipoPago = "0002";
                    tipoPago = "CHEQUE";
                    moneda = 'L';

                    break;

                //F11  = cheque Dolar
                case "F11_CHD":
                    //obtener el monto a pagar o el monto pagado por el cliente
                    valorMonto = (enable ? GetMontoCobrar() : GetMontoMontoPorMetodoPagoX(textBoxName));
                    montoFinalCobrarDolar = Math.Round((valorMonto / tipoCambioOficial), 2);
                    this.txtChequeDolar.Text = (enable ? (valorMonto / tipoCambioOficial).ToString("N2") : $"U${ (valorMonto / tipoCambioOficial).ToString("N2")}");
                    this.lblConvertidorDolares.Text = $"U${(valorMonto / tipoCambioOficial).ToString("N2")} = C${valorMonto.ToString("N2")} ";
                    this.txtChequeDolar.Enabled = enable;
                    valorMonto = valorMonto / tipoCambioOficial;
                    this.lblTituloCombox.Text = "Entidad Financiera:";
                    this.lblTituloCombox.Visible = enable;
                    this.cboEntidadFinanciera.Visible = enable;
                    this.lblTituloDocumento.Text = "Numero de cheque:";
                    this.lblTituloDocumento.Visible = enable;
                    this.txtDocumento.Visible = enable;

                    codigoTipoPago = "0002";
                    tipoPago = "CHEQUE (DOLAR)";
                    moneda = 'D';
                    break;

                //F3=Tarjeta Cordoba
                case "F3":
                    //obtener el monto a pagar o el monto pagado por el cliente
                    valorMonto = (enable ? GetMontoCobrar() : GetMontoMontoPorMetodoPagoX(textBoxName));
                    this.txtTarjetaCordoba.Text = (enable ? valorMonto.ToString("N2") : $"C${ valorMonto.ToString("N2")}");
                    //this.txtTarjetaDolar.Text = $"U${(valorMonto / tipoCambio).ToString("N2")}";
                    this.txtTarjetaCordoba.Enabled = enable;

                    this.lblTituloCombox.Text = "Tipo de Tarjeta:";
                    this.lblTituloCombox.Visible = enable;
                    this.cboTipoTarjeta.Visible = enable;
                    this.lblTituloDocumento.Text = "Numero de Tarjeta:";
                    this.lblTituloDocumento.Visible = enable;
                    this.txtDocumento.Visible = enable;

                    codigoTipoPago = "0003";
                    tipoPago = "TARJETA";
                    moneda = 'L';

                    break;

                //F11_TD=Telca F11 Tarjeta Dolar
                case "F11_TD":
                    //obtener el monto a pagar o el monto pagado por el cliente
                    valorMonto = (enable ? GetMontoCobrar() : GetMontoMontoPorMetodoPagoX(textBoxName));
                    montoFinalCobrarDolar = Math.Round((valorMonto / tipoCambioOficial), 2);
                    this.txtTarjetaDolar.Text = (enable ? (valorMonto / tipoCambioOficial).ToString("N2") : $"U${(valorMonto / tipoCambioOficial).ToString("N2")}");
                    this.lblConvertidorDolares.Text = $"U${(valorMonto / tipoCambioOficial).ToString("N2")} = C${valorMonto.ToString("N2")} ";
                    this.txtTarjetaDolar.Enabled = enable;
                    valorMonto = valorMonto / tipoCambioOficial;

                    this.lblTituloCombox.Text = "Tipo de Tarjeta:";
                    this.lblTituloCombox.Visible = enable;
                    this.cboTipoTarjeta.Visible = enable;
                    this.lblTituloDocumento.Text = "Numero de Tarjeta:";
                    this.lblTituloDocumento.Visible = enable;
                    this.txtDocumento.Visible = enable;

                    codigoTipoPago = "0003";
                    tipoPago = "TARJETA (DOLAR)";
                    moneda = 'D';

                    break;

                //F5 =Credito cordoba
                case "F5":

                    //obtener el monto a pagar o el monto pagado por el cliente
                    valorMonto = (enable ? GetMontoCobrar() : GetMontoMontoPorMetodoPagoX(textBoxName));
                    this.txtCredito.Text = (enable ? valorMonto.ToString("N2") : $"C${ valorMonto.ToString("N2")}");
                    this.txtCredito.Enabled = enable;

                    this.lblTituloCombox.Text = "Condicion de pago:";
                    this.lblTituloCombox.Visible = enable;
                    this.cboCondicionPago.Visible = enable;
                    this.lblTituloDocumento.Text = "No. de documento:";
                    this.lblTituloDocumento.Visible = enable;
                    this.txtDocumento.Visible = enable;

                    codigoTipoPago = "0004";
                    tipoPago = "CREDITO";
                    moneda = 'L';

                    break;

                //F6=credito a corto plazo en cordobas
                case "F6":
                    //obtener el monto a pagar o el monto pagado por el cliente
                    valorMonto = (enable ? GetMontoCobrar() : GetMontoMontoPorMetodoPagoX(textBoxName));
                    //comprobar si el valor del monto a pagar es mayor que el credito
                    if (valorMonto > montoCreditCrtPlz)
                    {
                        //asignar el monto del credito disponible
                        valorMonto = montoCreditCrtPlz;
                    }


                    this.txtCreditoCortoPlz.Text = (enable ? valorMonto.ToString("N2") : $"C${ valorMonto.ToString("N2")}");
                    this.txtCreditoCortoPlz.Enabled = enable;


                    this.lblTituloDocumento.Text = "No. de documento:";
                    this.lblTituloDocumento.Visible = enable;
                    this.txtDocumento.Visible = enable;

                    this.lblConvertidorDolares.Text = $"Credito a corto plazo: C$ {listarDrownListModel.Clientes.U_U_Credito2Disponible?.ToString("N2")}";
                    //this.txtMontoGeneral.Text = listarDrownListModel.Clientes.U_U_Credito2Disponible?.ToString("N2");
                    this.lblConvertidorDolares.Visible = true;

                    codigoTipoPago = "FP17";
                    tipoPago = "CREDITO A CORTO PLAZO";
                    moneda = 'L';
                    break;

                //F7=GiftCard Cordobas
                case "F7":
                    valorMonto = (enable ? GetMontoCobrar() : GetMontoMontoPorMetodoPagoX(textBoxName));
                    //revisar si estoy habilitando para obtener el monto a pagar, de lo contrario revisar si ya pagp                       
                    this.txtGiftCardCordoba.Text = (enable ? GetMontoCobrar().ToString("N2") : $"C${ GetMontoMontoPorMetodoPagoX(textBoxName).ToString("N2")}");
                    this.txtGiftCardCordoba.Enabled = enable;

                    this.lblTituloDocumento.Text = "Numero de Tarjeta:";
                    this.lblTituloDocumento.Visible = enable;
                    this.txtDocumento.Visible = enable;

                    codigoTipoPago = "FP01";
                    tipoPago = "GIFTCARD";
                    moneda = 'L';

                    break;

                //F11_GCD= GiftCard Dolar
                case "F11_GCD":

                    //obtener el monto a pagar o el monto pagado por el cliente siempre en cordobas
                    valorMonto = (enable ? GetMontoCobrar() : GetMontoMontoPorMetodoPagoX(textBoxName));
                    montoFinalCobrarDolar = Math.Round((valorMonto / tipoCambioOficial), 2);
                    this.txtGiftCardDolar.Text = (enable ? (valorMonto / tipoCambioOficial).ToString("N2") : $"U${(valorMonto / tipoCambioOficial).ToString("N2")}");
                    this.lblConvertidorDolares.Text = $"U${(valorMonto / tipoCambioOficial).ToString("N2")} = C${valorMonto.ToString("N2")} ";
                    this.txtGiftCardDolar.Enabled = enable;
                    valorMonto = valorMonto / tipoCambioOficial;

                    this.lblTituloDocumento.Text = "Numero de Tarjeta:";
                    this.lblTituloDocumento.Visible = enable;
                    this.txtDocumento.Visible = enable;

                    codigoTipoPago = "FP01";
                    tipoPago = "GIFTCARD (DOLAR)";
                    moneda = 'D';

                    break;

                case "F10":
                    valorMonto = (enable ? GetMontoCobrar() : GetMontoMontoPorMetodoPagoX(textBoxName));
                    this.lblTituloDocumento.Text = "No. documento:";
                    this.lblTituloDocumento.Visible = enable;
                    this.txtDocumento.Visible = enable;
                    this.cboFormaPago.Enabled = enable;
                    moneda = 'L';
                    break;


                //Vale=el vale del clientes en cordobas
                case "Vale":
                    //obtener el monto a pagar o el monto pagado por el cliente
                    valorMonto = (enable ? GetMontoCobrar() : GetMontoMontoPorMetodoPagoX(textBoxName));
                    ////comprobar si el valor del monto a pagar es mayor que el credito
                    //if (valorMonto > montoCreditCrtPlz)
                    //{
                    //    //asignar el monto del credito disponible
                    //    valorMonto = montoCreditCrtPlz;
                    //}


                    this.txtMontoGeneral.Text = (enable ? valorMonto.ToString("N2") : $"C${ valorMonto.ToString("N2")}");
                    this.lblTituloDocumento.Text = "No Devolucion:";
                    this.lblTituloDocumento.Visible = enable;
                    this.cboValeCliente.Visible = enable;

                    //esta pendiente de cambiar
                    this.lblConvertidorDolares.Text = $"Devolucion del Vale Por: C$ {MontoFavorCliente.ToString("N2")}";
                    this.lblConvertidorDolares.Visible = true;

                    codigoTipoPago = "0005";
                    tipoPago = "DEVOLUCION-VALE";
                    moneda = 'L';
                    break;

            }

            this.txtMontoGeneral.Enabled = enable;
            //limpiar el monto
            this.txtMontoGeneral.Text = (enable ? valorMonto.ToString("N2") : "");
            this.txtDocumento.Text = "";

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nombreTeclaEjecutada"></param>
        /// <param name="retornarMonto"> le indico si retorna el monto en corodobas(L=Local) o _Dolares (D=Dolares). Por defecto es en Cordoba. </param>
        /// <returns></returns>

        decimal GetMontoMontoPorMetodoPagoX(string nombreTeclaEjecutada)
        {
            decimal montoPagado = 0;
            //si la moneda es cordoba. (-1 se refiere al vuelto)
            montoPagado = detallePagosPos.Where(mp => mp.Pago != "-1" && mp.DescripcionTecla == nombreTeclaEjecutada).Sum(x => x.MontoCordoba);
           
            return montoPagado;
        }


        decimal ObtenerNuevoTipoCambioExcto(decimal montoExacto, decimal montoConError, decimal montoDolares)
        {
            int contadorResta = 0;
            int contadorSuma = 0;
            
            montoExacto = Math.Round(montoExacto, 2);

            decimal nuevoTipoCambio = tipoCambioOficial;
            //si el monto con error es mayor entonces hay que ir restando el tipo de cambio

            decimal nuevoMonto = 0;
            bool continuarCiclo = true;
            bool sumarTipoCambio = (montoConError < montoExacto ? true : false);


            while (continuarCiclo)
            {

                nuevoTipoCambio = sumarTipoCambio ? nuevoTipoCambio + 0.00001M : nuevoTipoCambio - 0.00001M;
                //nuevoTipoCambio = Math.Round(tipoCambio, 4);
                nuevoMonto = montoDolares * nuevoTipoCambio;
                var nuevoMontoConDosDecimal = Math.Round(nuevoMonto, 2);
                if (montoExacto == nuevoMontoConDosDecimal)
                {
                    continuarCiclo = false;
                    break;
                }

                if (nuevoMontoConDosDecimal < montoExacto)
                {
                    //contar cuantas veces el sistema suma
                    contadorSuma += 1;
                    sumarTipoCambio = true;
                }
                else
                {
                    //contar cuantas veces el sistema resta
                    contadorResta += 1;
                    sumarTipoCambio = false;
                }


                //if (contadorResta > 20000)
                //{

                //}

                //if (contadorResta >20000)
                //{

                //}
            }
           
            return nuevoTipoCambio;
        }

        private void txtTarjetaDolar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.txtTarjetaDolar.Enabled)
                {

                    //obtener el valor del textbox, ademas valida por si el textbox esta vacio
                    decimal valor = this.txtTarjetaDolar.Text.Trim().Length == 0 ? 0.00M : Convert.ToDecimal(this.txtTarjetaDolar.Text);
                    if (Convert.ToDecimal(this.txtTarjetaDolar.Text) == diferenciaDolar)
                    {
                        //hacer la conversion al tipo de  cambio del dia             
                        this.lblConvertidorDolares.Text = $"U${valor.ToString("N2")} = C${diferenciaCordoba.ToString("N2")}";
                    }
                    else
                    {
                        //hacer la conversion al tipo de  cambio del dia             
                        this.lblConvertidorDolares.Text = $"U${valor.ToString("N2")} = C${(valor * tipoCambioOficial).ToString("N2")}";
                    }

                }
            }
            catch
            {

            }
        }



        /** evento ***/
        private void txtEfectivoCordoba_Enter(object sender, EventArgs e)
        {
            bandera = true;
        }

        private void txtEfectivoDolar_Enter(object sender, EventArgs e)
        {
            bandera = true;
        }

        //private void txtChequeCordoba_Enter(object sender, EventArgs e)
        //{
        //    bandera = true;
        //}

        //private void txtChequeDolar_Enter(object sender, EventArgs e)
        //{
        //    bandera = true;
        //}

        private void txtTarjetaCordoba_Enter(object sender, EventArgs e)
        {
            bandera = true;
        }

        private void txtTarjetaDolar_Enter(object sender, EventArgs e)
        {
            bandera = true;
        }

        private void txtCredito_Enter(object sender, EventArgs e)
        {
            bandera = true;
        }

        private void txtBono_Enter(object sender, EventArgs e)
        {
            bandera = true;
        }

        private void txtGiftCardCordoba_Enter(object sender, EventArgs e)
        {
            bandera = true;
        }

        private void txtGiftCardDolar_Enter(object sender, EventArgs e)
        {
            bandera = true;
        }


        private void btnGuardar_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            this.btnGuardar.Enabled = false;

            /// viewModelMetodoPago = new List<ViewMetodoPago>();

            //asignar el totol de retencion en caso que existiera

            _listVarFactura.TotalRetencion = totalRetenciones;
            _datoEncabezadoFact.MontoRetencion = totalRetenciones;
            //luego recopilar la informacion del metodo de pago que se obtuvo de la ventana metodo de pago
            RecopilarDatosMetodoPagoDetalleRetencion();

            if (detallePagosPos.Count > 0)
            {
                //guardar la factura
                GuardarFacturaAsync();
            }
            else
            {
                this.btnGuardar.Enabled = true;
            }

            this.Cursor = Cursors.Default;
        }

        private async void GuardarFacturaAsync()
        {
            try
            {
                //si existe la retencion, entonces restar la retencion. se va a restar la retencion solo para efecto de impremir la factura, pero en la base de datos se guarda sin restar la retencion
                //
                if (_datoEncabezadoFact.MontoRetencion > 0)
                {
                    decimal totalRetencionDolar = _listVarFactura.TotalRetencion / _listVarFactura.TipoDeCambio;
                    _datoEncabezadoFact.totalCordoba = _datoEncabezadoFact.totalCordoba - _listVarFactura.TotalRetencion;
                    _datoEncabezadoFact.totalDolar = _datoEncabezadoFact.totalDolar - totalRetencionDolar;
                }

                //llamar al servidor para guardar la factura
                var responseModel = new ResponseModel();
                //responseModel = await _facturaController.GuardarFacturaAsync(_modelFactura);

                //validar que el modelo este correcto antes de guardar en la base de datos
                if (_serviceFactura.ModeloUsuarioEsValido(_modelFactura, responseModel))
                {
                    responseModel = await _serviceFactura.GuardarFactura(_modelFactura, responseModel);

                    //comprobar si el servidor respondio con exito (1)
                    if (responseModel.Exito == 1)
                    {

                        //var Imprimir =new Reportes.TicketVenta();

                        //imprimir la factura
                         new Metodos.MetodoImpresion().ImprimirTicketFactura(_listDetFactura, _datoEncabezadoFact, detallePagosPos);
                        

                        bool existeVuelto = VueltoCliente < 0 ? true : false;
                        this.Hide();
                        var frmInf = new frmInformacion(VueltoCliente, existeVuelto);
                        frmInf.ShowDialog();
                        

                        ///MessageBox.Show(responseModel.Mensaje, "Sistema COVENTAF");
                        facturaGuardada = true;
                        //cerrar la ventana de metodo de pagos
                        this.Close();
                    }
                    else
                    {
                        this.btnGuardar.Enabled = true;
                        this.Cursor = Cursors.Default;
                        MessageBox.Show(responseModel.Mensaje, "Sistema COVENTAF");
                    }
                }
                else
                {
                    this.Cursor = Cursors.Default;
                    MessageBox.Show(responseModel.Mensaje, "Sistema COVENTAF");
                    this.btnGuardar.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show($"Error: Guardar Factura: {ex.Message}", "Sistema COVENTAF");
                this.btnGuardar.Enabled = true;
            }

        }

        public void RecopilarDatosMetodoPagoDetalleRetencion()//List<ViewMetodoPago> metodoPago, List<DetalleRetenciones> _detalleRetencion)
        {
            string TarjetaCredito = "0";
            string Condicion_Pago = "0";
            decimal saldo = 0.00M;

            _modelFactura.PagoPos = new List<Pago_Pos>();
            _modelFactura.FacturaRetenciones = new List<Factura_Retencion>();

           
            //var modelFactura = new ViewModelFacturacion();
            //modelFactura.Factura = new Facturas();
            //modelFactura.FacturaLinea = new List<Factura_Linea>();
            //_modelFactura.PagoPos = new List<Pago_Pos>();

            foreach (var mMetodoPago in detallePagosPos)
            {
                //aqui incluye el vuelto del cliente
                var datosPagosPos_ = new Pago_Pos();
                datosPagosPos_.Documento = _modelFactura.Factura.Factura;

                //consecutivo ej.: 0,1,2
                datosPagosPos_.Pago = mMetodoPago.Pago;
                datosPagosPos_.Caja = User.Caja;
                //F=factura
                datosPagosPos_.Tipo = "F";
                //30 dias 
                datosPagosPos_.Condicion_Pago = mMetodoPago.CondicionPago;
                            

                //
                datosPagosPos_.Entidad_Financiera = mMetodoPago.EntidadFinanciera;
                datosPagosPos_.Tipo_Tarjeta = mMetodoPago.TipoTarjeta;

                datosPagosPos_.Forma_Pago = mMetodoPago.FormaPago;
                datosPagosPos_.Numero = mMetodoPago.Numero;
                datosPagosPos_.Monto_Local = mMetodoPago.Moneda == 'L' ? mMetodoPago.MontoCordoba : 0.0000M;
                datosPagosPos_.Monto_Dolar = mMetodoPago.Moneda == 'D' ? mMetodoPago.MontoDolar : 0.0000M;
                datosPagosPos_.Autorizacion = null;
                datosPagosPos_.Cobro = null;
                datosPagosPos_.Cliente_Liquidador = null;
                //revisar
                datosPagosPos_.Tipo_Cobro = "T";
                datosPagosPos_.NoteExistsFlag = 0;
                datosPagosPos_.RecordDate = DateTime.Now;
                // datosPagosPos_.RowPointer = 098D98DA-038F-4E06-B8E4-B48843DEEC1A
                datosPagosPos_.CreatedBy = User.Usuario;
                datosPagosPos_.UpdatedBy = User.Usuario;
                datosPagosPos_.CreateDate = DateTime.Now;

                //seleccionaste tarjeta
                if (datosPagosPos_.Forma_Pago == "0003")
                {
                    //banpro, credomatic
                    TarjetaCredito = datosPagosPos_.Tipo_Tarjeta;
                }

                //credito
                if (datosPagosPos_.Forma_Pago == "0004")
                {
                    Condicion_Pago = datosPagosPos_.Condicion_Pago;
                }

                //verificar si la forma de pago del cliente es 0004=Credito o FP17=Credito a Corto Plazo, entonces agregar el monto de pago en saldo
                if (datosPagosPos_.Forma_Pago == "0004" || datosPagosPos_.Forma_Pago == "FP17")
                {
                    saldo = Math.Round(datosPagosPos_.Monto_Local, 2);
                }

                //comprobar si la moneda es Dolar
                if (mMetodoPago.Moneda == 'D')
                {
                    datosPagosPos_.Monto_Local = mMetodoPago.MontoCordoba;
                    datosPagosPos_.Monto_Dolar = mMetodoPago.MontoDolar;
                }

                //agregar nuevo registro a la clase FacturaLinea.
                _modelFactura.PagoPos.Add(datosPagosPos_);
            }

            if (VueltoCliente < 0)
            {
                //agregar registro del vuelo
                _modelFactura.PagoPos.Add(new Pago_Pos()
                {
                    Documento = _modelFactura.Factura.Factura,
                    Pago = "-1",
                    Caja = _modelFactura.Factura.Caja,                    
                    Tipo = "F",
                    Forma_Pago = "0001",
                    Monto_Local = VueltoCliente,
                    Monto_Dolar = 0,
                    Tipo_Cobro = "T"
                });
            }  

            foreach (var itemRetencion in detalleRetenciones)
            {
                var datosDetRetencion = new Factura_Retencion()
                {
                    Tipo_Documento = "F",
                    Factura = _listVarFactura.NoFactura,
                    Codigo_Retencion = itemRetencion.Retencion,
                    Monto = itemRetencion.Monto,
                    Doc_Referencia = itemRetencion.Referencia,
                    Base = itemRetencion.Base,
                    AutoRetenedora = itemRetencion.AutoRetenedora ? "S" : "N",
                    NoteExistsFlag = 0,
                    RecordDate = DateTime.Now,
                    CreatedBy = User.Usuario,
                    UpdatedBy = User.Usuario,
                    CreateDate = DateTime.Now
                };
                _modelFactura.FacturaRetenciones.Add(datosDetRetencion);
            }


            //asingar la tarjeta de credito por el metodo de pago que selecciono el cliente
            _modelFactura.Factura.Tarjeta_Credito = TarjetaCredito;
            _modelFactura.Factura.Condicion_Pago = Condicion_Pago;
            //agregar en el campo saldo en caso que sea credito o credito a corto plazo
            _modelFactura.Factura.Saldo = saldo;       
        }


        private void ActivarfocusMontoGeneral()
        {
            txtMontoGeneral.SelectionStart = 0;
            txtMontoGeneral.SelectionLength = this.txtMontoGeneral.Text.Length;
            txtMontoGeneral.Focus();
        }

    

        private void txtMontoGeneral_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //F11_ED =Efectivo Dolar ||F11_CHD = cheque Dolar, F11_TD=Tarjeta Dolar. F11_GCD= GiftCard Dolar
                if (teclaPresionadaXCajero == "F11_ED" || teclaPresionadaXCajero == "F11_CHD" || teclaPresionadaXCajero == "F11_TD" || teclaPresionadaXCajero == "F11_GCD")
                {
                    //obtener el valor del textbox, ademas valida por si el textbox esta vacio
                    decimal valor = this.txtMontoGeneral.Text.Trim().Length == 0 ? 0.00M : Convert.ToDecimal(this.txtMontoGeneral.Text);
                    if (Convert.ToDecimal(valor) == diferenciaDolar)
                    {
                        //hacer la conversion al tipo de  cambio del dia             
                        this.lblConvertidorDolares.Text = $"U${valor.ToString("N2")} = C${diferenciaCordoba.ToString("N2")}";
                    }
                    else
                    {
                        //hacer la conversion al tipo de  cambio del dia             
                        this.lblConvertidorDolares.Text = $"U${valor.ToString("N2")} = C${(valor * tipoCambioOficial).ToString("N2")}";
                    }
                }
            }
            catch
            {

            }
        }



        private bool ValidacionMontoExitosa()
        {
            bool resultExitoso = false;
            if (this.txtMontoGeneral.Text.Trim().Length == 0)
            {
                MessageBox.Show("Debes de Ingresar un monto", "Sistema COVENTAF");
                txtMontoGeneral.Focus();
            }
            else if (this.txtMontoGeneral.Text.Trim() =="0")
            {
                MessageBox.Show("Debes de Ingresar un monto superior que cero (0)", "Sistema COVENTAF");
                txtMontoGeneral.Focus();
            }
            else
            {
                bool existeVueltoCliente = new FuncionMetodoPago().PreCalculoExisteVueltoCliente(Convert.ToDecimal(this.txtMontoGeneral.Text), totalCobrarCordoba - montoPagadoCordoba, moneda, tipoCambioOficial);
                if (existeVueltoCliente && codigoTipoPago == "0001")
                {
                    resultExitoso = true;
                }
                else if (existeVueltoCliente && codigoTipoPago != "0001")
                {
                    resultExitoso = false;
                    MessageBox.Show("El monto se excede al valor a cobrar", "Sistema COVENTAF");
                    txtMontoGeneral.Focus();
                }
                else
                {
                    resultExitoso = true;
                }
            }
            
            return resultExitoso;
                     
        }

        private void txtMontoGeneral_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Services.Utilidades.UnPunto(e, this.txtMontoGeneral.Text.Trim(), ref bandera);
            if (_procesoFactura.NumeroDecimalCorrecto(e, this.txtMontoGeneral.Text, this.txtMontoGeneral.SelectedText.Length))
           {
                if (e.KeyChar == 13)
                {
                    //si la validacion no fue exitosa detener el proceso
                    if (!ValidacionMontoExitosa()) return;

                    if (teclaPresionadaXCajero == "F1" || teclaPresionadaXCajero == "F11_ED")
                    {
                        //llamar el metodo asignar pago
                        Asginar_Pago_Pos(codigoTipoPago, tipoPago, Convert.ToDecimal(this.txtMontoGeneral.Text), moneda, true, teclaPresionadaXCajero);
                        setCambiarEstadoTextBoxMetodoPago(teclaPresionadaXCajero, false);
                        teclaPresionadaXCajero = "";
                    }
                    //comprobar si el cajero esta ejecutando el evento Devolucion-Vale y tambien si ya selecciono vale del cliente
                    else if (teclaPresionadaXCajero == "Vale" && this.cboValeCliente.SelectedValue.ToString().Length > 0)
                    {
                        this.txtMontoGeneral.ReadOnly = false;
                        //llamar el metodo asignar pago
                        Asginar_Pago_Pos(codigoTipoPago, tipoPago, Convert.ToDecimal(this.txtMontoGeneral.Text), moneda, true, teclaPresionadaXCajero, null, null, null, null, this.cboValeCliente.SelectedValue.ToString());
                        setCambiarEstadoTextBoxMetodoPago(teclaPresionadaXCajero, false);
                        teclaPresionadaXCajero = "";
                    }
                    else if (teclaPresionadaXCajero == "F2" || teclaPresionadaXCajero == "F11_CHD")
                    {
                        // desplegar el combox automaticamente
                        this.cboEntidadFinanciera.DroppedDown = true;
                        this.cboEntidadFinanciera.Focus();
                    }
                    else if (teclaPresionadaXCajero == "F3" || teclaPresionadaXCajero == "F11_TD")
                    {
                        // desplegar el combox automaticamente
                        this.cboTipoTarjeta.DroppedDown = true;
                        this.cboTipoTarjeta.Focus();
                    }

                    else if (teclaPresionadaXCajero == "F5")
                    {
                        // desplegar el combox automaticamente
                        this.cboCondicionPago.DroppedDown = true;
                        this.cboCondicionPago.Focus();
                    }

                }

                //if ((e.KeyChar == 13) && (this.txtMontoGeneral.Text.Trim().Length > 0))
                //{
                //    MessageBox.Show("Debes de Ingresar un Monto", "Sistema COVENTAF");
                //    e.Handled = true;
                //    return;
                //}

                //if (e.KeyChar == 13 && this.txtMontoGeneral.Text.Trim() == "0")
                //{
                //    MessageBox.Show("Debes de Ingresar un monto superior a Cero (0)", "Sistema COVENTAF");
                //    e.Handled = true;
                //    return;
                //}


               
                
            }
            else
            {
                e.Handled = true;
            }

        }

        private void txtMontoGeneral_Leave(object sender, EventArgs e)
        {
            bandera = true;
        }

        private void txtDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (!ValidacionMontoExitosa()) return;

                //comprobar si es Cheque Cordobas o Cheque Dolar
                if (teclaPresionadaXCajero == "F2" || teclaPresionadaXCajero == "F11_CHD")
                {
                    //llamar el metodo asignar pago
                    Asginar_Pago_Pos(codigoTipoPago, tipoPago, Convert.ToDecimal(this.txtMontoGeneral.Text), moneda, true, teclaPresionadaXCajero, this.cboEntidadFinanciera.SelectedValue.ToString(), null, null, null, this.txtDocumento.Text);
                    setCambiarEstadoTextBoxMetodoPago(teclaPresionadaXCajero, false);
                    teclaPresionadaXCajero = "";
                }

                //comprobar si es tarjeta Cordobas o tarjeta Dolar
                else if (teclaPresionadaXCajero == "F3" || teclaPresionadaXCajero == "F11_TD")
                {
                    //llamar el metodo asignar pago
                    Asginar_Pago_Pos(codigoTipoPago, tipoPago, Convert.ToDecimal(this.txtMontoGeneral.Text), moneda, true, teclaPresionadaXCajero, null, this.cboTipoTarjeta.Text, null, null, this.txtDocumento.Text);
                    setCambiarEstadoTextBoxMetodoPago(teclaPresionadaXCajero, false);
                    teclaPresionadaXCajero = "";
                }
                //credito. si ha presiona la tecla F5 y el boton credito esta habilitado entonces se dispara
                else if (teclaPresionadaXCajero == "F5" && btnCredito.Enabled)
                {
                    //llamar el metodo asignar pago
                    Asginar_Pago_Pos(codigoTipoPago, tipoPago, Convert.ToDecimal(this.txtMontoGeneral.Text), moneda, true, teclaPresionadaXCajero, null, null,
                        this.cboCondicionPago.SelectedValue.ToString(), this.cboCondicionPago.Text, this.txtDocumento.Text);
                    setCambiarEstadoTextBoxMetodoPago(teclaPresionadaXCajero, false);
                    teclaPresionadaXCajero = "";
                }

                //F7= GiftCard Cordoba, F11_GCD=GiftCard Dolar 
                else if (teclaPresionadaXCajero == "F7" || teclaPresionadaXCajero == "F11_GCD")
                {
                    //llamar el metodo asignar pago
                    Asginar_Pago_Pos(codigoTipoPago, tipoPago, Convert.ToDecimal(this.txtMontoGeneral.Text), moneda, true, teclaPresionadaXCajero, null, null, null, null, this.txtDocumento.Text);
                    setCambiarEstadoTextBoxMetodoPago(teclaPresionadaXCajero, false);
                    teclaPresionadaXCajero = "";
                }

                //F6=Credito a corto plazo
                else if (teclaPresionadaXCajero == "F6")
                {
                    //primero verificar si el credito aplica para el pago
                    if (Convert.ToDecimal(this.txtMontoGeneral.Text) <= montoCreditCrtPlz)
                    {
                        montoCreditCrtPlz = montoCreditCrtPlz - Convert.ToDecimal(this.txtMontoGeneral.Text);
                        //llamar el metodo asignar pago
                        Asginar_Pago_Pos(this.cboFormaPago.SelectedValue.ToString(), this.cboFormaPago.Text, Convert.ToDecimal(this.txtMontoGeneral.Text), moneda, true, teclaPresionadaXCajero, null, null, null, null, this.txtDocumento.Text);
                        setCambiarEstadoTextBoxMetodoPago(teclaPresionadaXCajero, false);
                        teclaPresionadaXCajero = "";
                        //restar el credito                       
                        if (montoCreditCrtPlz > 0)
                        {
                            this.btnCreditoCortoPlazo.Enabled = true;
                            this.lblCreditoCortoPlazo.Enabled = true;
                        }
                        else
                        {
                            this.btnCreditoCortoPlazo.Enabled = false;
                            this.lblCreditoCortoPlazo.Enabled = false;
                        }
                    }
                    else
                    {
                        MessageBox.Show($"El Credito Corto Plazo del Cliente es {montoCreditCrtPlz.ToString("N2")}", "Sistema COVENTAF");
                        this.txtMontoGeneral.Text = montoCreditCrtPlz.ToString("N2");
                    }


                }

                else if (teclaPresionadaXCajero == "F10")
                {
                    //llamar el metodo asignar pago
                    Asginar_Pago_Pos(this.cboFormaPago.SelectedValue.ToString(), this.cboFormaPago.Text, Convert.ToDecimal(this.txtMontoGeneral.Text), moneda, true, teclaPresionadaXCajero, null, null, null, null, this.txtDocumento.Text);
                    setCambiarEstadoTextBoxMetodoPago(teclaPresionadaXCajero, false);
                    teclaPresionadaXCajero = "";

                }
            }
        }


        private async void ListarDevolucionesCliente()
        {
            try
            {
                var responseModel = new ResponseModel();
                responseModel.Data = new List<ViewDevoluciones>();
                responseModel = await new ServiceFormaPago().ListarDevolucionesClienteAsync(_listVarFactura.CodigoCliente, responseModel);
                if (responseModel.Exito == 1)
                {
                    listDevCliente = null;
                    listDevCliente = new List<ViewDevoluciones>();




                    listDevCliente = responseModel.Data as List<ViewDevoluciones>;
                    listDevCliente.Add(new ViewDevoluciones { Factura = "", Tipo_Documento = "ND", Saldo = 0, Monto_Local = 0, Monto_Dolar = 0 });

                    this.cboValeCliente.ValueMember = "Factura";
                    this.cboValeCliente.DisplayMember = "Factura";
                    this.cboValeCliente.DataSource = listDevCliente;
                    this.cboValeCliente.SelectedValue = "";

                    // desplegar el combox automaticamente
                    cboValeCliente.DroppedDown = true;

                }
                else
                {
                    MessageBox.Show(responseModel.Mensaje, "Sistema COVENTAF");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Sistema COVENTAF");
            }
        }

        private void cboFormaPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ejecutarEventoSelect)
            {
                this.cboFormaPago.Enabled = false;
                switch (this.cboFormaPago.SelectedValue.ToString())
                {
                    case "0001":
                        btnEfectivoCordobas_Click(null, null);
                        break;

                    //F1= Efectivo Cordoba
                    case "0002":
                        btnChequeCordobas_Click(null, null);
                        break;

                    case "0003":
                        btnTarjetaCordobas_Click(null, null);
                        break;

                    case "0004":
                        btnCredito_Click(null, null);
                        break;

                    case "0005":

                        Devolucion_Vale();

                        //por defecto el sistema selecciona otro metodo de pago
                        //this.cboFormaPago.SelectedValue = "0001";
                        break;

                    case "FP17":

                        BtnCreditoCortoPlazo_Click(null, null);
                        break;

                    case "FP01":
                        btnGiftCardCordobar_Click(null, null);
                        break;


                    default:
                        this.cboFormaPago.Enabled = true;
                        break;
                }
            }

        }

        private void cboValeCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cboValeCliente.SelectedValue.ToString().Trim().Length > 0)
            {
                //                private List<ViewDevoluciones> listDevCliente = new List<ViewDevoluciones>();
                //private string formaPagoVale;
                //private decimal MontoFavorCliente;

                //obtener la informacion del vale
                var consultaDevolucion = listDevCliente.Where(x => x.Factura == this.cboValeCliente.SelectedValue.ToString()).FirstOrDefault();
                //guardar el monto a favor del cliente 
                MontoFavorCliente = consultaDevolucion.Saldo;
                //pintar en pantalla el monto del vale
                this.lblConvertidorDolares.Text = $"Vale por: C${MontoFavorCliente.ToString("N2")}";
                //obtener el monto a cobra al cliente
                decimal montoCobrar = GetMontoCobrar();
                this.txtMontoGeneral.Text = montoCobrar > MontoFavorCliente ? MontoFavorCliente.ToString("N2") : montoCobrar.ToString("N2");
                this.txtMontoGeneral.ReadOnly = true;
                this.txtMontoGeneral.Focus();

            }
        }

       

        private void cboEntidadFinanciera_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 )
            {
                this.txtDocumento.Focus();
            }
        }

        private void cboValeCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                this.txtDocumento.Focus();
            }
        }

        private void cboTipoTarjeta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                this.txtDocumento.Focus();
            }
        }

        private void cboCondicionPago_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                this.txtDocumento.Focus();
            }
        }

        private void btnCreditoCortoPlazo_Click_1(object sender, EventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvDetallePago.RowCount > 0)
                {
                    int filaSeleccionada = dgvDetallePago.CurrentRow.Index;
                    if (MessageBox.Show("¿ Estas seguro de eliminar el metodo de pago seleccionado ?", "Sistema COVENTAF", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        //si la fila que se va eliminar tiene vuelto del cliente entonces se pone en cero
                        //VueltoCliente = (detallePagosPos[filaSeleccionada].VueltoCliente < 0 ? 0 : VueltoCliente);

                        bloquearMetodoPago = false;
                        montoPagadoCordoba = montoPagadoCordoba - detallePagosPos[filaSeleccionada].MontoCordoba;
                        montoPagadoDolar = montoPagadoDolar - detallePagosPos[filaSeleccionada].MontoDolar;
                        VueltoCliente = (detallePagosPos[filaSeleccionada].VueltoCliente < 0 ? 0 : VueltoCliente);

                        var montoCobrar = GetMontoCobrar() + (detallePagosPos[filaSeleccionada].VueltoCliente < 0 ? VueltoCliente : 0);

                        txtPendientePagarCliente.Text = $"C$ {montoCobrar.ToString("N2")}";

                        //                      private decimal montoPagadoCordoba = 0.0000M;
                        //private decimal montoPagadoDolar = 0.00M;

                        //eliminar el registro de la lista.
                        detallePagosPos.RemoveAt(filaSeleccionada);
                        //eliminar el registro del grid
                        dgvDetallePago.Rows.RemoveAt(filaSeleccionada);
                        int rows = 0;

                        foreach (var pagosPos in detallePagosPos)
                        {
                            //actualizar el consecutivo de la lista
                            pagosPos.Indice = rows;
                            dgvDetallePago.Rows[rows].Cells["Indice"].Value = rows.ToString();
                            rows += 1;
                        }

                        this.lblCambioCliente.Text = "C$ 0.00";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Sistema COVENTAF");
            }
        }

   

        private void btnRetenciones_Click(object sender, EventArgs e)
        {
            if (detallePagosPos.Count == 0)
            {
                if (TotalCobrar >= 1000)
                {
                    using (var frm = new frmRetenciones())
                    {
                        frm.montoTotal = TotalCobrar;
                        frm._detalleRetenciones = detalleRetenciones;
                        frm.ShowDialog();

                        if (frm.aplicarRetenciones)
                        {
                            detalleRetenciones = frm._detalleRetenciones;
                            totalRetenciones = frm.totalRetenciones;
                            this.lblTotalRetenciones.Text = $"Total Retenciones: C$ {totalRetenciones}";
                            TotalCobrar = TotalCobrarAux;
                            TotalCobrar = TotalCobrar - totalRetenciones;
                            EstablecerMontosInicio();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Para aplicar retenciones el monto tiene que ser de superior de 1000 cordobas", "Sistema COVENTAF");
                }


            }
            else
            {
                MessageBox.Show("Para aplicar retencion primero debes de resetear el Cobro", "Sistema COVENTAF");
            }


        }


    }
}
