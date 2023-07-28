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

namespace COVENTAF.Security
{
    public partial class frmCajero : Form
    {
        public bool nuevoCajero = false;
        string Transition;
        private ServiceCajero serviceCajero = new ServiceCajero();
        public bool resultExitoso = false;
        private Cajeros cajeros;

        #region codigo para mover pantalla
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        #endregion

        public frmCajero()
        {
            InitializeComponent();
        }

        private void barraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private async void frmCajero_Load(object sender, EventArgs e)
        {
            Transition = "FadeIn";
            tmTransition.Start();
            this.Top = this.Top + 15;

            //si llenar combox se haiga llenado correctamente y no sea un nuevo cajero entonce procede a buscar del cajero
            if (await LlenarComboxSucursal() && !nuevoCajero)
            {
                //proceder a buscar al cajero
                BuscarCajero();
            }
            else
            {
                cajeros = new Cajeros() { Verificacion = "N", Rotativo = "N", CreatedBy = User.Usuario, UpdatedBy = User.Usuario };
            }

        }

        private async Task<bool> LlenarComboxSucursal()
        {
            var resultadoExitoso = false;
            var responseModel = new ResponseModel();
            try
            {
                responseModel = await new ServiceGrupo().ListarGruposAsync(responseModel, User.TiendaID);

                if (responseModel.Exito == 1)
                {
                    resultadoExitoso = true;
                    //llenar el combox del grupo
                    this.cboSucursal.ValueMember = "Grupo";
                    this.cboSucursal.DisplayMember = "Descripcion";
                    this.cboSucursal.DataSource = responseModel.Data as List<Grupos>;
                }
                else
                {
                    MessageBox.Show(responseModel.Mensaje, "Sistema COVENTAF");
                    //cerrar la ventana con animaciones
                    btnCancel_Click(null, null);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Sistema COVENTAF");
            }

            return resultadoExitoso;
        }

        private async void BuscarCajero()
        {
            var responseModel = new ResponseModel();

            try
            {
                responseModel = await serviceCajero.ObtenerDatosCajeroId(this.txtCajero.Text, responseModel);

                if (responseModel.Exito == 1)
                {
                    cajeros = responseModel.Data as Cajeros;
                    this.txtCajero.Text = cajeros.Cajero;
                    this.txtBodega.Text = cajeros.Vendedor;
                    this.cboSucursal.SelectedValue = cajeros.Sucursal == null ? "" : cajeros.Sucursal;
                }
                else
                {
                    MessageBox.Show(responseModel.Mensaje, "Sistema COVENTAF");
                    //cerrar la ventana con animaciones
                    btnCancel_Click(null, null);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Sistema COVENTAF");
            }
        }

        private void tmTransition_Tick(object sender, EventArgs e)
        {
            Utilidades.tmTransition_Tick(ref Transition, this.tmTransition, this);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.tmTransition.Start();
        }

        private async void btnAceptar_Click(object sender, EventArgs e)
        {
            //si es un nuevo cajero entonces verificar si el nombre del cajero ya existe 
            if (nuevoCajero) if (!await ModeloCajeroEsValido()) return;
      
            if (MessageBox.Show("¿ Estas seguro Guardar los datos del Cajero ?", "Sistema COVENTAF", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    var responseModel = new ResponseModel();

                    cajeros.Cajero = nuevoCajero ? this.txtCajero.Text : cajeros.Cajero;
                    cajeros.Vendedor = this.txtBodega.Text;
                    cajeros.Sucursal = this.cboSucursal.SelectedValue.ToString();
                    cajeros.RecordDate = nuevoCajero ? DateTime.Now : cajeros.RecordDate;
                    cajeros.CreateDate = nuevoCajero ? DateTime.Now : cajeros.CreateDate;

                    responseModel = await serviceCajero.GuardarDatosCajero(cajeros, responseModel, nuevoCajero);
                    if (responseModel.Exito == 1)
                    {
                        MessageBox.Show(responseModel.Mensaje, "Sistema COVENTAF");
                        tmTransition.Start();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Sistema COVENTAF");
                }
            }
        }


        private async Task<bool> ModeloCajeroEsValido()
        {
            bool validoModelo = true;


            if (await ExisteCajeroBaseDatos())
            {
                validoModelo= false;
            }
            //si no existe el usuario en la tabla usuario entonces no se puede crear un nuevo cajero
            else if (!(await ExisteUsuario()))
            {                
                validoModelo = false;
            }
            else if (this.txtBodega.Text.Trim().Length ==0)
            {
                MessageBox.Show("Debes de ingresar el nombre de la bodega", "Sistema COVENTAF");
                validoModelo = false;
            }

            return validoModelo;
        }

        private async Task<bool> ExisteCajeroBaseDatos()
        {
            bool result = false;
            try
            {
                var responseModel = new ResponseModel();
                responseModel = await serviceCajero.ObtenerDatosCajeroId(this.txtCajero.Text, responseModel);
                if (responseModel.Exito == 1)
                {
                    result = true;
                    MessageBox.Show("El Cajero ya existe en la base de dato");                    
                }                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Sistema COVENTAF");
            }

            return result;
        }

        private async Task<bool> ExisteUsuario()
        {
            bool result = false;
            try
            {
                var responseModel = new ResponseModel();
                responseModel = await new ServiceUsuario().ObtenerDatosUsuarioPorFiltroX("Usuario", this.txtCajero.Text, responseModel);
                if (responseModel.Exito == 1)
                {
                    result = true;                    
                }
                else if (responseModel.Exito == 0)
                {
                    result = false;
                    MessageBox.Show("Primero debes de crear el usuario", "Sistema COVENTAF");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Sistema COVENTAF");
            }

            return result;
        }
    }
}
