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
    public partial class frmBuscarCliente : Form
    {
        List<Clientes> datosClientes;

        public frmBuscarCliente()
        {
            InitializeComponent();
        }

        private async void btnBuscar_Click(object sender, EventArgs e)
        {


            ResponseModel responseModel = new ResponseModel();
           
            var _dataService = new ServiceCliente();

            try
            {
                responseModel = await _dataService.ObtenerListaClientes(this.txtIdentificacion.Text, responseModel);
                if (responseModel.Exito ==1)
                {
                    datosClientes = new List<Clientes>();
                    datosClientes = responseModel.Data as List<Clientes>;

                    foreach (var item in datosClientes)
                    {
                        this.dgvListaCliente.Rows.Add(item.Cliente, item.Contribuyente, item.Nombre, item.Cargo, item.Activo);
                    }

                }


            }
            catch (Exception ex)
            {

            }
            finally
            {

            }

        }

        private void txtIdentificacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {

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

            }
            else
            {
                this.txtIdentificacion.Text = "";
            }
        }
    }
}
