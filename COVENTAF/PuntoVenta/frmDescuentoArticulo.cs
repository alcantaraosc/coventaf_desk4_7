using Api.Model.ViewModels;
using COVENTAF.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COVENTAF.PuntoVenta
{
    public partial class frmDescuentoArticulo : Form
    {
        string Transition;

        public List<DetalleFactura> listDetFactura;
        public bool descuentoLineaExitoso = false;
        public frmDescuentoArticulo()
        {
            InitializeComponent();
        }

        private void frmDescuentoArticulo_Load(object sender, EventArgs e)
        {
            Transition = "FadeIn";
            tmTransition.Start();
            this.Top = this.Top + 15;

            foreach (var item in listDetFactura)
            {
                this.dgvDetalleFactura.Rows.Add(false, item.ArticuloId, item.Cantidad, item.PorcentDescuentArticulo, item.Descripcion);
            }

            configurarDataGridView(dgvDetalleFactura);          
        }

        public void configurarDataGridView(DataGridView dgvDetalleFactura)
        {
            dgvDetalleFactura.Columns["Marcado"].ReadOnly = false;
            dgvDetalleFactura.Columns["Articulo"].ReadOnly = true;
            dgvDetalleFactura.Columns["Cantidad"].ReadOnly = true;
            dgvDetalleFactura.Columns["Descuento"].ReadOnly = true;
            dgvDetalleFactura.Columns["Descripcion"].ReadOnly = true;
        }

        private void btnActivarCheck_Click(object sender, EventArgs e)
        {
            for (var rows = 0; rows < dgvDetalleFactura.Rows.Count; rows++)
            {
                //activar el check
                dgvDetalleFactura.Rows[rows].Cells["Marcado"].Value = true;
            }
            this.txtDescuentoLinea.Enabled = true;
            this.txtDescuentoLinea.SelectionStart = 0;
            this.txtDescuentoLinea.SelectionLength = this.txtDescuentoLinea.Text.Length;
            this.txtDescuentoLinea.Focus();           
        }

        private void btnQuitarCheck_Click(object sender, EventArgs e)
        {
            for (var rows = 0; rows < dgvDetalleFactura.Rows.Count; rows++)
            {
                //quitar el check
                dgvDetalleFactura.Rows[rows].Cells["Marcado"].Value = false;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            //verificar si existe el descuento superior de los 25 %
            if (ExisteDescuentoSuperior25Porciento())
            {
                //si la autorizacion no fue exitosa e
                if (!Utilidades.AutorizacionExitosa()) return;
            }


            for (var rows = 0; rows < dgvDetalleFactura.Rows.Count; rows++)
            {
                string articulo = dgvDetalleFactura.Rows[rows].Cells["Articulo"].Value.ToString();
                var lineaArticulo = listDetFactura.Where(df => df.ArticuloId == articulo).FirstOrDefault();
                lineaArticulo.PorcentDescuentArticulo = dgvDetalleFactura.Rows[rows].Cells["Descuento"].Value.ToString();
                lineaArticulo.PorcentDescuentArticulo_d = Convert.ToDecimal(dgvDetalleFactura.Rows[rows].Cells["Descuento"].Value);
                //esta variable me indica que se aplico el descuento exitosamente
                descuentoLineaExitoso = true;
            }

            //this.Close();
            //iniciar la transaccion
            this.tmTransition.Start();
        }

        //este metodo verifica si existe el descuento maximo de 25 % para pedir autorizacion.
        private bool ExisteDescuentoSuperior25Porciento()        
        {
            bool existeDescuentoMaximo = false;

            for (var rows = 0; rows < dgvDetalleFactura.Rows.Count; rows++)
            {
                if (Convert.ToDecimal(dgvDetalleFactura.Rows[rows].Cells["Descuento"].Value) >=25)
                {
                    existeDescuentoMaximo = true;
                    break;
                }               
            }

            return existeDescuentoMaximo;
        }

        private void txtDescuento_KeyPress(object sender, KeyPressEventArgs e)
        {
            //validar que el textbox solo se pueda digitar numero con punto decimal con decimal, ademas si esta seleccionado te permite borrar
            if (Utilidades.NumeroDecimalCorrecto(e, this.txtDescuentoLinea.Text, this.txtDescuentoLinea.SelectedText.Length))
            {
                if (e.KeyChar == 13)
                {
                    if (!Utilidades.ValidacionDescuentoExitoso(Convert.ToDecimal(this.txtDescuentoLinea.Text))) return;

                    AplicarDescuentoLinea();
                    this.btnAceptar.Enabled = true;
                    this.btnAceptar.Focus();
                }
            }
            else
            {
                e.Handled = true;
            }
        }

        private void AplicarDescuentoLinea()
        {
            for (var rows = 0; rows < dgvDetalleFactura.Rows.Count; rows++)
            {
                if (Convert.ToBoolean(dgvDetalleFactura.Rows[rows].Cells["Marcado"].Value))
                {
                    //asigno el descuento.
                    dgvDetalleFactura.Rows[rows].Cells["Descuento"].Value = this.txtDescuentoLinea.Text;
                    //quito el check
                    dgvDetalleFactura.Rows[rows].Cells["Marcado"].Value = false;
                }

            }
        }

        private void frmDescuentoArticulo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F6 && this.txtDescuentoLinea.Enabled)
            {
                this.txtDescuentoLinea.SelectionStart = 0;
                this.txtDescuentoLinea.SelectionLength = this.txtDescuentoLinea.Text.Length;
                this.txtDescuentoLinea.Focus();
            }
            else if (e.KeyCode == Keys.F2)
            {
                btnActivarCheck_Click(null, null);
            }
            else if (e.KeyCode == Keys.F3)
            {
                btnQuitarCheck_Click(null, null);
            }
            else 
            if (e.KeyCode == Keys.F4)
            {
                //obtener la fila seleccionada                              
                int IndexFila = dgvDetalleFactura.CurrentRow.Index;
                // 'Mueve el cursor a dicha fila               
                dgvDetalleFactura.CurrentCell = dgvDetalleFactura[0, IndexFila];
                //'Pinta de color azul la fila para indicar al usuario que esa celda está seleccionada (Opcional)
                dgvDetalleFactura.Rows[IndexFila].Selected = true;
            }

        }

        private void tmTransition_Tick(object sender, EventArgs e)
        {
            Utilidades.tmTransition_Tick(ref Transition, this.tmTransition, this);                     
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            tmTransition.Start();
        }
    }
}

