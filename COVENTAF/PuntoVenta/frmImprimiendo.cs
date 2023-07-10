﻿using COVENTAF.Services;
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
    public partial class frmImprimiendo : Form
    {
        public string factura;
        public bool esFactura = true;
        string Transition;
        int tiempo = 1;
        public frmImprimiendo()
        {
            InitializeComponent();
        }

        private void frmImprimiendo_Load(object sender, EventArgs e)
        {
            if (esFactura)
            {
                this.lblLabel.Text = $"Imprimiendo factura: {factura}";
            }
            else
            {
                this.lblLabel.Text = $"Imprimiendo Recibo";
                this.lblNoRecibo.Visible = true;
                this.lblNoRecibo.Text = factura;
            }
          
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
            if (tiempo==1)
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
