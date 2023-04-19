using Api.Model.Modelos;
using Api.Model.View;
using Api.Model.ViewModels;
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

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void frmAperturaCaja_Load(object sender, EventArgs e)
        {
            this.txtTienda.Text = User.NombreTienda;
            this.txtCajero.Text = User.Usuario;

            var responseModel = new ResponseModel();

            try
            {
                responseModel = await _cajaPosController.ListarCajasDisponible(User.Usuario, User.TiendaID);

                if (responseModel.Exito == 1)
                {

                    //llenar el combox de la bodega
                    this.cboCaja.ValueMember = "Caja";
                    this.cboCaja.DisplayMember = "Ubicacion";
                    this.cboCaja.DataSource = responseModel.Data as List<ViewCajaDisponible>;
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
        }

        private async void btnAperturarCaja_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿ Deseas crear la apertura de caja ?", "Sistema COVENTAF", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                var responseModel = new ResponseModel();
                responseModel = await _cajaPosController.GuardarAperturaCaja(this.cboCaja.SelectedValue.ToString(), User.Usuario, User.TiendaID, Convert.ToDecimal(this.txtMontoApertura.Text));
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
