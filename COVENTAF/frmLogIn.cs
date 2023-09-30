using Api.Model.Modelos;
using Api.Model.ViewModels;
using Api.Service.DataService;
using Api.Setting;
using COVENTAF.Metodos;
using COVENTAF.Security;
using COVENTAF.Services;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace COVENTAF
{
    public partial class frmLogIn : Form
    {
        string Transition;
        private ServiceLogIn serviceLogIn = new ServiceLogIn();

        #region codigo para mover pantalla
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        #endregion

        public frmLogIn()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.tmTransition.Start();
            //Application.Exit();
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

            var responseModel = new ResponseModel();

            try
            {
                responseModel = await this.serviceLogIn.LogearseIn(txtUser.Text, txtPassword.Text, responseModel);
                //si respuesta del servidor fue exitosa entonces mostrar el menu principal del sistema
                if (responseModel.Exito == 1)
                {
                    //guardar los roles del usuario autenticado
                    UtilidadesMain.GuardarMemoriaRolesDelUsuario(responseModel.DataAux as List<RolesUsuarioActual>);
                    //verificar si el rol es administrador, le paso como parametro el Rol de Administrador (ADMIN)
                    bool rolIsAdmin = UtilidadesMain.AccesoPermitido(new List<string>() { "ADMIN"});
                    if (rolIsAdmin && this.cboCompañia.Text.Trim().Length==0)
                    {
                        //mostrar que compañia desea entrar
                        MostrarCompañia();
                    }
                    else
                    {
                        //si el rol es de admin entonces asignar el nombre de la compañia, sino se mantiene el rol asignado
                        if (rolIsAdmin) { User.Compañia = this.cboCompañia.Text; User.NombreTienda =  User.Compañia; }                     
                        //abrir la ventana principal del sistema
                        AbrirVentanaMain(responseModel);
                    }                  
                }
                //exito == 2 pide cambiar contraseña
                else if(responseModel.Exito ==2)
                {
                    this.Cursor = Cursors.Default;
                    AbrirVentaActualizarPassword(responseModel.Data as string);
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
            finally
            {
                this.Cursor = Cursors.Default;
            }                 
        }

        private void AbrirVentaActualizarPassword(string usuario)
        {
            using (var frmCambiarClave = new frmCambiarPassword())
            {
                frmCambiarClave.txtUsuario.Text = usuario;
                frmCambiarClave.ShowDialog();
            }
        }
               

        private void AbrirVentanaMain(ResponseModel responseModel)
        {          
            //ocultar el form de Login
            this.Hide();
            //enviar al menu principal los roles del usuario 
            var formDashboard = new formMenuPrincipal();
            //formDashboard.user = this.txtUser.Text;
            formDashboard.Show();
        }

        private void MostrarCompañia()
        {
            this.txtUser.Enabled = false;
            this.txtPassword.Enabled = false;
            this.lblCompañia.Visible = true;
            this.cboCompañia.Visible = true;
        }

        //private bool EresRolAmdinistrador()
        //{

        //}

        //private async void btnLogIn_Click(object sender, EventArgs e)
        //{
        //    if (this.txtUser.Text.Length == 0)
        //    {
        //        MessageBox.Show("Ingrese el Usuario", "Sistema COVENTAF");
        //        this.txtUser.Focus();
        //        return;
        //    }
        //    else if (this.txtPassword.Text.Length == 0)
        //    {
        //        MessageBox.Show("Ingrese el password", "Sistema COVENTAF");
        //        this.txtPassword.Focus();
        //        return;
        //    }

        //    this.Cursor = Cursors.WaitCursor;

        //    var responseModel = new ResponseModel();

        //    try
        //    {
        //        responseModel = await this.serviceLogIn.LogearseIn(txtUser.Text, txtPassword.Text, responseModel);
        //        //si respuesta del servidor fue exitosa entonces mostrar el menu principal del sistema
        //        if (responseModel.Exito == 1)
        //        {
        //            Utilidades.GuardarMemoriaRolesDelUsuario(responseModel.DataAux as List<RolesUsuarioActual>);
        //            //ocultar el form de Login
        //            this.Hide();
        //            //enviar al menu principal los roles del usuario 
        //            var formDashboard = new formMenuPrincipal();
        //            //formDashboard.user = this.txtUser.Text;
        //            formDashboard.Show();
        //        }
        //        else
        //        {
        //            MessageBox.Show(responseModel.Mensaje, "Sistema COVENTAF");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "Sistema COVENTAF");
        //    }
        //    finally
        //    {
        //        this.Cursor = Cursors.Default;
        //    }
        //}

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

        private void frmLogIn_Load(object sender, EventArgs e)
        {
            Transition = "FadeIn";
            tmTransition.Start();
            this.Top = this.Top + 15;
        }

        private void frmLogIn_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData ==(Keys.Shift | Keys.Control | Keys.Alt |Keys.Delete  ))
            {
                var frmConfigConexion = new frmConfigConexion();
                frmConfigConexion.ShowDialog();               
                frmConfigConexion.Dispose();
            }
        }

        private void tmTransition_Tick(object sender, EventArgs e)
        {
            UtilidadesMain.tmTransition_Tick(ref Transition, this.tmTransition, this);            
        }
    }
}
