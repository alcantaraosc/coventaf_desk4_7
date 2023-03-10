
using Api.Model.Modelos;
using Api.Model.ViewModels;
using Api.Service.DataService;
using Controladores;
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
    public partial class frmPuntoVenta : Form
    {
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();


        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private readonly FacturaController _facturaController;
        public RolesDelSistema _rolesDelSistema;


        //clase para enviar el filtro.
        FiltroFactura filtroFactura = new FiltroFactura();


        private readonly CajaPosController _cajaPosController;
        private ServiceCaja_Pos _serviceCaja_Pos = new ServiceCaja_Pos();

        public int rowGrid = 0;

        public frmPuntoVenta()
        {
            InitializeComponent();
            this._facturaController = new FacturaController();
            this._cajaPosController = new CajaPosController();

           

            //FlowLayoutPanel panel = new FlowLayoutPanel();
            //panel.AutoSize = true;
            //panel.FlowDirection = FlowDirection.TopDown;
            //panel.Controls.Add(TextBox1);
            //this.Controls.Add(panel);

            //this.KeyPreview = true;
            //this.KeyPress +=
            //    new KeyPressEventHandler(frmPuntoVenta_KeyPress);

            //frmPuntoVenta_KeyDown


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

           

            this.dgvPuntoVenta.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvPuntoVenta.AutoGenerateColumns = true;

            //seleccionar el primer index de la lista del combox tipo de filtro
            this.cboTipoFiltro.SelectedIndex = 0;

            if (await ExisteAperturaCaja())
            {
                //asignar los valores por defectos para iniciar el form
                filtroFactura.Busqueda = User.ConsecCierreCT;
                filtroFactura.FechaInicio = this.dtFechaDesde.Value;
                filtroFactura.FechaFinal = this.dtFechaHasta.Value;
                filtroFactura.Tipofiltro = this.cboTipoFiltro.Text;
                filtroFactura.Cajero = User.Usuario;

                //listar las facturas en el Grid
                onListarGridFacturas(filtroFactura);
            }

            this.Cursor = Cursors.Default;
        }

        private async Task<bool> ExisteAperturaCaja()
        {
            bool existeApertura = false;
            try
            {
                ResponseModel responseModel = await _serviceCaja_Pos.VerificarExistenciaAperturaCajaAsync(User.Usuario, User.TiendaID);
                if (responseModel.Exito == 1)
                {
                    ////indicar queexiste la apertura de caja
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
                    this.btnNuevaFactura.Enabled = true;
                }
                else if (responseModel.Exito == 0)
                {
                    //indicar que no existe la apertura de caja
                    existeApertura = false;
                    this.lblCajaApertura.Text = "Caja de Apertura: --- ";
                    this.lblNoCierre.Text = "No. Cierre: --- ";
                    this.btnNuevaFactura.Enabled = false;
                    this.btnAperturaCaja.Enabled = true;
                    this.btnCierreCaja.Enabled = false;
                    existeApertura = false;
                }
                //(-1) el registro tiene inconsistencia
                else if (responseModel.Exito == -1)
                {
                    //indicar que no existe la apertura de caja
                    existeApertura = false;
                    this.lblCajaApertura.Text = "Caja de Apertura: --- ";
                    this.lblNoCierre.Text = "No. Cierre: --- ";
                    this.btnNuevaFactura.Enabled = false;
                    this.btnAperturaCaja.Enabled = true;
                    this.btnCierreCaja.Enabled = false;

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

        private async void onListarGridFacturas(FiltroFactura filtroFactura)
        {
            var responseModel = new ResponseModel();
            responseModel = await this._facturaController.ListarFacturas(filtroFactura);
            this.dgvPuntoVenta.DataSource = responseModel.Data;

        }

        //evento para seleccionar el tipo de filtro
        private void cboTipoFiltro_SelectedIndexChanged(object sender, EventArgs e)
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
        }


        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAperturaCaja_Click(object sender, EventArgs e)
        {
            var frmAperturaCaja = new frmAperturaCaja();
            frmAperturaCaja.ShowDialog();
            if (frmAperturaCaja.ExitoAperturaCaja)
            {
                this.lblCajaApertura.Text = "Caja de Apertura: " + User.Caja;
                this.lblNoCierre.Text = "No. Cierre: " + User.ConsecCierreCT;
                //desactivar la opcion de caja de apertura
                this.btnAperturaCaja.Enabled = false;
                this.btnCierreCaja.Enabled = true;
                this.btnNuevaFactura.Enabled = true;

            }
            //liberar recurso del form
            frmAperturaCaja.Dispose();
        }

        private void btnNuevaFactura_Click(object sender, EventArgs e)
        {
            NuevaFactura();

            //DialogResult dialogResult;
            //using (var frmMessageBox = new frmMessageBox("¿ Estas seguro de crear una nueva factura ?"))
            //{
            //    frmMessageBox.ShowDialog();
            //    dialogResult = frmMessageBox.respuesta;
            //}

            //if (dialogResult == DialogResult.Yes)
            //{
            /* NuevaFactura();
             var frm = new frmVentas();
             frm.ShowDialog();
             //liberar recurso
             frm.Dispose();

             //asignar los valores por defectos para iniciar el form
             filtroFactura.Busqueda = "";
             filtroFactura.FechaInicio = this.dtpFechaInicio.Value;
             filtroFactura.FechaFinal = this.dtpFechaFinal.Value;
             filtroFactura.Tipofiltro = this.cboTipoFiltro.Text;
             filtroFactura.Cajero = User.Usuario;

             //listar las facturas en el Grid
             onListarGridFacturas(filtroFactura);*/
            //NuevaFactura();

            //}                        
        }

        private void NuevaFactura()
        {
            bool facturaGuardada = false;
            var frm = new frmVentas();
            frm.ShowDialog();
            facturaGuardada = frm.facturaGuardada;

            //liberar recurso
            frm.Dispose();

            //asignar los valores por defectos para iniciar el form
            filtroFactura.Busqueda = "";
            filtroFactura.FechaInicio = this.dtFechaDesde.Value;
            filtroFactura.FechaFinal = this.dtFechaHasta.Value;
            filtroFactura.Tipofiltro = this.cboTipoFiltro.Text;
            filtroFactura.Cajero = User.Usuario;

            //listar las facturas en el Grid
            onListarGridFacturas(filtroFactura);

            //si la factura se guardo correctamente entonces vuelvo a llamar a la ventana ventas
            if (facturaGuardada)
            {
                NuevaFactura();
            }

        }

        private async void btnCierreCaja_Click(object sender, EventArgs e)
        {
            var frmCierreCaja = new frmCierreCaja();
            frmCierreCaja.ShowDialog();
            if (frmCierreCaja.CierreCajaExitosamente)
            {
                await ExisteAperturaCaja();
                /* this.lblCajaApertura.Text = "Caja de Apertura: Sin Apertura";
                 this.lblNoCierre.Text = "No. Cierre: ";
                 //desactivar la opcion de caja de apertura
                 this.btnAperturaCaja.Enabled = true;
                 this.btnCierreCaja.Enabled = false;
                 this.btnNuevaFactura.Enabled = false;*/

            }
            //liberar recurso del form
            frmCierreCaja.Dispose();
        }

        private void btnAnularFactura_Click(object sender, EventArgs e)
        {
            var frmAnularFactura = new frmAnularFactura();
            frmAnularFactura.ShowDialog();
        }

     

        private void btnBusca_Click(object sender, EventArgs e)
        {
            
        }

        private void btnDevoluciones_Click(object sender, EventArgs e)
        {
            if (dgvPuntoVenta.RowCount >0)
            {
                int fila = dgvPuntoVenta.CurrentRow.Index;
                //dgvPuntoVenta.CurrentCell = dgvPuntoVenta.SelectedRows//.Rows[consecutivoActualFactura].Cells[3]; */
                var frmDevolucion = new frmDevoluciones();
                frmDevolucion.factura = dgvPuntoVenta.Rows[fila].Cells["Factura"].Value.ToString();
                frmDevolucion.numeroCierre = dgvPuntoVenta.Rows[fila].Cells["Num_Cierre"].Value.ToString();
                frmDevolucion.ShowDialog();

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
                this.btnDevoluciones.Enabled = true;
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
            else if (e.KeyCode == Keys.F2 && this.btnBusca.Enabled)
            {
                btnBusca_Click(null, null);
            }
            //F6 y chkDescuentoGeneral este habilitado
            else if (e.KeyCode == Keys.F3 && this.btnDevoluciones.Enabled)
            {
                btnDevoluciones_Click(null, null);
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
    }
}
