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
    public class ServiceFormaPago
    {
        private TiendaDbContext _db = new TiendaDbContext();

        public ServiceFormaPago()
        {

        }

        public async Task<bool> ObtenerListaFormaDePago(ListarDatosFactura listarDrownListModel)
        {
            bool resultExitoso = false;
            try
            {
                using (TiendaDbContext _db = new TiendaDbContext())
                {
                    listarDrownListModel.FormaPagos = await _db.Forma_Pagos.Where(fp => fp.Activo == "S" && fp.Forma_Pago != "0007").ToListAsync();
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
                }
                else
                {
                    ResponseModel responseModel = new ResponseModel();
                    responseModel = await new ServiceCliente().ObtenerClientePorIdAsync(codigoCliente, responseModel);

                    if (responseModel.Exito == 1)
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


        public async Task<ResponseModel> ListarDevolucionesClienteAsync(string codigoCliente, string tiendaId, ResponseModel responseModel)
        {
            bool resultExitoso = false;
            var listDevolucionCliente = new List<ViewDevoluciones>();

            try
            {
                using (SqlConnection cn = new SqlConnection(ConectionContext.GetConnectionSqlServer()))
                {
                    //Abrir la conección 
                    cn.Open();
                    SqlCommand cmd = new SqlCommand($"SELECT FACTURA.FACTURA, FACTURA.TIPO_DOCUMENTO, FACTURA.SALDO, PAGO_POS.MONTO_LOCAL, PAGO_POS.MONTO_DOLAR, FACTURA.ANULADA," +
                                                $" FACTURA.CLIENTE, PAGO_POS.FORMA_PAGO, FACTURA.COBRADA FROM {User.Compañia}.FACTURA INNER JOIN {User.Compañia}.PAGO_POS WITH (NOLOCK) ON FACTURA.FACTURA = PAGO_POS.DOCUMENTO " +
                                                $" AND FACTURA.TIPO_DOCUMENTO = PAGO_POS.TIPO AND FACTURA.TIPO_DOCUMENTO = 'D' AND  FACTURA.MULTIPLICADOR_EV = -1 AND FACTURA.ANULADA = 'N' " +
                                                $" AND FACTURA.COBRADA = 'N' WHERE CLIENTE=@CodigoCliente AND Tienda_Enviado=@TiendaId", cn);
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandTimeout = 0;
                    cmd.Parameters.AddWithValue("@CodigoCliente", codigoCliente);
                    cmd.Parameters.AddWithValue("@TiendaId", tiendaId);


                    var dr = await cmd.ExecuteReaderAsync();
                    while (await dr.ReadAsync())
                    {
                        resultExitoso = true;
                        var viewDevolucion = new ViewDevoluciones()
                        {
                            Factura = dr["FACTURA"].ToString(),
                            Tipo_Documento = dr["TIPO_DOCUMENTO"].ToString(),
                            Saldo = Convert.ToDecimal(dr["SALDO"]),
                            Monto_Local = Convert.ToDecimal(dr["MONTO_LOCAL"]),
                            Monto_Dolar = Convert.ToDecimal(dr["MONTO_DOLAR"])
                        };

                        listDevolucionCliente.Add(viewDevolucion);

                    }
                }

                if (resultExitoso)
                {
                    responseModel.Data = listDevolucionCliente as List<ViewDevoluciones>;
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

        public async Task<ResponseModel> ListarAnticipoClienteAsync(string codigoCliente, string tiendaId, ResponseModel responseModel)
        {
            var listAnticipoCliente = new List<Documento_Pos>();

            try
            {

                using (TiendaDbContext _db = new TiendaDbContext())
                {
                    listAnticipoCliente = await _db.Documento_Pos.Where(dp => dp.Estado_Cobro == "P" && dp.Tipo == "R" && dp.Cliente == codigoCliente && dp.Tienda_Enviado == tiendaId).ToListAsync();
                }
                if (listAnticipoCliente.Count >0)
                {
                    responseModel.Data = listAnticipoCliente as List<Documento_Pos>;
                    responseModel.Exito = 1;
                    responseModel.Mensaje = $"Consulta exitosa";
                }
                else
                {                   
                    responseModel.Exito = 0;
                    responseModel.Mensaje = $"Este cliente no tiene Anticipo";
                }

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
