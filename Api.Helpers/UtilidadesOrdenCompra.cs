using Api.Model.Modelos;
using Api.Model.ViewModels;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Api.Helpers
{
    public static class UtilidadesOrdenCompra
    {
        public static bool ExistenCantidadesPrecio_Cero(List<DetalleListOrdenCompra> detalleOrdeCompra)
        {
            var existe = false;
            foreach (var item in detalleOrdeCompra)
            {
                
                if (item.Cantidad == 0)
                {
                    existe = true;
                    MessageBox.Show("La cantidad del articulo no puede ser cero", "Sistema COVENTAF");
                    break;
                }
                else if (item.Precio == 0)
                {
                    existe = true;
                    MessageBox.Show("El Precio del articulo no puede ser cero", "Sistema COVENTAF");
                    break;
                }
            }

            return existe;
        }

        private static void RecopilarLineaOrdenCompraAlEditar(List<Detalle_Orden_Compra> listOrdenCompra, List<DetalleListOrdenCompra> detalleOrdeCompra, string ordenCompra, string bodega)
        {

            foreach (var itemDetalle in detalleOrdeCompra)
            {
                //si es un nuevo registro
                if (itemDetalle.Nuevo)
                {
                    var datoOrdComp = new Detalle_Orden_Compra();
                    //agregar a la lista la nueva linea de la orden de compra
                    AsignarLineaOrdenCompra(datoOrdComp, itemDetalle, ordenCompra, bodega);
                    //agregar a la lista la nueva linea de la orden de compra
                    listOrdenCompra.Add(datoOrdComp);
                }
                else
                {
                    var lineaOrdeCompra = listOrdenCompra.Where(x => x.Linea == itemDetalle.Linea).FirstOrDefault();
                    //asignar la la linea de la orden de compra
                    AsignarLineaOrdenCompra(lineaOrdeCompra, itemDetalle, ordenCompra, bodega);
                }
            }
        }

        private static void AsignarLineaOrdenCompra(Detalle_Orden_Compra datoDetOrdComp, DetalleListOrdenCompra itemDetalleLinea, string ordenCompra, string bodega)
        {           
            datoDetOrdComp.Orden_Compra = ordenCompra;
            datoDetOrdComp.Linea = itemDetalleLinea.Linea;
            datoDetOrdComp.Articulo = itemDetalleLinea.ArticuloId;
            datoDetOrdComp.Codigo_Barra = itemDetalleLinea.CodigoBarra;
            datoDetOrdComp.Descripcion = itemDetalleLinea.Descripcion;
            datoDetOrdComp.Cantidad_Orden = itemDetalleLinea.Cantidad;
            datoDetOrdComp.Precio = itemDetalleLinea.Precio;      
            datoDetOrdComp.Porcentaje_Desc = itemDetalleLinea.PorcentajeDescuento;
            datoDetOrdComp.Porcentajae_Isc = itemDetalleLinea.PorcentajeISC;
            datoDetOrdComp.Porcentaje_Iva = itemDetalleLinea.PorcentajeIVA;
            datoDetOrdComp.Monto_Desc = itemDetalleLinea.MontoDesc;
            datoDetOrdComp.Monto_Isc = itemDetalleLinea.MontoISC;
            datoDetOrdComp.Monto_Iva = itemDetalleLinea.MontoIVA;
            datoDetOrdComp.Costo = itemDetalleLinea.CostoIVA;
            datoDetOrdComp.Nuevo = itemDetalleLinea.Nuevo;
        }

        public static ViewModelOrdenCompra RecolectarOrdeCompra(ViewModelOrdenCompra modelOrdenCompra, List<DetalleListOrdenCompra> detalleOrdeCompra, string ordenCompra,
                                                                string proveedor, string bodega, string condicionPago, string nota, 
                                                                decimal subTotal, decimal montoDescuento, decimal montoISC, decimal montoIVA, 
                                                                decimal Total, decimal totalItem, decimal totalUnidades, DateTime fechaPedido, DateTime fechaEntrega, bool editOrdenCompra)
        {

            modelOrdenCompra.OrdenCompra.Orden_Compra = ordenCompra;
            modelOrdenCompra.OrdenCompra.Usuario = User.Usuario;
            modelOrdenCompra.OrdenCompra.Proveedor = proveedor;
            modelOrdenCompra.OrdenCompra.Bodega = bodega;
            
            modelOrdenCompra.OrdenCompra.Condicion_Pago = condicionPago;
            modelOrdenCompra.OrdenCompra.Nota = nota;
            modelOrdenCompra.OrdenCompra.Fecha_Pedido = fechaPedido;
            modelOrdenCompra.OrdenCompra.Fecha_Entrega = fechaEntrega;
            modelOrdenCompra.OrdenCompra.Sub_Total = subTotal;
                    
            modelOrdenCompra.OrdenCompra.Usuario_Edita = editOrdenCompra ? User.Usuario : null;
            modelOrdenCompra.OrdenCompra.Monto_Desc = montoDescuento;
            modelOrdenCompra.OrdenCompra.Monto_ISC = montoISC;
            modelOrdenCompra.OrdenCompra.Monto_IVA = montoIVA;
            modelOrdenCompra.OrdenCompra.Monto_Total = Total;
            modelOrdenCompra.OrdenCompra.Total_Item = totalItem;
            modelOrdenCompra.OrdenCompra.Total_Unidades = totalUnidades;

            modelOrdenCompra.OrdenCompra.Usuario = editOrdenCompra ? modelOrdenCompra.OrdenCompra.Usuario : User.Usuario;

            //
            foreach (var itemDetalle in detalleOrdeCompra)
            {
                var detOrdenCompra = detalleOrdeCompra.Where(x => x.Linea == itemDetalle.Linea).FirstOrDefault();
                var datoOrdComp = new Detalle_Orden_Compra() 
                {
                    Orden_Compra = ordenCompra,
                Linea = itemDetalle.Linea,
                Articulo = itemDetalle.ArticuloId,
                Codigo_Barra = itemDetalle.CodigoBarra,
                Descripcion = itemDetalle.Descripcion,
                Cantidad_Orden = itemDetalle.Cantidad,
                Precio = itemDetalle.Precio,

                Porcentaje_Desc = itemDetalle.PorcentajeDescuento,
                Porcentajae_Isc = itemDetalle.PorcentajeISC,
                Porcentaje_Iva = itemDetalle.PorcentajeIVA,
                Monto_Desc = itemDetalle.MontoDesc,
                Monto_Isc = itemDetalle.MontoISC,
                Monto_Iva = itemDetalle.MontoIVA,
                Costo = itemDetalle.CostoIVA,
                Nuevo = itemDetalle.Nuevo,
            };

                //agregar a la lista la nueva linea de la orden de compra
                //AsignarLineaOrdenCompra(datoOrdComp, detOrdenCompra, ordenCompra, bodega);
                      
                modelOrdenCompra.DetalleOrdenCompra.Add(datoOrdComp);
            }


            ////si estas editando la orden de compra
            //if (editOrdenCompra)
            //{
            //    //recopilar los datos de la orden de compra cuando se esta editando
            //    RecopilarLineaOrdenCompraAlEditar(modelOrdenCompra.DetalleOrdenCompra, detalleOrdeCompra, ordenCompra, bodega);
            //}
            //else
            //{
            //    //este caso 
            //    foreach (var itemDetalle in detalleOrdeCompra)
            //    {
            //        var detOrdenCompra = detalleOrdeCompra.Where(x => x.Linea == itemDetalle.Linea).FirstOrDefault();
            //        var datoOrdComp = new Detalle_Orden_Compra();

            //        //agregar a la lista la nueva linea de la orden de compra
            //        AsignarLineaOrdenCompra(datoOrdComp, detOrdenCompra, ordenCompra, bodega);
            //        modelOrdenCompra.DetalleOrdenCompra.Add(datoOrdComp);
            //    }
            //}

            return modelOrdenCompra;
        }



        public static void RedefinirConsecutivoLinea(List<DetalleListOrdenCompra> detalleOrdeCompra, DataGridView dgvDetalleCompra)
        {           
            int rows = 0;
            foreach (var ordenDetalle in detalleOrdeCompra)
            {
                //actualizar el consecutivo de la lista
                ordenDetalle.Consecutivo = rows;
                ordenDetalle.Linea = rows + 1;
                dgvDetalleCompra.Rows[rows].Cells["Linea"].Value = ordenDetalle.Linea.ToString();

                dgvDetalleCompra.Rows[rows].Cells["Consecutivo"].Value = ordenDetalle.Consecutivo.ToString();
                rows += 1;
            }
        }

        public static void EliminarLineaOrdenCompra(List<DetalleListOrdenCompra> detalleOrdeCompra, DataGridView dgvDetalleCompra)
        {
            dgvDetalleCompra.CurrentCell = dgvDetalleCompra[7, 0];            

            int rows = 0;
            while (rows < dgvDetalleCompra.RowCount)
            {
                //verificar si la fila tiene el check
                if ( Convert.ToBoolean(dgvDetalleCompra.Rows[rows].Cells["Seleccionar"].Value))
                {
                    var consecutivo = rows;
                    //eliminar el registro de la lista.
                    detalleOrdeCompra.RemoveAt(consecutivo);
                    //eliminar el registro del grid
                    dgvDetalleCompra.Rows.RemoveAt(consecutivo);

                    //llamar al metodo para redefinir el consecutivo                   
                    RedefinirConsecutivoLinea(detalleOrdeCompra, dgvDetalleCompra);
                    rows = 0;
                }
                else
                {
                    rows += 1;
                }
            }
        }

        public static void EliminarOrdenCompraAlSerNuevo(string articuloId, int consecutivo, List<DetalleListOrdenCompra> detalleOrdeCompra, DataGridView dgvDetalleCompra)
        {
           
            //eliminar el registro de la lista.
            detalleOrdeCompra.RemoveAt(consecutivo);
            //eliminar el registro del grid
            dgvDetalleCompra.Rows.RemoveAt(consecutivo);

            int rows = 0;

            foreach (var ordenDetalle in detalleOrdeCompra)
            {
                //actualizar el consecutivo de la lista
                ordenDetalle.Consecutivo = rows;
                ordenDetalle.Linea = rows + 1;
                dgvDetalleCompra.Rows[rows].Cells["Linea"].Value = ordenDetalle.Linea.ToString();

                dgvDetalleCompra.Rows[rows].Cells["Consecutivo"].Value = ordenDetalle.Consecutivo.ToString();

                rows += 1;
            }
        }

        public static void EliminarOrdenCompraAlEditar(string articuloId, int consecutivo, List<DetalleListOrdenCompra> detalleOrdeCompra, DataGridView dgvDetalleCompra, List<Detalle_Orden_Compra> OrdenCompraLinea)
        {

            //obtener la linea del articulo a eliminar
            var lineaArticulo = detalleOrdeCompra.Where(x => x.Consecutivo == consecutivo).Select(x => x.Linea).FirstOrDefault();
            //obtener la linea a eliminar
            var lineaOrdenCompra = OrdenCompraLinea.Where(ocl => ocl.Linea == lineaArticulo && ocl.Articulo == articuloId).FirstOrDefault();
            //eliminar la orden de la lista
            OrdenCompraLinea.Remove(lineaOrdenCompra);

            //eliminar el registro de la lista.
            detalleOrdeCompra.RemoveAt(consecutivo);
            //eliminar el registro del grid
            dgvDetalleCompra.Rows.RemoveAt(consecutivo);

            int rows = 0;
            int lineaAux = 1;
            foreach (var itemOrdenCompra in detalleOrdeCompra)
            {               
                //actualizar el consecutivo de la lista
                itemOrdenCompra.Consecutivo = rows;
                //si no estas editando la orden de compras entonces reorganizar el consecutivo
                if (itemOrdenCompra.Nuevo)
                {
                    itemOrdenCompra.Linea = lineaAux + 1;
                    dgvDetalleCompra.Rows[rows].Cells["Linea"].Value = itemOrdenCompra.Linea.ToString();
                }
                dgvDetalleCompra.Rows[rows].Cells["Consecutivo"].Value = itemOrdenCompra.Consecutivo.ToString();

                rows += 1;
                //guardar la ultima linea
                lineaAux = itemOrdenCompra.Linea;
            }
        }

        public static void CopiarOrdenCompra(ViewModelOrdenCompra copyModel, ViewModelOrdenCompra model)
        {
            copyModel.OrdenCompra.Orden_Compra = model.OrdenCompra.Orden_Compra;
            copyModel.OrdenCompra.Usuario = model.OrdenCompra.Usuario;
            copyModel.OrdenCompra.Fecha_Registro = model.OrdenCompra.Fecha_Registro;
            copyModel.OrdenCompra.Proveedor = model.OrdenCompra.Proveedor;
            copyModel.OrdenCompra.Bodega = model.OrdenCompra.Bodega;            
            copyModel.OrdenCompra.Condicion_Pago = model.OrdenCompra.Condicion_Pago;
            copyModel.OrdenCompra.Nota = model.OrdenCompra.Nota;
            copyModel.OrdenCompra.Fecha_Pedido = model.OrdenCompra.Fecha_Pedido;
            copyModel.OrdenCompra.Fecha_Entrega = model.OrdenCompra.Fecha_Entrega;
            copyModel.OrdenCompra.Sub_Total = model.OrdenCompra.Sub_Total;            
            copyModel.OrdenCompra.Monto_Desc = model.OrdenCompra.Monto_Desc;
            copyModel.OrdenCompra.Monto_ISC = model.OrdenCompra.Monto_ISC;
            copyModel.OrdenCompra.Monto_IVA = model.OrdenCompra.Monto_IVA;
            copyModel.OrdenCompra.Monto_Total = model.OrdenCompra.Monto_Total;            
            copyModel.OrdenCompra.Total_Item = model.OrdenCompra.Total_Item;
            copyModel.OrdenCompra.Total_Unidades = model.OrdenCompra.Total_Unidades;
            copyModel.OrdenCompra.Usuario_Edita = model.OrdenCompra.Usuario_Edita;
            copyModel.OrdenCompra.Fecha_Edita = model.OrdenCompra.Fecha_Edita;



            foreach (var item in model.DetalleOrdenCompra)
            {
                var dataLinea = new Detalle_Orden_Compra()
                {
                    Orden_Compra = item.Orden_Compra,
                    Linea = item.Linea,
                    Articulo = item.Articulo,
                    Codigo_Barra = item.Codigo_Barra,
                    Descripcion = item.Descripcion,
                    Cantidad_Orden = item.Cantidad_Orden,
                    Precio = item.Precio,
                    Porcentaje_Desc = item.Porcentaje_Desc,
                    Porcentajae_Isc = item.Porcentajae_Isc,
                    Porcentaje_Iva = item.Porcentaje_Iva,
                    Monto_Desc = item.Monto_Desc,
                    Monto_Isc = item.Monto_Isc,
                    Monto_Iva = item.Monto_Iva,
                    Costo = item.Costo,
                    Total_Linea = item.Total_Linea,
                    Usuario = item.Usuario,
                    Fecha_Registro = item.Fecha_Registro,
                    Usuario_Edita = item.Usuario_Edita,
                    Fecha_Edita = item.Fecha_Edita
                };

                copyModel.DetalleOrdenCompra.Add(dataLinea);
            }
        }


        public static bool IsInValidoInputGrid(string valor, string nombreCampo)
        {
            bool valido = true;

            if (valor.Trim().Length ==0)
            {
                XtraMessageBox.Show($" {nombreCampo} no debe estar vacio", "Sistema COVENTAF",  MessageBoxButtons.OK);
            }
            else if (Utilidades.TieneLetra(valor))
            {
                MessageBox.Show($" {nombreCampo} solo debe ser numero", "Sistema COVENTAF");
            }
            else if(Convert.ToDecimal(valor) < 0)
            {
                MessageBox.Show($" {nombreCampo} debe ser un numero positivo", "Sistema COVENTAF");
            }
            else
            {
                valido = false;
            }

            return valido;
        }

        public static void ValidarGridOrdenCompra(int rowsGrid, int columnaIndex, DataGridView dgvDetalleOrden)
        {
            //verificar que los consecutivoActualFactura y columnaIndex no tenga
            if (rowsGrid != -1 && columnaIndex != -1)
            {              
                switch (columnaIndex)
                {                     
                    //columna Cantidad    
                    case 7:                        
                        string cantidad = dgvDetalleOrden.Rows[rowsGrid].Cells["Cantidad"].Value == null ? "" : dgvDetalleOrden.Rows[rowsGrid].Cells["Cantidad"].Value.ToString();                      
                        //si es invalido el valor de entrada
                        if(IsInValidoInputGrid(cantidad, "Cantidad"))
                        {
                            dgvDetalleOrden.Rows[rowsGrid].Cells["Cantidad"].Value = "0";
                        }
                        break;

                        //precio
                    case 8:
                        string precio = dgvDetalleOrden.Rows[rowsGrid].Cells["Precio"].Value == null ? "" : dgvDetalleOrden.Rows[rowsGrid].Cells["Precio"].Value.ToString();
                        //si es invalido el valor de entrada
                        if (IsInValidoInputGrid(precio, "Precio"))
                        {
                            dgvDetalleOrden.Rows[rowsGrid].Cells["Precio"].Value = "0";
                        }
                        break;

                    //descuento %
                    case 10:
                        string descuento = dgvDetalleOrden.Rows[rowsGrid].Cells["PorcentajeDescuento"].Value == null ? "" : dgvDetalleOrden.Rows[rowsGrid].Cells["PorcentajeDescuento"].Value.ToString();
                        //si es invalido el valor de entrada
                        if (IsInValidoInputGrid(descuento, "Descuento"))
                        {
                            dgvDetalleOrden.Rows[rowsGrid].Cells["PorcentajeDescuento"].Value = "0";
                        }
                        break;

                    //isc %
                    case 11:
                        string ISC = dgvDetalleOrden.Rows[rowsGrid].Cells["PorcentajeISC"].Value == null ? "" : dgvDetalleOrden.Rows[rowsGrid].Cells["PorcentajeISC"].Value.ToString();
                        //si es invalido el valor de entrada
                        if (IsInValidoInputGrid(ISC, "Descuento ISC"))
                        {
                            dgvDetalleOrden.Rows[rowsGrid].Cells["PorcentajeISC"].Value = "0";
                        }
                        break;

                    //IVA %
                    case 12:
                        string IVA = dgvDetalleOrden.Rows[rowsGrid].Cells["PorcentajaIVA"].Value == null ? "" : dgvDetalleOrden.Rows[rowsGrid].Cells["PorcentajaIVA"].Value.ToString();
                        //si es invalido el valor de entrada
                        if (IsInValidoInputGrid(IVA, "Descuento ISC"))
                        {
                            dgvDetalleOrden.Rows[rowsGrid].Cells["PorcentajaIVA"].Value = "0";
                        }
                        break;
                }

            }
        }

        public static void ValidarGridRecepcionOrdenCompra(int rowsGrid, int columnaIndex, DataGridView dgvDetalleOrden)
        {
            //verificar que los consecutivoActualFactura y columnaIndex no tenga
            if (rowsGrid != -1 && columnaIndex != -1)
            {

                switch (columnaIndex)
                {
                    //6
                    //columna Cantidad    
                    case 6:
                        string cantidad = dgvDetalleOrden.Rows[rowsGrid].Cells["Recibido"].Value == null ? "" : dgvDetalleOrden.Rows[rowsGrid].Cells["Recibido"].Value.ToString();
                        //si es invalido el valor de entrada
                        if (IsInValidoInputGrid(cantidad, "Recibido"))
                        {
                            dgvDetalleOrden.Rows[rowsGrid].Cells["Recibido"].Value = "0";
                        }
                        break;                   
                }

            }
        }

        public static void RecolectarDatosDetalleRecepcion(ViewModelOrdenCompra model, List<DetalleListOrdenCompra> detalleOrdeCompra)
        {
            foreach (var itemDetalle in detalleOrdeCompra)
            {
                model.DetalleOrdenCompra[itemDetalle.Consecutivo].Cantidad_Recibida = itemDetalle.CantidadRecibida;
            }
        }

        public static void SeleccionarArticuloGrid(List<DetalleListOrdenCompra> detalleOrdeCompra, string articulo, DataGridView dgvDetalleCompra)
        {
            //buscar el articulo en la detalle de orden      
            var datosOrdenCompra = detalleOrdeCompra.Where(doc => doc.ArticuloId == articulo).FirstOrDefault();

            int filaOrden = datosOrdenCompra.Consecutivo;


            if (dgvDetalleCompra.Rows.Count > 0)
            {
                // 'Mueve el cursor a dicha fila               
                dgvDetalleCompra.CurrentCell = dgvDetalleCompra[6, filaOrden];
                //'Pinta de color azul la fila para indicar al usuario que esa celda está seleccionada
                dgvDetalleCompra.Rows[filaOrden].Selected = true;
            }

        }

        public static void AddNewRow(List<DetalleListOrdenCompra> detalleOrdeCompra, ViewModelArticulo listArticulo, decimal cantidad, decimal precio, 
            decimal PorcentajeDescuento, decimal PorcentajeISC, decimal PorcentajeIVA )
        {
            //obtener el numero consecutivo del
            var numConsecutivo = detalleOrdeCompra.Count;

            //verificar si linea la orden de compra y encontrar la linea maxima
            var lineaMax = detalleOrdeCompra.Count > 0 ? detalleOrdeCompra.Max(x => x.Linea) : detalleOrdeCompra.Count;

            var datosd_ = new DetalleListOrdenCompra()
            {
                Consecutivo = numConsecutivo,
                Linea = lineaMax + 1,
                ArticuloId = listArticulo.ArticuloID,
                CodigoBarra = listArticulo.CodigoBarra,
                ArticuloProveedor = listArticulo.Articulo_Del_Prov,
                Descripcion = listArticulo.Descripcion,

                Cantidad = cantidad,
                Precio = precio == 0.00M ? Utilidades.RoundApproximate(listArticulo.Costo_Ult_Loc, 4) : precio,
                PorcentajeDescuento = PorcentajeDescuento,
                PorcentajeISC = PorcentajeISC,
                PorcentajeIVA = PorcentajeIVA,

                MontoDesc = 0.00M,
                MontoISC = 0.00M,
                MontoIVA = 0.00M,
                TotalLinea = 0.00M,
                Nuevo = true
            };

            detalleOrdeCompra.Add(datosd_);
        }

        public static void ActualizarLineaPedidio(List<DetalleListOrdenCompra> detalleOrdeCompra, ViewModelArticulo listArticulo, decimal cantidad, decimal precio, decimal 
                                                    PorcentajeDescuento, decimal PorcentajeISC, decimal PorcentajeIVA)
        {
       
            var lineaOrdenCompra = detalleOrdeCompra.Where(x => x.ArticuloId == listArticulo.ArticuloID).FirstOrDefault();

            //actualizar la linea 
            lineaOrdenCompra.ArticuloId = listArticulo.ArticuloID;            
            lineaOrdenCompra.CodigoBarra = listArticulo.CodigoBarra;
            lineaOrdenCompra.ArticuloProveedor = listArticulo.Articulo_Del_Prov;
            lineaOrdenCompra.Descripcion = listArticulo.Descripcion;
            lineaOrdenCompra.Cantidad += cantidad;
            lineaOrdenCompra.Precio = precio == 0.00M ? Utilidades.RoundApproximate(listArticulo.Costo_Ult_Loc, 4) : precio;
            lineaOrdenCompra.PorcentajeDescuento = PorcentajeDescuento;
            lineaOrdenCompra.PorcentajeISC = PorcentajeISC;
            lineaOrdenCompra.PorcentajeIVA = PorcentajeIVA;
            
        }

        //seleccionar todo la orden o quitar el check a toda la orden
        public static void ChequearTodaOrdenCompra(bool chequearTodo, DataGridView dgvDetalleCompra)
        {
            
            for (var rows =0; rows < dgvDetalleCompra.RowCount; ++rows)
            {
                dgvDetalleCompra.Rows[rows].Cells["Seleccionar"].Value = chequearTodo;                             
            }
        }
    }
}
