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
    public class ServiceSupervisor
    {
        public ServiceSupervisor()
        {
        }

        public async Task<ResponseModel> ObtenerDatosSupervisorId(string supervisorId, ResponseModel responseModel)
        {
            Supervisores supervisor = new Supervisores();
            try
            {
                using (var _db = new TiendaDbContext())
                {
                    supervisor = await _db.Supervisores.Where(sp => sp.Supervisor == supervisorId).FirstOrDefaultAsync();
                }

                if (supervisor == null)
                {
                    responseModel.Exito = 0;
                    responseModel.Mensaje = "El Supervisor no existe en la base de datos";
                    responseModel.Data = null;
                }
                else
                {
                    responseModel.Exito = 1;
                    responseModel.Mensaje = "Consulta Exitosa";
                    responseModel.Data = supervisor as Supervisores;
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

        public async Task<ResponseModel> GuardarDatosSupervisor(Supervisores supervisor, ResponseModel responseModel, bool nuevoSupervisor = false)
        {
            int result = 0;
            try
            {
                using (var _db = new TiendaDbContext())
                {
                    if (nuevoSupervisor)
                    {
                        supervisor.RowPointer = Utilidades.GenerarGuid();
                        _db.Supervisores.Add(supervisor);
                    }
                    else
                    {
                        _db.Entry(supervisor).State = EntityState.Modified;
                    }

                    //guardar los cambios en la tabla supervisor
                    result = await _db.SaveChangesAsync();
                }

                if (result > 0)
                {
                    responseModel.Exito = 1;
                    responseModel.Mensaje = nuevoSupervisor ? "Se ha guardado exitosamente los datos del Supervisor" : "Se ha actualizado exitosamente los datos del Supervisor";
                }
                else
                {
                    responseModel.Exito = 0;
                    responseModel.Mensaje = nuevoSupervisor ? "No se pudo guardar los datos del Supervisor" : "No se pudo actualizar los datos del Supervisor";
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
