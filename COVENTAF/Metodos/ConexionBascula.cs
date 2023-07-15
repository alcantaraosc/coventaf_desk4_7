using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace COVENTAF.Metodos
{
    public delegate void DelegadoAcceso(string accion);
    public class ConexionBascula
    {
        SerialPort puertoSerialScanner;
                

        public static Parity GetParity(string parity)
        {
            Parity _parity;

            switch (parity)
            {
                case "None":
                    _parity = Parity.None;
                    break;

                case "Odd":
                    _parity = Parity.Odd;
                    break;

                case "Even":
                    _parity = Parity.Even;
                    break;
                case "Mark":
                    _parity = Parity.Mark;
                    break;

                case "Space":
                    _parity = Parity.Space;
                    break;

                //por defecto es None
                default:
                    _parity = Parity.None;
                    break;
            }

            return _parity;
        }

        public static StopBits GetStopBits(string stopBits)
        {
            StopBits _stopBits;

            switch (stopBits)
            {
                case "None":
                    _stopBits = StopBits.None;
                    break;

                case "One":
                    _stopBits = StopBits.One;
                    break;

                case "OnePointFive":
                    _stopBits = StopBits.OnePointFive;
                    break;

                case "Two":
                    _stopBits = StopBits.Two;
                    break;

                //por defecto One
                default:
                    _stopBits = StopBits.One;
                    break;
            }

            return _stopBits;
        }

        public void ComunicacionScanner( string puerto, int speedBaud, string datosParity, int bitsScanner, string datosStopBits)
        {
            Parity parity = GetParity(datosParity);
            StopBits _stopBits = GetStopBits(datosStopBits);

            try
            {
                //probar si el scanner tiene abierto la conexion   cierre la conexion
                // if (puertoSerialScanner.IsOpen) puertoSerialScanner.Close();

                puertoSerialScanner = new SerialPort(puerto, speedBaud, parity, bitsScanner, _stopBits);

                puertoSerialScanner.Handshake = Handshake.None;
                puertoSerialScanner.DataReceived += new SerialDataReceivedEventHandler(sp_DataReceivedScanner);
                puertoSerialScanner.ReadTimeout = 500;
                puertoSerialScanner.WriteTimeout = 500;
                //abrir el puerto.
                puertoSerialScanner.Open();
                puertoSerialScanner.Write("");               
            }
            catch (Exception ex)
            {
                throw new Exception (ex.Message);
            }
        }


        void sp_DataReceivedScanner(object sender, SerialDataReceivedEventArgs e)
        {

            Thread.Sleep(500);
            string data = puertoSerialScanner.ReadExisting();

            
            //BeginInvoke(new DelegadoAcceso(si_DataReceivedScanner), new object[] { data });

        }

        //private void si_DataReceivedScanner(string accion)
        //{
        //    this.txtScanner.Text = accion;

        //    //probar si el scanner tiene abierto la conexion   cierre la conexion
        //    if (puertoSerialScanner.IsOpen) puertoSerialScanner.Close();

        //    btnProbarScanner_Click(null, null);
        //}


    }
}
