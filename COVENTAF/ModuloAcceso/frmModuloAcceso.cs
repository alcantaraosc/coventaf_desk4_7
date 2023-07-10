using Api.Model.Modelos;
using Api.Model.ViewModels;
using Api.Service.DataService;

using GenCode128;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COVENTAF.ModuloAcceso
{
    public partial class frmModuloAcceso : Form
    {

        //https://www.youtube.com/watch?v=kVuWseZJ5Mo
        public int altura = 2;

        private string codigoCliente;
        private string identificacion;
        private string nombreCliente;

        public static System.Drawing.Font printFont;

        private PrintDocument doc = new PrintDocument();
        private PrintPreviewDialog vista = new PrintPreviewDialog();
        // Construct the PrintPreviewControl.
        PrintPreviewControl PrintPreviewControl1 = new PrintPreviewControl();

        public frmModuloAcceso()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            try
            {
               

               

                if (dgvListaCliente.RowCount >0)
                {
                    
                    int index = dgvListaCliente.CurrentRow.Index;
                    codigoCliente = this.dgvListaCliente.Rows[index].Cells["Titular1"].Value.ToString();
                    identificacion = this.dgvListaCliente.Rows[index].Cells["Cedula"].Value.ToString();
                    nombreCliente = this.dgvListaCliente.Rows[index].Cells["Nombre"].Value.ToString();

                    var bitacoraVisita = new Cs_Bitacora_Visita() { Cliente = codigoCliente, Titular = codigoCliente, Usuario_Registro = User.Usuario };

                    if (MessageBox.Show("¿ El Cliente trae acompañante ?", "Sistema COVENTAF", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        using (var frmAcompañante = new frmRegistroAcompañante())
                        {
                            frmAcompañante.bitacoraVisita = bitacoraVisita;
                            frmAcompañante.ShowDialog();
                        }
                    }



                   

                    //Image codigoBarras =  Code128Rendering.MakeBarcodeImage(codigoCliente, altura, true);                   
                    //this.pBxCodigoBarra.Image = codigoBarras;

                    //Zen.Barcode.Code128BarcodeDraw mGeneradorCB = Zen.Barcode.BarcodeDrawFactory.Code128WithChecksum;

                    //Image codigoBarras = mGeneradorCB.Draw(codigoCliente, 60, 1);
                    //pBxCodigoBarra.Image = codigoBarras;

                    BarcodeLib.Barcode Codigo = new BarcodeLib.Barcode();
                    Codigo.IncludeLabel = true;
                    pBxCodigoBarra.Image = Codigo.Encode(BarcodeLib.TYPE.CODE128, codigoCliente, Color.Black, Color.White, 200, 100);



                    doc.PrinterSettings.PrinterName = doc.DefaultPageSettings.PrinterSettings.PrinterName;

                    doc.PrintPage += new PrintPageEventHandler(ImprimirCodigoBarra);
                    // Set the zoom to 25 percent.
                    //this.PrintPreviewControl1.Zoom = 0.25;            
                    //vista.Controls.Add(this.PrintPreviewControl1);

                    vista.Document = doc;

                    /* if (User.VistaPrevia)
                     {*/
                    vista.ShowDialog();
                    //}
                    //else
                    //{
                    //    doc.Print();
                    //}
                }




            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, this.Text);
            }
        }

        public void ImprimirCodigoBarra(object sender, PrintPageEventArgs e)
        {
            //printFont = new Font("Agency FB", 11, FontStyle.Regular);
            using (var fnt = new Font("Agency FB", 11, FontStyle.Regular))
            {
                int posX = 20;
                int posY = 0;                             
              
                posY += 17;
                e.Graphics.DrawString($"{codigoCliente} - { identificacion}", fnt, Brushes.Black, posX, posY);              
                posX = 15;
                posY += 20;
                e.Graphics.DrawString(nombreCliente, fnt, Brushes.Black, posX, posY);
                posX = 15;
                posY += 20;
                e.Graphics.DrawString(DateTime.Now.ToString("dd/MM/yyyy HH:MM:ss"), fnt, Brushes.Black, posX, posY);

                posY += 40;
                //e.Graphics.DrawImage(this.pBxCodigoBarra.Image, 20, 50);
                e.Graphics.DrawImage(this.pBxCodigoBarra.Image, 30, posY);
                posY += 120;

            }
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnBuscar_Click(null, null);
            }
            else
            {
                this.txtNombreCliente.Text = "";
                this.txtIdentificacion.Text = "";
            }
        }

        private void txtIdentificacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnBuscar_Click(null, null);
            }
            else
            {
                this.txtCodigo.Text = "";
                this.txtIdentificacion.Text = "";
            }
        }

        private void txtNombreCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnBuscar_Click(null, null);
            }
            else
            {
                this.txtCodigo.Text = "";
                this.txtNombreCliente.Text = "";
               
            }
        }

        private async void btnBuscar_Click(object sender, EventArgs e)        
        {
            this.txtMensajeFechaVencimiento.Text = "";
            string tipoFiltro = "";
            string busqueda = "";

            if (this.txtCodigo.Text.Trim().Length > 0 && this.txtNombreCliente.Text.Trim().Length ==0 && this.txtIdentificacion.Text.Trim().Length == 0)
            {
                tipoFiltro = "Codigo";
                busqueda = this.txtCodigo.Text;
                busqueda = $"%{busqueda}%";
                busqueda = busqueda.Replace(" ", "%");
            }
            //identificacion y que el nombre del cliente este en cero
            else if (this.txtNombreCliente.Text.Trim().Length > 0 && this.txtCodigo.Text.Trim().Length == 0 && this.txtIdentificacion.Text.Trim().Length == 0)
            {
                tipoFiltro = "Nombre";
                busqueda = this.txtNombreCliente.Text;
                busqueda = $"%{busqueda}%";
                busqueda = busqueda.Replace(" ", "%");
            }
            //nombre del cliente y que la identificacion del cliente este vacio 
            else if (this.txtIdentificacion.Text.Trim().Length > 0 && this.txtCodigo.Text.Trim().Length == 0 && this.txtNombreCliente.Text.Trim().Length == 0)
            {
                tipoFiltro = "Identificacion";
                busqueda = this.txtIdentificacion.Text;
                busqueda = $"%{busqueda}%";
                busqueda = busqueda.Replace(" ", "%");
            }
            //si la identificacion y el nombre del cliente estan vacion entonces mandar un mensaje y cancelar la busqueda
            else if (this.txtIdentificacion.Text.Trim().Length == 0 && this.txtNombreCliente.Text.Trim().Length == 0 && this.txtCodigo.Text.Trim().Length==0)
            {
                MessageBox.Show("Debes de ingresar el numero de identificacion o el nombre del cliente", "Sistema COVENTAF");
                return;
            }

            this.Cursor = Cursors.WaitCursor;
            this.dgvListaCliente.Cursor = Cursors.WaitCursor;

            this.btnImprimir.Enabled = false;
          
            //limpiar las filas
            this.dgvListaCliente.Rows.Clear();
            this.dgvBeneficiaro.Rows.Clear();
            ResponseModel responseModel = new ResponseModel();
            var _dataService = new ServiceCliente();

            try
            {
                responseModel = await new ServiceCliente().ConsultarCliente(tipoFiltro, busqueda, responseModel);

                if (responseModel.Exito == 1)
                {
                    var datosClientes = new List<ListaCliente>();
                    datosClientes = responseModel.Data as List<ListaCliente>;
                    // this.dgvListaCliente.DataSource = datosClientes;

                    foreach (var item in datosClientes)
                    {
                        this.dgvListaCliente.Rows.Add(item.Titular, item.NombreTitular, item.Cliente, item.Nombre, item.Cedula, item.Identidad, item.Grado, item.NumeroUnico, item.Procedencia, item.UnidadMilitar, item.Autoriza, item.Nota, item.FechaVencimiento);
                    }

                    if (this.dgvListaCliente.Rows.Count > 0)
                    {
                        this.btnImprimir.Enabled = true;
                    }
                }             
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Sistema COVENTAF");
            }
            finally
            {
                this.Cursor = Cursors.Default;
                this.dgvListaCliente.Cursor = Cursors.Default;
            }
        }

        private async void dgvListaCliente_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.dgvListaCliente.RowCount > 0)
            {
                int index = this.dgvListaCliente.CurrentRow.Index;
                var busqueda = dgvListaCliente.Rows[index].Cells["Titular1"].Value.ToString();

                //limpiar las filas
                this.dgvBeneficiaro.Rows.Clear();
                ResponseModel responseModel = new ResponseModel();
                var _dataService = new ServiceCliente();


                try
                {
                    responseModel = await new ServiceCliente().ObtenenerBeneficiario("Beneficiario", busqueda, responseModel);

                    if (responseModel.Exito == 1)
                    {                        

                        var datosClientes = new List<ListaCliente>();
                        datosClientes = responseModel.Data as List<ListaCliente>;

                        foreach (var item in datosClientes)
                        {
                            this.dgvBeneficiaro.Rows.Add(item.Cliente, item.Nombre, item.Parentesco, item.Sexo, item.FechaNacimiento, item.Edad, item.Cedula, item.Titular, item.NombreTitular, item.Nota, item.FechaVencimiento);
                        }

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                BuscarFechaVencimiento(busqueda);
            }
        }


        private async void BuscarFechaVencimiento(string busqueda)
        {
            
            //limpiar las filas
            
            ResponseModel responseModel = new ResponseModel();
            var _dataService = new ServiceCliente();

            try
            {
                responseModel = await new ServiceCliente().ObtenenerFechaVencimientoTitular(busqueda, responseModel);

                if (responseModel.Exito == 1)
                {
                    var datosClientes = new ListaCliente();
                    datosClientes = responseModel.Data as ListaCliente;

                    //V= significa que esta vencido
                    if (datosClientes.VencidoID == "V")
                    {
                        this.txtMensajeFechaVencimiento.ForeColor = Color.Red;
                    }
                    else
                    {
                        this.txtMensajeFechaVencimiento.ForeColor = Color.Blue;
                    }

                    this.txtMensajeFechaVencimiento.Text = datosClientes.MensajeVencido;
                    if (datosClientes.Nota.Length !=0)
                    {
                        this.txtMensajeFechaVencimiento.Text = $" {datosClientes.MensajeVencido} \n NOTAS: {datosClientes.Nota}";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

     
    }
}
