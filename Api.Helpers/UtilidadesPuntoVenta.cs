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
    public static class UtilidadesPuntoVenta
    {

        private static bool IsInValidoInputGridDevolucion(string valor, string nombreCampo)
        {
            bool valido = true;

            if (valor.Trim().Length == 0)
            {
                XtraMessageBox.Show($" {nombreCampo} no debe estar vacio", "Sistema COVENTAF", MessageBoxButtons.OK);
            }
            else if (Utilidades.TieneLetra(valor))
            {
                MessageBox.Show($" {nombreCampo} solo debe ser numero", "Sistema COVENTAF");
            }
            else if (Convert.ToDecimal(valor) < 0)
            {
                MessageBox.Show($" {nombreCampo} debe ser un numero positivo", "Sistema COVENTAF");
            }
            else
            {
                valido = false;
            }

            return valido;
        }

        /// <summary>
        /// validar el grid de la Devolucion
        /// </summary>
        /// <param name="rowsGrid"></param>
        /// <param name="columnaIndex"></param>
        /// <param name="dgvDetalleDevolucion"></param>
        /// <param name="btnAceptar"></param>
        /// <param name="_detalleDevolucion"></param>
        public static void ValidarGridDevolucion(int rowsGrid, int columnaIndex, DataGridView dgvDetalleDevolucion, ToolStripButton btnAceptar, List<DetalleDevolucion> _detalleDevolucion)
        {
            //verificar que los consecutivoActualFactura y columnaIndex no tenga
            if (rowsGrid != -1 && columnaIndex != -1 && columnaIndex == 6)
            {
                string mensaje = "";
                bool cantidadConDecimal = false;               
                //obtener el valor del grid ya sea si esta vacio
                string cantidadDevolver = dgvDetalleDevolucion.Rows[rowsGrid].Cells["CantidadDevolver"].Value == null ? "" : dgvDetalleDevolucion.Rows[rowsGrid].Cells["CantidadDevolver"].Value.ToString();
                //obtener la cantidad del DataGridView
                decimal cantidadFactura = Convert.ToDecimal(dgvDetalleDevolucion.Rows[rowsGrid].Cells["Cantidad"].Value);
               
                //si es invalido el valor de entrada
                if (IsInValidoInputGridDevolucion(cantidadDevolver, "Cantidad Devolver"))
                {
                    dgvDetalleDevolucion.Rows[rowsGrid].Cells["CantidadDevolver"].Value = "0";
                }
                else if (!Utilidades.CantidadIsValido(dgvDetalleDevolucion.Rows[rowsGrid].Cells["CantidadDevolver"].Value.ToString(), cantidadConDecimal, ref mensaje))
                {
                    MessageBox.Show(mensaje, "Sistema COVENTAF", MessageBoxButtons.OK);
                    //asignarle la cantidad que tenia antes de editarla
                    dgvDetalleDevolucion.Rows[rowsGrid].Cells["CantidadDevolver"].Value = "0";
                }
                else if (Convert.ToDecimal(cantidadDevolver) > cantidadFactura)
                {
                    XtraMessageBox.Show("La cantidad a devolver excede a la cantidad del articulo de la factura", "Sistema COVENTAF", MessageBoxButtons.OK);
                    //asignarle la cantidad que tenia antes de editarla
                    dgvDetalleDevolucion.Rows[rowsGrid].Cells["CantidadDevolver"].Value = "0";
                }
                else
                {
                   
                    btnAceptar.Enabled = true;
                }

                //actualizar la clase que lleva el control la devolucion
                _detalleDevolucion[rowsGrid].CantidadDevolver = dgvDetalleDevolucion.Rows[rowsGrid].Cells["CantidadDevolver"].Value.ToString();
            }
        }      
    }
}
