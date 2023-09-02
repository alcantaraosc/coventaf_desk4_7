
using Api.Model.Modelos;
using Api.Model.ViewModels;
using Api.Setting;
using COVENTAF.Metodos;
using COVENTAF.ModuloAcceso;
using COVENTAF.ModuloCliente;
using COVENTAF.PuntoVenta;
using COVENTAF.Security;
using COVENTAF.Services;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace COVENTAF
{
    public partial class formMenuPrincipal : Form
    {
        

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        //Constructor
        public formMenuPrincipal()
        {

            InitializeComponent();
            //panel1.BackColor = Color.FromArgb(125, Color.MediumSlateBlue);

            //Estas lineas eliminan los parpadeos del formulario o controles en la interfaz grafica (Pero no en un 100%)
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.DoubleBuffered = true;
      
            this.lblUsuario.Text = User.Usuario;

            MostrarDatosCoenexion();

        }

        private void MostrarDatosCoenexion()
        {
            string version = string.Format("Version: {0}", Application.ProductVersion);
            this.lblInformacion.Text = $"Servidor: { ConectionContext.Server }.  Base de Datos: { ConectionContext.DataBase }. Tienda: {User.NombreTienda}. {version}";
        }


        //RESIZE METODO PARA REDIMENCIONAR/CAMBIAR TAMAÑO A FORMULARIO EN TIEMPO DE EJECUCION ----------------------------------------------------------
        private int tolerance = 12;
        private const int WM_NCHITTEST = 132;
        private const int HTBOTTOMRIGHT = 17;
        private Rectangle sizeGripRectangle;

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_NCHITTEST:
                    base.WndProc(ref m);
                    var hitPoint = this.PointToClient(new Point(m.LParam.ToInt32() & 0xffff, m.LParam.ToInt32() >> 16));
                    if (sizeGripRectangle.Contains(hitPoint))
                        m.Result = new IntPtr(HTBOTTOMRIGHT);
                    break;
                default:
                    base.WndProc(ref m);
                    break;
            }

        }
        //----------------DIBUJAR RECTANGULO / EXCLUIR ESQUINA PANEL 
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            var region = new Region(new Rectangle(0, 0, this.ClientRectangle.Width, this.ClientRectangle.Height));

            sizeGripRectangle = new Rectangle(this.ClientRectangle.Width - tolerance, this.ClientRectangle.Height - tolerance, tolerance, tolerance);

            region.Exclude(sizeGripRectangle);
            this.PanelContenedor.Region = region;
            this.Invalidate();
        }
        //----------------COLOR Y GRIP DE RECTANGULO INFERIOR
        protected override void OnPaint(PaintEventArgs e)
        {
            SolidBrush blueBrush = new SolidBrush(Color.FromArgb(244, 244, 244));
            e.Graphics.FillRectangle(blueBrush, sizeGripRectangle);

            base.OnPaint(e);
            ControlPaint.DrawSizeGrip(e.Graphics, Color.Transparent, sizeGripRectangle);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //Capturar posicion y tamaño antes de maximizar para restaurar
        int lx, ly;
        int sw, sh;


        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            lx = this.Location.X;
            ly = this.Location.Y;
            sw = this.Size.Width;
            sh = this.Size.Height;
            btnMaximizar.Visible = false;
            btnRestaurar.Visible = true;
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            this.Location = Screen.PrimaryScreen.WorkingArea.Location;
        }

        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            btnMaximizar.Visible = true;
            btnRestaurar.Visible = false;
            this.Size = new Size(sw, sh);
            this.Location = new Point(lx, ly);
        }

        private void formMenuPrincipal_Load(object sender, EventArgs e)
        {
          
            btnMaximizar_Click(null, null);


            /*roles disponible para punto de Venta*/
            var rolesDisponibleParaPostVenta = new List<string>() { "ADMIN", "CAJERO", "SUPERVISOR" };
            this.btnPuntoVenta.Enabled = UtilidadesMain.AccesoPermitido(rolesDisponibleParaPostVenta);

            /*roles disponible para modulo de cliente*/
            var rolesModuloCliente = new List<string>() { "ADMIN", "MOD_CLIENTE"};
            this.btnModuloCliente.Enabled = UtilidadesMain.AccesoPermitido(rolesModuloCliente);

            /*roles disponible para el modulo de Acceso*/
            var rolesModuloAcceso = new List<string>() { "ADMIN", "ACCESO" };
            this.btnModuloAcceso.Enabled = UtilidadesMain.AccesoPermitido(rolesModuloAcceso);

            /*roles disponible para seguridad*/
            var rolesDisponibleParaSeguridad = new List<string>() { "ADMIN" };
            this.btnSeguridad.Enabled = UtilidadesMain.AccesoPermitido(rolesDisponibleParaSeguridad);

            //entonces para abrir la ventana de punto de venta el sistema verifica si eres supervisor o cajero
            var  rolesDisponiblePntoVenta = new List<string>() { "CAJERO", "SUPERVISOR" };

            var listaAccesoParaTituloSistema = new List<string>() { "ADMIN", "CLIENTE" };
            var tituloPrincipalSistema = UtilidadesMain.AccesoPermitido(listaAccesoParaTituloSistema);

            if (tituloPrincipalSistema)
            {
                //titulo generla
                this.lblTituloSistema.Text = $"EJERCITO DE NICARAGUA - TIENDAS Y SUPERMERCADOS ({User.NombreTienda})"; 
            }
            else
            {
                this.lblTituloSistema.Text = $"EJERCITO DE NICARAGUA - {User.NombreTienda}";
            }


            //revisar si eres cajero o supervisor entonces se abre automaticamente el punto de venta
            if (UtilidadesMain.AccesoPermitido(rolesDisponiblePntoVenta))
            {
                //Thread.Sleep(1000);
                btnPuntoVenta_Click(null, null);
            }
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnSeguridad_Click(object sender, EventArgs e)
        {
            AbrirFormulario<frmListaUsuarios>();
        }

        private void btnPuntoVenta_Click(object sender, EventArgs e)
        {

            this.panelMenu.Visible = false;

            //_rolesDelSistema, _user
            AbrirFormulario<frmPuntoVenta>();
            //AbrirFormulario<FrmVentas>();            
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            this.panelMenu.Visible = !this.panelMenu.Visible;
        }

        private void panelBarraTitulo_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void lblInformacion_Click(object sender, EventArgs e)
        {
            //var frmConfigConexion = new frmConfigConexion();
            //frmConfigConexion.ShowDialog();
            //if (frmConfigConexion.confuguracionExitosa)
            //{
            //    MostrarDatosCoenexion();                
            //}
            //frmConfigConexion.Dispose();
        }


        private void btnModuloCliente_Click(object sender, EventArgs e)
        {
            this.panelMenu.Visible = false;          
            AbrirFormulario<frmModuloCliente>();
        }

        private void btnModuloAcceso_Click(object sender, EventArgs e)
        {
            this.panelMenu.Visible = false;
            
            AbrirFormulario<frmModuloAcceso>();
        }


        private void panelBarraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void AbrirFormulario<MiForm>() where MiForm : Form, new()
        {
            Form formulario;
            formulario = panelformularios.Controls.OfType<MiForm>().FirstOrDefault();//Busca en la colecion el formulario
                                                                                     //si el formulario/instancia no existe
            if (formulario == null)
            {
                formulario = new MiForm();
                formulario.TopLevel = false;
                formulario.FormBorderStyle = FormBorderStyle.None;
                formulario.Dock = DockStyle.Fill;
                //formulario.LoadDatos();
                panelformularios.Controls.Add(formulario);
                panelformularios.Tag = formulario;
                formulario.Show();
                formulario.BringToFront();
            }
            //si el formulario/instancia existe
            else
            {
                formulario.BringToFront();
            }
        }



    }
}
