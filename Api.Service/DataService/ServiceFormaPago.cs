using Api.Context;
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
    public class ServiceFormaPago
    {
        private TiendaDbContext _db = new TiendaDbContext();

        public ServiceFormaPago()
        {
            
        }

        public async Task<bool> ObtenerListaFormaDePago( ListarDatosFactura listarDrownListModel)
        {
            bool resultExitoso = false;            
            try
            {
                using (TiendaDbContext _db = new TiendaDbContext())
                {
                    listarDrownListModel.FormaPagos = await _db.Forma_Pagos.Where(fp => fp.Activo == "S").ToListAsync();
                }                                   
               
                if (listarDrownListModel.FormaPagos.Count > 0)
                {
                    resultExitoso = true;
                    listarDrownListModel.Exito = 1;
                    listarDrownListModel.Mensaje = "Consulta exitosa";
                }
                else
                {
                    resultExitoso = false;
                    listarDrownListModel.Exito = 0;
                    listarDrownListModel.Mensaje = "El Catalogo de forma de pago no tiene registro";
                }                        
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return resultExitoso;
        }

        public async Task<bool> ObtenerListaCondicionPago(ListarDatosFactura listarDrownListModel)
        {
            bool resultExitoso = false;

            try
            {
                using (TiendaDbContext _db = new TiendaDbContext())
                {
                    listarDrownListModel.CondicionPago = await _db.Condicion_Pagos.Where(x => x.Condicion_Pago != "0").ToListAsync();
                }

                if (listarDrownListModel.CondicionPago.Count > 0)
                {
                    resultExitoso = true;
                    listarDrownListModel.Exito = 1;
                    listarDrownListModel.Mensaje = "Consulta exitosa";
                }
                else
                {
                    listarDrownListModel.FormaPagos = null;
                    listarDrownListModel.CondicionPago = null;
                    resultExitoso = false;
                    listarDrownListModel.Exito = 0;
                    listarDrownListModel.Mensaje = "El Catalogo de Codicion de pago no tiene registro";
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return resultExitoso;
        }


        public async Task<bool> ObtenerListaTipoTarjeta(ListarDatosFactura listarDrownListModel)
        {
            bool resultExitoso = false;

            try
            {
                using (TiendaDbContext _db = new TiendaDbContext())
                {
                    listarDrownListModel.TipoTarjeta = await _db.Tipo_Tarjeta_Pos.ToListAsync();
                }

                if (listarDrownListModel.TipoTarjeta.Count > 0)
                {
                    resultExitoso = true;
                    listarDrownListModel.Exito = 1;
                    listarDrownListModel.Mensaje = "Consulta exitosa";
                }
                else
                {
                    listarDrownListModel.FormaPagos = null;
                    listarDrownListModel.CondicionPago = null;
                    listarDrownListModel.TipoTarjeta = null;
                    resultExitoso = false;
                    listarDrownListModel.Exito = 0;
                    listarDrownListModel.Mensaje = "El Catalogo de Tarjeta no tiene registro";
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return resultExitoso;
        }

        public async Task<bool> ObtenerListaEntidadFinanciera(ListarDatosFactura listarDrownListModel)
        {
            bool resultExitoso = false;
          

            try
            {                 
                using (TiendaDbContext _db = new TiendaDbContext())
                {
                    listarDrownListModel.EntidadFinanciera = await _db.Entidad_Financieras.ToListAsync();
                }

                if (listarDrownListModel.EntidadFinanciera.Count > 0)
                {
                    resultExitoso = true;
                    listarDrownListModel.Exito = 1;
                    listarDrownListModel.Mensaje = "Consulta exitosa";
                }
                else
                {
                    listarDrownListModel.FormaPagos = null;
                    listarDrownListModel.CondicionPago = null;
                    listarDrownListModel.TipoTarjeta = null;
                    listarDrownListModel.EntidadFinanciera = null;
                    resultExitoso = false;
                    listarDrownListModel.Exito = 0;
                    listarDrownListModel.Mensaje = "El Catalogo de Entidad Financiera no tiene registro";
                }


            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException.Message);
            }

            return resultExitoso;
        }

        public async Task<ListarDatosFactura> llenarComboxMetodoPagoAsync(string codigoCliente)
        {

            var listarDrownListModel = new ListarDatosFactura();
            listarDrownListModel.FormaPagos = new List<Forma_Pagos>();
            listarDrownListModel.CondicionPago = new List<Condicion_Pagos>();
            listarDrownListModel.TipoTarjeta = new List<Tipo_Tarjeta_Pos>();
            listarDrownListModel.EntidadFinanciera = new List<Entidad_Financieras>();
            listarDrownListModel.Clientes = new Clientes();             

            try
            {
                
                //verificar si e
                if (!await ObtenerListaFormaDePago(listarDrownListModel))
                {
                    return listarDrownListModel;
                }
                //
                else if (!await ObtenerListaCondicionPago(listarDrownListModel))
                {
                    return listarDrownListModel;
                }
                else if (!await ObtenerListaTipoTarjeta(listarDrownListModel))
                {
                    return listarDrownListModel;
                }
                else if (!await ObtenerListaEntidadFinanciera(listarDrownListModel))
                {
                    return listarDrownListModel;
                }else
                {
                    ResponseModel responseModel = new ResponseModel();
                    responseModel = await new ServiceCliente().ObtenerClientePorIdAsync(codigoCliente, responseModel);
                    
                    if (responseModel.Exito ==1)
                    {
                        listarDrownListModel.Exito = 1;
                        listarDrownListModel.Mensaje = "Consulta exitosa";
                        listarDrownListModel.Clientes = responseModel.Data as Clientes;
                    }
                    else
                    {
                        listarDrownListModel.Exito = 0;
                        listarDrownListModel.Mensaje = responseModel.Mensaje;
                        listarDrownListModel.FormaPagos = null;
                        listarDrownListModel.CondicionPago = null;
                        listarDrownListModel.TipoTarjeta = null;
                        listarDrownListModel.EntidadFinanciera = null;
                        listarDrownListModel.Clientes = null;
                    }
                }               
            }
            catch (Exception ex)
            {
                //-1 indica que existe algun error del servidor
                listarDrownListModel.Exito = -1;
                listarDrownListModel.Mensaje = ex.Message;
            }

            return listarDrownListModel;
        }


        //forma de pagos
        //public async Task<bool> ListarFormaDePago(ResponseModel responseModel)
        //{
        //    bool resultExitoso = false;
        //    responseModel.Data = new List<Forma_Pagos>();
        //    //var listFormaPago = new List<Forma_Pagos>();
        //    try
        //    {
        //        var listFormaPago = await _db.Forma_Pagos.Where(fp => fp.Activo == "S").ToListAsync();
        //        if (listFormaPago.Count ==0 )
        //        {
        //            responseModel.Exito = 0;
        //            responseModel.Mensaje = "En el catalogo forma de pagos no hay registro";
        //        }
        //        else
        //        {
        //            resultExitoso = true;
        //            responseModel.Exito = 1;
        //            responseModel.Mensaje = "Consulta exitosa";
        //            responseModel.Data = listFormaPago as List<Forma_Pagos>;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }

        //    return resultExitoso;
        //}


    
        public async Task<List<Retenciones>> ListarRetenciones()
        {
            var listarRetenciones = new List<Retenciones>();

            try
            {
                listarRetenciones = await _db.Retenciones.Where(r => r.Estado == "A").ToListAsync();
 
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException.Message);
            }

            return listarRetenciones;
        }


        public async Task<ResponseModel> ListarDevolucionesClienteAsync(string codigoCliente, ResponseModel responseModel)
        {
            bool resultExitoso = false;
            var listDevolucionCliente = new List<ViewDevoluciones>();
            //try
            //{
            //    using (var _db = new TiendaDbContext())
            //    {
            //        listDevolucionCliente =  _db.ViewDevoluciones.Where(d => d.Cliente == codigoCliente).ToList();
            //    }

            //    if (listDevolucionCliente != null)
            //    {
            //        responseModel.Data = listDevolucionCliente as List<ViewDevoluciones>;
            //        resultExitoso = true;
            //        responseModel.Exito = 1;
            //        responseModel.Mensaje = $"Consulta exitosa";
            //    }
            //    else
            //    {
            //        resultExitoso = false;
            //        responseModel.Exito = 0;
            //        responseModel.Mensaje = $"El Cliente no tiene vale";
            //    }
            //}
            //catch (Exception ex)
            //{
            //    responseModel.Exito = -1;
            //    responseModel.Mensaje = $"Error SFP1803231341: { ex.Message}";
            //    throw new Exception($"Error SFP1803231341: {ex.Message}");
            //}


            try
            {
                using (SqlConnection cn = new SqlConnection(ADONET.strConnect))
                {
                    //Abrir la conección 
                    cn.Open();
                    SqlCommand cmd = new SqlCommand($"SELECT * FROM ViewDevoluciones WHERE CLIENTE=@CodigoCliente", cn);
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandTimeout = 0;
                    cmd.Parameters.AddWithValue("@CodigoCliente", codigoCliente);
           ;

                    var dr = await cmd.ExecuteReaderAsync();
                    while (await dr.ReadAsync())
                    {
                        resultExitoso = true;
                       // listarDatosFactura.NoFactura = dr["Factura"].ToString();
                    }
                }

                //if (resultExitoso)
                //{
                //    listarDatosFactura.Exito = 1;
                //    listarDatosFactura.Mensaje = "Consulta exitosa";
                //}
                //else
                //{
                //    listarDatosFactura.Exito = 0;
                //    listarDatosFactura.Mensaje = "La base de dato no retorno el numero de factura";
                //}

            }
            catch (Exception ex)
            {
               // listarDatosFactura.Exito = -1;
                throw new Exception(ex.Message);
            }

            return responseModel;

        }
    }
}
