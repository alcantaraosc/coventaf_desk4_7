using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Api.Model.Modelos;
using GenCode128;

namespace COVENTAF.ModuloCliente
{
    public partial class frmConsultarCliente : Form
    {
        //https://www.youtube.com/watch?v=kVuWseZJ5Mo
        public int altura = 2;

        public static System.Drawing.Font printFont;

        private PrintDocument doc = new PrintDocument();
        private PrintPreviewDialog vista = new PrintPreviewDialog();
        // Construct the PrintPreviewControl.
        PrintPreviewControl PrintPreviewControl1 = new PrintPreviewControl();

        public frmConsultarCliente()
        {
            InitializeComponent();
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            try
            {
                Image codigoBarras = Code128Rendering.MakeBarcodeImage(txtCodigo.Text, altura, true);
                this.pBxCodigoBarra.Image = codigoBarras;

                doc.PrinterSettings.PrinterName = doc.DefaultPageSettings.PrinterSettings.PrinterName;

                doc.PrintPage += new PrintPageEventHandler(ImprimirCodigoBarra);
                // Set the zoom to 25 percent.
                //this.PrintPreviewControl1.Zoom = 0.25;            
                //vista.Controls.Add(this.PrintPreviewControl1);

                vista.Document = doc;
               
                if (User.VistaPrevia)
                {
                    vista.ShowDialog();
                }
                else
                {
                    doc.Print();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, this.Text);
            }
        }

        public void ImprimirCodigoBarra(object sender, PrintPageEventArgs e)
        {
            using (var g = e.Graphics )
            {
                using(var fnt = new Font("Courier New", 16))
                {
                    g.DrawImage(this.pBxCodigoBarra.Image, 20, 50);

                    var caption = txtCodigo.Text;
                    g.DrawString(caption, fnt, Brushes.Black, 130, 110);
                }
            }
        }
    }
}
