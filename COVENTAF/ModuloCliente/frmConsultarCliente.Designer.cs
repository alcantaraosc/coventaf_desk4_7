
namespace COVENTAF.ModuloCliente
{
    partial class frmConsultarCliente
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pBxCodigoBarra = new System.Windows.Forms.PictureBox();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.btnGenerar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pBxCodigoBarra)).BeginInit();
            this.SuspendLayout();
            // 
            // pBxCodigoBarra
            // 
            this.pBxCodigoBarra.Location = new System.Drawing.Point(86, 146);
            this.pBxCodigoBarra.Name = "pBxCodigoBarra";
            this.pBxCodigoBarra.Size = new System.Drawing.Size(496, 175);
            this.pBxCodigoBarra.TabIndex = 0;
            this.pBxCodigoBarra.TabStop = false;
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(100, 95);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(482, 20);
            this.txtCodigo.TabIndex = 1;
            // 
            // btnGenerar
            // 
            this.btnGenerar.Location = new System.Drawing.Point(86, 361);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(496, 52);
            this.btnGenerar.TabIndex = 2;
            this.btnGenerar.Text = "Generar";
            this.btnGenerar.UseVisualStyleBackColor = true;
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // frmConsultarCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(191)))), ((int)(((byte)(215)))));
            this.ClientSize = new System.Drawing.Size(690, 450);
            this.Controls.Add(this.btnGenerar);
            this.Controls.Add(this.txtCodigo);
            this.Controls.Add(this.pBxCodigoBarra);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmConsultarCliente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmConsultarCliente";
            ((System.ComponentModel.ISupportInitialize)(this.pBxCodigoBarra)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pBxCodigoBarra;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Button btnGenerar;
    }
}