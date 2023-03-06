using Api.Model.View;
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
    public partial class frmAnularFacturaPrueba : Form
    {
        #region codigo para mover pantalla
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        #endregion
        public frmAnularFacturaPrueba()
        {
            InitializeComponent();
        }

        private void btnBuscarFactura_Click(object sender, EventArgs e)
        {
            //var frmBuscarFactura = new frmAnularFactura(this);
            //frmBuscarFactura.ShowDialog();
        }

        private void btnCierre_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       

        public void CargarDatosFactura(ViewFactura datosFactura)
        {
            this.txtNoFactura.Text = datosFactura.Factura;
            this.txtCaja.Text = datosFactura.Caja;
            this.txtFecha.Text = datosFactura.Fecha.ToString("dd/MM/yyyy HH:mm");
            this.txtCodigoCliente.Text = datosFactura.Cliente;
            this.txtCliente.Text = datosFactura.Nombre_Cliente;
            this.txtCajero.Text = datosFactura.Usuario;
            this.txtNumCierre.Text = datosFactura.Usuario;
            this.txtTotal.Text =$"C$ {datosFactura.Total_Factura.ToString("N2")}";
            
        }

        private void btnAnularFactura_Click(object sender, EventArgs e)
        {
           
        }
    }
}
