using Api.Context;
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
    public class ServiceDevolucion
    {
        private TiendaDbContext _db = new TiendaDbContext();

        public async Task<bool> facturaTieneDevolucion(string factura, ResponseModel responseModel)
        {
            bool existeDevolucion = false;
            var devolucion = new Facturas();
            try
            {
                devolucion = await _db.Facturas.Where(f => f.Factura_Original == factura && f.Tipo_Documento == "D").FirstOrDefaultAsync();
                if (devolucion != null)
                {
                    existeDevolucion = true;
                    responseModel.Exito = 0;
                    responseModel.Mensaje = $"Ya existe una devolucion para esta factura";
                }
                else
                {
                    existeDevolucion = false;
                    responseModel.Exito = 1;
                    responseModel.Mensaje = $"Esta factura no esta anulada";
                }
            }
            catch (Exception ex)
            {
                responseModel.Exito = -1;
                responseModel.Mensaje = $"Error SD0903231718: {ex.Message}";
                throw new Exception($"Error SD0903231718 facturaTieneDevolucion: {ex.Message}");
            }

            return existeDevolucion;
        }
        public async Task<bool> FacturaAnulada(string factura, ResponseModel responseModel)
        {
            bool existeFacturaAnulada = false;
            var facturaAnulada = new Facturas();
            try
            {
                facturaAnulada = await _db.Facturas.Where(f => f.Factura == factura && f.Anulada =="S" && f.Multiplicador_Ev ==-1).FirstOrDefaultAsync();
                if (facturaAnulada != null)
                {
                    existeFacturaAnulada = true;
                    responseModel.Exito = 0;
                    responseModel.Mensaje = $"No se puede hacer Devolucion, la factura {factura} está anulada";
                }
                else
                {
                    existeFacturaAnulada = false;
                    responseModel.Exito = 1;
                    responseModel.Mensaje = $"Esta factura no esta anulada";
                }
            }
            catch (Exception ex)
            {
                responseModel.Exito = -1;
                responseModel.Mensaje = $"Error SD0903231717: { ex.Message}";
                throw new Exception($"Error SD0903231717: {ex.Message}");
            }

            return existeFacturaAnulada;

        }

        public async Task<bool> EstadoCajaAbierto(string numCierre, ResponseModel responseModel)
        {
            bool cajaAbierta = false;
            var cierrePos = new Cierre_Pos();
            var cierraCaja = new Cierre_Caja();
            try
            {
                //Comprobar si el cajero y la caja ya esta cerrada con el numero de cierre.
                cierrePos = await _db.Database.SqlQuery<Cierre_Pos>($" SELECT CIERRE_POS.* FROM  TIENDA.CIERRE_POS INNER JOIN TIENDA.CIERRE_CAJA " +
                    $"ON TIENDA.CIERRE_POS.NUM_CIERRE_CAJA = TIENDA.CIERRE_CAJA.NUM_CIERRE_CAJA AND TIENDA.CIERRE_POS.CAJA = TIENDA.CIERRE_CAJA.CAJA " +
                    $"WHERE CIERRE_POS.NUM_CIERRE = '{numCierre}' AND CIERRE_POS.ESTADO ='C' AND CIERRE_CAJA.ESTADO ='C'").FirstOrDefaultAsync();
               
                //si tiene registro es xq la caja ya esta cerrada
                if (cierrePos != null)
                {
                    cajaAbierta = false;
                    responseModel.Exito = 1;
                    responseModel.Mensaje = $"Caja cerrada";
                }
                else 
                {
                    cajaAbierta = true;
                    responseModel.Exito = 0;
                    responseModel.Mensaje = $"No se puede hacer Devolucion, el numero de cierre de caja esta abierta";
                }               
            }
            catch (Exception ex)
            {
                responseModel.Exito = -1;
                responseModel.Mensaje = $"Error SD0903231715: {ex.Message}";
                throw new Exception($"Error SD0903231715: {ex.Message}");
            }

            return cajaAbierta;
        }

        public async Task<ResponseModel> BuscarFacturaPorNoFactura(string factura, string numeroCierre, ResponseModel responseModel)
        {
            var viewFactura = new ViewModelFacturacion();
            viewFactura.Factura = new Facturas();
            viewFactura.FacturaLinea = new List<Factura_Linea>();           
            var facturas = new Facturas();
            var factura_Linea = new List<Factura_Linea>();
            try
            {
                //verificar si la factura ya fue anulada
                if (await FacturaAnulada(factura, responseModel))
                {
                    return responseModel;
                }
                //verificar si la factura ya tiene devolucion
                else if (await facturaTieneDevolucion(factura, responseModel))
                {
                    return responseModel;
                }
                //verificar si el cierre aun esta abierto
                else if (await EstadoCajaAbierto(numeroCierre, responseModel))
                {
                    return responseModel;
                }
                else
                {                   
                    viewFactura.Factura = await _db.Facturas.Where(f => f.Factura == factura && f.Tipo_Documento == "F").FirstOrDefaultAsync();
                    viewFactura.FacturaLinea = await _db.Factura_Linea.Where(f => f.Factura == factura && f.Tipo_Documento == "F").ToListAsync();
                   
                    //verificar si factura y factura linea tienen registro
                    if(viewFactura.Factura != null  && viewFactura.FacturaLinea.Count >0)
                    {
                        responseModel.Exito = 1;
                        responseModel.Mensaje = "Consulta Exitosa";
                        responseModel.Data = viewFactura as ViewModelFacturacion;
                    }
                    else if (viewFactura.Factura == null && viewFactura.FacturaLinea.Count == 0)
                    {
                        responseModel.Exito = 0;
                        responseModel.Mensaje = "No existe la factura en la base de dato";
                    }
                    else if (viewFactura.Factura == null && viewFactura.FacturaLinea.Count > 0)
                    {
                        responseModel.Exito = 0;
                        responseModel.Mensaje = "El registro de la factura esta incompleto";
                    }
                    else
                    {
                        responseModel.Exito = 0;
                        responseModel.Mensaje = "El sistema detecto que el registro está incompleta";
                    }            
                }
            }
            catch (Exception ex)
            {
                responseModel.Exito = -1;
                responseModel.Mensaje = $"Error SD0903231721: {ex.Message}";
                throw new Exception($"Error SD0903231721: {ex.Message}");
            }

            return responseModel;

        }

  

        public async Task<ResponseModel> GuardarDevolucion(ViewModelFacturacion _devolucion, ResponseModel responseModel)
        {
            var result = 0;
            try
            {
                //model.Fecha = DateTime.Now.Date;
                using (SqlConnection cn = new SqlConnection(ADONET.strConnect))
                {
                    //Abrir la conección 
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("SP_GuardarDevolucion", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 0;

                        cmd.Parameters.AddWithValue("@Factura", _devolucion.Factura.Factura);                        
                        cmd.Parameters.AddWithValue("@TipoDocumento", "D");
                        cmd.Parameters.AddWithValue("@Caja", _devolucion.Factura.Caja);
                        cmd.Parameters.AddWithValue("@Cajero", _devolucion.Factura.Usuario);
                        cmd.Parameters.AddWithValue("@NumCierre", _devolucion.Factura.Num_Cierre);
                        cmd.Parameters.AddWithValue("@Observaciones", _devolucion.Factura.Observaciones);
                        cmd.Parameters.AddWithValue("@TotalFacturaDevuelta", _devolucion.Factura.Total_Factura);                        
                        //Monto_Descuento1= monto del Descuento General 5%
                        cmd.Parameters.AddWithValue("@Monto_Descuento1", _devolucion.Factura.Monto_Descuento1);
                        cmd.Parameters.AddWithValue("@Total_Mercaderia", _devolucion.Factura.Total_Mercaderia);
                        cmd.Parameters.AddWithValue("@Total_Unidades", _devolucion.Factura.Total_Unidades);
                        cmd.Parameters.AddWithValue("@Tipo_Original", _devolucion.Factura.Tipo_Original);


                        var dt = new DataTable();
                        dt.Columns.Add("ArticuloId", typeof(string));
                        dt.Columns.Add("BodegaId", typeof(string));
                        dt.Columns.Add("CantidadDevolver", typeof(decimal));                        
                        dt.Columns.Add("Desc_Tot_Linea_Dev", typeof(decimal));
                        dt.Columns.Add("Costo_Total_Dolar_Dev", typeof(decimal));
                        dt.Columns.Add("Costo_Total_Dev", typeof(decimal));
                        dt.Columns.Add("Costo_Total_Local_Dev", typeof(decimal));
                        dt.Columns.Add("Costo_Total_Comp_Dev", typeof(decimal));
                        dt.Columns.Add("Costo_Total_Comp_Local_Dev", typeof(decimal));
                        dt.Columns.Add("Costo_Total_Comp_Dolar_Dev", typeof(decimal));                         
                        dt.Columns.Add("Precio_Total_Dev", typeof(decimal));                        
                        dt.Columns.Add("Desc_Tot_General_Dev", typeof(decimal));


                        foreach (var item in _devolucion.FacturaLinea)
                        {
                            dt.Rows.Add(item.Articulo, item.Bodega, item.Cantidad_Devuelt, 
                                
                                item.Desc_Tot_Linea,
                                item.Costo_Total_Dolar, 
                                item.Costo_Total,
                                item.Costo_Total_Local, 
                                item.Costo_Total_Comp, 
                                item.Costo_Total_Comp_Local, 
                                item.Costo_Total_Comp_Dolar,
                                item.Precio_Total,
                                item.Desc_Tot_General);
                        }

                        var parametro = cmd.Parameters.AddWithValue("@DevolucionArticulos", dt);
                        parametro.SqlDbType = SqlDbType.Structured;

                        result = await cmd.ExecuteNonQueryAsync();

                    }
                }

                if (result > 0)
                {
                    responseModel.Exito = 1;
                    responseModel.Mensaje = $"La Devolcion se realizó exitosamente";
                }
                else
                {
                    responseModel.Exito = 0;
                    responseModel.Mensaje = $"El cierre no se pudo realizar";
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
