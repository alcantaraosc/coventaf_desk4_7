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
                    codigoCliente = this.dgvListaCliente.Rows[index].Cells[0].Value.ToString();
                    identificacion = this.dgvListaCliente.Rows[index].Cells[1].Value.ToString();
                    nombreCliente = this.dgvListaCliente.Rows[index].Cells[2].Value.ToString();

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
            using (var fnt = new Font("Courier New", 10))
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

            }
            else
            {
                this.txtIdentificacion.Text = "";
                this.txtNombreCliente.Text = "";
            }
        }

        private void txtIdentificacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                
            }
            else
            {
                this.txtCodigo.Text = "";
                this.txtNombreCliente.Text = "";
            }
        }

        private void txtNombreCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {

            }
            else
            {
                this.txtCodigo.Text = "";
                this.txtIdentificacion.Text = "";
               
            }
        }

        private async void btnBuscar_Click(object sender, EventArgs e)
        {
            string tipoFiltro = "";
            string busqueda = "";

            //identificacion y que el nombre del cliente este en cero
            if (this.txtIdentificacion.Text.Trim().Length > 0 && this.txtNombreCliente.Text.Trim().Length == 0)
            {
                tipoFiltro = "Identificacion";
                busqueda = this.txtIdentificacion.Text;
            }
            //nombre del cliente y que la identificacion del cliente este vacio 
            else if (this.txtNombreCliente.Text.Trim().Length > 0 && this.txtIdentificacion.Text.Trim().Length == 0)
            {
                tipoFiltro = "Cliente";
                busqueda = this.txtNombreCliente.Text;
            }
            //si la identificacion y el nombre del cliente estan vacion entonces mandar un mensaje y cancelar la busqueda
            else if (this.txtNombreCliente.Text.Trim().Length == 0 && this.txtIdentificacion.Text.Trim().Length == 0)
            {
                MessageBox.Show("Debes de ingresar el numero de identificacion o el nombre del cliente", "Sistema COVENTAF");
                return;
            }

            this.Cursor = Cursors.WaitCursor;
            this.dgvListaCliente.Cursor = Cursors.WaitCursor;

            //limpiar las filas
            this.dgvListaCliente.Rows.Clear();
            ResponseModel responseModel = new ResponseModel();
            var _dataService = new ServiceCliente();

            try
            {
                responseModel = await new ServiceCliente().ObtenerListaClientes(tipoFiltro, busqueda, responseModel);

                if (responseModel.Exito == 1)
                {
                    var datosClientes = new List<Clientes>();
                    datosClientes = responseModel.Data as List<Clientes>;

                    foreach (var item in datosClientes)
                    {
                        this.dgvListaCliente.Rows.Add(item.Cliente, item.Contribuyente, item.Nombre, item.Cargo, item.Activo);
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
    }
}
