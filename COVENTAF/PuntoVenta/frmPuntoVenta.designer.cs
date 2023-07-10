
namespace COVENTAF.PuntoVenta
{
    partial class frmPuntoVenta
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

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPuntoVenta));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cboTipoFiltro = new System.Windows.Forms.ComboBox();
            this.barraTitulo = new System.Windows.Forms.Panel();
            this.btnMinizar = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.pnRight = new System.Windows.Forms.Panel();
            this.pnlButtom = new System.Windows.Forms.Panel();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnConfigCajero = new System.Windows.Forms.Button();
            this.btnReimprimir = new System.Windows.Forms.Button();
            this.btnPrelectura = new System.Windows.Forms.Button();
            this.label21 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.btnAperturaCaja = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.button6 = new System.Windows.Forms.Button();
            this.btnAnularFactura2 = new System.Windows.Forms.Button();
            this.btnCierreCaja = new System.Windows.Forms.Button();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.panel5 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.lblNoCierre = new System.Windows.Forms.Label();
            this.lblCajaApertura = new System.Windows.Forms.Label();
            this.pictureBox26 = new System.Windows.Forms.PictureBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.pictureBox11 = new System.Windows.Forms.PictureBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtFacturaHasta = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtFacturaDesde = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtCaja = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtFechaHasta = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dtFechaDesde = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.panel9 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnNuevaFactura = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.btnRecibo = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnDevoluciones = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnAnularFactura = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.btnDetalleFactura = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.cboTransaccionRealizar = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.dgvPuntoVenta = new System.Windows.Forms.DataGridView();
            this.barraTitulo.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox26)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox11)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPuntoVenta)).BeginInit();
            this.SuspendLayout();
            // 
            // cboTipoFiltro
            // 
            this.cboTipoFiltro.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.cboTipoFiltro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoFiltro.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cboTipoFiltro.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold);
            this.cboTipoFiltro.ForeColor = System.Drawing.Color.Maroon;
            this.cboTipoFiltro.FormattingEnabled = true;
            this.cboTipoFiltro.Items.AddRange(new object[] {
            "No Factura",
            "No Recibo",
            "Factura del dia",
            "Recuperar Factura",
            "Devolucion",
            "Factura Anulada"});
            this.cboTipoFiltro.Location = new System.Drawing.Point(104, 160);
            this.cboTipoFiltro.Name = "cboTipoFiltro";
            this.cboTipoFiltro.Size = new System.Drawing.Size(220, 26);
            this.cboTipoFiltro.TabIndex = 26;
            // 
            // barraTitulo
            // 
            this.barraTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(99)))), ((int)(((byte)(177)))));
            this.barraTitulo.Controls.Add(this.btnMinizar);
            this.barraTitulo.Controls.Add(this.btnCerrar);
            this.barraTitulo.Controls.Add(this.button1);
            this.barraTitulo.Controls.Add(this.button2);
            this.barraTitulo.Controls.Add(this.lblTitulo);
            this.barraTitulo.Cursor = System.Windows.Forms.Cursors.Default;
            this.barraTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.barraTitulo.Location = new System.Drawing.Point(0, 0);
            this.barraTitulo.Name = "barraTitulo";
            this.barraTitulo.Size = new System.Drawing.Size(1136, 22);
            this.barraTitulo.TabIndex = 28;
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
            this.btnMinizar.Location = new System.Drawing.Point(1088, 4);
            this.btnMinizar.Name = "btnMinizar";
            this.btnMinizar.Size = new System.Drawing.Size(11, 13);
            this.btnMinizar.TabIndex = 12;
            this.btnMinizar.UseVisualStyleBackColor = true;
            this.btnMinizar.Visible = false;
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
            this.btnCerrar.Location = new System.Drawing.Point(1114, 4);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(11, 13);
            this.btnCerrar.TabIndex = 11;
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Image = global::COVENTAF.Properties.Resources.Icono_Minimizar;
            this.button1.Location = new System.Drawing.Point(1614, -33);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(40, 40);
            this.button1.TabIndex = 10;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Image = global::COVENTAF.Properties.Resources.Icono_cerrar_FN;
            this.button2.Location = new System.Drawing.Point(1658, -33);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(40, 40);
            this.button2.TabIndex = 9;
            this.button2.UseVisualStyleBackColor = true;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.lblTitulo.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(3, 3);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(106, 16);
            this.lblTitulo.TabIndex = 8;
            this.lblTitulo.Text = "Punto de Venta";
            // 
            // pnRight
            // 
            this.pnRight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(99)))), ((int)(((byte)(177)))));
            this.pnRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnRight.Location = new System.Drawing.Point(1132, 22);
            this.pnRight.Name = "pnRight";
            this.pnRight.Size = new System.Drawing.Size(4, 654);
            this.pnRight.TabIndex = 147;
            // 
            // pnlButtom
            // 
            this.pnlButtom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(99)))), ((int)(((byte)(177)))));
            this.pnlButtom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButtom.Location = new System.Drawing.Point(0, 672);
            this.pnlButtom.Name = "pnlButtom";
            this.pnlButtom.Size = new System.Drawing.Size(1132, 4);
            this.pnlButtom.TabIndex = 149;
            // 
            // pnlLeft
            // 
            this.pnlLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(99)))), ((int)(((byte)(177)))));
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(0, 22);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(4, 650);
            this.pnlLeft.TabIndex = 150;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(34)))), ((int)(((byte)(69)))));
            this.panel1.Controls.Add(this.btnConfigCajero);
            this.panel1.Controls.Add(this.btnReimprimir);
            this.panel1.Controls.Add(this.btnPrelectura);
            this.panel1.Controls.Add(this.label21);
            this.panel1.Controls.Add(this.panel6);
            this.panel1.Controls.Add(this.btnAperturaCaja);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.button6);
            this.panel1.Controls.Add(this.btnAnularFactura2);
            this.panel1.Controls.Add(this.btnCierreCaja);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(1136, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(159, 676);
            this.panel1.TabIndex = 152;
            // 
            // btnConfigCajero
            // 
            this.btnConfigCajero.FlatAppearance.BorderColor = System.Drawing.Color.DarkGoldenrod;
            this.btnConfigCajero.FlatAppearance.BorderSize = 0;
            this.btnConfigCajero.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(50)))), ((int)(((byte)(70)))));
            this.btnConfigCajero.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(61)))), ((int)(((byte)(92)))));
            this.btnConfigCajero.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfigCajero.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.btnConfigCajero.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnConfigCajero.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConfigCajero.Location = new System.Drawing.Point(6, 340);
            this.btnConfigCajero.Margin = new System.Windows.Forms.Padding(2);
            this.btnConfigCajero.Name = "btnConfigCajero";
            this.btnConfigCajero.Size = new System.Drawing.Size(146, 35);
            this.btnConfigCajero.TabIndex = 151;
            this.btnConfigCajero.Text = "Config. Cajero";
            this.btnConfigCajero.UseVisualStyleBackColor = true;
            this.btnConfigCajero.Click += new System.EventHandler(this.btnConfigCajero_Click);
            // 
            // btnReimprimir
            // 
            this.btnReimprimir.FlatAppearance.BorderColor = System.Drawing.Color.DarkGoldenrod;
            this.btnReimprimir.FlatAppearance.BorderSize = 0;
            this.btnReimprimir.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(50)))), ((int)(((byte)(70)))));
            this.btnReimprimir.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(61)))), ((int)(((byte)(92)))));
            this.btnReimprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReimprimir.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.btnReimprimir.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnReimprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReimprimir.Location = new System.Drawing.Point(6, 290);
            this.btnReimprimir.Margin = new System.Windows.Forms.Padding(2);
            this.btnReimprimir.Name = "btnReimprimir";
            this.btnReimprimir.Size = new System.Drawing.Size(146, 35);
            this.btnReimprimir.TabIndex = 150;
            this.btnReimprimir.Text = "&Reimprimir";
            this.btnReimprimir.UseVisualStyleBackColor = true;
            this.btnReimprimir.Click += new System.EventHandler(this.btnReimprimir_Click);
            // 
            // btnPrelectura
            // 
            this.btnPrelectura.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrelectura.FlatAppearance.BorderColor = System.Drawing.Color.DarkGoldenrod;
            this.btnPrelectura.FlatAppearance.BorderSize = 0;
            this.btnPrelectura.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(50)))), ((int)(((byte)(70)))));
            this.btnPrelectura.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(61)))), ((int)(((byte)(92)))));
            this.btnPrelectura.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrelectura.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.btnPrelectura.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnPrelectura.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrelectura.Location = new System.Drawing.Point(3, 88);
            this.btnPrelectura.Margin = new System.Windows.Forms.Padding(2);
            this.btnPrelectura.Name = "btnPrelectura";
            this.btnPrelectura.Size = new System.Drawing.Size(150, 35);
            this.btnPrelectura.TabIndex = 149;
            this.btnPrelectura.Text = "&Prelectura";
            this.btnPrelectura.UseVisualStyleBackColor = true;
            this.btnPrelectura.Click += new System.EventHandler(this.btnPrelectura_Click);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Bahnschrift Condensed", 14.25F);
            this.label21.ForeColor = System.Drawing.Color.White;
            this.label21.Location = new System.Drawing.Point(44, 256);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(72, 23);
            this.label21.TabIndex = 148;
            this.label21.Text = "Consultas";
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.White;
            this.panel6.Location = new System.Drawing.Point(28, 242);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(110, 2);
            this.panel6.TabIndex = 147;
            // 
            // btnAperturaCaja
            // 
            this.btnAperturaCaja.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAperturaCaja.FlatAppearance.BorderColor = System.Drawing.Color.DarkGoldenrod;
            this.btnAperturaCaja.FlatAppearance.BorderSize = 0;
            this.btnAperturaCaja.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(50)))), ((int)(((byte)(70)))));
            this.btnAperturaCaja.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(61)))), ((int)(((byte)(92)))));
            this.btnAperturaCaja.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAperturaCaja.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.btnAperturaCaja.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnAperturaCaja.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAperturaCaja.Location = new System.Drawing.Point(2, 42);
            this.btnAperturaCaja.Margin = new System.Windows.Forms.Padding(2);
            this.btnAperturaCaja.Name = "btnAperturaCaja";
            this.btnAperturaCaja.Size = new System.Drawing.Size(155, 35);
            this.btnAperturaCaja.TabIndex = 5;
            this.btnAperturaCaja.Text = "&Apertura de Caja";
            this.btnAperturaCaja.UseVisualStyleBackColor = true;
            this.btnAperturaCaja.Click += new System.EventHandler(this.btnAperturaCaja_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Bahnschrift Condensed", 18F);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(21, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 29);
            this.label3.TabIndex = 4;
            this.label3.Text = "Punto de Venta";
            // 
            // button6
            // 
            this.button6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button6.FlatAppearance.BorderSize = 0;
            this.button6.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(50)))), ((int)(((byte)(70)))));
            this.button6.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(61)))), ((int)(((byte)(92)))));
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.button6.ForeColor = System.Drawing.Color.Gainsboro;
            this.button6.Image = global::COVENTAF.Properties.Resources.logout;
            this.button6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button6.Location = new System.Drawing.Point(2, 1390);
            this.button6.Margin = new System.Windows.Forms.Padding(2);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(161, 35);
            this.button6.TabIndex = 2;
            this.button6.Text = "Salir del Sistema";
            this.button6.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button6.UseVisualStyleBackColor = true;
            // 
            // btnAnularFactura2
            // 
            this.btnAnularFactura2.FlatAppearance.BorderColor = System.Drawing.Color.DarkGoldenrod;
            this.btnAnularFactura2.FlatAppearance.BorderSize = 0;
            this.btnAnularFactura2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(50)))), ((int)(((byte)(70)))));
            this.btnAnularFactura2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(61)))), ((int)(((byte)(92)))));
            this.btnAnularFactura2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnularFactura2.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.btnAnularFactura2.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnAnularFactura2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAnularFactura2.Location = new System.Drawing.Point(0, 175);
            this.btnAnularFactura2.Margin = new System.Windows.Forms.Padding(2);
            this.btnAnularFactura2.Name = "btnAnularFactura2";
            this.btnAnularFactura2.Size = new System.Drawing.Size(157, 35);
            this.btnAnularFactura2.TabIndex = 0;
            this.btnAnularFactura2.Text = "&Anular Factura";
            this.btnAnularFactura2.UseVisualStyleBackColor = true;
            this.btnAnularFactura2.Click += new System.EventHandler(this.btnAnularFactura_Click);
            // 
            // btnCierreCaja
            // 
            this.btnCierreCaja.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCierreCaja.FlatAppearance.BorderColor = System.Drawing.Color.DarkGoldenrod;
            this.btnCierreCaja.FlatAppearance.BorderSize = 0;
            this.btnCierreCaja.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(50)))), ((int)(((byte)(70)))));
            this.btnCierreCaja.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(61)))), ((int)(((byte)(92)))));
            this.btnCierreCaja.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCierreCaja.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.btnCierreCaja.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnCierreCaja.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCierreCaja.Location = new System.Drawing.Point(2, 131);
            this.btnCierreCaja.Margin = new System.Windows.Forms.Padding(2);
            this.btnCierreCaja.Name = "btnCierreCaja";
            this.btnCierreCaja.Size = new System.Drawing.Size(150, 35);
            this.btnCierreCaja.TabIndex = 0;
            this.btnCierreCaja.Text = "&Cierre de Caja";
            this.btnCierreCaja.UseVisualStyleBackColor = true;
            this.btnCierreCaja.Click += new System.EventHandler(this.btnCierreCaja_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(45)))), ((int)(((byte)(64)))));
            this.panel5.Controls.Add(this.pictureBox2);
            this.panel5.Controls.Add(this.lblNoCierre);
            this.panel5.Controls.Add(this.lblCajaApertura);
            this.panel5.Controls.Add(this.pictureBox26);
            this.panel5.Controls.Add(this.label10);
            this.panel5.Controls.Add(this.label20);
            this.panel5.Controls.Add(this.pictureBox11);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(4, 22);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1128, 74);
            this.panel5.TabIndex = 155;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Image = global::COVENTAF.Properties.Resources.logo;
            this.pictureBox2.Location = new System.Drawing.Point(774, 9);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(351, 48);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 146;
            this.pictureBox2.TabStop = false;
            // 
            // lblNoCierre
            // 
            this.lblNoCierre.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblNoCierre.AutoSize = true;
            this.lblNoCierre.BackColor = System.Drawing.Color.Transparent;
            this.lblNoCierre.Font = new System.Drawing.Font("Bahnschrift Condensed", 15.75F);
            this.lblNoCierre.ForeColor = System.Drawing.Color.SeaShell;
            this.lblNoCierre.Location = new System.Drawing.Point(347, 38);
            this.lblNoCierre.Name = "lblNoCierre";
            this.lblNoCierre.Size = new System.Drawing.Size(84, 25);
            this.lblNoCierre.TabIndex = 145;
            this.lblNoCierre.Text = "No. Cierre:";
            // 
            // lblCajaApertura
            // 
            this.lblCajaApertura.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblCajaApertura.AutoSize = true;
            this.lblCajaApertura.BackColor = System.Drawing.Color.Transparent;
            this.lblCajaApertura.Font = new System.Drawing.Font("Bahnschrift Condensed", 15.75F);
            this.lblCajaApertura.ForeColor = System.Drawing.Color.SeaShell;
            this.lblCajaApertura.Location = new System.Drawing.Point(300, 7);
            this.lblCajaApertura.Name = "lblCajaApertura";
            this.lblCajaApertura.Size = new System.Drawing.Size(282, 25);
            this.lblCajaApertura.TabIndex = 144;
            this.lblCajaApertura.Text = "Caja de Apertura: Sin Apertura de Caja";
            // 
            // pictureBox26
            // 
            this.pictureBox26.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox26.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox26.Image = global::COVENTAF.Properties.Resources.logo;
            this.pictureBox26.Location = new System.Drawing.Point(2345, 3);
            this.pictureBox26.Name = "pictureBox26";
            this.pictureBox26.Size = new System.Drawing.Size(351, 48);
            this.pictureBox26.TabIndex = 143;
            this.pictureBox26.TabStop = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold);
            this.label10.ForeColor = System.Drawing.Color.Gold;
            this.label10.Location = new System.Drawing.Point(9, 7);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(121, 30);
            this.label10.TabIndex = 140;
            this.label10.Text = "COVENTAF";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.BackColor = System.Drawing.Color.Transparent;
            this.label20.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold);
            this.label20.ForeColor = System.Drawing.Color.SeaShell;
            this.label20.Location = new System.Drawing.Point(29, 39);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(151, 23);
            this.label20.TabIndex = 141;
            this.label20.Text = "Punto de Venta";
            // 
            // pictureBox11
            // 
            this.pictureBox11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox11.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox11.Image = global::COVENTAF.Properties.Resources.logo;
            this.pictureBox11.Location = new System.Drawing.Point(3050, 2);
            this.pictureBox11.Name = "pictureBox11";
            this.pictureBox11.Size = new System.Drawing.Size(351, 48);
            this.pictureBox11.TabIndex = 142;
            this.pictureBox11.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtFacturaHasta);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.txtFacturaDesde);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(24)))), ((int)(((byte)(72)))));
            this.groupBox3.Location = new System.Drawing.Point(773, 151);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(206, 107);
            this.groupBox3.TabIndex = 158;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Buscar No Facturas";
            // 
            // txtFacturaHasta
            // 
            this.txtFacturaHasta.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtFacturaHasta.Location = new System.Drawing.Point(80, 63);
            this.txtFacturaHasta.MaxLength = 20;
            this.txtFacturaHasta.Name = "txtFacturaHasta";
            this.txtFacturaHasta.Size = new System.Drawing.Size(111, 28);
            this.txtFacturaHasta.TabIndex = 153;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(24)))), ((int)(((byte)(72)))));
            this.label6.Location = new System.Drawing.Point(17, 66);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 20);
            this.label6.TabIndex = 152;
            this.label6.Text = "Hasta:";
            // 
            // txtFacturaDesde
            // 
            this.txtFacturaDesde.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtFacturaDesde.Location = new System.Drawing.Point(80, 26);
            this.txtFacturaDesde.MaxLength = 20;
            this.txtFacturaDesde.Name = "txtFacturaDesde";
            this.txtFacturaDesde.Size = new System.Drawing.Size(111, 28);
            this.txtFacturaDesde.TabIndex = 151;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(24)))), ((int)(((byte)(72)))));
            this.label4.Location = new System.Drawing.Point(17, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 20);
            this.label4.TabIndex = 148;
            this.label4.Text = "Desde:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtCaja);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(24)))), ((int)(((byte)(72)))));
            this.groupBox2.Location = new System.Drawing.Point(559, 151);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(205, 107);
            this.groupBox2.TabIndex = 157;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Buscar por Caja";
            // 
            // txtCaja
            // 
            this.txtCaja.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCaja.Location = new System.Drawing.Point(66, 42);
            this.txtCaja.MaxLength = 10;
            this.txtCaja.Name = "txtCaja";
            this.txtCaja.Size = new System.Drawing.Size(126, 28);
            this.txtCaja.TabIndex = 151;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(24)))), ((int)(((byte)(72)))));
            this.label5.Location = new System.Drawing.Point(15, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 20);
            this.label5.TabIndex = 148;
            this.label5.Text = "Caja:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtFechaHasta);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dtFechaDesde);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(24)))), ((int)(((byte)(72)))));
            this.groupBox1.Location = new System.Drawing.Point(339, 151);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(214, 107);
            this.groupBox1.TabIndex = 156;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Fecha de la factura";
            // 
            // dtFechaHasta
            // 
            this.dtFechaHasta.CalendarForeColor = System.Drawing.Color.Indigo;
            this.dtFechaHasta.CalendarTitleForeColor = System.Drawing.Color.Indigo;
            this.dtFechaHasta.CalendarTrailingForeColor = System.Drawing.Color.Indigo;
            this.dtFechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFechaHasta.Location = new System.Drawing.Point(73, 67);
            this.dtFechaHasta.Name = "dtFechaHasta";
            this.dtFechaHasta.Size = new System.Drawing.Size(128, 28);
            this.dtFechaHasta.TabIndex = 152;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(24)))), ((int)(((byte)(72)))));
            this.label1.Location = new System.Drawing.Point(10, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 20);
            this.label1.TabIndex = 151;
            this.label1.Text = "Hasta:";
            // 
            // dtFechaDesde
            // 
            this.dtFechaDesde.CalendarForeColor = System.Drawing.Color.Indigo;
            this.dtFechaDesde.CalendarTitleForeColor = System.Drawing.Color.Indigo;
            this.dtFechaDesde.CalendarTrailingForeColor = System.Drawing.Color.Indigo;
            this.dtFechaDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFechaDesde.Location = new System.Drawing.Point(73, 26);
            this.dtFechaDesde.Name = "dtFechaDesde";
            this.dtFechaDesde.Size = new System.Drawing.Size(128, 28);
            this.dtFechaDesde.TabIndex = 150;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(24)))), ((int)(((byte)(72)))));
            this.label2.Location = new System.Drawing.Point(10, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 20);
            this.label2.TabIndex = 148;
            this.label2.Text = "Desde:";
            // 
            // panel9
            // 
            this.panel9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.panel9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel9.Location = new System.Drawing.Point(4, 264);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(1129, 7);
            this.panel9.TabIndex = 171;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(24)))), ((int)(((byte)(72)))));
            this.label7.Location = new System.Drawing.Point(28, 164);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(61, 20);
            this.label7.TabIndex = 183;
            this.label7.Text = "Buscar:";
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.White;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNuevaFactura,
            this.toolStripSeparator5,
            this.btnRecibo,
            this.toolStripSeparator1,
            this.btnDevoluciones,
            this.toolStripSeparator3,
            this.btnAnularFactura,
            this.toolStripSeparator4,
            this.btnDetalleFactura,
            this.toolStripSeparator2});
            this.toolStrip1.Location = new System.Drawing.Point(4, 96);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1128, 39);
            this.toolStrip1.TabIndex = 184;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnNuevaFactura
            // 
            this.btnNuevaFactura.BackColor = System.Drawing.Color.Transparent;
            this.btnNuevaFactura.Enabled = false;
            this.btnNuevaFactura.Font = new System.Drawing.Font("Bahnschrift Condensed", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevaFactura.ForeColor = System.Drawing.Color.Maroon;
            this.btnNuevaFactura.Image = ((System.Drawing.Image)(resources.GetObject("btnNuevaFactura.Image")));
            this.btnNuevaFactura.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnNuevaFactura.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNuevaFactura.Name = "btnNuevaFactura";
            this.btnNuevaFactura.Size = new System.Drawing.Size(128, 36);
            this.btnNuevaFactura.Text = "Facturar - F1";
            this.btnNuevaFactura.Click += new System.EventHandler(this.btnNuevaFactura_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.toolStripSeparator5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 39);
            // 
            // btnRecibo
            // 
            this.btnRecibo.Font = new System.Drawing.Font("Bahnschrift Condensed", 14.25F);
            this.btnRecibo.ForeColor = System.Drawing.Color.Maroon;
            this.btnRecibo.Image = ((System.Drawing.Image)(resources.GetObject("btnRecibo.Image")));
            this.btnRecibo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnRecibo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRecibo.Name = "btnRecibo";
            this.btnRecibo.Size = new System.Drawing.Size(110, 36);
            this.btnRecibo.Text = "Recibo-F2";
            this.btnRecibo.Click += new System.EventHandler(this.btnRecibo_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 39);
            // 
            // btnDevoluciones
            // 
            this.btnDevoluciones.Font = new System.Drawing.Font("Bahnschrift Condensed", 14.25F);
            this.btnDevoluciones.ForeColor = System.Drawing.Color.Maroon;
            this.btnDevoluciones.Image = ((System.Drawing.Image)(resources.GetObject("btnDevoluciones.Image")));
            this.btnDevoluciones.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnDevoluciones.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDevoluciones.Name = "btnDevoluciones";
            this.btnDevoluciones.Size = new System.Drawing.Size(135, 36);
            this.btnDevoluciones.Text = "Devolucion-F3";
            this.btnDevoluciones.Click += new System.EventHandler(this.btnDevoluciones_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 39);
            // 
            // btnAnularFactura
            // 
            this.btnAnularFactura.Enabled = false;
            this.btnAnularFactura.Font = new System.Drawing.Font("Bahnschrift Condensed", 14.25F);
            this.btnAnularFactura.ForeColor = System.Drawing.Color.Maroon;
            this.btnAnularFactura.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnAnularFactura.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAnularFactura.Name = "btnAnularFactura";
            this.btnAnularFactura.Size = new System.Drawing.Size(135, 36);
            this.btnAnularFactura.Text = "Anular Factura- F4";
            this.btnAnularFactura.Visible = false;
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 39);
            this.toolStripSeparator4.Visible = false;
            // 
            // btnDetalleFactura
            // 
            this.btnDetalleFactura.Font = new System.Drawing.Font("Bahnschrift Condensed", 14.25F);
            this.btnDetalleFactura.ForeColor = System.Drawing.Color.Maroon;
            this.btnDetalleFactura.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDetalleFactura.Name = "btnDetalleFactura";
            this.btnDetalleFactura.Size = new System.Drawing.Size(140, 36);
            this.btnDetalleFactura.Text = "Detalle Factura - F5";
            this.btnDetalleFactura.Click += new System.EventHandler(this.btnDetalleFactura_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 39);
            // 
            // cboTransaccionRealizar
            // 
            this.cboTransaccionRealizar.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.cboTransaccionRealizar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTransaccionRealizar.Enabled = false;
            this.cboTransaccionRealizar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cboTransaccionRealizar.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold);
            this.cboTransaccionRealizar.ForeColor = System.Drawing.Color.Maroon;
            this.cboTransaccionRealizar.FormattingEnabled = true;
            this.cboTransaccionRealizar.Items.AddRange(new object[] {
            "Default",
            "Anular",
            "Devolucion",
            "Editar Metodo Pago"});
            this.cboTransaccionRealizar.Location = new System.Drawing.Point(32, 232);
            this.cboTransaccionRealizar.Name = "cboTransaccionRealizar";
            this.cboTransaccionRealizar.Size = new System.Drawing.Size(292, 26);
            this.cboTransaccionRealizar.TabIndex = 185;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(24)))), ((int)(((byte)(72)))));
            this.label8.Location = new System.Drawing.Point(36, 204);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(163, 20);
            this.label8.TabIndex = 186;
            this.label8.Text = "Transacción a realizar:";
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(103)))), ((int)(((byte)(62)))));
            this.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscar.FlatAppearance.BorderSize = 0;
            this.btnBuscar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(92)))), ((int)(((byte)(133)))));
            this.btnBuscar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(50)))), ((int)(((byte)(97)))));
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnBuscar.Font = new System.Drawing.Font("Bahnschrift Condensed", 14.25F);
            this.btnBuscar.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnBuscar.Image = global::COVENTAF.Properties.Resources.buscar;
            this.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnBuscar.Location = new System.Drawing.Point(993, 189);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(2);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(132, 44);
            this.btnBuscar.TabIndex = 257;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // dgvPuntoVenta
            // 
            this.dgvPuntoVenta.AllowUserToAddRows = false;
            this.dgvPuntoVenta.AllowUserToDeleteRows = false;
            this.dgvPuntoVenta.AllowUserToResizeColumns = false;
            this.dgvPuntoVenta.AllowUserToResizeRows = false;
            this.dgvPuntoVenta.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPuntoVenta.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvPuntoVenta.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvPuntoVenta.BackgroundColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.dgvPuntoVenta.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.dgvPuntoVenta.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(103)))), ((int)(((byte)(62)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPuntoVenta.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPuntoVenta.ColumnHeadersHeight = 30;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.DarkGoldenrod;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPuntoVenta.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvPuntoVenta.EnableHeadersVisualStyles = false;
            this.dgvPuntoVenta.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dgvPuntoVenta.Location = new System.Drawing.Point(4, 269);
            this.dgvPuntoVenta.MultiSelect = false;
            this.dgvPuntoVenta.Name = "dgvPuntoVenta";
            this.dgvPuntoVenta.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPuntoVenta.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvPuntoVenta.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPuntoVenta.Size = new System.Drawing.Size(1128, 402);
            this.dgvPuntoVenta.TabIndex = 182;
            this.dgvPuntoVenta.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgvPuntoVenta_MouseDoubleClick);
            // 
            // frmPuntoVenta
            // 
            this.AcceptButton = this.btnBuscar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(191)))), ((int)(((byte)(215)))));
            this.ClientSize = new System.Drawing.Size(1295, 676);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cboTransaccionRealizar);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.dgvPuntoVenta);
            this.Controls.Add(this.panel9);
            this.Controls.Add(this.cboTipoFiltro);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.pnlLeft);
            this.Controls.Add(this.pnlButtom);
            this.Controls.Add(this.pnRight);
            this.Controls.Add(this.barraTitulo);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "frmPuntoVenta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Punto de Venta";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmPuntoVenta_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmPuntoVenta_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmPuntoVenta_KeyPress);
            this.barraTitulo.ResumeLayout(false);
            this.barraTitulo.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox26)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox11)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPuntoVenta)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }



        private System.Windows.Forms.ComboBox cboTipoFiltro;
        private System.Windows.Forms.Panel barraTitulo;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Button btnMinizar;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Panel pnRight;
        private System.Windows.Forms.Panel pnlButtom;
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button btnAnularFactura2;
        private System.Windows.Forms.Button btnCierreCaja;
        
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Button btnAperturaCaja;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label lblNoCierre;
        private System.Windows.Forms.Label lblCajaApertura;
        private System.Windows.Forms.PictureBox pictureBox26;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.PictureBox pictureBox11;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtFacturaHasta;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtFacturaDesde;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtCaja;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dtFechaHasta;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtFechaDesde;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnNuevaFactura;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton btnDevoluciones;
        private System.Windows.Forms.ComboBox cboTransaccionRealizar;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnPrelectura;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnReimprimir;
        private System.Windows.Forms.DataGridView dgvPuntoVenta;
        private System.Windows.Forms.Button btnConfigCajero;
        private System.Windows.Forms.ToolStripButton btnRecibo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btnAnularFactura;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton btnDetalleFactura;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    }
}