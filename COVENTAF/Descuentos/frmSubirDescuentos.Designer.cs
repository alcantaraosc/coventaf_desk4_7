
namespace COVENTAF.Descuentos
{
    partial class frmSubirDescuentos
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.barraTitulo = new System.Windows.Forms.Panel();
            this.btnCierre = new System.Windows.Forms.PictureBox();
            this.btnMinizar = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.btnMinimizar = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pnl = new System.Windows.Forms.Panel();
            this.pictureBox26 = new System.Windows.Forms.PictureBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.pictureBox11 = new System.Windows.Forms.PictureBox();
            this.btnExaminar = new System.Windows.Forms.Button();
            this.gridControl2 = new DevExpress.XtraGrid.GridControl();
            this.dgvDescuentoArticulos = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Articulo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Descuento = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lblArchivo = new System.Windows.Forms.Label();
            this.txtRuta = new System.Windows.Forms.TextBox();
            this.cboHojas = new System.Windows.Forms.ComboBox();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.lblMoneda = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.lblNivelPrecio = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.grpOpcionesDescuentos = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.barraTitulo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnCierre)).BeginInit();
            this.pnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox26)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDescuentoArticulos)).BeginInit();
            this.grpOpcionesDescuentos.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(99)))), ((int)(((byte)(177)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(589, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(7, 697);
            this.panel2.TabIndex = 133;
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
            this.barraTitulo.Size = new System.Drawing.Size(589, 28);
            this.barraTitulo.TabIndex = 134;
            // 
            // btnCierre
            // 
            this.btnCierre.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCierre.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCierre.Image = global::COVENTAF.Properties.Resources.close_login;
            this.btnCierre.Location = new System.Drawing.Point(557, 3);
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
            this.btnMinizar.Location = new System.Drawing.Point(1291, -26);
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
            this.btnCerrar.Location = new System.Drawing.Point(1316, -26);
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
            this.lblTitulo.Location = new System.Drawing.Point(9, 4);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(179, 19);
            this.lblTitulo.TabIndex = 8;
            this.lblTitulo.Text = "Descuentos de Precios";
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
            this.btnMinimizar.Location = new System.Drawing.Point(2025, -63);
            this.btnMinimizar.Name = "btnMinimizar";
            this.btnMinimizar.Size = new System.Drawing.Size(40, 40);
            this.btnMinimizar.TabIndex = 7;
            this.btnMinimizar.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(99)))), ((int)(((byte)(177)))));
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(7, 669);
            this.panel1.TabIndex = 136;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(99)))), ((int)(((byte)(177)))));
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(7, 690);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(582, 7);
            this.panel3.TabIndex = 137;
            // 
            // pnl
            // 
            this.pnl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(45)))), ((int)(((byte)(64)))));
            this.pnl.Controls.Add(this.pictureBox26);
            this.pnl.Controls.Add(this.label10);
            this.pnl.Controls.Add(this.label20);
            this.pnl.Controls.Add(this.pictureBox11);
            this.pnl.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl.Location = new System.Drawing.Point(7, 28);
            this.pnl.Name = "pnl";
            this.pnl.Size = new System.Drawing.Size(582, 74);
            this.pnl.TabIndex = 275;
            // 
            // pictureBox26
            // 
            this.pictureBox26.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox26.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox26.Image = global::COVENTAF.Properties.Resources.logo;
            this.pictureBox26.Location = new System.Drawing.Point(1799, 3);
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
            this.label10.Location = new System.Drawing.Point(9, 6);
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
            this.label20.Location = new System.Drawing.Point(51, 41);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(216, 23);
            this.label20.TabIndex = 141;
            this.label20.Text = "Descuentos de Precios";
            // 
            // pictureBox11
            // 
            this.pictureBox11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox11.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox11.Image = global::COVENTAF.Properties.Resources.logo;
            this.pictureBox11.Location = new System.Drawing.Point(2504, 2);
            this.pictureBox11.Name = "pictureBox11";
            this.pictureBox11.Size = new System.Drawing.Size(351, 48);
            this.pictureBox11.TabIndex = 142;
            this.pictureBox11.TabStop = false;
            // 
            // btnExaminar
            // 
            this.btnExaminar.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F);
            this.btnExaminar.Location = new System.Drawing.Point(440, 116);
            this.btnExaminar.Name = "btnExaminar";
            this.btnExaminar.Size = new System.Drawing.Size(36, 23);
            this.btnExaminar.TabIndex = 280;
            this.btnExaminar.Text = "..";
            this.btnExaminar.UseVisualStyleBackColor = true;
            this.btnExaminar.Click += new System.EventHandler(this.btnExaminar_Click);
            // 
            // gridControl2
            // 
            this.gridControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl2.Location = new System.Drawing.Point(7, 311);
            this.gridControl2.MainView = this.dgvDescuentoArticulos;
            this.gridControl2.Name = "gridControl2";
            this.gridControl2.Size = new System.Drawing.Size(582, 377);
            this.gridControl2.TabIndex = 281;
            this.gridControl2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.dgvDescuentoArticulos});
            // 
            // dgvDescuentoArticulos
            // 
            this.dgvDescuentoArticulos.Appearance.ColumnFilterButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.dgvDescuentoArticulos.Appearance.ColumnFilterButton.Options.UseForeColor = true;
            this.dgvDescuentoArticulos.Appearance.FocusedCell.BackColor = System.Drawing.Color.DarkGoldenrod;
            this.dgvDescuentoArticulos.Appearance.FocusedCell.BackColor2 = System.Drawing.Color.DarkGoldenrod;
            this.dgvDescuentoArticulos.Appearance.FocusedCell.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.dgvDescuentoArticulos.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.dgvDescuentoArticulos.Appearance.FocusedCell.Options.UseBackColor = true;
            this.dgvDescuentoArticulos.Appearance.FocusedCell.Options.UseBorderColor = true;
            this.dgvDescuentoArticulos.Appearance.FocusedCell.Options.UseForeColor = true;
            this.dgvDescuentoArticulos.Appearance.FocusedRow.BackColor = System.Drawing.Color.DarkGoldenrod;
            this.dgvDescuentoArticulos.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.DarkGoldenrod;
            this.dgvDescuentoArticulos.Appearance.FocusedRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.dgvDescuentoArticulos.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.dgvDescuentoArticulos.Appearance.FocusedRow.Options.UseBackColor = true;
            this.dgvDescuentoArticulos.Appearance.FocusedRow.Options.UseBorderColor = true;
            this.dgvDescuentoArticulos.Appearance.FocusedRow.Options.UseForeColor = true;
            this.dgvDescuentoArticulos.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.dgvDescuentoArticulos.Appearance.FooterPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.dgvDescuentoArticulos.Appearance.FooterPanel.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal;
            this.dgvDescuentoArticulos.Appearance.FooterPanel.Options.UseFont = true;
            this.dgvDescuentoArticulos.Appearance.FooterPanel.Options.UseForeColor = true;
            this.dgvDescuentoArticulos.Appearance.FooterPanel.Options.UseTextOptions = true;
            this.dgvDescuentoArticulos.Appearance.FooterPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.dgvDescuentoArticulos.Appearance.FooterPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.dgvDescuentoArticulos.Appearance.GroupPanel.Font = new System.Drawing.Font("Tahoma", 9F);
            this.dgvDescuentoArticulos.Appearance.GroupPanel.Options.UseFont = true;
            this.dgvDescuentoArticulos.Appearance.HeaderPanel.Font = new System.Drawing.Font("Gadugi", 9.75F, System.Drawing.FontStyle.Bold);
            this.dgvDescuentoArticulos.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.dgvDescuentoArticulos.Appearance.HeaderPanel.Options.UseFont = true;
            this.dgvDescuentoArticulos.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.dgvDescuentoArticulos.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.dgvDescuentoArticulos.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.dgvDescuentoArticulos.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.dgvDescuentoArticulos.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.DarkGoldenrod;
            this.dgvDescuentoArticulos.Appearance.HideSelectionRow.BackColor2 = System.Drawing.Color.DarkGoldenrod;
            this.dgvDescuentoArticulos.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.White;
            this.dgvDescuentoArticulos.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.dgvDescuentoArticulos.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.dgvDescuentoArticulos.Appearance.Row.BackColor = System.Drawing.Color.OldLace;
            this.dgvDescuentoArticulos.Appearance.Row.BorderColor = System.Drawing.Color.DarkGoldenrod;
            this.dgvDescuentoArticulos.Appearance.Row.Font = new System.Drawing.Font("Gadugi", 9.75F);
            this.dgvDescuentoArticulos.Appearance.Row.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.dgvDescuentoArticulos.Appearance.Row.Options.UseBackColor = true;
            this.dgvDescuentoArticulos.Appearance.Row.Options.UseBorderColor = true;
            this.dgvDescuentoArticulos.Appearance.Row.Options.UseFont = true;
            this.dgvDescuentoArticulos.Appearance.Row.Options.UseForeColor = true;
            this.dgvDescuentoArticulos.Appearance.SelectedRow.BackColor = System.Drawing.Color.DarkGoldenrod;
            this.dgvDescuentoArticulos.Appearance.SelectedRow.BackColor2 = System.Drawing.Color.DarkGoldenrod;
            this.dgvDescuentoArticulos.Appearance.SelectedRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.dgvDescuentoArticulos.Appearance.SelectedRow.ForeColor = System.Drawing.Color.White;
            this.dgvDescuentoArticulos.Appearance.SelectedRow.Options.UseBackColor = true;
            this.dgvDescuentoArticulos.Appearance.SelectedRow.Options.UseBorderColor = true;
            this.dgvDescuentoArticulos.Appearance.SelectedRow.Options.UseForeColor = true;
            this.dgvDescuentoArticulos.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.Articulo,
            this.Descuento});
            this.dgvDescuentoArticulos.GridControl = this.gridControl2;
            this.dgvDescuentoArticulos.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Total_Factura", null, "(Total Factura C$: SUMA={0:#.##})"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Saldo", null, "(Saldo C$: SUMA={0:#.##})")});
            this.dgvDescuentoArticulos.Name = "dgvDescuentoArticulos";
            this.dgvDescuentoArticulos.OptionsBehavior.Editable = false;
            this.dgvDescuentoArticulos.OptionsPrint.PrintFilterInfo = true;
            this.dgvDescuentoArticulos.OptionsPrint.PrintPreview = true;
            this.dgvDescuentoArticulos.OptionsPrint.SplitDataCellAcrossPages = true;
            this.dgvDescuentoArticulos.OptionsView.ColumnAutoWidth = false;
            this.dgvDescuentoArticulos.OptionsView.ShowFooter = true;
            // 
            // Articulo
            // 
            this.Articulo.Caption = "Articulo";
            this.Articulo.FieldName = "Articulo";
            this.Articulo.Name = "Articulo";
            this.Articulo.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "Articulo", "{0} Registros")});
            this.Articulo.Visible = true;
            this.Articulo.VisibleIndex = 0;
            this.Articulo.Width = 295;
            // 
            // Descuento
            // 
            this.Descuento.Caption = "Descuento";
            this.Descuento.FieldName = "Descuento";
            this.Descuento.Name = "Descuento";
            this.Descuento.Visible = true;
            this.Descuento.VisibleIndex = 1;
            this.Descuento.Width = 237;
            // 
            // lblArchivo
            // 
            this.lblArchivo.AutoSize = true;
            this.lblArchivo.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F);
            this.lblArchivo.Location = new System.Drawing.Point(18, 119);
            this.lblArchivo.Name = "lblArchivo";
            this.lblArchivo.Size = new System.Drawing.Size(63, 16);
            this.lblArchivo.TabIndex = 282;
            this.lblArchivo.Text = "Archivo:";
            // 
            // txtRuta
            // 
            this.txtRuta.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F);
            this.txtRuta.Location = new System.Drawing.Point(87, 116);
            this.txtRuta.Name = "txtRuta";
            this.txtRuta.ReadOnly = true;
            this.txtRuta.Size = new System.Drawing.Size(347, 23);
            this.txtRuta.TabIndex = 283;
            // 
            // cboHojas
            // 
            this.cboHojas.FormattingEnabled = true;
            this.cboHojas.Location = new System.Drawing.Point(511, 116);
            this.cboHojas.Name = "cboHojas";
            this.cboHojas.Size = new System.Drawing.Size(21, 21);
            this.cboHojas.TabIndex = 286;
            this.cboHojas.Visible = false;
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Location = new System.Drawing.Point(364, 56);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(62, 16);
            this.lblUsuario.TabIndex = 284;
            this.lblUsuario.Text = "Usuario:";
            // 
            // comboBox2
            // 
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "CORDOBA",
            "DOLAR"});
            this.comboBox2.Location = new System.Drawing.Point(436, 20);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(120, 24);
            this.comboBox2.TabIndex = 279;
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(436, 54);
            this.txtUser.Name = "txtUser";
            this.txtUser.ReadOnly = true;
            this.txtUser.Size = new System.Drawing.Size(120, 23);
            this.txtUser.TabIndex = 285;
            // 
            // lblMoneda
            // 
            this.lblMoneda.AutoSize = true;
            this.lblMoneda.Location = new System.Drawing.Point(364, 24);
            this.lblMoneda.Name = "lblMoneda";
            this.lblMoneda.Size = new System.Drawing.Size(65, 16);
            this.lblMoneda.TabIndex = 278;
            this.lblMoneda.Text = "Moneda:";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "LPTIENDA"});
            this.comboBox1.Location = new System.Drawing.Point(191, 21);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(139, 24);
            this.comboBox1.TabIndex = 277;
            // 
            // lblNivelPrecio
            // 
            this.lblNivelPrecio.AutoSize = true;
            this.lblNivelPrecio.Location = new System.Drawing.Point(70, 28);
            this.lblNivelPrecio.Name = "lblNivelPrecio";
            this.lblNivelPrecio.Size = new System.Drawing.Size(111, 16);
            this.lblNivelPrecio.TabIndex = 276;
            this.lblNivelPrecio.Text = "Nivel de Precio:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(11, 117);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(545, 33);
            this.button1.TabIndex = 286;
            this.button1.Text = "Guardar Descuento del articulo";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(191, 51);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(139, 23);
            this.dateTimePicker1.TabIndex = 287;
            this.dateTimePicker1.Value = new System.DateTime(2023, 8, 2, 0, 0, 0, 0);
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker2.Location = new System.Drawing.Point(191, 80);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(139, 23);
            this.dateTimePicker2.TabIndex = 288;
            this.dateTimePicker2.Value = new System.DateTime(2023, 8, 2, 0, 0, 0, 0);
            // 
            // grpOpcionesDescuentos
            // 
            this.grpOpcionesDescuentos.Controls.Add(this.label3);
            this.grpOpcionesDescuentos.Controls.Add(this.dateTimePicker2);
            this.grpOpcionesDescuentos.Controls.Add(this.label2);
            this.grpOpcionesDescuentos.Controls.Add(this.dateTimePicker1);
            this.grpOpcionesDescuentos.Controls.Add(this.button1);
            this.grpOpcionesDescuentos.Controls.Add(this.lblNivelPrecio);
            this.grpOpcionesDescuentos.Controls.Add(this.comboBox1);
            this.grpOpcionesDescuentos.Controls.Add(this.lblMoneda);
            this.grpOpcionesDescuentos.Controls.Add(this.txtUser);
            this.grpOpcionesDescuentos.Controls.Add(this.comboBox2);
            this.grpOpcionesDescuentos.Controls.Add(this.lblUsuario);
            this.grpOpcionesDescuentos.Enabled = false;
            this.grpOpcionesDescuentos.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpOpcionesDescuentos.Location = new System.Drawing.Point(16, 146);
            this.grpOpcionesDescuentos.Name = "grpOpcionesDescuentos";
            this.grpOpcionesDescuentos.Size = new System.Drawing.Size(566, 159);
            this.grpOpcionesDescuentos.TabIndex = 288;
            this.grpOpcionesDescuentos.TabStop = false;
            this.grpOpcionesDescuentos.Text = "Opciones para Guardar los descuentos";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(169, 16);
            this.label2.TabIndex = 289;
            this.label2.Text = "Fecha Inicio Descuento:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(164, 16);
            this.label3.TabIndex = 290;
            this.label3.Text = "Fecha Final Descuento:";
            // 
            // frmSubirDescuentos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(191)))), ((int)(((byte)(215)))));
            this.ClientSize = new System.Drawing.Size(596, 697);
            this.Controls.Add(this.grpOpcionesDescuentos);
            this.Controls.Add(this.cboHojas);
            this.Controls.Add(this.txtRuta);
            this.Controls.Add(this.lblArchivo);
            this.Controls.Add(this.gridControl2);
            this.Controls.Add(this.btnExaminar);
            this.Controls.Add(this.pnl);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.barraTitulo);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmSubirDescuentos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmSubirDescuentos";
            this.barraTitulo.ResumeLayout(false);
            this.barraTitulo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnCierre)).EndInit();
            this.pnl.ResumeLayout(false);
            this.pnl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox26)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDescuentoArticulos)).EndInit();
            this.grpOpcionesDescuentos.ResumeLayout(false);
            this.grpOpcionesDescuentos.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel barraTitulo;
        private System.Windows.Forms.PictureBox btnCierre;
        private System.Windows.Forms.Button btnMinizar;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Button btnMinimizar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel pnl;
        private System.Windows.Forms.PictureBox pictureBox26;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.PictureBox pictureBox11;
        private System.Windows.Forms.Button btnExaminar;
        private DevExpress.XtraGrid.GridControl gridControl2;
        private DevExpress.XtraGrid.Views.Grid.GridView dgvDescuentoArticulos;
        private DevExpress.XtraGrid.Columns.GridColumn Articulo;
        private System.Windows.Forms.Label lblArchivo;
        private System.Windows.Forms.TextBox txtRuta;
        private System.Windows.Forms.ComboBox cboHojas;
        private DevExpress.XtraGrid.Columns.GridColumn Descuento;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Label lblMoneda;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label lblNivelPrecio;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.GroupBox grpOpcionesDescuentos;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}