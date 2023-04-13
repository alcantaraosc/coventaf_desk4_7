using Api.Model.Modelos;
using Api.Model.ViewModels;
using Api.Service.DataService;
using System;
using System.Windows.Forms;

namespace COVENTAF.PuntoVenta
{
    public partial class frmAutorizacion : Form
    {
        private ServiceLogIn serviceLogIn = new ServiceLogIn();
        public bool resultExitoso = false;

        public frmAutorizacion()
        {
            InitializeComponent();
        }

        private void frmAutorizacion_Load(object sender, EventArgs e)
        {
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
                this.Close();
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
            this.Close();
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
    }
}
