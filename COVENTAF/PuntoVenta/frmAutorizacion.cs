using Api.Model.Modelos;
using Api.Model.ViewModels;
using Api.Service.DataService;
using COVENTAF.Metodos;
using COVENTAF.Services;
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace COVENTAF.PuntoVenta
{
    public partial class frmAutorizacion : Form
    {
        string Transition;
        private ServiceLogIn serviceLogIn = new ServiceLogIn();
        public bool resultExitoso = false;

        #region codigo para mover pantalla
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        #endregion

        public frmAutorizacion()
        {
            InitializeComponent();
        }
        private void barraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }


        private void frmAutorizacion_Load(object sender, EventArgs e)
        {
            Transition = "FadeIn";
            tmTransition.Start();
            this.Top = this.Top + 15;

            this.txtUser.Text = "";
            this.txtUser.Focus();
        }

        private async void btnAceptar_Click(object sender, EventArgs e)
        {
            var responseModel = new ResponseModel();

            responseModel = await this.serviceLogIn.AutorizacionExitosa(txtUser.Text, txtPassword.Text, User.TiendaID, responseModel);
            if (responseModel.Exito == 1)
            {
                resultExitoso = true;
                this.tmTransition.Start();              
            }
            else
            {
                MessageBox.Show(responseModel.Mensaje, "Sistema COVENTAF");
            }
        }

        private void txtUser_Enter(object sender, EventArgs e)
        {
            this.AcceptButton = null;
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            //activar
            this.AcceptButton = this.btnAceptar;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.tmTransition.Start();
        }

        private void txtUser_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar ==13)
            {
                if (this.txtUser.Text.Trim().Length > 0)
                {
                    e.Handled = true;
                    this.txtPassword.Focus();
                }
            }           
        }

        private void tmTransition_Tick(object sender, EventArgs e)
        {
            UtilidadesMain.tmTransition_Tick(ref Transition, this.tmTransition, this);
        }
    }
}
