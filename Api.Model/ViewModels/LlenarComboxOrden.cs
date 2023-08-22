using Api.Model.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Model.ViewModels
{
    public class LlenarComboxOrden
    {
        public int Exito { get; set; }
        public string Mensaje { get; set; }
        public string OrdenCompra { get; set; }
        public decimal TipoDeCambio { get; set; }
        public List<Bodegas> Bodega { get; set; }
        public Globales_co Globales_Co { get; set; }
        public List<Proveedores> Proveedor { get; set; }       
        public List<Condicion_Pagos> CondicionPago { get; set; }
        public List<Monedas> Moneda { get; set; }
    }
}
