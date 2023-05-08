using COVENTAF.Security;
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
    public partial class frmListaCajero : frmListaUsuarios
    {
        public frmListaCajero()
        {
            InitializeComponent();
        }


        protected override void frmListaUsuario_Load(object sender, EventArgs e)
        {
            this.cboCatalogo.Enabled = false;
            this.btnNuevoUsuario.Visible = false;
            this.lblTituloTop.Text = "Lista de Cajeros";
            this.cboCatalogo.SelectedIndex =  1;
        }

        protected override void dgvListaUsuarios_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (MessageBox.Show($"¿Estas seguro de Editar los datos del {this.cboCatalogo.Text}", "Sistema COVENTAF", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                //obtener el login del usuario.
                int Index = dgvListaUsuarios.CurrentRow.Index;
                string usuario = dgvListaUsuarios.Rows[Index].Cells[0].Value.ToString();

                switch (this.cboCatalogo.Text)
                {
                   
                    case "Cajero":
                        CatalogoCajero(usuario);
                        break;
                }
            }
        }

        protected override void CatalogoCajero(string cajero, bool nuevoCajero = false)
        {
            using (var frmDatosCajero = new frmCajero())
            {
                frmDatosCajero.nuevoCajero = nuevoCajero;
                frmDatosCajero.txtCajero.Text = cajero;
                frmDatosCajero.txtCajero.Enabled = false;
                frmDatosCajero.txtBodega.Enabled = false;
                frmDatosCajero.ShowDialog();
            }
        }
    }
}
