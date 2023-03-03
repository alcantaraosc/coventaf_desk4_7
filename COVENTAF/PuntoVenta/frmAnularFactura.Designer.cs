
namespace COVENTAF.PuntoVenta
{
    partial class frmAnularFactura
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
            this.panel5 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnAnularFactura = new System.Windows.Forms.ToolStripButton();
            this.btnBuscarFactura = new System.Windows.Forms.ToolStripButton();
            this.pictureBox11 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel5.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox11)).BeginInit();
            this.SuspendLayout();
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(13)))), ((int)(((byte)(66)))));
            this.panel5.Controls.Add(this.label10);
            this.panel5.Controls.Add(this.label20);
            this.panel5.Controls.Add(this.pictureBox11);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(625, 69);
            this.panel5.TabIndex = 145;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold);
            this.label10.ForeColor = System.Drawing.Color.Gold;
            this.label10.Location = new System.Drawing.Point(22, 3);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(121, 30);
            this.label10.TabIndex = 140;
            this.label10.Text = "COVENTAF";
            // 
            // label20
            // 
            this.label20.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label20.AutoSize = true;
            this.label20.BackColor = System.Drawing.Color.Transparent;
            this.label20.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold);
            this.label20.ForeColor = System.Drawing.Color.SeaShell;
            this.label20.Location = new System.Drawing.Point(39, 38);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(145, 23);
            this.label20.TabIndex = 141;
            this.label20.Text = "Anular Factura";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnBuscarFactura,
            this.toolStripSeparator1,
            this.btnAnularFactura,
            this.toolStripSeparator2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 69);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(625, 56);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 56);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 56);
            // 
            // btnAnularFactura
            // 
            this.btnAnularFactura.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAnularFactura.Image = global::COVENTAF.Properties.Resources.cancelar;
            this.btnAnularFactura.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnAnularFactura.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAnularFactura.Name = "btnAnularFactura";
            this.btnAnularFactura.Size = new System.Drawing.Size(95, 53);
            this.btnAnularFactura.Text = "Anular Factura";
            this.btnAnularFactura.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // btnBuscarFactura
            // 
            this.btnBuscarFactura.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscarFactura.Image = global::COVENTAF.Properties.Resources.search24;
            this.btnBuscarFactura.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnBuscarFactura.Name = "btnBuscarFactura";
            this.btnBuscarFactura.Size = new System.Drawing.Size(96, 53);
            this.btnBuscarFactura.Text = "Buscar Factura";
            this.btnBuscarFactura.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // pictureBox11
            // 
            this.pictureBox11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox11.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox11.Image = global::COVENTAF.Properties.Resources.logo;
            this.pictureBox11.Location = new System.Drawing.Point(977, 2);
            this.pictureBox11.Name = "pictureBox11";
            this.pictureBox11.Size = new System.Drawing.Size(351, 48);
            this.pictureBox11.TabIndex = 142;
            this.pictureBox11.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Navy;
            this.label2.Location = new System.Drawing.Point(30, 153);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 20);
            this.label2.TabIndex = 148;
            this.label2.Text = "No Factura:";
            // 
            // txtCliente
            // 
            this.txtCliente.Enabled = false;
            this.txtCliente.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtCliente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.txtCliente.Location = new System.Drawing.Point(27, 239);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.Size = new System.Drawing.Size(548, 25);
            this.txtCliente.TabIndex = 149;
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.textBox1.ForeColor = System.Drawing.Color.Navy;
            this.textBox1.Location = new System.Drawing.Point(27, 181);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(169, 25);
            this.textBox1.TabIndex = 150;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label1.Location = new System.Drawing.Point(30, 214);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 20);
            this.label1.TabIndex = 151;
            this.label1.Text = "Cliente:";
            // 
            // textBox2
            // 
            this.textBox2.Enabled = false;
            this.textBox2.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.textBox2.ForeColor = System.Drawing.Color.Navy;
            this.textBox2.Location = new System.Drawing.Point(217, 181);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(169, 25);
            this.textBox2.TabIndex = 153;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Navy;
            this.label3.Location = new System.Drawing.Point(224, 153);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 20);
            this.label3.TabIndex = 152;
            this.label3.Text = "Caja:";
            // 
            // textBox3
            // 
            this.textBox3.Enabled = false;
            this.textBox3.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.textBox3.ForeColor = System.Drawing.Color.Navy;
            this.textBox3.Location = new System.Drawing.Point(406, 181);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(169, 25);
            this.textBox3.TabIndex = 155;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Navy;
            this.label4.Location = new System.Drawing.Point(411, 153);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 20);
            this.label4.TabIndex = 154;
            this.label4.Text = "Fecha:";
            // 
            // textBox4
            // 
            this.textBox4.Enabled = false;
            this.textBox4.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.textBox4.ForeColor = System.Drawing.Color.Navy;
            this.textBox4.Location = new System.Drawing.Point(25, 313);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(169, 25);
            this.textBox4.TabIndex = 157;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Navy;
            this.label5.Location = new System.Drawing.Point(30, 285);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 20);
            this.label5.TabIndex = 156;
            this.label5.Text = "Total";
            // 
            // frmAnularFactura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(625, 418);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.txtCliente);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.panel5);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmAnularFactura";
            this.Text = "Anular Factura";
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox11)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.PictureBox pictureBox11;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnAnularFactura;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnBuscarFactura;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label5;
    }
}