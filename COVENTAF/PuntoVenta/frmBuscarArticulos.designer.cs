
namespace COVENTAF.PuntoVenta
{
    partial class frmBuscarArticulos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBuscarArticulos));
            this.barraTitulo = new System.Windows.Forms.Panel();
            this.btnCierre = new System.Windows.Forms.PictureBox();
            this.btnMinizar = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.btnMinimizar = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblTituloCaja = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel25 = new System.Windows.Forms.Panel();
            this.lblDescripcionArticulo = new System.Windows.Forms.Label();
            this.txtDescripcionArticulo = new System.Windows.Forms.TextBox();
            this.lblCodigoArticulo = new System.Windows.Forms.Label();
            this.txtCodigoArticulo = new System.Windows.Forms.TextBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.tmTransition = new System.Windows.Forms.Timer(this.components);
            this.gridControl2 = new DevExpress.XtraGrid.GridControl();
            this.dgvListaArticulos = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Articulo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CodigoBarra = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Descripcion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Activo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.barraTitulo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnCierre)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaArticulos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
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
            this.barraTitulo.Size = new System.Drawing.Size(651, 28);
            this.barraTitulo.TabIndex = 5;
            this.barraTitulo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.barraTitulo_MouseDown);
            // 
            // btnCierre
            // 
            this.btnCierre.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCierre.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCierre.Image = global::COVENTAF.Properties.Resources.close_login;
            this.btnCierre.Location = new System.Drawing.Point(619, 3);
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
            this.btnMinizar.Location = new System.Drawing.Point(1353, -26);
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
            this.btnCerrar.Location = new System.Drawing.Point(1378, -26);
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
            this.lblTitulo.Location = new System.Drawing.Point(9, 3);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(129, 19);
            this.lblTitulo.TabIndex = 8;
            this.lblTitulo.Text = "Buscar Articulos";
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
            this.btnMinimizar.Location = new System.Drawing.Point(2087, -63);
            this.btnMinimizar.Name = "btnMinimizar";
            this.btnMinimizar.Size = new System.Drawing.Size(40, 40);
            this.btnMinimizar.TabIndex = 7;
            this.btnMinimizar.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(99)))), ((int)(((byte)(177)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(644, 28);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(7, 448);
            this.panel2.TabIndex = 132;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(99)))), ((int)(((byte)(177)))));
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 469);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(644, 7);
            this.panel3.TabIndex = 134;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(99)))), ((int)(((byte)(177)))));
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(7, 441);
            this.panel1.TabIndex = 135;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(45)))), ((int)(((byte)(64)))));
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(13)))), ((int)(((byte)(66)))));
            this.label2.Location = new System.Drawing.Point(7, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(637, 74);
            this.label2.TabIndex = 162;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(45)))), ((int)(((byte)(64)))));
            this.label4.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.Gold;
            this.label4.Location = new System.Drawing.Point(39, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 30);
            this.label4.TabIndex = 163;
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
            this.lblTituloCaja.Location = new System.Drawing.Point(77, 71);
            this.lblTituloCaja.Name = "lblTituloCaja";
            this.lblTituloCaja.Size = new System.Drawing.Size(155, 23);
            this.lblTituloCaja.TabIndex = 164;
            this.lblTituloCaja.Text = "Buscar Articulos";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(91)))), ((int)(((byte)(13)))));
            this.panel4.Location = new System.Drawing.Point(208, 183);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(237, 2);
            this.panel4.TabIndex = 224;
            // 
            // panel25
            // 
            this.panel25.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(91)))), ((int)(((byte)(13)))));
            this.panel25.Location = new System.Drawing.Point(209, 139);
            this.panel25.Name = "panel25";
            this.panel25.Size = new System.Drawing.Size(237, 2);
            this.panel25.TabIndex = 223;
            // 
            // lblDescripcionArticulo
            // 
            this.lblDescripcionArticulo.AutoSize = true;
            this.lblDescripcionArticulo.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblDescripcionArticulo.ForeColor = System.Drawing.Color.Maroon;
            this.lblDescripcionArticulo.Location = new System.Drawing.Point(13, 159);
            this.lblDescripcionArticulo.Name = "lblDescripcionArticulo";
            this.lblDescripcionArticulo.Size = new System.Drawing.Size(186, 18);
            this.lblDescripcionArticulo.TabIndex = 222;
            this.lblDescripcionArticulo.Text = "Descripcion del Articulo";
            // 
            // txtDescripcionArticulo
            // 
            this.txtDescripcionArticulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(191)))), ((int)(((byte)(215)))));
            this.txtDescripcionArticulo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDescripcionArticulo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescripcionArticulo.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold);
            this.txtDescripcionArticulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.txtDescripcionArticulo.Location = new System.Drawing.Point(209, 158);
            this.txtDescripcionArticulo.Name = "txtDescripcionArticulo";
            this.txtDescripcionArticulo.Size = new System.Drawing.Size(236, 20);
            this.txtDescripcionArticulo.TabIndex = 0;
            this.txtDescripcionArticulo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNombreCliente_KeyPress);
            // 
            // lblCodigoArticulo
            // 
            this.lblCodigoArticulo.AutoSize = true;
            this.lblCodigoArticulo.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblCodigoArticulo.ForeColor = System.Drawing.Color.Maroon;
            this.lblCodigoArticulo.Location = new System.Drawing.Point(41, 114);
            this.lblCodigoArticulo.Name = "lblCodigoArticulo";
            this.lblCodigoArticulo.Size = new System.Drawing.Size(157, 18);
            this.lblCodigoArticulo.TabIndex = 220;
            this.lblCodigoArticulo.Text = "Codigo del Articulo:";
            // 
            // txtCodigoArticulo
            // 
            this.txtCodigoArticulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(191)))), ((int)(((byte)(215)))));
            this.txtCodigoArticulo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCodigoArticulo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCodigoArticulo.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold);
            this.txtCodigoArticulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.txtCodigoArticulo.Location = new System.Drawing.Point(209, 112);
            this.txtCodigoArticulo.Name = "txtCodigoArticulo";
            this.txtCodigoArticulo.Size = new System.Drawing.Size(236, 20);
            this.txtCodigoArticulo.TabIndex = 1;
            this.txtCodigoArticulo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtIdentificacion_KeyPress);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.panel5.Location = new System.Drawing.Point(10, 192);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(633, 4);
            this.panel5.TabIndex = 225;
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(99)))), ((int)(((byte)(177)))));
            this.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscar.FlatAppearance.BorderSize = 0;
            this.btnBuscar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(92)))), ((int)(((byte)(133)))));
            this.btnBuscar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(50)))), ((int)(((byte)(97)))));
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnBuscar.Font = new System.Drawing.Font("Bahnschrift Condensed", 14.25F);
            this.btnBuscar.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnBuscar.Image = global::COVENTAF.Properties.Resources.buscar;
            this.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnBuscar.Location = new System.Drawing.Point(478, 147);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(2);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(115, 40);
            this.btnBuscar.TabIndex = 2;
            this.btnBuscar.Text = "&Buscar";
            this.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // tmTransition
            // 
            this.tmTransition.Enabled = true;
            this.tmTransition.Interval = 20;
            this.tmTransition.Tick += new System.EventHandler(this.tmTransition_Tick);
            // 
            // gridControl2
            // 
            this.gridControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl2.Location = new System.Drawing.Point(10, 202);
            this.gridControl2.MainView = this.dgvListaArticulos;
            this.gridControl2.Name = "gridControl2";
            this.gridControl2.Size = new System.Drawing.Size(634, 267);
            this.gridControl2.TabIndex = 278;
            this.gridControl2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.dgvListaArticulos});
            this.gridControl2.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.gridControl2_MouseDoubleClick);
            // 
            // dgvListaArticulos
            // 
            this.dgvListaArticulos.Appearance.ColumnFilterButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.dgvListaArticulos.Appearance.ColumnFilterButton.Options.UseForeColor = true;
            this.dgvListaArticulos.Appearance.FocusedCell.BackColor = System.Drawing.Color.DarkGoldenrod;
            this.dgvListaArticulos.Appearance.FocusedCell.BackColor2 = System.Drawing.Color.DarkGoldenrod;
            this.dgvListaArticulos.Appearance.FocusedCell.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.dgvListaArticulos.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.dgvListaArticulos.Appearance.FocusedCell.Options.UseBackColor = true;
            this.dgvListaArticulos.Appearance.FocusedCell.Options.UseBorderColor = true;
            this.dgvListaArticulos.Appearance.FocusedCell.Options.UseForeColor = true;
            this.dgvListaArticulos.Appearance.FocusedRow.BackColor = System.Drawing.Color.DarkGoldenrod;
            this.dgvListaArticulos.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.DarkGoldenrod;
            this.dgvListaArticulos.Appearance.FocusedRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.dgvListaArticulos.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.dgvListaArticulos.Appearance.FocusedRow.Options.UseBackColor = true;
            this.dgvListaArticulos.Appearance.FocusedRow.Options.UseBorderColor = true;
            this.dgvListaArticulos.Appearance.FocusedRow.Options.UseForeColor = true;
            this.dgvListaArticulos.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.dgvListaArticulos.Appearance.FooterPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.dgvListaArticulos.Appearance.FooterPanel.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal;
            this.dgvListaArticulos.Appearance.FooterPanel.Options.UseFont = true;
            this.dgvListaArticulos.Appearance.FooterPanel.Options.UseForeColor = true;
            this.dgvListaArticulos.Appearance.FooterPanel.Options.UseTextOptions = true;
            this.dgvListaArticulos.Appearance.FooterPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.dgvListaArticulos.Appearance.FooterPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.dgvListaArticulos.Appearance.GroupPanel.Font = new System.Drawing.Font("Tahoma", 9F);
            this.dgvListaArticulos.Appearance.GroupPanel.Options.UseFont = true;
            this.dgvListaArticulos.Appearance.HeaderPanel.Font = new System.Drawing.Font("Gadugi", 9.75F, System.Drawing.FontStyle.Bold);
            this.dgvListaArticulos.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.dgvListaArticulos.Appearance.HeaderPanel.Options.UseFont = true;
            this.dgvListaArticulos.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.dgvListaArticulos.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.dgvListaArticulos.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.dgvListaArticulos.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.dgvListaArticulos.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.DarkGoldenrod;
            this.dgvListaArticulos.Appearance.HideSelectionRow.BackColor2 = System.Drawing.Color.DarkGoldenrod;
            this.dgvListaArticulos.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.White;
            this.dgvListaArticulos.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.dgvListaArticulos.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.dgvListaArticulos.Appearance.Row.BackColor = System.Drawing.Color.OldLace;
            this.dgvListaArticulos.Appearance.Row.BorderColor = System.Drawing.Color.DarkGoldenrod;
            this.dgvListaArticulos.Appearance.Row.Font = new System.Drawing.Font("Gadugi", 9.75F);
            this.dgvListaArticulos.Appearance.Row.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.dgvListaArticulos.Appearance.Row.Options.UseBackColor = true;
            this.dgvListaArticulos.Appearance.Row.Options.UseBorderColor = true;
            this.dgvListaArticulos.Appearance.Row.Options.UseFont = true;
            this.dgvListaArticulos.Appearance.Row.Options.UseForeColor = true;
            this.dgvListaArticulos.Appearance.SelectedRow.BackColor = System.Drawing.Color.DarkGoldenrod;
            this.dgvListaArticulos.Appearance.SelectedRow.BackColor2 = System.Drawing.Color.DarkGoldenrod;
            this.dgvListaArticulos.Appearance.SelectedRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.dgvListaArticulos.Appearance.SelectedRow.ForeColor = System.Drawing.Color.White;
            this.dgvListaArticulos.Appearance.SelectedRow.Options.UseBackColor = true;
            this.dgvListaArticulos.Appearance.SelectedRow.Options.UseBorderColor = true;
            this.dgvListaArticulos.Appearance.SelectedRow.Options.UseForeColor = true;
            this.dgvListaArticulos.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.Articulo,
            this.CodigoBarra,
            this.Descripcion,
            this.Activo});
            this.dgvListaArticulos.GridControl = this.gridControl2;
            this.dgvListaArticulos.Name = "dgvListaArticulos";
            this.dgvListaArticulos.OptionsBehavior.Editable = false;
            this.dgvListaArticulos.OptionsPrint.PrintFilterInfo = true;
            this.dgvListaArticulos.OptionsPrint.PrintPreview = true;
            this.dgvListaArticulos.OptionsPrint.SplitDataCellAcrossPages = true;
            this.dgvListaArticulos.OptionsView.ColumnAutoWidth = false;
            // 
            // Articulo
            // 
            this.Articulo.Caption = "Articulo";
            this.Articulo.FieldName = "Articulo";
            this.Articulo.Name = "Articulo";
            this.Articulo.Visible = true;
            this.Articulo.VisibleIndex = 0;
            this.Articulo.Width = 131;
            // 
            // CodigoBarra
            // 
            this.CodigoBarra.Caption = "Codigo de Barra";
            this.CodigoBarra.FieldName = "Codigo_Barras_Invt";
            this.CodigoBarra.Name = "CodigoBarra";
            this.CodigoBarra.Visible = true;
            this.CodigoBarra.VisibleIndex = 1;
            this.CodigoBarra.Width = 150;
            // 
            // Descripcion
            // 
            this.Descripcion.Caption = "Descripcion";
            this.Descripcion.FieldName = "Descripcion";
            this.Descripcion.Name = "Descripcion";
            this.Descripcion.Visible = true;
            this.Descripcion.VisibleIndex = 2;
            this.Descripcion.Width = 397;
            // 
            // Activo
            // 
            this.Activo.Caption = "Activo";
            this.Activo.FieldName = "Activo";
            this.Activo.Name = "Activo";
            this.Activo.Visible = true;
            this.Activo.VisibleIndex = 3;
            this.Activo.Width = 89;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(45)))), ((int)(((byte)(64)))));
            this.pictureBox1.Image = global::COVENTAF.Properties.Resources.Articulos;
            this.pictureBox1.Location = new System.Drawing.Point(478, 28);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(166, 74);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 279;
            this.pictureBox1.TabStop = false;
            // 
            // frmBuscarArticulos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(191)))), ((int)(((byte)(215)))));
            this.ClientSize = new System.Drawing.Size(651, 476);
            this.ControlBox = false;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.gridControl2);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel25);
            this.Controls.Add(this.lblDescripcionArticulo);
            this.Controls.Add(this.txtDescripcionArticulo);
            this.Controls.Add(this.lblCodigoArticulo);
            this.Controls.Add(this.txtCodigoArticulo);
            this.Controls.Add(this.lblTituloCaja);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.barraTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmBuscarArticulos";
            this.Opacity = 0D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Buscar Clientes";
            this.Load += new System.EventHandler(this.frmBuscarCliente_Load);
            this.barraTitulo.ResumeLayout(false);
            this.barraTitulo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnCierre)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaArticulos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
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
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblTituloCaja;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel25;
        private System.Windows.Forms.Label lblDescripcionArticulo;
        private System.Windows.Forms.TextBox txtDescripcionArticulo;
        private System.Windows.Forms.Label lblCodigoArticulo;
        private System.Windows.Forms.TextBox txtCodigoArticulo;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Timer tmTransition;
        private DevExpress.XtraGrid.GridControl gridControl2;
        private DevExpress.XtraGrid.Views.Grid.GridView dgvListaArticulos;
        private DevExpress.XtraGrid.Columns.GridColumn Articulo;
        private DevExpress.XtraGrid.Columns.GridColumn CodigoBarra;
        private DevExpress.XtraGrid.Columns.GridColumn Descripcion;
        private DevExpress.XtraGrid.Columns.GridColumn Activo;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}