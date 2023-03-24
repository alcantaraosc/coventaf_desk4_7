using Api.Model.Modelos;
using Api.Model.ViewModels;
using Api.Service.DataService;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COVENTAF.Security
{
    public partial class frmListaUsuario : Form
    {
        private ServiceUsuario _serviceUsuario = new ServiceUsuario();
   
        public frmListaUsuario()
        {
            InitializeComponent();
        }

        private  void frmListaUsuario_Load(object sender, System.EventArgs e)
        {
            //seleccionar el primero de la lista
            this.cboTipoConsulta.SelectedIndex = 0;
            //listar todos los usuarios
             ListarUsuariosAsync();
        }



        public async void ListarUsuariosAsync()
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
          
        }

        private async void dgvListaUsuarios_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (MessageBox.Show("¿Estas seguro de Editar los datos del Usuario ?", "Sistema COVENTAF", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                //obtener el login del usuario.
                int Index = dgvListaUsuarios.CurrentRow.Index;
                string usuario = dgvListaUsuarios.Rows[Index].Cells[0].Value.ToString();

                var model = new ViewModelSecurity();
                model.Usuarios = new Usuarios();
                model.RolesUsuarios = new List<RolesUsuarios>();

                ResponseModel responseModel = new ResponseModel();
                responseModel.Data = model;





                try
                {
                    //obtener la consulta por Id del tipo de usuario
                    responseModel = await _serviceUsuario.ObtenerUsuarioPorIdAsync(usuario, responseModel);
                }
                catch (Exception ex)
                {

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
