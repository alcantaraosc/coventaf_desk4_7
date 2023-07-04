using Api.Model.ViewModels;
using Api.Setting;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Api.Service.DataService
{
    public class ServiceArticulo//: IArticulo
    {
        // private TiendaDbContext _db = new TiendaDbContext();
        public ServiceArticulo()
        {
        }

        /// <summary>
        /// obtener el registro de un cliente por medio el codigo de cliente
        /// </summary>
        /// <param name="codigoBarra"></param>
        /// <param name="responseModel"></param>
        /// <returns></returns>
        public async Task<List<ViewModelArticulo>> ObtenerArticuloPorIdAsync(ResponseModel responseModel, string codigoBarra, string bodegaID, string nivelPrecio)
        {
            var Articulo = new List<ViewModelArticulo>();
            var consultaExitosa = false;

            try
            {
                using (SqlConnection cn = new SqlConnection(ConectionContext.GetConnectionSqlServer()))
                {
                    //Abrir la conección 
                    await cn.OpenAsync();
                    SqlCommand cmd = new SqlCommand($"{ConectionContext.Esquema}.SP_PrecioArticulos", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 0;
                    cmd.Parameters.AddWithValue("@CodigoBarra", codigoBarra);
                    cmd.Parameters.AddWithValue("@BodegaID", bodegaID);
                    cmd.Parameters.AddWithValue("@NivelPrecio", nivelPrecio);

                    var dr = await cmd.ExecuteReaderAsync();
                    while (await dr.ReadAsync())
                    {
                        consultaExitosa = true;
                        var _listArticulo = new ViewModelArticulo();

                        _listArticulo.ArticuloID = dr["ARTICULOID"].ToString();
                        _listArticulo.CodigoBarra = dr["CODIGOBARRA"].ToString();
                        _listArticulo.Descripcion = dr["DESCRIPCION"].ToString();
                        _listArticulo.Precio = Convert.ToDecimal(dr["PRECIO"]);
                        _listArticulo.UnidadVenta = dr["UNIDAD_VENTA"].ToString();
                        _listArticulo.UnidadFraccion = dr["UNIDAD_FRACCION"].ToString();
                        _listArticulo.BodegaID = dr["BODEGAID"].ToString();
                        _listArticulo.NombreBodega = dr["NOMBREBODEGA"].ToString();
                        _listArticulo.NivelPrecio = dr["NIVELPRECIO"].ToString();
                        _listArticulo.Existencia = Convert.ToDecimal(dr["EXISTENCIA"]);
                        _listArticulo.Moneda = Convert.ToChar(dr["MONEDA"]);
                        _listArticulo.Descuento = Convert.ToDecimal(dr["DESCUENTO"]);
                        _listArticulo.Cost_Prom_Dol = Convert.ToDecimal(dr["COSTO_PROM_DOL"]);
                        _listArticulo.Costo_Prom_Loc = Convert.ToDecimal(dr["COSTO_PROM_LOC"]);                                               
                       
                        _listArticulo.Lote = dr["LOTE"]?.ToString();
                        if (dr["FECHA_VENCIMIENTO"] != DBNull.Value)
                        {
                            _listArticulo.FechaVencimiento = Convert.ToDateTime(dr["FECHA_VENCIMIENTO"]);
                        }                            
                        _listArticulo.Localizacion = dr?["LOCALIZACION"].ToString();
                        _listArticulo.ExistenciaPorLote = Convert.ToDecimal(dr?["EXISTENCIA_POR_LOTE"]);                                                                  
                       _listArticulo.UsaLote = dr?["USA_LOTES"].ToString();

                        Articulo.Add(_listArticulo);
                    }
                }

                
                //verificar si la consulta fue exitosa
                if (consultaExitosa)
                {
                    //1 signinfica que la consulta fue exitosa
                    responseModel.Exito = 1;
                    responseModel.Mensaje = "Consulta exitosa";
                }
                else
                {
                    //0 signinfica que la consulta no se encontro en la base de datos
                    responseModel.Exito = 0;
                    responseModel.Mensaje = $"El articulo {codigoBarra} no existe en la base de datos";
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return Articulo;
        }

    }
}
