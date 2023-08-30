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

namespace COVENTAF.Security
{
    public partial class frmCambiarPassword : Form
    {
        string Transition;

        #region codigo para mover pantalla
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        #endregion

        public frmCambiarPassword()
        {
            InitializeComponent();
        }

        private void barraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void frmCambiarPassword_Load(object sender, EventArgs e)
        {
            Transition = "FadeIn";
            tmTransition.Start();
            this.Top = this.Top + 15;
        }

        private void tmTransition_Tick(object sender, EventArgs e)
        {
            UtilidadesMain.tmTransition_Tick(ref Transition, this.tmTransition, this);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private async void btnAceptar_Click(object sender, EventArgs e)
        {

            if (this.txtNuevoPassword.Text.Trim() != this.txtConfirmarPassword.Text.Trim())
            {
                MessageBox.Show("Tu contraseña de confirmacion es diferente", "Sistema COVENTAF");
                return;
            }

           
            if (MessageBox.Show("¿ Estas seguro de actualizar tu password ?", "Sistema COVENTAF", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                var responseModel = new ResponseModel();
                responseModel = await new ServiceUsuario().ActualizarPassword(this.txtUsuario.Text.Trim(), this.txtNuevoPassword.Text.Trim(), responseModel);
                if (responseModel.Exito ==1)
                {
                    MessageBox.Show(responseModel.Mensaje, "Sistema COVENTAF");
                    MessageBox.Show("Vuelva abrir la aplicacion para iniciar sesion ", "Sistema COVENTAF");
                    Application.Exit();
                }
                else
                {
                    MessageBox.Show(responseModel.Mensaje, "Sistema COVENTAF");
                }
            }
        }

      
    }
}
