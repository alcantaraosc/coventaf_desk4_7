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
    public partial class frmSupervisor : Form
    {
        public bool nuevoSupervisor = false;
        string Transition;
        private ServiceSupervisor serviceSupervisor = new ServiceSupervisor();
        public bool resultExitoso = false;
        private Supervisores supervisor;

        #region codigo para mover pantalla
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        #endregion

        public frmSupervisor()
        {
            InitializeComponent();
        }

        private void barraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private async void frmSupervisor_Load(object sender, EventArgs e)
        {
            Transition = "FadeIn";
            tmTransition.Start();
            this.Top = this.Top + 15;

            //si llenar combox se haiga llenado correctamente y no sea un nuevo cajero entonce procede a buscar del cajero
            if (await LlenarComboxSucursal() && !nuevoSupervisor)
            {
                //proceder a buscar al cajero
                BuscarSupervisor();
            }
            else
            {
                supervisor = new Supervisores() { CreatedBy = User.Usuario, UpdatedBy = User.Usuario };
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

        private async void BuscarSupervisor()
        {
            var responseModel = new ResponseModel();

            try
            {
                responseModel = await serviceSupervisor.ObtenerDatosSupervisorId(this.txtSupervisor.Text, responseModel);

                if (responseModel.Exito == 1)
                {
                    supervisor = responseModel.Data as Supervisores;
                    this.txtSupervisor.Text = supervisor.Supervisor;
                    this.chkSuperUsuario.Checked = supervisor.SuperUsuario =="S" ? true : false ;
                    this.cboSucursal.SelectedValue = supervisor.Sucursal == null ? "" : supervisor.Sucursal;
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
            if (nuevoSupervisor) if (!await ModeloCajeroEsValido()) return;


            if (MessageBox.Show("¿ Estas seguro Guardar los datos del Supervisor ?", "Sistema COVENTAF", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                 {
                    var responseModel = new ResponseModel();

                    supervisor.Supervisor = nuevoSupervisor ? this.txtSupervisor.Text : supervisor.Supervisor;
                    supervisor.SuperUsuario = this.chkSuperUsuario.Checked ? "S" : "N";
                    supervisor.Sucursal = this.cboSucursal.SelectedValue.ToString();
                    supervisor.RecordDate = nuevoSupervisor ? DateTime.Now : supervisor.RecordDate;
                    supervisor.CreateDate = nuevoSupervisor ? DateTime.Now : supervisor.CreateDate;

                    responseModel = await serviceSupervisor.GuardarDatosSupervisor(supervisor, responseModel, nuevoSupervisor);
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
                responseModel = await serviceSupervisor.ObtenerDatosSupervisorId(this.txtSupervisor.Text, responseModel);
                if (responseModel.Exito == 1)
                {
                    result = true;
                    MessageBox.Show("El Supervisor ya existe en la base de dato");
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
