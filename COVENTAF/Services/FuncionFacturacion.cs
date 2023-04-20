using Api.Model.Modelos;
using Api.Model.ViewModels;

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace COVENTAF.Services
{
    public class FuncionFacturacion
    {

        //asignar datos del cliente para mostrarlo en HTML
        public void asignarDatoClienteParaVisualizarHtml(Clientes datosCliente, VariableFact listVarFactura)
        {
            //nombre del cliente
            listVarFactura.NombreCliente = datosCliente.Nombre;
            //saldo disponible del cliente del descuento
            listVarFactura.SaldoDisponible = Convert.ToDecimal(datosCliente.U_U_SaldoDisponible is null ? 0.00M : datosCliente.U_U_SaldoDisponible);
            //porcentaje del cliente
            listVarFactura.PorcentajeDescCliente = Convert.ToDecimal(datosCliente.U_U_Descuento is null ? 0.00M : datosCliente.U_U_Descuento);
            listVarFactura.PorcentajeDescGeneral = 0.00M;
        }

        public void inicializarDatosClienteParaVisualizarHTML(VariableFact listVarFactura)
        {
            //nombre del cliente
            listVarFactura.NombreCliente = "********";
            //saldo disponible del cliente
            listVarFactura.SaldoDisponible = 0;
            //el porcentaje del cliente, descrito 5.20 %
            listVarFactura.PorcentajeDescCliente = 0.00M;
            listVarFactura.PorcentajeDescGeneral = 0.00M;
        }


        //toma de decision del sistema si obtiene descuento de Linea del producto o el descuento del Beneficio
        string getValorDescuentoDelBeneficiario(VariableFact listVarFactura, bool descuentoSobreDescuento)
        {
            string valor = "";

            if (descuentoSobreDescuento)
                valor = "Descuento_DSD";
            //si el saldo disponible del cliente es mayor que cero
            else if (listVarFactura.SaldoDisponible > 0)
                valor = "Descuento_Beneficio";
            else
                valor = "Descuento_Linea";

            /*
          //si es Descuento_DSD or Descuento_Beneficio y tiene saldo disponible y el metodo montoDescuentoBeneficioIsOk no es Ok entonces cambia automanticamente de descuento
          if (((valor == "Descuento_DSD") || (valor =="Descuento_Beneficio")) && (SaldoDisponible !=0) && (!this.montoDescuentoBeneficioIsOk(SaldoDisponible, descuentoFactura)))
            valor="Descuento_Linea";*/

            return valor;
        }



        /* 0001	EFECTIVO, 0002	CHEQUE, 0003	TARJETA, 0004 CREDITO*/
        //este metodo verifica si tiene derecho al descuento 
        public decimal obtenerDescuento(Clientes datoCliente, string formaPago)
        {
            decimal descuento = 0.000M;

            ///si eres militar entonces tiene derecho descuento independientemente si es al credito
            if (datoCliente.U_EsMilitar == "S")
            {
                descuento = Convert.ToDecimal(datoCliente.U_U_Descuento);

            }
            //si eres empleado y la forma de pago no es al credito (0004) entonces tienes derecho al descuento
            else if (datoCliente.U_EsEmpleado == "S" && formaPago != "0004")
            {
                descuento = Convert.ToDecimal(datoCliente.U_U_Descuento);
            }

            return descuento;
        }

        //verificar si el cliente paga IVA
        public decimal obtenerIVA(Clientes datosCliente)
        {
            var IVA = 0.0000M;

            if (datosCliente.Codigo_Impuesto == "IVA")
            {
                IVA = 0.15M;
            }

            return IVA;
        }


        //  
        bool aplicaMontoParaDescuento(Clientes datosCliente, decimal monto)
        {
            bool aplicarDescuento = false;

            if (monto > datosCliente.U_MontoInicial)
            {
                aplicarDescuento = true;
            }

            return aplicarDescuento;
        }

        //verificar si debes de activar la linea de descuento o desactivar la linea de descuento
        bool DescuentoLineaActivoIsOk(string descBeneficioOrDescLinea)
        {
            if (descBeneficioOrDescLinea == "Descuento_Linea" || descBeneficioOrDescLinea == "Descuento_DSD")
                return true;
            else
                return false;
        }



        /// <summary>
        /// inicializar todas las variables
        /// </summary>
        /// <param name="listVarFactura"></param>
        public void InicializarTodaslasVariable(VariableFact listVarFactura)
        {
            listVarFactura.TotalRetencion = 0;      
            //indica si el descuento esta aplicado o no esta aplicado
            listVarFactura.DescuentoActivo = true;
            //descuento que el cliente
            listVarFactura.TipoDeCambio = 0.0000M;
            listVarFactura.BodegaId = "";

            /**Totales */
            listVarFactura.SubTotalDolar = 0.0000M;
            listVarFactura.SubTotalCordoba = 0.0000M;
            //descuento
            listVarFactura.DescuentoPorLineaDolar = 0.0000M;
            listVarFactura.DescuentoPorLineaCordoba = 0.0000M;
            listVarFactura.DescuentoGeneralCordoba = 0.0000M;

            //descuento General
            listVarFactura.DescuentoGeneralDolar = 0.0000M;
            listVarFactura.DescuentoGeneralCordoba = 0.0000M;

            //subtotales 
            listVarFactura.SubTotalDescuentoDolar = 0.0000M;
            listVarFactura.SubTotalDescuentoCordoba = 0.0000M;
            listVarFactura.IvaCordoba = 0.0000M;
            listVarFactura.IvaDolar = 0.0000M;
            listVarFactura.TotalDolar = 0.0000M;
            listVarFactura.TotalCordobas = 0.0000M;
            listVarFactura.TotalUnidades = 0.0000M;
            //fecha de hoy
            listVarFactura.FechaFactura = DateTime.Now;
        }

        public bool DesactivarBotonVerificarDescuento(VariableFact listVarFactura, List<DetalleFactura> detalleFactura, string forma_Pago)
        {
            //verifico que existe el cliente y si existe almenos un codigo de barra
            if ((listVarFactura.NombreCliente.Length > 0) && (detalleFactura[0].CodigoBarra.Length > 0) && (forma_Pago.Length > 0))
                return true;
            else
                return false;
        }

        //validar el boton validar descuento
        public string ValidarAntesActivarBotonValidarDesc(VariableFact listVarFactura, List<DetalleFactura> detalleFactura, string forma_Pago, string tipoTarjeta, string condicionPago)
        {
            //si la validacion esta correcta entonces devuelve un OK
            string mensaje = "OK";
            string drownListVisible = "";

            if (forma_Pago == "0003")
                drownListVisible = "tipo_tarjeta";

            else if (forma_Pago == "0004")
                drownListVisible = "condicion_pago";


            //comprobar si tiene el 
            if (listVarFactura.NombreCliente.Length == 0)
            {
                mensaje = "Debes de ingresar el codigo del cliente";
            }
            //verificar si almenos la primer fila del detalle de la factura tiene un producto
            else if (detalleFactura.Count == 0)
                mensaje = "Debes de ingresar al menos un articulo";

            //verificar si es tarjeta y el tipo de tarjeta es igual al vacio
            else if ((forma_Pago == "0003") && (tipoTarjeta.Length == 0) && (drownListVisible == "tipo_tarjeta"))
                mensaje = "Debes de seleccionar el tipo de tarjeta";

            //verificar si es credito y la condicion de pago es igual al vacio
            else if ((forma_Pago == "0004") && (condicionPago.Length == 0) && drownListVisible == "condicion_pago")
                mensaje = "Debes de seleccionar la condicion de pago";

            return mensaje;
        }

        //inicializar las variables totales
        public void InicializarVariableTotales(VariableFact listVarFactura)
        {
            /**Totales */
            listVarFactura.SubTotalDolar = 0.0000M; listVarFactura.SubTotalCordoba = 0.0000M;
            //descuento
            listVarFactura.DescuentoPorLineaDolar = 0.0000M; listVarFactura.DescuentoPorLineaCordoba = 0.0000M;
            //descuento general
            listVarFactura.DescuentoGeneralCordoba = 0.0000M; listVarFactura.DescuentoGeneralDolar = 0.0000M;
            //subtotales 
            listVarFactura.SubTotalDescuentoDolar = 0.0000M; listVarFactura.SubTotalDescuentoCordoba = 0.0000M;
            //iva
            listVarFactura.IvaCordoba = 0.0000M; listVarFactura.IvaDolar = 0.0000M;
            //total
            listVarFactura.TotalDolar = 0.0000M; listVarFactura.TotalCordobas = 0.0000M;
            listVarFactura.TotalUnidades = 0.0000M;
        }


        public void configurarDataGridView(DataGridView dgvDetalleFactura)
        {
            dgvDetalleFactura.Columns["Consecutivo"].Visible = false;


            dgvDetalleFactura.Columns["Consecutivo"].ReadOnly = true;
            dgvDetalleFactura.Columns["ArticuloId"].ReadOnly = true;
            dgvDetalleFactura.Columns["codigoBarra"].ReadOnly = true;
            dgvDetalleFactura.Columns["Descripcion"].ReadOnly = true;
            dgvDetalleFactura.Columns["Unidad"].ReadOnly = true;
            dgvDetalleFactura.Columns["CantidadExistencia"].ReadOnly = true;
            dgvDetalleFactura.Columns["UnidadFraccion"].ReadOnly = true;
            dgvDetalleFactura.Columns["PrecioDolar"].ReadOnly = true;
            dgvDetalleFactura.Columns["PrecioCordobas"].ReadOnly = true;
            dgvDetalleFactura.Columns["Moneda"].ReadOnly = true;
            dgvDetalleFactura.Columns["BodegaID"].ReadOnly = true;
            dgvDetalleFactura.Columns["NombreBodega"].ReadOnly = true;
            dgvDetalleFactura.Columns["CantidadExistencia"].ReadOnly = true;
            dgvDetalleFactura.Columns["SubTotalDolar"].ReadOnly = true;
            dgvDetalleFactura.Columns["SubTotalCordobas"].ReadOnly = true;
            dgvDetalleFactura.Columns["DescuentoPorLineaDolar"].ReadOnly = true;
            dgvDetalleFactura.Columns["DescuentoPorLineaCordoba"].ReadOnly = true;
            dgvDetalleFactura.Columns["MontoDescGeneralCordoba"].ReadOnly = true;
            dgvDetalleFactura.Columns["MontoDescGeneralDolar"].ReadOnly = true;
            dgvDetalleFactura.Columns["TotalDolar"].ReadOnly = true;
            dgvDetalleFactura.Columns["TotalCordobas"].ReadOnly = true;


            //dgvDetalleFactura.Columns["PrecioDolar"].ReadOnly = true;
            //dgvDetalleFactura.Columns["PrecioCordobas"].ReadOnly = true;
            //dgvDetalleFactura.Columns["Moneda"].ReadOnly = true;
            //dgvDetalleFactura.Columns["BodegaID"].ReadOnly = true;
            //dgvDetalleFactura.Columns["NombreBodega"].ReadOnly = true;
            //dgvDetalleFactura.Columns["CantidadExistencia"].ReadOnly = true;
            //dgvDetalleFactura.Columns["SubTotalDolar "].ReadOnly = true;

            //dgvDetalleFactura.Columns["InputArticuloDesactivado"].Visible = false;
            dgvDetalleFactura.Columns["Moneda"].Visible = false;
            //dgvDetalleFactura.Columns["inputCantidadDesactivado"].Visible = false;
            //dgvDetalleFactura.Columns["inputCantidadDesactivado"].Visible = false;
            //dgvDetalleFactura.Columns["descuentoInactivo"].Visible = false;
            dgvDetalleFactura.Columns["MontoDescGeneralCordoba"].Visible = false;
            dgvDetalleFactura.Columns["MontoDescGeneralDolar"].Visible = false;
            //dgvDetalleFactura.Columns["inputActivoParaBusqueda"].Visible = false;
            //dgvDetalleFactura.Columns["botonEliminarDesactivado"].Visible = false;
            dgvDetalleFactura.Columns["BodegaID"].Visible = false;
            dgvDetalleFactura.Columns["NombreBodega"].Visible = false;
            //dgvDetalleFactura.Columns["Cantidad"].Name = "txtCantidad";
            //dgvDetalleFactura.Columns["PorCentajeDescXArticulo"].Name = "txtPorCentajeDescuento";

            dgvDetalleFactura.Columns["TotalDolar"].HeaderText = "Total U$";
            dgvDetalleFactura.Columns["DescuentoPorLineaDolar"].HeaderText = "Descuento U$";
            dgvDetalleFactura.Columns["PrecioDolar"].HeaderText = "Precio U$";
            dgvDetalleFactura.Columns["CodigoBarra"].HeaderText = "Codigo Barra";
            dgvDetalleFactura.Columns["Descripcion"].HeaderText = "Descripcion";
            dgvDetalleFactura.Columns["Cantidad"].HeaderText = "Cantidad";
            dgvDetalleFactura.Columns["CantidadExistencia"].HeaderText = "Existencia";
            dgvDetalleFactura.Columns["PrecioCordobas"].HeaderText = "Precio C$";
            dgvDetalleFactura.Columns["DescuentoPorLineaCordoba"].HeaderText = "Descuento C$";
            dgvDetalleFactura.Columns["SubTotalCordobas"].HeaderText = "Sub Total C$";
            dgvDetalleFactura.Columns["PorCentajeDescXArticulo"].HeaderText = "Descuento %";
            dgvDetalleFactura.Columns["TotalCordobas"].HeaderText = "Total C$";

            //dgvDetalleFactura.Columns[24].Name = "cantidadd";
            //dgvDetalleFactura.Columns[25].Name = "descuentod";

        }

        /// <summary>
        /// quitar el simbolo del % 
        /// </summary>
        /// <param name="cadena"></param>
        /// <param name="existeCaractePorcentaje"></param>
        /// <returns></returns>
        public string QuitarSimboloPorCentaje(string cadena, ref bool existeCaractePorcentaje)
        {
           // string caracter = "";
            string nuevaCadena = cadena.Replace("%", "");
            //for (int n = 0; n < cadena.Length; n++)
            //{
            //    caracter = cadena.Substring(n, 1);
            //    if (caracter == "%")
            //    {
            //        existeCaractePorcentaje = true;
            //        break;
            //    }
            //    else
            //    {
            //        nuevaCadena += caracter;
            //    }
            //}

            return nuevaCadena;
        }

        public bool CantidadIsValido(string cantidad, bool IsPermitodFraccion, ref string Mensaje)
        {
            bool isValido = false;
            //comprobar que el primer caracter es un digito
            if (char.IsDigit(cantidad[0]))
            {
                int contadorPuntoDecimal = 0;
                bool caracterInvalido = false;
                bool puntoDecimalIdentificado = false;
                //bool tieneCeroDespuesDecimal = false;
                bool tieneNumDespuesDecimal = false;

                foreach (var caracter in cantidad)
                {
                    //verificar si es un punto decimal
                    if (caracter == '.')
                    {
                        contadorPuntoDecimal += 1;
                        puntoDecimalIdentificado = true;
                        continue;
                    }
                    //comprobar si no es un digito
                    else if (!(char.IsDigit(caracter)))
                    {
                        //aqui identifica q se encontro un caracter invalido. (am-+%)
                        caracterInvalido = true;
                        //detener el ciclo
                        break;
                    }

                    //una vez identificado el punto decimal el sistema verifica q los siguientes caracteres sean digitos para la parte decimal
                    if (puntoDecimalIdentificado)
                    {

                        //comprobar si es un cero
                        if (caracter == '0')
                        {
                            continue;
                        }
                        else
                        {
                            tieneNumDespuesDecimal = true;
                        }
                    }
                }

                //identificar si encontro mas de 2 punto decimales(ej.. 2.5.6)
                if (contadorPuntoDecimal >= 2)
                {
                    Mensaje = "La cantidad digitada tiena mas de un punto decimal";
                }
                //comprobar si tiene caracter invalido
                else if (caracterInvalido)
                {
                    Mensaje = "La cantidad digitada tiene caracter invalido";
                }
                else if (tieneNumDespuesDecimal && !IsPermitodFraccion)
                {
                    Mensaje = "La unidad de medida para este articulo no permite cantidades con decimales";
                }
                else
                {
                    isValido = true;
                }
            }
            else
            {
                Mensaje = "La cantidad tiene caracteres inválidos";
            }

            return isValido;
        }

        public bool PorCentajeIsValido(string cantidad, ref string Mensaje)
        {
            bool isValido = false;
            //comprobar que el primer caracter es un digito
            if (char.IsDigit(cantidad[0]))
            {
                int contadorPuntoDecimal = 0;
                bool caracterInvalido = false;


                foreach (var caracter in cantidad)
                {
                    //verificar si es un punto decimal
                    if (caracter == '.')
                    {
                        contadorPuntoDecimal += 1;
                        continue;
                    }
                    //comprobar si no es un digito
                    else if (!(char.IsDigit(caracter)))
                    {
                        //aqui identifica q se encontro un caracter invalido. (am-+%)
                        caracterInvalido = true;
                        //detener el ciclo
                        break;
                    }
                
                }

                //identificar si encontro mas de 2 punto decimales(ej.. 2.5.6)
                if (contadorPuntoDecimal >= 2)
                {
                    Mensaje = "Has digitado mas de un punto decimal";
                }
                //comprobar si tiene caracter invalido
                else if (caracterInvalido)
                {
                    Mensaje = "El Porcentaje del descuento tiene caracter inválido";
                }
                else
                {
                    isValido = true;
                }
            }
            else
            {

                Mensaje = "El Porcentaje del descuento tiene caracter inválido";
            }

            return isValido;
        }

        /// <summary>
        /// calcula el nuevo porcenta para el descuento del cliente
        /// </summary>
        /// <param name="subTotal"></param>
        /// <param name="techoDisponibleDescuento"></param>
        /// <returns></returns>
        public decimal CalcularNuevoPorCentajeDescuentoGeneral(decimal subTotal, decimal techoDisponibleDescuento, decimal PorCentajeDescGeneral, ref int cantidadDecimal)
        {
            decimal nuevoPorCentajeDescuento = 0;
            cantidadDecimal = 2;

            //hacer una regla de 3

            //                subTotal = 100%
            //techoDisponibleDescuento = X 

            try
            {
                //comprobar si el subtotal es mayo que cero para evita division entre cero                                
                if (subTotal > 0)
                {
                    nuevoPorCentajeDescuento = Utilidades.RoundApproximate(((techoDisponibleDescuento * 100) / subTotal), 8);
                    //validar que el descuento no se un valor negativo
                    nuevoPorCentajeDescuento = nuevoPorCentajeDescuento < 0 ? 0 : nuevoPorCentajeDescuento;

                    if (nuevoPorCentajeDescuento >0 && nuevoPorCentajeDescuento <1)
                    {
                        cantidadDecimal = ObtenerCantidesDecimales(nuevoPorCentajeDescuento.ToString());
                    }

                }
                else
                {
                    //dejo el mismo porcentaje
                    nuevoPorCentajeDescuento = PorCentajeDescGeneral;
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return nuevoPorCentajeDescuento;
        }

        public bool PorcentajeDescuentoEsValido(char caracter, string cadena)
        {
            bool isValido = false;
            int contadorPuntoDecimal = 0;

            //verificar si es un punto decimal
            if (caracter == '.')
            {
                isValido = true;
                contadorPuntoDecimal += 1;
            }

            if (char.IsDigit(caracter))
            {
                isValido = true;
            }
            if (char.IsControl(caracter))
            {
                isValido = true;
            }
            if (caracter == ' ')
            {
                isValido = false;
            }

            foreach (var newCaracter in cadena)
            {
                //contar cuantos punto decimal tiene la cadena
                if (newCaracter == '.') contadorPuntoDecimal += 1;
            }

            if (contadorPuntoDecimal > 1)
            {
                isValido = false;
            }

            return isValido;
        }
        private int ObtenerCantidesDecimales(string cadenaPorcentaje)
        {
            int contadorCero = 0;
            bool puntoLocalizado = false;
            foreach(var digit in cadenaPorcentaje)
            {
                //
                if (digit =='.')
                {
                    puntoLocalizado = true;
                    
                }
                //verificar si ya se localizo el punto decimal
                else if (puntoLocalizado)
                {
                    contadorCero += 1;

                    if (digit != '0') break;
                }           
            }

            return contadorCero;
        }



        public bool ModificarAutomatPorcentaDescuento(decimal techoDescuento, decimal descuentoGeneralCordoba)
        {
            decimal restaMontos = techoDescuento - descuentoGeneralCordoba;           
            //comprobar si el techo del descuento esta en negativo 
            if (techoDescuento < 0)
            {
                //indico al sistema que no haga modificacion tel descuento
                return false;
            }
            else if (descuentoGeneralCordoba < 0)
            {
                return false;
            }
            //si el monto es negativo entonces proceder el sistema a modificar el % del c
            else if (restaMontos <= -1)
            {
                return true;
            }
            else
            {
                return false;
            }

        }



        private PrintDocument doc = new PrintDocument();
        private PrintPreviewDialog vista = new PrintPreviewDialog();
        // Construct the PrintPreviewControl.
        PrintPreviewControl PrintPreviewControl1 = new PrintPreviewControl();

        private List<DetalleFactura> _listDetFactura;
        private List<DetallePagosPos> _listMetodoPago;
        private Encabezado _encabezadoFact;


        public void ImprimirTicketFactura(List<DetalleFactura> listDetFactura, Encabezado encabezadoFact,   List<DetallePagosPos> viewModelMetodoPago )
        {
            this._listDetFactura = new List<DetalleFactura>();
            this._listMetodoPago = new List<DetallePagosPos>();
            this._listDetFactura = listDetFactura;
            this._listMetodoPago = viewModelMetodoPago;
            this._encabezadoFact = new Encabezado();
            this._encabezadoFact = encabezadoFact;
            
            doc.PrinterSettings.PrinterName = doc.DefaultPageSettings.PrinterSettings.PrinterName;

            doc.PrintPage += new PrintPageEventHandler(ImprimirTicket);
            // Set the zoom to 25 percent.
            //this.PrintPreviewControl1.Zoom = 0.25;            
            //vista.Controls.Add(this.PrintPreviewControl1);

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



        public void ImprimirTicket(object sender, PrintPageEventArgs e)
        {

            //en una linea son 40 caracteres.


            int posX=0, posY=0;
            //Font fuente = new Font("consola", 8, FontStyle.Bold);
            //Font fuenteRegular = new Font("consola", 8, FontStyle.Regular);
            //Font fuenteRegular_7 = new Font("consola", 7, FontStyle.Regular);

            //Tahoma
            //Bahnschrift Light Condensed
            Font fuente = new Font("Tahoma", 8, FontStyle.Bold);
            Font fuenteRegular = new Font("Tahoma", 8, FontStyle.Regular);
            Font fuenteRegular_7 = new Font("Tahoma", 7, FontStyle.Regular);
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

            //convertir el registro en arreglo

           

            try
            {
                posX = 2;
                //posY += 20;
                e.Graphics.DrawString("EJERCITO DE NICARAGUA", fuente, Brushes.Black, posX + 53, posY);
                // posY += 15;


                // e.Graphics.DrawString("EJERCITO DE NICARAGUA", fuente, Brushes.Black, ClientRectangle, sf);
                //ImprimirPorReferenciaCaracter(e, User.NombreTienda, fuente, ref posX, 45, ref posY, 15);
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

                ImprimirPorReferenciaCaracter(ref e, User.DireccionTienda, fuente, ref posX, 20, ref posY, 15);


                //posY += 15;
                //e.Graphics.DrawString(direccion2, fuente, Brushes.Black, posX + 80, posY);
                //posY += 15;
                //e.Graphics.DrawString("Managua, Nicaragua", fuente, Brushes.Black, posX + 80, posY);
                posY += 15;
                e.Graphics.DrawString($"Tel.: {User.TelefonoTienda}", fuente, Brushes.Black, posX + 60, posY);

                posY += 15;
                e.Graphics.DrawString("N° RUC: J1330000001272", fuente, Brushes.Black, posX + 55, posY);

                //factura
                posY += 24;
                e.Graphics.DrawString("N° Factura: " + _encabezadoFact.NoFactura, fuenteRegular, Brushes.Black, posX, posY);
                posY += 15;
                e.Graphics.DrawString("Codigo Cliente: " + _encabezadoFact.codigoCliente, fuenteRegular, Brushes.Black, posX, posY);
                posY += 15;
                e.Graphics.DrawString("Cliente: " + _encabezadoFact.cliente, fuenteRegular, Brushes.Black, posX, posY);
                posY += 15;
                e.Graphics.DrawString("Fecha: " + _encabezadoFact.fecha, fuenteRegular, Brushes.Black, posX, posY);
                posY += 15;
                e.Graphics.DrawString("Bodega: " + _encabezadoFact.bodega, fuenteRegular, Brushes.Black, posX, posY);
                posY += 15;
                e.Graphics.DrawString("Caja: " + _encabezadoFact.caja, fuenteRegular, Brushes.Black, posX, posY);
                posY += 15;
                e.Graphics.DrawString("Tipo Cambio: " + _encabezadoFact.tipoCambio.ToString("N2"), fuenteRegular, Brushes.Black, posX, posY);
                posY += 18;
                e.Graphics.DrawString("-------------------------------------------------------------------------", fuente, Brushes.Black, posX, posY);
                posY += 10;
                e.Graphics.DrawString("Codigo", fuente, Brushes.Black, posX, posY);
                //posY += 15;
                posX += 60;
                e.Graphics.DrawString("Cant", fuente, Brushes.Black, posX, posY);
                //posY += 15;
                posX += 50;
                e.Graphics.DrawString("Precio", fuente, Brushes.Black, posX, posY);
                // posY += 15;
                posX += 50;
                e.Graphics.DrawString("Desc", fuente, Brushes.Black, posX, posY);
                //posY += 15;
                posX += 55;
                e.Graphics.DrawString("Monto", fuente, Brushes.Black, posX, posY);
                posY += 10;
                //reiniciar la posicionX
                posX = 2;
                e.Graphics.DrawString("-------------------------------------------------------------------------", fuente, Brushes.Black, posX, posY);



                //e.Graphics.DrawString("8721160000939", fuenteRegular, Brushes.Black, posX, posY);
                //_listDetFactura

                foreach (var detalleFactura in _listDetFactura)
                {
                    posY += 10;
                    e.Graphics.DrawString(detalleFactura.ArticuloId, fuenteRegular, Brushes.Black, posX, posY);

                    posX += 60;
                    e.Graphics.DrawString(detalleFactura.Cantidad_d.ToString("N2"), fuenteRegular, Brushes.Black, posX, posY);

                    posX += 45;
                    e.Graphics.DrawString(detalleFactura.PrecioCordobas.ToString("N2"), fuenteRegular, Brushes.Black, posX, posY);

                    posX += 60;
                    e.Graphics.DrawString(Convert.ToDecimal(detalleFactura.DescuentoPorLineaCordoba).ToString("N2"), fuenteRegular, Brushes.Black, posX, posY);

                    posX += 50;
                    e.Graphics.DrawString(detalleFactura.TotalCordobas.ToString("N2"), fuenteRegular, Brushes.Black, posX, posY);

                    //salto a la siguiente linea
                    posY += 15;
                    posX = 2;
                    e.Graphics.DrawString(detalleFactura.Descripcion, fuenteRegular_7, Brushes.Black, posX, posY);

                    posY += 7;

                }

                posY += 5;
                e.Graphics.DrawString("-------------------------------------------------------------------------", fuente, Brushes.Black, posX, posY);

                posY += 15;
                posX = 2;
                posX += 140;
                e.Graphics.DrawString("Sub Total:", fuente, Brushes.Black, posX, posY);


                posX += 65;
                e.Graphics.DrawString("C$ " + _encabezadoFact.subTotalCordoba.ToString("N2"), fuenteRegular, Brushes.Black, posX, posY);



                posY += 15;
                posX = 2;
                posX += 140;
                e.Graphics.DrawString("Descuento:", fuente, Brushes.Black, posX, posY);

                posX += 65;
                e.Graphics.DrawString("C$ " + _encabezadoFact.descuentoCordoba.ToString("N2"), fuenteRegular, Brushes.Black, posX, posY);

                /************************* RETENCIONES ************************************************************************/
                if (_encabezadoFact.MontoRetencion > 0)
                {
                    posY += 15;
                    posX = 2;
                    posX += 140;
                    e.Graphics.DrawString("Retencion:", fuente, Brushes.Black, posX, posY);

                    posX += 65;
                    e.Graphics.DrawString("C$ " + _encabezadoFact.MontoRetencion.ToString("N2"), fuenteRegular, Brushes.Black, posX, posY);
                }
                /****************************************************************************************************************/


                posY += 15;
                posX = 2;
                posX += 140;
                e.Graphics.DrawString("IVA:", fuente, Brushes.Black, posX, posY);

                posX += 65;
                e.Graphics.DrawString("C$ " + _encabezadoFact.ivaCordoba.ToString("N2"), fuenteRegular, Brushes.Black, posX, posY);

                posY += 15;
                posX = 2;
                posX += 140;
                e.Graphics.DrawString("Total a Pagar:", fuente, Brushes.Black, posX, posY);

                posX += 65;
                e.Graphics.DrawString("C$ " + _encabezadoFact.totalCordoba.ToString("N2"), fuenteRegular, Brushes.Black, posX, posY);


                posY += 15;
                posX = 2;
                posX += 140;
                e.Graphics.DrawString("Total a Pagar:", fuente, Brushes.Black, posX, posY);

                posX += 65;
                e.Graphics.DrawString("U$ " + _encabezadoFact.totalDolar.ToString("N2"), fuenteRegular, Brushes.Black, posX, posY);

                /************************************************************************************/
                string[] stringSeparators = new string[] { "\r\n" };

                //convertir el registro en arreglo
                //string[] newformaDePago = _encabezadoFact.formaDePago.Split(stringSeparators, StringSplitOptions.None);


                ////comprobar si tiene mas de 2 registro el arreglo                               
                //if (newformaDePago.Length >= 2)
                //{
                //    posY += 20;
                //    e.Graphics.DrawString($"FORMA DE PAGO: {newformaDePago[0]}", fuenteRegular, Brushes.Black, posX, posY);

                //    for (var rows = 1; rows < newformaDePago.Length; rows++)
                //    {
                //        posY += 20;
                //        e.Graphics.DrawString(newformaDePago[rows], fuenteRegular, Brushes.Black, posX, posY);
                //    }
                //}
                //else
                //{
                //    posY += 20;
                //    e.Graphics.DrawString("FORMA DE PAGO: " + _encabezadoFact.formaDePago, fuenteRegular, Brushes.Black, posX, posY);
                //}

                //reiniciar en la posicion X
                posX = 2;
                posY += 15;
                e.Graphics.DrawString("-------------------------------------------------------------------------", fuente, Brushes.Black, posX, posY);
          
                posY += 10;
                e.Graphics.DrawString("FORMA DE PAGO: " , fuenteRegular, Brushes.Black, posX+90, posY);

                foreach (var listPagos in _listMetodoPago)
                {
                   
                        //reiniciar con 2
                        posX = 2;
                        posY += 15;
                        e.Graphics.DrawString(listPagos.DescripcionFormaPago, fuenteRegular, Brushes.Black, posX, posY);                      

                        //sumar 160
                        posX = 220;
                        e.Graphics.DrawString((listPagos.Moneda =='D' ?   $"U${listPagos.MontoDolar.ToString("N2")}" : $"C${listPagos.MontoCordoba.ToString("N2")}"), fuenteRegular, Brushes.Black, posX, posY);
                           
                   //si
                    if (listPagos.VueltoCliente < 0)
                    {
                        //reiniciar con 2
                        posX = 2;
                        posY += 15;
                        e.Graphics.DrawString("SU CAMBIO: ", fuenteRegular, Brushes.Black, posX, posY);

                        //sumar 160
                        posX = 220;
                        e.Graphics.DrawString( $"C${(listPagos.VueltoCliente * (-1)).ToString("N2")}", fuenteRegular, Brushes.Black, posX, posY);
                    }

                }




                //oscar revisar este codigo urgente
                // char[] value = ['\r', '\n'];
                posX = 2;
                posY += 50;
                string[] newObservacion = _encabezadoFact.observaciones.Split(stringSeparators, StringSplitOptions.None);

                e.Graphics.DrawString("OBSERVACIONES: ", fuenteRegular, Brushes.Black, posX, posY);

                if (newObservacion.Length >= 2)
                {
                    for (var fila = 0; fila < newObservacion.Length; fila++)
                    {
                        posY += 15;
                        e.Graphics.DrawString(newObservacion[fila], fuenteRegular, Brushes.Black, posX + 10, posY);
                    }
                }
                else
                {
                    posY += 15;
                    e.Graphics.DrawString(_encabezadoFact.observaciones, fuenteRegular, Brushes.Black, posX, posY);
                }


                posY += 50;
                e.Graphics.DrawString("ATENDIDO POR: ", fuenteRegular, Brushes.Black, posX, posY);
                posY += 15;
                e.Graphics.DrawString( _encabezadoFact.atentidoPor, fuenteRegular, Brushes.Black, posX+15, posY);

                posY += 70;
                e.Graphics.DrawString("ENTREGADO: ", fuenteRegular, Brushes.Black, posX, posY);

                posY += 70;
                e.Graphics.DrawString("RECIBIDO: ", fuenteRegular, Brushes.Black, posX, posY);

                posY += 70;
                posX = 30;
                e.Graphics.DrawString("NO SE ACEPTAN CAMBIOS DESPUES DE", fuenteRegular, Brushes.Black, posX, posY);
                posY += 15;
                e.Graphics.DrawString("48 HORAS. *APLICAN RESTRICCIONES*", fuenteRegular, Brushes.Black, posX, posY);

                posY += 40;
                posX += 23;
                e.Graphics.DrawString("GRACIAS POR SU COMPRA", fuenteRegular, Brushes.Black, posX, posY);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


        private List<string> ObtenerDatosRegistro(string dato, int longitudMax)
        {
            string nuevoDato = "";
            List<string> nuevaLista = new List<string>();
            for (int row = 0; row < dato.Length; row++)
            {
                if (nuevoDato.Length == longitudMax)
                {
                    nuevaLista.Add(nuevoDato);
                }
                else
                {
                    nuevoDato = nuevoDato + dato[row];
                }
            }

            return nuevaLista;
        }




        private void ImprimirPorReferenciaCaracter(ref PrintPageEventArgs e, string texto, Font fuente, ref int posX, int incrementoX, ref int posY, int incrementoY = 0)
        {
            string[] textoImprimir = texto.Split('*');


            //comprobar si tiene mas de 2 registro el arreglo                               
            if (textoImprimir.Length >= 2)
            {
                //posY += incrementoY;
                //e.Graphics.DrawString(textoImprimir[0], fuente, Brushes.Black, posX + incrementoX, posY);

                for (var rows = 0; rows < textoImprimir.Length; rows++)
                {
                    posY += incrementoY;
                    e.Graphics.DrawString(textoImprimir[rows], fuente, Brushes.Black, posX + incrementoX, posY);
                }
            }
            else
            {
                posY += incrementoY;
                e.Graphics.DrawString(texto, fuente, Brushes.Black, posX+incrementoX, posY);
            }
        }


        public void ImprimirTicketFacturaDemo(List<DetalleFactura> listDetFactura, Encabezado encabezadoFact)
        {
            this._listDetFactura = new List<DetalleFactura>();
            _listDetFactura = listDetFactura;

            this._encabezadoFact = new Encabezado();
            this._encabezadoFact = encabezadoFact;


            doc.PrinterSettings.PrinterName = doc.DefaultPageSettings.PrinterSettings.PrinterName;

            doc.PrintPage += new PrintPageEventHandler(ImprimirTicket);
            // Set the zoom to 25 percent.
            //this.PrintPreviewControl1.Zoom = 0.25;            
            //vista.Controls.Add(this.PrintPreviewControl1);

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

        public void ImprimirTicketDemo(object sender, PrintPageEventArgs e)
        {
            int posX, posY;
            Font fuente = new Font("consola", 8, FontStyle.Bold);
            Font fuenteRegular = new Font("consola", 8, FontStyle.Regular);
            Font fuenteRegular_7 = new Font("consola", 7, FontStyle.Regular);

            var direccion = "Km 6 Carretera Norte, 700 Mts al norte";
            var direccion2 = "Puente a Desnivel";
            var telefono = "Tel:(505)22493187 Fax: 22493184";


            try
            {
                posX = 2;
                posY = 0;
                posY += 20;
                e.Graphics.DrawString("EJERCITO DE NICARAGUA ", fuente, Brushes.Black, posX + 53, posY);
                posY += 15;
                e.Graphics.DrawString(User.NombreTienda, fuente, Brushes.Black, posX + 45, posY);
                posY += 15;
                e.Graphics.DrawString(direccion, fuente, Brushes.Black, posX + 35, posY);
                posY += 15;
                e.Graphics.DrawString(direccion2, fuente, Brushes.Black, posX + 80, posY);
                posY += 15;
                e.Graphics.DrawString("Managua, Nicaragua", fuente, Brushes.Black, posX + 80, posY);
                posY += 15;
                e.Graphics.DrawString(telefono, fuente, Brushes.Black, posX + 40, posY);
                posY += 15;
                e.Graphics.DrawString("N° RUC: J1330000001272", fuente, Brushes.Black, posX + 55, posY);

                //factura
                posY += 24;
                e.Graphics.DrawString("N° Factura: " + _encabezadoFact.NoFactura, fuenteRegular, Brushes.Black, posX, posY);
                posY += 15;
                e.Graphics.DrawString("Codigo Cliente: " + _encabezadoFact.codigoCliente, fuenteRegular, Brushes.Black, posX, posY);
                posY += 15;
                e.Graphics.DrawString("Cliente: " + _encabezadoFact.cliente, fuenteRegular, Brushes.Black, posX, posY);
                posY += 15;
                e.Graphics.DrawString("Fecha: " + _encabezadoFact.fecha, fuenteRegular, Brushes.Black, posX, posY);
                posY += 15;
                e.Graphics.DrawString("Bodega: " + _encabezadoFact.bodega, fuenteRegular, Brushes.Black, posX, posY);
                posY += 15;
                e.Graphics.DrawString("Caja: " + _encabezadoFact.caja, fuenteRegular, Brushes.Black, posX, posY);
                posY += 15;
                e.Graphics.DrawString("Tipo Cambio: " + _encabezadoFact.tipoCambio.ToString("N4"), fuenteRegular, Brushes.Black, posX, posY);
                posY += 18;
                e.Graphics.DrawString("-------------------------------------------------------------------------", fuente, Brushes.Black, posX, posY);
                posY += 10;
                e.Graphics.DrawString("Codigo", fuente, Brushes.Black, posX, posY);
                //posY += 15;
                posX += 60;
                e.Graphics.DrawString("Cant", fuente, Brushes.Black, posX, posY);
                //posY += 15;
                posX += 50;
                e.Graphics.DrawString("Precio", fuente, Brushes.Black, posX, posY);
                // posY += 15;
                posX += 50;
                e.Graphics.DrawString("Desc", fuente, Brushes.Black, posX, posY);
                //posY += 15;
                posX += 40;
                e.Graphics.DrawString("Monto", fuente, Brushes.Black, posX, posY);
                posY += 10;
                //reiniciar la posicionX
                posX = 2;
                e.Graphics.DrawString("-------------------------------------------------------------------------", fuente, Brushes.Black, posX, posY);



                //e.Graphics.DrawString("8721160000939", fuenteRegular, Brushes.Black, posX, posY);
                //_listDetFactura

                foreach (var detalleFactura in _listDetFactura)
                {
                    posY += 10;
                    e.Graphics.DrawString(detalleFactura.ArticuloId, fuenteRegular, Brushes.Black, posX, posY);

                    posX += 60;
                    e.Graphics.DrawString(detalleFactura.Cantidad_d.ToString("N2"), fuenteRegular, Brushes.Black, posX, posY);

                    posX += 45;
                    e.Graphics.DrawString(detalleFactura.PrecioCordobas.ToString("N2"), fuenteRegular, Brushes.Black, posX, posY);

                    posX += 60;
                    e.Graphics.DrawString(Convert.ToDecimal(detalleFactura.DescuentoPorLineaCordoba).ToString("N2"), fuenteRegular, Brushes.Black, posX, posY);

                    posX += 50;
                    e.Graphics.DrawString(detalleFactura.TotalCordobas.ToString("N2"), fuenteRegular, Brushes.Black, posX, posY);

                    //salto a la siguiente linea
                    posY += 15;
                    posX = 2;
                    e.Graphics.DrawString(detalleFactura.Descripcion, fuenteRegular_7, Brushes.Black, posX, posY);

                    posY += 7;

                }

                posY += 5;
                e.Graphics.DrawString("-------------------------------------------------------------------------", fuente, Brushes.Black, posX, posY);

                posY += 15;
                posX = 2;
                posX += 140;
                e.Graphics.DrawString("Sub Total:", fuente, Brushes.Black, posX, posY);


                posX += 65;
                e.Graphics.DrawString("C$ " + _encabezadoFact.subTotalCordoba.ToString("N2"), fuenteRegular, Brushes.Black, posX, posY);

                posY += 15;
                posX = 2;
                posX += 140;
                e.Graphics.DrawString("Descuento:", fuente, Brushes.Black, posX, posY);

                posX += 65;
                e.Graphics.DrawString("C$ " + _encabezadoFact.descuentoCordoba.ToString("N2"), fuenteRegular, Brushes.Black, posX, posY);

                posY += 15;
                posX = 2;
                posX += 140;
                e.Graphics.DrawString("IVA:", fuente, Brushes.Black, posX, posY);

                posX += 65;
                e.Graphics.DrawString("C$ " + _encabezadoFact.ivaCordoba.ToString("N2"), fuenteRegular, Brushes.Black, posX, posY);

                posY += 15;
                posX = 2;
                posX += 140;
                e.Graphics.DrawString("Total:", fuente, Brushes.Black, posX, posY);

                posX += 65;
                e.Graphics.DrawString("C$ " + _encabezadoFact.totalCordoba.ToString("N2"), fuenteRegular, Brushes.Black, posX, posY);


                posY += 15;
                posX = 2;
                posX += 140;
                e.Graphics.DrawString("Total:", fuente, Brushes.Black, posX, posY);

                posX += 65;
                e.Graphics.DrawString("U$ " + _encabezadoFact.totalDolar.ToString("N2"), fuenteRegular, Brushes.Black, posX, posY);

                /************************************************************************************/

                posY += 20;
                //reiniciar en la posicion X
                posX = 2;
                e.Graphics.DrawString("Forma de Pago: " + _encabezadoFact.formaDePago, fuenteRegular, Brushes.Black, posX, posY);

                //oscar revisar este codigo urgente
                //char[] value = ['\r', '\n'];
                posY += 18;
                string[] newObservacion = _encabezadoFact.observaciones.Split('\r');

                e.Graphics.DrawString("Observaciones: ", fuenteRegular, Brushes.Black, posX, posY);

                if (newObservacion.Length >= 2)
                {
                    for (var fila = 0; fila < newObservacion.Length; fila++)
                    {
                        posY += 15;
                        e.Graphics.DrawString(newObservacion[fila], fuenteRegular, Brushes.Black, posX + 10, posY);
                    }
                }
                else
                {
                    posY += 15;
                    e.Graphics.DrawString(_encabezadoFact.observaciones, fuenteRegular, Brushes.Black, posX, posY);
                }


                posY += 20;
                e.Graphics.DrawString("Atendido Por: ", fuenteRegular, Brushes.Black, posX, posY);

                posY += 50;
                e.Graphics.DrawString("ENTREGADO: ", fuenteRegular, Brushes.Black, posX, posY);

                posY += 50;
                e.Graphics.DrawString("RECIBIDO: ", fuenteRegular, Brushes.Black, posX, posY);

                posY += 50;
                posX = 30;
                e.Graphics.DrawString("NO SE ACEPTAN CAMBIOS DESPUES DE", fuenteRegular, Brushes.Black, posX, posY);
                posY += 15;
                e.Graphics.DrawString("48 HORAS. *APLICAN RESTRICCIONES*", fuenteRegular, Brushes.Black, posX, posY);

                posY += 40;
                posX += 23;
                e.Graphics.DrawString("GRACIAS POR SU COMPRA", fuenteRegular, Brushes.Black, posX, posY);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


        private void TextoExtremo_Extremo(PrintPageEventArgs e, string texto, Font fuente, int posX, int posY)
        {
            int tamañoMax = 40;
            //int cantidadLinea;
            int longitutText = texto.Length;

            if (texto.Length > 40)
            {
                //float valor = texto.Length / 40.00f;
                //cantidad de linea a crear
                //cantidadLinea =(int)Math.Ceiling(valor);
                //int fila = 0;
                ////declaro un arreglo
                //string[] elementos = new string[cantidadLinea];

                int index = 0;
                while (index < texto.Length)
                {
                    string textImprimir = texto.Substring(index, tamañoMax);
                    posY += 70;
                    posX = 30;
                    e.Graphics.DrawString(textImprimir, fuente, Brushes.Black, posX, posY);



                    index = index + 40;
                    longitutText = longitutText - 40;
                    tamañoMax = longitutText >= 40 ? 40 : longitutText;
                }
            }
        }

        private static void TextoExtremo_Extremo(string texto)
        {
            int tamañoMax = 40;
            //int cantidadLinea;
            int longitutText = texto.Length;

            if (texto.Length > 40)
            {
                //float valor = texto.Length / 40.00f;
                //cantidad de linea a crear
                //cantidadLinea =(int)Math.Ceiling(valor);
                //int fila = 0;
                ////declaro un arreglo
                //string[] elementos = new string[cantidadLinea];

                int index = 0;
                while (index < texto.Length)
                {


                    string textImprimir = texto.Substring(index, tamañoMax);
                    index = index + 40;

                    longitutText = longitutText - 40;
                    tamañoMax = longitutText >= 40 ? 40 : longitutText;

                }
            }
        }




    }
}
