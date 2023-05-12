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
    public partial class frmRecibo : Form
    {
        public frmRecibo()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            using (var frmFiltrarCliente = new frmBuscarCliente())
            {
                frmFiltrarCliente.ShowDialog();
                if (frmFiltrarCliente.resultExitosa)
                {
                    this.txtCodigoCliente.Text = frmFiltrarCliente.codigoCliente;
                    this.txtNombreCliente.Text = frmFiltrarCliente.nombreCliente;
                }
            }

          
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (Convert.ToDecimal(this.txtMontoGeneral.Text.Trim()) > 0)
            {

            }
            else
            {
                MessageBox.Show("No se puede generar el recibo con este monto", "sistema COVENTAF");
            }
           
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
