using Api.Model.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Model.ViewModels
{
    public class ViewModelFactura_Documento
    {
        public Documento_Pos Documento_Pos { get; set; }
        public List<Doc_Pos_Linea> Doc_Pos_Linea { get; set; }
        public Facturas Facturas { get; set; }
        public List<Factura_Linea> Factura_Linea { get; set; }
    }
}
