using Api.Context;
using Api.Helpers;
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
    public class ServiceCajero
    {
        public ServiceCajero()
        {

        }

        public async Task<ResponseModel> ObtenerDatosCajeroId(string cajeroId, ResponseModel responseModel)
        {
            Cajeros cajero = new Cajeros();
            try
            {
                using(var _db = new TiendaDbContext() )
                {
                    cajero = await _db.Cajeros.Where(cj => cj.Cajero == cajeroId).FirstOrDefaultAsync();
                }

                if (cajero == null)
                {
                    responseModel.Exito = 0;
                    responseModel.Mensaje = "El Cajero no existe en la base de datos";
                    responseModel.Data = null;
                }
                else
                {
                    responseModel.Exito = 1;
                    responseModel.Mensaje = "Consulta Exitosa";
                    responseModel.Data = cajero as Cajeros;
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

        public async Task<ResponseModel> GuardarDatosCajero( Cajeros cajeros, ResponseModel responseModel, bool nuevoCajero=false)
        {
            int result = 0;
            try
            {
                using (var _db = new TiendaDbContext())
                {
                    if (nuevoCajero)
                    {
                        cajeros.RowPointer =  Utilidades.GenerarGuid();
                        _db.Cajeros.Add(cajeros);
                    }
                    else
                    {
                        _db.Entry(cajeros).State = EntityState.Modified;
                    }

                    //guardar los cambios en la tabla Factura
                   result = await _db.SaveChangesAsync();
                }

                if (result >0)
                {
                    responseModel.Exito = 1;
                    responseModel.Mensaje = nuevoCajero ? "Se ha guardado exitosamente los datos del cajero" : "Se ha actualizado exitosamente los datos del cajero";                                 
                }
                else
                {
                    responseModel.Exito = 0;                    
                    responseModel.Mensaje = nuevoCajero ? "No se pudo guardar los datos del cajero" : "No se pudo actualizar los datos del cajero";                    
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
