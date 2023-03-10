
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPuntoVenta));
            this.cboTipoFiltro = new System.Windows.Forms.ComboBox();
            this.txtBusqueda = new System.Windows.Forms.TextBox();
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
            this.label21 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.btnAperturaCaja = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.button6 = new System.Windows.Forms.Button();
            this.btnAnularFactura = new System.Windows.Forms.Button();
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
            this.dgvPuntoVenta = new System.Windows.Forms.DataGridView();
            this.label7 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnNuevaFactura = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.btnBusca = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnDevoluciones = new System.Windows.Forms.ToolStripButton();
            this.barraTitulo.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox26)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox11)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPuntoVenta)).BeginInit();
            this.toolStrip1.SuspendLayout();
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
            "Factura del dia",
            "Recuperar Factura",
            "No Factura",
            "Devolucion",
            "Rango de Fecha"});
            this.cboTipoFiltro.Location = new System.Drawing.Point(115, 181);
            this.cboTipoFiltro.Name = "cboTipoFiltro";
            this.cboTipoFiltro.Size = new System.Drawing.Size(220, 26);
            this.cboTipoFiltro.TabIndex = 26;
            this.cboTipoFiltro.SelectedIndexChanged += new System.EventHandler(this.cboTipoFiltro_SelectedIndexChanged);
            // 
            // txtBusqueda
            // 
            this.txtBusqueda.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.txtBusqueda.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBusqueda.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold);
            this.txtBusqueda.ForeColor = System.Drawing.Color.Maroon;
            this.txtBusqueda.Location = new System.Drawing.Point(356, 181);
            this.txtBusqueda.Name = "txtBusqueda";
            this.txtBusqueda.Size = new System.Drawing.Size(322, 26);
            this.txtBusqueda.TabIndex = 24;
            // 
            // barraTitulo
            // 
            this.barraTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(50)))), ((int)(((byte)(124)))));
            this.barraTitulo.Controls.Add(this.btnMinizar);
            this.barraTitulo.Controls.Add(this.btnCerrar);
            this.barraTitulo.Controls.Add(this.button1);
            this.barraTitulo.Controls.Add(this.button2);
            this.barraTitulo.Controls.Add(this.lblTitulo);
            this.barraTitulo.Cursor = System.Windows.Forms.Cursors.Default;
            this.barraTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.barraTitulo.Location = new System.Drawing.Point(0, 0);
            this.barraTitulo.Name = "barraTitulo";
            this.barraTitulo.Size = new System.Drawing.Size(990, 22);
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
            this.btnMinizar.Location = new System.Drawing.Point(942, 4);
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
            this.btnCerrar.Location = new System.Drawing.Point(968, 4);
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
            this.button1.Location = new System.Drawing.Point(1468, -33);
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
            this.button2.Location = new System.Drawing.Point(1512, -33);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(40, 40);
            this.button2.TabIndex = 9;
            this.button2.UseVisualStyleBackColor = true;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.lblTitulo.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(3, 3);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(110, 17);
            this.lblTitulo.TabIndex = 8;
            this.lblTitulo.Text = "Punto de Venta";
            // 
            // pnRight
            // 
            this.pnRight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(50)))), ((int)(((byte)(124)))));
            this.pnRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnRight.Location = new System.Drawing.Point(986, 22);
            this.pnRight.Name = "pnRight";
            this.pnRight.Size = new System.Drawing.Size(4, 654);
            this.pnRight.TabIndex = 147;
            // 
            // pnlButtom
            // 
            this.pnlButtom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(50)))), ((int)(((byte)(124)))));
            this.pnlButtom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButtom.Location = new System.Drawing.Point(0, 672);
            this.pnlButtom.Name = "pnlButtom";
            this.pnlButtom.Size = new System.Drawing.Size(986, 4);
            this.pnlButtom.TabIndex = 149;
            // 
            // pnlLeft
            // 
            this.pnlLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(50)))), ((int)(((byte)(124)))));
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(0, 22);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(4, 650);
            this.pnlLeft.TabIndex = 150;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(42)))), ((int)(((byte)(81)))));
            this.panel1.Controls.Add(this.label21);
            this.panel1.Controls.Add(this.panel6);
            this.panel1.Controls.Add(this.btnAperturaCaja);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.button6);
            this.panel1.Controls.Add(this.btnAnularFactura);
            this.panel1.Controls.Add(this.btnCierreCaja);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(990, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(159, 676);
            this.panel1.TabIndex = 152;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Bahnschrift Condensed", 14.25F);
            this.label21.ForeColor = System.Drawing.Color.White;
            this.label21.Location = new System.Drawing.Point(44, 206);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(72, 23);
            this.label21.TabIndex = 148;
            this.label21.Text = "Consultas";
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.White;
            this.panel6.Location = new System.Drawing.Point(28, 192);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(110, 2);
            this.panel6.TabIndex = 147;
            // 
            // btnAperturaCaja
            // 
            this.btnAperturaCaja.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAperturaCaja.FlatAppearance.BorderSize = 0;
            this.btnAperturaCaja.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(92)))), ((int)(((byte)(133)))));
            this.btnAperturaCaja.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(50)))), ((int)(((byte)(97)))));
            this.btnAperturaCaja.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAperturaCaja.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.btnAperturaCaja.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnAperturaCaja.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAperturaCaja.Location = new System.Drawing.Point(2, 42);
            this.btnAperturaCaja.Margin = new System.Windows.Forms.Padding(2);
            this.btnAperturaCaja.Name = "btnAperturaCaja";
            this.btnAperturaCaja.Size = new System.Drawing.Size(156, 35);
            this.btnAperturaCaja.TabIndex = 5;
            this.btnAperturaCaja.Text = "Apertura de Caja";
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
            // btnAnularFactura
            // 
            this.btnAnularFactura.FlatAppearance.BorderSize = 0;
            this.btnAnularFactura.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(92)))), ((int)(((byte)(133)))));
            this.btnAnularFactura.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(50)))), ((int)(((byte)(97)))));
            this.btnAnularFactura.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnularFactura.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.btnAnularFactura.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnAnularFactura.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAnularFactura.Location = new System.Drawing.Point(0, 127);
            this.btnAnularFactura.Margin = new System.Windows.Forms.Padding(2);
            this.btnAnularFactura.Name = "btnAnularFactura";
            this.btnAnularFactura.Size = new System.Drawing.Size(158, 35);
            this.btnAnularFactura.TabIndex = 0;
            this.btnAnularFactura.Text = "Anular Factura";
            this.btnAnularFactura.UseVisualStyleBackColor = true;
            this.btnAnularFactura.Click += new System.EventHandler(this.btnAnularFactura_Click);
            // 
            // btnCierreCaja
            // 
            this.btnCierreCaja.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCierreCaja.FlatAppearance.BorderSize = 0;
            this.btnCierreCaja.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(92)))), ((int)(((byte)(133)))));
            this.btnCierreCaja.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(50)))), ((int)(((byte)(97)))));
            this.btnCierreCaja.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCierreCaja.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.btnCierreCaja.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnCierreCaja.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCierreCaja.Location = new System.Drawing.Point(2, 83);
            this.btnCierreCaja.Margin = new System.Windows.Forms.Padding(2);
            this.btnCierreCaja.Name = "btnCierreCaja";
            this.btnCierreCaja.Size = new System.Drawing.Size(151, 35);
            this.btnCierreCaja.TabIndex = 0;
            this.btnCierreCaja.Text = "Cierre de Caja";
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
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(13)))), ((int)(((byte)(66)))));
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
            this.panel5.Size = new System.Drawing.Size(982, 66);
            this.panel5.TabIndex = 155;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Image = global::COVENTAF.Properties.Resources.logo;
            this.pictureBox2.Location = new System.Drawing.Point(628, 9);
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
            this.lblNoCierre.Location = new System.Drawing.Point(274, 34);
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
            this.lblCajaApertura.Location = new System.Drawing.Point(227, 7);
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
            this.pictureBox26.Location = new System.Drawing.Point(2199, 3);
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
            this.label10.Location = new System.Drawing.Point(9, 4);
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
            this.label20.Location = new System.Drawing.Point(29, 36);
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
            this.pictureBox11.Location = new System.Drawing.Point(2904, 2);
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
            this.groupBox3.ForeColor = System.Drawing.Color.Indigo;
            this.groupBox3.Location = new System.Drawing.Point(502, 234);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(242, 107);
            this.groupBox3.TabIndex = 158;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Buscar No Facturas";
            // 
            // txtFacturaHasta
            // 
            this.txtFacturaHasta.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtFacturaHasta.Location = new System.Drawing.Point(85, 63);
            this.txtFacturaHasta.MaxLength = 20;
            this.txtFacturaHasta.Name = "txtFacturaHasta";
            this.txtFacturaHasta.Size = new System.Drawing.Size(133, 27);
            this.txtFacturaHasta.TabIndex = 153;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Indigo;
            this.label6.Location = new System.Drawing.Point(17, 66);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 20);
            this.label6.TabIndex = 152;
            this.label6.Text = "Hasta:";
            // 
            // txtFacturaDesde
            // 
            this.txtFacturaDesde.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtFacturaDesde.Location = new System.Drawing.Point(85, 26);
            this.txtFacturaDesde.MaxLength = 20;
            this.txtFacturaDesde.Name = "txtFacturaDesde";
            this.txtFacturaDesde.Size = new System.Drawing.Size(133, 27);
            this.txtFacturaDesde.TabIndex = 151;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Indigo;
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
            this.groupBox2.ForeColor = System.Drawing.Color.Indigo;
            this.groupBox2.Location = new System.Drawing.Point(267, 234);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(228, 107);
            this.groupBox2.TabIndex = 157;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Buscar por Caja";
            // 
            // txtCaja
            // 
            this.txtCaja.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCaja.Location = new System.Drawing.Point(67, 47);
            this.txtCaja.MaxLength = 10;
            this.txtCaja.Name = "txtCaja";
            this.txtCaja.Size = new System.Drawing.Size(151, 27);
            this.txtCaja.TabIndex = 151;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Indigo;
            this.label5.Location = new System.Drawing.Point(16, 50);
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
            this.groupBox1.ForeColor = System.Drawing.Color.Indigo;
            this.groupBox1.Location = new System.Drawing.Point(18, 234);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(243, 107);
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
            this.dtFechaHasta.Location = new System.Drawing.Point(81, 67);
            this.dtFechaHasta.Name = "dtFechaHasta";
            this.dtFechaHasta.Size = new System.Drawing.Size(150, 27);
            this.dtFechaHasta.TabIndex = 152;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Indigo;
            this.label1.Location = new System.Drawing.Point(18, 70);
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
            this.dtFechaDesde.Location = new System.Drawing.Point(81, 26);
            this.dtFechaDesde.Name = "dtFechaDesde";
            this.dtFechaDesde.Size = new System.Drawing.Size(150, 27);
            this.dtFechaDesde.TabIndex = 150;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Indigo;
            this.label2.Location = new System.Drawing.Point(18, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 20);
            this.label2.TabIndex = 148;
            this.label2.Text = "Desde:";
            // 
            // panel9
            // 
            this.panel9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(13)))), ((int)(((byte)(66)))));
            this.panel9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel9.Location = new System.Drawing.Point(4, 217);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(983, 7);
            this.panel9.TabIndex = 171;
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
            this.dgvPuntoVenta.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.dgvPuntoVenta.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.dgvPuntoVenta.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Snow;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(13)))), ((int)(((byte)(66)))));
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
            this.dgvPuntoVenta.Location = new System.Drawing.Point(4, 371);
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
            this.dgvPuntoVenta.Size = new System.Drawing.Size(982, 300);
            this.dgvPuntoVenta.TabIndex = 182;
            this.dgvPuntoVenta.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgvPuntoVenta_MouseDoubleClick);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Indigo;
            this.label7.Location = new System.Drawing.Point(13, 184);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 20);
            this.label7.TabIndex = 183;
            this.label7.Text = "Filtrar por:";
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNuevaFactura,
            this.toolStripSeparator5,
            this.btnBusca,
            this.toolStripSeparator1,
            this.btnDevoluciones});
            this.toolStrip1.Location = new System.Drawing.Point(4, 88);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(982, 78);
            this.toolStrip1.TabIndex = 184;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnNuevaFactura
            // 
            this.btnNuevaFactura.BackColor = System.Drawing.Color.Transparent;
            this.btnNuevaFactura.Font = new System.Drawing.Font("Bahnschrift Condensed", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevaFactura.ForeColor = System.Drawing.Color.Maroon;
            this.btnNuevaFactura.Image = global::COVENTAF.Properties.Resources.add_notes_white;
            this.btnNuevaFactura.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnNuevaFactura.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNuevaFactura.Name = "btnNuevaFactura";
            this.btnNuevaFactura.Size = new System.Drawing.Size(130, 75);
            this.btnNuevaFactura.Text = "Nueva factura - F1";
            this.btnNuevaFactura.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnNuevaFactura.Click += new System.EventHandler(this.btnNuevaFactura_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.toolStripSeparator5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 78);
            // 
            // btnBusca
            // 
            this.btnBusca.BackColor = System.Drawing.Color.Transparent;
            this.btnBusca.Font = new System.Drawing.Font("Bahnschrift Condensed", 14.25F);
            this.btnBusca.ForeColor = System.Drawing.Color.Maroon;
            this.btnBusca.Image = global::COVENTAF.Properties.Resources.buscar;
            this.btnBusca.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnBusca.ImageTransparentColor = System.Drawing.Color.White;
            this.btnBusca.Name = "btnBusca";
            this.btnBusca.Size = new System.Drawing.Size(83, 75);
            this.btnBusca.Text = "Buscar- F2";
            this.btnBusca.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnBusca.ToolTipText = "Buscar F2";
            this.btnBusca.Click += new System.EventHandler(this.btnBusca_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 78);
            // 
            // btnDevoluciones
            // 
            this.btnDevoluciones.Font = new System.Drawing.Font("Bahnschrift Condensed", 14.25F);
            this.btnDevoluciones.ForeColor = System.Drawing.Color.Maroon;
            this.btnDevoluciones.Image = ((System.Drawing.Image)(resources.GetObject("btnDevoluciones.Image")));
            this.btnDevoluciones.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnDevoluciones.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDevoluciones.Name = "btnDevoluciones";
            this.btnDevoluciones.Size = new System.Drawing.Size(103, 75);
            this.btnDevoluciones.Text = "Devolucion-F3";
            this.btnDevoluciones.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnDevoluciones.Click += new System.EventHandler(this.btnDevoluciones_Click);
            // 
            // frmPuntoVenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(1149, 676);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dgvPuntoVenta);
            this.Controls.Add(this.panel9);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.cboTipoFiltro);
            this.Controls.Add(this.txtBusqueda);
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
            this.Load += new System.EventHandler(this.frmPuntoVenta_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmPuntoVenta_KeyDown);
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
            ((System.ComponentModel.ISupportInitialize)(this.dgvPuntoVenta)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }



        private System.Windows.Forms.ComboBox cboTipoFiltro;
        private System.Windows.Forms.TextBox txtBusqueda;
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
        private System.Windows.Forms.Button btnAnularFactura;
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
        private System.Windows.Forms.DataGridView dgvPuntoVenta;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnNuevaFactura;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton btnBusca;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnDevoluciones;
    }
}