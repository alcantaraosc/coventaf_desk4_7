using Api.Model.ViewModels;
using Api.Service.DataService;
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

            responseModel = await this.serviceLogIn.AutorizacionExitosa(txtUser.Text, txtPassword.Text, responseModel);
            if (responseModel.Exito ==1)
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
    }
}
