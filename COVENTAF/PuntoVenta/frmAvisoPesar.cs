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
    public partial class frmAvisoPesar : Form
    {
              
        string Transition;
        int tiempo = 1;

        public frmAvisoPesar()
        {
            InitializeComponent();
        }


        private void frmAvisoPesar_Load(object sender, EventArgs e)
        {
            Transition = "FadeIn";
            tmTransition.Start();
            this.Top = this.Top + 15;
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
            else if (Transition == "FadeIn")
            {
                if (this.Opacity == 1)
                {
                    tmTransition.Stop();
                    tmTemporizador.Start();

                }
                else
                {
                    this.Opacity = this.Opacity + 0.15;
                    this.Top = this.Top - 3;
                }
            }
        }

        private void tmTemporizador_Tick(object sender, EventArgs e)
        {
            if (tiempo == 1)
            {
                //detener el temporizador
                tmTemporizador.Stop();
                Transition = "FadeOut";
                tmTransition.Start();
            }
            else
            {
                tiempo += 1;
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
