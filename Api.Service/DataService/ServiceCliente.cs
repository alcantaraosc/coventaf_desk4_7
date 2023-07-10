using Api.Context;
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


        public async Task<ResponseModel> ConsultarCliente(string tipoFiltro, string busqueda, ResponseModel responseModel)
        {
            var cliente = new List<ListaCliente>();
            try
            {
                var sqlQuery = "";
                switch (tipoFiltro)
                {
                    case "Codigo":
                        //cliente = await _db.Clientes.Where(cl => cl.Contribuyente.Contains(busqueda)).ToListAsync();
                        //cliente = await _db.Database.SqlQuery<Clientes>("SELECT * FROM TIENDA.CLIENTE WHERE CLIENTE LIKE '" + busqueda + "'").ToListAsync();

                        sqlQuery = $"SELECT U_FECHA_VENC_CONTRATO AS FECHA_VENCIMIENTO_CONTRATO, NOTAS, CLIENTE, CONTRIBUYENTE AS CEDULA, U_IDENTIDAD AS IDENTIDAD, A.NOMBRE,B.NOMBRE AS GRADO," +
                            "U_NUMERO_UNICO AS NUMERO_UNICO, C.U_DESCRIP AS PROCEDENCIA, D.U_DESCRIP AS UNIDAD_MILITAR, U_AUTORIZA AS AUTORIZA, CASE WHEN  CLI_CORPORAC_ASOC IS NULL THEN CLIENTE ELSE CLI_CORPORAC_ASOC END TITULAR, " +
                            " dbo.fn_NombreTitular(CASE WHEN  CLI_CORPORAC_ASOC IS NULL THEN CLIENTE ELSE CLI_CORPORAC_ASOC END) AS NOMBRE_TITULAR FROM TIENDA.CLIENTE A LEFT OUTER JOIN TIENDA.ZONA B  ON B.ZONA = A.ZONA " +
                            " LEFT OUTER JOIN TIENDA.U_PROCEDENCIA C ON C.U_CODIGO = A.U_PROCEDENCIA LEFT OUTER JOIN TIENDA.U_UNIDAD_MILITAR D ON D.U_CODIGO = A.U_UNIDAD_MILITAR  WHERE CASE WHEN CLI_CORPORAC_ASOC IS NULL THEN CLIENTE ELSE CLI_CORPORAC_ASOC END LIKE @busqueda";

                        break;

                    case "Nombre":
                        sqlQuery = "SELECT  U_FECHA_VENC_CONTRATO AS FECHA_VENCIMIENTO_CONTRATO, NOTAS, CLIENTE, CONTRIBUYENTE AS CEDULA, U_IDENTIDAD AS IDENTIDAD, A.NOMBRE, B.NOMBRE AS GRADO, U_NUMERO_UNICO AS NUMERO_UNICO, " +
                            $" C.U_DESCRIP AS PROCEDENCIA, D.U_DESCRIP AS  UNIDAD_MILITAR, U_AUTORIZA AS AUTORIZA, CASE WHEN  CLI_CORPORAC_ASOC IS NULL THEN CLIENTE ELSE CLI_CORPORAC_ASOC END TITULAR, " +
                            $" dbo.fn_NombreTitular(CASE WHEN  CLI_CORPORAC_ASOC IS NULL THEN CLIENTE ELSE CLI_CORPORAC_ASOC END) AS NOMBRE_TITULAR FROM TIENDA.CLIENTE A LEFT OUTER JOIN TIENDA.ZONA B  ON B.ZONA = A.ZONA " +
                            $" LEFT OUTER JOIN TIENDA.U_PROCEDENCIA C ON C.U_CODIGO = A.U_PROCEDENCIA LEFT OUTER JOIN TIENDA.U_UNIDAD_MILITAR D ON D.U_CODIGO = A.U_UNIDAD_MILITAR  where A.NOMBRE LIKE @Busqueda ";

                        //sqlQuery = $"SELECT U_FECHA_VENC_CONTRATO AS FECHAVENCIMIENTOCONTRATO,  NOTAS,CLIENTE, CONTRIBUYENTE AS CEDULA, U_IDENTIDAD AS IDENTIDAD, A.NOMBRE, B.NOMBRE AS GRADO, U_NUMERO_UNICO AS NUMEROUNICO, " +
                        //                                                 $" C.U_DESCRIP AS PROCEDENCIA, D.U_DESCRIP AS UNIDADMILITAR, U_AUTORIZA AS AUTORIZA, CASE WHEN  CLI_CORPORAC_ASOC IS NULL " +
                        //                                                 $" THEN CLIENTE ELSE CLI_CORPORAC_ASOC END TITULAR, dbo.fn_NombreTitular(CASE WHEN  CLI_CORPORAC_ASOC IS NULL THEN CLIENTE ELSE CLI_CORPORAC_ASOC END) as NOMBRETITULAR " +
                        //                                                 $" FROM TIENDA.CLIENTE A LEFT OUTER JOIN TIENDA.ZONA B  ON B.ZONA = A.ZONA LEFT OUTER JOIN TIENDA.U_PROCEDENCIA C ON C.U_CODIGO = A.U_PROCEDENCIA " +
                        //                                                 $" LEFT OUTER JOIN TIENDA.U_UNIDAD_MILITAR D ON D.U_CODIGO = A.U_UNIDAD_MILITAR  WHERE A.NOMBRE LIKE @Busqueda ";
                        break;

                    case "Identificacion":
                        //cliente = await _db.Clientes.Where(cl => cl.Contribuyente.Contains(busqueda)).ToListAsync();
                        //cliente = await _db.Database.SqlQuery<Clientes>("SELECT * FROM TIENDA.CLIENTE WHERE CONTRIBUYENTE LIKE '" + busqueda + "'").ToListAsync();
                        sqlQuery = $"SELECT U_FECHA_VENC_CONTRATO AS FECHA_VENCIMIENTO_CONTRATO , NOTAS, CLIENTE, CONTRIBUYENTE AS CEDULA, U_IDENTIDAD AS IDENTIDAD ,A.NOMBRE, B.NOMBRE AS GRADO, U_NUMERO_UNICO AS NUMERO_UNICO, " +
                                                           $" C.U_DESCRIP AS PROCEDENCIA, D.U_DESCRIP AS UNIDAD_MILITAR, U_AUTORIZA AS AUTORIZA, CASE WHEN  CLI_CORPORAC_ASOC IS NULL THEN CLIENTE ELSE CLI_CORPORAC_ASOC " +
                                                            $" END TITULAR, dbo.fn_NombreTitular(CASE WHEN  CLI_CORPORAC_ASOC IS NULL THEN CLIENTE ELSE CLI_CORPORAC_ASOC END) AS NOMBRE_TITULAR " +
                                                            $" FROM TIENDA.CLIENTE A LEFT OUTER JOIN TIENDA.ZONA B  ON B.ZONA = A.ZONA LEFT OUTER JOIN TIENDA.U_PROCEDENCIA C ON C.U_CODIGO = A.U_PROCEDENCIA " +
                                                            $" LEFT OUTER JOIN TIENDA.U_UNIDAD_MILITAR D ON D.U_CODIGO=A.U_UNIDAD_MILITAR  WHERE CONTRIBUYENTE LIKE @Busqueda";

                        break;

                    case "Beneficiario":

                        sqlQuery = $"SELECT U_FECHA_VENC_CONTRATO AS FECHA_VENCIMIENTO_CONTRATO, NULL AS AUTORIZA, NULL AS PROCEDENCIA, NULL AS IDENTIDAD, NULL AS GRADO, NULL AS NUMERO_UNICO, NULL AS UNIDAD_MILITAR, CLIENTE, " +
                            $"NOMBRE ,U_DESCRIP AS PARENTESCO, U_SEXO AS SEXO, U_FECHA_NAC AS FECHA_NAC, NOTAS, ISNULL(floor(cast(datediff(day,U_FECHA_NAC, GETDATE()) as float)/365),0) AS EDAD ," +
                                                                            $" CONTRIBUYENTE AS CEDULA, CASE WHEN  CLI_CORPORAC_ASOC IS NULL THEN CLIENTE ELSE CLI_CORPORAC_ASOC END TITULAR, " +
                                                                            $" dbo.fn_NombreTitular(CASE WHEN  CLI_CORPORAC_ASOC IS NULL THEN CLIENTE ELSE CLI_CORPORAC_ASOC END) AS NOMBRE_TITULAR " +
                                                                            $" FROM TIENDA.CLIENTE LEFT OUTER JOIN TIENDA.U_PARENTEZCO ON U_PARENTESCO = U_CODIGO " +
                                                                            $" WHERE CASE WHEN CLI_CORPORAC_ASOC IS NULL THEN CLIENTE ELSE CLI_CORPORAC_ASOC END = @Busqueda";

                        break;

                        //case "Beneficiario":

                        //    sqlQuery = $"SELECT U_FECHA_VENC_CONTRATO AS FECHA_VENCIMIENTO_CONTRATO, NULL AS AUTORIZA, NULL AS PROCEDENCIA, NULL AS IDENTIDAD, NULL AS GRADO, NULL AS NUMERO_UNICO, NULL AS UNIDAD_MILITAR, CLIENTE, " +
                        //        $"NOMBRE ,U_DESCRIP AS PARENTESCO, U_SEXO AS SEXO, U_FECHA_NAC AS FECHA_NAC, NOTAS, ISNULL(floor(cast(datediff(day,U_FECHA_NAC, GETDATE()) as float)/365),0) AS EDAD ," +
                        //                                                        $" CONTRIBUYENTE AS CEDULA, CASE WHEN  CLI_CORPORAC_ASOC IS NULL THEN CLIENTE ELSE CLI_CORPORAC_ASOC END TITULAR, " +
                        //                                                        $" dbo.fn_NombreTitular(CASE WHEN  CLI_CORPORAC_ASOC IS NULL THEN CLIENTE ELSE CLI_CORPORAC_ASOC END) AS NOMBRE_TITULAR " +
                        //                                                        $" FROM TIENDA.CLIENTE LEFT OUTER JOIN TIENDA.U_PARENTEZCO ON U_PARENTESCO = U_CODIGO " +
                        //                                                        $" WHERE CASE WHEN CLI_CORPORAC_ASOC IS NULL THEN CLIENTE ELSE CLI_CORPORAC_ASOC END = @Busqueda";

                        break;



                }


                using (SqlConnection cn = new SqlConnection(ConectionContext.GetConnectionSqlServer()))
                {
                    //Abrir la conección 
                    await cn.OpenAsync();

                    SqlCommand cmd = new SqlCommand("SP_ConsultarClientes", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 0;
                    cmd.Parameters.AddWithValue("@TipoFiltro", tipoFiltro);
                    cmd.Parameters.AddWithValue("@Busqueda", busqueda);


                    var dr = await cmd.ExecuteReaderAsync();
                    while (await dr.ReadAsync())
                    {
                        // resultExitoso = true;
                        var _datoCliente = new ListaCliente();

                        _datoCliente.Nota = DBNull.Value != dr["NOTAS"] ? dr["NOTAS"].ToString() : "";
                        _datoCliente.Cliente = DBNull.Value != dr["CLIENTE"] ? dr["CLIENTE"].ToString() : "";
                        _datoCliente.Cedula = DBNull.Value != dr["CEDULA"] ? dr["CEDULA"].ToString() : "";
                        _datoCliente.Identidad = DBNull.Value != dr["IDENTIDAD"] ? dr["IDENTIDAD"].ToString() : "";
                        _datoCliente.Nombre = DBNull.Value != dr["NOMBRE"] ? dr["NOMBRE"].ToString() : "";
                        _datoCliente.Grado = DBNull.Value != dr["GRADO"] ? dr["GRADO"].ToString() : "";
                        _datoCliente.NumeroUnico = DBNull.Value != dr["NUMERO_UNICO"] ? dr["NUMERO_UNICO"].ToString() : "";
                        _datoCliente.Procedencia = DBNull.Value != dr["PROCEDENCIA"] ? dr["PROCEDENCIA"].ToString() : "";
                        _datoCliente.UnidadMilitar = DBNull.Value != dr["UNIDAD_MILITAR"] ? dr["UNIDAD_MILITAR"].ToString() : "";

                        _datoCliente.Autoriza = DBNull.Value != dr["AUTORIZA"] ? dr["AUTORIZA"].ToString() : "";
                        _datoCliente.Titular = DBNull.Value != dr["TITULAR"] ? dr["TITULAR"].ToString() : "";
                        _datoCliente.NombreTitular = DBNull.Value != dr["NOMBRE_TITULAR"] ? dr["NOMBRE_TITULAR"].ToString() : "";

                        if (DBNull.Value != dr["FECHA_VENCIMIENTO_CONTRATO"])
                        {
                            _datoCliente.FechaVencimiento = Convert.ToDateTime(dr["FECHA_VENCIMIENTO_CONTRATO"]);
                        }
                        else
                        {
                            _datoCliente.FechaVencimiento = null;
                        }

                        if (tipoFiltro == "Beneficiario")
                        {
                            _datoCliente.Parentesco = DBNull.Value != dr["PARENTESCO"] ? dr["PARENTESCO"].ToString() : "";
                            _datoCliente.Sexo = DBNull.Value != dr["SEXO"] ? dr["SEXO"].ToString() : "";
                            _datoCliente.Edad = DBNull.Value != dr["EDAD"] ? dr["EDAD"].ToString() : "";

                            if (DBNull.Value != dr["FECHA_NAC"])
                            {
                                _datoCliente.FechaNacimiento = Convert.ToDateTime(dr["FECHA_NAC"]);
                            }
                            else
                            {
                                _datoCliente.FechaNacimiento = null;
                            }
                        }



                        cliente.Add(_datoCliente);

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
                    responseModel.Data = cliente as List<ListaCliente>;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return responseModel;
        }

        public async Task<ResponseModel> ObtenenerBeneficiario(string tipoFiltro, string busqueda, ResponseModel responseModel)
        {
            var cliente = new List<ListaCliente>();
            try
            {
                //var sqlQuery = "";
                //switch (tipoFiltro)
                //{
                //    case "Codigo":
                //        //cliente = await _db.Clientes.Where(cl => cl.Contribuyente.Contains(busqueda)).ToListAsync();
                //        //cliente = await _db.Database.SqlQuery<Clientes>("SELECT * FROM TIENDA.CLIENTE WHERE CLIENTE LIKE '" + busqueda + "'").ToListAsync();

                //        sqlQuery = $"SELECT U_FECHA_VENC_CONTRATO AS FECHA_VENCIMIENTO_CONTRATO, NOTAS, CLIENTE, CONTRIBUYENTE AS CEDULA, U_IDENTIDAD AS IDENTIDAD, A.NOMBRE,B.NOMBRE AS GRADO," +
                //            "U_NUMERO_UNICO AS NUMERO_UNICO, C.U_DESCRIP AS PROCEDENCIA, D.U_DESCRIP AS UNIDAD_MILITAR, U_AUTORIZA AS AUTORIZA, CASE WHEN  CLI_CORPORAC_ASOC IS NULL THEN CLIENTE ELSE CLI_CORPORAC_ASOC END TITULAR, " +
                //            " dbo.fn_NombreTitular(CASE WHEN  CLI_CORPORAC_ASOC IS NULL THEN CLIENTE ELSE CLI_CORPORAC_ASOC END) AS NOMBRE_TITULAR FROM TIENDA.CLIENTE A LEFT OUTER JOIN TIENDA.ZONA B  ON B.ZONA = A.ZONA " +
                //            " LEFT OUTER JOIN TIENDA.U_PROCEDENCIA C ON C.U_CODIGO = A.U_PROCEDENCIA LEFT OUTER JOIN TIENDA.U_UNIDAD_MILITAR D ON D.U_CODIGO = A.U_UNIDAD_MILITAR  WHERE CASE WHEN CLI_CORPORAC_ASOC IS NULL THEN CLIENTE ELSE CLI_CORPORAC_ASOC END LIKE @busqueda";

                //        break;

                //    case "Nombre":
                //        sqlQuery = "SELECT  U_FECHA_VENC_CONTRATO AS FECHA_VENCIMIENTO_CONTRATO, NOTAS, CLIENTE, CONTRIBUYENTE AS CEDULA, U_IDENTIDAD AS IDENTIDAD, A.NOMBRE, B.NOMBRE AS GRADO, U_NUMERO_UNICO AS NUMERO_UNICO, " +
                //            $" C.U_DESCRIP AS PROCEDENCIA, D.U_DESCRIP AS  UNIDAD_MILITAR, U_AUTORIZA AS AUTORIZA, CASE WHEN  CLI_CORPORAC_ASOC IS NULL THEN CLIENTE ELSE CLI_CORPORAC_ASOC END TITULAR, " +
                //            $" dbo.fn_NombreTitular(CASE WHEN  CLI_CORPORAC_ASOC IS NULL THEN CLIENTE ELSE CLI_CORPORAC_ASOC END) AS NOMBRE_TITULAR FROM TIENDA.CLIENTE A LEFT OUTER JOIN TIENDA.ZONA B  ON B.ZONA = A.ZONA " +
                //            $" LEFT OUTER JOIN TIENDA.U_PROCEDENCIA C ON C.U_CODIGO = A.U_PROCEDENCIA LEFT OUTER JOIN TIENDA.U_UNIDAD_MILITAR D ON D.U_CODIGO = A.U_UNIDAD_MILITAR  where A.NOMBRE LIKE @Busqueda ";

                //        //sqlQuery = $"SELECT U_FECHA_VENC_CONTRATO AS FECHAVENCIMIENTOCONTRATO,  NOTAS,CLIENTE, CONTRIBUYENTE AS CEDULA, U_IDENTIDAD AS IDENTIDAD, A.NOMBRE, B.NOMBRE AS GRADO, U_NUMERO_UNICO AS NUMEROUNICO, " +
                //        //                                                 $" C.U_DESCRIP AS PROCEDENCIA, D.U_DESCRIP AS UNIDADMILITAR, U_AUTORIZA AS AUTORIZA, CASE WHEN  CLI_CORPORAC_ASOC IS NULL " +
                //        //                                                 $" THEN CLIENTE ELSE CLI_CORPORAC_ASOC END TITULAR, dbo.fn_NombreTitular(CASE WHEN  CLI_CORPORAC_ASOC IS NULL THEN CLIENTE ELSE CLI_CORPORAC_ASOC END) as NOMBRETITULAR " +
                //        //                                                 $" FROM TIENDA.CLIENTE A LEFT OUTER JOIN TIENDA.ZONA B  ON B.ZONA = A.ZONA LEFT OUTER JOIN TIENDA.U_PROCEDENCIA C ON C.U_CODIGO = A.U_PROCEDENCIA " +
                //        //                                                 $" LEFT OUTER JOIN TIENDA.U_UNIDAD_MILITAR D ON D.U_CODIGO = A.U_UNIDAD_MILITAR  WHERE A.NOMBRE LIKE @Busqueda ";
                //        break;

                //    case "Identificacion":
                //        //cliente = await _db.Clientes.Where(cl => cl.Contribuyente.Contains(busqueda)).ToListAsync();
                //        //cliente = await _db.Database.SqlQuery<Clientes>("SELECT * FROM TIENDA.CLIENTE WHERE CONTRIBUYENTE LIKE '" + busqueda + "'").ToListAsync();
                //        sqlQuery = $"SELECT U_FECHA_VENC_CONTRATO AS FECHA_VENCIMIENTO_CONTRATO , NOTAS, CLIENTE, CONTRIBUYENTE AS CEDULA, U_IDENTIDAD AS IDENTIDAD ,A.NOMBRE, B.NOMBRE AS GRADO, U_NUMERO_UNICO AS NUMERO_UNICO, " +
                //                                           $" C.U_DESCRIP AS PROCEDENCIA, D.U_DESCRIP AS UNIDAD_MILITAR, U_AUTORIZA AS AUTORIZA, CASE WHEN  CLI_CORPORAC_ASOC IS NULL THEN CLIENTE ELSE CLI_CORPORAC_ASOC " +
                //                                            $" END TITULAR, dbo.fn_NombreTitular(CASE WHEN  CLI_CORPORAC_ASOC IS NULL THEN CLIENTE ELSE CLI_CORPORAC_ASOC END) AS NOMBRE_TITULAR " +
                //                                            $" FROM TIENDA.CLIENTE A LEFT OUTER JOIN TIENDA.ZONA B  ON B.ZONA = A.ZONA LEFT OUTER JOIN TIENDA.U_PROCEDENCIA C ON C.U_CODIGO = A.U_PROCEDENCIA " +
                //                                            $" LEFT OUTER JOIN TIENDA.U_UNIDAD_MILITAR D ON D.U_CODIGO=A.U_UNIDAD_MILITAR  WHERE CONTRIBUYENTE LIKE @Busqueda";

                //        break;

                //    case "Beneficiario":

                //        sqlQuery = $"SELECT U_FECHA_VENC_CONTRATO AS FECHA_VENCIMIENTO_CONTRATO, NULL AS AUTORIZA, NULL AS PROCEDENCIA, NULL AS IDENTIDAD, NULL AS GRADO, NULL AS NUMERO_UNICO, NULL AS UNIDAD_MILITAR, CLIENTE, " +
                //            $"NOMBRE ,U_DESCRIP AS PARENTESCO, U_SEXO AS SEXO, U_FECHA_NAC AS FECHA_NAC, NOTAS, ISNULL(floor(cast(datediff(day,U_FECHA_NAC, GETDATE()) as float)/365),0) AS EDAD ," +
                //                                                            $" CONTRIBUYENTE AS CEDULA, CASE WHEN  CLI_CORPORAC_ASOC IS NULL THEN CLIENTE ELSE CLI_CORPORAC_ASOC END TITULAR, " +
                //                                                            $" dbo.fn_NombreTitular(CASE WHEN  CLI_CORPORAC_ASOC IS NULL THEN CLIENTE ELSE CLI_CORPORAC_ASOC END) AS NOMBRE_TITULAR " +
                //                                                            $" FROM TIENDA.CLIENTE LEFT OUTER JOIN TIENDA.U_PARENTEZCO ON U_PARENTESCO = U_CODIGO " +
                //                                                            $" WHERE CASE WHEN CLI_CORPORAC_ASOC IS NULL THEN CLIENTE ELSE CLI_CORPORAC_ASOC END = @Busqueda";

                //        break;

                //        //case "Beneficiario":

                //        //    sqlQuery = $"SELECT U_FECHA_VENC_CONTRATO AS FECHA_VENCIMIENTO_CONTRATO, NULL AS AUTORIZA, NULL AS PROCEDENCIA, NULL AS IDENTIDAD, NULL AS GRADO, NULL AS NUMERO_UNICO, NULL AS UNIDAD_MILITAR, CLIENTE, " +
                //        //        $"NOMBRE ,U_DESCRIP AS PARENTESCO, U_SEXO AS SEXO, U_FECHA_NAC AS FECHA_NAC, NOTAS, ISNULL(floor(cast(datediff(day,U_FECHA_NAC, GETDATE()) as float)/365),0) AS EDAD ," +
                //        //                                                        $" CONTRIBUYENTE AS CEDULA, CASE WHEN  CLI_CORPORAC_ASOC IS NULL THEN CLIENTE ELSE CLI_CORPORAC_ASOC END TITULAR, " +
                //        //                                                        $" dbo.fn_NombreTitular(CASE WHEN  CLI_CORPORAC_ASOC IS NULL THEN CLIENTE ELSE CLI_CORPORAC_ASOC END) AS NOMBRE_TITULAR " +
                //        //                                                        $" FROM TIENDA.CLIENTE LEFT OUTER JOIN TIENDA.U_PARENTEZCO ON U_PARENTESCO = U_CODIGO " +
                //        //                                                        $" WHERE CASE WHEN CLI_CORPORAC_ASOC IS NULL THEN CLIENTE ELSE CLI_CORPORAC_ASOC END = @Busqueda";

                //        break;



                //}


                using (SqlConnection cn = new SqlConnection(ConectionContext.GetConnectionSqlServer()))
                {
                    //Abrir la conección 
                    await cn.OpenAsync();

                    SqlCommand cmd = new SqlCommand("SP_ConsultarBeneficiario", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 0;
                    cmd.Parameters.AddWithValue("@Busqueda", busqueda);

                    var dr = await cmd.ExecuteReaderAsync();
                    while (await dr.ReadAsync())
                    {
                        // resultExitoso = true;
                        var _datoCliente = new ListaCliente();

                        _datoCliente.Nota = DBNull.Value != dr["NOTAS"] ? dr["NOTAS"].ToString() : "";
                        _datoCliente.Cliente = DBNull.Value != dr["CLIENTE"] ? dr["CLIENTE"].ToString() : "";
                        _datoCliente.Cedula = DBNull.Value != dr["CEDULA"] ? dr["CEDULA"].ToString() : "";
                        _datoCliente.Identidad = DBNull.Value != dr["IDENTIDAD"] ? dr["IDENTIDAD"].ToString() : "";
                        _datoCliente.Nombre = DBNull.Value != dr["NOMBRE"] ? dr["NOMBRE"].ToString() : "";
                        _datoCliente.Grado = DBNull.Value != dr["GRADO"] ? dr["GRADO"].ToString() : "";
                        _datoCliente.NumeroUnico = DBNull.Value != dr["NUMERO_UNICO"] ? dr["NUMERO_UNICO"].ToString() : "";
                        _datoCliente.Procedencia = DBNull.Value != dr["PROCEDENCIA"] ? dr["PROCEDENCIA"].ToString() : "";
                        _datoCliente.UnidadMilitar = DBNull.Value != dr["UNIDAD_MILITAR"] ? dr["UNIDAD_MILITAR"].ToString() : "";

                        _datoCliente.Autoriza = DBNull.Value != dr["AUTORIZA"] ? dr["AUTORIZA"].ToString() : "";
                        _datoCliente.Titular = DBNull.Value != dr["TITULAR"] ? dr["TITULAR"].ToString() : "";
                        _datoCliente.NombreTitular = DBNull.Value != dr["NOMBRE_TITULAR"] ? dr["NOMBRE_TITULAR"].ToString() : "";

                        if (DBNull.Value != dr["FECHA_VENCIMIENTO_CONTRATO"])
                        {
                            _datoCliente.FechaVencimiento = Convert.ToDateTime(dr["FECHA_VENCIMIENTO_CONTRATO"]);
                        }
                        else
                        {
                            _datoCliente.FechaVencimiento = null;
                        }

                        _datoCliente.Parentesco = DBNull.Value != dr["PARENTESCO"] ? dr["PARENTESCO"].ToString() : "";
                        _datoCliente.Sexo = DBNull.Value != dr["SEXO"] ? dr["SEXO"].ToString() : "";
                        _datoCliente.Edad = DBNull.Value != dr["EDAD"] ? dr["EDAD"].ToString() : "";

                        if (DBNull.Value != dr["FECHA_NAC"])
                        {
                            _datoCliente.FechaNacimiento = Convert.ToDateTime(dr["FECHA_NAC"]);
                        }
                        else
                        {
                            _datoCliente.FechaNacimiento = null;
                        }                    
                        cliente.Add(_datoCliente);

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
                    responseModel.Data = cliente as List<ListaCliente>;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return responseModel;
        }

        public async Task<ResponseModel> ObtenenerFechaVencimientoTitular(string titular, ResponseModel responseModel)
        {
            var cliente = new ListaCliente();
            bool resultExitoso = false;
            try
            {
   
                using (SqlConnection cn = new SqlConnection(ConectionContext.GetConnectionSqlServer()))
                {
                    //Abrir la conección 
                    await cn.OpenAsync();

                    SqlCommand cmd = new SqlCommand("SP_ObtenerFechaVencimientoTitular", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 0;
                    cmd.Parameters.AddWithValue("@Titular", titular);

                    var dr = await cmd.ExecuteReaderAsync();
                    if (await dr.ReadAsync())
                    {
                         resultExitoso = true;
                   
                        cliente.Titular = DBNull.Value != dr["TITULAR"] ? dr["TITULAR"].ToString() : "";
                        cliente.MensajeVencido = DBNull.Value != dr["VENCIDO"] ? dr["VENCIDO"].ToString() : "";
                        cliente.VencidoID = dr["VENCIDOID"].ToString();
                        cliente.Nota = DBNull.Value != dr["NOTAS"] ? dr["NOTAS"].ToString() : "";
                    }
                }

                if (resultExitoso)
                {
                    //1 signinfica que la consulta fue exitosa
                    responseModel.Exito = 1;
                    responseModel.Mensaje = "Consulta exitosa";
                    responseModel.Data = cliente as ListaCliente;                   
                }
                else
                {
                    //0 signinfica que la consulta no se encontro en la base de datos
                    responseModel.Exito = 0;
                    responseModel.Mensaje = $"No existe cliente en la base de datos";
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return responseModel;
        }

        public async Task<ResponseModel> GuardarRegistroVisita(Cs_Bitacora_Visita cs_Bitacora_Visita, List<Cs_Acompanante> cs_Acompanante, ResponseModel responseModel)
        {
            int result = 0;
            try
            {
                using (SqlConnection cn = new SqlConnection(ConectionContext.GetConnectionSqlServer()))
                {
                    //Abrir la conección 
                    await cn.OpenAsync();
                    SqlCommand cmd = new SqlCommand($"SP_GuardarRegistroVisita", cn);
                    cmd.CommandTimeout = 0;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Cliente", cs_Bitacora_Visita.Cliente);
                    cmd.Parameters.AddWithValue("@Titular", cs_Bitacora_Visita.Titular);
                    cmd.Parameters.AddWithValue("@Usuario", cs_Bitacora_Visita.Usuario_Registro);
                    cmd.Parameters.AddWithValue("@Tienda", User.TiendaID);
         
                    var dtAcompañante = new DataTable();
                    dtAcompañante.Columns.Add("Cedula", typeof(string));
                    dtAcompañante.Columns.Add("Nombre", typeof(string));
                    dtAcompañante.Columns.Add("Observacion", typeof(string));
 
                    foreach (var item in cs_Acompanante)
                    {
                        dtAcompañante.Rows.Add(item.Cedula, item.Nombre_Visitar, item.Observacion);
                    }

                    var parametroFacturaLinea = cmd.Parameters.AddWithValue("@DetAcompañante", dtAcompañante);
                    parametroFacturaLinea.SqlDbType = SqlDbType.Structured;

                    result = await cmd.ExecuteNonQueryAsync();
                }

                if (result > 0)
                {
                    responseModel.Exito = 1;
                    responseModel.Mensaje = $"Se guardo exitosamente el registro";
                }
                else
                {
                    responseModel.Exito = 0;
                    responseModel.Mensaje = $"Se pudo guardar el registro";
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
