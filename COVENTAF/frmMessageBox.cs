using System;
using System.Windows.Forms;

namespace COVENTAF
{
    public partial class frmMessageBox : Form
    {
        //video: https://www.youtube.com/watch?v=1QSu_2BN-Zw&list=PLdn0WbxCwBAmQXXI9FEx4UvypQXOuP5Fw
        public DialogResult respuesta;
        public frmMessageBox(string mensaje, string barraTitulo = "Sistema COVENTAF")
        {
            InitializeComponent();

            //this.lblTitle.Text = mensaje;
            //this.lblTitle.Text = barraTitulo;
        }

        public frmMessageBox()
        {
        }

        private void MessageBox_Load(object sender, EventArgs e)
        {

        }



        private void btnYes_Click(object sender, EventArgs e)
        {
            respuesta = DialogResult.Yes;
        }
    }
}
