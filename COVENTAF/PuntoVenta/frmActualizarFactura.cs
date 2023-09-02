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
        string factura = "";
        private ViewModelFactura_Documento viewModel;

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
            viewModel = new ViewModelFactura_Documento();
            viewModel.Documento_Pos = new Documento_Pos();
            viewModel.Doc_Pos_Linea = new List<Doc_Pos_Linea>();
            viewModel.Facturas = new Facturas();
            viewModel.Factura_Linea = new List<Factura_Linea>();


            try
            {
                this.dgv1.Rows.Clear();
                this.dgv2.Rows.Clear();
                              
                responseModel = await new ServiceFactura().BuscarFacturaSoftlandYCoventaf(txtNoFactura.Text.Trim(), responseModel);
              
                if (responseModel.Exito ==1)
                {
                    
                    viewModel = responseModel.Data as ViewModelFactura_Documento;

                    

                    if (!( viewModel.Documento_Pos is null))
                    {
                        this.lblFactura1.Text = $"Factura: {viewModel.Documento_Pos.Documento}";
                        this.lblTipo1.Text = $"Tipo: {viewModel.Documento_Pos.Tipo}";
                        this.lblCaja1.Text = $"Caja: {viewModel.Documento_Pos.Caja}";
                        this.lblCajero1.Text = $"Cajero: {viewModel.Documento_Pos.Cajero}";
                        this.lblNumeroCierre1.Text = $"Numero Cierre: {viewModel.Documento_Pos.Num_Cierre}";
                        this.lblTienda1.Text = $"Tienda: {viewModel.Documento_Pos.Tienda_Enviado}";
                        this.lblFecha1.Text = $"Fecha y hora: {viewModel.Documento_Pos.Fch_Hora_Creacion.ToString("dd/MM/yyyy HH:MM:ss")}";
                        this.lblTotalFactura1.Text = $"Total Factura : C${viewModel.Documento_Pos.Total_Pagar.ToString("N2")}";
                        this.lblCliente1.Text = $"Cliente: {viewModel.Documento_Pos.Cliente}";
                        this.lblNombreCliente1.Text = $"Nombre Cliente: {viewModel.Documento_Pos.Nombre_Cliente}";
                    }

          
                    if (viewModel.Doc_Pos_Linea.Count >0)
                    {
                        foreach (var item in viewModel.Doc_Pos_Linea)
                        {
                            this.dgv1.Rows.Add(item.Documento.ToString(), item.Caja.ToString(), item.Linea.ToString(), item.Articulo.ToString(), item.Descripcion.ToString(),
                                item.Cantidad.ToString("N2"), item.Precio_Venta.ToString("N2"), item.Descuento_Linea.ToString("N2"), item.Bodega.ToString());
                        }
                    }


                    if (!(viewModel.Facturas is null))
                    {
                        factura = viewModel.Facturas.Factura;

                        this.lblFactura2.Text = $"Factura: {viewModel.Facturas.Factura}";
                        this.lblTipo2.Text = $"Tipo: {viewModel.Facturas.Tipo_Documento}";

                        this.lblCaja2.Text = $"Caja: {viewModel.Facturas.Caja}";
                        this.lblCajero2.Text = $"Cajero: {viewModel.Facturas.Usuario}";
                        this.lblNumeroCierre2.Text = $"Numero Cierre: {viewModel.Facturas.Num_Cierre}";
                        this.lblTienda2.Text = $"Tienda: {viewModel.Facturas.Tienda_Enviado}";
                        this.lblFechaHora2.Text = $"Fecha y hora: {viewModel.Facturas.Fecha.ToString("dd/MM/yyyy HH:MM:ss")}";
                        this.lblTotalFactura2.Text = $"Total Factura : C${viewModel.Facturas.Total_Factura.ToString("N2")}";
                        this.lblCliente2.Text = $"Cliente: {viewModel.Facturas.Cliente}";
                        this.lblNombreCliente2.Text = $"Nombre Cliente: {viewModel.Facturas.Nombre_Cliente}";
                    }

                    if (viewModel.Factura_Linea.Count > 0)
                    {
                        foreach (var item in viewModel.Factura_Linea)
                        {
                            this.dgv2.Rows.Add(item.Factura.ToString(), item.Caja, item.Linea, item.Articulo, item.Descripcion,
                                item.Cantidad.ToString("N2"), item.Precio_Unitario.ToString("N2"), item.Desc_Tot_Linea.ToString("N2"), item.Porc_Desc_Linea, item.Bodega.ToString());
                        }
                    }

                    if (viewModel.Documento_Pos is null && viewModel.Doc_Pos_Linea.Count ==0)
                    {
                        this.btnActualizar.Enabled = false;
                    }
                    else if (! (viewModel.Documento_Pos is null) && viewModel.Doc_Pos_Linea.Count > 0 && ! (viewModel.Facturas is null) && viewModel.Factura_Linea.Count > 0)
                    {
                        this.btnActualizar.Enabled = true;
                    }
                    else
                    {
                        this.btnActualizar.Enabled = false;
                    }
                }              
                else
                {
                    MessageBox.Show(responseModel.Mensaje, "Sistema COVENTAF");
                }
            }
            catch (Exception ex)
            {               
                MessageBox.Show(ex.Message);
            }
            finally
            {
                this.Cursor = Cursors.Default;
                this.dgv1.Cursor = Cursors.Default;
                this.dgv2.Cursor = Cursors.Default;
            }
        }

        private bool ValidacionCorrecta()
        {
            bool resultValido = false;
            try
            {
                if (!(viewModel.Documento_Pos.Tienda_Enviado == User.TiendaID))
                {
                    MessageBox.Show($"Esta factura no es de tu tienda ", "Sistema COVENTAF");
                }
                else if (viewModel.Documento_Pos.Documento == viewModel.Facturas.Factura && viewModel.Documento_Pos.Cliente == viewModel.Facturas.Cliente && viewModel.Documento_Pos.Total_Pagar == viewModel.Facturas.Total_Factura)
                {
                    resultValido = true;
                }
            }
            catch (Exception ex)
            {
                
            }

            return resultValido;
        }

        private async void btnActualizar_Click(object sender, EventArgs e)
        {
            if (ValidacionCorrecta())
            {
                if (MessageBox.Show($"¿ Estas seguro de actualizar la factura {factura} ?", "Sistema COVENTAF", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {

                    this.Cursor = Cursors.WaitCursor;
                    this.dgv1.Cursor = Cursors.WaitCursor;
                    this.dgv2.Cursor = Cursors.WaitCursor;

                    try
                    {
                      
                        var responseModel = new ResponseModel();
                        responseModel = await new ServiceFactura().ActualizarFacturaDeSoftlandaCoventaf(txtNoFactura.Text.Trim(), responseModel);

                        if (responseModel.Exito == 1)
                        {
                            MessageBox.Show(responseModel.Mensaje, "Sistema COVENTAF");
                        }
                        else
                        {
                            MessageBox.Show(responseModel.Mensaje, "Sistema COVENTAF");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Sistema COVENTAF");
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
    }
}
