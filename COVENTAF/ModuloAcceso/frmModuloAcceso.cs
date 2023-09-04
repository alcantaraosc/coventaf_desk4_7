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


        private string codigoTitular;
        private string codigoBeneficiario;
        private string cedulaBeneficiario;
        private string cedulaTitular;
        private string nombreBeneficiario;
        private string nombreTitular;
        private string procedencia;
        private decimal credito = 0.00M;

        List<ListaCliente> listaBeneficiario;



        public static System.Drawing.Font printFont;

        private PrintDocument doc = new PrintDocument();
        private PrintPreviewDialog vista = new PrintPreviewDialog();
        // Construct the PrintPreviewControl.
        PrintPreviewControl PrintPreviewControl1 = new PrintPreviewControl();

        public frmModuloAcceso()
        {
            InitializeComponent();
        }

        private async void frmModuloAcceso_Load(object sender, EventArgs e)
        {
            await Task.Delay(TimeSpan.FromSeconds(2));
            //this.dgvListaCliente1.OptionsView.ColumnAutoWidth = false;
            await ObtenerInformacionDelDia();
           
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
       
        private async void btnImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                var codigoZafra1 = dgvListaCliente1.GetFocusedRowCellValue("Titular").ToString();
                string codigoZafra = Convert.ToString(dgvListaCliente1.GetRowCellValue(0, "Titular"));
                             
                bool resultAcompañante = false;

                if (dgvListaCliente1.RowCount > 0)
                {
                    //obtener la fila seleccionada
                    int row = dgvListaCliente1.GetSelectedRows()[0];
                    //codigo del titular                   
                    codigoTitular = this.dgvListaCliente1.GetRowCellValue(row, "Titular").ToString().Trim();
                    //codigo del beneficiario
                    codigoBeneficiario = this.dgvListaCliente1.GetRowCellValue(row, "Cliente").ToString().Trim();
                    //cedula del beneficiario
                    cedulaBeneficiario = this.dgvListaCliente1.GetRowCellValue(row, "Cedula").ToString().Trim();
                    //nombre del beneficiario
                    nombreBeneficiario = this.dgvListaCliente1.GetRowCellValue(row, "Nombre").ToString().Trim();
                    //nombre del titular
                    nombreTitular = this.dgvListaCliente1.GetRowCellValue(row, "NombreTitular").ToString().Trim();                    
                    //procedencia
                    procedencia = this.dgvListaCliente1.GetRowCellValue(row, "Procedencia").ToString().Trim();

                    cedulaTitular = listaBeneficiario.Where(x => x.Cliente == codigoTitular).Select(x => x.Cedula).FirstOrDefault();

                    //Credito del cliente (credito 2 de cada 15 dia)
                    credito = Convert.ToDecimal(this.dgvListaCliente1.GetRowCellValue(row, "MontoCredito2Disponible").ToString());

                    var bitacoraVisita = new Cs_Bitacora_Visita() { Cliente = codigoBeneficiario, Titular = codigoTitular, Usuario_Registro = User.Usuario };
                    var respuesta =  MessageBox.Show("¿ El cliente trae acompañante ?", "Sistema COVENTAF", MessageBoxButtons.YesNoCancel);

                    //si tiene acompañante entonces se registra
                    if (respuesta == DialogResult.Yes)
                    {
                        using (var frmAcompañante = new frmRegistroAcompañante())
                        {
                            frmAcompañante.bitacoraVisita = bitacoraVisita;
                            frmAcompañante.ShowDialog();
                            resultAcompañante = frmAcompañante.result;
                        }

                        //si se guardo exitosamente los datos del acompañante entonces manda a imprimir la tickect
                        if (resultAcompañante)
                        {
                            OrdenImprimir();
                            await ObtenerInformacionDelDia();
                        }
                    }
                    //de lo contario 
                    else if (respuesta == DialogResult.No)
                    {
                        ResponseModel responseModel = new ResponseModel();
                        var cs_Acompanante = new List<Cs_Acompanante>();
                        var _dataService = new ServiceCliente();

                        responseModel = await _dataService.GuardarRegistroVisita(bitacoraVisita, cs_Acompanante, responseModel);

                        if (responseModel.Exito == 1) 
                        { 
                            OrdenImprimir();
                            await ObtenerInformacionDelDia();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, this.Text);
            }
        }

        private void OrdenImprimir()
        {
            //Image codigoBarras =  Code128Rendering.MakeBarcodeImage(codigoCliente, altura, true);                   
            //this.pBxCodigoBarra.Image = codigoBarras;

            //Zen.Barcode.Code128BarcodeDraw mGeneradorCB = Zen.Barcode.BarcodeDrawFactory.Code128WithChecksum;

            //Image codigoBarras = mGeneradorCB.Draw(codigoCliente, 60, 1);
            //pBxCodigoBarra.Image = codigoBarras;

            BarcodeLib.Barcode Codigo = new BarcodeLib.Barcode();
            Codigo.IncludeLabel = true;
            pBxCodigoBarra.Image = Codigo.Encode(BarcodeLib.TYPE.CODE128, codigoTitular, Color.Black, Color.White,  200, 50);
                 
            doc.PrinterSettings.PrinterName = doc.DefaultPageSettings.PrinterSettings.PrinterName;
            doc.PrintPage += new PrintPageEventHandler(ImprimirCodigoBarraCliente);
    
            vista.Document = doc;

            if (User.VistaPrevia)
            {
                vista.ShowDialog();
            }
            else
            {
                doc.Print();
            }
        }


        public void ImprimirCodigoBarraCliente(object sender, PrintPageEventArgs e)
        {
            //printFont = new Font("Agency FB", 11, FontStyle.Regular);
            Font fnt = new Font("Agency FB", 11, FontStyle.Regular);
            //using (var fnt = new Font("Agency FB", 11, FontStyle.Regular))
            //{
                //int posX = 20;
                //int posY = 0;

                //posX = 15;
                //posY += 20;
                //e.Graphics.DrawString(procedencia, fnt, Brushes.Black, posX, posY);

                //posY += 17;
                //e.Graphics.DrawString($"{titular} - { identificacion}", fnt, Brushes.Black, posX, posY);
                //posX = 15;
                //posY += 20;
                //e.Graphics.DrawString(nombreCliente, fnt, Brushes.Black, posX, posY);
                //posX = 15;
                //posY += 20;
                //e.Graphics.DrawString(DateTime.Now.ToString("dd/MM/yyyy HH:MM:ss"), fnt, Brushes.Black, posX, posY);

                //posY += 40;
                ////e.Graphics.DrawImage(this.pBxCodigoBarra.Image, 20, 50);
                //e.Graphics.DrawImage(this.pBxCodigoBarra.Image, 2, posY);
                //posY += 120;

            //}

            try
            {
                int posX = 20;
                int posY = 0;

                posX = 15;
                posY += 20;
                e.Graphics.DrawString($"{User.NombreTienda}", fnt, Brushes.Black, posX, posY);

                posY += 17;
                e.Graphics.DrawString($"CODIGO: {codigoTitular} - { cedulaTitular}", fnt, Brushes.Black, posX, posY);
                posX = 15;
                posY += 20;
                e.Graphics.DrawString($"TITULAR: {nombreTitular}", fnt, Brushes.Black, posX, posY);

                if (codigoBeneficiario != codigoTitular)
                {
                    posX = 15;
                    posY += 20;
                    e.Graphics.DrawString($"BENEFICIARIO: { nombreBeneficiario }", fnt, Brushes.Black, posX, posY);
                }

                posX = 15;
                posY += 20;
                e.Graphics.DrawString($"FECHA DE INGRESO: { DateTime.Now.ToString("dd/MM/yyyy HH:MM:ss")}", fnt, Brushes.Black, posX, posY);
                posX = 15;
                posY += 20;
                e.Graphics.DrawString($"PROCEDENCIA: {procedencia}", fnt, Brushes.Black, posX, posY);
                //posX = 15;
                //posY += 20;
                //e.Graphics.DrawString($"CREDITO: {credito}", fnt, Brushes.Black, posX, posY);

                posY += 20;
                //e.Graphics.DrawImage(this.pBxCodigoBarra.Image, 20, 50);
                e.Graphics.DrawImage(this.pBxCodigoBarra.Image, 50, posY);
                posY += 120;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Sistema COVENTAF");
            }

        }

        public async Task<bool> ObtenerInformacionDelDia()
        {           
            var responseModelo = new ResponseModel();
            responseModelo.Data = new Int32();
            responseModelo = await new ServiceCliente().ObtenerCantidadClientes(responseModelo);
            if (responseModelo.Exito ==1)
            {
                this.lblCantidadClientesDia.Text = $"Cantidad Clientes del Dia: {responseModelo.Data.ToString()}";
            }

            return true;
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnBuscar_Click(null, null);
            }
            else
            {
                this.btnImprimir.Enabled = false;
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
                this.btnImprimir.Enabled = false;
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
                this.btnImprimir.Enabled = false;
                this.txtCodigo.Text = "";
                this.txtNombreCliente.Text = "";

            }
        }

        private async void btnBuscar_Click(object sender, EventArgs e)
        {
            this.txtMensajeFechaVencimiento.Text = "";
            string tipoFiltro = "";
            string busqueda = "";

            if (this.txtCodigo.Text.Trim().Length > 0 && this.txtNombreCliente.Text.Trim().Length == 0 && this.txtIdentificacion.Text.Trim().Length == 0)
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
            else if (this.txtIdentificacion.Text.Trim().Length == 0 && this.txtNombreCliente.Text.Trim().Length == 0 && this.txtCodigo.Text.Trim().Length == 0)
            {
                MessageBox.Show("Debes de ingresar el numero de identificacion o el nombre del cliente", "Sistema COVENTAF");
                return;
            }

            this.Cursor = Cursors.WaitCursor;            
            this.btnImprimir.Enabled = false;
           
            ResponseModel responseModel = new ResponseModel();
            var _dataService = new ServiceCliente();

            try
            {
                this.btnBuscar.Enabled = false;
                responseModel = await new ServiceCliente().ConsultarCliente(tipoFiltro, busqueda, responseModel);

                if (responseModel.Exito == 1)
                {
                   
                    var datosClientes = new List<ListaCliente>();
                    datosClientes = responseModel.Data as List<ListaCliente>;
                    this.dgvListaCliente1.GridControl.DataSource = datosClientes;
                    this.dgvBeneficiario.GridControl.DataSource = null;                        
                }
                else
                {                  
                    var datosClientes = new List<ListaCliente>();
                    this.dgvListaCliente1.GridControl.DataSource = datosClientes;
                    this.dgvBeneficiario.GridControl.DataSource = null;

                    MessageBox.Show(responseModel.Mensaje, "Sistema COVENTAF");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Sistema COVENTAF");
            }
            finally
            {
                listaBeneficiario = null;
                this.btnBuscar.Enabled = true;
                this.Cursor = Cursors.Default;                
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
                        this.btnImprimir.Enabled = false;
                        this.txtMensajeFechaVencimiento.ForeColor = Color.Red;
                    }
                    else
                    {
                        this.btnImprimir.Enabled = true;
                        this.txtMensajeFechaVencimiento.ForeColor = Color.Blue;
                    }

                    this.txtMensajeFechaVencimiento.Text = datosClientes.MensajeVencido;
                    if (datosClientes.Nota.Length != 0)
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
      
        private void btnListaClienteDelDia_Click(object sender, EventArgs e)
        {
            using(var frmListaCliente = new frmListaVisitaCliente())
            {
                frmListaCliente.ShowDialog();
            }
        }

        private async void gridControl1_MouseClick(object sender, MouseEventArgs e)
        {
            if (this.dgvListaCliente1.RowCount > 0)
            {
                //obtener la fila seleccionada
                int index = dgvListaCliente1.GetSelectedRows()[0];
                // int index = this.dgvListaCliente.CurrentRow.Index;
                string busqueda = dgvListaCliente1.GetRowCellValue(index, "Titular").ToString().Trim();

                //limpiar las filas
                //this.dgvBeneficiaro.Rows.Clear();
                ResponseModel responseModel = new ResponseModel();
                var _dataService = new ServiceCliente();

                try
                {
                    responseModel = await new ServiceCliente().ObtenenerBeneficiario("Beneficiario", busqueda, responseModel);

                    if (responseModel.Exito == 1)
                    {
                        listaBeneficiario = new List<ListaCliente>();
                        listaBeneficiario = responseModel.Data as List<ListaCliente>;
                        this.dgvBeneficiario.GridControl.DataSource = listaBeneficiario;                                             
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                BuscarFechaVencimiento(busqueda);
            }
        }
    }
}
