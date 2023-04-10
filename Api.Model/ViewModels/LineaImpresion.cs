using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Model.ViewModels
{
    public class LineaImpresion
    {
        public string Linea { get; set; }
        public int PosX { get; set; }
        public int PosY { get; set; }
        //este campo me indica si la siguiente linea existe o es la ultima;
        public bool TieneMasLinea { get; set; } = true;
    }
}
