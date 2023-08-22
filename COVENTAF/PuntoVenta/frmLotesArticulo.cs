using Api.Model.ViewModels;
using COVENTAF.Metodos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COVENTAF.PuntoVenta
{
    public partial class frmLotesArticulo : Form
    {
        public List<ViewModelArticulo> listArticulo;
        public string numLote = "";
        public bool resultExitos = false;

        string Transition;

        #region codigo para mover pantalla
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        #endregion

        public frmLotesArticulo()
        {
            InitializeComponent();
        }

        private void barraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }


        private void frmLotesArticulo_Load(object sender, EventArgs e)
        {
            Transition = "FadeIn";
            tmTransition.Start();
            this.Top = this.Top + 15;

            ListarLotesGrid();
            
        }

        private void ListarLotesGrid()
        {
            foreach(var item in listArticulo)
            {
                this.dgvLotes.Rows.Add(item.Lote, item.FechaVencimiento, item.Localizacion, item.ExistenciaPorLote);
            }
        }

        private void tmTransition_Tick(object sender, EventArgs e)
        {
            UtilidadesMain.tmTransition_Tick(ref Transition, this.tmTransition, this);
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (dgvLotes.Rows.Count > 0)
            {
                int index = dgvLotes.CurrentRow.Index;
                numLote = this.dgvLotes.Rows[index].Cells["Lote"].Value.ToString();
                resultExitos = true;
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvLotes_MouseDoubleClick(object sender, MouseEventArgs e)
        {
           if (dgvLotes.Rows.Count >0)
            {
                int index = dgvLotes.CurrentRow.Index;
                numLote = this.dgvLotes.Rows[index].Cells["Lote"].Value.ToString();
                resultExitos = true;
                this.Close();
            }
     
           //btnCierre_Click(null, null);
        }
    }
}
