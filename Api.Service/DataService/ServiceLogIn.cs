using Api.Context;
using Api.Helpers;
using Api.Model.Modelos;
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
    public class ServiceLogIn
    {
        private TiendaDbContext _db = new TiendaDbContext();

        private async Task<bool> Supervisor(string usuario, ResponseModel responseModel)
        {
            bool result = false;
            var supervisor = new Supervisores();
            try
            {
                supervisor = await _db.Supervisores.Where(s => s.Supervisor == usuario).FirstOrDefaultAsync();
                if (supervisor != null)
                {
                    result = true;
                    responseModel.Exito = 1;
                    responseModel.Mensaje = "es supervisor";
                }
                else
                {
                    result = false;
                    responseModel.Exito = 0;
                    responseModel.Mensaje = "no es supervisor";
                }

            }
            catch(Exception ex)
            {
                responseModel.Exito = -1;
                responseModel.Mensaje = $"Error SL1003231009: {ex.Message}";
                throw new Exception($"Error SL1003231009: {ex.Message}");
            }

            return result;
        }

        private async Task<bool> EsCajero(string usuario, ResponseModel responseModel)
        {
            bool result = false;
            var cajero = new Cajeros();
            try
            {
                cajero = await _db.Cajeros.Where(c => c.Cajero == usuario).FirstOrDefaultAsync();
                if (cajero != null)
                {
                    result = true;
                    responseModel.Exito = 1;
                    responseModel.Mensaje = "es cajero";
                }
                else
                {
                    result = false;
                    responseModel.Exito = 0;
                    responseModel.Mensaje = "no es cajero";
                }

            }
            catch (Exception ex)
            {
                responseModel.Exito = -1;
                responseModel.Mensaje = $"Error SL1003231015: {ex.Message}";
                throw new Exception($"Error SL1003231015: {ex.Message}");
            }

            return result;
        }

        //verifica si el usuario y contraseña es correcto
        private async Task<bool> AutenticationExitosa(string usuarioId, string password, ResponseModel responseModel)
        {
            bool result = false;
            var usuario = new Usuarios();
            try
            {
                using(var _db = new TiendaDbContext())
                {
                    usuario = await _db.Usuarios.Where(s => s.Usuario == usuarioId).FirstOrDefaultAsync();
                }
              
                if (usuario == null)
                {
                    result = false;
                    responseModel.Exito = 0;
                    responseModel.Mensaje = "El usuario no existe en la base de datos";
                }
               else if (usuario.Activo =="N" || usuario.Activo == "")
                {
                    result = false;
                    responseModel.Exito = 0;
                    responseModel.Mensaje = "Usuario estas inactivo";
                }

                else if (usuario.ClaveCifrada != password)
                {
                    result = false;
                    responseModel.Exito = 0;
                    responseModel.Mensaje = "Tu password es incorrecto";
                }
                else
                {
                    result = true;
                    responseModel.Exito = 1;
                    responseModel.Mensaje = "Autenticacion exitosa";
                }
            }
            catch (Exception ex)
            {
                responseModel.Exito = -1;
                responseModel.Mensaje = $"Error SL1003231035: {ex.Message}";
                throw new Exception($"Error SL1003231035: {ex.Message}");
            }

            return result;
        }

        private async Task<bool> TieneRolesUsuario(string usuarioId , ResponseModel responseModel)
        {
            var existenRolesUser = false;
            try
            {
                var listRolesUsuario = await _db.RolesUsuarios.Where(ru=>ru.UsuarioID  == usuarioId).ToListAsync();

                if (listRolesUsuario.Count >0)
                {
                    existenRolesUser = true;
                    responseModel.Exito = 1;
                    responseModel.Mensaje = "Roles definido";
                }
                else
                {
                    existenRolesUser = false;
                    responseModel.Exito = 0;
                    responseModel.Mensaje = "El Usuario no tiene Roles definido";
                }

            }
            catch (Exception ex)
            {
                responseModel.Exito = -1;
                responseModel.Mensaje = $"Error SL1003231113: {ex.Message}";
                throw new Exception($"Error SL1003231113: {ex.Message}");
            }

            return existenRolesUser;
        }


        private async Task<bool> TieneAccesoUsuario(string usuarioId, List<RolesUsuarioActual> roles, ResponseModel responseModel)
        {            
            bool accesoExitoso =false ;
            bool supervisor = false;
            bool cajero = false;
                                   
            try
            {
                using (SqlConnection cn = new SqlConnection(ADONET.strConnect))
                {
                    //Abrir la conección 
                    await cn.OpenAsync();
                    SqlCommand cmd = new SqlCommand("SP_ObtenerRolesUsuario", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 0;
                    cmd.Parameters.AddWithValue("@Usuario", usuarioId);     
                                 

                    var dr = await cmd.ExecuteReaderAsync();
                    while (await dr.ReadAsync())
                    {                       
                        User.Usuario = dr["Usuario"]?.ToString();
                        User.NombreUsuario = dr["NombreUsuario"]?.ToString();

                        //revisar si el usuario tiene rol asignado
                        if (dr["RolID"] == null || dr["RolID"]?.ToString() =="" )
                        {
                            accesoExitoso = false;
                            break;
                        }
                        else
                         {
                            accesoExitoso = true;
                            roles.Add(new RolesUsuarioActual() { RolID = dr["RolID"].ToString(), NombreRol = dr["NombreRol"]?.ToString() });
                        }

                        //verificar si el rol es supervisor 
                        if (dr["RolID"].ToString()=="SUPERVISOR" )
                        {
                            //hacer una funcion para revisar
                            supervisor = true;
                            //obtener la informacion de la unidad de negocio
                            User.TiendaID = dr["SupTiendaID"]?.ToString();
                            User.NombreTienda = dr["SupNombreTienda"]?.ToString();
                            User.NivelPrecio = dr["SupNivel_Precio"]?.ToString();
                            User.MonedaNivel = dr["SupMoneda_Nivel"]?.ToString();
                            User.DireccionTienda = dr["SupDireccion"]?.ToString();// is null ? null : dr["Direccion"].ToString();
                            User.TelefonoTienda = dr["SupTelefono"]?.ToString();
                            User.UnidadNegocio = dr["SupUnidadNegocio"]?.ToString();
                        }
                        //verificar si el rol es cajero
                        else if (dr["RolID"].ToString() == "CAJERO")
                        {
                            cajero = true;
                            //obtener la informacion de la unidad de negocio
                            User.TiendaID = dr["CajeroTiendaID"]?.ToString();
                            User.NombreTienda = dr["CajeroNombreTienda"]?.ToString();
                            User.NivelPrecio = dr["CajeroNivel_Precio"]?.ToString();
                            User.MonedaNivel = dr["CajeroMoneda_Nivel"]?.ToString();
                            User.DireccionTienda = dr["CajeroDireccion"]?.ToString();// is null ? null : dr["Direccion"].ToString();
                            User.TelefonoTienda = dr["CajeroTelefono"]?.ToString();
                            User.UnidadNegocio = dr["UnidadNegocio"]?.ToString();
                        }                        
                    }

                    cn.Close();
                    dr.Close();
                }

                //comprobar si el usuario tiene roles asignado
                if (accesoExitoso)
                {                   
                    responseModel.Exito = 1;
                    responseModel.Mensaje = "Roles existentes";
                }
                else
                {                    
                    responseModel.Exito = 0;
                    responseModel.Mensaje = $"El usuario {usuarioId} no tienes roles definidos";
                }

                //si eres supervisor y tiendaID esta vacio entonces significa  
                if (supervisor && User.TiendaID == "")
                {
                    accesoExitoso = false;
                    responseModel.Exito = 0;
                    responseModel.Mensaje = $"El Supervisor {usuarioId} no esta asociado a la unidad de negocio";
                }
                //si eres supervisor y tiendaID esta vacio entonces significa  
                else if (cajero && User.TiendaID == "")
                {
                    accesoExitoso = false;
                    responseModel.Exito = 0;
                    responseModel.Mensaje = $"El Cajero {usuarioId} no esta asociado a la unidad de negocio";
                }

            }
            catch (Exception ex)
            {               
                responseModel.Exito = -1;
                responseModel.Mensaje = $"Error 1003231301: {ex.Message}";
                throw new Exception($"Error 1003231301: {ex.Message}");
            }


            return accesoExitoso;
        }



        public async Task<ResponseModel> LogearseIn(string usuarioId, string password, ResponseModel _responseModel)
        {
            var responseModel = _responseModel;
            //encryptar la constraseña
            var passwordCifrado = new EncryptMD5().EncriptarMD5(password);
            
            responseModel.DataAux = new List<RolesUsuarioActual>();
            var roles = new List<RolesUsuarioActual>();                       

            try
            {
                //si la autenticacion no fue exitosa emitir el mensajer del problema
                if (!(await AutenticationExitosa(usuarioId, passwordCifrado, responseModel)))
                {
                    return responseModel;
                   
                }
                //verificar si el usuario no tiene roles
                else if (await TieneAccesoUsuario(usuarioId, roles, responseModel))
                {                   
                    responseModel.DataAux = roles as List<RolesUsuarioActual>;
                    //obtener los roles del usuario                                                       
                }                
               
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return responseModel;
        }
    
    
        public async Task<ResponseModel> AutorizacionExitosa(string usuarioId, string password, ResponseModel responseModel)
        {                       
            var passwordCifrado = new EncryptMD5().EncriptarMD5(password);

            try
            {
                
                //verifica si la autenticacion del supervisor no es correcta
                if (!await AutenticationExitosa(usuarioId, passwordCifrado, responseModel))
                {
                    responseModel.Exito = 0;
                }
                //luego verifica si supervisor
                else if (!await Supervisor(usuarioId, responseModel))
                {
                    responseModel.Exito = 0;
                }
                else
                {
                    responseModel.Exito = 1;
                    responseModel.Mensaje = "Autorizacion Exitosa";
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error SL1603232112: {ex.Message}");
            }
        


            return responseModel;
        }

    }
}
