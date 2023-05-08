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
    public class ServiceGrupo
    {

        private TiendaDbContext _db = new TiendaDbContext();

        public ServiceGrupo()
        {

        }


        /// <summary>
        /// listar los grupos 
        /// </summary>
        /// <returns></returns>
        public async Task<ResponseModel> ListarGruposAsync( ResponseModel responseModel, string sucursal="")
        {
            var listaGrupo = new List<Grupos>();
            string valor = sucursal.Trim().Length == 0 ? "1" : "0";

            try
            {
                listaGrupo = await _db.Grupos.Where(grp=>grp.Sucursal =="S" && (grp.GrupoAdministrado == sucursal ||  valor == "1")).ToListAsync();

                if (listaGrupo.Count > 0)
                {
                    //listaGrupo.Add( new )

                    responseModel.Data = listaGrupo as List<Grupos>;
                    responseModel.Exito = 1;
                    responseModel.Mensaje = "Consulta exitosa";
                }
                else
                {
                    responseModel.Exito = 0;
                    responseModel.Mensaje = "No se pudo hacer la consulta";
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
