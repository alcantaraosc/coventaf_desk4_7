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
    public partial class frmConvertidor : Form
    {
        string Transition;
        public decimal tipoCambio;
        public bool resultExitoso = false;

        #region codigo para mover pantalla
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        #endregion

        public frmConvertidor()
        {
            InitializeComponent();
        }

        private void barraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnCierre_Click(object sender, EventArgs e)
        {
            this.tmTransition.Start();
        }

        private void frmConvertidor_Load(object sender, EventArgs e)
        {
            this.txtMontoCordoba.Text =(1 * tipoCambio).ToString("N2");
            Transition = "FadeIn";
            tmTransition.Start();
            this.Top = this.Top + 15;

            this.txtMontoDolar.SelectionStart = 0;
            this.txtMontoDolar.SelectionLength = this.txtMontoDolar.Text.Length;
            this.txtMontoDolar.Focus();
        }

        private void tmTransition_Tick(object sender, EventArgs e)
        {
            UtilidadesMain.tmTransition_Tick(ref Transition, this.tmTransition, this);
        }

        private void txtDolar_KeyPress(object sender, KeyPressEventArgs e)
        {
            //validar el numero decimal
            if (UtilidadesMain.NumeroDecimalCorrecto(e, this.txtMontoDolar.Text, this.txtMontoDolar.SelectedText.Length))
           {
                if (e.KeyChar == 13)
                {
                    btnAceptar_Click(null, null);
                }
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtMontoDolar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string montoDolar = this.txtMontoDolar.Text.Replace("U$", "");
                //obtener el valor del textbox, ademas valida por si el textbox esta vacio
                decimal valor = montoDolar.Trim().Length == 0 ? 0.00M : Convert.ToDecimal(montoDolar);                
                valor = valor * tipoCambio;
                this.txtMontoCordoba.Text = $"C${valor.ToString("N2")}";
            }
            catch
            {

            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.tmTransition.Start();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            resultExitoso = true;
            this.tmTransition.Start();
        }
    }
}
