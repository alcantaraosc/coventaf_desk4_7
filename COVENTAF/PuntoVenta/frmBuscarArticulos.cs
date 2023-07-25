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
    public partial class frmBuscarArticulos : Form
    {
        List<Articulos> datosArticulos;
        string Transition;
        public string codigoArticulo = "";
        public string descripcionArticulo = "";
        public bool resultExitosa = false;
   

        #region codigo para mover pantalla
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        #endregion
        public frmBuscarArticulos()
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
            if (this.txtCodigoArticulo.Text.Trim().Length >0 && this.txtDescripcionArticulo.Text.Trim().Length==0)
            {
                tipoFiltro = "Articulo";
                busqueda = this.txtCodigoArticulo.Text;
            }
            //nombre del cliente y que la identificacion del cliente este vacio 
            else if (this.txtDescripcionArticulo.Text.Trim().Length >0 && this.txtCodigoArticulo.Text.Trim().Length ==0)
            {
                tipoFiltro = "Descripcion";
                busqueda = $"%{this.txtDescripcionArticulo.Text}%";
                busqueda = busqueda.Replace(" ", "%");
            }
            //si la identificacion y el nombre del cliente estan vacion entonces mandar un mensaje y cancelar la busqueda
            else if (this.txtDescripcionArticulo.Text.Trim().Length ==0 && this.txtCodigoArticulo.Text.Trim().Length == 0)
            {                
                MessageBox.Show("Debes de ingresar el codigo del articulo o la descripcion del articulo", "Sistema COVENTAF");
                return;
            }

            this.Cursor = Cursors.WaitCursor;
            this.dgvListaArticulos.Cursor = Cursors.WaitCursor;

            //limpiar las filas
            this.dgvListaArticulos.Rows.Clear();
            ResponseModel responseModel = new ResponseModel();           
            var _dataService = new ServiceArticulo();

            try
            {
                responseModel = await _dataService.ObtenerListaArticulos(tipoFiltro, busqueda, responseModel);
                if (responseModel.Exito ==1)
                {
                    datosArticulos = new List<Articulos>();
                    datosArticulos = responseModel.Data as List<Articulos>;

                    foreach (var item in datosArticulos)
                    {
                        this.dgvListaArticulos.Rows.Add(item.Articulo, item.CODIGO_BARRAS_INVT, item.Descripcion, item.ACTIVO);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Sistema COVENTAF");
            }
            finally
            {
                this.Cursor = Cursors.Default;
                this.dgvListaArticulos.Cursor = Cursors.Default;
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
                this.txtDescripcionArticulo.Text = "";               
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
                this.txtCodigoArticulo.Text = "";
            }
        }

        private void btnCierre_Click(object sender, EventArgs e)
        {
            this.tmTransition.Start();
        }

        private void tmTransition_Tick(object sender, EventArgs e)
        {
            Utilidades.tmTransition_Tick(ref Transition, this.tmTransition, this);
        }

        private void frmBuscarCliente_Load(object sender, EventArgs e)
        {
            Transition = "FadeIn";
            tmTransition.Start();
            this.Top = this.Top + 15;
        }

        private void dgvListaCliente_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            resultExitosa = true;
            int index = dgvListaArticulos.CurrentRow.Index;
            codigoArticulo = this.dgvListaArticulos.Rows[index].Cells[0].Value.ToString();
            descripcionArticulo = this.dgvListaArticulos.Rows[index].Cells[2].Value.ToString();
            btnCierre_Click(null, null);
        }
    }
}
