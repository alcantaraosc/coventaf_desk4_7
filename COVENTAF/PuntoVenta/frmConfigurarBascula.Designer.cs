
namespace COVENTAF.PuntoVenta
{
    partial class frmConfigurarBascula
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
            this.barraTitulo = new System.Windows.Forms.Panel();
            this.btnCerrar = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboStopBitsScanner = new System.Windows.Forms.ComboBox();
            this.btnBuscarPuertoScanner = new System.Windows.Forms.Button();
            this.lblStopBitsScanner = new System.Windows.Forms.Label();
            this.txtDataBitsScanner = new System.Windows.Forms.TextBox();
            this.DataBitsScanner = new System.Windows.Forms.Label();
            this.cboParityScanner = new System.Windows.Forms.ComboBox();
            this.lblParityScanner = new System.Windows.Forms.Label();
            this.txtSpeedScanner = new System.Windows.Forms.TextBox();
            this.SpeedScanner = new System.Windows.Forms.Label();
            this.cboPuertoScanner = new System.Windows.Forms.ComboBox();
            this.lblPuertoScanner = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cboStopBitsBascula = new System.Windows.Forms.ComboBox();
            this.btnBuscarPuertoBascula = new System.Windows.Forms.Button();
            this.lblStopBitsBascula = new System.Windows.Forms.Label();
            this.txtDataBitsBascula = new System.Windows.Forms.TextBox();
            this.lblDataBitsBascula = new System.Windows.Forms.Label();
            this.cboParityBascula = new System.Windows.Forms.ComboBox();
            this.lblParityBascula = new System.Windows.Forms.Label();
            this.txtSpeedBascula = new System.Windows.Forms.TextBox();
            this.lblSpeedBascula = new System.Windows.Forms.Label();
            this.cboPuertoBascula = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtScanner = new System.Windows.Forms.TextBox();
            this.txtBascula = new System.Windows.Forms.TextBox();
            this.btnProbarScanner = new System.Windows.Forms.Button();
            this.lblInformacionScanner = new System.Windows.Forms.Label();
            this.lblInformacionBascula = new System.Windows.Forms.Label();
            this.btnProbarBascula = new System.Windows.Forms.Button();
            this.btnGuardarConfiguracion = new System.Windows.Forms.Button();
            this.chkAplicarConfiguaracion = new System.Windows.Forms.CheckBox();
            this.grpConfiguaracion = new System.Windows.Forms.GroupBox();
            this.barraTitulo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.grpConfiguaracion.SuspendLayout();
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
            this.barraTitulo.Size = new System.Drawing.Size(872, 28);
            this.barraTitulo.TabIndex = 150;
            this.barraTitulo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.barraTitulo_MouseDown);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrar.Image = global::COVENTAF.Properties.Resources.close_login;
            this.btnCerrar.Location = new System.Drawing.Point(843, 3);
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
            this.pictureBox1.Location = new System.Drawing.Point(2550, 3);
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
            this.lblTitulo.Size = new System.Drawing.Size(266, 19);
            this.lblTitulo.TabIndex = 8;
            this.lblTitulo.Text = "Configuracion Scanner y Bascula";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(99)))), ((int)(((byte)(177)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(867, 28);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(5, 533);
            this.panel2.TabIndex = 151;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(99)))), ((int)(((byte)(177)))));
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 556);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(867, 5);
            this.panel3.TabIndex = 153;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(99)))), ((int)(((byte)(177)))));
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(5, 528);
            this.panel1.TabIndex = 154;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cboStopBitsScanner);
            this.groupBox1.Controls.Add(this.btnBuscarPuertoScanner);
            this.groupBox1.Controls.Add(this.lblStopBitsScanner);
            this.groupBox1.Controls.Add(this.txtDataBitsScanner);
            this.groupBox1.Controls.Add(this.DataBitsScanner);
            this.groupBox1.Controls.Add(this.cboParityScanner);
            this.groupBox1.Controls.Add(this.lblParityScanner);
            this.groupBox1.Controls.Add(this.txtSpeedScanner);
            this.groupBox1.Controls.Add(this.SpeedScanner);
            this.groupBox1.Controls.Add(this.cboPuertoScanner);
            this.groupBox1.Controls.Add(this.lblPuertoScanner);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBox1.Location = new System.Drawing.Point(21, 23);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(377, 259);
            this.groupBox1.TabIndex = 155;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Configuración Scanner";
            // 
            // cboStopBitsScanner
            // 
            this.cboStopBitsScanner.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStopBitsScanner.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.cboStopBitsScanner.FormattingEnabled = true;
            this.cboStopBitsScanner.Items.AddRange(new object[] {
            "None",
            "One",
            "OnePointFive",
            "Two"});
            this.cboStopBitsScanner.Location = new System.Drawing.Point(136, 198);
            this.cboStopBitsScanner.Name = "cboStopBitsScanner";
            this.cboStopBitsScanner.Size = new System.Drawing.Size(115, 27);
            this.cboStopBitsScanner.TabIndex = 4;
            // 
            // btnBuscarPuertoScanner
            // 
            this.btnBuscarPuertoScanner.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscarPuertoScanner.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnBuscarPuertoScanner.Location = new System.Drawing.Point(259, 31);
            this.btnBuscarPuertoScanner.Name = "btnBuscarPuertoScanner";
            this.btnBuscarPuertoScanner.Size = new System.Drawing.Size(112, 26);
            this.btnBuscarPuertoScanner.TabIndex = 157;
            this.btnBuscarPuertoScanner.Text = "Buscar Puerto";
            this.btnBuscarPuertoScanner.UseVisualStyleBackColor = true;
            this.btnBuscarPuertoScanner.Click += new System.EventHandler(this.btnBuscarPuertoScanner_Click);
            // 
            // lblStopBitsScanner
            // 
            this.lblStopBitsScanner.AutoSize = true;
            this.lblStopBitsScanner.Location = new System.Drawing.Point(17, 202);
            this.lblStopBitsScanner.Name = "lblStopBitsScanner";
            this.lblStopBitsScanner.Size = new System.Drawing.Size(70, 18);
            this.lblStopBitsScanner.TabIndex = 7;
            this.lblStopBitsScanner.Text = "Stop bits:";
            // 
            // txtDataBitsScanner
            // 
            this.txtDataBitsScanner.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.txtDataBitsScanner.ForeColor = System.Drawing.Color.Maroon;
            this.txtDataBitsScanner.Location = new System.Drawing.Point(136, 158);
            this.txtDataBitsScanner.Name = "txtDataBitsScanner";
            this.txtDataBitsScanner.Size = new System.Drawing.Size(115, 27);
            this.txtDataBitsScanner.TabIndex = 3;
            this.txtDataBitsScanner.Text = "8";
            this.txtDataBitsScanner.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // DataBitsScanner
            // 
            this.DataBitsScanner.AutoSize = true;
            this.DataBitsScanner.Location = new System.Drawing.Point(17, 162);
            this.DataBitsScanner.Name = "DataBitsScanner";
            this.DataBitsScanner.Size = new System.Drawing.Size(70, 18);
            this.DataBitsScanner.TabIndex = 5;
            this.DataBitsScanner.Text = "Data bits:";
            // 
            // cboParityScanner
            // 
            this.cboParityScanner.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboParityScanner.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.cboParityScanner.FormattingEnabled = true;
            this.cboParityScanner.Items.AddRange(new object[] {
            "None",
            "Odd",
            "Even",
            "Mark",
            "Space"});
            this.cboParityScanner.Location = new System.Drawing.Point(136, 117);
            this.cboParityScanner.Name = "cboParityScanner";
            this.cboParityScanner.Size = new System.Drawing.Size(115, 27);
            this.cboParityScanner.TabIndex = 2;
            // 
            // lblParityScanner
            // 
            this.lblParityScanner.AutoSize = true;
            this.lblParityScanner.Location = new System.Drawing.Point(17, 125);
            this.lblParityScanner.Name = "lblParityScanner";
            this.lblParityScanner.Size = new System.Drawing.Size(49, 18);
            this.lblParityScanner.TabIndex = 4;
            this.lblParityScanner.Text = "Parity:";
            // 
            // txtSpeedScanner
            // 
            this.txtSpeedScanner.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.txtSpeedScanner.ForeColor = System.Drawing.Color.Maroon;
            this.txtSpeedScanner.Location = new System.Drawing.Point(136, 74);
            this.txtSpeedScanner.Name = "txtSpeedScanner";
            this.txtSpeedScanner.Size = new System.Drawing.Size(115, 27);
            this.txtSpeedScanner.TabIndex = 1;
            this.txtSpeedScanner.Text = "9600";
            this.txtSpeedScanner.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // SpeedScanner
            // 
            this.SpeedScanner.AutoSize = true;
            this.SpeedScanner.Location = new System.Drawing.Point(17, 78);
            this.SpeedScanner.Name = "SpeedScanner";
            this.SpeedScanner.Size = new System.Drawing.Size(100, 18);
            this.SpeedScanner.TabIndex = 1;
            this.SpeedScanner.Text = "Speed (baud):";
            // 
            // cboPuertoScanner
            // 
            this.cboPuertoScanner.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPuertoScanner.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cboPuertoScanner.FormattingEnabled = true;
            this.cboPuertoScanner.Location = new System.Drawing.Point(136, 33);
            this.cboPuertoScanner.Name = "cboPuertoScanner";
            this.cboPuertoScanner.Size = new System.Drawing.Size(115, 26);
            this.cboPuertoScanner.TabIndex = 0;
            // 
            // lblPuertoScanner
            // 
            this.lblPuertoScanner.AutoSize = true;
            this.lblPuertoScanner.Location = new System.Drawing.Point(17, 41);
            this.lblPuertoScanner.Name = "lblPuertoScanner";
            this.lblPuertoScanner.Size = new System.Drawing.Size(56, 18);
            this.lblPuertoScanner.TabIndex = 0;
            this.lblPuertoScanner.Text = "Puerto:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cboStopBitsBascula);
            this.groupBox2.Controls.Add(this.btnBuscarPuertoBascula);
            this.groupBox2.Controls.Add(this.lblStopBitsBascula);
            this.groupBox2.Controls.Add(this.txtDataBitsBascula);
            this.groupBox2.Controls.Add(this.lblDataBitsBascula);
            this.groupBox2.Controls.Add(this.cboParityBascula);
            this.groupBox2.Controls.Add(this.lblParityBascula);
            this.groupBox2.Controls.Add(this.txtSpeedBascula);
            this.groupBox2.Controls.Add(this.lblSpeedBascula);
            this.groupBox2.Controls.Add(this.cboPuertoBascula);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(433, 23);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(377, 259);
            this.groupBox2.TabIndex = 156;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Configuración Bascula";
            // 
            // cboStopBitsBascula
            // 
            this.cboStopBitsBascula.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStopBitsBascula.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.cboStopBitsBascula.FormattingEnabled = true;
            this.cboStopBitsBascula.Items.AddRange(new object[] {
            "None",
            "One",
            "OnePointFive",
            "Two"});
            this.cboStopBitsBascula.Location = new System.Drawing.Point(136, 202);
            this.cboStopBitsBascula.Name = "cboStopBitsBascula";
            this.cboStopBitsBascula.Size = new System.Drawing.Size(115, 27);
            this.cboStopBitsBascula.TabIndex = 4;
            // 
            // btnBuscarPuertoBascula
            // 
            this.btnBuscarPuertoBascula.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscarPuertoBascula.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnBuscarPuertoBascula.Location = new System.Drawing.Point(257, 33);
            this.btnBuscarPuertoBascula.Name = "btnBuscarPuertoBascula";
            this.btnBuscarPuertoBascula.Size = new System.Drawing.Size(112, 26);
            this.btnBuscarPuertoBascula.TabIndex = 158;
            this.btnBuscarPuertoBascula.Text = "Buscar Puerto";
            this.btnBuscarPuertoBascula.UseVisualStyleBackColor = true;
            this.btnBuscarPuertoBascula.Click += new System.EventHandler(this.btnBuscarPuertoBascula_Click);
            // 
            // lblStopBitsBascula
            // 
            this.lblStopBitsBascula.AutoSize = true;
            this.lblStopBitsBascula.ForeColor = System.Drawing.Color.White;
            this.lblStopBitsBascula.Location = new System.Drawing.Point(17, 199);
            this.lblStopBitsBascula.Name = "lblStopBitsBascula";
            this.lblStopBitsBascula.Size = new System.Drawing.Size(70, 18);
            this.lblStopBitsBascula.TabIndex = 7;
            this.lblStopBitsBascula.Text = "Stop bits:";
            // 
            // txtDataBitsBascula
            // 
            this.txtDataBitsBascula.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.txtDataBitsBascula.ForeColor = System.Drawing.Color.Maroon;
            this.txtDataBitsBascula.Location = new System.Drawing.Point(136, 158);
            this.txtDataBitsBascula.Name = "txtDataBitsBascula";
            this.txtDataBitsBascula.Size = new System.Drawing.Size(115, 27);
            this.txtDataBitsBascula.TabIndex = 3;
            this.txtDataBitsBascula.Text = "7";
            this.txtDataBitsBascula.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblDataBitsBascula
            // 
            this.lblDataBitsBascula.AutoSize = true;
            this.lblDataBitsBascula.ForeColor = System.Drawing.Color.White;
            this.lblDataBitsBascula.Location = new System.Drawing.Point(17, 162);
            this.lblDataBitsBascula.Name = "lblDataBitsBascula";
            this.lblDataBitsBascula.Size = new System.Drawing.Size(70, 18);
            this.lblDataBitsBascula.TabIndex = 5;
            this.lblDataBitsBascula.Text = "Data bits:";
            // 
            // cboParityBascula
            // 
            this.cboParityBascula.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboParityBascula.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.cboParityBascula.FormattingEnabled = true;
            this.cboParityBascula.Items.AddRange(new object[] {
            "None",
            "Odd",
            "Even",
            "Mark",
            "Space"});
            this.cboParityBascula.Location = new System.Drawing.Point(136, 117);
            this.cboParityBascula.Name = "cboParityBascula";
            this.cboParityBascula.Size = new System.Drawing.Size(115, 27);
            this.cboParityBascula.TabIndex = 2;
            // 
            // lblParityBascula
            // 
            this.lblParityBascula.AutoSize = true;
            this.lblParityBascula.ForeColor = System.Drawing.Color.White;
            this.lblParityBascula.Location = new System.Drawing.Point(17, 125);
            this.lblParityBascula.Name = "lblParityBascula";
            this.lblParityBascula.Size = new System.Drawing.Size(49, 18);
            this.lblParityBascula.TabIndex = 4;
            this.lblParityBascula.Text = "Parity:";
            // 
            // txtSpeedBascula
            // 
            this.txtSpeedBascula.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.txtSpeedBascula.ForeColor = System.Drawing.Color.Maroon;
            this.txtSpeedBascula.Location = new System.Drawing.Point(136, 74);
            this.txtSpeedBascula.Name = "txtSpeedBascula";
            this.txtSpeedBascula.Size = new System.Drawing.Size(115, 27);
            this.txtSpeedBascula.TabIndex = 1;
            this.txtSpeedBascula.Text = "9600";
            this.txtSpeedBascula.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblSpeedBascula
            // 
            this.lblSpeedBascula.AutoSize = true;
            this.lblSpeedBascula.ForeColor = System.Drawing.Color.White;
            this.lblSpeedBascula.Location = new System.Drawing.Point(17, 78);
            this.lblSpeedBascula.Name = "lblSpeedBascula";
            this.lblSpeedBascula.Size = new System.Drawing.Size(100, 18);
            this.lblSpeedBascula.TabIndex = 1;
            this.lblSpeedBascula.Text = "Speed (baud):";
            // 
            // cboPuertoBascula
            // 
            this.cboPuertoBascula.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPuertoBascula.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cboPuertoBascula.FormattingEnabled = true;
            this.cboPuertoBascula.Location = new System.Drawing.Point(136, 33);
            this.cboPuertoBascula.Name = "cboPuertoBascula";
            this.cboPuertoBascula.Size = new System.Drawing.Size(115, 26);
            this.cboPuertoBascula.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(17, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 18);
            this.label5.TabIndex = 0;
            this.label5.Text = "Puerto:";
            // 
            // txtScanner
            // 
            this.txtScanner.Font = new System.Drawing.Font("Cascadia Code", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtScanner.ForeColor = System.Drawing.Color.DarkRed;
            this.txtScanner.Location = new System.Drawing.Point(24, 371);
            this.txtScanner.Name = "txtScanner";
            this.txtScanner.Size = new System.Drawing.Size(377, 32);
            this.txtScanner.TabIndex = 157;
            // 
            // txtBascula
            // 
            this.txtBascula.Font = new System.Drawing.Font("Cascadia Code", 15.75F);
            this.txtBascula.ForeColor = System.Drawing.Color.DarkRed;
            this.txtBascula.Location = new System.Drawing.Point(436, 371);
            this.txtBascula.Name = "txtBascula";
            this.txtBascula.Size = new System.Drawing.Size(377, 32);
            this.txtBascula.TabIndex = 159;
            // 
            // btnProbarScanner
            // 
            this.btnProbarScanner.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProbarScanner.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnProbarScanner.Location = new System.Drawing.Point(24, 333);
            this.btnProbarScanner.Name = "btnProbarScanner";
            this.btnProbarScanner.Size = new System.Drawing.Size(377, 26);
            this.btnProbarScanner.TabIndex = 161;
            this.btnProbarScanner.Text = "Probar el Scanner";
            this.btnProbarScanner.UseVisualStyleBackColor = true;
            this.btnProbarScanner.Click += new System.EventHandler(this.btnProbarScanner_Click);
            // 
            // lblInformacionScanner
            // 
            this.lblInformacionScanner.AutoSize = true;
            this.lblInformacionScanner.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInformacionScanner.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblInformacionScanner.Location = new System.Drawing.Point(27, 285);
            this.lblInformacionScanner.Name = "lblInformacionScanner";
            this.lblInformacionScanner.Size = new System.Drawing.Size(302, 36);
            this.lblInformacionScanner.TabIndex = 162;
            this.lblInformacionScanner.Text = "Para probar el scanner, dar click en el boton \r\nProbar Scanner y luego escanear u" +
    "n articulo";
            // 
            // lblInformacionBascula
            // 
            this.lblInformacionBascula.AutoSize = true;
            this.lblInformacionBascula.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInformacionBascula.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblInformacionBascula.Location = new System.Drawing.Point(442, 286);
            this.lblInformacionBascula.Name = "lblInformacionBascula";
            this.lblInformacionBascula.Size = new System.Drawing.Size(367, 36);
            this.lblInformacionBascula.TabIndex = 164;
            this.lblInformacionBascula.Text = "Para probar la bascula, Primero ponga una articulo en \r\nla bascula y luego dar cl" +
    "ick en el boton Probar Bascula";
            // 
            // btnProbarBascula
            // 
            this.btnProbarBascula.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProbarBascula.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnProbarBascula.Location = new System.Drawing.Point(439, 335);
            this.btnProbarBascula.Name = "btnProbarBascula";
            this.btnProbarBascula.Size = new System.Drawing.Size(374, 26);
            this.btnProbarBascula.TabIndex = 163;
            this.btnProbarBascula.Text = "Probar Bascula";
            this.btnProbarBascula.UseVisualStyleBackColor = true;
            this.btnProbarBascula.Click += new System.EventHandler(this.btnProbarBascula_Click);
            // 
            // btnGuardarConfiguracion
            // 
            this.btnGuardarConfiguracion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardarConfiguracion.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnGuardarConfiguracion.Location = new System.Drawing.Point(35, 518);
            this.btnGuardarConfiguracion.Name = "btnGuardarConfiguracion";
            this.btnGuardarConfiguracion.Size = new System.Drawing.Size(789, 26);
            this.btnGuardarConfiguracion.TabIndex = 165;
            this.btnGuardarConfiguracion.Text = "Guardar la configuracion";
            this.btnGuardarConfiguracion.UseVisualStyleBackColor = true;
            this.btnGuardarConfiguracion.Click += new System.EventHandler(this.btnGuardarConfiguracion_Click);
            // 
            // chkAplicarConfiguaracion
            // 
            this.chkAplicarConfiguaracion.AutoSize = true;
            this.chkAplicarConfiguaracion.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.chkAplicarConfiguaracion.ForeColor = System.Drawing.Color.White;
            this.chkAplicarConfiguaracion.Location = new System.Drawing.Point(12, 50);
            this.chkAplicarConfiguaracion.Name = "chkAplicarConfiguaracion";
            this.chkAplicarConfiguaracion.Size = new System.Drawing.Size(544, 23);
            this.chkAplicarConfiguaracion.TabIndex = 166;
            this.chkAplicarConfiguaracion.Text = "Aplicar Configuracion de scanner y bascula por medio de puerto?";
            this.chkAplicarConfiguaracion.UseVisualStyleBackColor = true;
            this.chkAplicarConfiguaracion.CheckedChanged += new System.EventHandler(this.chkAplicarConfiguaracion_CheckedChanged);
            // 
            // grpConfiguaracion
            // 
            this.grpConfiguaracion.Controls.Add(this.groupBox1);
            this.grpConfiguaracion.Controls.Add(this.groupBox2);
            this.grpConfiguaracion.Controls.Add(this.lblInformacionScanner);
            this.grpConfiguaracion.Controls.Add(this.lblInformacionBascula);
            this.grpConfiguaracion.Controls.Add(this.txtScanner);
            this.grpConfiguaracion.Controls.Add(this.btnProbarBascula);
            this.grpConfiguaracion.Controls.Add(this.txtBascula);
            this.grpConfiguaracion.Controls.Add(this.btnProbarScanner);
            this.grpConfiguaracion.Enabled = false;
            this.grpConfiguaracion.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpConfiguaracion.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.grpConfiguaracion.Location = new System.Drawing.Point(11, 81);
            this.grpConfiguaracion.Name = "grpConfiguaracion";
            this.grpConfiguaracion.Size = new System.Drawing.Size(836, 420);
            this.grpConfiguaracion.TabIndex = 167;
            this.grpConfiguaracion.TabStop = false;
            this.grpConfiguaracion.Text = "Configuración";
            // 
            // frmConfigurarBascula
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(45)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(872, 561);
            this.Controls.Add(this.chkAplicarConfiguaracion);
            this.Controls.Add(this.grpConfiguaracion);
            this.Controls.Add(this.btnGuardarConfiguracion);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.barraTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmConfigurarBascula";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmConfigurarBascula";
            this.Load += new System.EventHandler(this.frmConfigurarBascula_Load);
            this.barraTitulo.ResumeLayout(false);
            this.barraTitulo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.grpConfiguaracion.ResumeLayout(false);
            this.grpConfiguaracion.PerformLayout();
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
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtSpeedScanner;
        private System.Windows.Forms.Label SpeedScanner;
        private System.Windows.Forms.ComboBox cboPuertoScanner;
        private System.Windows.Forms.Label lblPuertoScanner;
        private System.Windows.Forms.Label lblStopBitsScanner;
        private System.Windows.Forms.TextBox txtDataBitsScanner;
        private System.Windows.Forms.Label DataBitsScanner;
        private System.Windows.Forms.ComboBox cboParityScanner;
        private System.Windows.Forms.Label lblParityScanner;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblStopBitsBascula;
        private System.Windows.Forms.TextBox txtDataBitsBascula;
        private System.Windows.Forms.Label lblDataBitsBascula;
        private System.Windows.Forms.ComboBox cboParityBascula;
        private System.Windows.Forms.Label lblParityBascula;
        private System.Windows.Forms.TextBox txtSpeedBascula;
        private System.Windows.Forms.Label lblSpeedBascula;
        private System.Windows.Forms.ComboBox cboPuertoBascula;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnBuscarPuertoScanner;
        private System.Windows.Forms.Button btnBuscarPuertoBascula;
        private System.Windows.Forms.TextBox txtScanner;
        private System.Windows.Forms.TextBox txtBascula;
        private System.Windows.Forms.Button btnProbarScanner;
        private System.Windows.Forms.Label lblInformacionScanner;
        private System.Windows.Forms.Label lblInformacionBascula;
        private System.Windows.Forms.Button btnProbarBascula;
        private System.Windows.Forms.Button btnGuardarConfiguracion;
        private System.Windows.Forms.ComboBox cboStopBitsScanner;
        private System.Windows.Forms.ComboBox cboStopBitsBascula;
        private System.Windows.Forms.CheckBox chkAplicarConfiguaracion;
        private System.Windows.Forms.GroupBox grpConfiguaracion;
    }
}