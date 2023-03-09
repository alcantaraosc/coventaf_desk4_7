using Api.Context;
using Api.Model.Modelos;
using Api.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
            bool result = false;
            var facturas = new Facturas();
            var factura_Linea = new List<Factura_Linea>();
            try
            {
                //verificar si la factura ya fue anulada
                if (await FacturaAnulada(factura, responseModel))
                {
                    result = true;
                }
                //verificar si la factura ya tiene devolucion
                else if (await facturaTieneDevolucion(factura, responseModel))
                {
                    result = true;
                }
                //verificar si el cierre aun esta abierto
                else if (await EstadoCajaAbierto(numeroCierre, responseModel))
                {
                    result = true;
                }
                else
                {
                    result = false;
                    viewFactura.Factura = await _db.Facturas.Where(f => f.Factura == factura && f.Tipo_Documento == "F").FirstOrDefaultAsync();
                    viewFactura.FacturaLinea = await _db.Factura_Linea.Where(f => f.Factura == factura && f.Tipo_Documento == "F").ToListAsync();
                   
                    //verificar si factura y factura linea tienen registro
                    if(viewFactura.Factura != null  && viewFactura.FacturaLinea.Count >0)
                    {
                        responseModel.Exito = 1;
                        responseModel.Mensaje = "Consulta Exitosa";
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
                        responseModel.Mensaje = "El sistema detecto que el registro esta completa";
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
    }
}
