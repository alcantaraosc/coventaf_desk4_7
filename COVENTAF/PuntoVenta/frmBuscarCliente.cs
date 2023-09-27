using Api.Model.Modelos;
using Api.Model.ViewModels;
using Api.Service.DataService;
using COVENTAF.Metodos;
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
    public partial class frmBuscarCliente : Form
    {

        List<Clientes> datosClientes;
        string Transition;
        public string codigoCliente = "";
        public string nombreCliente = "";
        public bool resultExitosa = false;
   
        #region codigo para mover pantalla
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        #endregion
        public frmBuscarCliente()
        {
            InitializeComponent();
        }

        private void barraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private async void btnBuscar_Click(object sender, EventArgs e)
        {
            string tipoFiltro="";
            string busqueda ="";

            //identificacion y que el nombre del cliente este en cero
            if (this.txtIdentificacion.Text.Trim().Length >0 && this.txtNombreCliente.Text.Trim().Length==0)
            {
                tipoFiltro = "Identificacion";
                busqueda = this.txtIdentificacion.Text;
            }
            //nombre del cliente y que la identificacion del cliente este vacio 
            else if (this.txtNombreCliente.Text.Trim().Length >0 && this.txtIdentificacion.Text.Trim().Length ==0)
            {
                tipoFiltro = "Cliente";
                busqueda = $"%{this.txtNombreCliente.Text}%";
                busqueda = busqueda.Replace(" ", "%");
            }
            //si la identificacion y el nombre del cliente estan vacion entonces mandar un mensaje y cancelar la busqueda
            else if (this.txtNombreCliente.Text.Trim().Length ==0 && this.txtIdentificacion.Text.Trim().Length == 0)
            {                
                MessageBox.Show("Debes de ingresar el numero de identificacion o el nombre del cliente", "Sistema COVENTAF");
                return;
            }

            this.Cursor = Cursors.WaitCursor;
            this.gridControl2.Cursor = Cursors.WaitCursor;

           
            ResponseModel responseModel = new ResponseModel();           
            var _dataService = new ServiceCliente();

            try
            {
                responseModel = await _dataService.ObtenerListaClientes(tipoFiltro, busqueda, responseModel);
                if (responseModel.Exito ==1)
                {
                    datosClientes = new List<Clientes>();
                    datosClientes = responseModel.Data as List<Clientes>;
                    this.dgvListaCliente.GridControl.DataSource = datosClientes;

                    //foreach (var item in datosClientes)
                    //{
                    //    this.dgvListaCliente.Rows.Add(item.Cliente, item.Contribuyente, item.Nombre, item.Cargo, item.Activo);
                    //}
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Sistema COVENTAF");
            }
            finally
            {
                this.Cursor = Cursors.Default;
                this.gridControl2.Cursor = Cursors.Default;
            }

        }

        private void txtIdentificacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                this.btnBuscar_Click(null, null);
            }
            else
            {
                this.txtNombreCliente.Text = "";               
            }
        }

        private void txtNombreCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                this.btnBuscar_Click(null, null);
            }
            else
            {
                this.txtIdentificacion.Text = "";
            }
        }

        private void btnCierre_Click(object sender, EventArgs e)
        {
            this.tmTransition.Start();
        }

        private void tmTransition_Tick(object sender, EventArgs e)
        {
            UtilidadesMain.tmTransition_Tick(ref Transition, this.tmTransition, this);
        }

        private void frmBuscarCliente_Load(object sender, EventArgs e)
        {
                      
            Transition = "FadeIn";
            tmTransition.Start();
            this.Top = this.Top + 15;

            this.txtNombreCliente.SelectionStart = 0;
            this.txtNombreCliente.SelectionLength = this.txtNombreCliente.Text.Length;
            this.txtNombreCliente.Focus();

        }

        private void dgvListaCliente_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            resultExitosa = true;
            int index = dgvListaCliente.GetSelectedRows()[0];
            if (index >=0)
            {
                codigoCliente = this.dgvListaCliente.GetRowCellValue(index, "Cliente").ToString().Trim(); // this.dgvListaCliente.Rows[index].Cells[0].Value.ToString();
                nombreCliente = this.dgvListaCliente.GetRowCellValue(index, "Nombre").ToString().Trim();
                btnCierre_Click(null, null);
            }      
        }

        private void gridControl2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            resultExitosa = true;
            int index = this.dgvListaCliente.GetSelectedRows()[0];
            if (index >=0)
            {
                codigoCliente = this.dgvListaCliente.GetRowCellValue(index, "Cliente").ToString().Trim(); //this.dgvListaCliente.Rows[index].Cells[0].Value.ToString();
                nombreCliente = this.dgvListaCliente.GetRowCellValue(index, "Nombre").ToString().Trim();
                btnCierre_Click(null, null);
            }

        }
    }
}
