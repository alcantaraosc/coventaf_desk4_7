using Api.Model.Modelos;
using Api.Model.ViewModels;
using Api.Service.DataService;
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
    public partial class frmActualizarFactura : Form
    {
        public frmActualizarFactura()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void btnBuscar_Click(object sender, EventArgs e)
        {
            if (this.txtNoFactura.Text.Trim().Length==0)
            {
                MessageBox.Show("Debes de digitar el numero de factura", "Sistema COVENTAF");
                return;
            }

            this.Cursor = Cursors.WaitCursor;
            this.dgv1.Cursor = Cursors.WaitCursor;
            this.dgv2.Cursor = Cursors.WaitCursor;

            ResponseModel responseModel = new ResponseModel();
            var viewModel = new ViewModelFactura_Documento();
            viewModel.Documento_Pos = new Documento_Pos();
            viewModel.Doc_Pos_Linea = new List<Doc_Pos_Linea>();
            viewModel.Facturas = new Facturas();
            viewModel.Factura_Linea = new List<Factura_Linea>();


            try
            {
                this.dgv1.Rows.Clear();
                this.dgv2.Rows.Clear();
                              
                responseModel = await new ServiceFactura().BuscarFacturaSoftlandYCoventaf(txtNoFactura.Text.Trim(), responseModel);
                               
                var vieModel = new ViewModelFactura_Documento();
                vieModel = responseModel.Data as ViewModelFactura_Documento;

                this.lblFactura1.Text = $"Factura: {vieModel.Documento_Pos.Documento}";
                this.lblTipo1.Text = $"Tipo: {vieModel.Documento_Pos.Tipo}";
                this.lblCaja1.Text = $"Caja: {vieModel.Documento_Pos.Caja}";
                this.lblCajero1.Text = $"Cajero: {vieModel.Documento_Pos.Cajero}";
                this.lblNumeroCierre1.Text = $"Numero Cierre: {vieModel.Documento_Pos.Num_Cierre}";
                this.lblTienda1.Text = $"Tienda: {vieModel.Documento_Pos.Tienda_Enviado}";
                this.lblFecha1.Text = $"Fecha y hora: {vieModel.Documento_Pos.Fch_Hora_Creacion.ToString("dd/MM/yyyy HH:MM:ss")}";
                this.lblTotalFactura1.Text = $"Total Factura : C${vieModel.Documento_Pos.Total_Pagar.ToString("N2")}";
                this.lblCliente1.Text = $"Cliente: {vieModel.Documento_Pos.Cliente}";
                this.lblNombreCliente1.Text = $"Nombre Cliente: {vieModel.Documento_Pos.Nombre_Cliente}";
               
                foreach(var item in vieModel.Doc_Pos_Linea)
                {
                    this.dgv1.Rows.Add(item.Documento.ToString(), item.Caja.ToString(), item.Linea.ToString(), item.Articulo.ToString(), item.Descripcion.ToString(), 
                        item.Cantidad.ToString("N2"),item.Precio_Venta.ToString("N2"), item.Descuento_Linea.ToString("N2"), item.Bodega.ToString());
                }

              
                this.lblFactura2.Text = $"Factura: {vieModel.Facturas.Factura}";
                this.lblTipo2.Text = $"Tipo: {vieModel.Facturas.Tipo_Documento}";
                this.lblCaja2.Text = $"Caja: {vieModel.Facturas.Caja}";
                this.lblCajero2.Text = $"Cajero: {vieModel.Facturas.Usuario}";
                this.lblNumeroCierre2.Text = $"Numero Cierre: {vieModel.Facturas.Num_Cierre}";
                this.lblTienda2.Text = $"Tienda: {vieModel.Facturas.Tienda_Enviado}";
                this.lblFechaHora2.Text = $"Fecha y hora: {vieModel.Facturas.Fecha.ToString("dd/MM/yyyy HH:MM:ss")}";
                this.lblTotalFactura2.Text = $"Total Factura : C${vieModel.Facturas.Total_Factura.ToString("N2")}";
                this.lblCliente2.Text = $"Cliente: {vieModel.Facturas.Cliente}";
                this.lblNombreCliente2.Text = $"Nombre Cliente: {vieModel.Facturas.Nombre_Cliente}";

                foreach (var item in vieModel.Factura_Linea)
                {
                    this.dgv2.Rows.Add(item.Factura.ToString(), item.Caja, item.Linea, item.Articulo, item.Descripcion,
                        item.Cantidad.ToString("N2"), item.Precio_Unitario.ToString("N2"), item.Desc_Tot_Linea.ToString("N2"), item.Porc_Desc_Linea, item.Bodega.ToString());
                }

            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show(ex.Message);
            }
            finally
            {

                this.Cursor = Cursors.Default;
                this.dgv1.Cursor = Cursors.Default;
                this.dgv2.Cursor = Cursors.Default;
            }
        }
    }
}
