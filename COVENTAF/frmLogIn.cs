﻿using Api.Model.Modelos;
using Api.Model.Request;
using Api.Model.ViewModels;
using Api.Service.DataService;
using Controladores;
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

namespace COVENTAF
{
    public partial class frmLogIn : Form
    {
        private LoginController _loginController;

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        public frmLogIn()
        {
            InitializeComponent();
            this._loginController = new LoginController();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void titleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private async void btnLogIn_Click(object sender, EventArgs e)
        {
           
            if (this.txtUser.Text.Length == 0)
            {               
                MessageBox.Show("Ingrese el Usuario", "Sistema COVENTAF");
                this.txtUser.Focus();
                return;
            }
            else if (this.txtPassword.Text.Length == 0)
            {                
                MessageBox.Show("Ingrese el password", "Sistema COVENTAF");
                this.txtPassword.Focus();
                return;
            }

            this.Cursor = Cursors.WaitCursor;

            var crendenciales = new AuthRequest() { Usuario = this.txtUser.Text, Password = this.txtPassword.Text };
            var responseModel = new ResponseModel();

            responseModel = await this._loginController.Authenticate(crendenciales);
            if (responseModel.Exito == 1)
            {
                //ocultar el form de Login
                this.Hide();
                //var formDashboard = new frmDashboard(this, responseModel );
                //formDashboard.Show();
                
                var formDashboard = new formMenuPrincipal(responseModel);
                //formDashboard.user = this.txtUser.Text;
                formDashboard.Show();
            }
            else
            {                
                MessageBox.Show(responseModel.Mensaje);
            }

            this.Cursor = Cursors.Default;
        }

        private void txtUser_Enter(object sender, EventArgs e)
        {
            this.AcceptButton = null;
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            //asignar el boton Iniciar login para que permita dar enter.
            this.AcceptButton = this.btnLogIn;
        }

        private void txtUser_KeyPress(object sender, KeyPressEventArgs e)
        {
            //si presiona la tecla enter
            if (e.KeyChar == 13 && this.txtUser.Text.Trim().Length > 0)
            {
                e.Handled = true;
                this.txtPassword.Focus();
            }
        }
    }
}
