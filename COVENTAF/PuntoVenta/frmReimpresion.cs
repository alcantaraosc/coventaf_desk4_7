using Api.Model.Modelos;
using Api.Model.View;
using Api.Model.ViewModels;
using Api.Service.DataService;
using COVENTAF.Metodos;
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
    public partial class frmReimpresion : Form
    {
        private ServiceFactura _serviceFactura = new ServiceFactura();
        public bool _supervisor;

        #region codigo para mover pantalla
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        #endregion
        public frmReimpresion()
        {
            InitializeComponent();
        }

        private void barraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
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

        private void ObtenerTipoFiltro(FiltroFactura filtroFactura)
        {
            filtroFactura.FechaInicio = Convert.ToDateTime(this.dtFechaDesde.Value.Date);
            filtroFactura.FechaFinal = Convert.ToDateTime(this.dtFechaHasta.Value.Date);
            filtroFactura.Caja = this.txtCaja.Text.Length == 0 ? "" : this.txtCaja.Text;
            //filtroFactura.Cajero = this.txtCaja.Text.Length == 0 ? "" : this.txtCaja.Text;
            filtroFactura.FacturaDesde = this.txtFacturaDesde.Text.Length == 0 ? "" : this.txtFacturaDesde.Text;
            filtroFactura.FacturaHasta = this.txtFacturaHasta.Text.Length == 0 ? "" : this.txtFacturaHasta.Text;

            var tipoFiltro = "Fecha";
            if (filtroFactura.Caja.Length > 0)
            {
                tipoFiltro += "_Caja";
            }

            if (filtroFactura.FacturaDesde.Length > 0 && filtroFactura.FacturaHasta.Length > 0)
            {
                tipoFiltro += "_Factura";
            }

            filtroFactura.Tipofiltro = tipoFiltro;
            filtroFactura.TipoDocumento = this.cboTipoFiltro.Text == "Factura" ? "F" : "D";

                               
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            switch (this.cboTipoFiltro.Text)
            {
                case "Factura": 
                    BuscarFacturaDevolucion();
                    break;

                case "Devolucion":
                    BuscarFacturaDevolucion();
                    break;


                case "Cierre Cajero":
                    BuscarCierreCajero();                    
                    break;

                case "Cierre Caja":
                    BuscarCierreCaja();
                    break;

            }           
        }

       private async void BuscarFacturaDevolucion()
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
                    ObtenerTipoFiltro(filtroFactura);

                    if (filtroFactura.Tipofiltro.Length == 0) return;
                    responseModel = await _serviceFactura.BuscarFactura(filtroFactura, _supervisor, responseModel);

                    if (responseModel.Exito == 1)
                    {
                        var listaFactura = responseModel.Data as List<ViewFactura>;
                        this.dgvConsultaFacturas.Rows.Clear();

                        foreach (var item in listaFactura)
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

       private async void BuscarCierreCajero()
        {
            if (this.txtCaja.Text.Trim().Length == 0)
            {
                MessageBox.Show("Debes de digitar el usuario del cajero", "Sistema COVENTAF");
                this.txtCaja.Focus();
                return;
            }
            else
            {

                //this.btnAnularFactura.Enabled = false;
                var filtroFactura = new FiltroFactura();
                ResponseModel responseModel = new ResponseModel();
                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    this.dgvConsultaFacturas.Cursor = Cursors.WaitCursor;

                    filtroFactura.Cajero = this.txtCaja.Text.Length == 0 ? "" : this.txtCaja.Text;
                    filtroFactura.Tipofiltro = this.cboTipoFiltro.Text;

                    responseModel = await _serviceFactura.BuscarCierreCajero(filtroFactura, responseModel);

                    if (responseModel.Exito == 1)
                    {
                        var listCierreCajero = responseModel.Data as List<Cierre_Pos>;
                        this.dgvConsultaFacturas.Rows.Clear();

                        foreach (var item in listCierreCajero)
                        {
                            this.dgvConsultaFacturas.Rows.Add(item.Num_Cierre, item.Caja, item.Cajero,item.Fecha_Hora, item.Estado, "");
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
      

        private async void BuscarCierreCaja()
        {
            if (this.txtCaja.Text.Trim().Length == 0)
            {
                MessageBox.Show("Debes de digitar el usuario del cajero", "Sistema COVENTAF");
                this.txtCaja.Focus();
                return;
            }
            else
            {
                //this.btnAnularFactura.Enabled = false;
                var filtroFactura = new FiltroFactura();
                ResponseModel responseModel = new ResponseModel();
                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    this.dgvConsultaFacturas.Cursor = Cursors.WaitCursor;

                    filtroFactura.Cajero = this.txtCaja.Text.Length == 0 ? "" : this.txtCaja.Text;
                    filtroFactura.Tipofiltro = this.cboTipoFiltro.Text;

                    responseModel = await _serviceFactura.BuscarCierreCaja(filtroFactura, responseModel);

                    if (responseModel.Exito == 1)
                    {
                        var listCierreCaja = responseModel.Data as List<Cierre_Caja>;
                        this.dgvConsultaFacturas.Rows.Clear();

                        foreach (var item in listCierreCaja)
                        {                            
                            this.dgvConsultaFacturas.Rows.Add(item.Num_Cierre, item.Caja, item.Cajero_Cierre, item.Fecha_Cierre, item.Estado, item.Num_Cierre_Caja);
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
                if (!UtilidadesMain.AutorizacionExitosa()) return;

                if (this.cboTipoFiltro.Text =="Factura" || this.cboTipoFiltro.Text == "Devolucion")
                {
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
                else if (this.cboTipoFiltro.Text =="Cierre Cajero")
                {
                    string caja = dgvConsultaFacturas.Rows[rowGrid].Cells["Caja"].Value.ToString();
                    string numCierre = dgvConsultaFacturas.Rows[rowGrid].Cells["NumeroCierre"].Value.ToString();

                    ReimprimirCierreCajero( caja, User.Usuario, numCierre);

                }
                else if (this.cboTipoFiltro.Text == "Cierre Caja")
                {
                    string caja = dgvConsultaFacturas.Rows[rowGrid].Cells["Caja"].Value.ToString();
                    string numCierre = dgvConsultaFacturas.Rows[rowGrid].Cells["NumeroCierre"].Value.ToString();

                    ReimprimirCierreCaja(caja, User.Usuario, numCierre);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Sistema COVENTAF");
            }
      

        }

        private async void ReimprimirCierreCajero(string caja, string cajero, string num_Cierre)
        {
            ServiceCaja_Pos _serviceCajaPos = new ServiceCaja_Pos();
            var responseModel = new ResponseModel();

            var viewModelCierre = new ViewModelCierre();
            viewModelCierre.Cierre_Det_Pago = new List<Cierre_Det_Pago>();
            viewModelCierre.Cierre_Pos = new Cierre_Pos();
            viewModelCierre.Cierre_Desg_Tarj = new List<Cierre_Desg_Tarj>();

            responseModel = await _serviceCajaPos.ObtenerRegistro_ReporteCierre(caja, cajero, num_Cierre, responseModel);
            if (responseModel.Exito == 1)
            {
                viewModelCierre = responseModel.Data as ViewModelCierre;

                new Metodos.MetodoImprimir().ImprimirReporteCierreCajero(viewModelCierre);
                           
            }
            else
            {
                MessageBox.Show(responseModel.Mensaje, "Sistema COVENTAF");
            }
        }

        private async void ReimprimirCierreCaja(string caja, string cajero, string num_Cierre)
        {
            ServiceCaja_Pos _serviceCajaPos = new ServiceCaja_Pos();
            var responseModel = new ResponseModel();

            var viewModelCierre = new ViewModelCierre();
            viewModelCierre.Cierre_Det_Pago = new List<Cierre_Det_Pago>();
            viewModelCierre.Cierre_Pos = new Cierre_Pos();
            viewModelCierre.Cierre_Desg_Tarj = new List<Cierre_Desg_Tarj>();

            responseModel = await _serviceCajaPos.ObtenerRegistro_ReporteCierre(caja, cajero, num_Cierre, responseModel);
            if (responseModel.Exito == 1)
            {
                viewModelCierre = responseModel.Data as ViewModelCierre;             

                if (viewModelCierre.DetalleFacturaCierreCaja.Count > 0)
                {
                    new Metodos.MetodoImprimir().ImprimirReporteCierreCaja(viewModelCierre);
                }
                else
                {
                    MessageBox.Show("No hay factura para el cierre de caja", "Sistema COVENTAF");
                }

            }
            else
            {
                MessageBox.Show(responseModel.Mensaje, "Sistema COVENTAF");
            }
        }

        private async void ReimprimirFactura(string factura)
        {
            var _serviceFactura = new ServiceFactura();

            ResponseModel responseModel = new ResponseModel();
            ViewModelFacturacion viewModelFactura;
          
            responseModel = await _serviceFactura.BuscarNoFactura(factura, responseModel);
            //si la respuesta del servidor es diferente de 1
            if (responseModel.Exito == 1)
            {
                viewModelFactura = responseModel.Data as ViewModelFacturacion;

                new Metodos.MetodoImprimir().ImprimirTicketFactura(viewModelFactura, true);
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
                case "Factura o Devolucion":
                    this.grpTituloBuscar.Text = "Buscar por Caja";
                    this.lblTituloCaja.Text = "Caja:";
                    this.grpBuscarFactura.Enabled = true;
                    this.grpDate.Enabled = true;
                    this.txtCaja.Text = "";
                    AgregarColumnasFactura();
                    break;

            
                case "Cierre Cajero":
                    AgregarColumnasCierre();
                    this.grpTituloBuscar.Text = "Buscar por Cajero";
                    this.lblTituloCaja.Text = "Cajero:";
                    this.grpBuscarFactura.Enabled = false;
                    this.grpDate.Enabled = false;
                    this.txtFacturaDesde.Text = "";
                    this.txtFacturaHasta.Text = "";
                    this.txtCaja.Text = User.Usuario;
                    this.txtCaja.Focus();               
                    break;

                case "Cierre Caja":
                    AgregarColumnasCierre();
                    this.grpTituloBuscar.Text = "Buscar por Cajero";
                    this.lblTituloCaja.Text = "Cajero:";
                    this.grpBuscarFactura.Enabled = false;
                    this.grpDate.Enabled = false;
                    
                    this.txtFacturaDesde.Text = "";
                    this.txtFacturaHasta.Text = "";
                    this.txtCaja.Text = User.Usuario;
                    this.txtCaja.Focus();
                    break;

            }
        }

        private void frmReimpresion_Load(object sender, EventArgs e)
        {
            this.cboTipoFiltro.SelectedIndex = 0;
        }

        private void AgregarColumnasFactura()
        {

            dgvConsultaFacturas.Columns.Clear();

            DataGridViewTextBoxColumn NoFactura = new DataGridViewTextBoxColumn();
            NoFactura.HeaderText = "NoFactura";
            NoFactura.Name = "NoFactura";
            NoFactura.Width = 200;

            DataGridViewTextBoxColumn TipoDoc = new DataGridViewTextBoxColumn();
            TipoDoc.HeaderText = "TipoDoc";
            TipoDoc.Name = "TipoDoc";
            TipoDoc.Width = 200;

            DataGridViewTextBoxColumn Fecha = new DataGridViewTextBoxColumn();
            Fecha.HeaderText = "Fecha";
            Fecha.Name = "Fecha";
            Fecha.Width = 200;


            DataGridViewTextBoxColumn Caja = new DataGridViewTextBoxColumn();
            Caja.HeaderText = "Caja";
            Caja.Name = "Caja";
            Caja.Width = 200;

            DataGridViewTextBoxColumn Cajero = new DataGridViewTextBoxColumn();
            Cajero.HeaderText = "Cajero";
            Cajero.Name = "Cajero";
            Cajero.Width = 200;


            DataGridViewTextBoxColumn Cliente = new DataGridViewTextBoxColumn();
            Cliente.HeaderText = "Cliente";
            Cliente.Name = "Cliente";
            Cliente.Width = 200;

            DataGridViewTextBoxColumn NombreCliente = new DataGridViewTextBoxColumn();
            NombreCliente.HeaderText = "Nombre Cliente";
            NombreCliente.Name = "NombreCliente";
            NombreCliente.Width = 200;


            DataGridViewTextBoxColumn TotalFactura = new DataGridViewTextBoxColumn();
            TotalFactura.HeaderText = "Total Factura";
            TotalFactura.Name = "TotalFactura";
            TotalFactura.Width = 200;


            DataGridViewTextBoxColumn NumCierre = new DataGridViewTextBoxColumn();
            NumCierre.HeaderText = "Num Cierre";
            NumCierre.Name = "NumCierre";
            NumCierre.Width = 200;

            dgvConsultaFacturas.Columns.AddRange(new[] { NoFactura, TipoDoc, Fecha, Caja, Cajero, Cliente, NombreCliente, TotalFactura, NumCierre });


        }

        private void AgregarColumnasCierre()
        {
            //NUM_CIERRE_CAJA, CAJERO_CIERRE, CAJA, FECHA_CIERRE, ESTADO
            dgvConsultaFacturas.Columns.Clear();

            DataGridViewTextBoxColumn NumeroCierre = new DataGridViewTextBoxColumn();
            NumeroCierre.HeaderText = "Numero Cierre";
            NumeroCierre.Name = "NumeroCierre";
            NumeroCierre.Width = 200;

            DataGridViewTextBoxColumn Caja = new DataGridViewTextBoxColumn();
            Caja.HeaderText = "Caja";
            Caja.Name = "Caja";
            Caja.Width = 200;

            DataGridViewTextBoxColumn Cajero = new DataGridViewTextBoxColumn();
            Cajero.HeaderText = "Cajero";
            Cajero.Name = "Cajero";
            Cajero.Width = 200;


            DataGridViewTextBoxColumn FechaCierre = new DataGridViewTextBoxColumn();
            FechaCierre.HeaderText = "Fecha Cierre";
            FechaCierre.Name = "FechaCierre";
            FechaCierre.Width = 200;

            DataGridViewTextBoxColumn Estado = new DataGridViewTextBoxColumn();
            Estado.HeaderText = "Estado";
            Estado.Name = "Estado";
            Estado.Width = 200;

            DataGridViewTextBoxColumn NumCierreCaja = new DataGridViewTextBoxColumn();
            NumCierreCaja.HeaderText = "Num Cierre Caja";
            NumCierreCaja.Name = "NumCierreCaja";
            NumCierreCaja.Width = 200;

            dgvConsultaFacturas.Columns.AddRange(new [] { NumeroCierre, Caja, Cajero,  FechaCierre, Estado, NumCierreCaja });
           
        }



        private void cboTipoFiltro_Click(object sender, EventArgs e)
        {

        }

     
    }
}
