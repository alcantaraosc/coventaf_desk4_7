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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COVENTAF.PuntoVenta
{
    public partial class frmReimpresion : Form
    {
        private ServiceFactura _serviceFactura = new ServiceFactura();

        public frmReimpresion()
        {
            InitializeComponent();
        }


        private bool FiltrosValido()
        {
            bool valido = false;

            if (dtFechaDesde.Value.Date > dtFechaHasta.Value.Date)
            {
                MessageBox.Show("La Fecha desde tiene que ser menor que la fecha hasta", "Sistema COVENTAF");
            }
            else
            {
                valido = true;
            }

            return valido;
        }

        private string ObtenerTipoFiltro(FiltroFactura filtroFactura)
        {
            var tipoFiltro = "Fecha";
            if (filtroFactura.Caja.Length > 0)
            {
                tipoFiltro += "_Caja";
            }

            if (filtroFactura.FacturaDesde.Length > 0 && filtroFactura.FacturaHasta.Length > 0)
            {
                tipoFiltro += "_Factura";
            }
            return tipoFiltro;
        }

        private async void BtnAceptar_Click(object sender, EventArgs e)
        {
            if (FiltrosValido())
            {
                //this.btnAnularFactura.Enabled = false;
                var filtroFactura = new FiltroFactura();
                ResponseModel responseModel = new ResponseModel();
                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    this.dgvConsultaFacturas.Cursor = Cursors.WaitCursor;


                    filtroFactura.FechaInicio = Convert.ToDateTime(this.dtFechaDesde.Value.Date);
                    filtroFactura.FechaFinal = Convert.ToDateTime(this.dtFechaHasta.Value.Date);
                    filtroFactura.Caja = this.txtCaja.Text.Length == 0 ? "" : this.txtCaja.Text;
                    filtroFactura.FacturaDesde = this.txtFacturaDesde.Text.Length == 0 ? "" : this.txtFacturaDesde.Text;
                    filtroFactura.FacturaHasta = this.txtFacturaHasta.Text.Length == 0 ? "" : this.txtFacturaHasta.Text;
                    filtroFactura.Tipofiltro = ObtenerTipoFiltro(filtroFactura);
                    responseModel = await _serviceFactura.BuscarFactura(filtroFactura, responseModel);


                    if (responseModel.Exito == 1)
                    {
                        var listaFactura = responseModel.Data as List<ViewFactura>;
                        this.dgvConsultaFacturas.Rows.Clear();

                        foreach(var item in listaFactura)
                        {
                            this.dgvConsultaFacturas.Rows.Add(item.Factura, item.Tipo_Documento, item.Fecha, item.Caja, item.Usuario, item.Cliente, item.Nombre_Cliente, item.Total_Factura.ToString("N2"), item.Num_Cierre);
                        }

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
                    this.dgvConsultaFacturas.Cursor = Cursors.Default;
                }
            }
        }

        private void btnCierre_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnReimprimir_Click(object sender, EventArgs e)
        {
            int rowGrid = dgvConsultaFacturas.CurrentRow.Index;

            try
            {
                if (!Utilidades.AutorizacionExitosa()) return;

                string factura = dgvConsultaFacturas.Rows[rowGrid].Cells["NoFactura"].Value.ToString();
                string tipoDoc = dgvConsultaFacturas.Rows[rowGrid].Cells["TipoDoc"].Value.ToString();

                switch (tipoDoc)
                {
                    case "F":
                        ReimprimirFactura(factura);
                        break;

                    case "D":
                        ReimprimirDevolucion(factura);
                        break;
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Sistema COVENTAF");
            }
      

        }


        private async void ReimprimirFactura(string factura)
        {
            var _serviceFactura = new ServiceFactura();

            ResponseModel responseModel = new ResponseModel();
            ViewModelFacturacion viewModelFactura;
            //modelDevolucion.Factura = new Facturas();
            //modelDevolucion.FacturaLinea = new List<Factura_Linea>();
            //modelDevolucion.NoDevolucion = _devolucion.NoDevolucion;


            responseModel = await _serviceFactura.BuscarNoFactura(factura, responseModel);
            //si la respuesta del servidor es diferente de 1
            if (responseModel.Exito == 1)
            {
                viewModelFactura = responseModel.Data as ViewModelFacturacion;

                new Metodos.MetodoImprimir().ImprimirTicketFacturaDuplicada(viewModelFactura);
            }
        }

        private async void ReimprimirDevolucion(string factura)
        {
            var _serviceDevolucion = new ServiceDevolucion();

            ResponseModel responseModel = new ResponseModel();
            ViewModelFacturacion modelDevolucion;
            //modelDevolucion.Factura = new Facturas();
            //modelDevolucion.FacturaLinea = new List<Factura_Linea>();
            //modelDevolucion.NoDevolucion = _devolucion.NoDevolucion;


            responseModel = await _serviceDevolucion.BuscarDevolucion(factura, responseModel);
            //si la respuesta del servidor es diferente de 1
            if (responseModel.Exito == 1)
            {
                modelDevolucion = responseModel.Data as ViewModelFacturacion;

                new Metodos.MetodoImprimir().ImprimirDevolucion(modelDevolucion, true);
            }
        }

        private void cboTipoFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (this.cboTipoFiltro.Text)
            {
                case "Factura":
                    this.grpTituloBuscar.Text = "Buscar por Caja";
                    this.lblTituloCaja.Text = "Caja:";
                    this.grpBuscarFactura.Enabled = true;
                    break;

                case "Devolucion":
                    this.grpTituloBuscar.Text = "Buscar por Caja";
                    this.lblTituloCaja.Text = "Caja:";
                    this.grpBuscarFactura.Enabled = true;
                    break;

                case "Cierre Cajero":
                    this.grpTituloBuscar.Text = "Buscar por Cajero";
                    this.lblTituloCaja.Text = "Cajero:";
                    this.grpBuscarFactura.Enabled = false;
                    break;

                case "Cierre Caja":
                    this.grpTituloBuscar.Text = "Buscar por Cajero";
                    this.lblTituloCaja.Text = "Cajero:";
                    this.grpBuscarFactura.Enabled = false;
                    break;

            }
        }

        private void frmReimpresion_Load(object sender, EventArgs e)
        {
            this.cboTipoFiltro.SelectedIndex = 0;
        }
    }
}
