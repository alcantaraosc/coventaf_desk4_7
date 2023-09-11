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

namespace COVENTAF.ModuloAcceso
{
    public partial class frmListaVisitaCliente : Form
    {

        string Transition;
       
        #region codigo para mover pantalla
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        #endregion

   
        private void barraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }


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
            this.tmTransition.Start();
        }

        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            //comprobar el estado de la ventana
            this.WindowState = this.WindowState == FormWindowState.Normal ? this.WindowState = FormWindowState.Maximized : this.WindowState = FormWindowState.Normal;            
        }

        private void frmListaVisitaCliente_Load(object sender, EventArgs e)
        {
            Transition = "FadeIn";
            tmTransition.Start();
            this.Top = this.Top + 15;           
        }

        private void tmTransition_Tick(object sender, EventArgs e)
        {
            UtilidadesMain.tmTransition_Tick(ref Transition, this.tmTransition, this);
        }
    }
}
