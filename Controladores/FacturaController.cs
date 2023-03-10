using Api.Model.Modelos;
using Api.Model.ViewModels;
using Api.Service.DataService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladores
{
    public class FacturaController
    {
        //declarar la interfaz
        //private readonly IFactura _serviceFactura;
        //private readonly IBodega _dataBodega;
        //private readonly IFormaPago _dataFormaPago;
        //private readonly IMoneda_Hist _dataMonedaHist;

        private ServiceFactura _serviceFactura = new ServiceFactura();
        private ServiceBodega _serviceBodega = new ServiceBodega();
        private ServiceFormaPago _serviceFormaPago = new ServiceFormaPago();
        private ServiceMoneda_Hist _serviceMonedaHist = new ServiceMoneda_Hist();
        

        public FacturaController()
        {
           
        }

        // GET: FacturaController
        //[HttpPost("ListarFacturas")]
        public async Task<ResponseModel> ListarFacturas(FiltroFactura filtroFactura)
        {
            ResponseModel responseModel = new ResponseModel();
            responseModel.Data = new List<Facturas>();

            try
            {
                responseModel.Data = await _serviceFactura.ListarFacturasAsync(filtroFactura, responseModel);
            }
            catch (Exception ex)
            {
                //0 para indicar que existe algun error en la consulta 
                responseModel.Exito = -1;
                //indicar el mensaje del error
                responseModel.Mensaje = ex.Message;
            }
            return responseModel;
        }

               

        public async Task<ResponseModel> CancelarNoFacturaBloqueada(string noFactura)
        {
            ResponseModel responseModel = new ResponseModel();
            
            try
            {
                 await _serviceFactura.CancelarNoFacturaBloqueada(responseModel, noFactura);
            }
            catch (Exception ex)
            {
                //0 para indicar que existe algun error en la consulta 
                responseModel.Exito = -1;
                //indicar el mensaje del error
                responseModel.Mensaje = ex.Message;
            }
            return responseModel;

        }

       // [HttpDelete("EliminarArticuloDetalleFacturaAsync/{noFactura}/{articulo}")]
        public async Task<ResponseModel> EliminarArticuloDetalleFacturaAsync(string noFactura, string articulo)
        {
            var responseModel = new ResponseModel();
            responseModel.Data = new Facturando();
            try
            {
                responseModel.Data = await _serviceFactura.EliminarFacturaTemporal(responseModel, noFactura, articulo);
            }
            catch (Exception ex)
            {
                //-1 indica que existe algun error del servidor
                responseModel.Exito = -1;
                responseModel.Mensaje = ex.Message;
            }

            return responseModel;
        }



        //[HttpGet("ObtenerNoFacturaAsync")]
        /*public async Task<ResponseModel> ObtenerNoFacturaAsync()
        {
            var responseModel = new ResponseModel();
            responseModel.Data = new object();

            try
            {
                responseModel.Data = await _serviceFactura.ObtenerNoFactura(responseModel);
            }
            catch (Exception ex)
            {
                //-1 indica que existe algun error del servidor
                responseModel.Exito = -1;
                responseModel.Mensaje = ex.Message;
            }

            return responseModel;
        }*/





       
    }
}


