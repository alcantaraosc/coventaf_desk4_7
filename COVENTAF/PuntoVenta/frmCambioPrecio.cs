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
    public partial class frmCambioPrecio : Form
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

        public frmCambioPrecio()
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
            
            this.txtPrecioDefinido.Focus();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {            
            if (Utilidades.AutorizacionExitosa())
            {               
                resultExitoso = true;
                this.tmTransition.Start();
            }                          
        }

       

        private void btnCancel_Click(object sender, EventArgs e)
        {
            resultExitoso = false;
            this.tmTransition.Start();
        }
        
        private void tmTransition_Tick(object sender, EventArgs e)
        {
            Utilidades.tmTransition_Tick(ref Transition, this.tmTransition, this);
        }

   
        private void txtPrecioDefinido_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Utilidades.NumeroDecimalCorrecto(e, this.txtPrecioDefinido.Text, this.txtPrecioDefinido.SelectedText.Length))
            {
                if (e.KeyChar == 13)
                {
                    //si la validacion no fue exitosa detener el proceso
                    if (!ValidacionPrecioExitosa()) return;
                    this.btnAceptar.Enabled = true;
                    this.btnAceptar.Focus();
                }
            }
            else
            {
                e.Handled = true;
            }
        }


        private bool ValidacionPrecioExitosa()
        {
            bool resultExitoso = false;
            if (this.txtPrecioDefinido.Text.Trim().Length == 0)
            {
                MessageBox.Show("Debes de Ingresar el precio", "Sistema COVENTAF");
                this.txtPrecioDefinido.Focus();
            }
            else if (this.txtPrecioDefinido.Text.Trim() == "0")
            {
                MessageBox.Show("Debes de Ingresar un monto superior que cero (0)", "Sistema COVENTAF");
                this.txtPrecioDefinido.Focus();
            }
            else
            {
                resultExitoso = true;
            }

            return resultExitoso;

        }

   
    }
}
