using Api.Context;
using Api.Helpers;
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
    public class ServiceFactura
    {

        public ServiceFactura()
        {
        }


        //Listar informacion de inicio la factura
        public async Task<ListarDatosFactura> ListarInformacionInicioFactura()
        {

            var listarDatosFactura = new ListarDatosFactura();
            listarDatosFactura.tipoDeCambio = 0;
            listarDatosFactura.bodega = new List<Bodegas>();
            listarDatosFactura.NoFactura = "";

            try
            {
             
                //obtener el tipo de cambio 
                listarDatosFactura = await ObtenerTipoCambioDelDiaAsync(listarDatosFactura);
                //si la respuesta del servidor es diferente a 1 (1 es exitoso, cualquiere otro numero significa que hubo algun problema)
                if (listarDatosFactura.Exito != 1) return listarDatosFactura;

                //obtener la lista de la bodega que corresponda
                listarDatosFactura = await ListarBodegasAsync(User.TiendaID, listarDatosFactura);
                // si la respuesta del servidor es diferente a 1(1 es exitoso, cualquiere otro numero significa que hubo algun problema)
                if (listarDatosFactura.Exito != 1) return listarDatosFactura;
                              
                //obtener el siguiente numero de factura
                listarDatosFactura = await GenerarConsecutivoNoFactura(User.Usuario, User.Caja, User.ConsecCierreCT, User.MascaraFactura, User.UnidadNegocio, listarDatosFactura);
                // si la respuesta del servidor es diferente a 1(1 es exitoso, cualquiere otro numero significa que hubo algun problema)
                if (listarDatosFactura.Exito != 1) return listarDatosFactura;                

            }
            catch (Exception ex)
            {
                listarDatosFactura.Exito = -1;
                listarDatosFactura.Mensaje = ex.Message;
            }
            finally
            {

            }

            return listarDatosFactura;
        }

        //otener el tipo de cambio del dia
        public async Task<ListarDatosFactura> ObtenerTipoCambioDelDiaAsync(ListarDatosFactura listarDatosFactura)
        {
            decimal tipoCambio = 0.0000M;
            bool resultExitoso = false;

            try
            {
               // var fecha = DateTime.Now.Date;
                using (SqlConnection cn = new SqlConnection(ConectionContext.GetConnectionSqlServer()))
                {
                    //Abrir la conección 
                    await cn.OpenAsync();
                    SqlCommand cmd = new SqlCommand("SP_ObtenerTipoCambioVenta", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 0;
                   
                    var dr = await cmd.ExecuteReaderAsync();
                    if (await dr.ReadAsync())
                    {
                        resultExitoso = true;
                        tipoCambio = Convert.ToDecimal(dr["MONTO"]);
                    }
                }

                if (resultExitoso)
                {
                    listarDatosFactura.Exito = 1;
                    listarDatosFactura.Mensaje = "Consulta Exitosa";
                    //asignar el tipo de cambio del dia
                    listarDatosFactura.tipoDeCambio = Convert.ToDecimal(tipoCambio);
                }
                else
                {
                    listarDatosFactura.Exito = 0;
                    listarDatosFactura.Mensaje = "El Tipo de cambio del dia no existe en la base de datos";
                }

            }
            catch (Exception ex)
            {
                listarDatosFactura.Exito = -1;
                throw new Exception(ex.Message);
            }

            return listarDatosFactura;
        }

        public async Task<ListarDatosFactura> ListarBodegasAsync(string tiendaID, ListarDatosFactura listarDatosFactura)
        {
            var ListBodega = new List<Bodegas>();
            try
            {
                using (TiendaDbContext _db = new TiendaDbContext())
                {
                    //mostrar la bodega que este activo y q sea de Tipo Venta(V) y que sea de la tienda
                    ListBodega = await _db.Bodegas.Where(b => b.Activo == true && b.Tipo == "V" && b.U_Tienda_Madre == tiendaID).ToListAsync();
                }

                if (ListBodega.Count > 0)
                {
                    listarDatosFactura.Exito = 1;
                    listarDatosFactura.Mensaje = "Consulta exitosa";
                    listarDatosFactura.bodega = ListBodega;
                }
                else
                {
                    listarDatosFactura.Exito = 0;
                    listarDatosFactura.Mensaje = "No hay registro de Bodega";
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return listarDatosFactura;
        }
        public async Task<List<ViewFactura>> ListarFacturasAsync(FiltroFactura filtroFactura, ResponseModel responseModel)
        {
            var listaFactura = new List<ViewFactura>();

            try
            {
                using (TiendaDbContext _db = new TiendaDbContext())
                {
                    switch (filtroFactura.Tipofiltro)
                    {
                        case "Factura del dia":
                            var fechaDeHoy = DateTime.Now.Date;

                            listaFactura = await _db.ViewFactura.Where(x => x.Num_Cierre == filtroFactura.Busqueda).ToListAsync();
                            //listaArticulo =await _db.ARTICULOS.FromSqlRaw("SELECT ARTICULO, DESCRIPCION From TIENDA.ARTICULO Where ARTICULO = {0}", consulta).FirstOrDefault();
                            break;

                        //case "Recuperar factura":
                        //    listaFactura = await _db.FacturaTemporal.Where(x => x.Factura == filtroFactura.Busqueda).ToListAsync();
                        //    //listaArticulo =await _db.ARTICULOS.FromSqlRaw("SELECT ARTICULO, DESCRIPCION From TIENDA.ARTICULO Where ARTICULO = {0}", consulta).FirstOrDefault();
                        //    break;

                        case "Rango de fecha":
                            listaFactura = await _db.ViewFactura.Where(x => x.Fecha >= filtroFactura.FechaInicio && x.Fecha <= filtroFactura.FechaFinal).ToListAsync();
                            //listaArticulo =await _db.ARTICULOS.FromSqlRaw("SELECT ARTICULO, DESCRIPCION From TIENDA.ARTICULO Where ARTICULO = {0}", consulta).FirstOrDefault();
                            break;

                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return listaFactura;
        }

        public async Task<ResponseModel> BuscarFactura(FiltroFactura filtroFactura, ResponseModel responseModel)
        {
            var listaFactura = new List<ViewFactura>();  
            string fechaInicio = filtroFactura.FechaInicio.Value.Year.ToString() + "-" + filtroFactura.FechaInicio.Value.Month.ToString() + "-" + filtroFactura.FechaInicio.Value.Day.ToString();
            string fechaFinal = filtroFactura.FechaFinal.Value.Year.ToString() + "-" + filtroFactura.FechaFinal.Value.Month.ToString() + "-" + filtroFactura.FechaFinal.Value.Day.ToString();

            try
            {
                using (TiendaDbContext _db = new TiendaDbContext())
                {
                    switch (filtroFactura.Tipofiltro)
                    {
                        case "Fecha":
                            var fechaDeHoy = DateTime.Now.Date;

                            //listaFactura = await _db.ViewFactura.Where(vf => vf.Fecha >= filtroFactura.FechaInicio && vf.Fecha <= filtroFactura.FechaFinal).ToListAsync();
                            listaFactura = await _db.Database.SqlQuery<ViewFactura>($"SELECT * FROM dbo.ViewFactura WHERE ANULADA='N' AND Tienda_Enviado='{User.TiendaID}' AND (CONVERT(DATE, FECHA) BETWEEN '{ fechaInicio }' AND '{ fechaFinal }')  ORDER BY FECHA").ToListAsync();
                            break;

                        case "Fecha_Caja":
                            //  listaFactura = await _db.ViewFactura.Where(vf => vf.Fecha >= filtroFactura.FechaInicio && vf.Fecha <= filtroFactura.FechaFinal && vf.Caja == filtroFactura.Caja).ToListAsync();
                            listaFactura = await _db.Database.SqlQuery<ViewFactura>($"SELECT * FROM dbo.ViewFactura WHERE ANULADA='N'  AND Tienda_Enviado='{User.TiendaID}' AND (CONVERT(DATE, FECHA) BETWEEN '{ fechaInicio }' AND '{ fechaFinal }') AND ( Caja = '{ filtroFactura.Caja }')  ORDER BY FECHA").ToListAsync();
                            //listaArticulo =await _db.ARTICULOS.FromSqlRaw("SELECT ARTICULO, DESCRIPCION From TIENDA.ARTICULO Where ARTICULO = {0}", consulta).FirstOrDefault();
                            break;

                        case "Fecha_Factura":
                            //listaFactura = await _db.ViewFactura.Where(vf => vf.Fecha >= filtroFactura.FechaInicio && vf.Fecha <= filtroFactura.FechaFinal
                            //                                            && (vf.Factura >= filtroFactura.FacturaDesde) && vf.Factura <= Convert.ToInt32(filtroFactura.FacturaHasta)).ToListAsync();

                            listaFactura = await _db.Database.SqlQuery<ViewFactura>($"SELECT  * FROM dbo.ViewFactura WHERE ANULADA='N'  AND Tienda_Enviado='{User.TiendaID}' AND (CONVERT(DATE,FECHA) BETWEEN '{ fechaInicio }' AND '{ fechaFinal}') AND (FACTURA BETWEEN '{filtroFactura.FacturaDesde}' AND '{filtroFactura.FacturaHasta}' )  ORDER BY FECHA").ToListAsync();
                            break;

                        case "Fecha_Caja_Factura":

                          
                            listaFactura = await _db.Database.SqlQuery<ViewFactura>($"SELECT  * FROM dbo.ViewFactura WHERE ANULADA='N'  AND Tienda_Enviado='{User.TiendaID}' AND (FECHA BETWEEN '{ fechaInicio }' AND '{ fechaFinal}') " +
                                $"AND (FACTURA BETWEEN '{filtroFactura.FacturaDesde}' AND '{filtroFactura.FacturaHasta}') AND (Caja = '{filtroFactura.Caja}')  ORDER BY FECHA").ToListAsync();
                            break;
                    }
                }


                if (listaFactura.Count > 0)
                {
                    responseModel.Exito = 1;
                    responseModel.Mensaje = "Consulta Exitosa";
                    responseModel.Data = listaFactura as List<ViewFactura>;
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

        public async Task<ResponseModel> BuscarCierreCajero(FiltroFactura filtroFactura, ResponseModel responseModel)
        {         
            var listCierrePos = new List<Cierre_Pos>();
           
          
            try
            {
                using (TiendaDbContext _db = new TiendaDbContext())
                {
                    switch (filtroFactura.Tipofiltro)
                    {
                      
                        case "Cierre Cajero":

                            DateTime ultimaFecha = _db.Cierre_Pos.Where(cp => cp.Cajero == filtroFactura.Cajero && cp.Estado == "C").Max(cp => cp.Fecha_Hora);
                            listCierrePos = await _db.Cierre_Pos.Where(cp => cp.Cajero == filtroFactura.Cajero && cp.Fecha_Hora == ultimaFecha && cp.Estado == "C").ToListAsync();
                            break;                    
                    }
                }


                if (listCierrePos.Count > 0)
                {
                    responseModel.Exito = 1;
                    responseModel.Mensaje = "Consulta Exitosa";
                    responseModel.Data = listCierrePos as List<Cierre_Pos>;
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

        public async Task<ResponseModel> BuscarCierreCaja(FiltroFactura filtroFactura, ResponseModel responseModel)
        {
           
            var listCierreCaja = new List<Cierre_Caja>();

            try
            {
                using (TiendaDbContext _db = new TiendaDbContext())
                {
                    switch (filtroFactura.Tipofiltro)
                    {
                        case "Cierre Caja":
                            DateTime fechaApertura = _db.Cierre_Caja.Where(cp => cp.Cajero_Cierre == filtroFactura.Cajero && cp.Estado == "C").Max(cp => cp.Fecha_Apertura);
                            listCierreCaja = await _db.Cierre_Caja.Where(cp => cp.Cajero_Cierre == filtroFactura.Cajero && cp.Fecha_Apertura == fechaApertura && cp.Estado == "C").ToListAsync();
                            if (listCierreCaja.Count > 0)
                            {
                                var NumCierreCaja = listCierreCaja.Where(cp => cp.Cajero_Cierre == filtroFactura.Cajero && cp.Fecha_Apertura == fechaApertura).Select(x => x.Num_Cierre_Caja).FirstOrDefault();
                                var cierrPos = await _db.Cierre_Pos.Where(cp => cp.Num_Cierre_Caja == NumCierreCaja).FirstOrDefaultAsync();
                                listCierreCaja[0].Num_Cierre = cierrPos.Num_Cierre;
                            }
                            break;
                    }
                }


                if (listCierreCaja.Count > 0)
                {
                    responseModel.Exito = 1;
                    responseModel.Mensaje = "Consulta Exitosa";
                    responseModel.Data = listCierreCaja as List<Cierre_Caja>;
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
        public async Task<ResponseModel> BuscarFacturaParaAnular(FiltroFactura filtroFactura, ResponseModel responseModel)
        {
            var listaFactura = new List<ViewFactura>();

            try
            {
                using (TiendaDbContext _db = new TiendaDbContext())
                {
                    switch (filtroFactura.Tipofiltro)
                    {
                        case "Fecha":
                            var fechaDeHoy = DateTime.Now.Date;

                            listaFactura = await _db.ViewFactura.Where(vf => vf.Fecha >= filtroFactura.FechaInicio && vf.Fecha <= filtroFactura.FechaFinal).ToListAsync();
                            //listaArticulo =await _db.ARTICULOS.FromSqlRaw("SELECT ARTICULO, DESCRIPCION From TIENDA.ARTICULO Where ARTICULO = {0}", consulta).FirstOrDefault();
                            break;

                        case "Fecha_Caja":
                            listaFactura = await _db.ViewFactura.Where(vf => vf.Fecha >= filtroFactura.FechaInicio && vf.Fecha <= filtroFactura.FechaFinal && vf.Caja == filtroFactura.Caja).ToListAsync();
                            //listaArticulo =await _db.ARTICULOS.FromSqlRaw("SELECT ARTICULO, DESCRIPCION From TIENDA.ARTICULO Where ARTICULO = {0}", consulta).FirstOrDefault();
                            break;

                        case "Fecha_Factura":

                            listaFactura = await _db.Database.SqlQuery<ViewFactura>($"SELECT  * FROM dbo.ViewFactura WHERE (FECHA BETWEEN '{ filtroFactura.FechaInicio }' AND '{ filtroFactura.FechaFinal}') AND (FACTURA BETWEEN '{filtroFactura.FacturaDesde}' AND '{filtroFactura.FacturaHasta}' )").ToListAsync();
                            break;

                        case "Fecha_Caja_Factura":

                            listaFactura = await _db.Database.SqlQuery<ViewFactura>($"SELECT  * FROM dbo.ViewFactura WHERE (FECHA BETWEEN '{ filtroFactura.FechaInicio }' AND '{ filtroFactura.FechaFinal}') " +
                            $"AND (FACTURA BETWEEN '{filtroFactura.FacturaDesde}' AND '{filtroFactura.FacturaHasta}') AND (Caja = '{filtroFactura.Caja}')").ToListAsync();
                            break;
                    }
                }


                if (listaFactura.Count > 0)
                {
                    responseModel.Exito = 1;
                    responseModel.Mensaje = "Consulta Exitosa";
                    responseModel.Data = listaFactura as List<ViewFactura>;
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


        public async Task<List<Facturando>> ListarFacturaTemporalesAsync(FiltroFactura filtroFactura, ResponseModel responseModel)
        {

            var listaFacturaTemp = new List<Facturando>();

            try
            {
                using (TiendaDbContext _db = new TiendaDbContext())
                {
                    switch (filtroFactura.Tipofiltro)
                    {
                        case "Factura Perdidas":
                            listaFacturaTemp = await _db.Facturando.Where(x => x.Factura == filtroFactura.Busqueda).ToListAsync();
                            //listaArticulo =await _db.ARTICULOS.FromSqlRaw("SELECT ARTICULO, DESCRIPCION From TIENDA.ARTICULO Where ARTICULO = {0}", consulta).FirstOrDefault();
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return listaFacturaTemp;
        }

        //obtener el siguiente numero consecutivo
        public async Task<ListarDatosFactura> GenerarConsecutivoNoFactura(string cajero, string caja, string numCierre, string mascaraFactura, string unidadNegocio, ListarDatosFactura listarDatosFactura)
        {
            bool resultExitoso = false;
            try
            {
                using (SqlConnection cn = new SqlConnection(ConectionContext.GetConnectionSqlServer()))
                {
                    //Abrir la conección 
                    await cn.OpenAsync();
                    SqlCommand cmd = new SqlCommand("SP_GenerarNumeroFactura", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 0;
                    cmd.Parameters.AddWithValue("@Cajero", cajero);
                    cmd.Parameters.AddWithValue("@Caja", caja);
                    cmd.Parameters.AddWithValue("@NumCierre", numCierre);
                    cmd.Parameters.AddWithValue("@MascaraFactura", mascaraFactura);
                    cmd.Parameters.AddWithValue("@UnidadNegocio", unidadNegocio);

                    var dr = await cmd.ExecuteReaderAsync();
                    if (await dr.ReadAsync())
                    {
                        resultExitoso = true;
                        listarDatosFactura.NoFactura = dr["Factura"].ToString();
                    }
                }

                if (resultExitoso)
                {
                    listarDatosFactura.Exito = 1;
                    listarDatosFactura.Mensaje = "Consulta exitosa";
                }
                else
                {
                    listarDatosFactura.Exito = 0;
                    listarDatosFactura.Mensaje = "No se pudo generar el siguiente numero de factura";
                }

            }
            catch (Exception ex)
            {
                listarDatosFactura.Exito = -1;
                throw new Exception(ex.Message);
            }
            return listarDatosFactura;
        }

        public async Task<ResponseModel> InsertOrUpdateFacturaTemporal(Facturando model, ResponseModel responseModel)
        {
            int result = 0;
            try
            {
                model.FechaRegistro = DateTime.Now.Date;
                using (SqlConnection cn = new SqlConnection(ConectionContext.GetConnectionSqlServer()))
                {
                    //Abrir la conección 
                    await cn.OpenAsync();
                    SqlCommand cmd = new SqlCommand("SP_GuardarFacturaTemporal", cn);
                    cmd.CommandTimeout = 0;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Factura", model.Factura);
                    cmd.Parameters.AddWithValue("@ArticuloID", model.ArticuloID);
                    cmd.Parameters.AddWithValue("@CodigoCliente", model.CodigoCliente);
                    cmd.Parameters.AddWithValue("@FacturaEnEspera", model.FacturaEnEspera);
                    cmd.Parameters.AddWithValue("@Cajero", model.Cajero);
                    cmd.Parameters.AddWithValue("@Caja", model.Caja);
                    cmd.Parameters.AddWithValue("@NumCierre", model.NumCierre);
                    cmd.Parameters.AddWithValue("@TiendaID", model.TiendaID);
                    cmd.Parameters.AddWithValue("@TipoCambio", model.TipoCambio);
                    cmd.Parameters.AddWithValue("@Bodega", model.BodegaID);
                    cmd.Parameters.AddWithValue("@Consecutivo", model.Consecutivo);
                    cmd.Parameters.AddWithValue("@CodigoBarra", model.CodigoBarra);
                    cmd.Parameters.AddWithValue("@Cantidad", model.Cantidad);
                    cmd.Parameters.AddWithValue("@Descripcion", model.Descripcion);
                    cmd.Parameters.AddWithValue("@Unidad", model.Unidad);
                    cmd.Parameters.AddWithValue("@Precio", model.Precio);
                    cmd.Parameters.AddWithValue("@Moneda", model.Moneda);
                    cmd.Parameters.AddWithValue("@DescuentoLinea", model.DescuentoLinea);
                    cmd.Parameters.AddWithValue("@DescuentoGeneral", model.DescuentoGeneral);
                    cmd.Parameters.AddWithValue("@AplicarDescuento", model.AplicarDescuento);
                    cmd.Parameters.AddWithValue("@Observaciones", model.Observaciones);
                    result = await cmd.ExecuteNonQueryAsync();
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return responseModel;

        }

        private Facturas AsignarNuevosRegistro(ViewModelFacturacion model)
        {
            Facturas factura = new Facturas();
            var FacturaLinea = new List<Factura_Linea>();
            factura = model.Factura;
            FacturaLinea = model.FacturaLinea;

            return factura;
        }

        /// <summary>
        /// guardar o actualizar los datos de la factura
        /// </summary>
        /// <param name="model"></param>
        /// <param name="responseModel"></param>
        /// <returns></returns>
        public async Task<ResponseModel> InsertOrUpdateFactura(ViewModelFacturacion model, ResponseModel responseModel)
        {
            var utilidad = new Utilidades();
            //Facturas facturas = new Facturas();
            ////List<FACTURA_LINEA> facturaLinea = new List<FACTURA_LINEA>();
            //facturas = model.Factura;
            //facturaLinea = model.FacturaLinea;

            int result = 0;

            using (TiendaDbContext _db = new TiendaDbContext())
            {
                //utilizar transacciones
                using (DbContextTransaction transaction = _db.Database.BeginTransaction())
                {
                    try
                    {
                        //generar el Guid
                        model.Factura.RowPointer = utilidad.GenerarGuid();

                        //agregar la factura
                        _db.Facturas.Add(model.Factura);
                        //guardar los cambios en la tabla Factura
                        await _db.SaveChangesAsync();

                        for (int row = 0; row < model.FacturaLinea.Count; ++row)
                        {
                            //instanciar la clase FACTURA_LINEA
                            var facturaLinea = new Factura_Linea();
                            //agregar la primera fila a la clase facturaLinea
                            facturaLinea = model.FacturaLinea.ElementAt<Factura_Linea>(row);

                            //generar el Guid
                            facturaLinea.RowPointer = utilidad.GenerarGuid();
                            //insertar en la base de datos el p
                            _db.Factura_Linea.Add(facturaLinea);
                            await _db.SaveChangesAsync();
                        }

                        for (int row = 0; row < model.PagoPos.Count; row++)
                        {
                            //instanciar la clase Pago_Pos
                            var pagoPos = new Pago_Pos();
                            //agregar la primera fila a la clase Pago_Pos
                            pagoPos = model.PagoPos.ElementAt<Pago_Pos>(row);
                            //asignar el numero de facturas.                        
                            //generar el Guid
                            pagoPos.RowPointer = utilidad.GenerarGuid();
                            //insertar en la base de datos el p
                            _db.Pago_Pos.Add(pagoPos);
                            await _db.SaveChangesAsync();
                        }

                        //comprobar si tiene registro de retenciones
                        if (model.FacturaRetenciones.Count > 0)
                        {
                            for (int row = 0; row < model.FacturaRetenciones.Count; row++)
                            {
                                //instanciar la clase Pago_Pos
                                var _factura_Retenciones = new Factura_Retencion();
                                //agregar la primera fila a la clase Pago_Pos
                                _factura_Retenciones = model.FacturaRetenciones.ElementAt<Factura_Retencion>(row);
                                //asignar el numero de facturas.                        
                                //generar el Guid
                                _factura_Retenciones.RowPointer = utilidad.GenerarGuid();
                                //insertar en la base de datos el p
                                _db.Factura_Retencion.Add(_factura_Retenciones);
                                await _db.SaveChangesAsync();
                            }
                        }


                   
                        transaction.Commit();
                        result = 1;
                    }
                    catch (Exception ex)
                    {
                        responseModel.Exito = -1;
                        transaction.Rollback();
                        throw new Exception(ex.InnerException.Message);
                    }
                }
            }


            if (result > 0)
            {
                if (await RegistrarAuditoriaInventario(model.Factura.Factura) > 0)
                {
                    responseModel.Mensaje = "La factura se ha guardado exitosamente";
                    responseModel.Exito = 1;
                }

            }
            else
            {
                responseModel.Mensaje = "No se pudo guardar la informacion";
                responseModel.Exito = 0;
            }

            return responseModel;
        }

        //concatenar los valores de las retenciones para enviarlo al servidor
        private void ConcatenarValoresRetencion(ref string codigoRetencion, ref string montoFacturaRetencion, List<Factura_Retencion> facturaRetencion)
        {
            /******** concatener la informacion de la retencion si existiera *******/

            if (facturaRetencion.Count >0)
            {
                foreach (var item in facturaRetencion)
                {
                    codigoRetencion = codigoRetencion + item.Codigo_Retencion + "*";
                    montoFacturaRetencion = montoFacturaRetencion + item.Monto + "*";
                }
                codigoRetencion = codigoRetencion.Substring(0, codigoRetencion.Length - 1);
                montoFacturaRetencion = montoFacturaRetencion.Substring(0, montoFacturaRetencion.Length - 1);               
            }
            /******** concatener la informacion de la retencion si existiera *******/

        }

        public async Task<ResponseModel> GuardarFactura(ViewModelFacturacion model, ResponseModel responseModel)
        {
            var result = 0;
            string codigoRetencion = "";
            string montoFacturaRetencion = "";
            
            ConcatenarValoresRetencion(ref codigoRetencion, ref montoFacturaRetencion, model.FacturaRetenciones);

            try
            {
                //model.Fecha = DateTime.Now.Date;
                using (SqlConnection cn = new SqlConnection(ConectionContext.GetConnectionSqlServer()))
                {
                    //Abrir la conección 
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("SP_GuardarFactura", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 0;
               
                        //factura
                        cmd.Parameters.AddWithValue("@Factura", model.Factura.Factura);
                        cmd.Parameters.AddWithValue("@Tipo_Documento", model.Factura.Tipo_Documento);
                        cmd.Parameters.AddWithValue("@Caja", model.Factura.Caja);
                        cmd.Parameters.AddWithValue("@NumCierre", model.Factura.Num_Cierre);
                        cmd.Parameters.AddWithValue("@Esta_Despachado", model.Factura.Esta_Despachado);
                        cmd.Parameters.AddWithValue("@En_Investigacion", model.Factura.En_Investigacion);
                        cmd.Parameters.AddWithValue("@Trans_Adicionales", model.Factura.Trans_Adicionales);
                        cmd.Parameters.AddWithValue("@Estado_Remision", model.Factura.Estado_Remision);
                        cmd.Parameters.AddWithValue("@Descuento_Volumen", model.Factura.Descuento_Volumen);
                        cmd.Parameters.AddWithValue("@Moneda_Factura", model.Factura.Moneda_Factura);
                        cmd.Parameters.AddWithValue("@Fecha_Despacho", model.Factura.Fecha_Despacho);
                        cmd.Parameters.AddWithValue("@Clase_Documento", model.Factura.Clase_Documento);
                        cmd.Parameters.AddWithValue("@Fecha_Recibido", model.Factura.Fecha_Recibido);                                                                    
                        cmd.Parameters.AddWithValue("@Comision_Cobrador", model.Factura.Comision_Cobrador);
                        cmd.Parameters.AddWithValue("@Tarjeta_Credito", model.Factura.Tarjeta_Credito);
                        cmd.Parameters.AddWithValue("@Total_Volumen", model.Factura.Total_Volumen);
                        cmd.Parameters.AddWithValue("@Total_Peso", model.Factura.Total_Peso);
                        cmd.Parameters.AddWithValue("@Monto_Cobrado", model.Factura.Monto_Cobrado);
                        cmd.Parameters.AddWithValue("@Total_Impuesto1", model.Factura.Total_Impuesto1);
                        cmd.Parameters.AddWithValue("@Fecha", model.Factura.Fecha);
                        cmd.Parameters.AddWithValue("@Fecha_Entrega", model.Factura.Fecha_Entrega);
                        cmd.Parameters.AddWithValue("@Total_Impuesto2", model.Factura.Total_Impuesto2);
                        cmd.Parameters.AddWithValue("@Porc_Descuento2", model.Factura.Porc_Descuento2);
                        cmd.Parameters.AddWithValue("@Monto_Flete", model.Factura.Monto_Flete);
                        cmd.Parameters.AddWithValue("@Monto_Seguro", model.Factura.Monto_Seguro);
                        cmd.Parameters.AddWithValue("@Monto_Documentacio", model.Factura.Monto_Documentacio);
                        cmd.Parameters.AddWithValue("@Tipo_Descuento1", model.Factura.Tipo_Descuento1);
                        cmd.Parameters.AddWithValue("@Tipo_Descuento2", model.Factura.Tipo_Descuento2);
                        //Monto_Descuento1 = monto del descuento general
                        cmd.Parameters.AddWithValue("@Monto_Descuento1", model.Factura.Monto_Descuento1);
                        cmd.Parameters.AddWithValue("@Monto_Descuento2", model.Factura.Monto_Descuento2);
                        cmd.Parameters.AddWithValue("@Porc_Descuento1", model.Factura.Porc_Descuento1);
                        cmd.Parameters.AddWithValue("@Total_Factura", model.Factura.Total_Factura);
                        cmd.Parameters.AddWithValue("@Fecha_Pedido", model.Factura.Fecha_Pedido);
                        cmd.Parameters.AddWithValue("@Fecha_Orden", model.Factura.Fecha_Orden);
                        cmd.Parameters.AddWithValue("@Total_Mercaderia", model.Factura.Total_Mercaderia);
                        cmd.Parameters.AddWithValue("@Comision_Vendedor", model.Factura.Comision_Vendedor);
                        cmd.Parameters.AddWithValue("@Fecha_Hora", model.Factura.Fecha_Hora);
                        cmd.Parameters.AddWithValue("@Total_Unidades", model.Factura.Total_Unidades);
                        cmd.Parameters.AddWithValue("@Numero_Paginas", model.Factura.Numero_Paginas);
                        cmd.Parameters.AddWithValue("@Tipo_Cambio", model.Factura.Tipo_Cambio);
                        cmd.Parameters.AddWithValue("@Anulada", model.Factura.Anulada);
                        cmd.Parameters.AddWithValue("@Modulo", model.Factura.Modulo);
                        cmd.Parameters.AddWithValue("@Cargado_Cg", model.Factura.Cargado_Cg);
                        cmd.Parameters.AddWithValue("@Cargado_Cxc", model.Factura.Cargado_Cxc);
                        cmd.Parameters.AddWithValue("@Embarcar_A", model.Factura.Embarcar_A);
                        cmd.Parameters.AddWithValue("@Direc_Embarque", model.Factura.Direc_Embarque);
                        cmd.Parameters.AddWithValue("@Direccion_Factura", model.Factura.Direccion_Factura);
                        cmd.Parameters.AddWithValue("@Multiplicador_Ev", model.Factura.Multiplicador_Ev);
                        cmd.Parameters.AddWithValue("@Observaciones", model.Factura.Observaciones);
                        cmd.Parameters.AddWithValue("@Version_Np", model.Factura.Version_Np);
                        cmd.Parameters.AddWithValue("@Moneda", model.Factura.Moneda);
                        cmd.Parameters.AddWithValue("@Nivel_Precio", model.Factura.Nivel_Precio);
                        cmd.Parameters.AddWithValue("@Cobrador", model.Factura.Cobrador);
                        cmd.Parameters.AddWithValue("@Ruta", model.Factura.Ruta);
                        cmd.Parameters.AddWithValue("@Usuario", model.Factura.Usuario);
                        cmd.Parameters.AddWithValue("@Condicion_Pago", model.Factura.Condicion_Pago);
                        cmd.Parameters.AddWithValue("@Zona", model.Factura.Zona);
                        cmd.Parameters.AddWithValue("@Vendedor", model.Factura.Vendedor);
                        cmd.Parameters.AddWithValue("@Doc_Credito_Cxc", model.Factura.Doc_Credito_Cxc);
                        cmd.Parameters.AddWithValue("@Cliente_Direccion", model.Factura.Cliente_Direccion);
                        cmd.Parameters.AddWithValue("@Cliente_Corporac", model.Factura.Cliente_Corporac);
                        cmd.Parameters.AddWithValue("@Cliente_Origen", model.Factura.Cliente_Origen);
                        cmd.Parameters.AddWithValue("@Cliente", model.Factura.Cliente);
                        cmd.Parameters.AddWithValue("@Pais", model.Factura.Pais);
                        cmd.Parameters.AddWithValue("@Subtipo_Doc_Cxc", model.Factura.Subtipo_Doc_Cxc);
                        cmd.Parameters.AddWithValue("@Tipo_Credito_Cxc", model.Factura.Tipo_Credito_Cxc);
                        cmd.Parameters.AddWithValue("@Tipo_Doc_Cxc", model.Factura.Tipo_Doc_Cxc);
                        cmd.Parameters.AddWithValue("@Monto_Anticipo", model.Factura.Monto_Anticipo);
                        cmd.Parameters.AddWithValue("@Total_Peso_Neto", model.Factura.Total_Peso_Neto);
                        cmd.Parameters.AddWithValue("@Fecha_Rige", model.Factura.Fecha_Rige);
                        cmd.Parameters.AddWithValue("@Porc_Intcte", model.Factura.Porc_Intcte);
                        cmd.Parameters.AddWithValue("@Usa_Despachos", model.Factura.Usa_Despachos);
                        cmd.Parameters.AddWithValue("@Cobrada", model.Factura.Cobrada);
                        cmd.Parameters.AddWithValue("@Descuento_Cascada", model.Factura.Descuento_Cascada);
                        cmd.Parameters.AddWithValue("@Direccion_Embarque", model.Factura.Direccion_Embarque);
                        cmd.Parameters.AddWithValue("@Reimpreso", model.Factura.Reimpreso);
                        cmd.Parameters.AddWithValue("@Base_Impuesto1", model.Factura.Base_Impuesto1);
                        cmd.Parameters.AddWithValue("@Base_Impuesto2", model.Factura.Base_Impuesto2);
                        cmd.Parameters.AddWithValue("@Nombre_Cliente", model.Factura.Nombre_Cliente);
                        cmd.Parameters.AddWithValue("@Nombremaquina", model.Factura.Nombremaquina);
                        cmd.Parameters.AddWithValue("@Genera_Doc_Fe", model.Factura.Genera_Doc_Fe);
                        cmd.Parameters.AddWithValue("@Tasa_Impositiva_Porc", model.Factura.Tasa_Impositiva_Porc);
                        cmd.Parameters.AddWithValue("@Tasa_Cree1_Porc", model.Factura.Tasa_Cree1_Porc);
                        cmd.Parameters.AddWithValue("@Tasa_Cree2_Porc", model.Factura.Tasa_Cree2_Porc);
                        cmd.Parameters.AddWithValue("@Tasa_Gan_Ocasional_Porc", model.Factura.Tasa_Gan_Ocasional_Porc);                       
                        cmd.Parameters.AddWithValue("@Tienda_Enviado", model.Factura.Tienda_Enviado);
                        cmd.Parameters.AddWithValue("@UnidadNegocio", model.Factura.UnidadNegocio);
                        cmd.Parameters.AddWithValue("@Saldo", model.Factura.Saldo);
                        //factura_linea que son datos fijo
                        cmd.Parameters.AddWithValue("@Bodega", model.FacturaLinea[0].Bodega);                        
                        cmd.Parameters.AddWithValue("@Fecha_Factura", model.FacturaLinea[0].Fecha_Factura);
                        cmd.Parameters.AddWithValue("@Total_Impuesto1Linea", model.FacturaLinea[0].Total_Impuesto1);
                        cmd.Parameters.AddWithValue("@Total_Impuesto2Linea", model.FacturaLinea[0].Total_Impuesto2);
                        cmd.Parameters.AddWithValue("@Cantidad_Devuelt", model.FacturaLinea[0].Cantidad_Devuelt);
                        cmd.Parameters.AddWithValue("@Descuento_VolumenLinea", model.FacturaLinea[0].Descuento_Volumen);
                        cmd.Parameters.AddWithValue("@Tipo_Linea", model.FacturaLinea[0].Tipo_Linea);
                        cmd.Parameters.AddWithValue("@Cantidad_Aceptada", model.FacturaLinea[0].Cantidad_Aceptada);
                        cmd.Parameters.AddWithValue("@Cant_No_Entregada", model.FacturaLinea[0].Cant_No_Entregada);
                        cmd.Parameters.AddWithValue("@Pedido_Linea", model.FacturaLinea[0].Pedido_Linea);                        
                        cmd.Parameters.AddWithValue("@Cant_Despachada", model.FacturaLinea[0].Cant_Despachada);
                        cmd.Parameters.AddWithValue("@Costo_Estim_Local", model.FacturaLinea[0].Costo_Estim_Local);
                        cmd.Parameters.AddWithValue("@Costo_Estim_Dolar", model.FacturaLinea[0].Costo_Estim_Dolar);
                        cmd.Parameters.AddWithValue("@Cant_Anul_Pordespa", model.FacturaLinea[0].Cant_Anul_Pordespa);
                        cmd.Parameters.AddWithValue("@Monto_Retencion", model.FacturaLinea[0].Monto_Retencion);
                        cmd.Parameters.AddWithValue("@Base_Impuesto1Linea", model.FacturaLinea[0].Base_Impuesto1);
                        cmd.Parameters.AddWithValue("@Base_Impuesto2Linea", model.FacturaLinea[0].Base_Impuesto2);
                        cmd.Parameters.AddWithValue("@Costo_Estim_Comp_Local", model.FacturaLinea[0].Costo_Estim_Comp_Local);
                        cmd.Parameters.AddWithValue("@Costo_Estim_Comp_Dolar", model.FacturaLinea[0].Costo_Estim_Comp_Dolar);
                        cmd.Parameters.AddWithValue("@Cant_Dev_Proceso", model.FacturaLinea[0].Cant_Dev_Proceso);
                        //informacion de la retencion
                        cmd.Parameters.AddWithValue("@CodigoRetencion", codigoRetencion);
                        cmd.Parameters.AddWithValue("@MontoFacturaRetencion", montoFacturaRetencion);


                        var dtFacturaLin = new DataTable();
                        dtFacturaLin.Columns.Add("Linea", typeof(short));
                        dtFacturaLin.Columns.Add("Costo_Total_Dolar", typeof(decimal));
                        dtFacturaLin.Columns.Add("Articulo", typeof(string));                                         
                        dtFacturaLin.Columns.Add("Cantidad", typeof(decimal));
                        dtFacturaLin.Columns.Add("Precio_Unitario", typeof(decimal));                    
                        dtFacturaLin.Columns.Add("Desc_Tot_Linea", typeof(decimal));
                        dtFacturaLin.Columns.Add("Desc_Tot_General", typeof(decimal));
                        dtFacturaLin.Columns.Add("Costo_Total", typeof(decimal));
                        dtFacturaLin.Columns.Add("Precio_Total", typeof(decimal));
                        dtFacturaLin.Columns.Add("Descripcion", typeof(string));             
                        dtFacturaLin.Columns.Add("Costo_Total_Local", typeof(decimal));          
                        dtFacturaLin.Columns.Add("Costo_Total_Comp", typeof(decimal));
                        dtFacturaLin.Columns.Add("Costo_Total_Comp_Local", typeof(decimal));
                        dtFacturaLin.Columns.Add("Costo_Total_Comp_Dolar", typeof(decimal));                                                                            
                        dtFacturaLin.Columns.Add("Porc_Desc_Linea", typeof(decimal));

                        foreach (var item in model.FacturaLinea)
                        {
                            dtFacturaLin.Rows.Add(item.Linea, item.Costo_Total_Dolar,
                                item.Articulo,
                                item.Cantidad,
                                item.Precio_Unitario,
                                item.Desc_Tot_Linea,
                                item.Desc_Tot_General,
                                item.Costo_Total,
                                item.Precio_Total,
                                item.Descripcion,
                                 item.Costo_Total_Local,
                                item.Costo_Total_Comp,
                                item.Costo_Total_Comp_Local,
                                item.Costo_Total_Comp_Dolar,
                                item.Porc_Desc_Linea
                                );
                        }

                                                
                        var dtPagoPos = new DataTable();
                        dtPagoPos.Columns.Add("Pago", typeof(string));
                        dtPagoPos.Columns.Add("Condicion_Pago", typeof(string));
                        dtPagoPos.Columns.Add("Entidad_Financiera", typeof(string));
                        dtPagoPos.Columns.Add("Tipo_Tarjeta", typeof(string));
                        dtPagoPos.Columns.Add("Forma_Pago", typeof(string));
                        dtPagoPos.Columns.Add("Numero", typeof(string));
                        dtPagoPos.Columns.Add("Monto_Local", typeof(decimal));
                        dtPagoPos.Columns.Add("Monto_Dolar", typeof(decimal));
                        
                        foreach (var item in model.PagoPos)
                        {
                            dtPagoPos.Rows.Add(item.Pago, item.Condicion_Pago,
                                item.Entidad_Financiera,
                                item.Tipo_Tarjeta,
                                item.Forma_Pago,
                                item.Numero,
                                item.Monto_Local,
                                item.Monto_Dolar                               
                                );
                        }

                        var parametroFacturaLinea = cmd.Parameters.AddWithValue("@FacturaLinea", dtFacturaLin);
                        parametroFacturaLinea.SqlDbType = SqlDbType.Structured;

                        var parametroPagoPos = cmd.Parameters.AddWithValue("@PagoPos", dtPagoPos);
                        parametroPagoPos.SqlDbType = SqlDbType.Structured;
                        result = await cmd.ExecuteNonQueryAsync();

                    }
                }

                if (result > 0)
                {
                    responseModel.Mensaje = $"La factura {model.Factura.Factura} se ha guardado exitosamente";
                    responseModel.Exito = 1;
                }
                else
                {
                    responseModel.Mensaje = $"No se pudo guardar la factura {model.Factura.Factura}";
                    responseModel.Exito = 0;
                }
            }


            catch (Exception ex)
            {
                responseModel.Mensaje = ex.Message;
                responseModel.Exito = -1;
                throw new Exception(ex.Message);
            }
            return responseModel;

        }

        public async Task<int> RegistrarAuditoriaInventario(string factura)
        {
            int result = 0;
            try
            {
                using (SqlConnection cn = new SqlConnection(ConectionContext.GetConnectionSqlServer()))
                {
                    //Abrir la conección 
                    await cn.OpenAsync();
                    SqlCommand cmd = new SqlCommand("SP_GenerarTransaccionInventario", cn);
                    cmd.CommandTimeout = 0;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Factura", factura);

                    result = await cmd.ExecuteNonQueryAsync();
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException.Message);
            }

            return result;
        }

        public async Task<int> EliminarFacturaTemporal(ResponseModel responseModel, string noFactura, string articulo)
        {

            int result = 0;
            try
            {

                using (SqlConnection cn = new SqlConnection(ConectionContext.GetConnectionSqlServer()))
                {
                    //Abrir la conección 
                    await cn.OpenAsync();
                    SqlCommand cmd = new SqlCommand("SP_EliminarArticuloTablaTemp", cn);
                    cmd.CommandTimeout = 0;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Factura", noFactura);
                    cmd.Parameters.AddWithValue("@ArticuloID", articulo);

                    result = await cmd.ExecuteNonQueryAsync();
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;

        }

        //revisar si el unidad de medida permite punto decimal
        public async Task<bool> UnidadMedidaConDecimal(string unidadMedida, ResponseModel responseModel)
        {
            bool permitePuntoDecimal = false;

            try
            {
                using (TiendaDbContext _db = new TiendaDbContext())
                {
                    var unidadFraccion = await _db.Unidad_Fraccion.Where(uf => uf.Unidad_Medida == unidadMedida).FirstOrDefaultAsync();
                    if (unidadFraccion != null)
                    {
                        permitePuntoDecimal = true;
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return permitePuntoDecimal;
        }
        
        public async Task<ResponseModel> BuscarNoFactura(string factura, ResponseModel responseModel)
        {
            var viewModel = new ViewModelFacturacion();
            viewModel.Factura = new Facturas();
            viewModel.FacturaLinea = new List<Factura_Linea>();
            viewModel.FacturaRetenciones = new List<Factura_Retencion>();
            viewModel.PagoPos = new List<Pago_Pos>();
            viewModel.FormasPagos = new List<Forma_Pagos>();


            try
            {
                using (var _db = new TiendaDbContext())
                {
                    viewModel.Factura = await _db.Facturas.Where(f => f.Factura == factura && f.Tipo_Documento == "F").FirstOrDefaultAsync();
                    viewModel.FacturaLinea = await _db.Factura_Linea.Where(f => f.Factura == factura).OrderBy(x => x.Linea).ToListAsync();
                    viewModel.FacturaRetenciones = await _db.Factura_Retencion.Where(f => f.Factura == factura).ToListAsync();
                    viewModel.PagoPos = await _db.Pago_Pos.Where(pg => pg.Documento == factura).ToListAsync();
                    viewModel.Factura.NombreCajero = await _db.Usuarios.Where(u => u.Usuario == viewModel.Factura.Usuario).Select(u => u.Nombre).FirstOrDefaultAsync();
                    viewModel.FormasPagos = await _db.Forma_Pagos.ToListAsync();
                }

                //verificar si factura y factura lineay pago_pos tienen registro
                if (viewModel.Factura != null && viewModel.FacturaLinea.Count > 0 && viewModel.PagoPos.Count >0)
                {
                    responseModel.Exito = 1;
                    responseModel.Mensaje = "Consulta Exitosa";
                    responseModel.Data = viewModel as ViewModelFacturacion;
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
                responseModel.Mensaje = $"Error SF1804232116: {ex.Message}";
                throw new Exception($"Error SF1804232116: {ex.Message}");
            }

            return responseModel;

        }


        /// <summary>
        /// validar los campos de tabla factura
        /// </summary>
        /// <param name="model"></param>
        /// <param name="responseModel"></param>
        /// <param name="factura"></param>
        /// <returns></returns>

        public bool ModeloUsuarioEsValido(ViewModelFacturacion model, ResponseModel responseModel)
        {
            bool modeloIsValido = false;

            try
            {
                if (model.Factura.Factura == null)
                {
                    responseModel.Exito = 0;
                    responseModel.Mensaje = "No existe el numero de factura";
                    responseModel.NombreInput = "Factura";
                }
                else if (model.Factura.Cliente == null)
                {
                    responseModel.Exito = 0;
                    responseModel.Mensaje = "Debes de ingresar el codigo del cliente";
                    responseModel.NombreInput = "Cliente";
                }
                else
                {
                    modeloIsValido = true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return modeloIsValido;
        }

        public async Task CancelarNoFacturaBloqueada(ResponseModel responseModel, string noFactura)
        {
            int result = 0;
            FacturaBloqueada datosFactBloq = new FacturaBloqueada();

            try
            {
                using (TiendaDbContext _db = new TiendaDbContext())
                {
                    datosFactBloq = await _db.FacturaBloqueada.Where(fb => fb.NoFactura == noFactura).FirstOrDefaultAsync();

                    if (!(datosFactBloq is null))
                    {
                        datosFactBloq.EstadoFactura = "FACT_DISPONIBLE";
                        _db.FacturaBloqueada.Attach(datosFactBloq);
                        _db.Entry(datosFactBloq).Property(x => x.EstadoFactura).IsModified = true;
                        result = await _db.SaveChangesAsync();
                    }
                }


                if (result > 0)
                {
                    responseModel.Exito = 1;
                    responseModel.Mensaje = "Factura anulada";
                }
                else
                {
                    responseModel.Exito = 0;
                    responseModel.Mensaje = "Factura no se pudo anular";
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ResponseModel> AnularFacturaAsync(ResponseModel responseModel, string factura, string cajero, string numCierre)
        {
            int result = 0;
            try
            {

                using (SqlConnection cn = new SqlConnection(ConectionContext.GetConnectionSqlServer()))
                {
                    //Abrir la conección 
                    await cn.OpenAsync();
                    SqlCommand cmd = new SqlCommand("SP_AnularFactura", cn);
                    cmd.CommandTimeout = 0;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Factura", factura);
                    cmd.Parameters.AddWithValue("@Cajero", cajero);
                    cmd.Parameters.AddWithValue("@NumCierre", numCierre);

                    result = await cmd.ExecuteNonQueryAsync();
                }


                if (result > 0)
                {
                    responseModel.Exito = 1;
                    responseModel.Mensaje = $"Se anulo exitosamente la factura {factura}";
                }
                else
                {
                    responseModel.Exito = 0;
                    responseModel.Mensaje = $"Se pudo anular la factura {factura}";
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


    }
}
