using System;
using System.Windows.Forms;

namespace COVENTAF
{
    public partial class frmMessageBoxAsk : Form
    {
        //video: https://www.youtube.com/watch?v=1QSu_2BN-Zw&list=PLdn0WbxCwBAmQXXI9FEx4UvypQXOuP5Fw
        public DialogResult respuesta;
        public frmMessageBoxAsk(string mensaje, string barraTitulo = "Sistema COVENTAF")
        {
            InitializeComponent();

            //this.lblTitle.Text = mensaje;
            this.txtMensaje.Text = mensaje;
        }

        public frmMessageBoxAsk()
        {
            InitializeComponent();
        }

        private void MessageBox_Load(object sender, EventArgs e)
        {
            this.btnOk.Select();
            this.btnOk.Focus();
        }

    
        private void btnOk_Click(object sender, EventArgs e)
        {
            respuesta = DialogResult.Yes;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            respuesta = DialogResult.No;
            this.Close();
        }
    }
}
