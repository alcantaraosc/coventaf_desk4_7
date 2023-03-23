﻿using Api.Model.ViewModels;
using System;
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
        public async Task<ViewModelArticulo> ObtenerArticuloPorIdAsync(ResponseModel responseModel, string codigoBarra, string bodegaID, string nivelPrecio)
        {
            var Articulo = new ViewModelArticulo();
            var consultaExitosa = false;

            try
            {
                using (SqlConnection cn = new SqlConnection(ADONET.strConnect))
                {
                    //Abrir la conección 
                    await cn.OpenAsync();
                    SqlCommand cmd = new SqlCommand("SP_PrecioArticulos", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 0;
                    cmd.Parameters.AddWithValue("@CodigoBarra", codigoBarra);
                    cmd.Parameters.AddWithValue("@BodegaID", bodegaID);
                    cmd.Parameters.AddWithValue("@NivelPrecio", nivelPrecio);


                    var dr = await cmd.ExecuteReaderAsync();
                    if (await dr.ReadAsync())
                    {
                        consultaExitosa = true;
                        Articulo.ArticuloID = dr["ARTICULOID"].ToString();
                        Articulo.CodigoBarra = dr["CODIGOBARRA"].ToString();
                        Articulo.Descripcion = dr["DESCRIPCION"].ToString();
                        Articulo.Precio = Convert.ToDecimal(dr["PRECIO"]);
                        Articulo.UnidadVenta = dr["UNIDAD_VENTA"].ToString();
                        Articulo.UnidadFraccion = dr["UNIDAD_FRACCION"].ToString();
                        Articulo.BodegaID = dr["BODEGAID"].ToString();
                        Articulo.NombreBodega = dr["NOMBREBODEGA"].ToString();
                        Articulo.NivelPrecio = dr["NIVELPRECIO"].ToString();
                        Articulo.Existencia = Convert.ToDecimal(dr["EXISTENCIA"]);
                        Articulo.Moneda = Convert.ToChar(dr["MONEDA"]);
                        Articulo.Descuento = Convert.ToDecimal(dr["DESCUENTO"]);
                        Articulo.Cost_Prom_Dol = Convert.ToDecimal(dr["COSTO_PROM_DOL"]);
                        Articulo.Costo_Prom_Loc = Convert.ToDecimal(dr["COSTO_PROM_LOC"]);
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
