using Api.Model.View;
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
    public partial class frmFiltroAvanzado : Form
    {
        string Transition;
        //clase para enviar el filtro.
        public FiltroFactura filtroFactura;
        public bool resultExitoso =false;
        public List<ViewFactura> listaFactura = new List<ViewFactura>();

        private ServiceFactura _serviceFactura = new ServiceFactura();
        

        #region codigo para mover pantalla
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        #endregion

        public frmFiltroAvanzado()
        {
            InitializeComponent();
        }


        private void barraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void frmFiltroAvanzado_Load(object sender, EventArgs e)
        {
            this.cboTipoFiltro.Text = filtroFactura.Tipofiltro;
            this.txtCodigoCliente.Text = filtroFactura.CodigoCliente;
            this.txtNombreCliente.Text = filtroFactura.NombreCliente;
            this.txtCodigoArticulo.Text = filtroFactura.CodigoArticulo;
            this.txtNombreArticulo.Text = filtroFactura.NombreArticulo;
            this.dtFechaDesde.Text = filtroFactura.FechaInicio.ToString();
            this.dtFechaHasta.Text = filtroFactura.FechaFinal.ToString();
            this.txtCaja.Text = filtroFactura.Caja;
            this.txtFacturaDesde.Text = filtroFactura.FacturaDesde;
            this.txtFacturaHasta.Text = filtroFactura.FacturaHasta;
            this.chkCobradas.Checked = filtroFactura.Cobradas;
            this.chkAnuladas.Checked = filtroFactura.Anuladas;
            this.chkFacturaCredito.Checked = filtroFactura.FacturaCredito;

            Transition = "FadeIn";
            tmTransition.Start();
            this.Top = this.Top + 15;
        }
        private bool FiltroValido()
        {
            bool valido = false;
            try
            {
                this.txtNombreCliente.Text = this.txtNombreCliente.Text.Replace(" ", "%");
                filtroFactura.Tipofiltro = this.cboTipoFiltro.Text;
                filtroFactura.CodigoCliente = this.txtCodigoCliente.Text;
                filtroFactura.NombreCliente = this.txtNombreCliente.Text;
                filtroFactura.CodigoArticulo = this.txtCodigoArticulo.Text;
                filtroFactura.NombreArticulo = this.txtNombreArticulo.Text;
                filtroFactura.FechaInicio = this.dtFechaDesde.Value;
                filtroFactura.FechaFinal = this.dtFechaHasta.Value;
                filtroFactura.Caja = this.txtCaja.Text;
                filtroFactura.FacturaDesde = this.txtFacturaDesde.Text;
                filtroFactura.FacturaHasta = this.txtFacturaHasta.Text;
                filtroFactura.Cobradas = this.chkCobradas.Checked;
                filtroFactura.Anuladas = this.chkAnuladas.Checked;
                filtroFactura.FacturaCredito = this.chkFacturaCredito.Checked;

                if (this.cboTipoFiltro.Text == "No Factura")
                {
                    filtroFactura.TipoDocumento = "F";
                }
                else if (this.cboTipoFiltro.Text == "Devolucion")
                {
                    filtroFactura.TipoDocumento = "D";
                }
                else
                {
                    filtroFactura.TipoDocumento = "R";
                }

                if (dtFechaDesde.Value.Date > dtFechaHasta.Value.Date)
                {
                    MessageBox.Show("La Fecha desde tiene que ser menor que la fecha hasta", "Sistema COVENTAF");
                }
                else if(!(this.chkCobradas.Checked || this.chkAnuladas.Checked) && (this.cboTipoFiltro.Text=="No Factura"))
                {
                    MessageBox.Show("Debes de seleccionar un estado: Cobradas o Anuladas", "Sistema COVENTAF");
                }
                else
                {
                    valido = true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return valido;
        }

        private async void btnAceptar_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            //this.dgvPuntoVenta.Cursor = Cursors.WaitCursor;

            try
            {
                if (FiltroValido())
                {
                    var responseModel = new ResponseModel();
                    responseModel.Data = new List<ViewFactura>();
                    responseModel = await _serviceFactura.FiltroAvanzado(filtroFactura, responseModel);

                    if (responseModel.Exito == 1)
                    {
                        resultExitoso = true;
                        listaFactura = responseModel.Data as List<ViewFactura>;
                    }
                    else
                    {
                        MessageBox.Show(responseModel.Mensaje, "Sistema COVENTAF");
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Sistema COVENTAF", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
                if (resultExitoso) this.Close();
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.tmTransition.Start();
        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            using(var frmBuscarDatosCliente = new frmBuscarCliente())
            {
                frmBuscarDatosCliente.ShowDialog();
                if (frmBuscarDatosCliente.resultExitosa)
                {
                    this.txtCodigoCliente.Text = frmBuscarDatosCliente.codigoCliente;
                    this.txtNombreCliente.Text = frmBuscarDatosCliente.nombreCliente;
                }                              
            }
        }

        private void cboTipoFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (this.cboTipoFiltro.Text)
            {
                case "No Factura":
                    this.chkCobradas.Checked = true;
                    this.chkCobradas.Enabled = true;
                    this.grpEstadoFactura.Enabled = true;
                    this.grpArticulo.Enabled = true;
                    this.chkFacturaCredito.Enabled = true;
                    break;

                case "Devolucion":
                    this.grpEstadoFactura.Enabled = true;
                    this.grpArticulo.Enabled = true;
                    this.chkCobradas.Enabled = false;
                    this.chkCobradas.Checked = false;
                    this.chkFacturaCredito.Enabled = true;
                    break;

                case "No Recibo":                    
                    this.grpEstadoFactura.Enabled = false;
                    this.grpArticulo.Enabled = false;
                    this.chkFacturaCredito.Enabled = false;

                    break;
            }
        }

        private void tmTransition_Tick(object sender, EventArgs e)
        {
            Utilidades.tmTransition_Tick(ref Transition, this.tmTransition, this);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.tmTransition.Start();
        }

        private void btnResetear_Click(object sender, EventArgs e)
        {
            this.cboTipoFiltro.Text = "";
            this.txtCodigoCliente.Text = "";
            this.txtNombreCliente.Text = "";
            this.txtCodigoArticulo.Text = "";
            this.txtNombreArticulo.Text = "";
            this.txtCaja.Text = "";
            this.txtFacturaDesde.Text = "";
            this.txtFacturaHasta.Text = "";
            this.chkCobradas.Checked = true;
            this.chkAnuladas.Checked = false;
            this.chkFacturaCredito.Checked = false;
        }
    }
}
