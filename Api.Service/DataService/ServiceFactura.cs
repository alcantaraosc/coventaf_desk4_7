using Api.Context;
using Api.Helpers;
using Api.Model.Modelos;
using Api.Model.View;
using Api.Model.ViewModels;

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
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
                if (listarDatosFactura.Exito ==1)
                {                    
                    listarDatosFactura = await ListarBodegasAsync(User.TiendaID, listarDatosFactura);
                    if (listarDatosFactura.Exito ==1)
                    {
                        listarDatosFactura = await ObtenerNoFactura(User.Usuario, User.Caja, User.ConsecCierreCT, User.MascaraFactura, User.UnidadNegocio, listarDatosFactura);
                    }
                }
               
            }
            catch(Exception ex)
            {
                listarDatosFactura.Exito = -1;
                listarDatosFactura.Mensaje = ex.Message;
            }

            return listarDatosFactura;
            
        }

        //otener el tipo de cambio del dia
        public async Task<ListarDatosFactura> ObtenerTipoCambioDelDiaAsync(ListarDatosFactura listarDatosFactura)
        {           
            try
            {
                var fecha = DateTime.Now.Date;

                using(TiendaDbContext _db = new TiendaDbContext())
                {
                    var tipoCambio = await _db.Moneda_Hist.Where(tc => tc.Fecha == fecha).FirstOrDefaultAsync();
                    //si el objeto tipoCambio no tiene registro
                    if (!(tipoCambio is null))
                    {
                        listarDatosFactura.Exito = 1;
                        listarDatosFactura.Mensaje = "Consulta Exitosa";
                        //asignar el tipo de cambio del dia
                        listarDatosFactura.tipoDeCambio = Convert.ToDecimal(tipoCambio.Monto);
                    }
                    else
                    {
                        listarDatosFactura.Exito = 0;
                        listarDatosFactura.Mensaje = "El Tipo de cambio del dia no existe en la base de datos";
                    }
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
            catch(Exception ex)
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
                            listaFactura = await _db.Database.SqlQuery<ViewFactura>($"SELECT * FROM dbo.ViewFactura WHERE ANULADA='N' AND (CONVERT(DATE, FECHA) BETWEEN '{ fechaInicio }' AND '{ fechaFinal }')  ORDER BY FECHA").ToListAsync();
                            break;

                        case "Fecha_Caja":
                            //  listaFactura = await _db.ViewFactura.Where(vf => vf.Fecha >= filtroFactura.FechaInicio && vf.Fecha <= filtroFactura.FechaFinal && vf.Caja == filtroFactura.Caja).ToListAsync();
                            listaFactura = await _db.Database.SqlQuery<ViewFactura>($"SELECT * FROM dbo.ViewFactura WHERE ANULADA='N' AND (CONVERT(DATE, FECHA) BETWEEN '{ fechaInicio }' AND '{ fechaFinal }') AND ( Caja = '{ filtroFactura.Caja }'  ORDER BY FECHA").ToListAsync();
                            //listaArticulo =await _db.ARTICULOS.FromSqlRaw("SELECT ARTICULO, DESCRIPCION From TIENDA.ARTICULO Where ARTICULO = {0}", consulta).FirstOrDefault();
                            break;

                        case "Fecha_Factura":
                            //listaFactura = await _db.ViewFactura.Where(vf => vf.Fecha >= filtroFactura.FechaInicio && vf.Fecha <= filtroFactura.FechaFinal
                            //                                            && (vf.Factura >= filtroFactura.FacturaDesde) && vf.Factura <= Convert.ToInt32(filtroFactura.FacturaHasta)).ToListAsync();

                            listaFactura = await _db.Database.SqlQuery<ViewFactura>($"SELECT  * FROM dbo.ViewFactura WHERE ANULADA='N' AND (CONVERT(DATE,FECHA) BETWEEN '{ fechaInicio }' AND '{ fechaFinal}') AND (FACTURA BETWEEN '{filtroFactura.FacturaDesde}' AND '{filtroFactura.FacturaHasta}' )  ORDER BY FECHA").ToListAsync();
                            break;

                        case "Fecha_Caja_Factura":

                            //listaFactura = await _db.ViewFactura.Where(vf => vf.Fecha >= filtroFactura.FechaInicio && vf.Fecha <= filtroFactura.FechaFinal 
                            //                                            && vf.Caja == filtroFactura.Caja && Convert.ToInt32(vf.Factura) >= Convert.ToInt32(filtroFactura.FacturaDesde) && Convert.ToInt32(vf.Factura) <= Convert.ToInt32(filtroFactura.FacturaHasta)).ToListAsync();

                            listaFactura = await _db.Database.SqlQuery<ViewFactura>($"SELECT  * FROM dbo.ViewFactura WHERE ANULADA='N' AND (FECHA BETWEEN '{ fechaInicio }' AND '{ fechaFinal}') " +
                                $"AND (FACTURA BETWEEN '{filtroFactura.FacturaDesde}' AND '{filtroFactura.FacturaHasta}') AND (Caja = '{filtroFactura.Caja}')  ORDER BY FECHA").ToListAsync();
                            break;
                    }
                }
                   

                if (listaFactura.Count >0)
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
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return listaFacturaTemp;
        }

        //obtener el siguiente numero consecutivo
        public async Task<ListarDatosFactura> ObtenerNoFactura(string cajero, string caja, string numCierre, string mascaraFactura, string unidadNegocio, ListarDatosFactura listarDatosFactura)
        {
            bool resultExitoso = false;
            try
            {
                using (SqlConnection cn = new SqlConnection(ADONET.strConnect))
                {
                    //Abrir la conección 
                    await cn.OpenAsync();
                    SqlCommand cmd = new SqlCommand("SP_GenerarNumeroFactura", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 0;               
                    cmd.Parameters.AddWithValue("@Cajero", cajero );
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
                    listarDatosFactura.Mensaje = "La base de dato no retorno el numero de factura";
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
                using (SqlConnection cn = new SqlConnection(ADONET.strConnect))
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
               if ( await RegistrarAuditoriaInventario(model.Factura.Factura) >0)
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

        public async Task<int> RegistrarAuditoriaInventario(string factura)
        {
            int result = 0;
            try
            {
                using (SqlConnection cn = new SqlConnection(ADONET.strConnect))
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
                
                using (SqlConnection cn = new SqlConnection(ADONET.strConnect))
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
                if (model.Factura.Factura  == null)
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

                using (SqlConnection cn = new SqlConnection(ADONET.strConnect))
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


                if (result >0)
                {
                    responseModel.Exito = 1;
                    responseModel.Mensaje = $"Se anulo exitosamente la factura {factura}";
                }
                else                    
                {
                    responseModel.Exito =0;
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
