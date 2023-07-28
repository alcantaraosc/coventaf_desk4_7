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

namespace COVENTAF.ModuloAcceso
{
    public partial class frmListaVisitaCliente : Form
    {
        public frmListaVisitaCliente()
        {
            InitializeComponent();
        }

        private async void btnBuscar_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;                     

            ResponseModel responseModel = new ResponseModel();
            var _dataService = new ServiceCliente();
            try
            {
                DateTime fechaInicial = new DateTime();
                DateTime fechaFinal = new DateTime();

                fechaInicial = this.dtFechaDesde.Value;
                fechaFinal = this.dtFechaHasta.Value;

                responseModel = await new ServiceCliente().ListarCliente(fechaInicial, fechaFinal, responseModel);

                if (responseModel.Exito == 1)
                {
                    List<ListaCliente> datosClientes = new List<ListaCliente>();
                    datosClientes = responseModel.Data as List<ListaCliente>;
                    this.gridView1.GridControl.DataSource = datosClientes as List<ListaCliente>;

                    //foreach (var item in datosClientes)
                    //{
                    //    this.dgvListaCliente.Rows.Add(item.NumeroVisita, item.Cliente, item.Nombre, item.Parentesco, item.Sexo, item.FechaNacimiento, item.Edad, item.Cedula,
                    //        item.Titular, item.NombreTitular, "", item.FechaUltIngreso, item.CantidadVisita, item.FechaVisita);
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
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            //comprobar el estado de la ventana
            this.WindowState = this.WindowState == FormWindowState.Normal ? this.WindowState = FormWindowState.Maximized : this.WindowState = FormWindowState.Normal;            
        }
    }
}
