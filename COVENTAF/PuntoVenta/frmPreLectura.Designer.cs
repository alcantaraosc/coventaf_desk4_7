
namespace COVENTAF.PuntoVenta
{
    partial class frmPreLectura
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.barraTitulo = new System.Windows.Forms.Panel();
            this.btnCierre = new System.Windows.Forms.PictureBox();
            this.btnMinizar = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.btnMinimizar = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblTituloCaja = new System.Windows.Forms.Label();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.dgvGridReportadoPorSistema = new System.Windows.Forms.DataGridView();
            this.Ids = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoPagos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Montos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Monedas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblNoCierre = new System.Windows.Forms.Label();
            this.tmTransition = new System.Windows.Forms.Timer(this.components);
            this.barraTitulo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnCierre)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGridReportadoPorSistema)).BeginInit();
            this.SuspendLayout();
            // 
            // barraTitulo
            // 
            this.barraTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(99)))), ((int)(((byte)(177)))));
            this.barraTitulo.Controls.Add(this.btnCierre);
            this.barraTitulo.Controls.Add(this.btnMinizar);
            this.barraTitulo.Controls.Add(this.btnCerrar);
            this.barraTitulo.Controls.Add(this.lblTitulo);
            this.barraTitulo.Controls.Add(this.btnMinimizar);
            this.barraTitulo.Cursor = System.Windows.Forms.Cursors.Default;
            this.barraTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.barraTitulo.Location = new System.Drawing.Point(0, 0);
            this.barraTitulo.Name = "barraTitulo";
            this.barraTitulo.Size = new System.Drawing.Size(523, 28);
            this.barraTitulo.TabIndex = 4;
            this.barraTitulo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.barraTitulo_MouseDown);
            // 
            // btnCierre
            // 
            this.btnCierre.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCierre.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCierre.Image = global::COVENTAF.Properties.Resources.close_login;
            this.btnCierre.Location = new System.Drawing.Point(491, 3);
            this.btnCierre.Name = "btnCierre";
            this.btnCierre.Size = new System.Drawing.Size(21, 21);
            this.btnCierre.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnCierre.TabIndex = 81;
            this.btnCierre.TabStop = false;
            this.btnCierre.Click += new System.EventHandler(this.btnCierre_Click);
            // 
            // btnMinizar
            // 
            this.btnMinizar.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnMinizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMinizar.FlatAppearance.BorderSize = 0;
            this.btnMinizar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnMinizar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.btnMinizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinizar.Image = global::COVENTAF.Properties.Resources.Icono_Minimizar;
            this.btnMinizar.Location = new System.Drawing.Point(1225, -26);
            this.btnMinizar.Name = "btnMinizar";
            this.btnMinizar.Size = new System.Drawing.Size(11, 13);
            this.btnMinizar.TabIndex = 10;
            this.btnMinizar.UseVisualStyleBackColor = true;
            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrar.FlatAppearance.BorderSize = 0;
            this.btnCerrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnCerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.Image = global::COVENTAF.Properties.Resources.Icono_cerrar_FN;
            this.btnCerrar.Location = new System.Drawing.Point(1250, -26);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(11, 13);
            this.btnCerrar.TabIndex = 9;
            this.btnCerrar.UseVisualStyleBackColor = true;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.lblTitulo.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(9, 5);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(87, 19);
            this.lblTitulo.TabIndex = 8;
            this.lblTitulo.Text = "Prelectura";
            // 
            // btnMinimizar
            // 
            this.btnMinimizar.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnMinimizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMinimizar.FlatAppearance.BorderSize = 0;
            this.btnMinimizar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnMinimizar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.btnMinimizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimizar.Image = global::COVENTAF.Properties.Resources.Icono_Minimizar;
            this.btnMinimizar.Location = new System.Drawing.Point(1959, -63);
            this.btnMinimizar.Name = "btnMinimizar";
            this.btnMinimizar.Size = new System.Drawing.Size(40, 40);
            this.btnMinimizar.TabIndex = 7;
            this.btnMinimizar.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(99)))), ((int)(((byte)(177)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(516, 28);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(7, 564);
            this.panel2.TabIndex = 131;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(99)))), ((int)(((byte)(177)))));
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(7, 564);
            this.panel1.TabIndex = 132;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(99)))), ((int)(((byte)(177)))));
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(7, 585);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(509, 7);
            this.panel3.TabIndex = 133;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(45)))), ((int)(((byte)(64)))));
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(13)))), ((int)(((byte)(66)))));
            this.label2.Location = new System.Drawing.Point(7, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(509, 74);
            this.label2.TabIndex = 161;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(45)))), ((int)(((byte)(64)))));
            this.label4.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.Gold;
            this.label4.Location = new System.Drawing.Point(40, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 30);
            this.label4.TabIndex = 162;
            this.label4.Text = "COVENTAF";
            // 
            // lblTituloCaja
            // 
            this.lblTituloCaja.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTituloCaja.AutoSize = true;
            this.lblTituloCaja.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(45)))), ((int)(((byte)(64)))));
            this.lblTituloCaja.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblTituloCaja.ForeColor = System.Drawing.Color.SeaShell;
            this.lblTituloCaja.Location = new System.Drawing.Point(66, 71);
            this.lblTituloCaja.Name = "lblTituloCaja";
            this.lblTituloCaja.Size = new System.Drawing.Size(104, 23);
            this.lblTituloCaja.TabIndex = 163;
            this.lblTituloCaja.Text = "Prelectura";
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalir.BackColor = System.Drawing.Color.Maroon;
            this.btnSalir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSalir.FlatAppearance.BorderSize = 0;
            this.btnSalir.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(92)))), ((int)(((byte)(133)))));
            this.btnSalir.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(50)))), ((int)(((byte)(97)))));
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSalir.Font = new System.Drawing.Font("Bahnschrift Condensed", 14.25F);
            this.btnSalir.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnSalir.Image = global::COVENTAF.Properties.Resources.cancelar;
            this.btnSalir.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnSalir.Location = new System.Drawing.Point(395, 535);
            this.btnSalir.Margin = new System.Windows.Forms.Padding(2);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(111, 40);
            this.btnSalir.TabIndex = 196;
            this.btnSalir.Text = "&Cancelar";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnImprimir
            // 
            this.btnImprimir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImprimir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(99)))), ((int)(((byte)(177)))));
            this.btnImprimir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnImprimir.FlatAppearance.BorderSize = 0;
            this.btnImprimir.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(92)))), ((int)(((byte)(133)))));
            this.btnImprimir.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(50)))), ((int)(((byte)(97)))));
            this.btnImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnImprimir.Font = new System.Drawing.Font("Bahnschrift Condensed", 14.25F);
            this.btnImprimir.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnImprimir.Image = global::COVENTAF.Properties.Resources.print24;
            this.btnImprimir.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnImprimir.Location = new System.Drawing.Point(245, 535);
            this.btnImprimir.Margin = new System.Windows.Forms.Padding(2);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(139, 40);
            this.btnImprimir.TabIndex = 195;
            this.btnImprimir.Text = "&Imprimir";
            this.btnImprimir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnImprimir.UseVisualStyleBackColor = false;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // dgvGridReportadoPorSistema
            // 
            this.dgvGridReportadoPorSistema.AllowUserToAddRows = false;
            this.dgvGridReportadoPorSistema.AllowUserToDeleteRows = false;
            this.dgvGridReportadoPorSistema.AllowUserToResizeColumns = false;
            this.dgvGridReportadoPorSistema.AllowUserToResizeRows = false;
            this.dgvGridReportadoPorSistema.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvGridReportadoPorSistema.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvGridReportadoPorSistema.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvGridReportadoPorSistema.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvGridReportadoPorSistema.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(24)))), ((int)(((byte)(69)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvGridReportadoPorSistema.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvGridReportadoPorSistema.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGridReportadoPorSistema.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Ids,
            this.TipoPagos,
            this.Montos,
            this.Monedas});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.NavajoWhite;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvGridReportadoPorSistema.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvGridReportadoPorSistema.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvGridReportadoPorSistema.EnableHeadersVisualStyles = false;
            this.dgvGridReportadoPorSistema.GridColor = System.Drawing.Color.Gray;
            this.dgvGridReportadoPorSistema.Location = new System.Drawing.Point(7, 102);
            this.dgvGridReportadoPorSistema.MultiSelect = false;
            this.dgvGridReportadoPorSistema.Name = "dgvGridReportadoPorSistema";
            this.dgvGridReportadoPorSistema.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.InactiveBorder;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Sienna;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvGridReportadoPorSistema.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvGridReportadoPorSistema.RowHeadersVisible = false;
            this.dgvGridReportadoPorSistema.RowTemplate.Height = 25;
            this.dgvGridReportadoPorSistema.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvGridReportadoPorSistema.Size = new System.Drawing.Size(509, 411);
            this.dgvGridReportadoPorSistema.TabIndex = 197;
            // 
            // Ids
            // 
            this.Ids.HeaderText = "Id";
            this.Ids.Name = "Ids";
            this.Ids.ReadOnly = true;
            this.Ids.Visible = false;
            this.Ids.Width = 29;
            // 
            // TipoPagos
            // 
            this.TipoPagos.HeaderText = "Tipo de Pago";
            this.TipoPagos.Name = "TipoPagos";
            this.TipoPagos.ReadOnly = true;
            this.TipoPagos.Width = 125;
            // 
            // Montos
            // 
            this.Montos.HeaderText = "Monto";
            this.Montos.Name = "Montos";
            this.Montos.ReadOnly = true;
            this.Montos.Width = 81;
            // 
            // Monedas
            // 
            this.Monedas.HeaderText = "Moneda";
            this.Monedas.Name = "Monedas";
            this.Monedas.ReadOnly = true;
            this.Monedas.Visible = false;
            this.Monedas.Width = 91;
            // 
            // lblNoCierre
            // 
            this.lblNoCierre.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNoCierre.AutoSize = true;
            this.lblNoCierre.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(45)))), ((int)(((byte)(64)))));
            this.lblNoCierre.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoCierre.ForeColor = System.Drawing.Color.SeaShell;
            this.lblNoCierre.Location = new System.Drawing.Point(242, 42);
            this.lblNoCierre.Name = "lblNoCierre";
            this.lblNoCierre.Size = new System.Drawing.Size(87, 18);
            this.lblNoCierre.TabIndex = 198;
            this.lblNoCierre.Text = "No. Cierre:";
            // 
            // tmTransition
            // 
            this.tmTransition.Enabled = true;
            this.tmTransition.Interval = 20;
            this.tmTransition.Tick += new System.EventHandler(this.tmTransition_Tick);
            // 
            // frmPreLectura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(191)))), ((int)(((byte)(215)))));
            this.ClientSize = new System.Drawing.Size(523, 592);
            this.ControlBox = false;
            this.Controls.Add(this.lblNoCierre);
            this.Controls.Add(this.dgvGridReportadoPorSistema);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.lblTituloCaja);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.barraTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmPreLectura";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmPreLectura";
            this.Load += new System.EventHandler(this.frmPreLectura_Load);
            this.barraTitulo.ResumeLayout(false);
            this.barraTitulo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnCierre)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGridReportadoPorSistema)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel barraTitulo;
        private System.Windows.Forms.PictureBox btnCierre;
        private System.Windows.Forms.Button btnMinizar;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Button btnMinimizar;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblTituloCaja;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.DataGridView dgvGridReportadoPorSistema;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ids;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoPagos;
        private System.Windows.Forms.DataGridViewTextBoxColumn Montos;
        private System.Windows.Forms.DataGridViewTextBoxColumn Monedas;
        private System.Windows.Forms.Label lblNoCierre;
        private System.Windows.Forms.Timer tmTransition;
    }
}