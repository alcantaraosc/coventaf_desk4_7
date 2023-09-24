using Api.Model.Modelos;
using Api.Model.ViewModels;
using DevExpress.XtraEditors;
using SpreadsheetLight;
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

        public static async Task<bool> GuardarFactura(VariableFact listVarFactura, List<DetalleFactura> listDetFactura, string bodega, string Observaciones)
        {
            bool result = false;
            try
            {
                // SpreadsheetLight works on the idea of a currently selected worksheet.
                // If no worksheet name is provided on opening an existing spreadsheet,
                // the first available worksheet is selected.
                //string pathFile = AppDomain.CurrentDomain.BaseDirectory + "Auto_Recuperacion_Factura.xlsx";

                await Task.Run(() =>
                {

                    SLDocument sl = new SLDocument("Auto_Recuperacion_Factura.xlsx", "Encabezado");
                    sl.SetCellValue("A2", listVarFactura.NoFactura);
                    sl.SetCellValue("B2", listVarFactura.CodigoCliente);
                    sl.SetCellValue("C2", bodega);
                    sl.SetCellValue("D2", User.Caja);
                    sl.SetCellValue("E2", User.Usuario);
                    sl.SetCellValue("F2", User.ConsecCierreCT);
                    sl.SetCellValue("G2", User.TiendaID);
                    sl.SetCellValue("H2", listVarFactura.TipoDeCambio);
                    sl.SetCellValue("I2", Observaciones);
                    sl.SetCellValue("J2", "0.00");
                    sl.SetCellValue("K2", "0.00");

                    //hoja detalle
                    sl.SelectWorksheet("Detalles");


                    // elimina apartir de la fila 2 las cantidades
                    // Tenga en cuenta que la fila 6 original ahora está en la fila 10
                    sl.DeleteRow(2, listDetFactura.Count + 2);

                    foreach (var item in listDetFactura)
                    {
                        int linea = item.Consecutivo + 2;
                        //Linea
                        sl.SetCellValue($"A{linea}", item.Consecutivo);
                        //codigo del articulo
                        sl.SetCellValue($"B{linea}", item.ArticuloId);
                        //cantidad
                        sl.SetCellValue($"C{linea}", item.Cantidad);
                        //% descuento
                        sl.SetCellValue($"D{linea}", item.PorcentDescuentArticulo_d);
                        //descripcion
                        sl.SetCellValue($"E{linea}", item.Descripcion);
                        //lote
                        sl.SetCellValue($"F{linea}", item.Lote);
                        //localizacion
                        sl.SetCellValue($"G{linea}", item.Localizacion);
                    }

                    sl.SaveAs("Auto_Recuperacion_Factura.xlsx");

                    result = true;
                });


                /*   SLDocument sl = new SLDocument();

                   // set a boolean at "A1"
                   sl.SetCellValue("A1", true);

                   // set at row 2, columns 1 through 20, a value that's equal to the column index
                   for (int i = 1; i <= 20; ++i) sl.SetCellValue(2, i, i);

                   // set the value of PI
                   sl.SetCellValue("B3", 3.14159);

                   // set the value of PI at row 4, column 2 (or "B4") in string form.
                   // use this when you already have numeric data in string form and don't
                   // want to parse it to a double or float variable type
                   // and then set it as a value.
                   // Note that "3,14159" is invalid. Excel (or Open XML) stores numerals in
                   // invariant culture mode. Frankly, even "1,234,567.89" is invalid because
                   // of the comma. If you can assign it in code, then it's fine, like so:
                   // double fTemp = 1234567.89;
                   sl.SetCellValueNumeric(4, 2, "3.14159");

                   // normal string data
                   sl.SetCellValue("C6", "This is at C6!");

                   // typical XML-invalid characters are taken care of,
                   // in particular the & and < and >
                   sl.SetCellValue("I6", "Dinner & Dance costs < $10");

                   // this sets a cell formula
                   // Note that if you want to set a string that starts with the equal sign,
                   // but is not a formula, prepend a single quote.
                   // For example, "'==" will display 2 equal signs
                   sl.SetCellValue(7, 3, "=SUM(A2:T2)");

                   // if you need cell references and cell ranges really badly, consider the SLConvert class.
                   sl.SetCellValue(SLConvert.ToCellReference(7, 4), string.Format("=SUM({0})", SLConvert.ToCellRange(2, 1, 2, 20)));

                   // dates need the format code to be displayed as the typical date.
                   // Otherwise it just looks like a floating point number.
                   sl.SetCellValue("C8", new DateTime(3141, 5, 9));
                   SLStyle style = sl.CreateStyle();
                   style.FormatCode = "d-mmm-yyyy";
                   sl.SetCellStyle("C8", style);

                   sl.SetCellValue(8, 6, "I predict this to be a significant date. Why, I do not know...");

                   sl.SetCellValue(9, 4, 456.123789);
                   // we don't have to create a new SLStyle because
                   // we only used the FormatCode property
                   style.FormatCode = "0.000%";
                   sl.SetCellStyle(9, 4, style);

                   sl.SetCellValue(9, 6, "Perhaps a phenomenal growth in something?");

                   sl.SaveAs("HelloWorld.xlsx");*/
            }
            catch (Exception)
            {

            }

            return result;
        }
    }
}
