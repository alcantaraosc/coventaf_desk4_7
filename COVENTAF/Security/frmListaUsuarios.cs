using Api.Model.Modelos;
using Api.Model.ViewModels;
using Api.Service.DataService;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COVENTAF.Security
{
    public partial class frmListaUsuarios : Form
    {
        private ServiceUsuario _serviceUsuario = new ServiceUsuario();
   
        public frmListaUsuarios()
        {
            InitializeComponent();
        }

        protected virtual async void frmListaUsuario_Load(object sender, System.EventArgs e)
        {
            //seleccionar el primero de la lista           
            this.cboCatalogo.SelectedIndex = 0;
            this.cboTipoConsulta.SelectedIndex = 0;
            //listar todos los usuarios
            await ListarUsuariosAsync();
        }



        public async Task<bool>  ListarUsuariosAsync()
        {
            var responseModel = new ResponseModel(); ;
            responseModel.Data = new List<Usuarios>();

            try
            {
                responseModel = await _serviceUsuario.ListarUsuarios(responseModel);

                if (responseModel.Exito ==1)
                {
                    this.dgvListaUsuarios.DataSource = null;
                    this.dgvListaUsuarios.DataSource = responseModel.Data as List<Usuarios>;
                }
               
            }

            catch (Exception ex)
            {
                responseModel.Exito = -1;
                responseModel.Mensaje = ex.Message;
            }

            return true;
          
        }

        public async void dgvListaUsuarios_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (MessageBox.Show($"¿Estas seguro de Editar los datos del {this.cboCatalogo.Text}", "Sistema COVENTAF", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                //obtener el login del usuario.
                int Index = dgvListaUsuarios.CurrentRow.Index;
                string usuario = dgvListaUsuarios.Rows[Index].Cells[0].Value.ToString();

                switch(this.cboCatalogo.Text)
                {
                    case "Usuario":
                        CatalogoUsuario(usuario);
                        break;

                    case "Cajero":
                        CatalogoCajero(usuario);
                        break;

                    case "Supervisor":
                        CatalogoSupervisor(usuario);
                        break;
                }





            

                ////si la respuesta del servidor es 1 es exito
                //if (responseModel.Exito == 1)
                //{
                //    model = responseModel.Data as ViewModelSecurity;

                //    using (frmUsuario frmUser = new frmUsuario())
                //    {
                //        model.Usuarios.NuevoUsuario = false;
                //        frmUser.model = model;
                //        frmUser.Text = "Editar datos del Usuario";
                //        frmUser.ShowDialog();
                //        LlenarListarUsuariosGrid();
                //    }

                //}
                //else
                //{
                //    MessageBox.Show(responseModel.Mensaje, "Sistema COVENTAF", MessageBoxButtons.OK);
                //}

            }
        }

        public async void CatalogoUsuario(string usuario)
        {

            var model = new ViewModelSecurity();
            model.Usuarios = new Usuarios();
            model.RolesUsuarios = new List<RolesUsuarios>();

            ResponseModel responseModel = new ResponseModel();
            responseModel.Data = model;

            try
            {
                //obtener la consulta por Id del tipo de usuario
                responseModel = await _serviceUsuario.ObtenerUsuarioPorIdAsync(usuario, responseModel);
                //si la respuesta del servidor es 1 es exito
                if (responseModel.Exito == 1)
                {
                    model = responseModel.Data as ViewModelSecurity;

                    using (frmUsuario frmUser = new frmUsuario())
                    {
                        model.Usuarios.NuevoUsuario = false;
                        frmUser.model = model;
                        frmUser.Text = "Editar datos del Usuario";
                        frmUser.ShowDialog();
                    }

                }
                else
                {
                    MessageBox.Show(responseModel.Mensaje, "Sistema COVENTAF", MessageBoxButtons.OK);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Sistema COVENTAF");
            }
        }

        public void CatalogoCajero(string cajero, bool nuevoCajero=false)
        {
            using (var frmCajero = new frmCajero())
            {                              
                frmCajero.nuevoCajero = nuevoCajero;
                frmCajero.txtCajero.Text = cajero;
                frmCajero.ShowDialog();
            }
        }

        private void CatalogoSupervisor(string supervisor)
        { 
        }


        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            //si el catalogo es usuario y el tipo de consulta es usuario y 
           if (this.cboCatalogo.Text =="Usuario" && this.cboTipoConsulta.Text == "Usuario"  || this.cboTipoConsulta.Text =="Nombre")
            {
                BuscarUsuario();
            }
           else if (this.cboCatalogo.Text =="Cajero" )
            {
                BuscarCajero();
            }
           else if (this.cboCatalogo.Text =="Supervisor")
            {
                BuscarSupervisor();
            }
        }

        private async void BuscarUsuario()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.dgvListaUsuarios.Cursor = Cursors.WaitCursor;

                var responseModel = new ResponseModel();
                responseModel = await _serviceUsuario.ObtenerDatosUsuarioPorFiltroX(this.cboTipoConsulta.Text, this.txtBusqueda.Text, responseModel);
                if (responseModel.Exito == 1)
                {
                    this.dgvListaUsuarios.DataSource = null;
                    this.dgvListaUsuarios.DataSource = responseModel.Data;
                }
                else
                {
                    MessageBox.Show(responseModel.Mensaje, "Sistema COVENTAF");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Sistema COVENTAF");
            }
            finally
            {
                this.Cursor = Cursors.Default;
                this.dgvListaUsuarios.Cursor = Cursors.Default;
            }
        }
        private async void BuscarCajero()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.dgvListaUsuarios.Cursor = Cursors.WaitCursor;

                var responseModel = new ResponseModel();
                responseModel = await _serviceUsuario.ObtenerDatosCajeroPorFiltroX( this.cboTipoConsulta.Text, this.txtBusqueda.Text, responseModel, User.TiendaID);
                if (responseModel.Exito == 1)
                {
                    this.dgvListaUsuarios.DataSource = null;
                    this.dgvListaUsuarios.DataSource = responseModel.Data;
                }
                else
                {
                    MessageBox.Show(responseModel.Mensaje, "Sistema COVENTAF");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Sistema COVENTAF");
            }
            finally
            {
                this.Cursor = Cursors.Default;
                this.dgvListaUsuarios.Cursor = Cursors.Default;
            }
        }

        private async void BuscarSupervisor()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.dgvListaUsuarios.Cursor = Cursors.WaitCursor;

                var responseModel = new ResponseModel();
                responseModel = await _serviceUsuario.ObtenerDatosSupervisorPorFiltroX(this.cboTipoConsulta.Text, this.txtBusqueda.Text, responseModel);
                if (responseModel.Exito == 1)
                {
                    this.dgvListaUsuarios.DataSource = null;
                    this.dgvListaUsuarios.DataSource = responseModel.Data;
                }
                else
                {
                    MessageBox.Show(responseModel.Mensaje, "Sistema COVENTAF");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Sistema COVENTAF");
            }
            finally
            {
                this.Cursor = Cursors.Default;
                this.dgvListaUsuarios.Cursor = Cursors.Default;
            }
        }



        private void txtBusqueda_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar ==13)
            {
                btnBuscar_Click(null, null);
            }
        }

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
       {
            if (e.KeyChar == 13)
            {
                btnBuscar_Click(null, null);
            }
        }

        private void btnNuevoUsuario_Click(object sender, EventArgs e)
        {

            var model = new ViewModelSecurity();
            model.Usuarios = new Usuarios();
            model.RolesUsuarios = new List<RolesUsuarios>();

            using (frmUsuario frmUser = new frmUsuario())
            {
                model.Usuarios.NuevoUsuario = true;
                frmUser.model = model;
                frmUser.Text = "Nuevo Usuario";
                frmUser.ShowDialog();                
            }
        }

   

        private async void cboCatalogo_SelectedIndexChanged(object sender, EventArgs e)
        {
            //limpiar los item s
            cboTipoConsulta.Items.Clear();

            switch (this.cboCatalogo.Text)
            {
                case "Usuario":                   
                    this.cboTipoConsulta.Items.AddRange(new object[] { "Nombre", "Usuario" });
                    cboTipoConsulta.SelectedIndex = 0;
                    await ListarUsuariosAsync();
                    break;

                case "Cajero":
                    this.cboTipoConsulta.Items.AddRange(new object[] {"Cajero"});
                    cboTipoConsulta.SelectedIndex = 0;
                    BuscarCajero();
                    break;

                case "Supervisor":
                    this.cboTipoConsulta.Items.AddRange(new object[] { "Supervisor" });
                    cboTipoConsulta.SelectedIndex = 0;
                    BuscarSupervisor();
                    break;
            }
        }

        private void cboCatalogo_Click(object sender, EventArgs e)
        {

        }

        //public async Task<ResponseModel> ObtenerUsuarioPorIdAsync(string usuarioID)
        //{
        //    var responseModel = respuestModel();
        //    responseModel.Data = new ViewModelSecurity();

        //    //obtener la consulta por Id del usuario
        //    try
        //    {
        //        //obtener la consulta por Id del tipo de usuario
        //        responseModel.Data = await _serviceUsuario.ObtenerUsuarioPorIdAsync(usuarioID, responseModel);
        //    }
        //    catch (Exception ex)
        //    {
        //        responseModel.Exito = -1;
        //        responseModel.Mensaje = ex.Message;
        //    }

        //    return responseModel;
        //}
    }
}
