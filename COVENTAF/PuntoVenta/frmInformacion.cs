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
    public partial class frmInformacion : Form
    {
        string Transition;
        public frmInformacion(decimal vueltoCliente, bool existeVuelto)
        {
            InitializeComponent();
            this.lblTitulo.Text = existeVuelto ? "Vuelto del Cliente" : "Punto de Venta";
            this.lblCambio.Visible = existeVuelto;
            this.lblCambio.Text = $"Cambio: C$ {vueltoCliente * (-1)}";
        }

     

        private void frmInformacion_Load(object sender, EventArgs e)
        {
           
            Transition = "FadeIn";
            tmTransition.Start();
            this.Top=this.Top + 15;
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            Transition = "FadeOut";
            tmTransition.Start();
           
        }

        private void tmTransition_Tick(object sender, EventArgs e)
        {
            if (Transition == "FadeOut")
            {
                if (this.Opacity == 0)
                {
                    tmTransition.Stop();
                    this.Close();
                }
                else
                {
                    this.Opacity = this.Opacity - 0.15;
                    this.Top = this.Top + 3;
                }
            }
            else if (Transition =="FadeIn")
            {
                if (this.Opacity ==1)
                {
                    tmTransition.Stop();
                }
                else
                {
                    this.Opacity = this.Opacity + 0.15;
                    this.Top = this.Top - 3;
                }
            }
        }
    }
}
