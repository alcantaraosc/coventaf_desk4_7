using Api.Model.Modelos;
using Api.Model.View;
using Api.Model.ViewModels;
using Api.Service.DataService;
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

namespace COVENTAF.PuntoVenta
{
    public partial class frmAnularFactura : Form
    {
        private ServiceFactura _serviceFactura = new ServiceFactura();
        //private frmAnularFacturaPrueba _frmAnularFactura;
        private List<ViewFactura> _ListFactura = new List<ViewFactura>();
        private int IndexGrid =0;
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


        private bool FiltrosValido()
        {
            bool valido = false;

            if (dtFechaDesde.Value.Date > dtFechaHasta.Value.Date)
            {
                MessageBox.Show("La Fecha desde tiene que ser menor que la fecha hasta", "Sistema COVENTAF");
            }
            else
            {
                valido = true;
            }

            return valido;
        }


        private async void btnBuscarFactura_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            if (FiltrosValido())
            {
                this.btnAnularFactura.Enabled = false;
                var filtroFactura = new FiltroFactura();
                ResponseModel responseModel = new ResponseModel();                          
                try
                {
                    filtroFactura.FechaInicio = Convert.ToDateTime(this.dtFechaDesde.Value.Date);
                    filtroFactura.FechaFinal = Convert.ToDateTime(this.dtFechaHasta.Value.Date);
                    filtroFactura.Caja = this.txtCaja.Text.Length == 0 ? "" : this.txtCaja.Text;
                    filtroFactura.FacturaDesde = this.txtFacturaDesde.Text.Length == 0 ? "" : this.txtFacturaDesde.Text;
                    filtroFactura.FacturaHasta = this.txtFacturaHasta.Text.Length == 0 ? "" : this.txtFacturaHasta.Text;
                    filtroFactura.Tipofiltro = ObtenerTipoFiltro(filtroFactura);
                    responseModel = await _serviceFactura.BuscarFactura(filtroFactura, responseModel);
                    
                    if (responseModel.Exito == 1)
                    {
                        _ListFactura = responseModel.Data as List<ViewFactura>;
                        this.dgvConsultaFacturas.DataSource = responseModel.Data;                       
                    }
                    else
                    {
                        this.dgvConsultaFacturas.DataSource = responseModel.Data;
                       
                        MessageBox.Show(responseModel.Mensaje, "Sistema COVENTAF");
                    }
                   
                }
                catch (Exception ex)
                {
                    this.Cursor = Cursors.Default;
                    MessageBox.Show(ex.Message, "Sistema COVENTAF");
                }
            }
            this.Cursor = Cursors.Default;
        }

        private string ObtenerTipoFiltro(FiltroFactura filtroFactura)
        {
            var tipoFiltro = "Fecha";
            if (filtroFactura.Caja.Length >0)
            {
                tipoFiltro += "_Caja";
            }

            if (filtroFactura.FacturaDesde.Length > 0 && filtroFactura.FacturaHasta.Length >0)
            {
                tipoFiltro += "_Factura";
            }
            return tipoFiltro;
        }

        private void dgvConsultaFacturas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (dgvConsultaFacturas.Columns[e.ColumnIndex].Name == "btnSeleccionar")
            //{
            //obtener el indiciee
             IndexGrid = e.RowIndex;
            //if (index >= 0)
            //{
            //    string valor = dgvConsultaFacturas.Rows[index].Cells["Factura"].Value.ToString();
            //    this.AsignarDatosFactura(dgvConsultaFacturas.Rows[index].Cells["FACTURA"].Value.ToString());


            //    //txtindex.Text = (index + 1).ToString();
            //    //txtid.Text = dgdata.Rows[index].Cells["Id"].Value.ToString();
            //    //txtdocumento.Text = dgdata.Rows[index].Cells["NumeroDocumento"].Value.ToString();
            //    //txtrazonsocial.Text = dgdata.Rows[index].Cells["RazonSocial"].Value.ToString();
            //    //txtcorreo.Text = dgdata.Rows[index].Cells["Correo"].Value.ToString();
            //    //txttelefono.Text = dgdata.Rows[index].Cells["Telefono"].Value.ToString();
            //}

            //}
        }

        public void AsignarDatosFactura(string factura)
        {
            ViewFactura datosFactura = _ListFactura.Where(vf => vf.Factura == factura).FirstOrDefault();

            //comprobar si el estado de caja esta abierta y estado del cajero es abierta
            if (datosFactura.Estado_Caja=="A" && datosFactura.Estado_Cajero == "A")
            {
                //_frmAnularFactura.CargarDatosFactura(datosFactura);
                this.Close();
            }
            else
            {
                MessageBox.Show("No se puede Anular, ya que la caja esta cerrado", "Sistema COVENTAF");
            }          
        }

        private void dgdata_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
        }

        private void dgvConsultaFacturas_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (e.ColumnIndex == 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                var w = Properties.Resources.check20.Width;
                var h = Properties.Resources.check20.Height;
                var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
                var y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2;

                e.Graphics.DrawImage(Properties.Resources.check20, new Rectangle(x, y, w, h));
                e.Handled = true;
            }
        }

        private void dgvConsultaFacturas_MouseDoubleClick(object sender, MouseEventArgs e)
        {
           
            if (IndexGrid >= 0)
            {
                this.btnAnularFactura.Enabled = true;
                facturaAnular = dgvConsultaFacturas.Rows[IndexGrid].Cells["FACTURA"].Value.ToString();
                estadoCajero = dgvConsultaFacturas.Rows[IndexGrid].Cells["Estado_Cajero"].Value.ToString();
                estadoCaja = dgvConsultaFacturas.Rows[IndexGrid].Cells["Estado_Caja"].Value.ToString();

                //asignar los datos                
                //this.AsignarDatosFactura(dgvConsultaFacturas.Rows[IndexGrid].Cells["FACTURA"].Value.ToString());

                //txtindex.Text = (index + 1).ToString();
                //txtid.Text = dgdata.Rows[index].Cells["Id"].Value.ToString();
                //txtdocumento.Text = dgdata.Rows[index].Cells["NumeroDocumento"].Value.ToString();
                //txtrazonsocial.Text = dgdata.Rows[index].Cells["RazonSocial"].Value.ToString();
                //txtcorreo.Text = dgdata.Rows[index].Cells["Correo"].Value.ToString();
                //txttelefono.Text = dgdata.Rows[index].Cells["Telefono"].Value.ToString();
            }
        }

        private async void btnAnularFactura_Click(object sender, EventArgs e)
        {
            ResponseModel responseModel = new ResponseModel();           

            try
            {
                if (estadoCajero =="A" && estadoCaja =="A")
                {
                    if (MessageBox.Show($"¿ Estas seguro de Anular la factura {facturaAnular}", "Sistema COVENTAF", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        this.Cursor = Cursors.WaitCursor;

                        responseModel = await _serviceFactura.AnularFacturaAsync(responseModel, facturaAnular, User.Usuario, User.ConsecCierreCT);
                        if (responseModel.Exito == 1)
                        {
                            MessageBox.Show(responseModel.Mensaje, "Sistema COVENTAF");
                            this.btnAnularFactura.Enabled = false;
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
                    MessageBox.Show("No se puede anular la factura, la caja para esa factura ya esta cerrado", "Sistema COVENTAF");
                }


            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show($"Error: Anular Factura {ex.Message}", "Sistema COVENTAF");
            }
        }

        private void btnCerraVentana_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
