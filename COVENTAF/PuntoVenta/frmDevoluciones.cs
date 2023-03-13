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
        private ViewModelFacturacion _devolucion;
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
            this.WindowState = FormWindowState.Maximized;

            this.lblNoFactura.Text = factura;
          

            ResponseModel responseModel = new ResponseModel();
            responseModel.Data = new ViewModelFacturacion();

            _devolucion = new ViewModelFacturacion();
            _devolucion.Factura = new Facturas();
            _devolucion.FacturaLinea = new List<Factura_Linea>();
            _devolucion.PagoPos = new List<Pago_Pos>();
            _devolucion.FacturaRetenciones = new List<Factura_Retencion>();

            responseModel = await _serviceDevolucion.BuscarFacturaPorNoFactura(factura, numeroCierre, responseModel);
            if (responseModel.Exito == 1)
            {
                _devolucion = responseModel.Data as ViewModelFacturacion;

                this.lblCaja.Text = _devolucion.Factura.Factura;


                foreach (var factLinea in _devolucion.FacturaLinea)
                {
                    this.dgvDetalleFacturaOriginal.Rows.Add(factLinea.Articulo, factLinea.Descripcion, Math.Round(factLinea.Cantidad, 2),  Math.Round(factLinea.Precio_Unitario, 4), 
                        Math.Round(factLinea.Precio_Unitario* factLinea.Cantidad, 4), 0.00);
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

        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.btnRestaurar.Visible = false;
            this.btnMaximizar.Visible = true;
        }

        private void btnMminizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.btnMaximizar.Visible = false;
            this.btnRestaurar.Visible = true;
        }

        private void btnDevolverTodo_Click(object sender, EventArgs e)
        {
            for (var rows=0; rows < dgvDetalleFacturaOriginal.RowCount; rows++)
            {
                decimal precioUnitario = Convert.ToDecimal(this.dgvDetalleFacturaOriginal.Rows[rows].Cells["PrecioUnitario"].Value);
                decimal cantidad = Convert.ToDecimal(this.dgvDetalleFacturaOriginal.Rows[rows].Cells["Cantidad"].Value);
                this.dgvDetalleFacturaOriginal.Rows[rows].Cells["CantidadDevolver"].Value = this.dgvDetalleFacturaOriginal.Rows[rows].Cells["Cantidad"].Value;
                this.dgvDetalleFacturaOriginal.Rows[rows].Cells["SubTotalDevolver"].Value = precioUnitario * cantidad;
            }
        }

        private async void btnAceptar_Click(object sender, EventArgs e)
        {
            bool verificacionExitosa = AsignarRegistroDevolucion();
                     

            if (verificacionExitosa)
            {
                ResponseModel responseModel = new ResponseModel();
                responseModel = await _serviceDevolucion.GuardarDevolucion(_devolucion, responseModel);
                if (responseModel.Exito ==1)
                {

                }
                else
                {
                    MessageBox.Show(responseModel.Mensaje);
                }
            }
            else
            {
                MessageBox.Show("La factura ha aun no has indicado los articulo a devolver", "Sistema COVENTAF", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private bool AsignarRegistroDevolucion()
        {
            bool verificacionExitosa = false;

            _devolucion.Factura.Caja = User.Caja;
            _devolucion.Factura.Usuario = User.Usuario;
            _devolucion.Factura.Num_Cierre = User.ConsecCierreCT;

            decimal TotalUnidDevuelta = 0.00M;

            for (var rows = 0; rows < dgvDetalleFacturaOriginal.RowCount; rows++)
            {
                string articuloId = this.dgvDetalleFacturaOriginal.Rows[rows].Cells["ArticuloId"].Value.ToString();
                decimal precioUnitario = Convert.ToDecimal(this.dgvDetalleFacturaOriginal.Rows[rows].Cells["PrecioUnitario"].Value);
                decimal cantidadDevolver = Convert.ToDecimal(this.dgvDetalleFacturaOriginal.Rows[rows].Cells["CantidadDevolver"].Value);
                decimal subtotal = Convert.ToDecimal(this.dgvDetalleFacturaOriginal.Rows[rows].Cells["SubTotalDevolver"].Value);

                TotalUnidDevuelta += cantidadDevolver;

                //comprobar si cantidadDevolver es mayor que cero
                if (cantidadDevolver > 0)
                {
                    verificacionExitosa = true;
                    for (var fila = 0; fila < _devolucion.FacturaLinea.Count; rows++)
                    {
                        if (_devolucion.FacturaLinea[fila].Articulo == articuloId)
                        {
                            _devolucion.FacturaLinea[fila].Cantidad_Devuelt = cantidadDevolver;
                            _devolucion.FacturaLinea[fila].Documento_Origen = factura;
                            _devolucion.FacturaLinea[fila].SubTotal = subtotal;
                            _devolucion.FacturaLinea[fila].Caja = User.Caja;
                        }
                    }
                }
            }

            return verificacionExitosa;

        }
    }
}
