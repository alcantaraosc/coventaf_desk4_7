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

namespace COVENTAF.ModuloCliente
{
    public partial class frmCliente : Form
    {
        string Transition;
        //private ServiceLogIn serviceLogIn = new ServiceLogIn();
        public bool resultExitoso = false;

        #region codigo para mover pantalla
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        #endregion


        public frmCliente()
        {
            InitializeComponent();
        }

        private void barraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void frmCliente_Load(object sender, EventArgs e)
        {
            Transition = "FadeIn";
            tmTransition.Start();
            this.Top = this.Top + 15;
        }

        private void tmTransition_Tick(object sender, EventArgs e)
        {
            Utilidades.tmTransition_Tick(ref Transition, this.tmTransition, this);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            tmTransition.Start();
        }
    }
}
