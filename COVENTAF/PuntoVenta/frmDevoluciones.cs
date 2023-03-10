using Api.Model.Modelos;
using Api.Model.View;
using Api.Model.ViewModels;
using Api.Service.DataService;
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
    public partial class frmDevoluciones : Form
    {
        private ViewModelFacturacion modelFactura;
        private ServiceDevolucion _serviceDevolucion = new ServiceDevolucion();

        public string factura = "0300376";
        public string numeroCierre = "CT1000000005143";



        #region codigo para mover pantalla
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        #endregion
        public frmDevoluciones()
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
        }

        private void btnAnularFactura_Click(object sender, EventArgs e)
        {
           
        }


        private async void frmDevoluciones_Load(object sender, EventArgs e)
        {
            ResponseModel responseModel = new ResponseModel();
            responseModel.Data = new ViewModelFacturacion();

            modelFactura = new ViewModelFacturacion();
            modelFactura.Factura = new Facturas();
            modelFactura.FacturaLinea = new List<Factura_Linea>();
            modelFactura.PagoPos = new List<Pago_Pos>();
            modelFactura.FacturaRetenciones = new List<Factura_Retencion>();

            responseModel = await _serviceDevolucion.BuscarFacturaPorNoFactura(factura, numeroCierre, responseModel);
            if (responseModel.Exito == 1)
            {
                modelFactura = responseModel.Data as ViewModelFacturacion;
                
                foreach(var factLinea in modelFactura.FacturaLinea)
                {
                    this.dgvDetalleFacturaOriginal.Rows.Add(factLinea.Articulo, factLinea.Descripcion, Math.Round(factLinea.Cantidad, 2), factLinea.Precio_Unitario);
                }


                ////agregar un tipo de retencion al grid
                //this.dgvDetalleRetenciones.Rows.Add(this.cboRetenciones.SelectedValue.ToString(), this.cboRetenciones.Text, Math.Round(montoTotal * (_datos.Porcentaje / 100), 2),
                //                                    montoTotal, $"RET-#{longitudGrid + 1}", (_datos.Es_AutoRetenedor == "S" ? true : false));

            }
            else
            {
                MessageBox.Show(responseModel.Mensaje, "Sistema COVENTAF");
            }
        }

        void BuscarFactura()
        {

        }
    }
}
