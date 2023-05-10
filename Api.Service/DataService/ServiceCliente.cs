using Api.Context;
using Api.Model.Modelos;
using Api.Model.ViewModels;

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;


namespace Api.Service.DataService
{
    public class ServiceCliente
    {
        public ServiceCliente()
        {

        }

        /// <summary>
        /// obtener el registro de un cliente por medio el codigo de cliente
        /// </summary>
        /// <param name="clienteID"></param>
        /// <param name="responseModel"></param>
        /// <returns></returns>
        public async Task<ResponseModel> ObtenerClientePorIdAsync(string clienteID, ResponseModel responseModel)
        {
            var cliente = new Clientes();
            try
            {
                using (var _db = new TiendaDbContext())
                {
                    cliente = await _db.Clientes.Where(cl => cl.Cliente == clienteID).FirstOrDefaultAsync();
                }

                if (cliente == null)
                {
                    //0 signinfica que la consulta no se encontro en la base de datos
                    responseModel.Exito = 0;
                    responseModel.Mensaje = $"El cliente {clienteID} no existe en la base de datos";
                }
                //verificar si el cliente no esta activo
                else if (cliente.Activo != "S")
                {
                    responseModel.Exito = 0;
                    responseModel.Mensaje = $"El cliente {cliente.Nombre} esta inactivo";
                }
                else
                {
                    //1 signinfica que la consulta fue exitosa
                    responseModel.Exito = 1;
                    responseModel.Mensaje = "Consulta exitosa";
                    responseModel.Data = cliente as Clientes;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return responseModel;
        }

        public async Task<ResponseModel> ObtenerListaClientes(string tipoFiltro, string busqueda, ResponseModel responseModel)
        {
            var cliente = new List<Clientes>();
            try
            {
                using (var _db = new TiendaDbContext())
                {
                    switch (tipoFiltro)
                    {
                        case "Codigo":
                            //cliente = await _db.Clientes.Where(cl => cl.Contribuyente.Contains(busqueda)).ToListAsync();
                            cliente = await _db.Database.SqlQuery<Clientes>("SELECT * FROM TIENDA.CLIENTE WHERE CLIENTE LIKE '" + busqueda + "'").ToListAsync();
                            break;

                        case "Identificacion":
                            //cliente = await _db.Clientes.Where(cl => cl.Contribuyente.Contains(busqueda)).ToListAsync();
                            cliente = await _db.Database.SqlQuery<Clientes>("SELECT * FROM TIENDA.CLIENTE WHERE CONTRIBUYENTE LIKE '" + busqueda + "'").ToListAsync();
                            break;

                        case "Cliente":
                            cliente = await _db.Database.SqlQuery<Clientes>("SELECT * FROM TIENDA.CLIENTE WHERE NOMBRE LIKE '" + busqueda + "'").ToListAsync();
                            //_db.Clientes.Where(cl => cl.Nombre.Contains(busqueda)).ToListAsync();
                            break;
                    }
                }

                if (cliente.Count == 0)
                {
                    //0 signinfica que la consulta no se encontro en la base de datos
                    responseModel.Exito = 0;
                    responseModel.Mensaje = $"No existe cliente en la base de datos";
                }
                else
                {
                    //1 signinfica que la consulta fue exitosa
                    responseModel.Exito = 1;
                    responseModel.Mensaje = "Consulta exitosa";
                    responseModel.Data = cliente as List<Clientes>;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return responseModel;
        }

        /*public async Task<ListarDatosFactura> ListarInformacionInicioFactura()
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
        }*/

        

       /* public async Task<ListarDatosFactura> llenarComboxMetodoPagoAsync(string codigoCliente)
        {

            var listarDrownListModel = new ListarDatosFactura();
            listarDrownListModel.FormaPagos = new List<Forma_Pagos>();
            //listarDrownListModel.CondicionPago = new List<Condicion_Pagos>();
            //listarDrownListModel.TipoTarjeta = new List<Tipo_Tarjeta_Pos>();
            //listarDrownListModel.EntidadFinanciera = new List<Entidad_Financieras>();
            //listarDrownListModel.Clientes = new Clientes();

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
        }*/

    }
}
