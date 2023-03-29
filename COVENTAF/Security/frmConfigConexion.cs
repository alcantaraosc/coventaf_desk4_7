using Api.Model.ViewModels;
using Api.Service.DataService;
using Api.Setting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COVENTAF.Security
{
    public partial class frmConfigConexion : Form
    {
        public bool confuguracionExitosa=false;
        private bool conexionOcultaExitosa=false;

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);



        public frmConfigConexion()
        {
            InitializeComponent();
        }

        private void barraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void frmConexion_Load(object sender, EventArgs e)
        {

            this.txtServidor.Text = Properties.Settings.Default.Servidor;
            this.txtBaseDatos.Text = Properties.Settings.Default.BaseDato;
            this.txtUsuario.Text = Properties.Settings.Default.Usuario;
            this.txtPassword.Text = Properties.Settings.Default.Password;


            ProbarConexion_Oculto();

            this.txtUser.SelectionStart = 0;
            this.txtUser.SelectionLength = this.txtUser.Text.Length;
            this.txtUser.Focus();
            
            
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Servidor = this.txtServidor.Text;
            Properties.Settings.Default.BaseDato = this.txtBaseDatos.Text;
            Properties.Settings.Default.Usuario = this.txtUsuario.Text;
            Properties.Settings.Default.Password = this.txtPassword.Text;
            //guardar la configuracion
            Properties.Settings.Default.Save();
            //indicar que sea guardado la configuracion de los datos de la conexion
            confuguracionExitosa = true;
            MessageBox.Show("Datos de la conexion guardado correctamente", "Sistema COVENTAF");
            ConectionContext.Server = Properties.Settings.Default.Servidor;
            ConectionContext.DataBase = Properties.Settings.Default.BaseDato;
            ConectionContext.User = Properties.Settings.Default.Usuario;
            ConectionContext.Password = Properties.Settings.Default.Password;
            this.Close();
        }

        public string GetConexion()
        {            
            string connectionString = @"Data Source=" + this.txtServidor.Text + ";Initial Catalog=" + txtBaseDatos.Text + "; user id=" + txtUsuario.Text + "; password= " + txtPassword.Text  + "";
            return connectionString;
        }

        private void ProbarConexion_Oculto()
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                SqlConnection connection = new SqlConnection(GetConexion());
                connection.Open();
                if ((connection.State & ConnectionState.Open) > 0)
                {
                   
                    connection.Close();
                    conexionOcultaExitosa = true;
                }
                else
                {
                    conexionOcultaExitosa = false;
                    
                }
            }
            catch
            {                
                conexionOcultaExitosa = false;
            }
            this.Cursor = Cursors.Default;
        }

        private void btnProbarConexion_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                SqlConnection connection = new SqlConnection(GetConexion());
                connection.Open();
                if ((connection.State & ConnectionState.Open) > 0)
                {
                    MessageBox.Show("Conexión OK!", "Sistema COVENTAF");
                    connection.Close();
                    this.btnAceptar.Enabled = true;
                }
                else
                {
                    this.btnAceptar.Enabled = false;
                    MessageBox.Show("Conexión falló", "Sistema COVENTAF");
                }
            }
            catch (Exception ex)
            {
                this.btnAceptar.Enabled = false;
                MessageBox.Show($"Error de Conexión: {ex.Message} ", "Sistema COVENTAF");
            }
            this.Cursor = Cursors.Default;
        }


        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void txtContraseña_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (txtUser.Text == "ADMIN" && txtContraseña.Text == "*Inf2023.+")
                {
                    this.grpDatosConexion.Visible = true;
                    this.groupBox1.Enabled = false;
                }
                //comprobar si hay conexion con la base de datos
                else if (conexionOcultaExitosa)
                {
                    var responseModel = new ResponseModel();
                    responseModel = await new ServiceLogIn().LogearseIn(txtUser.Text, txtContraseña.Text, responseModel);
                    //si respuesta del servidor fue exitosa entonces mostrar el menu principal del sistema
                    if (responseModel.Exito == 1)
                    {
                        this.grpDatosConexion.Visible = true;
                        this.groupBox1.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show(responseModel.Mensaje, "Sistema COVENTAF");
                    }
                }
            }
        }

      
    }
}
    

