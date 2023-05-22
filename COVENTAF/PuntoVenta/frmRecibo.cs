using Api.Model.Modelos;
using Api.Model.ViewModels;
using Api.Service.DataService;
using COVENTAF.Metodos;
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
    public partial class frmRecibo : Form
    {
        private decimal tipoCambio = 0.00M;
        private string recibo = "";

        ViewModelFacturacion _modelFactura = new ViewModelFacturacion();

        #region codigo para mover pantalla
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        #endregion

        public frmRecibo()
        {
            InitializeComponent();
        }

        private void barraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            using (var frmFiltrarCliente = new frmBuscarCliente())
            {
                frmFiltrarCliente.ShowDialog();
                if (frmFiltrarCliente.resultExitosa)
                {
                    this.txtCodigoCliente.Text = frmFiltrarCliente.codigoCliente;
                    this.txtNombreCliente.Text = frmFiltrarCliente.nombreCliente;
                    this.txtMontoGeneral.Focus();
                }
            }


        }



        private bool VerificarDatos()
        {
            bool result = false;
            if (this.txtCodigoCliente.Text.Trim().Length == 0 || this.txtNombreCliente.Text.Trim().Length == 0)
            {
                MessageBox.Show("Faltan los datos del cliente", "Sistema COVENTAF");
                this.txtCodigoCliente.Focus();
            }
            else if (this.txtMontoGeneral.Text.Trim().Length ==0)
            {
                MessageBox.Show("No se puede generar el recibo con este monto", "sistema COVENTAF");
                this.txtMontoGeneral.Focus();
            }
            else if (Convert.ToDecimal(this.txtMontoGeneral.Text.Trim()) == 0)
            {
                MessageBox.Show("Debes de ingresar un monto", "sistema COVENTAF");
                this.txtMontoGeneral.Focus();
            }
            else
            {
                result = true;
            }

            return result;                
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (VerificarDatos())
            {
                bool GuardarRecibo = false;

                var _listVarFactura = new VariableFact() { CodigoCliente = this.txtCodigoCliente.Text };

                var datoEncabezadoFact = new Encabezado()
                {
                    NoFactura = recibo,
                    fecha = DateTime.Now,
                    caja = User.Caja,
                    tipoCambio = tipoCambio,
                    codigoCliente = this.txtCodigoCliente.Text,
                    cliente = txtNombreCliente.Text,

                    atentidoPor = User.NombreUsuario,

                };
                _modelFactura.Documento_Pos = null;
                _modelFactura.Documento_Pos = new Documento_Pos();
                RecolectarInformacion(_modelFactura);


                using (var frmRecibirDinero = new frmPagosPos(_modelFactura, _listVarFactura, datoEncabezadoFact, null))
                {
                    frmRecibirDinero.TipoDocumento = "R";
                    frmRecibirDinero.TotalCobrar = Utilidades.RoundApproximate(Convert.ToDecimal(this.txtMontoGeneral.Text), 2);
                    frmRecibirDinero.tipoCambioOficial = Utilidades.RoundApproximate(tipoCambio, 2);
                    frmRecibirDinero.factura = recibo;
                    frmRecibirDinero.lblTotalRetenciones.Visible = false;
                    frmRecibirDinero.btnRetenciones.Visible = false;
                    frmRecibirDinero.ShowDialog();
                    ////obtener informacion si el cajero cancelo o dio guardar factura
                    GuardarRecibo = frmRecibirDinero.facturaGuardada;
                }

                //verificar si el sistema guardo el recibo o esta cancelando la ventana metodo de pago
                if (GuardarRecibo)
                {
                    //cerrar la ventana
                    this.Close();
                    GuardarRecibo = true;
                }
            }            
        }

        private void RecolectarInformacion(ViewModelFacturacion _modelFactura)
        {

            // Getting Ip address of local machine…
            // First get the host name of local machine.
            string strNombreEquipo = string.Empty;
            // Getting Ip address of local machine…
            // First get the host name of local machine.
            strNombreEquipo = Dns.GetHostName();


            _modelFactura.Documento_Pos = new Documento_Pos()
            {
                Documento = recibo,
                Tipo = "R",
                Caja = User.Caja,
                Caja_Cobro = User.Caja,
                Correlativo = "REC",
                Perfil = null,
                Vendedor = User.BodegaID,
                Cliente = txtCodigoCliente.Text,
                Nombre_Cliente = txtNombreCliente.Text,
                Cajero = User.Usuario,
                Impuesto1 = 0.00M,
                Impuesto2 = 0.00M,
                Descuento = 0.000M,
                Total_Pagar = Convert.ToDecimal(this.txtMontoGeneral.Text),
                Total = 0.00M,
                Fch_Hora_Creacion = DateTime.Now,
                Fch_Hora_Cobro = DateTime.Now,
                Fch_Hora_Anula = null,
                Exportado = "N",
                Estado_Cobro = "P",
                Saldo = Convert.ToDecimal(this.txtMontoGeneral.Text),
                Saldo_Reporte = 0.00M,
                Moneda_Doc = "L",
                Fecha_Vence = DateTime.Now,
                Listo_Inventario = "S",
                Nivel_Precio = User.NivelPrecio,
                Moneda_Nivel = "L",
                Version = 1,
                FechaNac_Cliente = null,
                Telefono_Cliente = "0",
                Nit_Cliente = "CEDULA_CLIENTE",
                Notas = this.txtObservaciones.Text,
                Pais = null,
                Clase_Documento = "N",
                Direccion = "",
                Exportado_Tienda = null,
                Condicion_Pago_Apa = null,
                Doc_Cc = recibo,
                Tipo_Doc_Cc = "REC",
                Cargado_Cc = "S",
                Cargado_Cg = "N",
                Devuelve_Dinero = "N",
                Doc_Cc_Anul = null,
                Tipo_Doc_Cc_Anul = null,
                Genero_Factura_Inicio = "N",
                Afecta_Contabil = null,
                Efectivo_Devuelto = null,
                Tipo_Cambio = tipoCambio,
                Beneficiario = null,
                Moneda = null,
                Subtipo = null,
                Id_Beneficiario = null,
                Usuario_Ult_Impre = null,
                Fch_Hora_Ult_Impre = null,
                Usuario_Aplicacion = null,
                Fch_Hora_Aplicacio = null,
                Usuario_Anulacion = null,
                Estado_Impresion = null,
                Telefono_Beneficia = null,
                Ncf = null,
                Tipo_Ncf = null,
                Num_Cierre = User.ConsecCierreCT,
                Recibido_De = txtNombreCliente.Text,
                Resolucion = null,
                Cod_Clase_Doc = "01",
                Doc_Express = "N",
                Mensajero = null,
                Cliente_Express = null,
                Entrega_Exprss_A = null,
                Estado_Express = "P",
                Monto_Entregado = null,
                Monto_Devuelto = null,
                Fch_Envio = null,
                Fch_Entrega = null,
                Motiv_Cancela_Expr = null,
                Nota_Express = null,
                Base_Impuesto1 = 0.00M,
                Base_Impuesto2 = 0.00M,
                Doc_Fiscal = null,
                Prefijo = null,
                Pedido_Autorizado = null,
                Doc_Cc_Anticipo = null,
                NombreMaquina = strNombreEquipo,
                Cierre_Anulacion = null,
                Doc_Sincronizado = "N",
                Monto_Bonificado = 0.00M,
                Es_Doc_Externo = "N",
                Tienda_Enviado = User.TiendaID,
                Usa_Despachos = "N",
                Clave_Referencia_De = null,
                Fecha_Referencia_De = null,
                Forma_Pago = null,
                Uso_Cfdi = null,
                Justi_Dev_Haciend = null,
                Clave_De = null,
                NoteExistsFlag = 0,
                RecordDate = DateTime.Now,
                //RowPointer = "255255",
                CreatedBy = User.Usuario,
                UpdatedBy = User.Usuario,
                CreateDate = DateTime.Now,
                Actividad_Comercial = null,
                Monto_Otro_Cargo = null,
                Monto_Total_Iva_Devuelto = null,
                Ncf_Modificado = null
            };

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmRecibo_Load(object sender, EventArgs e)
        {
             MostrarInfInicioRecibo();
        }

        private async void MostrarInfInicioRecibo()
        {
           
            var listarDatosFactura = new ListarDatosFactura();
            //se refiere a la bodega. mal configurado en base de datos
            listarDatosFactura.tipoDeCambio = 0.00M;
            listarDatosFactura.NoFactura = "";
            try
            {
                listarDatosFactura = await new ServiceDocumento_Pos().ListarInformacionInicioRecibo();
                if (listarDatosFactura.Exito == 1)
                {
                    tipoCambio = Utilidades.RoundApproximate(listarDatosFactura.tipoDeCambio, 4); 
                    recibo = listarDatosFactura.NoFactura;

                    this.lblNoFactura.Text = $"No. Recibo: { recibo}";
                    this.lblFecha.Text =$"Fecha: {DateTime.Now.ToString("dd/MM/yyyy")}";
                    this.lblTipoCambio.Text =$"Tipo Cambio: {tipoCambio.ToString("N2")}";
                    this.lblCaja.Text = $"Caja: {User.Caja}";

                    this.txtCodigoCliente.SelectionStart = 0;
                    this.txtCodigoCliente.SelectionLength = this.txtCodigoCliente.Text.Length;
                    this.txtCodigoCliente.Focus();

                }
                else
                {

                    MessageBox.Show(listarDatosFactura.Mensaje, "Sistema COVENTAF");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                //-1 indica que existe algun error del servidor
                listarDatosFactura.Exito = -1;
                listarDatosFactura.Mensaje = ex.Message;
            }
            finally
            {
                this.Cursor = Cursors.Default;               
            }
        }

        private void txtMontoGeneral_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Utilidades.NumeroDecimalCorrecto(e, this.txtMontoGeneral.Text, this.txtMontoGeneral.SelectedText.Length))
            {
                if (e.KeyChar == 13)
                {
                    //si la validacion no fue exitosa detener el proceso
                    if (!ValidacionMontoExitosa()) return;
                    this.btnRecibir.Enabled = true;
                    this.btnRecibir.Focus();
                }
            }
            else
            {
                e.Handled = true;
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
            else if (this.txtMontoGeneral.Text.Trim() == "0")
            {
                MessageBox.Show("Debes de Ingresar un monto superior que cero (0)", "Sistema COVENTAF");
                txtMontoGeneral.Focus();
            }
            else
            {
                resultExitoso = true;
            }

            return resultExitoso;

        }
       
    }
}
