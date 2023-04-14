using Api.Model.Modelos;
using Api.Model.ViewModels;
using Api.Service.DataService;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Windows.Forms;
using Font = System.Drawing.Font;

using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using System.IO;
using System.Text;
using System.Diagnostics;
using RawPrint;

namespace COVENTAF.PuntoVenta
{
    public partial class frmCierreCaja : Form
    {
        /*
         * libreria para generar en PDF: 
               iTextSharp v5.5.13
               itextsharp.xmlworker v5.5.13*/

        //esta variable guardar true si se guardo correctamente el cierre de caja
        public bool CierreCajaExitosamente = false;
        private bool existeEfectivoDolar = false;
        private bool existeEfectivoCordoba = false;

        List<Denominacion> denominacion = new List<Denominacion>();
        ServiceCaja_Pos _serviceCajaPos;
        List<DetallesCierreCaja> _datosCierreCaja;
        VariableCierreCaja _listVarCierreCaja = new VariableCierreCaja();
        ViewModelCierre viewModelCierre;
        Cierre_Pos _cierre_Pos;
        private string idActual = "";
        private decimal cantidadGrid;
        private decimal totatCajeroCordobas = 0.00M;
        private decimal totalCajeroDolares = 0.00M;

        private PrintDocument doc = new PrintDocument();
        private PrintPreviewDialog vista = new PrintPreviewDialog();
        // Construct the PrintPreviewControl.
        PrintPreviewControl PrintPreviewControl1 = new PrintPreviewControl();

        public frmCierreCaja()
        {
            InitializeComponent();
            _serviceCajaPos = new ServiceCaja_Pos();
            
        }

        private void frmCierreCaja_Load(object sender, EventArgs e)
        {
            _cierre_Pos = new Cierre_Pos();
            try
            {
                if (User.ConsecCierreCT.Length != 0)
                {
                    //
                    PrepararCajaParaCierre(User.Caja, User.Usuario, User.ConsecCierreCT);
                }
                else
                {
                    MessageBox.Show("No existe el numero de cierre para el cajero", "Sistema COVENTAF");
                    this.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Sistema COVENTAF");
            }

            this.lblTitulo.Text = $"Cierre de Caja: {User.Caja}";
            this.lblTituloCaja.Text = $"Cierre de Caja {User.Caja}. con el Numero de Cierre: {User.ConsecCierreCT}";
        }



        public async void PrepararCajaParaCierre(string caja, string cajero, string numeroCierre)
        {
            this.Cursor = Cursors.WaitCursor;

            ResponseModel responseModel = new ResponseModel();
            _datosCierreCaja = new List<DetallesCierreCaja>();

            try
            {
                _datosCierreCaja = await _serviceCajaPos.ObtenerDatosParaCierreCaja(caja, cajero, numeroCierre, responseModel);
                if (responseModel.Exito == 1)
                {
                    //obtener los datos del cierre pos
                    _cierre_Pos = responseModel.Data as Cierre_Pos;
                    //llenar el grid reportado por el sistema
                    LlenarGridReportadoXSistema(_datosCierreCaja);
                    LlenarGridReportadoCajero(_datosCierreCaja);
                    CalcularTotalReportadoCajero();
                    ListarDenomincaciones();
                }
                else
                {
                    MessageBox.Show(responseModel.Mensaje, "Sistema COVENTAF");
                }
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show(ex.Message);
            }
            this.Cursor = Cursors.Default;
        }

        private void LlenarGridReportadoXSistema(List<DetallesCierreCaja> _datosCierreCaja)
        {
            _listVarCierreCaja.TotalCordoba = 0.00M;
            _listVarCierreCaja.TotalDolar = 0.00M;
            _listVarCierreCaja.VentaEfectivoCordoba = 0.00M;
            _listVarCierreCaja.VentaEfectivoDolar = 0.00M;

            foreach (var itemSistema in _datosCierreCaja)
            {

                this.dgvGridReportadoPorSistema.Rows.Add(itemSistema.Id, itemSistema.Descripcion,
                    (itemSistema.Moneda == "L" ? $"C$ {itemSistema.Monto.ToString("N2")}" : $"U$ {itemSistema.Monto.ToString("N2")}"),
                    itemSistema.Moneda);
                //comprobar si la moneda es Local =L (C$)
                if (itemSistema.Moneda == "L")
                {
                    _listVarCierreCaja.TotalCordoba += itemSistema.Monto;
                }
                //comprobar si la moneda es Dolar =D (U$)
                else if (itemSistema.Moneda == "D")
                {
                    _listVarCierreCaja.TotalDolar += itemSistema.Monto;
                }

                //comprobar si existe forma de pago 0001=Efectivo cordoba
                if (itemSistema.Forma_Pago == "0001" && itemSistema.Moneda == "L")
                {
                    existeEfectivoCordoba = true;
                    _listVarCierreCaja.VentaEfectivoCordoba += itemSistema.Monto;
                }
                //comprobar si existe forma de pago 0001=Efectivo dolar
                if (itemSistema.Forma_Pago == "0001" && itemSistema.Moneda == "D")
                {
                    existeEfectivoDolar = true;
                    _listVarCierreCaja.VentaEfectivoDolar += itemSistema.Monto;
                }
            }

            this.txtTotalCordobasSistema.Text = _listVarCierreCaja.TotalCordoba.ToString("N2");
            this.txtTotalDolaresSistema.Text = _listVarCierreCaja.TotalDolar.ToString("N2");

        }

        private void LlenarGridReportadoCajero(List<DetallesCierreCaja> _datosCierreCaja)
        {
            foreach (var itemSistema in _datosCierreCaja)
            {
                this.dgvGridRportadoXCajero.Rows.Add(itemSistema.Id, itemSistema.Descripcion, (itemSistema.Moneda == "L" ? "C$ 0.00" : "U$ 0.00"), itemSistema.Moneda);
            }
        }

        void CalcularTotalReportadoCajero()
        {
            totatCajeroCordobas = 0.00M;
            totalCajeroDolares = 0.00M;

            for (var rows = 0; rows < dgvGridRportadoXCajero.RowCount; rows++)
            {
                //comprobar si la moneda es Local =L (C$)
                if (dgvGridRportadoXCajero.Rows[rows].Cells["Monedac"].Value.ToString() == "L")
                {

                    totatCajeroCordobas += Convert.ToDecimal(dgvGridRportadoXCajero.Rows[rows].Cells["Montoc"].Value.ToString().Replace("C$", ""));
                }
                else if (dgvGridRportadoXCajero.Rows[rows].Cells["Monedac"].Value.ToString() == "D")
                {
                    totalCajeroDolares += Convert.ToDecimal(dgvGridRportadoXCajero.Rows[rows].Cells["Montoc"].Value.ToString().Replace("U$", ""));
                }
            }

            this.txtTotalCordobasCajero.Text = totatCajeroCordobas.ToString("N2");
            this.txtTotalDolaresCajero.Text = totalCajeroDolares.ToString("N2");
        }

        private async void ListarDenomincaciones()
        {
            ResponseModel responseModel = new ResponseModel();

            try
            {
                denominacion = await _serviceCajaPos.ObtenerListaDenominacion(responseModel);
                if (responseModel.Exito == 1)
                {
                    LlenarGridDenominaciones();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void btnCierre_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void LlenarGridDenominaciones()
        {
            try
            {
                //comprobar si existe el efectivo en cordobas
                if (existeEfectivoCordoba)
                {
                    foreach (var itemDenominacion in denominacion)
                    {
                        //0001FL =Efectivo Factura Cordoba
                        this.dgvReportePagoCajero.Rows.Add("0001FL", itemDenominacion.Tipo, $"C${itemDenominacion.Denom_Monto.ToString("N2")}", 0, "L");
                    }
                }

                //comprobar si existe el efectivo en cordobas
                if (existeEfectivoDolar)
                {
                    foreach (var itemDenominacion in denominacion)
                    {
                        //0001FD =Efectivo Factura Dolar
                        this.dgvReportePagoCajero.Rows.Add("0001FD", itemDenominacion.Tipo, $"U${itemDenominacion.Denom_Monto.ToString("N2")}", 0, "D");
                    }
                }

                foreach (var itemDenomincacion in _datosCierreCaja)
                {
                    if (itemDenomincacion.Forma_Pago != "0001")
                    {
                        
                        this.dgvReportePagoCajero.Rows.Add($"{itemDenomincacion.Id}", "ND", itemDenomincacion.Descripcion, 0, itemDenomincacion.Moneda);
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        private void dgvReportePagoCajero_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //si la columna es cantidad (4) o descuento(5)
            if (e.ColumnIndex == 3)
            {
                int filaGrid = e.RowIndex;

                //btnCobrar.Enabled = false;
                //asignar el consucutivo para indicar en que posicion estas
                //consecutivoActualFactura = e.RowIndex;
                //validar la infor
                ValidarCantidaddelGridDenominacion(filaGrid);

                //calcular el grid de denominacion y enviar idActua y la fila
                CalcularGridDenominacion(idActual, filaGrid);
                //calcular totales
                CalcularTotalReportadoCajero();
            }
        }



        private void ValidarCantidaddelGridDenominacion(int rows)
        {
            //obtener el valor del grid
            var cantidad = this.dgvReportePagoCajero.Rows[rows].Cells["Cantidadd"].Value;
            //validar si el valor es null o tiene datos
            string valorCantidad = cantidad is null ? "" : cantidad.ToString().Trim();
            //probar si la fila corresponde a los codigo 0001FL or 0001FD
            bool permitirPuntDecimal = (this.dgvReportePagoCajero.Rows[rows].Cells["Idd"].Value.ToString() == "0001FL" || this.dgvReportePagoCajero.Rows[rows].Cells["Idd"].Value.ToString() == "0001FD") ? false : true;

            var x = this.dgvReportePagoCajero.Rows[rows].Cells["Idd"].Value.ToString();

            //VALES GENERADOS
            bool permitirNumeroNegativo = (this.dgvReportePagoCajero.Rows[rows].Cells["Idd"].Value.ToString() == "0005DL" ) ? true : false;
            //  bool isNumeric = double.TryParse(cantidad);

            if (valorCantidad.Length == 0)
            {
                MessageBox.Show("Debes Digitar un numero en la columna cantidad", "Sistema COVENTAF");
                this.dgvReportePagoCajero.Rows[rows].Cells["Cantidadd"].Value = cantidadGrid;
                cantidad = 0;
            }
            else if (CountPuntoDecimal(valorCantidad) >= 2)
            {
                MessageBox.Show("El numero que digitaste no es un numero correcto", "COVENTAF");
                this.dgvReportePagoCajero.Rows[rows].Cells["Cantidadd"].Value = cantidadGrid;
                cantidadGrid = 0;
            }
            else if (!IsDigit(valorCantidad, permitirPuntDecimal, permitirNumeroNegativo))
            {
                MessageBox.Show("La Columna Cantidad solo permite numeros enteros positivos", "COVENTAF");
                this.dgvReportePagoCajero.Rows[rows].Cells["Cantidadd"].Value = cantidadGrid;
                cantidadGrid = 0;
            }

        }


        private int CountPuntoDecimal(string cantidad)
        {
            byte contadorDecimales = 0;
            for (var rows = 0; rows < cantidad.Length; rows++)
            {
                //comprobar si es un punto decimal 
                if (cantidad[rows] == '.')
                {
                    //contar los puntos decimal
                    contadorDecimales += 1;
                }
            }

            return contadorDecimales;
        }


        private bool IsDigit(string cantidad, bool puntoDecimalPermitid, bool permitirNumeroNegativo)
        {
            bool tieneDigitado = true;
            for (var rows = 0; rows < cantidad.Length; rows++)
            {
                //comprobar si es un punto decimal y ademas si se permite para esta consulta el punto decimal
                if (cantidad[rows] == '.' && puntoDecimalPermitid)
                {
                    continue;
                }
                else if (cantidad[rows] == '-' && permitirNumeroNegativo)
                {
                    continue;
                }

                else if (!char.IsDigit(cantidad[rows]))
                {
                    tieneDigitado = false;
                    break;
                }
            }

            return tieneDigitado;
        }


        private void CalcularGridDenominacion(string Id, int filaGrid)
        {
            decimal sumaDenominacion = 0;
            string simboloBuscar = "";


            if (Id == "0001FL" || Id == "0001FD")
            {
                //simbolo a buscar
                simboloBuscar = Id == "0001FL" ? "C$" : "U$";

                for (var rows = 0; rows < dgvReportePagoCajero.Rows.Count; rows++)
                {
                    //verificar si el id="0001FL" or id="0001FD"
                    if (dgvReportePagoCajero.Rows[rows].Cells["Idd"].Value.ToString() == Id)
                    {
                        //obtener el valor
                        var denominacion = dgvReportePagoCajero.Rows[rows].Cells["Denominaciond"].Value.ToString();
                        //quitar el simbolo C$ o U$
                        decimal valorDenominacion = Convert.ToDecimal(denominacion.Replace(simboloBuscar, ""));
                        dgvReportePagoCajero.Rows[rows].Cells["Resultado"].Value = valorDenominacion * Convert.ToInt32(dgvReportePagoCajero.Rows[rows].Cells["Cantidadd"].Value);
                        //sumar la lista de denominacion C$ o U$
                        sumaDenominacion += Convert.ToDecimal(dgvReportePagoCajero.Rows[rows].Cells["Resultado"].Value);
                    }
                }

            }
            else
            {
                //simbolo a buscar
                simboloBuscar = dgvReportePagoCajero.Rows[filaGrid].Cells["Monedad"].Value.ToString() == "L" ? "C$" : "U$";
                //sumar la lista de denominacion C$ o U$
                sumaDenominacion = Convert.ToDecimal(dgvReportePagoCajero.Rows[filaGrid].Cells["Cantidadd"].Value);
            }

            AsignarValorGridReportadoXCajero(Id, sumaDenominacion, simboloBuscar);

            //dgvReportePagoCajero.Rows[rows].Cells["Result"] = Convert.ToDecimal(dgvReportePagoCajero.Rows[rows].Cells["datRepPagCajeroDenominacion"].Value.ToString()) * Convert.ToDecimal(dgvReportePagoCajero.Rows[rows].Cells["datRepPagCajeroCantidad"].Value);        
        }

        private void AsignarValorGridReportadoXCajero(string Id, decimal value, string simbolo)
        {
            for (var rows = 0; rows < dgvGridRportadoXCajero.Rows.Count; rows++)
            {
                //buscar el Id en el gridview del cajero reportado
                if (dgvGridRportadoXCajero.Rows[rows].Cells["Idc"].Value.ToString() == Id)
                {
                    //asignar el simbolo del C$ o U$ y el monto
                    dgvGridRportadoXCajero.Rows[rows].Cells["Montoc"].Value = $"{simbolo} {value.ToString("N2")}";
                    break;
                }

            }
        }

        private void dgvReportePagoCajero_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //obtener el consecutivo
            int index = e.RowIndex;
            int columna = e.ColumnIndex;


            var columnaIndex = columna;

            if (index != -1 && columna != -1)
            {
                //(columna 3) es cantidad
                //columna Cantidad del DataGridView (columna=3)
                if (columnaIndex == 3)
                {
                    idActual = dgvReportePagoCajero.Rows[index].Cells[0].Value.ToString();
                    //antes de editar guardar temporalmente la cantidad en la variable  cantidadGrid por si la cantidad que digita el cajero le agrega otra cosa, entonce regresa al ultimo valor 
                    cantidadGrid = Convert.ToDecimal(dgvReportePagoCajero.Rows[index].Cells[columnaIndex].Value);
                }
            }
        }

        private void dgvReportePagoCajero_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            int columna = e.ColumnIndex;


            var columnaIndex = columna;

            if (index != -1 && columna != -1)
            {
                //(columna 3) es cantidad
                //columna Cantidad del DataGridView (columna=3)
                if (columnaIndex == 3)
                {
                    idActual = dgvReportePagoCajero.Rows[index].Cells[0].Value.ToString();
                    //antes de editar guardar temporalmente la cantidad en la variable  cantidadGrid por si la cantidad que digita el cajero le agrega otra cosa, entonce regresa al ultimo valor 
                    cantidadGrid = Convert.ToDecimal(dgvReportePagoCajero.Rows[index].Cells[columnaIndex].Value);
                }
            }
        }

        private async void btnGuardarCierre_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿ Estas seguro de guardar el cierre de Caja ?", "Sistema COVENTAF", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
      
                var responseModel = new ResponseModel();            
                viewModelCierre = null;
                viewModelCierre = new ViewModelCierre();
                viewModelCierre.Cierre_Det_Pago = new List<Cierre_Det_Pago>();
                viewModelCierre.Cierre_Pos = new Cierre_Pos(); //{ Caja = "T1C2", Cajero = "MJUAREZ", Num_Cierre = "CT1000000006477" };
                viewModelCierre.Cierre_Desg_Tarj = new List<Cierre_Desg_Tarj>();

                var _service_Datos_Pos = new ServiceCaja_Pos();

                try
                {
                    //cargar los datos del cierre de caja  a la clase viewCierreCaja
                    CargarDatosCierreCaja(viewModelCierre);

                    responseModel = await _serviceCajaPos.GuardarCierreCaja(viewModelCierre, responseModel);                    
                    //si la respuesta del servidor es distinto a 1 (1 =Exitoso)
                    if (responseModel.Exito != 1)
                    {
                        //mostrar el mensaje del error.
                        MessageBox.Show(responseModel.Mensaje, "Sistema COVENTAF");
                    }
                    else
                    {
                        responseModel = await _serviceCajaPos.ObtenerRegistro_ReporteCierre(viewModelCierre.Cierre_Pos.Caja, viewModelCierre.Cierre_Pos.Cajero, viewModelCierre.Cierre_Pos.Num_Cierre, responseModel);
                        if (responseModel.Exito == 1)
                        {
                            viewModelCierre = responseModel.Data as ViewModelCierre;
                            CierreCajaExitosamente = true;
                            User.ConsecCierreCT = "";
                            User.Caja = "";
                            new Metodos.MetodoImpresion().ImprimirReporteCierreCajero(viewModelCierre);
                            new Metodos.MetodoImpresion().ImprimirReporteCierreCaja(viewModelCierre);

                            MessageBox.Show("El cierre de Caja se ha realizado correctamente", "Sistema COVENTAF");
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show(responseModel.Mensaje, "Sistema COVENTAF");
                        }
                    }                   
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Sistema COVENTAF");
                }



            }

        }

        void CargarDatosCierreCaja(ViewModelCierre viewModelCierre)
        {

            decimal sumarListaDif = 0.00M;
            viewModelCierre.Cierre_Pos.Cajero = User.Usuario;
            viewModelCierre.Cierre_Pos.Num_Cierre = User.ConsecCierreCT;
            viewModelCierre.Cierre_Pos.Caja = User.Caja;
            /*TotalDiferencia se refiere al faltante o sobrante y se obtiene del detalla de la tabla CIERRE_DET_PAGO, ahi hay un campo que se llama diferencia, 
              entonces sumar la diferencia en cordobas, debido que en el campo diferencia hay dolares entonces usar el tipo de cambio con 2 decimales para realizar la suma y obtener la diferencia */
            viewModelCierre.Cierre_Pos.Total_Diferencia = 0.00M;
            //total en cordoba que el el sistema reporto
            viewModelCierre.Cierre_Pos.Total_Local = _listVarCierreCaja.TotalCordoba;
            //total en dolares que el sistema Reporto
            viewModelCierre.Cierre_Pos.Total_Dolar = _listVarCierreCaja.TotalDolar;
            viewModelCierre.Cierre_Pos.Ventas_Efectivo = _listVarCierreCaja.VentaEfectivoCordoba;
            viewModelCierre.Cierre_Pos.Notas = this.txtNotas.Text;
            //Cobro_Efectivo_Rep = ventas solo en efectivo en dolar nada mas
            viewModelCierre.Cierre_Pos.Cobro_Efectivo_Rep = _listVarCierreCaja.VentaEfectivoDolar;


            for (int rows = 0; rows < this.dgvGridRportadoXCajero.Rows.Count; rows++)
            {
                //obtener el id
                var Id = dgvGridRportadoXCajero.Rows[rows].Cells["Idc"].Value.ToString();
                //obtener el registro por Id 
                var datSistema = _datosCierreCaja.Where(x => x.Id == Id).FirstOrDefault();
                //obtenere el simbolo de C$ or U$
                var simbolo = dgvGridRportadoXCajero.Rows[rows].Cells["Monedac"].Value.ToString() == "L" ? "C$" : "U$";
                //obtener la moneda. L=Local(Cordoba) o D=Dolar
                var moneda = dgvGridRportadoXCajero.Rows[rows].Cells["Monedac"].Value.ToString();

                //obtener el monto del usuario
                var montoUsuario = dgvGridRportadoXCajero.Rows[rows].Cells["Montoc"].Value.ToString().Replace(simbolo, "");

                var _dataCierreDetPago = new Cierre_Det_Pago()
                {
                    Identificacion = dgvGridRportadoXCajero.Rows[rows].Cells["Idc"].Value.ToString(),
                    Tipo_Pago = dgvGridRportadoXCajero.Rows[rows].Cells["TipoPagoc"].Value.ToString(),
                    Total_Usuario = Convert.ToDecimal(montoUsuario),
                    Total_Sistema = datSistema.Monto,
                    Diferencia = Convert.ToDecimal(montoUsuario) - datSistema.Monto,
                    //inicia desde cero (0)
                    Orden = rows,
                    Moneda = moneda,//dgvGridRportadoXCajero.Rows[rows].Cells["Monedac"].Value.ToString(),

                    Num_Cierre = User.ConsecCierreCT,
                    Cajero = User.Usuario,
                    Caja = User.Caja

                };

                sumarListaDif = (moneda == "L" ? sumarListaDif + _dataCierreDetPago.Diferencia : (sumarListaDif + (_dataCierreDetPago.Diferencia * Math.Round(_cierre_Pos.Tipo_Cambio, 2))));

                viewModelCierre.Cierre_Det_Pago.Add(_dataCierreDetPago);
            }

            viewModelCierre.Cierre_Pos.Total_Diferencia = sumarListaDif;
        }

        private void frmCierreCaja_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F8 && this.btnGuardarCierre.Enabled )
            {
                btnGuardarCierre_Click(null, null);
            }
        }

        private async void bntImprimir_Click(object sender, EventArgs e)
        {
            
            var responseModel = new ResponseModel();
            //ViewCierreCaja viewCierreCaja = new ViewCierreCaja();
            //viewCierreCaja.Cierre_Det_Pago = new List<Cierre_Det_Pago>();
            viewModelCierre = null;
            viewModelCierre = new ViewModelCierre();
            viewModelCierre.Cierre_Det_Pago = new List<Cierre_Det_Pago>();
            viewModelCierre.Cierre_Pos = new Cierre_Pos() { Caja = "T1C8", Cajero = "AOMAR", Num_Cierre = "CT1000000006694" };
            viewModelCierre.Cierre_Desg_Tarj = new List<Cierre_Desg_Tarj>();

            var _service_Datos_Pos = new ServiceCaja_Pos();

            try
            {
                //cargar los datos del cierre de caja  a la clase viewCierreCaja
               // CargarDatosCierreCaja(viewModelCierre);
                responseModel = await _serviceCajaPos.ObtenerRegistro_ReporteCierre(viewModelCierre.Cierre_Pos.Caja, viewModelCierre.Cierre_Pos.Cajero, viewModelCierre.Cierre_Pos.Num_Cierre, responseModel);
                if (responseModel.Exito == 1)
                {
                    viewModelCierre = responseModel.Data as ViewModelCierre;
                    CierreCajaExitosamente = true;
                    User.ConsecCierreCT = "";
                    User.Caja = "";
                    new Metodos.MetodoImpresion().ImprimirReporteCierreCajero(viewModelCierre);
                    new Metodos.MetodoImpresion().ImprimirReporteCierreCaja(viewModelCierre);               
                }
                else
                {
                    MessageBox.Show(responseModel.Mensaje, "Sistema COVENTAF");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Sistema COVENTAF");
            }

        }

        private void GuardarReporte()
        {
            /*
          * 
          * https://www.youtube.com/watch?v=Z47eF35t7E8 */
            SaveFileDialog guardar = new SaveFileDialog();
            guardar.FileName =DateTime.Now.ToString("ddMMyyyyHHmmss") + ".pdf";
            //guardar.ShowDialog();
            string paginaHtml = Properties.Resources.ReporteCierre.ToString();

            var FileName = DateTime.Now.ToString("ddMMyyyyHHmmss") + ".pdf";

           
            paginaHtml = paginaHtml.Replace("@CAJERO", "Oscar");

            if (guardar.ShowDialog() == DialogResult.OK)
            {
                using (FileStream stream = new FileStream(guardar.FileName, FileMode.Create))
                {
                    Document pdfDoc = new Document(PageSize.LETTER, 25, 25, 25, 25);
                    //pdfDoc.PageSize.Width
                    //BaseFont fuente;
                    //fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont;


                    //'Creamos una fuente
                    BaseFont fuente;
                    fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont;

                    PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);


                    //abrir el archivo
                    pdfDoc.Open();

                    //for(int i =0; i <=20000; i++)
                    //{


                    //    pdfDoc.Add(new Phrase("Oscar alcantara"));

                    //    // Escribimos el encabezamiento en el documento
                    //    pdfDoc.Add(new Paragraph("Mi primer documento PDF"));
                    //    pdfDoc.Add(Chunk.NEWLINE);
                    //    pdfDoc.Add (new Paragraph($"LINEA {i}"));
                    //}
                    //pdfDoc.Add(new Paragraph("Esta es la ultima linea"))


                    using (StringReader sr = new StringReader(paginaHtml))
                    {
                        XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
                    }

                    pdfDoc.Close();
                    stream.Close();
                }
            }
        }


        private void ImprimirReportePDF()
        {
            /*
             * 
             * https://www.youtube.com/watch?v=Z47eF35t7E8 */

            string path = AppDomain.CurrentDomain.BaseDirectory + "/Plantilla/";
            string pathHTMLPlantilla = path + "ReporteCierre.html";
            string paginaHtml = GetStringOfFile(pathHTMLPlantilla);//Properties.Resources.ReporteCierre.ToString();
                                
            

            var FileName = path +"Reporte_Cierre" + DateTime.Now.ToString("ddMMyyyyHHmmss") + ".pdf";

            paginaHtml = paginaHtml.Replace("@NOMBRE_TIENDA", viewModelCierre.Cierre_Pos.Cajero);
            paginaHtml = paginaHtml.Replace("@No. CIERRE", "Oscar");
            paginaHtml = paginaHtml.Replace("@CONSEC", "Oscar");
            paginaHtml = paginaHtml.Replace("@CAJA", "Oscar");
            paginaHtml = paginaHtml.Replace("@CAJERO", "Oscar");

            paginaHtml = paginaHtml.Replace("@BODEGA", "Oscar");
            paginaHtml = paginaHtml.Replace("@FECHA APERTURA", "Oscar");
            paginaHtml = paginaHtml.Replace("@CAJA", "Oscar");
            paginaHtml = paginaHtml.Replace("@FECHA_CIERRE", "Oscar");
            //Document pdfDoc = new Document(PageSize.LETTER, 10, 10, 10, 10);                                                                                         
            //PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);

            //writer.DirectContent.SetFontAndSize(bf, 16);

            //BaseFont bf = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, Encoding.UTF8.HeaderName, BaseFont.EMBEDDED);
            //writer.DirectContent.SetFontAndSize(bf, 8);

            var w = Utilities.MillimetersToPoints(216);
                var h = Utilities.MillimetersToPoints(4000);

                //Exporting HTML to PDF file.
                using (FileStream stream = new FileStream(path + "ReporteCierre.pdf", FileMode.Create))
                {
                    //Document(Recatngle(216, n))
                    Document pdfDoc = new Document(new iTextSharp.text.Rectangle(w, h), 10f, 10f, 10f, 0f);
                    PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);
                    pdfDoc.Open();
                    StringReader sr = new StringReader(paginaHtml);
                    XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
                    pdfDoc.Close();
                    stream.Close();
                }

                MessageBox.Show("PDF Generado", "Sistema COVENTAF");


            string print = GetDefaultPrintName();
                
            

        }


        void ImprimirReporte()
        {

            doc.PrinterSettings.PrinterName = doc.DefaultPageSettings.PrinterSettings.PrinterName;

            doc.PrintPage += new PrintPageEventHandler(ImprimirCierreCajero);            
            // Set the zoom to 25 percent.
            //this.PrintPreviewControl1.Zoom = 0.25;            
            //vista.Controls.Add(this.PrintPreviewControl1);

            vista.Document = doc;
            //doc.Print();
            vista.ShowDialog();
        }

        int numPagina = 1;       
        public void ImprimirCierreCajero(object sender, PrintPageEventArgs e)
        {

            int posX = 0, posY = 0;
            //en una linea son 40 caracteres.


            //Bahnschrift Light Condensed
            //Courier
            System.Drawing.Font fuente = new Font("Bahnschrift Light Condensed", 9, FontStyle.Regular);
            System.Drawing.Font fuenteRegular = new Font("Bahnschrift Light Condensed", 9, FontStyle.Regular);
            System.Drawing.Font fuenteRegular_7 = new Font("Bahnschrift Light Condensed", 9, FontStyle.Regular);
            //var ClientRectangle = new Point(4, 200);


            // Dim sfCenter As New StringFormat With _
            //{
            //     _
            //       .Alignment = StringAlignment.Near, _
            //       .LineAlignment = StringAlignment.Center _
            //}
            var sfCenter = new StringFormat()
            {
                Alignment = StringAlignment.Near,
                LineAlignment = StringAlignment.Center
            };

            StringFormat sf = new StringFormat();
            sf.LineAlignment = StringAlignment.Center;
            sf.Alignment = StringAlignment.Center;
                      

            try
            {
             
                    posX = 2;
                    e.Graphics.DrawString("EJERCITO DE NICARAGUA", fuente, Brushes.Black, posX + 53, posY);
                    posY += 15;
                    //TIENDA ELECTRODOMESTICO
                    if (User.TiendaID == "T01")
                    {
                        e.Graphics.DrawString(User.NombreTienda, fuente, Brushes.Black, posX + 45, posY);
                    }
                    else
                    {
                        e.Graphics.DrawString(User.NombreTienda, fuente, Brushes.Black, posX + 80, posY);
                    }

                    posX = 2;
                    posY += 20;
                    e.Graphics.DrawString("CIERRE DE CAJERO", fuente, Brushes.Black, posX + 53, posY);
                    posY += 20;

                    ////factura
                    posY += 24;
                    e.Graphics.DrawString($"No. CIERRE: { viewModelCierre.Cierre_Pos.Num_Cierre}", fuenteRegular, Brushes.Black, posX, posY);
                    posY += 15;
                    e.Graphics.DrawString($"CONSEC: { viewModelCierre.Cierre_Pos.Documento}", fuenteRegular, Brushes.Black, posX, posY);
                    posY += 15;
                    e.Graphics.DrawString($"CAJA: {viewModelCierre.Cierre_Pos.Caja}", fuenteRegular, Brushes.Black, posX, posY);
                    posY += 15;
                    e.Graphics.DrawString($"CAJERO: { viewModelCierre.Cierre_Pos.Cajero}", fuenteRegular, Brushes.Black, posX, posY);
                    posY += 15;
                    e.Graphics.DrawString($"BODEGA: { viewModelCierre.Cierre_Pos.Nombre_Vendedor}", fuenteRegular, Brushes.Black, posX, posY);
                    posY += 15;
                    e.Graphics.DrawString($"ESTADO: CERRADO", fuenteRegular, Brushes.Black, posX, posY);
                    posY += 15;
                    e.Graphics.DrawString($"FECHA APERTURA: { viewModelCierre.Cierre_Pos.Fecha_Hora_Inicio?.ToString("dd/MM/yyyy hh:mm tt")}", fuenteRegular, Brushes.Black, posX, posY);
                    posY += 15;
                    e.Graphics.DrawString($"FECHA CIERRE: { viewModelCierre.Cierre_Pos.Fecha_Hora.ToString("dd/MM/yyyy hh:mm tt")}", fuenteRegular, Brushes.Black, posX, posY);
                    posY += 15;
                    e.Graphics.DrawString($"TIPO CAMBIO: {viewModelCierre.Cierre_Pos.Tipo_Cambio.ToString("N2")}", fuenteRegular, Brushes.Black, posX, posY);


                    posY += 25;
                    e.Graphics.DrawString("_______________________________________________________________________________________________________", fuente, Brushes.Black, posX, posY);

                    posX = 2;
                    posY += 25;
                    e.Graphics.DrawString("TOTAL CORDOBAS EN CAJA:", fuenteRegular, Brushes.Black, posX, posY);
                    posX += 170;
                    e.Graphics.DrawString($"C$ {viewModelCierre.Cierre_Pos.Total_Local.ToString("N2")}", fuenteRegular, Brushes.Black, posX, posY);

                    posX = 2;
                    posY += 15;
                    e.Graphics.DrawString("TOTAL DOLAR EN CAJA:", fuenteRegular, Brushes.Black, posX, posY);
                    posX += 170;
                    e.Graphics.DrawString($"U$ {viewModelCierre.Cierre_Pos.Total_Dolar.ToString("N2")}", fuenteRegular, Brushes.Black, posX, posY);


                    posX = 2;
                    posY += 15;
                    e.Graphics.DrawString("MONTO APERTURA: ", fuenteRegular, Brushes.Black, posX, posY);
                    posX += 170;
                    e.Graphics.DrawString($"C$ {viewModelCierre.Cierre_Pos.Monto_Apertura.ToString("N2")}", fuenteRegular, Brushes.Black, posX, posY);

                    posX = 2;
                    posY += 25;
                    e.Graphics.DrawString("COBRO EFECTIVO CORDOBAS:", fuenteRegular, Brushes.Black, posX, posY);
                    posX += 170;
                    e.Graphics.DrawString($"C$ {viewModelCierre.Cierre_Pos.Ventas_Efectivo.ToString("N2")}", fuenteRegular, Brushes.Black, posX, posY);

                    posX = 2;
                    posY += 15;
                    e.Graphics.DrawString("COBRO EFECTIVO DOLAR:", fuenteRegular, Brushes.Black, posX, posY);
                    posX += 170;
                    e.Graphics.DrawString($"U$ {viewModelCierre.Cierre_Pos.Cobro_Efectivo_Rep.ToString("N2")}", fuenteRegular, Brushes.Black, posX, posY);


                    foreach (var item in viewModelCierre.Cierre_Det_Pago)
                    {
                        posY += 15;
                        posX = 2;
                        e.Graphics.DrawString(item.Tipo_Pago, fuenteRegular, Brushes.Black, posX, posY);

                        posX += 170;
                        e.Graphics.DrawString(item.Moneda == "L" ? $"C${item.Total_Sistema.ToString("N2")}" : $"U${item.Total_Sistema.ToString("N2")}", fuenteRegular, Brushes.Black, posX, posY);

                        posY += 15;
                        posX = 2;
                        e.Graphics.DrawString("REPORTADO: ", fuenteRegular, Brushes.Black, posX + 15, posY);

                        posX += 170;
                        e.Graphics.DrawString(item.Moneda == "L" ? $"C${item.Total_Usuario.ToString("N2")}" : $"U${item.Total_Usuario.ToString("N2")}", fuenteRegular, Brushes.Black, posX, posY);

                        posY += 15;
                        posX = 2;
                        e.Graphics.DrawString("DIFERENCIA: ", fuenteRegular, Brushes.Black, posX + 15, posY);

                        posX += 170;
                        e.Graphics.DrawString(item.Moneda == "L" ? $"C${item.Diferencia.ToString("N2")}" : $"U${item.Diferencia.ToString("N2")}", fuenteRegular, Brushes.Black, posX, posY);


                    }

                    posX = 2;
                    posY += 8;
                    e.Graphics.DrawString("_____________________________________________________________________________________", fuente, Brushes.Black, posX, posY);


                    posX = 2;
                    posY += 15;
                    e.Graphics.DrawString("TOTAL DIFERENCIA:", fuenteRegular, Brushes.Black, posX, posY);
                    posX += 140;
                    e.Graphics.DrawString($"C$ {viewModelCierre.Cierre_Pos.Total_Diferencia.ToString("N2")}", fuenteRegular, Brushes.Black, posX, posY);


                    posX = 2;
                    posY += 15;
                    e.Graphics.DrawString("DOCUMENTO AJUSTE:", fuenteRegular, Brushes.Black, posX, posY);
                    posX += 140;
                    e.Graphics.DrawString(viewModelCierre.Cierre_Pos.Documento_Ajuste, fuenteRegular, Brushes.Black, posX, posY);

                    posX = 2;
                    posY += 15;
                    e.Graphics.DrawString("NOTAS:", fuenteRegular, Brushes.Black, posX, posY);

                    posX = 2;
                    posY += 20;
                    e.Graphics.DrawString(viewModelCierre.Cierre_Pos.Notas, fuenteRegular, Brushes.Black, posX, posY);


                    posY += 200;
                    posX = 120;
                    e.Graphics.DrawString(" ", fuenteRegular, Brushes.Black, posX, posY);

                    numPagina += 1;
                    

                    posX = 2;
                    posY = 15;
                    //TIENDA ELECTRODOMESTICO
                    if (User.TiendaID == "T01")
                    {
                        e.Graphics.DrawString(User.NombreTienda, fuente, Brushes.Black, posX + 45, posY);
                    }
                    else
                    {
                        e.Graphics.DrawString(User.NombreTienda, fuente, Brushes.Black, posX + 80, posY);
                    }

                    posX = 2;
                    posY += 20;
                    e.Graphics.DrawString("DESGLOSE VENTAS CON TARJETA", fuente, Brushes.Black, posX + 53, posY);
                    posY += 20;


                    posY += 24;
                    e.Graphics.DrawString($"No. CIERRE: { viewModelCierre.Cierre_Pos.Num_Cierre}", fuenteRegular, Brushes.Black, posX, posY);
                    posY += 15;
                    e.Graphics.DrawString($"CAJA: {viewModelCierre.Cierre_Pos.Caja}", fuenteRegular, Brushes.Black, posX, posY);
                    posY += 15;
                    e.Graphics.DrawString($"CAJERO: { viewModelCierre.Cierre_Pos.Cajero}", fuenteRegular, Brushes.Black, posX, posY);
                    posY += 15;
                    e.Graphics.DrawString(viewModelCierre.Cierre_Pos.Nombre_Vendedor, fuenteRegular, Brushes.Black, posX, posY);
                    posY += 15;
                    e.Graphics.DrawString($"FECHA: { viewModelCierre.Cierre_Pos.Fecha_Hora.ToString("dd/MM/yyyy hh:mm:ss tt")}", fuenteRegular, Brushes.Black, posX, posY);
                    posY += 15;



                    // Check to see if more pages are to be printed.
                    //e.HasMorePages = true;

                    //// If there are no more pages, reset the string to be printed.
                    //if (!e.HasMorePages)
                    //    stringToPrint = documentContents;

                    var tarjetasAgrupad = from d in viewModelCierre.Cierre_Desg_Tarj
                                          group d by d.Tipo_Tarjeta into tabl_desglose
                                          select new
                                          {
                                              TipoTarjeta = tabl_desglose.Key,
                                              TotalMontoPorTarjeta = tabl_desglose.Sum(x => x.Monto),
                                              Cantidad = tabl_desglose.Count()
                                          };

                    foreach (var x in tarjetasAgrupad)
                    {
                        //obtengo el nombre de la tarjeta
                        var nombreTarjeta = x.TipoTarjeta;
                        var cantidad = x.Cantidad;
                        var totalMontoTarjet = x.TotalMontoPorTarjeta;

                        posY += 20;
                        e.Graphics.DrawString("_______________________________________________________________________________________________________", fuente, Brushes.Black, posX, posY);
                        posY += 15;
                        //imprimo el nombre de la tarjeta
                        e.Graphics.DrawString($"TARJETA     {nombreTarjeta}", fuenteRegular, Brushes.Black, posX, posY);
                        posY += 20;
                        e.Graphics.DrawString("_______________________________________________________________________________________________________", fuente, Brushes.Black, posX, posY);

                        posX = 2;
                        posY += 15;
                        e.Graphics.DrawString("Factura", fuenteRegular, Brushes.Black, posX, posY);
                        e.Graphics.DrawString("Monto", fuenteRegular, Brushes.Black, posX + 140, posY);

                        foreach (var item in viewModelCierre.Cierre_Desg_Tarj)
                        {
                            //mostrar las facturas y monto de la tarjeta
                            if (item.Tipo_Tarjeta == nombreTarjeta)
                            {
                                posX = 2;
                                posY += 15;
                                //imprimir el numero de factura
                                e.Graphics.DrawString(item.Documento, fuenteRegular, Brushes.Black, posX, posY);
                                //imprimir el monto de la factura
                                e.Graphics.DrawString(item.Monto.ToString("N2"), fuenteRegular, Brushes.Black, posX + 140, posY);
                            }
                        }

                        posY += 15;
                        //imprimo el nombre de la tarjeta
                        e.Graphics.DrawString($"TOTAL      {nombreTarjeta}", fuenteRegular, Brushes.Black, posX, posY);
                        e.Graphics.DrawString(totalMontoTarjet.ToString("N2"), fuenteRegular, Brushes.Black, posX + 140, posY);
                        posY += 15;



                        // Check to see if more pages are to be printed.
                        //e.HasMorePages = true;



                        //if (line != null)os
                        //    e.HasMorePages = true;
                        //else
                        //    e.HasMorePages = false;



                

                    }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


        private void GenerarPDFConRazor()
        {

            //2do paso aplicando Razor y Haciendo Html a PDF
            string path = AppDomain.CurrentDomain.BaseDirectory + "/Plantilla/";
            string pathHTMLTemp = path + "miHtml.html"; //temporal
            string pathHTMLPlantilla = path + "ReporteCierre.html";
            string sHtml = GetStringOfFile(pathHTMLPlantilla);
            string resultHtml = "";

            resultHtml = RazorEngine.Razor.Parse(sHtml, viewModelCierre);

            //creamos el archivo temporal
           /* System.IO.File.WriteAllText(pathHTMLTemp, resultHtml);

            string pathWKHTMTOPDF = @"C:\Users\alcantara\Desktop\coventaf_desk4.7\Api.COVENTAF\COVENTAF\bin\Debug\wkhtmltopdf\wkhtmltopdf.exe";

            ProcessStartInfo oProcessStartInfo = new ProcessStartInfo();
            oProcessStartInfo.UseShellExecute = false;
            oProcessStartInfo.FileName = pathWKHTMTOPDF;
            oProcessStartInfo.Arguments = "miHtml.html mipdf.pdf";


            using (Process oProcess = Process.Start(oProcessStartInfo))
            {
                oProcess.WaitForExit();
            }*/

            //eliminar el archivo Temporal
            System.IO.File.Delete(pathHTMLTemp);
        }

        private void GenerarPDFConRazor_2()
        {

            //2do paso aplicando Razor y Haciendo Html a PDF
            string path = AppDomain.CurrentDomain.BaseDirectory + "/Plantilla/";
            string pathHTMLTemp = path + "miHtml.html";
            string pathHTMLPlantilla = path + "ReporteCierre.html";
            string sHtml = GetStringOfFile(pathHTMLPlantilla);
            string resultHtml = "";

            resultHtml = RazorEngine.Razor.Parse(sHtml, viewModelCierre);

            //Creating Folder for saving PDF.
            string folderPath = "C:\\PDFs\\";
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }



           // iTextSharp.text.Rectangle rectangle = new iTextSharp.text.Rectangle(216, 80000);
            var w = Utilities.MillimetersToPoints(216);
            var h = Utilities.MillimetersToPoints(4000);

            //Exporting HTML to PDF file.
            using (FileStream stream = new FileStream(folderPath + "DataGridViewExport.pdf", FileMode.Create))
            {
                //Document(Recatngle(216, n))
                Document pdfDoc = new Document(new iTextSharp.text.Rectangle(w, h), 10f, 10f, 10f, 0f);
                PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);
                pdfDoc.Open();
                StringReader sr = new StringReader(resultHtml);
                XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
                pdfDoc.Close();
                stream.Close();
            }

            MessageBox.Show("PDF Generado", "Sistema COVENTAF");

            /*

            //creamos el archivo temporal
            System.IO.File.WriteAllText(pathHTMLTemp, resultHtml);

            string pathWKHTMTOPDF = @"C:\Users\alcantara\Desktop\coventaf_desk4.7\Api.COVENTAF\COVENTAF\bin\Debug\wkhtmltopdf\wkhtmltopdf.exe";

            ProcessStartInfo oProcessStartInfo = new ProcessStartInfo();
            oProcessStartInfo.UseShellExecute = false;
            oProcessStartInfo.FileName = pathWKHTMTOPDF;
            oProcessStartInfo.Arguments = "miHtml.html mipdf.pdf";


            using (Process oProcess = Process.Start(oProcessStartInfo))
            {
                oProcess.WaitForExit();
            }
            */
            //eliminar el archivo Temporal
            System.IO.File.Delete(pathHTMLTemp);



        }

        private static string GetStringOfFile(string pahtFile)
        {
            string contenido = File.ReadAllText(pahtFile);
            return contenido;
        }

        private string GetDefaultPrintName()
        {
            PrintDocument printDocument = new PrintDocument();          
            var defaultPrinter = printDocument.PrinterSettings.PrinterName;
        
            return defaultPrinter;
        }

        public void ImprimirPDF(string nombreArchivo, string nombreImpresora)
        {
            //libreria RawPrint Para imprimir
            // Crea la instancia de la impresora
            IPrinter printer = new Printer();
            // Imprime el archivo
            printer.PrintRawFile(nombreImpresora, nombreArchivo);
        }


        //        private impresionDirecta()
        //        {
        ////            Dim psi As System.Diagnostics.ProcessStartInfo = New System.Diagnostics.ProcessStartInfo()
        ////psi.UseShellExecute = True
        ////psi.Verb = "print"
        ////psi.FileName = "Documento.pdf"
        ////psi.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden
        ////psi.ErrorDialog = False
        ////psi.Arguments = "/p"
        ////Dim p As System.Diagnostics.Process = System.Diagnostics.Process.Start(psi)
        ////p.WaitForInputIdle()
        //        }


    }
}