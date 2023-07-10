using Api.Model.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Model.ViewModels
{
    public class ViewModelVisita
    {
        public Cs_Bitacora_Visita cs_Bitacora_Visita { get; set; }
        public List<Cs_Acompanante> cs_Acompanante { get; set; }
    }
}
