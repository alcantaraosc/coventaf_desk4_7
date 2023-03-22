using Api.Model.Modelos;
using Api.Model.ViewModels;
using Api.Service.DataService;
using System;
using System.Threading.Tasks;

namespace Controladores
{
    public class MonedaHistController
    {
        private readonly ServiceMoneda_Hist _serviceMoneda_Hist = new ServiceMoneda_Hist();

        public MonedaHistController()
        {
        }


        //[HttpGet("ObtenerTipoCambioDelDiaAsync")]
        public async Task<ResponseModel> ObtenerTipoCambioDelDiaAsync()
        {
            var responseModel = new ResponseModel();
            responseModel.Data = new Moneda_Hist();
            try
            {
                responseModel.Data = await _serviceMoneda_Hist.ObtenerTipoCambioDelDiaAsync(responseModel);
            }
            catch (Exception ex)
            {
                responseModel.Exito = -1;
                responseModel.Mensaje = ex.Message;
            }

            return responseModel;

        }
    }
}
