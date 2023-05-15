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
    public class ServiceDocumento_Pos
    {


        public async Task<ListarDatosFactura> ObtenerConsecutivoRecibo(string caja, ListarDatosFactura listarDatosFactura)
        {
            var consec_Caja_Pos = new Consec_Caja_Pos();
            try
            {
                using (TiendaDbContext _db = new TiendaDbContext())
                {
                    //mostrar la bodega que este activo y q sea de Tipo Venta(V) y que sea de la tienda
                    consec_Caja_Pos = await _db.Consec_Caja_Pos.Where(ccp => ccp.Tipo_Documento == "R" && ccp.Activo == "S" && ccp.Caja == caja).FirstOrDefaultAsync();
                }

                if (consec_Caja_Pos != null)
                {
                    listarDatosFactura.Exito = 1;
                    listarDatosFactura.Mensaje = "Consulta exitosa";
                    listarDatosFactura.NoFactura = consec_Caja_Pos.Valor;
                }
                else
                {
                    listarDatosFactura.Exito = 0;
                    listarDatosFactura.Mensaje = $"No hay consecutivo de recibo para la caja {caja}";
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return listarDatosFactura;
        }

        /*
        public async Task<ListarDatosFactura> ObtenerConsecutivoRecibo(string caja, ListarDatosFactura listarDatosFactura)
        {
            var consec_Caja_Pos = new List<Documento_Pos>();
            try
            {
                using (TiendaDbContext _db = new TiendaDbContext())
                {
                    //mostrar la bodega que este activo y q sea de Tipo Venta(V) y que sea de la tienda
                    consec_Caja_Pos = await _db.Documento_Pos.Where(ccp => ccp.Cajero == "GERNESTO").ToListAsync();
                }

              
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return listarDatosFactura;
        }
        */



        public async Task<ListarDatosFactura> ListarInformacionInicioRecibo()
        {

            var listarDatosFactura = new ListarDatosFactura();
            listarDatosFactura.tipoDeCambio = 0;           
            listarDatosFactura.NoFactura = "";

            try
            {

                //obtener el tipo de cambio 
                listarDatosFactura = await new ServiceFactura().ObtenerTipoCambioDelDiaAsync(listarDatosFactura);
                //si la respuesta del servidor es diferente a 1 (1 es exitoso, cualquiere otro numero significa que hubo algun problema)
                if (listarDatosFactura.Exito != 1) return listarDatosFactura;
                               
                //obtener el siguiente numero de factura
                listarDatosFactura = await ObtenerConsecutivoRecibo(User.Caja, listarDatosFactura);
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

            return listarDatosFactura;
        }

    }
}
