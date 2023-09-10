using Api.Context;
using Api.Helpers;
using Api.Model.Modelos;
using Api.Model.ViewModels;
using Api.Setting;
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
                using (SqlConnection cn = new SqlConnection(ConectionContext.GetConnectionSqlServer()))
                {
                    //Abrir la conección 
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand($"{User.Compañia}.SP_GuardarCajero", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 0;                                                
                        cmd.Parameters.AddWithValue("@Cajero", cajeros.Cajero);
                        cmd.Parameters.AddWithValue("@Vendedor", cajeros.Vendedor);
                        cmd.Parameters.AddWithValue("@Sucursal", cajeros.Sucursal);
                        cmd.Parameters.AddWithValue("@Usuario", User.Usuario);             
                        result = await cmd.ExecuteNonQueryAsync();
                    }
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


        public async Task<bool> Abierto_Cierre_PosPorCajero(string cajero)
        {
            bool existeCajaAbierta = false;
            try
            {
                using (TiendaDbContext _db = new TiendaDbContext())
                {
                    var cierre_Caja = await _db.Cierre_Pos.Where(cc => cc.Cajero == cajero && cc.Estado == "A").FirstOrDefaultAsync();
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

    }
}
