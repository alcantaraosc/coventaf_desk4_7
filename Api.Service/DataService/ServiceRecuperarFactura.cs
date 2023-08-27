using Api.Context;
using Api.Model.Modelos;
using Api.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Service.DataService
{
    public class ServiceRecuperarFactura
    {
        //verificar si el numero de cierre y el numero de caja es el mismo
        //luego verificar si el numero de factura ya existe en la tabla factura, en caso que ya existe entonces generar un numero de factura
        //luego mostrar al cajero los articulo a recuperar
        
        //los estoy programando, la forma de recuperacion
        public async Task<ResponseModel> ExisteNumeroCierreCajero(ResponseModel responseModel)
        {
            var list = new List<Facturando>();

            try
            {
                using (TiendaDbContext _db = new TiendaDbContext())
                {
                    list = _db.Facturando.Where(cj => cj.Cajero == User.Usuario && cj.NumCierre == User.ConsecCierreCT).Take(2).ToList();
                    if (list.Count > 0)
                    {
                        responseModel.Exito = 1;
                        responseModel.Mensaje = "Consulta Exitosa";
                        responseModel.Data = list as List<Facturando>;
                    }
                    else
                    {
                        responseModel.Exito = 0;
                        responseModel.Mensaje = $"No hay factura de recuperacion";
                        responseModel.Data = null;
                    }
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
    
           
    }
}
