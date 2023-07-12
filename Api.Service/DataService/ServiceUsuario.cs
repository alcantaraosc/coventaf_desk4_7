﻿using Api.Context;
using Api.Helpers;
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
    public class ServiceUsuario//: ISecurityUsuarios
    {
        //private CoreDBContext _db;
      
        public ServiceUsuario()
        {
        }

        /// <summary>
        /// Listar los usuarios existentes
        /// </summary>
        /// <returns></returns>
        public async Task<ResponseModel> ListarUsuarios(ResponseModel responseModel)
        {
            var listaUsuario = new List<Usuarios>();
            try
            {
                using (TiendaDbContext _db = new TiendaDbContext())
                {
                    //Lista los usuarios en orden ascendentes por nombres
                    listaUsuario = await _db.Usuarios.OrderBy(u => u.Nombre).ToListAsync();
                }


                //Lista los usuarios en orden ascendentes por nombres
                //    var listUser = await _db.Usuarios.Where(user => user.Activo == activo).
                //        Select(user => new { Usuario = user.Usuario, Nombre = user.Nombre, Activo = user.Activo, Grupo = user.Grupo }).
                //        OrderBy(user => user.Nombre).ToListAsync();
                //    listaUsuario = listUser.Select(user => new { Usuario = user.Usuario, Nombre = user.Nombre, Activo = user.Activo, Grupo = user.Grupo }) as List<ListUser>;

                if (listaUsuario.Count > 0)
                {
                    responseModel.Exito = 1;
                    responseModel.Mensaje = "consulta exitosa";
                    responseModel.Data = listaUsuario as List<Usuarios>;
                }
                else
                {
                    responseModel.Exito = 0;
                    responseModel.Mensaje = "No se pudo realizar la consulta";
                    responseModel.Data = listaUsuario;
                }

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return responseModel;
        }


        /// <summary>
        /// listar los usuarios activos y desactivados
        /// </summary>
        /// <param name="activo"></param>
        /// <returns></returns>
        public async Task<List<Usuarios>> ListarUsuarios(string activo = "S")
        {
            List<Usuarios> listaUsuario = new List<Usuarios>();

            try
            {
                using (TiendaDbContext _db = new TiendaDbContext())
                {
                    //Lista los usuarios en orden ascendentes por nombres
                    listaUsuario = await _db.Usuarios.Where(user => user.Activo == activo).OrderBy(user => user.Nombre).ToListAsync();
                }
                   
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return listaUsuario;
        }


        /// <summary> 
        /// validar si existe el login del usuario
        /// </summary>
        /// <param name="loginUser"></param>
        /// <returns></returns>
        public bool ExisteLogin(string loginUser)
        {
            bool existeRegistro;
            try
            {
                using (TiendaDbContext _db = new TiendaDbContext())
                {
                    existeRegistro = _db.Usuarios.Where(user => user.Usuario.Trim() == loginUser).Count() > 0 ? true : false;
                }
            }
                   
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }

            return existeRegistro;
        }


        /// <summary> 
        /// Obtener solo el login del usuario filtrado por el UsuarioID
        /// </summary>
        /// <param name="usuarioID"></param>
        /// <returns></returns>
        public string ObtenerSoloLoginUserPorId(string usuarioID)
        {
            string loginUser;
            try
            {
                using (TiendaDbContext _db = new TiendaDbContext())
                {
                    loginUser = (from usr in _db.Usuarios
                                 where usr.Usuario == usuarioID
                                 select usr.Usuario).FirstOrDefault();
                }                   
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return loginUser;
        }

        /// <summary>
        /// ESTE METODO ES PARA PODER FILTRAR X NOMBRE DEL usuairo EN EL LISTADO
        /// </summary>
        /// <param name="value"></param>
        /// <param name="responseModel"></param>
        /// <returns></returns>
        public async Task<ResponseModel> ObtenerDatosUsuarioPorFiltroX( string tipoConsulta, string busqueda, ResponseModel responseModel)
        {
            var listUser = new List<Usuarios>();

            try
            {
                using (TiendaDbContext _db = new TiendaDbContext())
                {
                    switch (tipoConsulta)
                    {
                        case "Usuario":
                            listUser = await _db.Usuarios.Where(user => user.Usuario.Contains(busqueda)).ToListAsync();
                            break;

                        case "Nombre":

                            listUser = await _db.Usuarios.Where(user => user.Nombre.Contains(busqueda)).ToListAsync();
                            break;
                    }
                }
                  
                if (listUser.Count == 0)
                {
                    responseModel.Exito = 0;
                    responseModel.Mensaje = "No se encontraron datos del usuario";

                }
                else
                {
                    responseModel.Exito = 1;
                    responseModel.Data = listUser as List<Usuarios>;
                    responseModel.Mensaje = "<< Usuario encontrado >>";
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return responseModel;
        }

        public async Task<ResponseModel> ObtenerDatosCajeroPorFiltroX(string tipoConsulta, string busqueda,  ResponseModel responseModel, string sucursal = "")
        {
            var listCajero = new List<ViewModelCajero>();
            busqueda = $"%{busqueda}%";
            int valor = sucursal == "" ? 1 : 0;
            try
            {
             
                using (SqlConnection cn = new SqlConnection(ConectionContext.GetConnectionSqlServer()))
                {
                    //Abrir la conección 
                    await cn.OpenAsync();
                    
                    SqlCommand cmd = new SqlCommand($"SELECT CAJERO.CAJERO, CAJERO.GRUPO, CAJERO.VENDEDOR, CAJERO.VERIFICACION, CAJERO.ROTATIVO, CAJERO.NoteExistsFlag, "+
                                   $" CAJERO.RecordDate, CAJERO.RowPointer, CAJERO.CreatedBy, CAJERO.UpdatedBy, CAJERO.CreateDate, CAJERO.Sucursal, GRUPO.DESCRIPCION AS NombreSucursal "+
                                    $" FROM {ConectionContext.Esquema}.CAJERO LEFT JOIN {ConectionContext.Esquema}.GRUPO ON GRUPO.GRUPO = CAJERO.Sucursal WHERE CAJERO.CAJERO LIKE @Busqueda " +
                                    $" AND (GRUPO.GrupoAdministrado IN (SELECT GRUPO  FROM {ConectionContext.Esquema}.GRUPO WHERE GrupoAdministrado=@Sucursal) OR 1=@valor)", cn);
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandTimeout = 0;
                                  
                    cmd.Parameters.AddWithValue("@Busqueda", busqueda);
                    cmd.Parameters.AddWithValue("@Sucursal", sucursal);
                    cmd.Parameters.AddWithValue("@valor", valor);

                    var dr = await cmd.ExecuteReaderAsync();
                    while (await dr.ReadAsync())
                    {                        
                        listCajero.Add(new ViewModelCajero
                        {
                            Cajero = dr["CAJERO"].ToString(),
                            Vendedor = dr["VENDEDOR"].ToString(),
                            Rotativo = dr["ROTATIVO"].ToString(),
                            Sucursal = dr["Sucursal"]?.ToString(),
                            NombreSucursal = dr["NombreSucursal"]?.ToString(),
                            CreateDate = Convert.ToDateTime(dr["CreateDate"])
                        });
                       
                    }
                }

                if (listCajero.Count == 0)
                {
                    responseModel.Exito = 0;
                    responseModel.Mensaje = "No se encontraron datos del cajero";

                }
                else
                {
                    responseModel.Exito = 1;
                    responseModel.Data = listCajero as List<ViewModelCajero>;
                    responseModel.Mensaje = "<< Cajero encontrado >>";
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return responseModel;
        }

        public async Task<ResponseModel> ObtenerDatosSupervisorPorFiltroX(string tipoConsulta, string busqueda, ResponseModel responseModel)
        {
            var listSupervisor = new List<ViewModelSupervisor>();
            busqueda = $"%{busqueda}%";
            try
            {
                //using (TiendaDbContext _db = new TiendaDbContext())
                //{
                //    //listSupervisor = await _db.Supervisores.Where(sp => sp.Supervisor.Contains(busqueda)).ToListAsync();
                //    listSupervisor = await _db.Database.SqlQuery<Supervisores>($"SELECT SUPERVISOR.SUPERVISOR, SUPERVISOR.GRUPO, SUPERVISOR.SUPERUSUARIO, SUPERVISOR.NoteExistsFlag, SUPERVISOR.RecordDate, SUPERVISOR.RowPointer, " +
                //                                                                $" SUPERVISOR.CreatedBy, SUPERVISOR.UpdatedBy, SUPERVISOR.CreateDate, SUPERVISOR.Sucursal, GRUPO.DESCRIPCION AS NombreSucursal " +
                //                                                                $" FROM TIENDA.SUPERVISOR LEFT JOIN TIENDA.GRUPO ON GRUPO.GRUPO = SUPERVISOR.Sucursal WHERE SUPERVISOR.SUPERVISOR LIKE '%{busqueda}%'").ToListAsync();
                //}


                using (SqlConnection cn = new SqlConnection(ConectionContext.GetConnectionSqlServer()))
                {
                    //Abrir la conección 
                    await cn.OpenAsync();
                    var sqlQuery = $"SELECT SUPERVISOR.SUPERVISOR, SUPERVISOR.GRUPO, SUPERVISOR.SUPERUSUARIO, SUPERVISOR.NoteExistsFlag, SUPERVISOR.RecordDate, SUPERVISOR.RowPointer, "+
                                    $" SUPERVISOR.CreatedBy, SUPERVISOR.UpdatedBy, SUPERVISOR.CreateDate, SUPERVISOR.Sucursal, GRUPO.DESCRIPCION AS NombreSucursal " +
                                    $" FROM {ConectionContext.Esquema}.SUPERVISOR LEFT JOIN {ConectionContext.Esquema}.GRUPO ON GRUPO.GRUPO = SUPERVISOR.Sucursal WHERE SUPERVISOR.SUPERVISOR LIKE @Busqueda";
                    SqlCommand cmd = new SqlCommand(sqlQuery, cn);
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandTimeout = 0;
                    cmd.Parameters.AddWithValue("@Busqueda", busqueda);

                    var dr = await cmd.ExecuteReaderAsync();
                    while (await dr.ReadAsync())
                    {
                        listSupervisor.Add(new ViewModelSupervisor
                        {
                            Supervisor = dr["SUPERVISOR"].ToString(),
                            SuperUsuario = dr["SUPERUSUARIO"].ToString(),                           
                            Sucursal = dr["Sucursal"]?.ToString(),
                            NombreSucursal = dr["NombreSucursal"]?.ToString(),
                            CreateDate = Convert.ToDateTime(dr["CreateDate"])
                        });

                    }
                }

                if (listSupervisor.Count == 0)
                {
                    responseModel.Exito = 0;
                    responseModel.Mensaje = "No se encontraron datos del supervisor";
                }
                else
                {
                    responseModel.Exito = 1;
                    responseModel.Data = listSupervisor as List<ViewModelSupervisor>;
                    responseModel.Mensaje = "<< Supervisor encontrado >>";
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return responseModel;
        }

        /// <summary>
        /// Guardar o actualizar los datos del usuario
        /// </summary>
        /// <param name="model"></param>
        /// <param name="responseModel"></param>
        /// <returns></returns>
        public async Task InsertOrUpdateUsuario(ViewModelSecurity model, ResponseModel responseModel)
        {
            int result = 0;

            //string ConvertirArrayString = new Utilidades().ConvertirEnCadenatring(model.RolesUsuarios, "RolesUsuarios", "FuncionID");
            try
            {
                using (SqlConnection cn = new SqlConnection(ConectionContext.GetConnectionSqlServer()))
                {
                    using (SqlCommand cmd = new SqlCommand("SP_GuardarDatosUsuario", cn))
                    {
                        //Aquí agregas los parámetros de tu procedimiento
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 0;
                        cmd.Parameters.AddWithValue("@NuevoUsuario", model.Usuarios.NuevoUsuario);
                        cmd.Parameters.AddWithValue("@Usuario", model.Usuarios.Usuario);
                        cmd.Parameters.AddWithValue("@Nombre", model.Usuarios.Nombre);
                        cmd.Parameters.AddWithValue("@Tipo", model.Usuarios.Tipo);
                        cmd.Parameters.AddWithValue("@Activo", model.Usuarios.Activo);
                        cmd.Parameters.AddWithValue("@Req_Cambio_Clave", model.Usuarios.Req_Cambio_Clave);
                        cmd.Parameters.AddWithValue("@Frecuencia_Clave", model.Usuarios.Frecuencia_Clave);
                        cmd.Parameters.AddWithValue("@Max_Intentos_Conex", model.Usuarios.Max_Intentos_Conex);
                        cmd.Parameters.AddWithValue("@Clave", model.Usuarios.Clave);
                        cmd.Parameters.AddWithValue("@Correo_Electronico", model.Usuarios.Correo_Electronico);
                        cmd.Parameters.AddWithValue("@Tipo_Acceso", model.Usuarios.Tipo_Acceso);
                        //cmd.Parameters.AddWithValue("@NoteExistsFlag", model.Usuarios.NoteExistsFlag);
                        //cmd.Parameters.AddWithValue("@RowPointer", model.Usuarios.RowPointer);
                        cmd.Parameters.AddWithValue("@CreatedBy", model.Usuarios.CreatedBy);
                        cmd.Parameters.AddWithValue("@UpdatedBy", model.Usuarios.UpdatedBy);
                        cmd.Parameters.AddWithValue("@ClaveCifrada", model.Usuarios.ClaveCifrada);
                        cmd.Parameters.AddWithValue("@Sucursal", model.Usuarios.Sucursal);

                        var dt = new DataTable();
                        dt.Columns.Add("RolID", typeof(string));
                        dt.Columns.Add("UsuarioID", typeof(string));
                        foreach (var item in model.RolesUsuarios)
                        {
                            dt.Rows.Add(item.RolID, item.UsuarioID);           
                        }

                        var parametro = cmd.Parameters.AddWithValue("@AsignarRolesUsuario", dt);
                        parametro.SqlDbType = SqlDbType.Structured;


                        //Abres la conexión 
                        await cn.OpenAsync();
                        //Ejecutas el procedimiento, y guardas en una variable tipo int el número de lineas afectadas en las tablas que se insertaron
                        //(ExecuteNonQuery devuelve un valor entero, en éste caso, devolverá el número de filas afectadas después del insert, si es mayor a > 0, entonces el insert se hizo con éxito)
                        result = await cmd.ExecuteNonQueryAsync();

                        if (result > 0)
                        {
                            responseModel.Mensaje = (model.Usuarios.NuevoUsuario) ? "Los datos se ha guardado correctamente" : "Se ha actualizado correctamente";
                            responseModel.Exito = 1;
                        }
                        else
                        {
                            responseModel.Mensaje = (model.Usuarios.NuevoUsuario) ? "No se pueden guardar los datos" : "No se puede actualizar los datos";
                            responseModel.Exito = 0;
                        }
                    }

                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<(bool, string)> DeleteBookAsync(Usuarios user)
        {
            try
            {
                using (TiendaDbContext _db = new TiendaDbContext())
                {
                    var dbBook = await _db.Usuarios.FindAsync(user.Usuario);

                    if (dbBook == null)
                    {
                        return (false, "Book could not be found.");
                    }

                    _db.Usuarios.Remove(user);
                    await _db.SaveChangesAsync();
                }
                 

                return (true, "Book got deleted.");
            }
            catch (Exception ex)
            {
                return (false, $"An error occured. Error Message: {ex.Message}");
            }
        }

        /// <summary>
        /// Obtener el usuario por ID para la editación
        /// </summary>
        /// <param name="usuarioID"></param>
        /// <returns></returns>
        public async Task<ResponseModel> ObtenerUsuarioPorIdAsync(string usuarioID, ResponseModel responseModel)
        {
            
            ViewModelSecurity viewModelSecurity = new ViewModelSecurity();
            viewModelSecurity.Usuarios = new Usuarios();
            viewModelSecurity.RolesUsuarios = new List<RolesUsuarios>();

            var consultaExitosa = false;

            try
            {
                using (SqlConnection cn = new SqlConnection(ConectionContext.GetConnectionSqlServer()))
                {
                    //Abrir la conección 
                    await cn.OpenAsync();
                    SqlCommand cmd = new SqlCommand($" SELECT USUARIO.USUARIO," +
                                                    $" USUARIO.NOMBRE,      " +
                                                    $" USUARIO.CORREO_ELECTRONICO," +
                                                    $" USUARIO.ACTIVO,        " +
                                                    $" USUARIO.ClaveCifrada,      " +
                                                    $" USUARIO.Sucursal,      " +
                                                    $" RolesUsuarios.RolID, " +
                                                    $" RolesUsuarios.FechaCreacion, " +
                                                    $" Roles.NombreRol " +
                                                    $" FROM ERPADMIN.USUARIO " +
                                                    $"      LEFT JOIN  RolesUsuarios ON USUARIO.USUARIO = RolesUsuarios.UsuarioID " +
                                                    $"      LEFT JOIN Roles ON RolesUsuarios.RolID= Roles.RolID WHERE USUARIO.USUARIO= '{@usuarioID}'", cn);
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandTimeout = 0;
                    cmd.Parameters.AddWithValue("@usuarioID", usuarioID);

                    var dr = await cmd.ExecuteReaderAsync();

                    int row = 1;

                    while (await dr.ReadAsync())
                    {
                        consultaExitosa = true;

                        if (row == 1)
                        {
                            viewModelSecurity.Usuarios.Usuario = dr["USUARIO"].ToString();
                            viewModelSecurity.Usuarios.Nombre = dr["NOMBRE"].ToString();
                            viewModelSecurity.Usuarios.Correo_Electronico = dr["CORREO_ELECTRONICO"]?.ToString();
                            viewModelSecurity.Usuarios.Activo = dr["ACTIVO"].ToString();
                            viewModelSecurity.Usuarios.ClaveCifrada = dr["ClaveCifrada"]?.ToString();
                            viewModelSecurity.Usuarios.Sucursal = dr["Sucursal"]?.ToString();
                            //verifico si la clave es null o si esta vacio, entonces procedo a poner le un null, de lo contrario significa que tiene contraseña y procedo a desencriptar
                            viewModelSecurity.Usuarios.ClaveCifrada = (viewModelSecurity.Usuarios.ClaveCifrada is null || viewModelSecurity.Usuarios.ClaveCifrada.Trim().Length == 0) ? null : new EncryptMD5().DesencriptarMD5(viewModelSecurity.Usuarios.ClaveCifrada);
                        }

                    
                        //verificar si tiene rol
                        if (dr["RolID"] != DBNull.Value)
                        {
                            //agregar los roles del usuario
                            viewModelSecurity.RolesUsuarios.Add(new RolesUsuarios
                            {
                                RolID = dr["RolID"].ToString(),
                                UsuarioID = dr["USUARIO"].ToString(),
                                NombreRol = dr["NombreRol"].ToString(),
                                FechaCreacion = Convert.ToDateTime(dr["FechaCreacion"])
                            });
                        }
                        row++;
                    }

                }

                   
                //verificar si la consulta fue exitosa
                if (consultaExitosa)
                {
                    //1 signinfica que la consulta fue exitosa
                    responseModel.Exito = 1;
                    responseModel.Mensaje = "Consulta exitosa";
                    responseModel.Data = viewModelSecurity;
                }
                else
                {
                    //0 signinfica que la consulta no se encontro en la base de datos
                    responseModel.Exito = 0;
                    responseModel.Mensaje = $"El articulo {usuarioID} no existe en la base de datos";
                    responseModel.Data = null;
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return responseModel; 
           
        }

        /// <summary>
        /// Verificar si existe en la tabla usuario
        /// </summary>
        /// <param name="usuarioID"></param>
        /// <returns></returns>
        public bool ExisteDataOnTablaUsuario(string usuarioID, ResponseModel responseModel)
        {
            bool existeRegistro;
            try
            {
                using (TiendaDbContext _db = new TiendaDbContext())
                {
                    //comprobar si en el la tabla usuario existe el registro 
                    existeRegistro = _db.Usuarios.Where(user => user.Usuario == usuarioID).Count() > 0 ? true : false;
                }

                if (!existeRegistro)
                {
                    responseModel.Mensaje = $"No existe el usuario {usuarioID} en la base de dato";
                    responseModel.Exito = 0;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }

            return existeRegistro;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="usuarioID"></param>
        /// <param name="responseModel"></param>
        /// <returns></returns>
        public async Task<int> EliminarUsuario(string usuarioID, ResponseModel responseModel)
        {
            var result = 0;
            try
            {
                //verificar si existe el usuario en la base de datos
                if (!ExisteDataOnTablaUsuario(usuarioID, responseModel))
                {
                    responseModel.Exito = 0;
                    responseModel.Mensaje = "No existe el usuario en la base de datos";
                }
                //verificar si existe el usuario  en otras  tablas
                else if (ExisteUsuarioEnTablaRolesUsuarios(usuarioID, responseModel))
                {
                    responseModel.Exito = 0;
                    responseModel.Mensaje = "No se puede eliminar el usuario, " +
                                            "esta siendo usada en otras tablas";
                }
                else
                {
                    //obtener los datos de la tabla usuario
                    var usuar = await ObtenerUsuarioPorId(usuarioID, responseModel);
                    using (TiendaDbContext _db = new TiendaDbContext())
                    {
                        //elimina los datos de la tabla usuario
                        _db.Usuarios.Remove(usuar);
                        result = _db.SaveChanges();

                    }

                    //comprobar si elimino el rol
                    if (result > 0)
                    {
                        responseModel.Mensaje = "Se ha eliminado exitosamente";
                        responseModel.Exito = 1;
                    }
                    else
                    {
                        responseModel.Mensaje = "No se ha eliminado el usuario";
                        responseModel.Exito = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }


        /// <summary>
        /// obtener usuario por ID
        /// </summary>
        /// <param name="usuarioID"></param>
        /// <param name="responseModel"></param>
        /// <returns></returns>
        public async Task<Usuarios> ObtenerUsuarioPorId(string usuarioID, ResponseModel responseModel)
        {
            var model = new Usuarios();

            try
            {
                using (TiendaDbContext _db = new TiendaDbContext())
                {
                    model = await _db.Usuarios.Where(user => user.Usuario == usuarioID).FirstOrDefaultAsync();
                }
                  
                //verificar si el modelo es null
                if (model == null)
                {
                    responseModel.Exito = 0;
                    responseModel.Mensaje = "No existe el usuario en la base de datos";
                }
                else
                {
                    responseModel.Exito = 1;
                    responseModel.Mensaje = "<<Usuario encontrado>>";
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return model;
        }


        /// <summary>
        /// existe el usuario ID  en la tabla RolesUsuario
        /// </summary>
        /// <param name="usuarioID"></param>
        /// <param name="responseModel"></param>
        /// <returns></returns>
        public bool ExisteUsuarioEnTablaRolesUsuarios(string usuarioID, ResponseModel responseModel)
        {
            bool existeusuario;

            try
            {
                using (TiendaDbContext _db = new TiendaDbContext())
                {
                    //comprobar si en el la tabla rolesusuairo existe id del usuario
                    existeusuario = _db.RolesUsuarios.Where(id => id.UsuarioID == usuarioID).Count() > 0 ? true : false;
                }
                   
            }

            catch (Exception ex)
            {
                responseModel.Exito = -1;
                responseModel.Mensaje = ex.Message;
                throw new Exception("Error: " + ex.Message);
            }

            return existeusuario;

        }



        /// <summary> 
        /// validar el modelo del Usuario
        /// </summary>
        /// <param name="model"></param>
        /// <param name="responseModel"></param>
        /// <returns></returns>
        public bool ModeloUsuarioEsValido(ViewModelSecurity model, ResponseModel responseModel)
        {
            bool modeloIsValido = false;
            try
            {
                //validar 
                if (model.Usuarios.Nombre == null)
                {
                    responseModel.Exito = 0;
                    responseModel.Mensaje = "Debes de Ingresar el Nombre y Apellido del Usuario";
                    responseModel.NombreInput = "NombreUsuario";                    
                }

                else if (model.Usuarios.Usuario == null)
                {
                    responseModel.Exito = 0;
                    responseModel.Mensaje = "Debes de Ingresar el Login del usuario";
                    responseModel.NombreInput = "LoginUsuario";
                }

                else if (model.Usuarios.ClaveCifrada == null)
                {
                    responseModel.Exito = 0;
                    responseModel.Mensaje = "Debes de ingresar la clave";
                    responseModel.NombreInput = "Clave_Cifrada";
                }
                else if (model.Usuarios.ClaveCifrada != model.Usuarios.ConfirmarClaveCifrada)
                {
                    responseModel.Exito = 0;
                    responseModel.Mensaje = "El Password de Confirmacion es diferente";
                    responseModel.NombreInput = "ConfirmarClaveCifrada";
                }
                else
                {
                    model.Usuarios.Nombre = model.Usuarios.Nombre.Trim();

                    //model.Usuario.Correo = model.Usuario.Correo.Trim();
                    model.Usuarios.Usuario = model.Usuarios.Usuario.Trim();
                    model.Usuarios.ClaveCifrada = model.Usuarios.ClaveCifrada.Trim();


                    //comprobar si es nuevo usuario
                    if (model.Usuarios.NuevoUsuario)
                    {
                        //comprobar si el modelo es valido cuando se esta agregando un nuevo registro
                        modeloIsValido = ModelIsValidWhenIsNewUsuario(model, responseModel);
                    }
                    else
                    {
                        //comprobar si el modelo es valido cuando se está editando el registro
                        modeloIsValido = ModelIsValidWhenIsEditUsuario(model, responseModel);
                    }

                    model.Usuarios.ClaveCifrada = new EncryptMD5().EncriptarMD5(model.Usuarios.ClaveCifrada);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return modeloIsValido;
        }

        /// <summary> continue 29/10/2021
        /// Verificar si el modelo es valido cuando se está editando el registro
        /// </summary>
        /// <param name="model"></param>
        /// <param name="respuesta"></param>
        /// <returns></returns>
        private bool ModelIsValidWhenIsEditUsuario(ViewModelSecurity model, ResponseModel responseModel)
        {
            bool modeloIsValido = false;
            try
            {
                //Obtener el login del Usuario filtrado por el usuarioID
                var loginUserConsultado = ObtenerSoloLoginUserPorId(model.Usuarios.Usuario);

                //comprobar si el login del usuario  es diferente la login de usuario que edito es diferente al login de usuario de la base de datos
                //y verifico en base de datos si existe el login de usuario que estoy editando.
                if ((loginUserConsultado.Trim() != model.Usuarios.Usuario.Trim()) && (ExisteLogin(model.Usuarios.Usuario.Trim())))
                {
                    responseModel.Mensaje = "El login del Usuario ya existe";
                    responseModel.NombreInput = "Usuario";
                }
                else
                {
                    modeloIsValido = true;
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return modeloIsValido;
        }


        /// <summary> 
        /// Verificar si el modelo es valido cuando es un nuevo registro
        /// </summary>
        /// <param name="model"></param>
        /// <param name="responseModel"></param>
        /// <returns></returns>
        private bool ModelIsValidWhenIsNewUsuario(ViewModelSecurity model, ResponseModel responseModel)
        {
            bool modeloIsValido = false;
            try
            {

                //comprobar si el existe el nombre del usuario
                if (ExisteLogin(model.Usuarios.Usuario.Trim()))
                {
                    responseModel.Exito = 0;
                    responseModel.Mensaje = "El login del usuario ya existe";
                    responseModel.NombreInput = "LoginUsuario";
                }
                //comprobar si tiene check al campo activo
                else if (model.Usuarios.Activo == "N")
                {
                    responseModel.Exito = 0;
                    responseModel.Mensaje = "Debes de activar el campo activo";
                    responseModel.NombreInput = "Activo";
                }
                else
                {
                    model.Usuarios.RowPointer = new Utilidades().GenerarGuid();
                    model.Usuarios.Fecha_Ult_Clave = DateTime.Now;
                    model.Usuarios.RecordDate = DateTime.Now;
                    modeloIsValido = true;
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

            return modeloIsValido;
        }
    }
}