using Api.Context;
using Api.Model.Modelos;
using Api.Model.View;
using Api.Model.ViewModels;
using Api.Setting;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Service.DataService
{
    public class ServiceDevolucion
    {
        // private TiendaDbContext _db = new TiendaDbContext();

        public async Task<bool> facturaTieneDevolucion(string factura, ResponseModel responseModel)
        {
            bool existeDevolucion = false;
            var devolucion = new Facturas();
            try
            {
                using (var _db = new TiendaDbContext())
                {
                    //una devolucion tiene no tiene que estar anulada y que usuario que anula sea null
                    devolucion = await _db.Facturas.Where(f => f.Factura_Original == factura && f.Tipo_Documento == "D" && f.Anulada == "N" && f.Usuario_Anula == null).FirstOrDefaultAsync();
                }

                if (devolucion != null)
                {
                    existeDevolucion = true;
                    responseModel.Exito = 0;
                    responseModel.Mensaje = $"Ya existe una devolucion para esta factura";
                }
                else
                {
                    existeDevolucion = false;
                    responseModel.Exito = 1;
                    responseModel.Mensaje = $"Esta factura no esta anulada";
                }
            }
            catch (Exception ex)
            {
                responseModel.Exito = -1;
                responseModel.Mensaje = ex.Message;
                throw new Exception(ex.Message);
            }

            return existeDevolucion;
        }

        public async Task<bool> FacturaTieneArticuloParaDevolver(string factura, string caja, ResponseModel responseModel)
        {
            bool existeFactura = false;           
            bool existeCantidades = false;
            bool tieneArticuloDevolver = false; 
            decimal cantidad = 0.00M;

            try
            {
                using (SqlConnection cn = new SqlConnection(ConectionContext.GetConnectionSqlServer()))
                {
                    //Abrir la conección 
                    cn.Open();
                    SqlCommand cmd = new SqlCommand($"{User.Compañia}.ObtenerArticulosDevolver", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 0;
                    cmd.Parameters.AddWithValue("@Factura", factura);
                    cmd.Parameters.AddWithValue("@Caja", caja);
                                   

                    var dr = await cmd.ExecuteReaderAsync();
                    while (await dr.ReadAsync())
                    {
                        existeFactura = true;
                        cantidad = Convert.ToDecimal(dr["Cantidad"]);
                        //verificar si las cantidades es mayor que cero entonces significa que factura tiene articulo para devolver
                        if (cantidad > 0) existeCantidades = true;
                     
                    }

                    //comprobar si existe la factura y existen las cantidades, entonces significa que la factura todavia tiene articulo para devolver
                    if (existeFactura && existeCantidades)
                    {
                        tieneArticuloDevolver = true;
                        responseModel.Exito = 1;
                        responseModel.Mensaje = "La factura todavia tiene articulo para devolver";
                    }
                    //si existe la factura y no tiene cantidades entonces significa que la factura ya tiene Devolucion para todos los articulos
                    else if (existeFactura && !existeCantidades)
                    {
                        tieneArticuloDevolver = false;
                        responseModel.Exito = 0;
                        responseModel.Mensaje = "Esta factura ya tiene Devolucion para todos los articulos";
                    }
                    else
                    {
                        tieneArticuloDevolver = false;
                        responseModel.Exito = 0;
                        responseModel.Mensaje = "La Factura no existe en la base de datos";
                    }

            
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return tieneArticuloDevolver;
        }


        public async Task<bool> FacturaAnulada(string factura, ResponseModel responseModel)
        {
            bool existeFacturaAnulada = false;
            var facturaAnulada = new Facturas();
            try
            {
                using (var _db = new TiendaDbContext())
                {
                    facturaAnulada = await _db.Facturas.Where(f => f.Factura == factura && f.Anulada == "S" && f.Multiplicador_Ev == 0).FirstOrDefaultAsync();
                }

                if (facturaAnulada != null)
                {
                    existeFacturaAnulada = true;
                    responseModel.Exito = 0;
                    responseModel.Mensaje = $"La factura {factura} está anulada";
                }
                else
                {
                    existeFacturaAnulada = false;
                    responseModel.Exito = 1;
                    responseModel.Mensaje = $"Esta factura no esta anulada";
                }
            }
            catch (Exception ex)
            {
                responseModel.Exito = -1;
                responseModel.Mensaje = ex.Message;
                throw new Exception(ex.Message);
            }

            return existeFacturaAnulada;
        }

        public async Task<bool> EstadoCajaAbierto(string numCierre, ResponseModel responseModel)
        {
            bool cajaAbierta = false;
            var cierrePos = new Cierre_Pos();
            var cierraCaja = new Cierre_Caja();
            try
            {
                using (var _db = new TiendaDbContext())
                {
                    //Comprobar si el cajero y la caja ya esta cerrada con el numero de cierre.
                    cierrePos = await _db.Database.SqlQuery<Cierre_Pos>($" SELECT CIERRE_POS.* FROM  {User.Compañia}.CIERRE_POS INNER JOIN {User.Compañia}.CIERRE_CAJA " +
                    $"ON CIERRE_POS.NUM_CIERRE_CAJA = CIERRE_CAJA.NUM_CIERRE_CAJA AND CIERRE_POS.CAJA = CIERRE_CAJA.CAJA " +
                    $"WHERE CIERRE_POS.NUM_CIERRE = '{numCierre}' AND CIERRE_POS.ESTADO ='C' AND CIERRE_CAJA.ESTADO ='C'").FirstOrDefaultAsync();
                }


                //si tiene registro es xq la caja ya esta cerrada
                if (cierrePos != null)
                {
                    cajaAbierta = false;
                    responseModel.Exito = 1;
                    responseModel.Mensaje = $"Caja cerrada";
                }
                else
                {
                    cajaAbierta = true;
                    responseModel.Exito = 0;
                    responseModel.Mensaje = $"No se puede hacer Devolucion, el numero de cierre de caja esta abierta";
                }
            }
            catch (Exception ex)
            {
                responseModel.Exito = -1;
                responseModel.Mensaje = $"Error SD0903231715: {ex.Message}";
                throw new Exception($"Error SD0903231715: {ex.Message}");
            }

            return cajaAbierta;
        }

        public async Task<ResponseModel> BuscarDevolucion(string noDevolucion, ResponseModel responseModel)
        {
            var modelDevolucion = new ViewModelFacturacion();
            modelDevolucion.Factura = new Facturas();
            modelDevolucion.FacturaLinea = new List<Factura_Linea>();
            modelDevolucion.AuxiliarPos = new Auxiliar_Pos();
         
            try
            {
                using (var _db = new TiendaDbContext())
                {
                    modelDevolucion.Factura = await _db.Facturas.Where(f => f.Factura == noDevolucion && f.Tipo_Documento == "D").FirstOrDefaultAsync();
                    modelDevolucion.Factura.NombreBodega = await _db.Bodegas.Where(f => f.Bodega == modelDevolucion.Factura.Bodega).Select(x=>x.Nombre).FirstOrDefaultAsync();
                    modelDevolucion.FacturaLinea = await _db.Factura_Linea.Where(f => f.Factura == noDevolucion).OrderBy(x => x.Linea).ToListAsync();
                    modelDevolucion.AuxiliarPos = await _db.Auxiliar_Pos.Where(f => f.Docum_Aplica == noDevolucion).FirstOrDefaultAsync();      
                    modelDevolucion.PagoPos = await _db.Pago_Pos.Where(f => f.Documento == noDevolucion).ToListAsync();
                }

                //verificar si factura y factura linea tienen registro
                if (modelDevolucion.Factura != null && modelDevolucion.FacturaLinea.Count > 0)
                {
                    responseModel.Exito = 1;
                    responseModel.Mensaje = "Consulta Exitosa";
                    responseModel.Data = modelDevolucion as ViewModelFacturacion;
                }
                else if (modelDevolucion.Factura == null && modelDevolucion.FacturaLinea.Count == 0)
                {
                    responseModel.Exito = 0;
                    responseModel.Mensaje = "No existe la factura en la base de dato";
                }
                else if (modelDevolucion.Factura == null && modelDevolucion.FacturaLinea.Count > 0)
                {
                    responseModel.Exito = 0;
                    responseModel.Mensaje = "El registro de la factura esta incompleto";
                }
                else
                {
                    responseModel.Exito = 0;
                    responseModel.Mensaje = "El sistema detecto que el registro está incompleta";
                }
            }
            catch (Exception ex)
            {
                responseModel.Exito = -1;
                responseModel.Mensaje = ex.Message;
                throw new Exception(ex.Message);
            }

            return responseModel;

        }

        public async Task<ResponseModel> BuscarFacturaPorNoFactura(string factura, string caja, string numeroCierre, ResponseModel responseModel)
        {
            var viewFactura = new ViewModelFacturacion();
            viewFactura.Factura = new Facturas();
            viewFactura.FacturaLinea = new List<Factura_Linea>();
            viewFactura.FormasPagos = new List<Forma_Pagos>();
            var facturas = new Facturas();
            var factura_Linea = new List<Factura_Linea>();
            try
            {
                //verificar si la factura ya fue anulada
                if (await FacturaAnulada(factura, responseModel))
                {
                    return responseModel;
                }
                //verificar si la factura ya tiene devolucion
                else if (!(await FacturaTieneArticuloParaDevolver(factura, caja, responseModel)))
                {
                    return responseModel;
                }
                //esta validacion se habia tomado en cuenta cuando ya se habia realizado el cierre.
                //verificar si el cierre aun esta abierto. 
                //else if (await EstadoCajaAbierto(numeroCierre, responseModel))
                //{
                //    return responseModel;
                //}
                else
                {

                    using (var _db = new TiendaDbContext())
                    {
                        viewFactura.Factura = await _db.Facturas.Where(f => f.Factura == factura).FirstOrDefaultAsync();
                        viewFactura.FacturaLinea = await _db.Factura_Linea.Where(fl => fl.Factura == factura && fl.Cantidad != fl.Cantidad_Devuelt).OrderBy(x=>x.Linea).ToListAsync();
                        viewFactura.PagoPos = await _db.Pago_Pos.Where(pp => pp.Documento == factura && pp.Pago != "-1").ToListAsync();
                        viewFactura.FormasPagos = await _db.Forma_Pagos.Where(fp => fp.Forma_Pago  == "0004" || fp.Forma_Pago == "0005" || fp.Forma_Pago == "FP17").ToListAsync();
                        var Consec_Caja_Pos = await _db.Database.SqlQuery<Consec_Caja_Pos>($"SELECT * FROM {User.Compañia}.CONSEC_CAJA_POS WHERE CODIGO='DEVOLUCION' AND CAJA='{User.Caja}' AND Tipo_Documento='D' AND ACTIVO='S'").FirstAsync();

                        if (Consec_Caja_Pos.Valor != null)
                        {
                            viewFactura.NoDevolucion = Consec_Caja_Pos.Valor;
                        }
                    }

                    //verificar si factura y factura linea tienen registro
                    if (viewFactura.Factura != null && viewFactura.FacturaLinea.Count > 0)
                    {
                        responseModel.Exito = 1;
                        responseModel.Mensaje = "Consulta Exitosa";
                        responseModel.Data = viewFactura as ViewModelFacturacion;
                    }
                    else if (viewFactura.Factura == null && viewFactura.FacturaLinea.Count == 0)
                    {
                        responseModel.Exito = 0;
                        responseModel.Mensaje = "No existe la factura en la base de dato";
                    }
                    else if (viewFactura.Factura == null && viewFactura.FacturaLinea.Count > 0)
                    {
                        responseModel.Exito = 0;
                        responseModel.Mensaje = "El registro de la factura esta incompleto";
                    }
                    else
                    {
                        responseModel.Exito = 0;
                        responseModel.Mensaje = "El sistema detecto que el registro está incompleta";
                    }
                }
            }
            catch (Exception ex)
            {
                responseModel.Exito = -1;
                responseModel.Mensaje = ex.Message;
                throw new Exception(ex.Message);
            }

            return responseModel;
        }




        public async Task<ResponseModel> BuscarFacturaBaseDatos(string factura, string tipoDocumento, ResponseModel responseModel)
        {
            var listFacturas = new List<Facturas>();
           

            try
            {
                using (TiendaDbContext _db = new TiendaDbContext())
                {
                    listFacturas = await _db.Facturas.Where(x => x.Factura == factura && x.Tipo_Documento == tipoDocumento).ToListAsync();
                }


                if (listFacturas.Count > 0)
                {
                    responseModel.Exito = 1;
                    responseModel.Mensaje = "Consulta Exitosa";
                    responseModel.Data = listFacturas as List<Facturas>;
                }
                else
                {
                    responseModel.Exito = 0;
                    responseModel.Mensaje = "No se encontro registro";
                    responseModel.Data = null;
                }
            }
            catch (Exception ex)
            {
                responseModel.Exito = -1;
                responseModel.Mensaje = ex.Message;
                throw new Exception(ex.Message);
            }

            return responseModel;
        }

        public async Task<ResponseModel> GuardarDevolucion(ViewModelFacturacion _devolucion, ResponseModel responseModel)
        {
            var result = 0;
            try
            {
                //model.Fecha = DateTime.Now.Date;
                using (SqlConnection cn = new SqlConnection(ConectionContext.GetConnectionSqlServer()))
                {
                    //Abrir la conección 
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand($"{User.Compañia}.SP_GuardarDevolucion", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 0;

                        cmd.Parameters.AddWithValue("@Factura", _devolucion.Factura.Factura);
                        cmd.Parameters.AddWithValue("@NoDevolucion", _devolucion.NoDevolucion);
                        cmd.Parameters.AddWithValue("@Caja", _devolucion.Factura.Caja);
                        cmd.Parameters.AddWithValue("@Cajero", _devolucion.Factura.Usuario);
                        cmd.Parameters.AddWithValue("@NumCierre", _devolucion.Factura.Num_Cierre);
                        cmd.Parameters.AddWithValue("@Observaciones", _devolucion.Factura.Observaciones);
                        cmd.Parameters.AddWithValue("@TotalFacturaDevuelta", _devolucion.Factura.Total_Factura);
                        //Monto_Descuento1= monto del Descuento General 5%
                        cmd.Parameters.AddWithValue("@Monto_Descuento1", _devolucion.Factura.Monto_Descuento1);
                        cmd.Parameters.AddWithValue("@Total_Mercaderia", _devolucion.Factura.Total_Mercaderia);
                        cmd.Parameters.AddWithValue("@Total_Unidades", _devolucion.Factura.Total_Unidades);
                        cmd.Parameters.AddWithValue("@Tipo_Original", _devolucion.Factura.Tipo_Original);
                        cmd.Parameters.AddWithValue("@FormaPago", _devolucion.Factura.Forma_Pago);
                        cmd.Parameters.AddWithValue("@Saldo", _devolucion.Factura.Saldo);
                        cmd.Parameters.AddWithValue("@Cobrada", _devolucion.Factura.Cobrada);

                        var dt = new DataTable();
                        dt.Columns.Add("ArticuloId", typeof(string));
                        dt.Columns.Add("Linea", typeof(short));
                        dt.Columns.Add("BodegaId", typeof(string));
                        dt.Columns.Add("Lote", typeof(string));
                        dt.Columns.Add("Localizacion", typeof(string));
                        dt.Columns.Add("CantidadDevolver", typeof(decimal));
                        dt.Columns.Add("Desc_Tot_Linea_Dev", typeof(decimal));
                        dt.Columns.Add("Costo_Total_Dolar_Dev", typeof(decimal));
                        dt.Columns.Add("Costo_Total_Dev", typeof(decimal));
                        dt.Columns.Add("Costo_Total_Local_Dev", typeof(decimal));
                        dt.Columns.Add("Costo_Total_Comp_Dev", typeof(decimal));
                        dt.Columns.Add("Costo_Total_Comp_Local_Dev", typeof(decimal));
                        dt.Columns.Add("Costo_Total_Comp_Dolar_Dev", typeof(decimal));
                        dt.Columns.Add("Precio_Total_Dev", typeof(decimal));
                        dt.Columns.Add("Desc_Tot_General_Dev", typeof(decimal));


                        foreach (var item in _devolucion.FacturaLinea)
                        {
                            if (item.Cantidad_Devuelt > 0)
                            {
                                dt.Rows.Add(item.Articulo, item.Linea, item.Bodega, item.Lote, item.Localizacion, item.Cantidad_Devuelt,
                                    item.Desc_Tot_Linea,  item.Costo_Total_Dolar,
                                    item.Costo_Total,  item.Costo_Total_Local,
                                    item.Costo_Total_Comp, item.Costo_Total_Comp_Local,
                                    item.Costo_Total_Comp_Dolar, item.Precio_Total,
                                    item.Desc_Tot_General
                                );
                            }

                       
                        }

                        var parametro = cmd.Parameters.AddWithValue("@DevolucionArticulos", dt);
                        parametro.SqlDbType = SqlDbType.Structured;

                        result = await cmd.ExecuteNonQueryAsync();
                    }
                }

                if (result > 0)
                {
                    responseModel.Exito = 1;
                    responseModel.Mensaje = $"La Devolcion se realizó exitosamente";
                }
                else
                {
                    responseModel.Exito = 0;
                    responseModel.Mensaje = $"El cierre no se pudo realizar";
                }
            }


            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return responseModel;
        }



        /// <summary>
        /// veri
        /// </summary>
        /// <param name="noDevolucion"></param>
        /// <param name="responseModel"></param>
        /// <returns></returns>
        public async Task<ResponseModel> NumeroCierre_Abierto(string num_Cierre, ResponseModel responseModel)
        {
            var cierre_Pos = new Cierre_Pos();
            try
            {
                using (var _db = new TiendaDbContext())
                {
                    //Comprobar si el cajero y la caja ya esta cerrada con el numero de cierre.
                    cierre_Pos = await _db.Database.SqlQuery<Cierre_Pos>($" SELECT CIERRE_POS.* FROM  {User.Compañia}.CIERRE_POS INNER JOIN {User.Compañia}.CIERRE_CAJA " +
                    $"ON CIERRE_POS.NUM_CIERRE_CAJA = CIERRE_CAJA.NUM_CIERRE_CAJA AND CIERRE_POS.CAJA = CIERRE_CAJA.CAJA " +
                    $"WHERE CIERRE_POS.NUM_CIERRE = '{num_Cierre}' AND CIERRE_POS.ESTADO ='A' AND CIERRE_CAJA.ESTADO ='A'").FirstOrDefaultAsync();
                }

                if (!(cierre_Pos is null))
                {
                    responseModel.Exito = 1;
                    responseModel.Mensaje = "consulta exitosa";
                }
                else
                {
                    responseModel.Exito = 0;
                    responseModel.Mensaje = "No se puede anular, el cajero ya hizo cierre";
                }
            }
            catch (Exception ex)
            {
                responseModel.Exito = -1;
                responseModel.Mensaje = ex.Message;
                throw new Exception(ex.Message);
            }

            return responseModel;

        }



        public async Task<ResponseModel> ListarDevolucionesClienteParaValidarAsync(string devolucion, string codigoCliente, ResponseModel responseModel)
        {
            bool resultExitoso = false;
            var devolucionCliente = new ViewDevoluciones();

            try
            {
                using (SqlConnection cn = new SqlConnection(ConectionContext.GetConnectionSqlServer()))
                {
                    //Abrir la conección 
                    cn.Open();
                    SqlCommand cmd = new SqlCommand($"SELECT FACTURA.FACTURA, FACTURA.TIPO_DOCUMENTO, FACTURA.SALDO, PAGO_POS.MONTO_LOCAL, PAGO_POS.MONTO_DOLAR, FACTURA.ANULADA," +
                                                $" FACTURA.CLIENTE, PAGO_POS.FORMA_PAGO, FACTURA.COBRADA FROM {User.Compañia}.FACTURA INNER JOIN {User.Compañia}.PAGO_POS WITH (NOLOCK) ON FACTURA.FACTURA = PAGO_POS.DOCUMENTO " +
                                                $" AND FACTURA.TIPO_DOCUMENTO = PAGO_POS.TIPO AND FACTURA.TIPO_DOCUMENTO = 'D' AND  FACTURA.MULTIPLICADOR_EV = -1 AND FACTURA.ANULADA = 'N' " +
                                                $" WHERE FACTURA.CLIENTE=@CodigoCliente AND FACTURA.FACTURA=@Devolucion", cn);
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandTimeout = 0;
                    cmd.Parameters.AddWithValue("@CodigoCliente", codigoCliente);
                    cmd.Parameters.AddWithValue("@Devolucion", devolucion);

                    var dr = await cmd.ExecuteReaderAsync();
                    if  (await dr.ReadAsync())
                    {
                        resultExitoso = true;
                        devolucionCliente.Factura = dr["FACTURA"].ToString();
                        devolucionCliente.Tipo_Documento = dr["TIPO_DOCUMENTO"].ToString();
                        devolucionCliente.Saldo = Convert.ToDecimal(dr["SALDO"]);
                        devolucionCliente.Monto_Local = Convert.ToDecimal(dr["MONTO_LOCAL"]);
                        devolucionCliente.Monto_Dolar = Convert.ToDecimal(dr["MONTO_DOLAR"]);
                        devolucionCliente.FormaPago = dr["FORMA_PAGO"].ToString();                 
                    }
                }

                if (resultExitoso)
                {
                    responseModel.Data = devolucionCliente as ViewDevoluciones;
                    responseModel.Exito = 1;
                    responseModel.Mensaje = $"Consulta exitosa";
                }
                else
                {
                    resultExitoso = false;
                    responseModel.Exito = 0;
                    responseModel.Mensaje = $"Este cliente no tiene Vale";
                }

            }
            catch (Exception ex)
            {
                // listarDatosFactura.Exito = -1;
                throw new Exception(ex.Message);
            }

            return responseModel;


        }



        public async Task<bool> DevolucionYaConsumioSaldo(string NoDevolucion, string codigoCliente, ResponseModel responseModel)
        {
            bool devolucionConsumido = true;

            try
            {                
                responseModel.Data = new List<ViewDevoluciones>();
                responseModel = await ListarDevolucionesClienteParaValidarAsync(NoDevolucion, codigoCliente,  responseModel);

                if (responseModel.Exito ==1)
                {
                    //obtener los datos de las devoluciones del cliente
                    var datosDevolucion = responseModel.Data as ViewDevoluciones;
                  
                    //validar que el monto del saldo es igual al monto_local de la devolucion y que la forma de pago fue por un vale (Devolucion-vale)
                    if(datosDevolucion.Saldo == datosDevolucion.Monto_Local && datosDevolucion.FormaPago == "0005")
                    {
                        devolucionConsumido = false;
                        responseModel.Exito = 1;
                        responseModel.Mensaje = "Consulta exitosa";
                    }
                    //validar que el monto del saldo es igual al monto_local de la devolucion y que la forma de pago fue al credito (0004) o Credito a corto plazo (FP17)
                    else if (datosDevolucion.Saldo != datosDevolucion.Monto_Local && (datosDevolucion.FormaPago == "0004" || datosDevolucion.FormaPago =="FP17"))
                    {
                        devolucionConsumido = false;
                        responseModel.Exito = 1;
                        responseModel.Mensaje = "Consulta exitosa";
                    }
                    else
                    {
                        devolucionConsumido = true;
                        responseModel.Exito = 0;
                        responseModel.Mensaje = $"El cliente ya consumio el vale de la devolucion {NoDevolucion}";
                    }
                }

              }
            catch (Exception ex)
            {
                responseModel.Exito = -1;
                responseModel.Mensaje = ex.Message;
                throw new Exception(ex.Message);
            }

            return devolucionConsumido;
        }

        //validacion para anular una factura tipo doc= F
        //1-que el numero de cierre de esa factura aun este abierta 
        //2-la factura no tenga devolucion.

        //validacion para anular una Devolucion tipo doc= D
        //1-que el numero de cierre de esa devolucion aun este abierta 
        //2-verificar que no se haiga consumido la devolcion con otra factura, es decir que el metodo de pago que no se haiga hecho por devolucion.
        //3-si es una devolucion al credito permitir la anulacion

        /// <summary>
        /// validar unas series de parametro para anular la factura o la devolucion     
        /// </summary>
        /// <param name="factura"></param>
        /// <param name="registroFactura"></param>
        /// <param name="responseModel"></param>
        /// <returns></returns>
        public async Task<ResponseModel> ModeloEsCorrecto(string factura, Facturas registroFactura, ResponseModel responseModel)
        {            
            try
            {
                //revisar si la factura tiene el numero de cierre abierto
                responseModel = await NumeroCierre_Abierto(registroFactura.Num_Cierre, responseModel);
                //si la respuesta del servidor es diferente a 1 (1 es exitoso, cualquiere otro numero significa que hubo algun problema)
                if (responseModel.Exito !=1) return responseModel;                           

                //validar que el tipo de documento es factura, entonces se procede a verificar si la factura tiene una devolucion
                if ( registroFactura.Tipo_Documento=="F") if (await facturaTieneDevolucion(factura, responseModel)) return responseModel;
                if (registroFactura.Tipo_Documento == "F") if (await FacturaAnulada(factura, responseModel)) return responseModel;

                if (registroFactura.Tipo_Documento =="D") if (await DevolucionYaConsumioSaldo(factura, registroFactura.Cliente, responseModel)) return responseModel;

            }
            catch (Exception ex)
            {
                responseModel.Mensaje = ex.Message;
            }

            return responseModel;
        }
    }
}
