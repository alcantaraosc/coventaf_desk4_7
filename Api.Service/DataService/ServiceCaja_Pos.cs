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
    public class ServiceCaja_Pos
    {
        //private TiendaDbContext _db = new TiendaDbContext();
        public ServiceCaja_Pos()
        {

        }


        public async Task<ResponseModel> ObtenerCierrePos(string caja, string cajero, string numCierre, ResponseModel responseModel)
        {
            var cierre_Pos = new Cierre_Pos();
            try
            {
                using (TiendaDbContext _db = new TiendaDbContext())
                {
                    cierre_Pos = await _db.Cierre_Pos.Where(cp => cp.Num_Cierre == numCierre && cp.Caja == caja && cp.Cajero == cajero).FirstOrDefaultAsync();
                }

                if (cierre_Pos == null)
                {
                    responseModel.Exito = 0;
                    responseModel.Mensaje = "No existe registro";
                    responseModel.Data = null;
                }
                else
                {
                    responseModel.Exito = 1;
                    responseModel.Mensaje = "consulta exitosa";
                    responseModel.Data = cierre_Pos as Cierre_Pos;
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return responseModel;
        }

        /// <summary>
        /// Listar las cajas disponible para cada sucursal
        /// </summary>
        /// <param name="cajero"></param>
        /// <param name="sucursalID"></param>
        /// <param name="responseModel"></param>
        /// <returns></returns>
        public async Task<List<ViewCajaDisponible>> ListarCajasDisponibles(string cajero, string sucursalID, ResponseModel responseModel)
        {
            var listaCajaDisponible = new List<ViewCajaDisponible>();
            try
            {
                using (TiendaDbContext _db = new TiendaDbContext())
                {

                    //primero verificar si el cajero esta en la tabla de cajeros
                    var datoCajero = await _db.Cajeros.Where(cj => cj.Cajero == cajero).FirstOrDefaultAsync();
                    if (!(datoCajero is null))
                    {
                        //listar todas las cajas disponibles que forman parte de la sucursal vinculada
                        listaCajaDisponible = await _db.ViewCajaDisponible.Where(cd => cd.Sucursal == sucursalID).ToListAsync();
                    }

                    if (!(datoCajero is null) && (listaCajaDisponible.Count > 0))
                    {
                        responseModel.Exito = 1;
                        responseModel.Mensaje = "Consulta exitosa";
                    }
                    else
                    {
                        responseModel.Exito = 0;
                        if (datoCajero is null)
                        {
                            responseModel.Mensaje = "Este usuario no pertenece a la lista de Cajero";
                        }
                        else if (listaCajaDisponible.Count == 0)
                        {
                            responseModel.Mensaje = "Actualmente el sistema ya no tiene caja disponible";
                        }

                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return listaCajaDisponible;

        }

        /// <summary>
        /// verificar si la caja de apertura ya esta ocupada antes de guardar, esto validacion se da por que el usuario 
        /// puede ser que deje la ventana abierta y haga apertura al instante.
        /// </summary>
        public bool CajaAperturaOcupada(string caja, ResponseModel responseModel)
        {
            bool ocupada = false;

            try
            {
                using (TiendaDbContext _db = new TiendaDbContext())
                {

                    //obtener el registor de la caja x que este abierta
                    var result = _db.Cierre_Pos.Where(cp => cp.Caja == caja && cp.Estado == "A").FirstOrDefault();
                    if (result is null)
                    {
                        responseModel.Exito = 1;
                        responseModel.Mensaje = "Caja Libre";
                        ocupada = false;
                    }
                    else
                    {
                        responseModel.Exito = 0;
                        responseModel.Mensaje = $"La Caja {caja} ya fue aperturada";
                        ocupada = true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return ocupada;
        }

        /// <summary>
        /// verificar si cajero tiene una caja abierta
        /// </summary>
        /// <returns></returns>
        private bool ExisteCajaAbiertaPorCajero(string cajero)
        {
            bool existeCajaAbierta = false;
            try
            {
                using (TiendaDbContext _db = new TiendaDbContext())
                {
                    var cierre_Caja = _db.Cierre_Caja.Where(cc => cc.Cajero_Apertura == cajero && cc.Estado == "A").FirstOrDefault();
                    //verificar si tiene caja abierta
                    if (cierre_Caja != null)
                    {
                        existeCajaAbierta = true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return existeCajaAbierta;
        }



        /// <summary>
        /// revisar si la caja ya fue aperturada por el cajero actual
        /// </summary>
        /// <param name="cajero"></param>
        /// <param name="responseModel"></param>
        /// <returns></returns>
        private bool AperturadoPorCajeroActual(string cajero, ResponseModel responseModel)
        {
            //el cajero ya hizo apertura o existe inconsistencia en el registro.
            bool aperturadoPorCajero = true;
            var cierre_Pos = new Cierre_Pos();
            try
            {
                bool CajaAbiertaPorCajero = ExisteCajaAbiertaPorCajero(cajero);

                using (TiendaDbContext _db = new TiendaDbContext())
                {
                    //obtener el registor para verificar si el cajero ya tiene abierto otro.
                     cierre_Pos = _db.Cierre_Pos.Where(cp => cp.Cajero == cajero && cp.Estado == "A").FirstOrDefault();
                }
                //true y   false
                if ((CajaAbiertaPorCajero) & (cierre_Pos is null))
                {
                    responseModel.Exito = 0;
                    responseModel.Mensaje = $"El Sistema a identificado una caja abierta del cajero {cajero}, contacte al supervisor";
                }
                //false  y true
                else if (!(CajaAbiertaPorCajero) & (cierre_Pos != null))
                {
                    responseModel.Exito = 0;
                    responseModel.Mensaje = $"Existe una inconsistencia de registro del cajero {cajero}, contacte al supervisor";
                }
                //true  y true
                else if ((CajaAbiertaPorCajero) & (cierre_Pos != null))
                {
                    responseModel.Exito = 0;
                    responseModel.Mensaje = $"Ya existe una Apertura de Caja para el Cajero {cajero}";
                }
                else
                {
                    //el cajero no ha aperturado
                    aperturadoPorCajero = false;
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return aperturadoPorCajero;
        }


        /*
        public bool AperturadoPorCajeroActual(string cajero, ResponseModel responseModel)
        {
            bool aperutadoPorCajero = false;

            try
            {
                using (var _db = new CoreDBContext())
                {
                    //obtener el registor de la caja x que este abierta
                    var result = _db.Cierre_Pos.Where(cp => cp.Cajero == cajero && cp.Estado == "A").FirstOrDefault();
                    if (result is null)
                    {
                        responseModel.Exito = 1;
                        responseModel.Mensaje = "El Cajero ya aperturo";
                        aperutadoPorCajero = false;
                        responseModel.Data = result as Cierre_Pos;
                    }
                    else
                    {
                        responseModel.Exito = 0;
                        responseModel.Mensaje = "La Caja se encuentra ocupada";
                        aperutadoPorCajero = true;
                        //responseModel.Data = result.Num_Cierre as string;
                        responseModel.Data = result as Cierre_Pos;
                    }

                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return aperutadoPorCajero;
        }*/
        /// <summary>
        /// verifica que la caja que esta aperturada esta ocupado por un cajero
        /// </summary>
        /// <param name="caja"></param>
        /// <param name="cajero"></param>
        /// <param name="responseModel"></param>
        /// <returns></returns>
        public bool CajaAperturaOcupadaConCajeroX(string caja, string cajero, ResponseModel responseModel)
        {
            bool ocupada = false;

            try
            {
                using (TiendaDbContext _db = new TiendaDbContext())
                {

                    //obtener el registor de la caja x que este abierta
                    var result = _db.Cierre_Pos.Where(cp => cp.Caja == caja && cp.Cajero == cajero && cp.Estado == "A").FirstOrDefault();
                    if (result is null)
                    {
                        responseModel.Exito = 1;
                        responseModel.Mensaje = "Caja Libre";
                        ocupada = false;
                    }
                    else
                    {
                        responseModel.Exito = 0;
                        responseModel.Mensaje = $"El cajero {cajero} ya hizo apertura con la caja {caja}";
                        ocupada = true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return ocupada;
        }


        public bool ModeloAperturaCajaEsValido(string caja, string cajero, ResponseModel responseModel)
        {
            //verificar si el cajero actual ya aperturo      
            if (AperturadoPorCajeroActual(cajero, responseModel))
            {
                return false;
            }
            //validar si la caja que intentas aperturar ya esta ocupada
            else if (CajaAperturaOcupada(caja, responseModel))
            {
                return false;
            }
            //validar si la caja ocupada con el cajero
            else if (CajaAperturaOcupadaConCajeroX(caja, cajero, responseModel))
            {
                return false;
            }
            else
            {
                return true;
            }
        }


        /// <summary>
        /// Crear la apertura de Caja
        /// </summary>
        /// <param name="caja"></param>
        /// <param name="cajero"></param>
        /// <param name="sucursalID"></param>
        /// <param name="responseModel"></param>
        /// <returns></returns>
        public async Task<List<string>> GuardarAperturaCaja(string caja, string cajero, string sucursalID, decimal montoApertura, ResponseModel responseModel)
        {
            //aqui vas almacenar la bodegaId y Consec_Cierre_CT
            var listResult = new List<string>();
            try
            {
                //model.Fecha = DateTime.Now.Date;
                using (SqlConnection cn = new SqlConnection(ConectionContext.GetConnectionSqlServer()))
                {
                    //Abrir la conección 
                    await cn.OpenAsync();
                    SqlCommand cmd = new SqlCommand("SP_AperturaCaja", cn);
                    cmd.CommandTimeout = 0;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Caja", caja);
                    cmd.Parameters.AddWithValue("@Cajero", cajero);
                    cmd.Parameters.AddWithValue("@Sucursal", sucursalID);
                    cmd.Parameters.AddWithValue("@MontoApertura", montoApertura);

                    //// Se añaden los parámetros de salida y se crean variables para facilitar su recuperacion
                    //SqlParameter paramOutConsec_Cierre_CT = cmd.Parameters.Add("@ConsecutivoCierreCT", SqlDbType.VarChar, 50);
                    //paramOutConsec_Cierre_CT.Direction = ParameterDirection.Output;

                    //SqlParameter paramReturned = cmd.Parameters.Add("@ConsecutivoCierreCT", SqlDbType.VarChar, 50);
                    //paramReturned.Direction = ParameterDirection.ReturnValue;

                    var dr = await cmd.ExecuteReaderAsync();
                    if (await dr.ReadAsync())
                    {
                        if (dr["Exito"].ToString() == "SI")
                        {
                            //bodegaId
                            listResult.Add(dr["BodegaId"].ToString());
                            //ConsecutivoCierreCT
                            listResult.Add(dr["ConsecutivoCierreCT"].ToString());
                        }
                    }

                }

                if (listResult.Count > 0)
                {
                    responseModel.Exito = 1;
                    responseModel.Mensaje = $"La Apertura de caja {caja} se realizó exitosamente";
                }
                else
                {
                    responseModel.Exito = 0;
                    responseModel.Mensaje = $"La Apertura de caja {caja} no se pudo realizar";
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Error SP_AperturaCaja: " + ex.Message);
            }
            return listResult;
        }

        private string ObtenerBodegaId(string caja, string sucursal, ResponseModel responseModel)
        {
            var bodegaID = "";
            try
            {
                using (TiendaDbContext _db = new TiendaDbContext())
                {
                    bodegaID = _db.Caja_Pos.Where(cp => cp.Caja == caja && cp.Sucursal == sucursal).Select(x => x.Bodega).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return bodegaID;
        }

        //private bool CajaEstaAperturadoPorCajeroActual(string cajero, string sucursalID, ResponseModel responseModel)
        //{
        //    bool aperturadoPorCajero = false;
        //    var bodegaID = "";

        //    try
        //    {
        //        //obtener el registor de la caja x que este abierta
        //        var cierre_Pos = _db.Cierre_Pos.Where(cp => cp.Cajero == cajero && cp.Estado == "A").FirstOrDefault();
        //        //comprobar si la caja ya fue aperturada
        //        if (!(cierre_Pos is null))
        //        {
        //            aperturadoPorCajero = true;
        //            //luego obtener la bodega ID
        //            bodegaID = _db.Caja_Pos.Where(cp => cp.Caja == cierre_Pos.Caja && cp.Sucursal == sucursalID).Select(x => x.Bodega).FirstOrDefault();
        //            //asignar los datos para enviarlos
        //            responseModel.Data = cierre_Pos as Cierre_Pos;
        //            //asignar la bodega
        //            responseModel.DataAux = bodegaID.ToString();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }

        //    return aperturadoPorCajero;
        //}

        /// <summary>
        /// aqui estoy trabajando Oscar
        /// </summary>
        /// <param name="cajero"></param>
        /// <param name="sucursalID"></param>
        /// <param name="responseModel"></param>
        public async Task<ResponseModel> VerificarExistenciaAperturaCajaAsync(string cajero, string sucursalID)
        {
            ResponseModel responseModel = new ResponseModel();
            responseModel.Data = new List<DatosResult>();
            var listDatosResult = new List<DatosResult>();
            var result = "";
            try
            {

                using (SqlConnection cn = new SqlConnection(ConectionContext.GetConnectionSqlServer()))
                {
                    //Abrir la conección 
                    await cn.OpenAsync();
                    SqlCommand cmd = new SqlCommand("SP_ExistenciaAperturaCaja", cn);
                    cmd.CommandTimeout = 0;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Cajero", cajero);
                    cmd.Parameters.AddWithValue("@Sucursal", sucursalID);

                    var dr = await cmd.ExecuteReaderAsync();
                    if (await dr.ReadAsync())
                    {
                        //obtener la respuesta del servidor
                        result = dr["ExisteAperturaCajero"].ToString();
                        if (result == "SI")
                        {
                            listDatosResult.Add(new DatosResult { ResultString = dr["Caja"].ToString() });
                            listDatosResult.Add(new DatosResult { ResultString = dr["ConsecCierreCT"].ToString() });
                            listDatosResult.Add(new DatosResult { ResultString = dr["BodegaID"].ToString() });
                            listDatosResult.Add(new DatosResult { ResultString = dr["MascaraFactura"].ToString() });
                            responseModel.Exito = 1;
                            responseModel.Data = listDatosResult;
                        }
                        else if (result == "NO")
                        {
                            responseModel.Exito = 0;
                            responseModel.Mensaje = dr["Mensaje"].ToString();
                            responseModel.Data = null;
                        }
                        else if (result == "SD")
                        {
                            responseModel.Exito = -1;
                            responseModel.Mensaje = dr["Mensaje"].ToString();
                            responseModel.Data = null;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return responseModel;
        }

        /*public async GuardarCierreCaja()
        {

        }*/

        public async Task<List<DetallesCierreCaja>> ObtenerDatosParaCierreCaja(string caja, string cajero, string numCierre, ResponseModel responseModel)
        {

            //aqui vas almacenar la bodegaId y Consec_Cierre_CT
            var datosCierreCaja = new List<DetallesCierreCaja>();
            try
            {
                //model.Fecha = DateTime.Now.Date;
                using (SqlConnection cn = new SqlConnection(ConectionContext.GetConnectionSqlServer()))
                {
                    //Abrir la conección 
                    await cn.OpenAsync();
                    SqlCommand cmd = new SqlCommand("SP_PrepararCierreCaja", cn);
                    cmd.CommandTimeout = 0;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Caja", caja);
                    cmd.Parameters.AddWithValue("@Cajero", cajero);
                    cmd.Parameters.AddWithValue("@NumCierre", numCierre);

       
                    var dr = await cmd.ExecuteReaderAsync();
                    while (await dr.ReadAsync())
                    {
                        var datos_ = new DetallesCierreCaja()
                        {
                            Id = $"{dr["FORMA_PAGO"].ToString()}{dr["TIPO_DOCUMENTO"].ToString()}{dr["MONEDA"].ToString()}",
                            Monto = Convert.ToDecimal(dr["MONTO"]),
                            //Monto_Dolar = Convert.ToDecimal(dr["MONTO_DOLAR"]),
                            Forma_Pago = dr["FORMA_PAGO"].ToString(),
                            Descripcion = dr["DESCRIPCION"].ToString(),
                            Moneda = dr["MONEDA"].ToString(),
                            TipoDocumento = dr["TIPO_DOCUMENTO"].ToString()
                        };

                        datosCierreCaja.Add(datos_);
                    }

                }

                //verificcar si hay datos para el cierre
                if (datosCierreCaja.Count == 0)
                {
                    responseModel.Exito = 0;
                    responseModel.Mensaje = $"No hay registro para el cierre";
                    return datosCierreCaja;
                }
                //de lo contrario obtengo datos del cierre_pos
                else if (datosCierreCaja.Count >0)
                {
                    
                    responseModel = await ObtenerCierrePos(caja, cajero, numCierre, responseModel);


                    if (responseModel.Exito ==1)
                    {
                        responseModel.Exito = 1;
                        responseModel.Mensaje = $"Consulta exitosa";
                    }
                    else
                    {
                        responseModel.Exito = 0;
                        responseModel.Mensaje = $"No hay registro para el cierre";
                    }
                }

            }
            catch (Exception ex)
            {
                //-1 para indicar que existe una exception
                responseModel.Exito = -1;
                //indicar el mensaje del error
                responseModel.Mensaje = ex.Message;
            }
            return datosCierreCaja;
        }

        public async Task<List<Denominacion>> ObtenerListaDenominacion(ResponseModel responseModel)
        {
            var denominacion = new List<Denominacion>();
            try
            {
                using (TiendaDbContext _db = new TiendaDbContext())
                {
                    denominacion = await _db.Denominacion.OrderBy(d => d.Denom_Monto).ToListAsync();
                }

                if (denominacion.Count > 0)
                {
                    responseModel.Exito = 1;
                    responseModel.Mensaje = $"Consulta exitosa";
                }
                else
                {
                    responseModel.Exito = 0;
                    responseModel.Mensaje = $"No hay registro de las denominaciones de Billetes";
                }

            }
            catch (Exception ex)
            {
                responseModel.Exito = -1;
                responseModel.Mensaje = ex.Message;
            }
            return denominacion;
        }

        public async Task<ResponseModel> GuardarCierreCaja(ViewModelCierre ViewModelCierre, ResponseModel responseModel)
        {
            var result = 0;
            try
            {
                //model.Fecha = DateTime.Now.Date;
                using (SqlConnection cn = new SqlConnection(ConectionContext.GetConnectionSqlServer()))
                {
                    //Abrir la conección 
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("SP_GuardarCierreCaja", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 0;

                        cmd.Parameters.AddWithValue("@Caja", ViewModelCierre.Cierre_Pos.Caja);
                        cmd.Parameters.AddWithValue("@Cajero", ViewModelCierre.Cierre_Pos.Cajero);
                        cmd.Parameters.AddWithValue("@NumCierre", ViewModelCierre.Cierre_Pos.Num_Cierre);
                        cmd.Parameters.AddWithValue("@TotalDiferencia", ViewModelCierre.Cierre_Pos.Total_Diferencia);
                        cmd.Parameters.AddWithValue("@Total_Local", ViewModelCierre.Cierre_Pos.Total_Local);
                        cmd.Parameters.AddWithValue("@Total_Dolar", ViewModelCierre.Cierre_Pos.Total_Dolar);
                        cmd.Parameters.AddWithValue("@Ventas_Efectivo", ViewModelCierre.Cierre_Pos.Ventas_Efectivo);
                        cmd.Parameters.AddWithValue("@CobroEfectivoRep", ViewModelCierre.Cierre_Pos.Cobro_Efectivo_Rep);
                        cmd.Parameters.AddWithValue("@Notas", ViewModelCierre.Cierre_Pos.Notas);

                        var dt = new DataTable();
                        //dt.Columns.Add("NumCierre", typeof(string));
                        //dt.Columns.Add("Cajero", typeof(string));
                        //dt.Columns.Add("Caja", typeof(string));
                        dt.Columns.Add("TipoPago", typeof(string));
                        dt.Columns.Add("TotalSistena", typeof(decimal));
                        dt.Columns.Add("TotalUsuario", typeof(decimal));
                        dt.Columns.Add("Diferencia", typeof(decimal));
                        dt.Columns.Add("Orden", typeof(int));
                        dt.Columns.Add("Moneda", typeof(string));

                        foreach (var item in ViewModelCierre.Cierre_Det_Pago)
                        {
                            dt.Rows.Add(item.Tipo_Pago, item.Total_Sistema, item.Total_Usuario, item.Diferencia, item.Orden, item.Moneda );
                            //{
                            //    Num_Cierre = viewCierreCaja.NumCierre,
                            //    Cajero = viewCierreCaja.Cajero,
                            //    Caja =viewCierreCaja.Caja,
                            //    Tipo_Pago = item.Tipo_Pago,
                            //    Total_Sistema = item.Total_Sistema,
                            //    Total_Usuario = item.Total_Usuario,
                            //    Diferencia = item.Diferencia,
                            //    Orden = item.Orden
                            //};
                            //dtCierrPago.Add(_det);
                        }

                        var parametro = cmd.Parameters.AddWithValue("@ListDetallePago", dt);
                        parametro.SqlDbType = SqlDbType.Structured;

                        result = await cmd.ExecuteNonQueryAsync();

                    }
                }

                if (result > 0)
                {
                    responseModel.Exito = 1;
                    responseModel.Mensaje = $"El cierre se realizó exitosamente";
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

        public async Task<ResponseModel> ObtenerFacturaLineaCierraCaja(string caja, string numCierre, ViewModelCierre reporteCierre, ResponseModel responseModel)
        {
           
            try
            {
                using (TiendaDbContext _db = new TiendaDbContext())
                {
                    reporteCierre.FacturaLinea = await _db.Database.SqlQuery<Factura_Linea>($"SELECT FACTURA_LINEA.* FROM TIENDA.FACTURA_LINEA INNER JOIN " +
                       $" TIENDA.FACTURA ON TIENDA.FACTURA_LINEA.TIPO_DOCUMENTO = TIENDA.FACTURA.TIPO_DOCUMENTO AND TIENDA.FACTURA_LINEA.FACTURA = TIENDA.FACTURA.FACTURA " +
                       $" WHERE FACTURA.NUM_CIERRE = '{numCierre}' AND FACTURA.MULTIPLICADOR_EV IN(-1, 1) AND FACTURA.ANULADA='N' AND FACTURA.COBRADA='S' AND FACTURA.CAJA='{caja}' ORDER BY FACTURA.FACTURA").ToListAsync();
                }
                
                if (reporteCierre.FacturaLinea.Count > 0)
                {
                    responseModel.Data = reporteCierre as ViewModelCierre;
                    responseModel.Exito = 1;
                    responseModel.Mensaje = $"Consulta exitosa";
                }
                else
                {
                    responseModel.Exito = 1;
                    responseModel.Mensaje = $"No hay factura para el cierre";
                }

            }
            catch (Exception ex)
            {
                //-1 para indicar que existe una exception
                responseModel.Exito = -1;
                //indicar el mensaje del error
                responseModel.Mensaje = ex.Message;
            }
            return responseModel;
        }

        ///estoy haciendo este metodo para la consulta.. 11/04/2023
        public async Task<ResponseModel> ObtenerDatosCierreCaja(string caja, string numCierre, ViewModelCierre reporteCierre, ResponseModel responseModel)
        {
            bool resultExitoso = false;
     
            try
            {
                
                using (SqlConnection cn = new SqlConnection(ConectionContext.GetConnectionSqlServer()))
                {
                    //Abrir la conección 
                    await cn.OpenAsync();
                    SqlCommand cmd = new SqlCommand("SP_ObtenerDatosCierreCaja", cn);
                    cmd.CommandTimeout = 0;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Caja", caja);                    
                    cmd.Parameters.AddWithValue("@NumCierre", numCierre);
                    var dr = await cmd.ExecuteReaderAsync();

                
                    while (await dr.ReadAsync())
                    {
                        resultExitoso = true;
                        var datos_ = new DetalleFacturaCierreCaja()
                        {                            
                            Factura = dr["FACTURA"].ToString(),
                            Impuesto = Convert.ToDecimal(dr["IMPUESTO1"]),
                            Caja = dr["CAJA"].ToString(),
                            //TOTAL_MERCADERIA= SUBTOTAL
                            SubTotal = Convert.ToDecimal(dr["SUB_TOTAL"]),
                            //se refiere al descuento general (5%)
                            Descuento = Convert.ToDecimal(dr["MONTO_DESCUENTO1"]),
                            TotalPagar = Convert.ToDecimal(dr["TOTAL_PAGAR"]),
                            MontoRetencion= Convert.ToDecimal(dr["MONTO_RETENCION"]),
                            Documento = dr["DOCUMENTO"].ToString(),
                            Multiplicador_Ev = Convert.ToInt16(dr["MULTIPLICADOR_EV"])
                        };

                        reporteCierre.DetalleFacturaCierreCaja.Add(datos_);                                      
                    }

                }

                if (resultExitoso)
                {
                    responseModel.Data = reporteCierre as ViewModelCierre;
                    responseModel.Exito = 1;
                    responseModel.Mensaje = $"Consulta exitosa";
                }
                else
                {
                    responseModel.Exito = 1;
                    responseModel.Mensaje = $"No hay factura para el cierre";
                }

            }
            catch (Exception ex)
            {
                //-1 para indicar que existe una exception
                responseModel.Exito = -1;
                //indicar el mensaje del error
                responseModel.Mensaje = ex.Message;
            }
            return responseModel;
        }

        //obtener los datos del cierre del cajero para imprimir el reporte.
        public async Task<ResponseModel> ObtenerDatosCierreCajero(string caja, string cajero, string numCierre, ViewModelCierre reporteCierre, ResponseModel responseModel)
        {
            bool resultExitoso = false;
           /* ViewModelCierre reporteCierre = new ViewModelCierre();
            reporteCierre.Cierre_Pos = new Cierre_Pos();
            reporteCierre.Cierre_Det_Pago = new List<Cierre_Det_Pago>();*/
            
            try
            {
                //model.Fecha = DateTime.Now.Date;
                using (SqlConnection cn = new SqlConnection(ConectionContext.GetConnectionSqlServer()))
                {
                    //Abrir la conección 
                    await cn.OpenAsync();
                    SqlCommand cmd = new SqlCommand("SP_ObtenerDatosCierreCajero", cn);
                    cmd.CommandTimeout = 0;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Caja", caja);
                    cmd.Parameters.AddWithValue("@Cajero", cajero);
                    cmd.Parameters.AddWithValue("@NumCierre", numCierre);
                    var dr = await cmd.ExecuteReaderAsync();

                    int row = 1;
                    while (await dr.ReadAsync())
                    {
                        resultExitoso = true;
                        var datos_ = new Cierre_Det_Pago()
                        {
                            Num_Cierre =dr["NUM_CIERRE"].ToString(),
                            Cajero = dr["CAJERO"].ToString(),                            
                            Caja = dr["CAJA"].ToString(),
                            Tipo_Pago = dr["TIPO_PAGO"].ToString(),
                            Total_Sistema = Convert.ToDecimal(dr["TOTAL_SISTEMA"]),
                            Total_Usuario =Convert.ToDecimal(dr["TOTAL_USUARIO"]),
                            Diferencia = Convert.ToDecimal(dr["DIFERENCIA"].ToString()),
                            Moneda = dr["MONEDA"]?.ToString()
                        };

                        reporteCierre.Cierre_Det_Pago.Add(datos_);

                        //verificar que sea la primer linea, ya que la tabla Cierre_Pos solo tiene un registro
                        if (row ==1)
                        {
                            reporteCierre.Cierre_Pos.Num_Cierre = dr["NUM_CIERRE"].ToString();
                            reporteCierre.Cierre_Pos.Cajero = dr["CAJERO"].ToString();
                            reporteCierre.Cierre_Pos.Caja = dr["CAJA"].ToString();
                            reporteCierre.Cierre_Pos.Nombre_Vendedor = dr["NOMBRE_VENDEDOR"].ToString();
                            reporteCierre.Cierre_Pos.Fecha_Hora = Convert.ToDateTime(dr["FECHA_HORA"]);
                            reporteCierre.Cierre_Pos.Tipo_Cambio = Convert.ToDecimal(dr["TIPO_CAMBIO"]);
                            reporteCierre.Cierre_Pos.Monto_Apertura = Convert.ToDecimal(dr["MONTO_APERTURA"]);
                            reporteCierre.Cierre_Pos.Total_Diferencia = Convert.ToDecimal(dr["TOTAL_DIFERENCIA"]);
                            reporteCierre.Cierre_Pos.Documento_Ajuste = dr["DOCUMENTO_AJUSTE"]?.ToString();
                            //TOTAL_LOCAL= [es la suma de todo lo q se recibió en cordoba incluyendo efectivo, tarjeta, cheque, etc pero qque solo sea córdobas]
                            reporteCierre.Cierre_Pos.Total_Local = Convert.ToDecimal(dr["TOTAL_LOCAL"]);
                            //--TOTAL_DOLAR=[es la suma de todo el dinero q se recibió en dolares incluyendo efectivo, tarjeta cheque, pero que solo sea dólar     
                            reporteCierre.Cierre_Pos.Total_Dolar = Convert.ToDecimal(dr["TOTAL_DOLAR"]);
                            //VENTAS_EFECTIVO= [es la suma solo en efectivo en cordoba y nada mas]
                            reporteCierre.Cierre_Pos.Ventas_Efectivo = Convert.ToDecimal(dr["VENTAS_EFECTIVO"]);
                            //Indica si el cierre esta abierto(A); cerrado(C) o anulado(N)
                            reporteCierre.Cierre_Pos.Estado = dr["ESTADO"].ToString();
                            reporteCierre.Cierre_Pos.Fecha_Hora_Inicio = Convert.ToDateTime(dr["FECHA_HORA_INICIO"]);
                            reporteCierre.Cierre_Pos.Notas = dr["NOTAS"]?.ToString();
                            //es la suma solo en efectivo en dolares y nada mas
                            reporteCierre.Cierre_Pos.Cobro_Efectivo_Rep = Convert.ToDecimal(dr["COBRO_EFECTIVO_REP"]);
                            reporteCierre.Cierre_Pos.Num_Cierre_Caja = dr["NUM_CIERRE_CAJA"].ToString();
                            reporteCierre.Cierre_Pos.Documento = dr["DOCUMENTO"].ToString();
                        }

                        //incrementar para identificar la primer fila.
                        row += 1;
                    }

                }

                if (resultExitoso)
                {
                    responseModel.Data = reporteCierre as ViewModelCierre;
                    responseModel.Exito = 1;
                    responseModel.Mensaje = $"Consulta exitosa";
                }
                else
                {
                    responseModel.Exito = 0;
                    responseModel.Mensaje = $"No hay registro";
                }

            }
            catch (Exception ex)
            {
                //-1 para indicar que existe una exception
                responseModel.Exito = -1;
                //indicar el mensaje del error
                responseModel.Mensaje = ex.Message;
            }
            return responseModel;
        }

        public async Task<ResponseModel> ObtenerDesgloseVentasTarjetas(string caja, string cajero, string numCierre, ViewModelCierre reporteCierre, ResponseModel responseModel)
        {            
            //ViewModelCierre reporteCierre = new ViewModelCierre();            
            //reporteCierre.Cierre_Desg_Tarj = new List<Cierre_Desg_Tarj>();

          
            try
            {
                //model.Fecha = DateTime.Now.Date;
                using (SqlConnection cn = new SqlConnection(ConectionContext.GetConnectionSqlServer()))
                {
                    //Abrir la conección 
                    await cn.OpenAsync();
                    SqlCommand cmd = new SqlCommand("SP_ObtenerDesgloseVentasTarjetas", cn);
                    cmd.CommandTimeout = 0;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Caja", caja);
                    cmd.Parameters.AddWithValue("@Cajero", cajero);
                    cmd.Parameters.AddWithValue("@NumCierre", numCierre);


                    var dr = await cmd.ExecuteReaderAsync();
                    while (await dr.ReadAsync())
                    {
                        var datos_ = new Cierre_Desg_Tarj()
                        {
                            Num_Cierre = dr["NUM_CIERRE"].ToString(),                            
                            Cajero = dr["CAJERO"].ToString(),
                            Caja = dr["CAJA"].ToString(),
                            Tipo_Tarjeta = dr["TIPO_TARJETA"].ToString(),
                            Documento = dr["DOCUMENTO"].ToString(),
                            Autorizacion = dr["AUTORIZACION"]?.ToString(),
                            Monto = Convert.ToDecimal(dr["MONTO"]),
                                                     
                        };

                        reporteCierre.Cierre_Desg_Tarj.Add(datos_);
                    }

                }

                if (reporteCierre.Cierre_Desg_Tarj.Count > 0)
                {
                    responseModel.Exito = 1;
                    responseModel.Mensaje = $"Consulta exitosa";
                    responseModel.Data = reporteCierre as ViewModelCierre;
                }
                else 
                {
                    responseModel.Exito = 1;
                    responseModel.Mensaje = $"No hay desglose de tarjeta";
                }

            }
            catch (Exception ex)
            {
                //-1 para indicar que existe una exception
                responseModel.Exito = -1;
                //indicar el mensaje del error
                responseModel.Mensaje = ex.Message;
            }
            return responseModel;
        }

        public async Task<ResponseModel> ObtenerRegistro_ReporteCierre( string caja, string cajero, string numCierre, ResponseModel responseModel)
        {                                
            try
            {
                ViewModelCierre reporteCierre = new ViewModelCierre();
                reporteCierre.Cierre_Pos = new Cierre_Pos();
                reporteCierre.Cierre_Det_Pago = new List<Cierre_Det_Pago>();
                reporteCierre.Cierre_Desg_Tarj = new List<Cierre_Desg_Tarj>();
                reporteCierre.DetalleFacturaCierreCaja = new List<DetalleFacturaCierreCaja>();
                reporteCierre.FacturaLinea = new List<Factura_Linea>();
                responseModel.Data = new ViewModelCierre();

                //obtener los datos del cierre del cajero
                responseModel = await ObtenerDatosCierreCajero(caja, cajero, numCierre, reporteCierre, responseModel);
                //si la respuesta del servidor es diferente a 1 (1 es exitoso, cualquiere otro numero significa que hubo algun problema.
                if (responseModel.Exito != 1) return responseModel;

                //obtener el detalle del desglose de ventas de tarjetas
                responseModel = await ObtenerDesgloseVentasTarjetas(caja, cajero, numCierre, reporteCierre, responseModel);
                //si la respuesta del servidor es diferente a 1 (1 es exitoso, cualquiere otro numero significa que hubo algun problema.
                if (responseModel.Exito != 1) return responseModel;

                //obtener el detalle 
                responseModel = await ObtenerDatosCierreCaja(caja, numCierre, reporteCierre, responseModel);             

                //si la respuesta del servidor es diferente a 1 (1 es exitoso, cualquiere otro numero significa que hubo algun problema.
                if (responseModel.Exito != 1) return responseModel;

                responseModel = await ObtenerFacturaLineaCierraCaja(caja, numCierre, reporteCierre, responseModel);

                //si la respuesta del servidor es diferente a 1 (1 es exitoso, cualquiere otro numero significa que hubo algun problema.
                if (responseModel.Exito != 1) return responseModel;
            }
            catch (Exception ex)
            {
                responseModel.Exito = -1;
                responseModel.Mensaje = ex.Message;
            }


            return responseModel;
        }
    }
}