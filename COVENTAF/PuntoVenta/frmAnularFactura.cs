using Api.Model.Modelos;
using Api.Model.View;
using Api.Model.ViewModels;
using Api.Service.DataService;
using COVENTAF.Metodos;
using COVENTAF.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace COVENTAF.PuntoVenta
{
    public partial class frmAnularFactura : Form
    {
        public string factura = "";
        public string tipoDocumento = "";
        public bool _supervisor;

        private List<Facturas> _listaFactura;
        
        // private int IndexGrid =0;
        private string facturaAnular;
        private string estadoCajero;
        private string estadoCaja;

        #region codigo para mover pantalla
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        #endregion
        public frmAnularFactura()
        {
            InitializeComponent();
            //this._frmAnularFactura = anularFactura;
        }

        private void barraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnCierre_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       

        private async void btnBuscarFactura_Click(object sender, EventArgs e)
        {
            
        }


        //public void AsignarDatosFactura(string factura)
        //{
        //    ViewFactura datosFactura = _ListFactura.Where(vf => vf.Factura == factura).FirstOrDefault();

        //    //comprobar si el estado de caja esta abierta y estado del cajero es abierta
        //    if (datosFactura.Estado_Caja == "A" && datosFactura.Estado_Cajero == "A")
        //    {
        //        //_frmAnularFactura.CargarDatosFactura(datosFactura);
        //        this.Close();
        //    }
        //    else
        //    {
        //        MessageBox.Show("No se puede Anular, ya que la caja esta cerrado", "Sistema COVENTAF");
        //    }
        //}

        private void dgdata_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
        }


        private void dgvConsultaFacturas_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int rowGrid = dgvConsultaFacturas.CurrentRow.Index;

            if (rowGrid >= 0)
            {
               
                facturaAnular = dgvConsultaFacturas.Rows[rowGrid].Cells["FACTURA"].Value.ToString();
                estadoCajero = dgvConsultaFacturas.Rows[rowGrid].Cells["Estado_Cajero"].Value.ToString();
                estadoCaja = dgvConsultaFacturas.Rows[rowGrid].Cells["Estado_Caja"].Value.ToString();
            }
        }

        private async void btnAnularFactura_Click(object sender, EventArgs e)
        {
           
        }
     
        private void btnCerraVentana_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void btnAnular_Click(object sender, EventArgs e)
        {
            ResponseModel responseModel = new ResponseModel();

            try
            {
                responseModel = await new ServiceDevolucion().ModeloEsCorrecto(factura, responseModel);
                if (responseModel.Exito ==1)
                {
                    if (MessageBox.Show($"¿ Estas seguro de Anular la factura {facturaAnular}", "Sistema COVENTAF", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        //si la autorizacion no tuvo exitos entonces no continua
                        if (!UtilidadesMain.AutorizacionExitosa()) return;

                        this.Cursor = Cursors.WaitCursor;

                        responseModel = await new ServiceFactura().AnularFacturaAsync(responseModel, facturaAnular, User.Usuario, User.ConsecCierreCT);
                        if (responseModel.Exito == 1)
                        {
                            MessageBox.Show(responseModel.Mensaje, "Sistema COVENTAF");

                            this.dgvConsultaFacturas.DataSource = null;
                        }
                        else
                        {
                            MessageBox.Show(responseModel.Mensaje, "Sistema COVENTAF");
                        }
                        this.Cursor = Cursors.Default;
                    }
                }
                else
                {
                    MessageBox.Show(responseModel.Mensaje, "Sistema COVENTAF");
                }
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show($"Error: Anular Factura {ex.Message}", "Sistema COVENTAF");
            }
        }

        private async void frmAnularFactura_Load(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            this.dgvConsultaFacturas.Cursor = Cursors.WaitCursor;

            ResponseModel responseModel = new ResponseModel();
            _listaFactura = new List<Facturas>();
            try
            {
                //buscar facturas
                responseModel = await new ServiceDevolucion().BuscarFacturaBaseDatos(factura, tipoDocumento, responseModel);

                if (responseModel.Exito == 1)
                {                                     
                     _listaFactura = responseModel.Data as List<Facturas>;
                   // this.dgvConsultaFacturas.DataSource = _listaFactura;
                   foreach(var item in _listaFactura)
                    {
                        this.dgvConsultaFacturas.Rows.Add(item.Factura, item.Tipo_Documento, item.Cliente, item.Nombre_Cliente, item.Total_Factura.ToString("N2"), 
                            item.Caja, item.Usuario, item.Num_Cierre, item.Fecha.ToString("dd/MM/yyyy"), item.Tienda_Enviado);
                    }
                }
                else
                {
                    this.dgvConsultaFacturas.DataSource = _listaFactura;
                    MessageBox.Show(responseModel.Mensaje, "Sistema COVENTAF");
                }

            }
            catch (Exception ex)
            {                
                MessageBox.Show(ex.Message, "Sistema COVENTAF");
            }
            finally
            {
                this.dgvConsultaFacturas.Cursor = Cursors.Default;
                this.Cursor = Cursors.Default;
            }
        }
    }
}
