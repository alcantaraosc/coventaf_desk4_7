using Api.Model.Modelos;
using Api.Model.View;
using Api.Model.ViewModels;
using Api.Service.DataService;
using COVENTAF.Services;
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

        public string factura = "0369655";
        public string numeroCierre = "CT1000000006373";
        //MONTO DEL DESCUENTO GENERAL DE LA FACTURA
        private decimal montDescuento = 0.00M;
        private decimal porCentajeDescGeneral = 0.00M;
        private decimal totalMercaderia = 0.00M;               
        private decimal totalUnidades = 0.000M;
        private decimal totalFacturaDevuelta = 0.0000M;
        private string documento_Origen;
        private string tipo_Origen;



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
                //obtiene el descuento 
                porCentajeDescGeneral = _devolucion.Factura.Porc_Descuento1;
                documento_Origen = _devolucion.Factura.Factura;
                tipo_Origen = _devolucion.Factura.Tipo_Documento;

                this.lblCaja.Text = _devolucion.Factura.Factura;
                //porCentajeDescuento = _devolucion.Factura.Porc_Descuento1;
                //totalMercaderia




                foreach (var factLinea in _devolucion.FacturaLinea)
                {
                    this.dgvDetalleFacturaOriginal.Rows.Add(factLinea.Articulo, factLinea.Descripcion, Math.Round(factLinea.Cantidad, 2), Math.Round(factLinea.Precio_Unitario, 4),
                        Math.Round(factLinea.Precio_Total, 4) /*SubTotal = Precio_Total*/,
                        0 /*CantidadDevolver*/,
                        factLinea.Costo_Total_Dolar, //Costo_Total_Dolar_Dev
                        factLinea.Costo_Total, //Costo_Total_Dev
                        factLinea.Costo_Total_Local, //Costo_Total_Local_Dev
                        factLinea.Costo_Total_Comp, //Costo_Total_Comp_Dev
                        factLinea.Costo_Total_Comp_Local, //Costo_Total_Comp_Local_Dev
                        factLinea.Costo_Total_Comp_Dolar, //Costo_Total_Comp_Dolar_Dev
                       factLinea.Desc_Tot_Linea, //DescTot_Linea
                       factLinea.Desc_Tot_General, //Desc_Tot_General_Dev
                        factLinea.Precio_Total);//Precio_Total_Dev
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
            decimal _precioUnitario = 0, _cantidad = 0, _cantidadDevolver =0, _descTotLineaDev = 0, _costTotalDolarDev = 0;
            decimal _costoTotalDev = 0, _costoTotalLocalDev = 0, _costoTotalCompDev=0, _costoTotalCompLocalDev = 0, _costoTotalCompDolarDev = 0;
            decimal _precioTotalDev = 0, _descTotGeneralDev = 0;


            //            private decimal montDescuento = 0.00M;
            //private decimal porCentajeDescuento = 0.00M;
            //private decimal totalMercaderia = 0.00M;
            //private decimal totaUnidades = 0.000M;
            totalUnidades = 0;







            // ArticuloId;
            //     Descripcion;
            //     Cantidad;
            //     PrecioUnitario;
            //     SubTotal = Precio_Total;
            //     CantidadDevolver;
            //     Costo_Total_Dolar_Dev;
            //     Costo_Total_Dev;
            //     Costo_Total_Local_Dev;
            //     Costo_Total_Comp_Dev;
            //     Costo_Total_Comp_Local_Dev;
            //     Costo_Total_Comp_Dolar_Dev;
            //     Desc_Tot_Linea;

            //     ;
            //     Precio_Total_Dev;

            for (var rows=0; rows < dgvDetalleFacturaOriginal.RowCount; rows++)
            {
                _precioUnitario = Convert.ToDecimal(this.dgvDetalleFacturaOriginal.Rows[rows].Cells["PrecioUnitario"].Value);
                _cantidad = Convert.ToDecimal(this.dgvDetalleFacturaOriginal.Rows[rows].Cells["Cantidad"].Value);
                this.dgvDetalleFacturaOriginal.Rows[rows].Cells["CantidadDevolver"].Value = _cantidad.ToString();
                //obtener la cantidad devuelta
                _cantidadDevolver = Convert.ToDecimal(this.dgvDetalleFacturaOriginal.Rows[rows].Cells["CantidadDevolver"].Value);
                //obtener el valor del descuento por linea del producto
                _descTotLineaDev = Convert.ToDecimal(this.dgvDetalleFacturaOriginal.Rows[rows].Cells["Desc_Tot_Linea_Dev"].Value);
                _costTotalDolarDev = Convert.ToDecimal(this.dgvDetalleFacturaOriginal.Rows[rows].Cells["Costo_Total_Dolar_Dev"].Value);
                _costoTotalDev = Convert.ToDecimal(this.dgvDetalleFacturaOriginal.Rows[rows].Cells["Costo_Total_Dev"].Value);
                _costoTotalLocalDev = Convert.ToDecimal(this.dgvDetalleFacturaOriginal.Rows[rows].Cells["Costo_Total_Local_Dev"].Value);
                _costoTotalCompDev = Convert.ToDecimal(this.dgvDetalleFacturaOriginal.Rows[rows].Cells["Costo_Total_Comp_Dev"].Value);
                _costoTotalCompLocalDev = Convert.ToDecimal(this.dgvDetalleFacturaOriginal.Rows[rows].Cells["Costo_Total_Comp_Local_Dev"].Value);
                _costoTotalCompDolarDev = Convert.ToDecimal(this.dgvDetalleFacturaOriginal.Rows[rows].Cells["Costo_Total_Comp_Dolar_Dev"].Value);
                _precioTotalDev = Convert.ToDecimal(this.dgvDetalleFacturaOriginal.Rows[rows].Cells["Precio_Total_Dev"].Value);
            
                this.dgvDetalleFacturaOriginal.Rows[rows].Cells["Costo_Total_Dolar_Dev"].Value = ((_costTotalDolarDev / _cantidad) * _cantidadDevolver).ToString("N2");
                this.dgvDetalleFacturaOriginal.Rows[rows].Cells["Costo_Total_Dev"].Value = ((_costoTotalDev / _cantidad) * _cantidadDevolver).ToString("N4");
                this.dgvDetalleFacturaOriginal.Rows[rows].Cells["Costo_Total_Local_Dev"].Value = ((_costoTotalLocalDev / _cantidad) * _cantidadDevolver).ToString("N4");
                this.dgvDetalleFacturaOriginal.Rows[rows].Cells["Costo_Total_Comp_Dev"].Value = ((_costoTotalCompDev / _cantidad) * _cantidadDevolver).ToString("N4");
                this.dgvDetalleFacturaOriginal.Rows[rows].Cells["Costo_Total_Comp_Local_Dev"].Value = ((_costoTotalCompLocalDev / _cantidad) * _cantidadDevolver).ToString("N4");
                this.dgvDetalleFacturaOriginal.Rows[rows].Cells["Costo_Total_Comp_Dolar_Dev"].Value = ((_costoTotalCompDolarDev / _cantidad) * _cantidadDevolver).ToString("N2");

                _descTotLineaDev = ((_descTotLineaDev / _cantidad) * _cantidadDevolver);
                _precioTotalDev = (_precioUnitario * _cantidadDevolver) - _descTotLineaDev;
                this.dgvDetalleFacturaOriginal.Rows[rows].Cells["Desc_Tot_Linea_Dev"].Value = _descTotLineaDev.ToString("N4");

                this.dgvDetalleFacturaOriginal.Rows[rows].Cells["Desc_Tot_General_Dev"].Value = (_precioTotalDev * ( porCentajeDescGeneral /100)).ToString("N4");
                this.dgvDetalleFacturaOriginal.Rows[rows].Cells["Precio_Total_Dev"].Value = _precioTotalDev.ToString("N4");

                //if (CantidadDevolver >0)
                //{
                //    _precioTotalDev= _precioTotalDev
                //}


                //sumar el total de las unidades
                totalUnidades += _cantidad;

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

        private void calculoMatematico()
        {
            /*************** tabla FACTURA*******************************************
             MONTO_DESCUENTO1= MONTO DEL DESCUENTO GENERAL DE LA FACTURA
             PORC_DESCUENTO1 = % DESCUENTO GENERAL DE LA FACTURA
             // total de cordobas = es el total de la factura + el monto del descuento General
             TOTAL_MERCADERIA = listVarFactura.TotalCordobas + listVarFactura.DescuentoGeneralCordoba   
            tota_unidades = total de unidades a devolver
             
             */




            /****************************tabla FACTURA LINEA  *********************************
             
            DESC_TOT_LINEA = (DESC_TOT_LINEA /cantidadVendida)* CantidadDevuelta
            COSTO_TOTAL_DOLAR= ((COSTO_TOTAL_DOLAR / FACT_LIN.CANTIDAD) * DEV.CantidadDevolver), 
            COSTO_TOTAL=((COSTO_TOTAL/CANTIDAD) * CantidadDevolver),
            COSTO_TOTAL_LOCAL=((COSTO_TOTAL_LOCAL / CANTIDAD) * CantidadDevolver)
            COSTO_TOTAL_COMP=((COSTO_TOTAL_COMP/CANTIDAD)* CantidadDevolver),
            COSTO_TOTAL_COMP_LOCAL=((COSTO_TOTAL_COMP_LOCAL/CANTIDAD)*CantidadDevolver),
            COSTO_TOTAL_COMP_DOLAR=((COSTO_TOTAL_COMP_DOLAR/CANTIDAD)* CantidadDevolver)
            //aqui ya tiene restado el descuento por linea. precio_total_x_linea. ya lo verifique con softland
            Precio_Total = (CantidadDevolver * PRECIO_VENTA)-DESC_TOT_LINEA
            DOCUMENTO_ORIGEN=NoFactura
            TIPO_ORIGEN= TipoDocumento
            //descuento general. el % se encuentra en la tabla Factura en el campo Porc_Descuento1 (Porc_Descuento1=% DEL DESCUENTO DE LOS MILITARES)
            DESC_TOT_GENERAL = Precio_Total *  Porc_Descuento1; (

                                                     
            */

        }

        private void dgvDetalleFacturaOriginal_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
          // dgvDetalleFacturaOriginal.Rows[0]
            //si la columna es cantidad (5) 
            if (e.ColumnIndex == 5)
            {
                string mensaje = "";
                bool CantidadConDecimal = false;
                string cantidadDevolver = dgvDetalleFacturaOriginal.Rows[e.RowIndex].Cells["CantidadDevuelta"].Value.ToString();
                //obtener la existencia del DataGridView
                decimal existencia = Convert.ToDecimal(dgvDetalleFacturaOriginal.Rows[e.RowIndex].Cells["Cantidad"].Value);
                //verificar si la unidad de medida del articulo permite punto decimal (ej.: 3.5)
               // bool CantidadConDecimal = (dgvDetalleFactura.Rows[consecutivoActualFactura].Cells["UnidadFraccion"].Value.ToString() == "S" ? true : false);
                if (! new  ProcesoFacturacion().CantidadIsValido(dgvDetalleFacturaOriginal.Rows[e.RowIndex].Cells["Cantidad"].Value.ToString(), CantidadConDecimal, ref mensaje))
                {
                    MessageBox.Show(mensaje, "Sistema COVENTAF", MessageBoxButtons.OK);
                    //asignarle la cantidad que tenia antes de editarla
                    dgvDetalleFacturaOriginal.Rows[e.RowIndex].Cells["CantidadDevuelta"].Value = "0";
                }
                else if (Convert.ToDecimal(CantidadConDecimal) > existencia)
                {
                    MessageBox.Show("La cantidad a devolver excede a la cantidad del articulo de la factura", "Sistema COVENTAF", MessageBoxButtons.OK);
                    //asignarle la cantidad que tenia antes de editarla
                    dgvDetalleFacturaOriginal.Rows[e.RowIndex].Cells["CantidadDevuelta"].Value = "0";
                }
                else if (Convert.ToDecimal(cantidadDevolver) < 0)
                {
                    MessageBox.Show("La cantidad del articulo Devolver no puede ser negativo", "Sistema COVENTAF", MessageBoxButtons.OK);
                    //asignarle la cantidad que tenia antes de editarla
                    dgvDetalleFacturaOriginal.Rows[e.RowIndex].Cells["CantidadDevuelta"].Value = "0";
                }
               
                //else
                //{
                //    //de lo contrario actualizar la cantidad de tipo decimal
                //    dgvDetalleFacturaOriginal.Rows[e.RowIndex].Cells["CantidadDevuelta"].Value = Convert.ToDecimal(dgvDetalleFactura.Rows[consecutivoActualFactura].Cells[3].Value);
                    
                //}
               

                //validarCantidadGrid();
                ////calcular totales
                //onCalcularTotales();
            }
        }


        private void dgvDetalleFactura_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

            
        }
    }
}
