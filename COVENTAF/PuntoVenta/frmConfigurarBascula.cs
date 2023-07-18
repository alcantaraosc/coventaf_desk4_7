using Api.Setting;
using COVENTAF.Metodos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COVENTAF.PuntoVenta
{
    public partial class frmConfigurarBascula : Form
    {
        private SerialPort puertoSerialScanner;
        private SerialPort puertoSerialBascula;

        private delegate void DelegadoAcceso(string accion);


        #region codigo para mover pantalla
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        #endregion

        public frmConfigurarBascula()
        {
            InitializeComponent();
        }

        private void barraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }


        private void frmConfigurarBascula_Load(object sender, EventArgs e)
        {
            btnBuscarPuertoScanner_Click(null, null);
            btnBuscarPuertoBascula_Click(null, null);

            if (Properties.Settings.Default.UsaConfigPuerto)
            {
                this.chkAplicarConfiguaracion.Checked = Properties.Settings.Default.UsaConfigPuerto;

                //scanner
                this.cboPuertoScanner.Text = Properties.Settings.Default.PuertoScanner;
                this.txtSpeedScanner.Text = Properties.Settings.Default.SpeedScanner;
                this.cboParityScanner.Text = Properties.Settings.Default.ParitySacanner;
                this.txtDataBitsScanner.Text = Properties.Settings.Default.DataBitsScanner;
                this.cboStopBitsScanner.Text = Properties.Settings.Default.StopBitScanner;
                //Bascula
                this.cboPuertoBascula.Text = Properties.Settings.Default.PuertoBascula;
                this.txtSpeedBascula.Text = Properties.Settings.Default.SpeedBascula;
                this.cboParityBascula.Text = Properties.Settings.Default.ParityBascula;
                this.txtDataBitsBascula.Text = Properties.Settings.Default.DataBitsBascula;
                this.cboStopBitsBascula.Text = Properties.Settings.Default.StopBitBascula;
            }
            else
            {
                this.cboParityScanner.SelectedIndex = 0;
                this.cboParityBascula.SelectedIndex = 2;

                this.cboStopBitsScanner.SelectedIndex = 1;
                this.cboStopBitsBascula.SelectedIndex = 1;
            }

        }


        //boton evento scanner
        private void btnBuscarPuertoScanner_Click(object sender, EventArgs e)
        {
            try
            {
                //limpiar el combo
                this.cboPuertoScanner.Items.Clear();
                //listar los puerto de la pc
                var listPuertoPC = Utilidades.ListarPuertoPC();
                //asinar al combo los puertos.
                foreach (string puerto in listPuertoPC)
                {
                    this.cboPuertoScanner.Items.Add(puerto);
                }

                if (this.cboPuertoScanner.Items.Count > 0)
                {
                    this.cboPuertoScanner.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Sistema COVENTAF");
            }
        }



        private void btnBuscarPuertoBascula_Click(object sender, EventArgs e)
        {
            try
            {
                //limpiar el combo
                this.cboPuertoBascula.Items.Clear();

                //listar los puerto de la pc
                var listPuertoPC = Utilidades.ListarPuertoPC();
                //asinar al combo los puertos.
                foreach (string puerto in listPuertoPC)
                {
                    this.cboPuertoBascula.Items.Add(puerto);
                }

                if (this.cboPuertoBascula.Items.Count > 0)
                {
                    this.cboPuertoBascula.SelectedIndex = 0;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Sistema COVENTAF");
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {          
            this.Close();
        }

        /********************************* codigo del scanner *******************************************************/
        private void btnProbarScanner_Click(object sender, EventArgs e)
        {
            Parity parity = Utilidades.GetParity(this.cboParityScanner.Text);
            StopBits _stopBits = Utilidades.GetStopBits(this.cboStopBitsScanner.Text);

            try
            {
                //probar si el scanner tiene abierto la conexion   cierre la conexion
                if (puertoSerialScanner != null) if (puertoSerialScanner.IsOpen) puertoSerialScanner.Close();

                puertoSerialScanner = new SerialPort(this.cboPuertoScanner.Text, Convert.ToInt32(this.txtSpeedScanner.Text), parity, Convert.ToInt32(this.txtDataBitsScanner.Text), _stopBits);
                puertoSerialScanner.Handshake = Handshake.XOnXOff;
                puertoSerialScanner.DataReceived += new SerialDataReceivedEventHandler(sp_DataReceivedScanner);
                puertoSerialScanner.ReadTimeout = 500;
                puertoSerialScanner.WriteTimeout = 500;
                //abrir el puerto.
                puertoSerialScanner.Open();
                puertoSerialScanner.Write("W");
                this.txtScanner.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void sp_DataReceivedScanner(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                if (this.Enabled == true)
                {
                    Thread.Sleep(500);
                    string data = puertoSerialScanner.ReadExisting();
                    this.BeginInvoke(new DelegadoAcceso(si_DataReceivedScanner), new object[] { data });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Sistema COVENTAF");
            }

        }

        private void si_DataReceivedScanner(string accion)
        {
            this.txtScanner.Text = accion;

            //probar si el scanner tiene abierto la conexion   cierre la conexion
            if (puertoSerialScanner.IsOpen) puertoSerialScanner.Close();

            btnProbarScanner_Click(null, null);
        }
        /***********************************fin del scanner *************************************************************/



        /********************************* codigo de la bascula *******************************************************/
        private void btnProbarBascula_Click(object sender, EventArgs e)
        {
            Parity parity = Utilidades.GetParity(this.cboParityBascula.Text);
            StopBits _stopBits = Utilidades.GetStopBits(this.cboStopBitsBascula.Text);

            try
            {
                //probar si el scanner tiene abierto la conexion   cierre la conexion
                if (puertoSerialBascula != null) if (puertoSerialBascula.IsOpen) puertoSerialBascula.Close();

                puertoSerialBascula = new SerialPort(this.cboPuertoBascula.Text, Convert.ToInt32(this.txtSpeedBascula.Text), parity, Convert.ToInt32(this.txtDataBitsBascula.Text), _stopBits);
                //puertoSerialBascula.Handshake = Handshake.None;
                puertoSerialBascula.Handshake = Handshake.XOnXOff;
                puertoSerialBascula.DataReceived += new SerialDataReceivedEventHandler(sp_DataReceivedBascula);
                puertoSerialBascula.ReadTimeout = 500;
                puertoSerialBascula.WriteTimeout = 500;
                //abrir el puerto.
                puertoSerialBascula.Open();
                puertoSerialBascula.Write("W");
             
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void sp_DataReceivedBascula(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                if (this.Enabled == true)
                {
                    Thread.Sleep(500);
                    string data = puertoSerialBascula.ReadExisting();
                    this.BeginInvoke(new DelegadoAcceso(si_DataReceivedBascula), new object[] { data });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Sistema COVENTAF");
            }
        }


        private void si_DataReceivedBascula(string accion)
        {
            this.txtBascula.Text = accion;

            //probar si el scanner tiene abierto la conexion   cierre la conexion
            if (puertoSerialBascula.IsOpen) puertoSerialBascula.Close();

            //btnProbarBascula_Click(null, null);
        }

        private void btnGuardarConfiguracion_Click(object sender, EventArgs e)
        {
            try
            {
                Properties.Settings.Default.UsaConfigPuerto = this.chkAplicarConfiguaracion.Checked;
                //scanner
                Properties.Settings.Default.PuertoScanner = this.cboPuertoScanner.Text;
                Properties.Settings.Default.SpeedScanner = this.txtSpeedScanner.Text;
                Properties.Settings.Default.ParitySacanner = this.cboParityScanner.Text;
                Properties.Settings.Default.DataBitsScanner = this.txtDataBitsScanner.Text;
                Properties.Settings.Default.StopBitScanner = this.cboStopBitsScanner.Text;
                //Bascula
                Properties.Settings.Default.PuertoBascula = this.cboPuertoBascula.Text;
                Properties.Settings.Default.SpeedBascula = this.txtSpeedBascula.Text;
                Properties.Settings.Default.ParityBascula = this.cboParityBascula.Text;
                Properties.Settings.Default.DataBitsBascula = this.txtDataBitsBascula.Text;
                Properties.Settings.Default.StopBitBascula = this.cboStopBitsBascula.Text;
                //guardar la configuracion
                Properties.Settings.Default.Save();

                MessageBox.Show("La configuracion se ha guardado correctamente", "Sistema COVENTAF");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Sistema COVENTAF");
            }
        }

        private void chkAplicarConfiguaracion_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkAplicarConfiguaracion.Checked)
            {
                this.grpConfiguaracion.Enabled = true;
                //scanner
                this.cboPuertoScanner.Text = Properties.Settings.Default.PuertoScanner;
                this.txtSpeedScanner.Text = Properties.Settings.Default.SpeedScanner;
                this.cboParityScanner.Text = Properties.Settings.Default.ParitySacanner;
                this.txtDataBitsScanner.Text = Properties.Settings.Default.DataBitsScanner;
                this.cboStopBitsScanner.Text = Properties.Settings.Default.StopBitScanner;
                //Bascula
                this.cboPuertoBascula.Text = Properties.Settings.Default.PuertoBascula;
                this.txtSpeedBascula.Text = Properties.Settings.Default.SpeedBascula;
                this.cboParityBascula.Text = Properties.Settings.Default.ParityBascula;
                this.txtDataBitsBascula.Text = Properties.Settings.Default.DataBitsBascula;
                this.cboStopBitsBascula.Text = Properties.Settings.Default.StopBitBascula;
            }
            else
            {
                this.grpConfiguaracion.Enabled = false;
            }
        }


        /********************************* fin de la bascula *******************************************************/


        private void CerrarConexionScanner()
        {
            if (Properties.Settings.Default.UsaConfigPuerto) if (puertoSerialScanner != null) if (puertoSerialScanner.IsOpen) puertoSerialScanner.Close();
        }

        private void CerrarConexionBascula()
        {
            if (Properties.Settings.Default.UsaConfigPuerto) if (puertoSerialBascula != null) if (puertoSerialBascula.IsOpen) puertoSerialBascula.Close();
        }

        public void IDispose()
        {
            CerrarConexionScanner();
            CerrarConexionBascula();
        }
    }
}
