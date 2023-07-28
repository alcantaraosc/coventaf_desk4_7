using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Model.ViewModels
{
    public class ListaCliente
    {       
        public string Cliente { get; set; }
        public string Nombre { get; set; }
        public string Cedula { get; set; }
        public string Identidad { get; set; }        
        public string Grado { get; set; }
        public string NumeroUnico { get; set; }
        public string Procedencia { get; set; }
        public string UnidadMilitar { get; set; }
        public string Autoriza { get; set; }
        public string Nota { get; set; }
        public DateTime? FechaVencimiento { get; set; }

        public string Parentesco { get; set; }
        public string Sexo { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string Edad { get; set; }
        public DateTime FechaVisita { get; set; }
        public int NumeroVisita { get; set; }
    
        public string Titular { get; set; }
        public DateTime? FechaUltIngreso { get; set; }
        public int CantidadVisita { get; set; }

        public string NombreTitular { get; set; }

        public string MensajeVencido { get; set; }
        public string VencidoID { get; set; }
        


    }
}
