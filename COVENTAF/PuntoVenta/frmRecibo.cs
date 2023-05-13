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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COVENTAF.PuntoVenta
{
    public partial class frmRecibo : Form
    {
        private decimal tipoCambio = 0.00M;
        private string recibo = "";
        public frmRecibo()
        {
            InitializeComponent();
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

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (Convert.ToDecimal(this.txtMontoGeneral.Text.Trim()) > 0)
            {
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


                using (var frmRecibirDinero = new frmPagosPos(null, _listVarFactura, datoEncabezadoFact, null))
                {
                    frmRecibirDinero.TipoDocumento = "R";
                    frmRecibirDinero.TotalCobrar = Utilidades.RoundApproximate(Convert.ToDecimal(this.txtMontoGeneral.Text), 2);
                    frmRecibirDinero.tipoCambioOficial = Utilidades.RoundApproximate(tipoCambio, 2);
                    frmRecibirDinero.factura = recibo;
                    frmRecibirDinero.lblTotalRetenciones.Visible = false;
                    frmRecibirDinero.btnRetenciones.Visible = false;

                    frmRecibirDinero.ShowDialog();
                }
                

            }
            else
            {
                MessageBox.Show("No se puede generar el recibo con este monto", "sistema COVENTAF");
            }
           
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
    }
}
