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
            this.label20.Text = "Lista de Cajeros";
            this.cboCatalogo.SelectedIndex =  1;
        }
    }
}
