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

namespace COVENTAF.ModuloCliente
{
    public partial class frmModuloCliente : Form
    {
        public frmModuloCliente()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    

        private async void btnBuscar_Click(object sender, EventArgs e)
        {
            string tipoFiltro = "";
            string busqueda = "";

            if (this.txtCodigo.Text.Trim().Length > 0 && this.txtIdentificacion.Text.Trim().Length == 0 && this.txtNombreCliente.Text.Trim().Length == 0)
            {
                tipoFiltro = "Codigo";
                busqueda = this.txtCodigo.Text;
            }
            //identificacion y que el nombre del cliente este en cero
            else if (this.txtIdentificacion.Text.Trim().Length > 0 && this.txtCodigo.Text.Trim().Length == 0 && this.txtNombreCliente.Text.Trim().Length == 0)
            {
                tipoFiltro = "Identificacion";
                busqueda = this.txtIdentificacion.Text;
            }
            //nombre del cliente y que la identificacion del cliente este vacio 
            else if (this.txtNombreCliente.Text.Trim().Length > 0 && this.txtCodigo.Text.Trim().Length == 0 && this.txtIdentificacion.Text.Trim().Length == 0)
            {
                tipoFiltro = "Cliente";
                busqueda = this.txtNombreCliente.Text;
                busqueda = $"%{busqueda}%";
                busqueda = busqueda.Replace(" ", "%");
            }
            //si la identificacion y el nombre del cliente estan vacion entonces mandar un mensaje y cancelar la busqueda
            else if (this.txtNombreCliente.Text.Trim().Length == 0 && this.txtIdentificacion.Text.Trim().Length == 0 && this.txtCodigo.Text.Trim().Length == 0)
            {
                MessageBox.Show("Debes de ingresar el numero de identificacion o el nombre del cliente", "Sistema COVENTAF");
                return;
            }

            this.Cursor = Cursors.WaitCursor;
            this.dgvListaCliente.Cursor = Cursors.WaitCursor;


            //limpiar las filas
            this.dgvListaCliente.Rows.Clear();
            ResponseModel responseModel = new ResponseModel();
            var _dataService = new ServiceCliente();

            try
            {
                responseModel = await new ServiceCliente().ObtenerListaClientes(tipoFiltro, busqueda, responseModel);

                if (responseModel.Exito == 1)
                {
                    var datosClientes = new List<Clientes>();
                    datosClientes = responseModel.Data as List<Clientes>;

                    foreach (var item in datosClientes)
                    {
                        this.dgvListaCliente.Rows.Add(item.Cliente, item.Contribuyente, item.Nombre, item.Activo, item.Cargo);
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
                this.dgvListaCliente.Cursor = Cursors.Default;
            }
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)Keys.Enter)
            {
                btnBuscar_Click(null, null);
            }
            else
            {
                this.txtIdentificacion.Text = "";
                this.txtNombreCliente.Text = "";
            }
        }

        private void txtIdentificacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnBuscar_Click(null, null);
            }
            else
            {
                this.txtCodigo.Text = "";
                this.txtNombreCliente.Text = "";
            }
        }

        private void txtNombreCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnBuscar_Click(null, null);
            }
            else
            {
                this.txtCodigo.Text = "";
                this.txtIdentificacion.Text = "";
            }
        }

        private void btnNuevoCliente_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿ Estas seguro de crear un nuevo cliente ?", "Sistema COVENTAF", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                using(var frmDatosClientes = new frmCliente())
                {
                    
                    frmDatosClientes.ShowDialog();  
                }
            }
        }
    }
}
