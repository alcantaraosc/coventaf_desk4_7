using Api.Model.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Model.ViewModels
{
    public class ViewModelCierre
    {
        public List<Cierre_Det_Pago> Cierre_Det_Pago { get; set; }
        public Cierre_Pos Cierre_Pos { get; set; }
        public List<Cierre_Desg_Tarj> Cierre_Desg_Tarj { get; set; }
        public List<DetalleFacturaCierreCaja> DetalleFacturaCierreCaja { get; set; }
    }
}
