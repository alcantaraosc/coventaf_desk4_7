
using Api.Model.Modelos;
using Api.Model.View;
using Api.Model.ViewModels;
using Api.Service.DataService;
using Controladores;
using COVENTAF.Metodos;
using COVENTAF.Services;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COVENTAF.PuntoVenta
{
    public partial class frmPuntoVenta : Form
    {       
        private bool _supervisor=false;

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();


        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private readonly FacturaController _facturaController;        

        //clase para enviar el filtro.
        FiltroFactura filtroFactura = new FiltroFactura();


        private readonly CajaPosController _cajaPosController;
        private ServiceCaja_Pos _serviceCaja_Pos = new ServiceCaja_Pos();
        private ServiceFactura _serviceFactura = new ServiceFactura();

        public int rowGrid = 0;

        public frmPuntoVenta()
        {
            InitializeComponent();
            this._facturaController = new FacturaController();
            this._cajaPosController = new CajaPosController();
            this.cboTipoFiltro.Items.Clear();
            this.cboTipoFiltro.Items.AddRange(new object[] { "No Factura", "Devolucion", "No Recibo" });
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {

        }

        /*  1- El cajero se logea y obtiene el informacion de la tienda que esta relacionado
         *  2-cuando el cajero haga apertura de caja entonces el sistema le asigna la bodega que tienen la caja.
         *  3-si el cajero ya hizo apertura de caja entonces el sistema obtiene la bodega
          */

        private async void frmPuntoVenta_Load(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            this.gridControl2.Cursor = Cursors.WaitCursor;

            /*roles dispionible solo si eres SUPERVISOR*/
            var rolesDisponibleSupervisor = new List<string>() { "ADMIN", "SUPERVISOR" };
            _supervisor = UtilidadesMain.AccesoPermitido(rolesDisponibleSupervisor);
            this.txtCaja.Enabled = _supervisor;
           // this.btnAnularFact.Enabled = _supervisor;
           // this.btnAnularFactura.Enabled = _supervisor;
            this.btnRecibo.Enabled = _supervisor;
            //this.btnDevoluciones.Enabled = _supervisor;
            this.btnReimprimir.Enabled = _supervisor;
            this.btnConfigCajero.Enabled = _supervisor;
            this.cboTipoFiltro.Enabled = _supervisor;
            this.btnFiltroAvanzado.Visible  = _supervisor;

            //this.cboTipoFiltro.Items.Clear();

            //if (_supervisor)
            //    this.cboTipoFiltro.Items.AddRange(new object[] { "No Factura", "Devolucion", "No Recibo", "Recuperar Factura" });
            //else               
            //    this.cboTipoFiltro.Items.AddRange(new object[] { "No Factura", "Recuperar Factura" });


            //seleccionar el primer index de la lista del combox tipo de filtro
            this.cboTipoFiltro.SelectedIndex = 0;
            this.cboTransaccionRealizar.SelectedIndex = 0;

            if (await ExisteAperturaCaja())
            {
                //si eres supervisor solo asignar un vacio de lo contrario asignar el numero de caja
                this.txtCaja.Text = _supervisor ? "" : User.Caja;
                //var list = new List<ViewFactura>();
                //this.dgvPuntoVenta.DataSource = list;
                btnBuscar_Click(null, null);
            }

            this.Cursor = Cursors.Default;            
            this.gridControl2.Cursor = Cursors.Default;
        }

        private async Task<bool> ExisteAperturaCaja()
        {
            bool existeApertura = false;
            try
            {
                ResponseModel responseModel = await _serviceCaja_Pos.VerificarExistenciaAperturaCajaAsync(User.Usuario, User.TiendaID);
                //Exito (1) es exitoso del servidor
                if (responseModel.Exito == 1)
                {
                    ////indicar que existe la apertura de caja
                    existeApertura = true;
                    List<DatosResult> listDatosResult = new List<DatosResult>();
                    listDatosResult = responseModel.Data as List<DatosResult>;

                    User.Caja = listDatosResult[0].ResultString.ToString();
                    User.ConsecCierreCT = listDatosResult[1].ResultString.ToString();
                    //asignar la bodega encontrado 
                    User.BodegaID = listDatosResult[2].ResultString.ToString();
                    //Mascara de la factura
                    User.MascaraFactura = listDatosResult[3].ResultString.ToString();


                    this.lblCajaApertura.Text = "Caja de Apertura: " + User.Caja;
                    this.lblNoCierre.Text = "No. Cierre: " + User.ConsecCierreCT;
                    this.btnAperturaCaja.Enabled = false;
                    this.btnCierreCaja.Enabled = true;
                    this.btnPrelectura.Enabled = true;
                    this.btnNuevaFactura.Enabled = true;
                    this.btnRecibo.Enabled = _supervisor;
                }
                else if (responseModel.Exito == 0)
                {
                    //indicar que no existe la apertura de caja
                    existeApertura = false;
                    this.lblCajaApertura.Text = "Caja de Apertura: --- ";
                    this.lblNoCierre.Text = "No. Cierre: --- ";
                    this.btnNuevaFactura.Enabled = false;
                    this.btnRecibo.Enabled = false;
                    this.btnAperturaCaja.Enabled = true;
                    this.btnCierreCaja.Enabled = false;
                    this.btnPrelectura.Enabled = false;
                    User.Caja = "";
                    User.ConsecCierreCT = "";
                }
                //(-1) el registro tiene inconsistencia
                else if (responseModel.Exito == -1)
                {
                    //indicar que no existe la apertura de caja
                    existeApertura = false;
                    this.lblCajaApertura.Text = "Caja de Apertura: --- ";
                    this.lblNoCierre.Text = "No. Cierre: --- ";
                    this.btnNuevaFactura.Enabled = false;
                    this.btnRecibo.Enabled = false;
                    this.btnAperturaCaja.Enabled = true;
                    this.btnCierreCaja.Enabled = false;
                    this.btnPrelectura.Enabled = false;

                    MessageBox.Show("Existe inconsistencia con el cierre de cajero y caja", "Sistema COVENTAF");
                    MessageBox.Show("Pongase en contacto con el supervisor", "Sistema COVENTAF");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Sistema COVENTAF");
            }

            return existeApertura;
        }

       /* private async void onListarGridFacturas(FiltroFactura filtroFactura)
        {
            var responseModel = new ResponseModel();
            responseModel = await this._facturaController.ListarFacturas(filtroFactura);
            this.dgvPuntoVenta.DataSource = responseModel.Data;

        }*/

        //evento para seleccionar el tipo de filtro
        /*private void cboTipoFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {

            switch (this.cboTipoFiltro.Text)
            {
                case "Factura del dia":
                    this.txtBusqueda.Enabled = false;

                    break;
                case "Recuperar Factura":
                    this.txtBusqueda.Enabled = true;

                    break;
                case "No Factura":
                    this.txtBusqueda.Enabled = true;
                    break;
                case "Devolucion":
                    this.txtBusqueda.Enabled = true;

                    break;
                case "Rango de Fecha":
                    this.txtBusqueda.Visible = false;
                    this.dtFechaDesde.Visible = true;
                    this.dtFechaHasta.Visible = true;

                    break;
            }

            this.txtBusqueda.Focus();
        }*/


        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void btnAperturaCaja_Click(object sender, EventArgs e)
        {
            var frmAperturaCaja = new frmAperturaCaja();
            frmAperturaCaja.ShowDialog();
            bool exitosApertura = frmAperturaCaja.ExitoAperturaCaja;
            //liberar recurso del form
            frmAperturaCaja.Dispose();

            //comprobar si la apertura fue exitosa
            if (exitosApertura)
            {
                if (await ExisteAperturaCaja())
                {
                    //si eres supervisor solo asignar un vacio de lo contrario asignar el numero de caja
                    this.txtCaja.Text = _supervisor ? "" : User.Caja;
                    btnBuscar_Click(null, null);
                   
                }              
            }
        }

        private void btnNuevaFactura_Click(object sender, EventArgs e)
        {
            NuevaFactura();                                 
        }

        private void NuevaFactura()
        {
            if (User.Caja.Length > 0)
            {
                bool facturaGuardada = false;
                using (var frm = new frmVentas())
                {
                    frm.ShowDialog();
                    facturaGuardada = frm.facturaGuardada;
                }
                          
                //asignar los valores por defectos para iniciar el form
                filtroFactura.Busqueda = "";
                filtroFactura.FechaInicio = this.dtFechaDesde.Value;
                filtroFactura.FechaFinal = this.dtFechaHasta.Value;
                filtroFactura.Tipofiltro = this.cboTipoFiltro.Text;
                filtroFactura.Cajero = User.Usuario;

                //listar las facturas en el Grid
                //onListarGridFacturas(filtroFactura);

                //si la factura se guardo correctamente entonces vuelvo a llamar a la ventana ventas
                if (facturaGuardada)
                {
                    btnNuevaFactura_Click(null, null);
                }
            }
            else
            {
                MessageBox.Show("Debes de Aperturar Caja para continuar", "Sistema COVENTAF");
            }


        }

        private async void btnCierreCaja_Click(object sender, EventArgs e)
        {
            //si la autorizacion no tuvo exitos entonces no continua
            if (!UtilidadesMain.AutorizacionExitosa()) return;

            var frmCierreCaja = new frmCierreCaja();
            frmCierreCaja.ShowDialog();
            if (frmCierreCaja.CierreCajaExitosamente)
            {
                await ExisteAperturaCaja();             
            }
            //liberar recurso del form
            frmCierreCaja.Dispose();
        }

   
        private void btnAnularFactura_Click(object sender, EventArgs e)
        {
            if (User.ConsecCierreCT.Trim().Length==0)
            {
                MessageBox.Show($"No existe un numero de cierre para el usuario {User.Usuario}, debes de hacer apertura", "Sistema COVENTAF");
                return;
            }

            if (UtilidadesMain.AutorizacionExitosa())
            {
                var frmAnularFactura = new frmAnularFactura();
                frmAnularFactura._supervisor = _supervisor;
                frmAnularFactura.ShowDialog();
            }            
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


  

        private void btnDevoluciones_Click(object sender, EventArgs e)
        {
            //comprobar si el gridview tiene registro
            if (dgvPuntoVenta.RowCount > 0)
            {
                //obtener la fila seleccionada
                int fila = dgvPuntoVenta.GetSelectedRows()[0];
                //obtener del grid la factura
                var factura= dgvPuntoVenta.GetRowCellValue(fila, "Factura").ToString().Trim();
                //obtener del Tipo Documento
                var tipoDocumento = dgvPuntoVenta.GetRowCellValue(fila, "Tipo_Documento").ToString().Trim();

                //verificar si la caja tiene apertura y tiene un numero de cierre de consecutivo
                if (User.Caja.Length > 0 && User.ConsecCierreCT.Length > 0 && tipoDocumento == "F")
                {
                    //si la autorizacion fue exitosa entonces abrir la venta de devolucion.
                    if (UtilidadesMain.AutorizacionExitosa())
                    {                        
                        //dgvPuntoVenta.CurrentCell = dgvPuntoVenta.SelectedRows//.Rows[consecutivoActualFactura].Cells[3]; */
                        var frmDevolucion = new frmDevoluciones();
                        frmDevolucion.factura = dgvPuntoVenta.GetRowCellValue(fila, "Factura").ToString().Trim();
                        frmDevolucion.numeroCierre = dgvPuntoVenta.GetRowCellValue(fila, "Num_Cierre").ToString().Trim();
                        frmDevolucion.caja = dgvPuntoVenta.GetRowCellValue(fila, "Caja").ToString().Trim();
                        frmDevolucion.ShowDialog();
                    }             
                }
                else if (User.Caja.Length > 0 && User.ConsecCierreCT.Length > 0 && (tipoDocumento == "R"  || tipoDocumento =="D"))
                {
                    MessageBox.Show("Tu tipo de documento tiene que ser una Factura", "Sistema COVENTAF");
                }
                else if (User.Caja.Length > 0 && User.ConsecCierreCT.Length > 0)
                {
                    MessageBox.Show("Para Continuar debes de realizar apertura de Caja", "Sistema COVENTAF");
                }
            }



        }


        private void dgvConsultaFacturas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            rowGrid = e.RowIndex;
            //if (dgvConsultaFacturas.Columns[e.ColumnIndex].Name == "btnSeleccionar")
            //{
            //obtener el indiciee

            //if (index >= 0)
            //{
            //    string valor = dgvConsultaFacturas.Rows[index].Cells["Factura"].Value.ToString();
            //    this.AsignarDatosFactura(dgvConsultaFacturas.Rows[index].Cells["FACTURA"].Value.ToString());


            //    //txtindex.Text = (index + 1).ToString();
            //    //txtid.Text = dgdata.Rows[index].Cells["Id"].Value.ToString();
            //    //txtdocumento.Text = dgdata.Rows[index].Cells["NumeroDocumento"].Value.ToString();
            //    //txtrazonsocial.Text = dgdata.Rows[index].Cells["RazonSocial"].Value.ToString();
            //    //txtcorreo.Text = dgdata.Rows[index].Cells["Correo"].Value.ToString();
            //    //txttelefono.Text = dgdata.Rows[index].Cells["Telefono"].Value.ToString();
            //}

            //}
        }


        //private void dgvPuntoVenta_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        //{

        //}

        private void dgvPuntoVenta_MouseDoubleClick(object sender, MouseEventArgs e)
        {

            if (rowGrid >= 0)
            {
                this.btnDevoluciones.Enabled = _supervisor;
                this.btnAnularFactura.Enabled = _supervisor;
                this.btnDetalleFactura.Enabled = true;
                //facturaAnular = dgvConsultaFacturas.Rows[IndexGrid].Cells["FACTURA"].Value.ToString();
                //estadoCajero = dgvConsultaFacturas.Rows[IndexGrid].Cells["Estado_Cajero"].Value.ToString();
                //estadoCaja = dgvConsultaFacturas.Rows[IndexGrid].Cells["Estado_Caja"].Value.ToString();

                //asignar los datos                
                //this.AsignarDatosFactura(dgvConsultaFacturas.Rows[IndexGrid].Cells["FACTURA"].Value.ToString());

                //txtindex.Text = (index + 1).ToString();
                //txtid.Text = dgdata.Rows[index].Cells["Id"].Value.ToString();
                //txtdocumento.Text = dgdata.Rows[index].Cells["NumeroDocumento"].Value.ToString();
                //txtrazonsocial.Text = dgdata.Rows[index].Cells["RazonSocial"].Value.ToString();
                //txtcorreo.Text = dgdata.Rows[index].Cells["Correo"].Value.ToString();
                //txttelefono.Text = dgdata.Rows[index].Cells["Telefono"].Value.ToString();
            }
        }

        private void frmPuntoVenta_KeyDown(object sender, KeyEventArgs e)
        {
            //comprobar si el usuario presiono la tecla f1 y ademas si el boton esta habilitado
            if (e.KeyCode == Keys.F1 && this.btnNuevaFactura.Enabled)
            {
                btnNuevaFactura_Click(null, null);
            }

            //comprobar si el usuario presiono la tecla f5 y ademas si el boton esta habilitado
            else if (e.KeyCode == Keys.F2 && this.btnRecibo.Enabled)
            {
                btnRecibo_Click(null, null);
            }
            //F6 y chkDescuentoGeneral este habilitado
            else if (e.KeyCode == Keys.F3 && this.btnDevoluciones.Enabled)
            {
                btnDevoluciones_Click(null, null);
            }

            else if (e.KeyCode == Keys.F5 && this.btnDetalleFactura.Enabled)
            {
                btnDetalleFactura_Click(null, null);
            }
        }

        private void frmPuntoVenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyCode == Keys.F1 && this.btnNuevaFactura.Enabled)
            //{
            //    btnNuevaFactura_Click(null, null);
            //}

            ////comprobar si el usuario presiono la tecla f5 y ademas si el boton esta habilitado
            //else if (e.KeyCode == Keys.F2 && this.btnBusca.Enabled)
            //{
            //    btnBusca_Click(null, null);
            //}
            ////F6 y chkDescuentoGeneral este habilitado
            //else if (e.KeyCode == Keys.F3 && this.btnDevoluciones.Enabled)
            //{
            //    btnDevoluciones_Click(null, null);
            //}
        }

        private void btnPrelectura_Click(object sender, EventArgs e)
        {
            //si la autorizacion no tuvo exitos entonces no continua
            if (!UtilidadesMain.AutorizacionExitosa()) return;

            var frmPrelectura = new frmPreLectura();
            frmPrelectura.ShowDialog();
            if (frmPrelectura.CierreCajaExitosamente)
            {
                //await ExisteAperturaCaja();
            }
            //liberar recurso del form
            frmPrelectura.Dispose();
        }

        private async void btnBuscar_Click(object sender, EventArgs e)
        {           
            if (FiltrosValido())
            {
               
                //this.btnAnularFactura.Enabled = false;
                var filtroFactura = new FiltroFactura();
                ResponseModel responseModel = new ResponseModel();
                try
                {
                    this.btnBuscar.Enabled = false;

                    this.Cursor = Cursors.WaitCursor;
                    this.gridControl2.Cursor = Cursors.WaitCursor;

                    this.lblCantidadRegistro.Text = "Cantidad de Registro: 0";

                    filtroFactura.FechaInicio = Convert.ToDateTime(this.dtFechaDesde.Value.Date);
                    filtroFactura.FechaFinal = Convert.ToDateTime(this.dtFechaHasta.Value.Date);
                    filtroFactura.Caja = this.txtCaja.Text.Length == 0 ? "" : this.txtCaja.Text;
                    filtroFactura.FacturaDesde = this.txtFacturaDesde.Text.Length == 0 ? "" : this.txtFacturaDesde.Text;
                    filtroFactura.FacturaHasta = this.txtFacturaHasta.Text.Length == 0 ? "" : this.txtFacturaHasta.Text;
                   
                    filtroFactura.Tipofiltro = ObtenerTipoFiltro(filtroFactura);


                    if (this.cboTipoFiltro.Text == "No Recibo")
                    {
                        filtroFactura.TipoDocumento = "R";
                        responseModel = await _serviceFactura.BuscarRecibo(filtroFactura, _supervisor, responseModel);
                        if (responseModel.Exito != 1)
                        {
                            this.lblCantidadRegistro.Text = "Cantidad de Registro: 0";

                            var list = new List<ViewRecibo>();
                            this.dgvPuntoVenta.GridControl.DataSource = list;
                        }
                        else
                        {
                            var list = responseModel.Data as List<ViewRecibo>;
                            this.dgvPuntoVenta.GridControl.DataSource = list;//responseModel.Data as List<ViewRecibo>;
                            this.lblCantidadRegistro.Text = $"Cantidad de Registro: {list.Count}";
                        }
                    }
                    //delo contrario es factura o devolucion
                    else 
                    {
                        //
                        filtroFactura.TipoDocumento = this.cboTipoFiltro.Text == "No Factura" ? "F" : "D";
                        responseModel = await _serviceFactura.BuscarFactura(filtroFactura, _supervisor, responseModel);
                        if (responseModel.Exito != 1)
                        {
                            var list = new List<ViewFactura>();
                            this.dgvPuntoVenta.GridControl.DataSource = list;
                        }
                        else
                        {
                            
                            var list =responseModel.Data as List<ViewFactura>;
                            this.dgvPuntoVenta.GridControl.DataSource = list;//responseModel.Data as List<ViewFactura>;
                            this.lblCantidadRegistro.Text = $"Cantidad de Registro: {list.Count}";
                        }
                    }
                    
                }
                catch (Exception ex)
                {                   
                    MessageBox.Show(ex.Message, "Sistema COVENTAF");
                }
                finally
                {
                    this.btnBuscar.Enabled = true;
                    this.Cursor = Cursors.Default;
                    this.gridControl2.Cursor = Cursors.Default;
                }
            }
            
        }

        private void BuscarDatosPuntoVenta()
        {
            try
            {

            }
            catch (Exception ex)
            {

            }

        }
           

        private void btnReimprimir_Click(object sender, EventArgs e)
        {
            using(var frmReimprimir = new frmReimpresion())
            {
                frmReimprimir._supervisor = _supervisor;
                frmReimprimir.ShowDialog();
            }
        }

        private void btnConfigCajero_Click(object sender, EventArgs e)
        {
            using (var frmReimprimir = new frmListaCajero())
            {                
                frmReimprimir.ShowDialog();
            }
        }

        private void btnRecibo_Click(object sender, EventArgs e)
        {
            using (var frmRecibo = new frmRecibo())
            {                
                frmRecibo.ShowDialog();
            }
        }

        private void btnDetalleFactura_Click(object sender, EventArgs e)
        {
            if (this.dgvPuntoVenta.RowCount >0)
            {
                using(var frmDetalleVenta = new frmDetalleFactura())
                {
                    int fila = dgvPuntoVenta.GetSelectedRows()[0];

                    frmDetalleVenta.factura = dgvPuntoVenta.GetRowCellValue(fila, "Factura").ToString().Trim();
                    frmDetalleVenta.tipoDocumento = dgvPuntoVenta.GetRowCellValue(fila, "Tipo_Documento").ToString().Trim();
                    frmDetalleVenta.ShowDialog();
                }
            }
        }

        private void btnConfiguracionBascula_Click(object sender, EventArgs e)
        {
            using (var frmConfigurar = new frmConfigurarBascula())
            {
                frmConfigurar.ShowDialog();
            }
        }

        private void btnFiltroAvanzado_Click(object sender, EventArgs e)
        {
            //asignar los filtros a la clase
            filtroFactura.Tipofiltro = this.cboTipoFiltro.Text;
            filtroFactura.FechaInicio = this.dtFechaDesde.Value;
            filtroFactura.FechaFinal = this.dtFechaHasta.Value;
            filtroFactura.Caja = this.txtCaja.Text;
            filtroFactura.FacturaDesde = this.txtFacturaDesde.Text;
            filtroFactura.FacturaHasta = this.txtFacturaHasta.Text;
                        
            if (this.cboTipoFiltro.Text == "No Factura")
            {
                filtroFactura.TipoDocumento = "F";
            }                
            else if (this.cboTipoFiltro.Text == "Devolucion")
            {
                filtroFactura.TipoDocumento = "D";
            }                
            else
            {
                filtroFactura.TipoDocumento = "R";
            }
                

            using (var frmFiltroAvanzado = new frmFiltroAvanzado())
            {
                //pasar la clase de filtro al formulario frmFiltroAvanzado
                frmFiltroAvanzado.filtroFactura = filtroFactura;                
                frmFiltroAvanzado.ShowDialog();
                if (frmFiltroAvanzado.resultExitoso)
                {                   
                    this.Cursor = Cursors.WaitCursor;

                    this.dgvPuntoVenta.GridControl.DataSource = frmFiltroAvanzado.listaFactura;
                    this.lblCantidadRegistro.Text = $"Cantidad de Registro: {frmFiltroAvanzado.listaFactura.Count}";
                    this.cboTipoFiltro.Text = filtroFactura.Tipofiltro;
                    this.dtFechaDesde.Text = filtroFactura.FechaInicio.ToString();
                    this.dtFechaHasta.Text = filtroFactura.FechaFinal.ToString();
                    this.txtCaja.Text = filtroFactura.Caja;
                    this.txtFacturaDesde.Text = filtroFactura.FacturaDesde;
                    this.txtFacturaHasta.Text = filtroFactura.FacturaHasta;
                   
                    this.Cursor = Cursors.Default;
                }
            }
        }
    }
}
