using Api.Context;
using Api.Model.Modelos;
using Api.Model.ViewModels;

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Api.Service.DataService
{
    public class ServiceCliente
    {       
        public ServiceCliente( )
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
                else if (cliente.Activo !="S")
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
    }
}
