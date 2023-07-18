
namespace COVENTAF.PuntoVenta
{
    partial class frmFiltroAvanzado
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFiltroAvanzado));
            this.barraTitulo = new System.Windows.Forms.Panel();
            this.btnCerrar = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox11 = new System.Windows.Forms.PictureBox();
            this.grpFechaFactura = new System.Windows.Forms.GroupBox();
            this.dtFechaHasta = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtFechaDesde = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.grpCaja = new System.Windows.Forms.GroupBox();
            this.txtCaja = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.grpFactura = new System.Windows.Forms.GroupBox();
            this.txtFacturaHasta = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtFacturaDesde = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.grpCliente = new System.Windows.Forms.GroupBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel25 = new System.Windows.Forms.Panel();
            this.btnBuscarCliente = new System.Windows.Forms.Button();
            this.txtNombreCliente = new System.Windows.Forms.TextBox();
            this.lblNombreCliente = new System.Windows.Forms.Label();
            this.txtCodigoCliente = new System.Windows.Forms.TextBox();
            this.lblCodigoCliente = new System.Windows.Forms.Label();
            this.grpArticulo = new System.Windows.Forms.GroupBox();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.txtNombreArticulo = new System.Windows.Forms.TextBox();
            this.lblNombreArticulo = new System.Windows.Forms.Label();
            this.txtCodigoArticulo = new System.Windows.Forms.TextBox();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.lblBuscarFiltro = new System.Windows.Forms.Label();
            this.cboTipoFiltro = new System.Windows.Forms.ComboBox();
            this.grpEstadoFactura = new System.Windows.Forms.GroupBox();
            this.chkAnuladas = new System.Windows.Forms.CheckBox();
            this.chkCobradas = new System.Windows.Forms.CheckBox();
            this.chkFacturaCredito = new System.Windows.Forms.CheckBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.ttpNotifcacion = new System.Windows.Forms.ToolTip(this.components);
            this.btnResetear = new System.Windows.Forms.Button();
            this.tmTransition = new System.Windows.Forms.Timer(this.components);
            this.barraTitulo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox11)).BeginInit();
            this.grpFechaFactura.SuspendLayout();
            this.grpCaja.SuspendLayout();
            this.grpFactura.SuspendLayout();
            this.grpCliente.SuspendLayout();
            this.grpArticulo.SuspendLayout();
            this.grpEstadoFactura.SuspendLayout();
            this.SuspendLayout();
            // 
            // barraTitulo
            // 
            this.barraTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(99)))), ((int)(((byte)(177)))));
            this.barraTitulo.Controls.Add(this.btnCerrar);
            this.barraTitulo.Controls.Add(this.pictureBox1);
            this.barraTitulo.Controls.Add(this.lblTitulo);
            this.barraTitulo.Cursor = System.Windows.Forms.Cursors.Default;
            this.barraTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.barraTitulo.Location = new System.Drawing.Point(0, 0);
            this.barraTitulo.Name = "barraTitulo";
            this.barraTitulo.Size = new System.Drawing.Size(705, 28);
            this.barraTitulo.TabIndex = 150;
            this.barraTitulo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.barraTitulo_MouseDown);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrar.Image = global::COVENTAF.Properties.Resources.close_login;
            this.btnCerrar.Location = new System.Drawing.Point(674, 3);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(21, 21);
            this.btnCerrar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnCerrar.TabIndex = 155;
            this.btnCerrar.TabStop = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = global::COVENTAF.Properties.Resources.close_login;
            this.pictureBox1.Location = new System.Drawing.Point(2383, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(21, 21);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.lblTitulo.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(4, 4);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(129, 19);
            this.lblTitulo.TabIndex = 8;
            this.lblTitulo.Text = "Filtro Avanzado";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(99)))), ((int)(((byte)(177)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(700, 28);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(5, 546);
            this.panel2.TabIndex = 151;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(99)))), ((int)(((byte)(177)))));
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 569);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(700, 5);
            this.panel3.TabIndex = 153;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(99)))), ((int)(((byte)(177)))));
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(5, 541);
            this.panel1.TabIndex = 154;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(45)))), ((int)(((byte)(64)))));
            this.panel5.Controls.Add(this.pictureBox2);
            this.panel5.Controls.Add(this.label1);
            this.panel5.Controls.Add(this.label3);
            this.panel5.Controls.Add(this.pictureBox11);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(5, 28);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(695, 74);
            this.panel5.TabIndex = 165;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(592, 5);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(100, 64);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 143;
            this.pictureBox2.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Gold;
            this.label1.Location = new System.Drawing.Point(9, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 30);
            this.label1.TabIndex = 140;
            this.label1.Text = "COVENTAF";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.SeaShell;
            this.label3.Location = new System.Drawing.Point(29, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(154, 23);
            this.label3.TabIndex = 141;
            this.label3.Text = "Filtro Avanzado";
            // 
            // pictureBox11
            // 
            this.pictureBox11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox11.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox11.Image = global::COVENTAF.Properties.Resources.logo;
            this.pictureBox11.Location = new System.Drawing.Point(2617, 2);
            this.pictureBox11.Name = "pictureBox11";
            this.pictureBox11.Size = new System.Drawing.Size(351, 48);
            this.pictureBox11.TabIndex = 142;
            this.pictureBox11.TabStop = false;
            // 
            // grpFechaFactura
            // 
            this.grpFechaFactura.Controls.Add(this.dtFechaHasta);
            this.grpFechaFactura.Controls.Add(this.label2);
            this.grpFechaFactura.Controls.Add(this.dtFechaDesde);
            this.grpFechaFactura.Controls.Add(this.label4);
            this.grpFechaFactura.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Bold);
            this.grpFechaFactura.ForeColor = System.Drawing.Color.Maroon;
            this.grpFechaFactura.Location = new System.Drawing.Point(15, 319);
            this.grpFechaFactura.Name = "grpFechaFactura";
            this.grpFechaFactura.Size = new System.Drawing.Size(214, 96);
            this.grpFechaFactura.TabIndex = 166;
            this.grpFechaFactura.TabStop = false;
            this.grpFechaFactura.Text = "Fecha de la factura";
            // 
            // dtFechaHasta
            // 
            this.dtFechaHasta.CalendarForeColor = System.Drawing.Color.Indigo;
            this.dtFechaHasta.CalendarTitleForeColor = System.Drawing.Color.Indigo;
            this.dtFechaHasta.CalendarTrailingForeColor = System.Drawing.Color.Indigo;
            this.dtFechaHasta.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold);
            this.dtFechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFechaHasta.Location = new System.Drawing.Point(73, 60);
            this.dtFechaHasta.Name = "dtFechaHasta";
            this.dtFechaHasta.Size = new System.Drawing.Size(128, 26);
            this.dtFechaHasta.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(24)))), ((int)(((byte)(72)))));
            this.label2.Location = new System.Drawing.Point(10, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 21);
            this.label2.TabIndex = 151;
            this.label2.Text = "Hasta:";
            // 
            // dtFechaDesde
            // 
            this.dtFechaDesde.CalendarForeColor = System.Drawing.Color.Indigo;
            this.dtFechaDesde.CalendarTitleForeColor = System.Drawing.Color.Indigo;
            this.dtFechaDesde.CalendarTrailingForeColor = System.Drawing.Color.Indigo;
            this.dtFechaDesde.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold);
            this.dtFechaDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFechaDesde.Location = new System.Drawing.Point(73, 26);
            this.dtFechaDesde.Name = "dtFechaDesde";
            this.dtFechaDesde.Size = new System.Drawing.Size(128, 26);
            this.dtFechaDesde.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(24)))), ((int)(((byte)(72)))));
            this.label4.Location = new System.Drawing.Point(10, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 21);
            this.label4.TabIndex = 148;
            this.label4.Text = "Desde:";
            // 
            // grpCaja
            // 
            this.grpCaja.Controls.Add(this.txtCaja);
            this.grpCaja.Controls.Add(this.label5);
            this.grpCaja.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Bold);
            this.grpCaja.ForeColor = System.Drawing.Color.Maroon;
            this.grpCaja.Location = new System.Drawing.Point(235, 319);
            this.grpCaja.Name = "grpCaja";
            this.grpCaja.Size = new System.Drawing.Size(191, 96);
            this.grpCaja.TabIndex = 167;
            this.grpCaja.TabStop = false;
            this.grpCaja.Text = "Buscar por Caja";
            // 
            // txtCaja
            // 
            this.txtCaja.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCaja.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold);
            this.txtCaja.Location = new System.Drawing.Point(66, 42);
            this.txtCaja.MaxLength = 10;
            this.txtCaja.Name = "txtCaja";
            this.txtCaja.Size = new System.Drawing.Size(119, 26);
            this.txtCaja.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(24)))), ((int)(((byte)(72)))));
            this.label5.Location = new System.Drawing.Point(10, 44);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 21);
            this.label5.TabIndex = 148;
            this.label5.Text = "Caja:";
            // 
            // grpFactura
            // 
            this.grpFactura.Controls.Add(this.txtFacturaHasta);
            this.grpFactura.Controls.Add(this.label6);
            this.grpFactura.Controls.Add(this.txtFacturaDesde);
            this.grpFactura.Controls.Add(this.label7);
            this.grpFactura.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Bold);
            this.grpFactura.ForeColor = System.Drawing.Color.Maroon;
            this.grpFactura.Location = new System.Drawing.Point(432, 318);
            this.grpFactura.Name = "grpFactura";
            this.grpFactura.Size = new System.Drawing.Size(258, 96);
            this.grpFactura.TabIndex = 168;
            this.grpFactura.TabStop = false;
            this.grpFactura.Text = "Buscar No Facturas";
            // 
            // txtFacturaHasta
            // 
            this.txtFacturaHasta.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtFacturaHasta.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold);
            this.txtFacturaHasta.Location = new System.Drawing.Point(80, 59);
            this.txtFacturaHasta.MaxLength = 20;
            this.txtFacturaHasta.Name = "txtFacturaHasta";
            this.txtFacturaHasta.Size = new System.Drawing.Size(162, 26);
            this.txtFacturaHasta.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(24)))), ((int)(((byte)(72)))));
            this.label6.Location = new System.Drawing.Point(17, 62);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 21);
            this.label6.TabIndex = 152;
            this.label6.Text = "Hasta:";
            // 
            // txtFacturaDesde
            // 
            this.txtFacturaDesde.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtFacturaDesde.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold);
            this.txtFacturaDesde.Location = new System.Drawing.Point(80, 26);
            this.txtFacturaDesde.MaxLength = 20;
            this.txtFacturaDesde.Name = "txtFacturaDesde";
            this.txtFacturaDesde.Size = new System.Drawing.Size(162, 26);
            this.txtFacturaDesde.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(24)))), ((int)(((byte)(72)))));
            this.label7.Location = new System.Drawing.Point(17, 29);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 21);
            this.label7.TabIndex = 148;
            this.label7.Text = "Desde:";
            // 
            // grpCliente
            // 
            this.grpCliente.Controls.Add(this.panel4);
            this.grpCliente.Controls.Add(this.panel25);
            this.grpCliente.Controls.Add(this.btnBuscarCliente);
            this.grpCliente.Controls.Add(this.txtNombreCliente);
            this.grpCliente.Controls.Add(this.lblNombreCliente);
            this.grpCliente.Controls.Add(this.txtCodigoCliente);
            this.grpCliente.Controls.Add(this.lblCodigoCliente);
            this.grpCliente.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Bold);
            this.grpCliente.ForeColor = System.Drawing.Color.Maroon;
            this.grpCliente.Location = new System.Drawing.Point(19, 162);
            this.grpCliente.Name = "grpCliente";
            this.grpCliente.Size = new System.Drawing.Size(667, 75);
            this.grpCliente.TabIndex = 169;
            this.grpCliente.TabStop = false;
            this.grpCliente.Text = "Cliente";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(91)))), ((int)(((byte)(13)))));
            this.panel4.Location = new System.Drawing.Point(336, 59);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(321, 2);
            this.panel4.TabIndex = 225;
            // 
            // panel25
            // 
            this.panel25.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(91)))), ((int)(((byte)(13)))));
            this.panel25.Location = new System.Drawing.Point(76, 58);
            this.panel25.Name = "panel25";
            this.panel25.Size = new System.Drawing.Size(126, 2);
            this.panel25.TabIndex = 224;
            // 
            // btnBuscarCliente
            // 
            this.btnBuscarCliente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(191)))), ((int)(((byte)(215)))));
            this.btnBuscarCliente.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscarCliente.FlatAppearance.BorderSize = 0;
            this.btnBuscarCliente.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(191)))), ((int)(((byte)(215)))));
            this.btnBuscarCliente.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(191)))), ((int)(((byte)(215)))));
            this.btnBuscarCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarCliente.Font = new System.Drawing.Font("Bahnschrift Condensed", 14.25F);
            this.btnBuscarCliente.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnBuscarCliente.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscarCliente.Image")));
            this.btnBuscarCliente.Location = new System.Drawing.Point(210, 26);
            this.btnBuscarCliente.Margin = new System.Windows.Forms.Padding(2);
            this.btnBuscarCliente.Name = "btnBuscarCliente";
            this.btnBuscarCliente.Size = new System.Drawing.Size(50, 36);
            this.btnBuscarCliente.TabIndex = 217;
            this.btnBuscarCliente.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnBuscarCliente.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ttpNotifcacion.SetToolTip(this.btnBuscarCliente, "Buscar el Cliente");
            this.btnBuscarCliente.UseVisualStyleBackColor = false;
            this.btnBuscarCliente.Click += new System.EventHandler(this.btnBuscarCliente_Click);
            // 
            // txtNombreCliente
            // 
            this.txtNombreCliente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(191)))), ((int)(((byte)(215)))));
            this.txtNombreCliente.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNombreCliente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNombreCliente.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold);
            this.txtNombreCliente.Location = new System.Drawing.Point(337, 35);
            this.txtNombreCliente.MaxLength = 500;
            this.txtNombreCliente.Name = "txtNombreCliente";
            this.txtNombreCliente.Size = new System.Drawing.Size(321, 19);
            this.txtNombreCliente.TabIndex = 1;
            this.ttpNotifcacion.SetToolTip(this.txtNombreCliente, "Nombre Completo del cliente");
            // 
            // lblNombreCliente
            // 
            this.lblNombreCliente.AutoSize = true;
            this.lblNombreCliente.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblNombreCliente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(24)))), ((int)(((byte)(72)))));
            this.lblNombreCliente.Location = new System.Drawing.Point(265, 33);
            this.lblNombreCliente.Name = "lblNombreCliente";
            this.lblNombreCliente.Size = new System.Drawing.Size(66, 21);
            this.lblNombreCliente.TabIndex = 154;
            this.lblNombreCliente.Text = "Nombre";
            // 
            // txtCodigoCliente
            // 
            this.txtCodigoCliente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(191)))), ((int)(((byte)(215)))));
            this.txtCodigoCliente.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCodigoCliente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCodigoCliente.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodigoCliente.Location = new System.Drawing.Point(77, 33);
            this.txtCodigoCliente.MaxLength = 25;
            this.txtCodigoCliente.Name = "txtCodigoCliente";
            this.txtCodigoCliente.Size = new System.Drawing.Size(126, 19);
            this.txtCodigoCliente.TabIndex = 0;
            this.ttpNotifcacion.SetToolTip(this.txtCodigoCliente, "Codigo del Cliente");
            // 
            // lblCodigoCliente
            // 
            this.lblCodigoCliente.AutoSize = true;
            this.lblCodigoCliente.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblCodigoCliente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(24)))), ((int)(((byte)(72)))));
            this.lblCodigoCliente.Location = new System.Drawing.Point(13, 33);
            this.lblCodigoCliente.Name = "lblCodigoCliente";
            this.lblCodigoCliente.Size = new System.Drawing.Size(56, 21);
            this.lblCodigoCliente.TabIndex = 152;
            this.lblCodigoCliente.Text = "Codigo";
            // 
            // grpArticulo
            // 
            this.grpArticulo.Controls.Add(this.panel7);
            this.grpArticulo.Controls.Add(this.panel6);
            this.grpArticulo.Controls.Add(this.button1);
            this.grpArticulo.Controls.Add(this.txtNombreArticulo);
            this.grpArticulo.Controls.Add(this.lblNombreArticulo);
            this.grpArticulo.Controls.Add(this.txtCodigoArticulo);
            this.grpArticulo.Controls.Add(this.lblCodigo);
            this.grpArticulo.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Bold);
            this.grpArticulo.ForeColor = System.Drawing.Color.Maroon;
            this.grpArticulo.Location = new System.Drawing.Point(17, 243);
            this.grpArticulo.Name = "grpArticulo";
            this.grpArticulo.Size = new System.Drawing.Size(669, 67);
            this.grpArticulo.TabIndex = 170;
            this.grpArticulo.TabStop = false;
            this.grpArticulo.Text = "Articulo";
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(91)))), ((int)(((byte)(13)))));
            this.panel7.Location = new System.Drawing.Point(78, 50);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(128, 2);
            this.panel7.TabIndex = 227;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(91)))), ((int)(((byte)(13)))));
            this.panel6.Location = new System.Drawing.Point(351, 53);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(308, 2);
            this.panel6.TabIndex = 226;
            this.panel6.Visible = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(191)))), ((int)(((byte)(215)))));
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(191)))), ((int)(((byte)(215)))));
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(191)))), ((int)(((byte)(215)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Bahnschrift Condensed", 14.25F);
            this.button1.ForeColor = System.Drawing.Color.Gainsboro;
            this.button1.Image = global::COVENTAF.Properties.Resources.seek_search_48x48;
            this.button1.Location = new System.Drawing.Point(218, 21);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(50, 36);
            this.button1.TabIndex = 218;
            this.button1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ttpNotifcacion.SetToolTip(this.button1, "Buscar Articulo");
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Visible = false;
            // 
            // txtNombreArticulo
            // 
            this.txtNombreArticulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(191)))), ((int)(((byte)(215)))));
            this.txtNombreArticulo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNombreArticulo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNombreArticulo.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold);
            this.txtNombreArticulo.Location = new System.Drawing.Point(352, 30);
            this.txtNombreArticulo.MaxLength = 500;
            this.txtNombreArticulo.Name = "txtNombreArticulo";
            this.txtNombreArticulo.Size = new System.Drawing.Size(308, 19);
            this.txtNombreArticulo.TabIndex = 1;
            this.txtNombreArticulo.Visible = false;
            // 
            // lblNombreArticulo
            // 
            this.lblNombreArticulo.AutoSize = true;
            this.lblNombreArticulo.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreArticulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(24)))), ((int)(((byte)(72)))));
            this.lblNombreArticulo.Location = new System.Drawing.Point(280, 33);
            this.lblNombreArticulo.Name = "lblNombreArticulo";
            this.lblNombreArticulo.Size = new System.Drawing.Size(66, 21);
            this.lblNombreArticulo.TabIndex = 154;
            this.lblNombreArticulo.Text = "Nombre";
            this.lblNombreArticulo.Visible = false;
            // 
            // txtCodigoArticulo
            // 
            this.txtCodigoArticulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(191)))), ((int)(((byte)(215)))));
            this.txtCodigoArticulo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCodigoArticulo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCodigoArticulo.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold);
            this.txtCodigoArticulo.Location = new System.Drawing.Point(79, 26);
            this.txtCodigoArticulo.MaxLength = 25;
            this.txtCodigoArticulo.Name = "txtCodigoArticulo";
            this.txtCodigoArticulo.Size = new System.Drawing.Size(128, 19);
            this.txtCodigoArticulo.TabIndex = 0;
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCodigo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(24)))), ((int)(((byte)(72)))));
            this.lblCodigo.Location = new System.Drawing.Point(16, 29);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(56, 21);
            this.lblCodigo.TabIndex = 152;
            this.lblCodigo.Text = "Codigo";
            // 
            // lblBuscarFiltro
            // 
            this.lblBuscarFiltro.AutoSize = true;
            this.lblBuscarFiltro.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBuscarFiltro.ForeColor = System.Drawing.Color.Maroon;
            this.lblBuscarFiltro.Location = new System.Drawing.Point(19, 127);
            this.lblBuscarFiltro.Name = "lblBuscarFiltro";
            this.lblBuscarFiltro.Size = new System.Drawing.Size(94, 21);
            this.lblBuscarFiltro.TabIndex = 185;
            this.lblBuscarFiltro.Text = "Buscar por:";
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
            "Devolucion",
            "No Recibo"});
            this.cboTipoFiltro.Location = new System.Drawing.Point(119, 125);
            this.cboTipoFiltro.Name = "cboTipoFiltro";
            this.cboTipoFiltro.Size = new System.Drawing.Size(220, 26);
            this.cboTipoFiltro.TabIndex = 184;
            this.cboTipoFiltro.SelectedIndexChanged += new System.EventHandler(this.cboTipoFiltro_SelectedIndexChanged);
            // 
            // grpEstadoFactura
            // 
            this.grpEstadoFactura.Controls.Add(this.chkAnuladas);
            this.grpEstadoFactura.Controls.Add(this.chkCobradas);
            this.grpEstadoFactura.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Bold);
            this.grpEstadoFactura.ForeColor = System.Drawing.Color.Maroon;
            this.grpEstadoFactura.Location = new System.Drawing.Point(15, 417);
            this.grpEstadoFactura.Name = "grpEstadoFactura";
            this.grpEstadoFactura.Size = new System.Drawing.Size(278, 75);
            this.grpEstadoFactura.TabIndex = 186;
            this.grpEstadoFactura.TabStop = false;
            this.grpEstadoFactura.Text = "Estado";
            // 
            // chkAnuladas
            // 
            this.chkAnuladas.AutoSize = true;
            this.chkAnuladas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(24)))), ((int)(((byte)(72)))));
            this.chkAnuladas.Location = new System.Drawing.Point(167, 34);
            this.chkAnuladas.Name = "chkAnuladas";
            this.chkAnuladas.Size = new System.Drawing.Size(92, 25);
            this.chkAnuladas.TabIndex = 1;
            this.chkAnuladas.Text = "Anuladas";
            this.chkAnuladas.UseVisualStyleBackColor = true;
            // 
            // chkCobradas
            // 
            this.chkCobradas.AutoSize = true;
            this.chkCobradas.Checked = true;
            this.chkCobradas.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCobradas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(24)))), ((int)(((byte)(72)))));
            this.chkCobradas.Location = new System.Drawing.Point(26, 34);
            this.chkCobradas.Name = "chkCobradas";
            this.chkCobradas.Size = new System.Drawing.Size(94, 25);
            this.chkCobradas.TabIndex = 0;
            this.chkCobradas.Text = "Cobradas";
            this.chkCobradas.UseVisualStyleBackColor = true;
            // 
            // chkFacturaCredito
            // 
            this.chkFacturaCredito.AutoSize = true;
            this.chkFacturaCredito.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.chkFacturaCredito.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(24)))), ((int)(((byte)(72)))));
            this.chkFacturaCredito.Location = new System.Drawing.Point(334, 451);
            this.chkFacturaCredito.Name = "chkFacturaCredito";
            this.chkFacturaCredito.Size = new System.Drawing.Size(136, 21);
            this.chkFacturaCredito.TabIndex = 0;
            this.chkFacturaCredito.Text = "Factura al Credito";
            this.chkFacturaCredito.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackColor = System.Drawing.Color.Maroon;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(92)))), ((int)(((byte)(133)))));
            this.btnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(50)))), ((int)(((byte)(97)))));
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancel.Font = new System.Drawing.Font("Bahnschrift Condensed", 14.25F);
            this.btnCancel.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnCancel.Image = global::COVENTAF.Properties.Resources.cancelar;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(151, 509);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(113, 43);
            this.btnCancel.TabIndex = 216;
            this.btnCancel.Text = "&Cancelar";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(99)))), ((int)(((byte)(177)))));
            this.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscar.FlatAppearance.BorderSize = 0;
            this.btnBuscar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(92)))), ((int)(((byte)(133)))));
            this.btnBuscar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(50)))), ((int)(((byte)(97)))));
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnBuscar.Font = new System.Drawing.Font("Bahnschrift Condensed", 14.25F);
            this.btnBuscar.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnBuscar.Image = global::COVENTAF.Properties.Resources.comprobado;
            this.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscar.Location = new System.Drawing.Point(23, 509);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(2);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(112, 43);
            this.btnBuscar.TabIndex = 215;
            this.btnBuscar.Text = "&Buscar";
            this.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnResetear
            // 
            this.btnResetear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(191)))), ((int)(((byte)(215)))));
            this.btnResetear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnResetear.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnResetear.FlatAppearance.BorderSize = 0;
            this.btnResetear.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(191)))), ((int)(((byte)(215)))));
            this.btnResetear.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(191)))), ((int)(((byte)(215)))));
            this.btnResetear.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnResetear.Font = new System.Drawing.Font("Bahnschrift Condensed", 14.25F);
            this.btnResetear.ForeColor = System.Drawing.Color.MediumBlue;
            this.btnResetear.Image = global::COVENTAF.Properties.Resources.Cleaner_icon_32x32;
            this.btnResetear.Location = new System.Drawing.Point(356, 114);
            this.btnResetear.Margin = new System.Windows.Forms.Padding(2);
            this.btnResetear.Name = "btnResetear";
            this.btnResetear.Size = new System.Drawing.Size(173, 45);
            this.btnResetear.TabIndex = 218;
            this.btnResetear.Text = "Resetear el Filtro";
            this.btnResetear.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ttpNotifcacion.SetToolTip(this.btnResetear, "Buscar el Cliente");
            this.btnResetear.UseVisualStyleBackColor = false;
            this.btnResetear.Click += new System.EventHandler(this.btnResetear_Click);
            // 
            // tmTransition
            // 
            this.tmTransition.Enabled = true;
            this.tmTransition.Interval = 20;
            this.tmTransition.Tick += new System.EventHandler(this.tmTransition_Tick);
            // 
            // frmFiltroAvanzado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(191)))), ((int)(((byte)(215)))));
            this.ClientSize = new System.Drawing.Size(705, 574);
            this.Controls.Add(this.btnResetear);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.chkFacturaCredito);
            this.Controls.Add(this.grpEstadoFactura);
            this.Controls.Add(this.lblBuscarFiltro);
            this.Controls.Add(this.cboTipoFiltro);
            this.Controls.Add(this.grpArticulo);
            this.Controls.Add(this.grpCliente);
            this.Controls.Add(this.grpFactura);
            this.Controls.Add(this.grpCaja);
            this.Controls.Add(this.grpFechaFactura);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.barraTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmFiltroAvanzado";
            this.Opacity = 0D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmFiltroAvanzado";
            this.Load += new System.EventHandler(this.frmFiltroAvanzado_Load);
            this.barraTitulo.ResumeLayout(false);
            this.barraTitulo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox11)).EndInit();
            this.grpFechaFactura.ResumeLayout(false);
            this.grpFechaFactura.PerformLayout();
            this.grpCaja.ResumeLayout(false);
            this.grpCaja.PerformLayout();
            this.grpFactura.ResumeLayout(false);
            this.grpFactura.PerformLayout();
            this.grpCliente.ResumeLayout(false);
            this.grpCliente.PerformLayout();
            this.grpArticulo.ResumeLayout(false);
            this.grpArticulo.PerformLayout();
            this.grpEstadoFactura.ResumeLayout(false);
            this.grpEstadoFactura.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel barraTitulo;
        private System.Windows.Forms.PictureBox btnCerrar;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox11;
        private System.Windows.Forms.GroupBox grpFechaFactura;
        private System.Windows.Forms.DateTimePicker dtFechaHasta;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtFechaDesde;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox grpCaja;
        private System.Windows.Forms.TextBox txtCaja;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox grpFactura;
        private System.Windows.Forms.TextBox txtFacturaHasta;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtFacturaDesde;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox grpCliente;
        private System.Windows.Forms.TextBox txtNombreCliente;
        private System.Windows.Forms.Label lblNombreCliente;
        private System.Windows.Forms.TextBox txtCodigoCliente;
        private System.Windows.Forms.Label lblCodigoCliente;
        private System.Windows.Forms.GroupBox grpArticulo;
        private System.Windows.Forms.TextBox txtNombreArticulo;
        private System.Windows.Forms.Label lblNombreArticulo;
        private System.Windows.Forms.TextBox txtCodigoArticulo;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.Label lblBuscarFiltro;
        private System.Windows.Forms.ComboBox cboTipoFiltro;
        private System.Windows.Forms.GroupBox grpEstadoFactura;
        private System.Windows.Forms.CheckBox chkAnuladas;
        private System.Windows.Forms.CheckBox chkCobradas;
        private System.Windows.Forms.CheckBox chkFacturaCredito;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button btnBuscarCliente;
        private System.Windows.Forms.ToolTip ttpNotifcacion;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnResetear;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel25;
        private System.Windows.Forms.Timer tmTransition;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel6;
    }
}