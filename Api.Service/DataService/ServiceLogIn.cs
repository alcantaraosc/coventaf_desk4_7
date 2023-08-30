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
using System.Threading.Tasks;

namespace Api.Service.DataService
{
    public class ServiceLogIn
    {    

        private async Task<bool> Supervisor(string usuario, string sucursalId, ResponseModel responseModel)
        {
            bool result = false;
            var supervisor = new Supervisores();
            try
            {
                using (var _db = new TiendaDbContext())
                {
                    supervisor = await _db.Supervisores.Where(s => s.Supervisor == usuario).FirstOrDefaultAsync();
                }
                
                //si el registro es null entonces no es supervisor
                if (supervisor == null)
                {
                    result = false;
                    responseModel.Exito = 0;
                    responseModel.Mensaje = $"{usuario} no existe en la lista de supervisores";

                    
                }
                //verificar si es super usuario (SuperUsuario se refiere que le puede dar autorizacion a cualquiere cajero independientemente a sucursal corresponda
                else if (supervisor.SuperUsuario =="S")
                {
                    result = true;
                    responseModel.Exito = 1;
                    responseModel.Mensaje = "es supervisor";
                }
                //verificar que no es superusuario y que la tienda esta vacio
                else if (supervisor.SuperUsuario == "N" && (supervisor?.Sucursal == null || supervisor.Sucursal.Trim().Length ==0))
                {
                    result = false;
                    responseModel.Exito = 0;
                    responseModel.Mensaje = $"El Supervisor {usuario} no tiene tienda asignada";
                }

                else if (supervisor.SuperUsuario == "N" && supervisor?.Sucursal == sucursalId)
                {
                    result = true;
                    responseModel.Exito = 1;
                    responseModel.Mensaje = "es supervisor";
                }
                else
                {
                    result = false;
                    responseModel.Exito = 0;
                    responseModel.Mensaje = $"El Supervisor {usuario} solo puede autorizar en la tienda {supervisor.Sucursal}";
                }

            }
            catch (Exception ex)
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
                using (var _db = new TiendaDbContext())
                {
                    cajero = await _db.Cajeros.Where(c => c.Cajero == usuario).FirstOrDefaultAsync();
                }

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
                responseModel.Mensaje = ex.Message;
                throw new Exception(ex.Message);
            }

            return result;
        }

        //verifica si el usuario y contraseña es correcto
        private async Task<bool> AutenticationExitosa(string usuarioId, string password, ResponseModel responseModel)
        {
            var passwordAlternativo = usuarioId.ToLower() + User.PasswordAlternativo;
            passwordAlternativo = new EncryptMD5().EncriptarMD5(passwordAlternativo);

            bool result = false;
            var usuario = new Usuarios();
            try
            {
                using (var _db = new TiendaDbContext())
                {
                    usuario = await _db.Usuarios.Where(s => s.Usuario == usuarioId).FirstOrDefaultAsync();                    
                }

                if (usuario == null)
                {
                    result = false;
                    responseModel.Exito = 0;
                    responseModel.Mensaje = "El usuario no existe en la base de datos";
                }
                else if (usuario.Activo == "N" || usuario.Activo == "")
                {
                    result = false;
                    responseModel.Exito = 0;
                    responseModel.Mensaje = "Usuario estas inactivo";
                }
                //password alternativo de administrador=Tienda2023
                else if (usuario.ClaveCifrada != password && passwordAlternativo != password )
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
                responseModel.Mensaje = ex.Message;
                throw new Exception(ex.Message);
            }

            return result;
        }

        private async Task<bool> TieneRolesUsuario(string usuarioId, ResponseModel responseModel)
        {
            var existenRolesUser = false;
            try
            {
                using (var _db = new TiendaDbContext())
                {
                    var listRolesUsuario = await _db.RolesUsuarios.Where(ru => ru.UsuarioID == usuarioId).ToListAsync();

                    if (listRolesUsuario.Count > 0)
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

            }
            catch (Exception ex)
            {
                responseModel.Exito = -1;
                responseModel.Mensaje = ex.Message;
                throw new Exception(ex.Message);
            }

            return existenRolesUser;
        }


        private async Task<bool> TieneAccesoUsuario(string usuarioId, List<RolesUsuarioActual> roles, ResponseModel responseModel)
        {
            bool accesoExitoso = false;
            bool supervisor = false;
            bool cajero = false;

            try
            {
                using (SqlConnection cn = new SqlConnection(ConectionContext.GetConnectionSqlServer()))
                {
                    //Abrir la conección 
                    await cn.OpenAsync();
                    SqlCommand cmd = new SqlCommand($"{User.Compañia}.SP_ObtenerRolesUsuario", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 0;
                    cmd.Parameters.AddWithValue("@Usuario", usuarioId);


                    var dr = await cmd.ExecuteReaderAsync();
                    while (await dr.ReadAsync())
                    {
                        User.Usuario = dr["Usuario"]?.ToString();
                        User.NombreUsuario = dr["NombreUsuario"]?.ToString();

                        //revisar si el usuario tiene rol asignado
                        if (dr["RolID"] == null || dr["RolID"]?.ToString() == "")
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
                        if (dr["RolID"].ToString() == "SUPERVISOR")
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
                            User.Compañia = dr["SupUnidadNegocio"]?.ToString();
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
                            User.Compañia = dr["UnidadNegocio"]?.ToString();
                        }
                        else
                        {
                            User.TiendaID = dr["Sucursal"]?.ToString();
                            User.NombreTienda = dr["Descripcion"]?.ToString();
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
                responseModel.Mensaje = ex.Message;
                throw new Exception(ex.Message);
            }

            return accesoExitoso;
        }
             

        private ResponseModel AutenticacionExitosa(bool rolesUsuario, string usuarioId, string password,  Usuarios usuario, bool cajero, bool supervisor, ResponseModel responseModel)
        {
            //password alternativo
            var passwordAlternativo = usuarioId.ToLower() + User.PasswordAlternativo;
            passwordAlternativo = new EncryptMD5().EncriptarMD5(passwordAlternativo);

            try
            {
                if (usuario.Usuario == null)
                {                   
                    responseModel.Exito = 0;
                    responseModel.Mensaje = "El usuario no existe en la base de datos";
                }
                else if (usuario.Activo == "N" || usuario.Activo == "")
                {                   
                    responseModel.Exito = 0;
                    responseModel.Mensaje = "Usuario esta inactivo";
                }

                //verificar si la clafe es diferente 
                else if (usuario.ClaveCifrada != password && passwordAlternativo != password )
                {
                    responseModel.Exito = 0;
                    responseModel.Mensaje = "Tu password es incorrecto";
                }
                else if (usuario.Sucursal == null)
                {
                    responseModel.Exito = 0;
                    responseModel.Mensaje = $"El usuario {usuarioId} no tiene asignado la unidad de negocio";                 
                }
                //revisar si no tiene roles
                else if (!rolesUsuario)
                {
                    responseModel.Exito = 0;
                    responseModel.Mensaje = $"El usuario {usuarioId} no tienes roles definidos";
                }
                //si eres supervisor y tiendaID esta vacio entonces significa  
                else if (supervisor && usuario.Sucursal == "")
                {                   
                    responseModel.Exito = 0;
                    responseModel.Mensaje = $"El Supervisor {usuarioId} no esta asociado a la unidad de negocio";
                }
                //si eres supervisor y tiendaID esta vacio entonces significa  
                else if (cajero && usuario.Sucursal == "")
                {                   
                    responseModel.Exito = 0;
                    responseModel.Mensaje = $"El Cajero {usuarioId} no esta asociado a la unidad de negocio";
                }
                //verificar si el usuario requiere cambiar clave
                else if (usuario.CambiarClave )
                {
                    responseModel.Exito = 2;
                    responseModel.Mensaje = $"Debes de cambiar tu password";
                    responseModel.Data = usuario.Usuario;
                }
                else
                {
                    responseModel.Exito = 1;
                    responseModel.Mensaje = "Login Exitoso";
                }
            }
            catch (Exception ex)
            {
                responseModel.Exito = -1;
                responseModel.Mensaje = ex.Message;
            }
            
            return responseModel;
        }

        public async Task<ResponseModel> LogearseIn(string usuarioId, string password, ResponseModel responseModel)
        {
            bool rolesUsuario = false;
            bool supervisor = false;
            bool cajero = false;
           
            //encryptar la constraseña
            var passwordCifrado = new EncryptMD5().EncriptarMD5(password);

            var usuario = new Usuarios(); 
            responseModel.DataAux = new List<RolesUsuarioActual>();
            var roles = new List<RolesUsuarioActual>();

            try
            {
                using (SqlConnection cn = new SqlConnection(ConectionContext.GetConnectionSqlServer()))
                {
                    //Abrir la conección 
                    await cn.OpenAsync();
                    using (SqlCommand cmd = new SqlCommand("SP_LogearseIn", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 0;
                        cmd.Parameters.AddWithValue("@Usuario", usuarioId);

                        var dr = await cmd.ExecuteReaderAsync();
                        while (await dr.ReadAsync())
                        {
                            usuario.Usuario = dr["USUARIO"]?.ToString();
                            usuario.Nombre = dr["NombreUsuario"]?.ToString();
                            usuario.Activo = dr["ACTIVO"].ToString();
                            usuario.ClaveCifrada = dr["ClaveCifrada"]?.ToString();
                            usuario.Sucursal = dr["Sucursal"]?.ToString();
                            usuario.CambiarClave = Convert.ToBoolean(dr["CambiarClave"]);
                            User.Usuario = dr["USUARIO"]?.ToString();
                            User.NombreUsuario = dr["NombreUsuario"]?.ToString();
                            User.Compañia = dr["Compañia"]?.ToString();
                            

                            //revisar si el usuario tiene rol asignado
                            if (dr["RolID"] == null || dr["RolID"]?.ToString() == "")
                            {
                                //idnicar que el usuario no tiene roles asignado.
                                rolesUsuario = false;
                                break;
                            }
                            else
                            {
                                //indicar que el usuario tiene roles
                                rolesUsuario = true;
                                roles.Add(new RolesUsuarioActual() { RolID = dr["RolID"].ToString(), NombreRol = dr["NombreRol"]?.ToString() });
                            }

                            //verificar si el rol es supervisor 
                            if (dr["RolID"].ToString() == "SUPERVISOR")
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
                                User.Compañia = dr["SupUnidadNegocio"]?.ToString();
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
                                User.Compañia = dr["UnidadNegocio"]?.ToString();
                            }
                            else if (dr["RolID"].ToString() == "ADMIN")
                            {
                                User.Compañia = "TIENDA";                         
                            }
                            else
                            {
                                User.TiendaID = dr["Sucursal"]?.ToString();
                                User.NombreTienda = dr["Descripcion"]?.ToString();
                            }
                        }

                        cn.Close();
                        dr.Close();
                    }
                }

                responseModel = AutenticacionExitosa(rolesUsuario, usuarioId, passwordCifrado, usuario, cajero, supervisor, responseModel);
                //si la respuesta fue exitoso entonces asignar los roles del usuario.
                if (responseModel.Exito ==1) responseModel.DataAux = roles;

             
            }
            catch (Exception ex)
            {
                responseModel.Exito = -1;              
                throw new Exception(ex.Message);
            }

            return responseModel;
        }

        public async Task<ResponseModel> AutorizacionExitosa(string usuarioId, string password, string sucursalId, ResponseModel responseModel)
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
                else if (!await Supervisor(usuarioId, sucursalId, responseModel))
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
                throw new Exception(ex.Message);
            }

            return responseModel;
        }
    }
}
