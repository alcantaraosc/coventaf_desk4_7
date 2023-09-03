using Api.Model.Modelos;
using Api.Model.View;
using Api.Model.ViewModels;
using Api.Service.DataService;
using Controladores;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace COVENTAF.PuntoVenta
{
    public partial class frmAperturaCaja : Form
    {
        private readonly CajaPosController _cajaPosController;
       
        public bool ExitoAperturaCaja = false;
        private decimal tipoCambio = 0.00M;



        #region codigo para mover pantalla
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        #endregion


        public frmAperturaCaja()
        {
            InitializeComponent();
            this._cajaPosController = new CajaPosController();
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

        private async void frmAperturaCaja_Load(object sender, EventArgs e)
        {

            this.Cursor = Cursors.WaitCursor;

            this.txtTienda.Text = User.NombreTienda;
            this.txtCajero.Text = User.Usuario;

            var responseModel = new ResponseModel();
            responseModel.Data = new List<ViewCajaDisponible>();
            responseModel.DataAux = new decimal();

            try
            {
                responseModel = await new ServiceCaja_Pos().ListarCajasDisponibles(User.Usuario, User.TiendaID, responseModel);// _serviceFactura.ListarFacturasAsync(filtroFactura, responseModel);                                
                if (responseModel.Exito == 1)
                {
                    this.btnAperturarCaja.Enabled = true;
                    //llenar el combox de la bodega
                    this.cboCaja.ValueMember = "Caja";
                    this.cboCaja.DisplayMember = "Ubicacion";
                    this.cboCaja.DataSource = responseModel.Data as List<ViewCajaDisponible>;
                    //obtener el tipo
                    tipoCambio = Convert.ToDecimal(responseModel.DataAux);
                    this.txtTipoCambio.Text = tipoCambio.ToString("N4");
                    
                }
                else
                {
                    this.btnAperturarCaja.Enabled = false;
                    MessageBox.Show(responseModel.Mensaje, "Sistema COVENTAF");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Sistema COVENTAF");

            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

       

        private async void btnAperturarCaja_Click(object sender, EventArgs e)
        {
            if (tipoCambio ==0.0000M)
            {
                MessageBox.Show("No se puede aperturar con un tipo cambio cambio cero", "Sistema COVENTAF");
                return;
            }

            if (MessageBox.Show("¿ Deseas crear la apertura de caja ?", "Sistema COVENTAF", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                var responseModel = new ResponseModel();
                responseModel = await _cajaPosController.GuardarAperturaCaja(this.cboCaja.SelectedValue.ToString(), User.Usuario, User.TiendaID, Convert.ToDecimal(this.txtMontoApertura.Text), tipoCambio);
                if (responseModel.Exito == 1)
                {
                    var listResult = responseModel.Data as List<string>;
                    //BodegaId
                    User.BodegaID = listResult[0];
                    //ConsecCierreCT
                    User.ConsecCierreCT = listResult[1];
                    User.Caja = this.cboCaja.SelectedValue.ToString();
                    MessageBox.Show(responseModel.Mensaje, "Sistema COVENTAF");
                    ExitoAperturaCaja = true;
                    this.Close();
                }
                else
                {
                    MessageBox.Show(responseModel.Mensaje, "Sistema COVENTAF");
                }
            }
        }
 
    }
}
