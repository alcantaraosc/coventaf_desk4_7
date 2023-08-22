using Api.Model.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Model.ViewModels
{
    public class ViewModelOrdenCompra
    {
        public Orden_Compras OrdenCompra { get; set; }
        public List<Detalle_Orden_Compra> DetalleOrdenCompra { get; set; }
        public List<Forma_Pagos> Forma_Pagos { get; set; }
        public List<Bodegas> Bodega { get; set; }
        public List<Proveedores> Proveedor { get; set; }
    }
}
