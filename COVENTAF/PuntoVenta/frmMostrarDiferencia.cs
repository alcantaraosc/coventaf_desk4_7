using Api.Model.Modelos;
using Api.Model.ViewModels;
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
    public partial class frmMostrarDiferencia : Form
    {
        public bool resultExitoso = false;
        
        public ViewModelCierre viewModelCierre = new ViewModelCierre();
   
        public frmMostrarDiferencia()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            resultExitoso = true;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmMostrarDiferencia_Load(object sender, EventArgs e)
        {
            foreach(var item in viewModelCierre.Cierre_Det_Pago)
            {
                this.dgvDiferencia.Rows.Add(item.Tipo_Pago, item.Total_Sistema.ToString("N2"), item.Total_Usuario.ToString("N2"), item.Diferencia.ToString("N2"));
            }
            this.lblDiferenciaTotal.Text = $"Diferencia Total {viewModelCierre.Cierre_Pos.Total_Diferencia.ToString("N2")}";
        }
    }
}
