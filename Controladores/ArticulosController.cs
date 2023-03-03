using Api.Model.View;
using Api.Model.ViewModels;
using Api.Service.DataService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladores
{
    public class ArticulosController
    {
        private ServiceArticulo _serviceArticulo =new ServiceArticulo();

        //aplicando inyeccion 
        public ArticulosController()
        {
            
        }


        //[HttpGet("ObtenerArticuloPorIdAsync/{codigoBarra}/{bodegaID}")]
        public async Task<ResponseModel> ObtenerArticuloPorIdAsync(string codigoBarra, string bodegaID, string NivelPrecio)
        {
            var responseModel = new ResponseModel();
            responseModel.Data = new ViewModelArticulo();
            try
            {
                //llamar al metodo ObtenerArticuloPorIdAsync para obtener el registro del articulo
                responseModel.Data = await _serviceArticulo.ObtenerArticuloPorIdAsync(responseModel, codigoBarra, bodegaID, NivelPrecio);
            }
            catch (Exception ex)
            {
                //-1 significa que existe un error
                responseModel.Exito = -1;
                responseModel.Mensaje = ex.Message;
            }

            return responseModel;
        }




    }

}
