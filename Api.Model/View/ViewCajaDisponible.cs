
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Model.View
{
    public class ViewCajaDisponible
    {
        public string Caja { get; set; }
        public string Ubicacion { get; set; }
        public string Sucursal { get; set; }
        public string Bodega { get; set; }



        //SELECT TIENDA.CAJA_POS.CAJA, TIENDA.CAJA_POS.CODIGO_CORTO, TIENDA.CAJA_POS.SUCURSAL, TIENDA.CAJA_POS.BODEGA, TIENDA.CAJA_POS.UBICACION +' (' + TIENDA.CAJA_POS.CAJA +')' AS UBICACION, TIENDA.CAJA_POS.ASIGNADO, TIENDA.CAJA_POS.IDENTIFICADOR,
        //                 TIENDA.CAJA_POS.CENTRO_COSTO, TIENDA.CAJA_POS.CONS_CIERRE_CAJA, TIENDA.CAJA_POS.CONSEC_DOC_ESPERA, TIENDA.CAJA_POS.ESTADO, TIENDA.CAJA_POS.FIRMA, TIENDA.CAJA_POS.NoteExistsFlag,
        //                 TIENDA.CAJA_POS.RecordDate, TIENDA.CAJA_POS.RowPointer, TIENDA.CAJA_POS.CreatedBy, TIENDA.CAJA_POS.UpdatedBy, TIENDA.CAJA_POS.CreateDate, TIENDA.CAJA_POS.ACTIVIDAD_COMERCIAL
    }
}
