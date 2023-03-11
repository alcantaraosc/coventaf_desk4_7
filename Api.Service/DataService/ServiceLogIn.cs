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

        private async Task<bool> ExistSupervisor(string usuario, ResponseModel responseModel)
        {
            bool result = false;
            var supervisor = new Supervisores();
            try
            {
                supervisor = await _db.Supervisores.Where(s => s.Supervisor == usuario).FirstOrDefaultAsync();
                if (supervisor != null)
                {
                    result = true;
                    responseModel.Exito = 0;
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

        private async Task<bool> ExistCajero(string usuario, ResponseModel responseModel)
        {
            bool result = false;
            var cajero = new Cajeros();
            try
            {
                cajero = await _db.Cajeros.Where(c => c.Cajero == usuario).FirstOrDefaultAsync();
                if (cajero != null)
                {
                    result = true;
                    responseModel.Exito = 0;
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

        //private bool Administrador()
        //{
        //    try
        //    {
        //        devolucion = await _db.Facturas.Where(f => f.Factura_Original == factura && f.Tipo_Documento == "D").FirstOrDefaultAsync();
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //}

        private async Task<bool> AutenticationExitosa(string usuarioId, string password, ResponseModel responseModel)
        {
            bool result = false;
            var usuario = new Usuarios();
            try
            {
                usuario = await _db.Usuarios.Where(s => s.Usuario == usuarioId).FirstOrDefaultAsync();
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


        private async Task<ViewModelUsuario> ObtenerRolesUsuario(string usuarioId, bool esSupervisor, bool esCajero, List<RolesUsuarioActual> roles, ResponseModel responseModel)
        {
            bool resultExitoso = false;
            bool rolExitoso =false ;
            bool supervisor = false;
            bool cajero = false;


            var ViewModelUser = new ViewModelUsuario();
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
                        resultExitoso = true;
                        ViewModelUser.Usuario = dr["Usuario"]?.ToString();
                        ViewModelUser.NombreUsuario = dr["NombreUsuario"]?.ToString();
                        ViewModelUser.Grupo = dr["TiendaID"]?.ToString();
                        ViewModelUser.NombreTienda = dr["NombreTienda"]?.ToString();
                        ViewModelUser.NivelPrecio = dr["Nivel_Precio"]?.ToString();
                        ViewModelUser.MonedaNivel = dr["Moneda_Nivel"]?.ToString();
                        ViewModelUser.DireccionTienda = dr["Direccion"]?.ToString();// is null ? null : dr["Direccion"].ToString();
                        ViewModelUser.DireccionTienda = dr["Telefono"]?.ToString();

                        //revisar si el usuario tiene rol asignado
                        if (dr["RolID"] == null )
                        {
                            rolExitoso = false;
                            break;
                        }
                        else
                        {
                            rolExitoso = true;
                            roles.Add(new RolesUsuarioActual() { RolID = dr["RolID"].ToString(), NombreRol = dr["NombreRol"]?.ToString() });
                        }

                        if (dr["RolID"].ToString()=="SUPERVISOR" )
                        {
                            //hacer una funcion para revisar
                            //supervisor = true;
                            User.TiendaID = dr["SupTiendaID"]?.ToString();
                            User.NombreTienda = dr["SupNombreTienda"]?.ToString();
                            User.NivelPrecio = dr["SupNivel_Precio"]?.ToString();
                            User.MonedaNivel = dr["SupMoneda_Nivel"]?.ToString();
                            User.DireccionTienda = dr["SupDireccion"]?.ToString();// is null ? null : dr["Direccion"].ToString();
                            User.TelefonoTienda = dr["SupTelefono"]?.ToString();
                        }
                        else if (dr["RolID"].ToString() == "CAJERO")
                        {
                            cajero = true;
                            User.TiendaID = dr["CajeroTiendaID"]?.ToString();
                            User.NombreTienda = dr["CajeroNombreTienda"]?.ToString();
                            User.NivelPrecio = dr["CajeroNivel_Precio"]?.ToString();
                            User.MonedaNivel = dr["CajeroMoneda_Nivel"]?.ToString();
                            User.DireccionTienda = dr["CajeroDireccion"]?.ToString();// is null ? null : dr["Direccion"].ToString();
                            User.TelefonoTienda = dr["CajeroTelefono"]?.ToString();
                        }                        
                    }                  
                }
            }
            catch (Exception ex)
            {               
                responseModel.Exito = -1;
                responseModel.Mensaje = $"Error 1003231301: {ex.Message}";
                throw new Exception($"Error 1003231301: {ex.Message}");
            }

            if (rolExitoso )
            {
                resultExitoso = true;
                responseModel.Exito = 1;
                responseModel.Mensaje = "Roles existentes";
            }
            else
            {
                resultExitoso = false;
                responseModel.Exito = 0;
                responseModel.Mensaje = $"El usuario {usuarioId} no tienes roles definidos";
            }

         

            return ViewModelUser;
        }



        public async Task<ResponseModel> LogearseIn(string username, string password, ResponseModel responseModel)
        {
            //encryptar la constraseña
            var passwordCifrado = new EncryptMD5().EncriptarMD5(password);
            var ViewModelUser = new ViewModelUsuario();
            responseModel.DataAux = new List<RolesUsuarioActual>();
            var roles = new List<RolesUsuarioActual>();
            bool esSupervisor = false;
            bool esCajero = false;
            bool respuestaExitosa = true;

            try
            {
                //si la autenticacion no fue exitosa emitir el mensajer del problema
                if (!(await AutenticationExitosa(username, passwordCifrado, responseModel)))
                {
                    respuestaExitosa = false;
                    
                  //verificar si el usuario no tiene roles
                }else if (!await TieneRolesUsuario(username, responseModel))
                {
                    respuestaExitosa = false;
                }
                //verificar si el usuario es un supervisor
                //else if ((await ExistSupervisor(username, responseModel)))
                //{
                //    esSupervisor = true;
                //}
                ////verificar si el usuario es un cajero
                //else if ((await ExistCajero(username, responseModel)))
                //{
                //    esCajero = true;
                //}

                //si respuestaExitosa es exitosa entonces procedo a obtener los roles
                if (respuestaExitosa)                               
                {
                    //obtener los roles del usuario
                    ViewModelUser = await ObtenerRolesUsuario(username, esSupervisor, esCajero, roles, responseModel);
                    responseModel.DataAux = roles as List<RolesUsuarioActual>;
                    responseModel.Data = ViewModelUser as ViewModelUsuario;
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

            if (!await AutenticationExitosa(usuarioId, passwordCifrado, responseModel))
            {
                responseModel.Exito = 0;
            }
            else if (! await ExistSupervisor(usuarioId, responseModel))
            {
                responseModel.Exito = 0;
            }
            else
            {
                responseModel.Exito = 1;
                responseModel.Mensaje = "Autorizacion Exitosa";
            }

            return responseModel;
        }

    }
}
