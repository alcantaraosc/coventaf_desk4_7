
namespace COVENTAF.PuntoVenta
{
    partial class frmDescuentoArticulo
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
            this.dgvDetalleFactura = new System.Windows.Forms.DataGridView();
            this.pnlDerecho = new System.Windows.Forms.Panel();
            this.pnlAbajo = new System.Windows.Forms.Panel();
            this.pnlIzquierdo = new System.Windows.Forms.Panel();
            this.barraTitulo = new System.Windows.Forms.Panel();
            this.btnCerrar = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.pictureBox26 = new System.Windows.Forms.PictureBox();
            this.lblEtiquetaCoventaf = new System.Windows.Forms.Label();
            this.lblEtiquetaPuntoVenta = new System.Windows.Forms.Label();
            this.pictureBox11 = new System.Windows.Forms.PictureBox();
            this.btnEliminarProductos = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnActivarCheck = new System.Windows.Forms.Button();
            this.btnQuitarCheck = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel25 = new System.Windows.Forms.Panel();
            this.txtDescuentoLinea = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tmTransition = new System.Windows.Forms.Timer(this.components);
            this.label18 = new System.Windows.Forms.Label();
            this.Marcado = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Articulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descuento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DescuentoAplicado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleFactura)).BeginInit();
            this.barraTitulo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox26)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox11)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvDetalleFactura
            // 
            this.dgvDetalleFactura.AllowUserToAddRows = false;
            this.dgvDetalleFactura.AllowUserToDeleteRows = false;
            this.dgvDetalleFactura.AllowUserToResizeColumns = false;
            this.dgvDetalleFactura.AllowUserToResizeRows = false;
            this.dgvDetalleFactura.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDetalleFactura.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvDetalleFactura.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvDetalleFactura.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.dgvDetalleFactura.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.dgvDetalleFactura.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(103)))), ((int)(((byte)(62)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetalleFactura.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDetalleFactura.ColumnHeadersHeight = 30;
            this.dgvDetalleFactura.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Marcado,
            this.Articulo,
            this.Cantidad,
            this.Descuento,
            this.Descripcion,
            this.DescuentoAplicado});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.DarkGoldenrod;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDetalleFactura.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDetalleFactura.EnableHeadersVisualStyles = false;
            this.dgvDetalleFactura.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dgvDetalleFactura.Location = new System.Drawing.Point(7, 180);
            this.dgvDetalleFactura.MultiSelect = false;
            this.dgvDetalleFactura.Name = "dgvDetalleFactura";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetalleFactura.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvDetalleFactura.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetalleFactura.Size = new System.Drawing.Size(613, 315);
            this.dgvDetalleFactura.TabIndex = 183;
            // 
            // pnlDerecho
            // 
            this.pnlDerecho.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(156)))), ((int)(((byte)(4)))));
            this.pnlDerecho.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlDerecho.Location = new System.Drawing.Point(620, 0);
            this.pnlDerecho.Name = "pnlDerecho";
            this.pnlDerecho.Size = new System.Drawing.Size(7, 592);
            this.pnlDerecho.TabIndex = 184;
            // 
            // pnlAbajo
            // 
            this.pnlAbajo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(156)))), ((int)(((byte)(4)))));
            this.pnlAbajo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlAbajo.Location = new System.Drawing.Point(0, 585);
            this.pnlAbajo.Name = "pnlAbajo";
            this.pnlAbajo.Size = new System.Drawing.Size(620, 7);
            this.pnlAbajo.TabIndex = 185;
            // 
            // pnlIzquierdo
            // 
            this.pnlIzquierdo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(156)))), ((int)(((byte)(4)))));
            this.pnlIzquierdo.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlIzquierdo.Location = new System.Drawing.Point(0, 0);
            this.pnlIzquierdo.Name = "pnlIzquierdo";
            this.pnlIzquierdo.Size = new System.Drawing.Size(7, 585);
            this.pnlIzquierdo.TabIndex = 186;
            // 
            // barraTitulo
            // 
            this.barraTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(156)))), ((int)(((byte)(4)))));
            this.barraTitulo.Controls.Add(this.btnCerrar);
            this.barraTitulo.Controls.Add(this.pictureBox1);
            this.barraTitulo.Controls.Add(this.lblTitulo);
            this.barraTitulo.Cursor = System.Windows.Forms.Cursors.Default;
            this.barraTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.barraTitulo.Location = new System.Drawing.Point(7, 0);
            this.barraTitulo.Name = "barraTitulo";
            this.barraTitulo.Size = new System.Drawing.Size(613, 28);
            this.barraTitulo.TabIndex = 187;
            this.barraTitulo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.barraTitulo_MouseDown);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrar.Image = global::COVENTAF.Properties.Resources.close_login;
            this.btnCerrar.Location = new System.Drawing.Point(1239, 2);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(21, 21);
            this.btnCerrar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnCerrar.TabIndex = 80;
            this.btnCerrar.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = global::COVENTAF.Properties.Resources.close_login;
            this.pictureBox1.Location = new System.Drawing.Point(4013, 3);
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
            this.lblTitulo.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.Transparent;
            this.lblTitulo.Location = new System.Drawing.Point(4, 4);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(189, 19);
            this.lblTitulo.TabIndex = 8;
            this.lblTitulo.Text = "Descuento por Articulos";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(106)))), ((int)(((byte)(74)))));
            this.panel5.Controls.Add(this.pictureBox26);
            this.panel5.Controls.Add(this.lblEtiquetaCoventaf);
            this.panel5.Controls.Add(this.lblEtiquetaPuntoVenta);
            this.panel5.Controls.Add(this.pictureBox11);
            this.panel5.Controls.Add(this.btnEliminarProductos);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(7, 28);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(613, 74);
            this.panel5.TabIndex = 188;
            // 
            // pictureBox26
            // 
            this.pictureBox26.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox26.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox26.Image = global::COVENTAF.Properties.Resources.logo;
            this.pictureBox26.Location = new System.Drawing.Point(1473, 3);
            this.pictureBox26.Name = "pictureBox26";
            this.pictureBox26.Size = new System.Drawing.Size(340, 48);
            this.pictureBox26.TabIndex = 143;
            this.pictureBox26.TabStop = false;
            // 
            // lblEtiquetaCoventaf
            // 
            this.lblEtiquetaCoventaf.AutoSize = true;
            this.lblEtiquetaCoventaf.BackColor = System.Drawing.Color.Transparent;
            this.lblEtiquetaCoventaf.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold);
            this.lblEtiquetaCoventaf.ForeColor = System.Drawing.Color.Gold;
            this.lblEtiquetaCoventaf.Location = new System.Drawing.Point(22, 3);
            this.lblEtiquetaCoventaf.Name = "lblEtiquetaCoventaf";
            this.lblEtiquetaCoventaf.Size = new System.Drawing.Size(121, 30);
            this.lblEtiquetaCoventaf.TabIndex = 140;
            this.lblEtiquetaCoventaf.Text = "COVENTAF";
            // 
            // lblEtiquetaPuntoVenta
            // 
            this.lblEtiquetaPuntoVenta.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblEtiquetaPuntoVenta.AutoSize = true;
            this.lblEtiquetaPuntoVenta.BackColor = System.Drawing.Color.Transparent;
            this.lblEtiquetaPuntoVenta.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblEtiquetaPuntoVenta.ForeColor = System.Drawing.Color.SeaShell;
            this.lblEtiquetaPuntoVenta.Location = new System.Drawing.Point(59, 40);
            this.lblEtiquetaPuntoVenta.Name = "lblEtiquetaPuntoVenta";
            this.lblEtiquetaPuntoVenta.Size = new System.Drawing.Size(227, 23);
            this.lblEtiquetaPuntoVenta.TabIndex = 141;
            this.lblEtiquetaPuntoVenta.Text = "Descuento por Articulos";
            // 
            // pictureBox11
            // 
            this.pictureBox11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox11.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox11.Image = global::COVENTAF.Properties.Resources.logo;
            this.pictureBox11.Location = new System.Drawing.Point(2167, 2);
            this.pictureBox11.Name = "pictureBox11";
            this.pictureBox11.Size = new System.Drawing.Size(351, 48);
            this.pictureBox11.TabIndex = 142;
            this.pictureBox11.TabStop = false;
            // 
            // btnEliminarProductos
            // 
            this.btnEliminarProductos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEliminarProductos.BackColor = System.Drawing.Color.Silver;
            this.btnEliminarProductos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminarProductos.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnEliminarProductos.Location = new System.Drawing.Point(1255, 4);
            this.btnEliminarProductos.Name = "btnEliminarProductos";
            this.btnEliminarProductos.Size = new System.Drawing.Size(47, 43);
            this.btnEliminarProductos.TabIndex = 125;
            this.btnEliminarProductos.UseVisualStyleBackColor = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackColor = System.Drawing.Color.Maroon;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(92)))), ((int)(((byte)(133)))));
            this.btnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(50)))), ((int)(((byte)(97)))));
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancel.Font = new System.Drawing.Font("Bahnschrift Condensed", 14.25F);
            this.btnCancel.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnCancel.Image = global::COVENTAF.Properties.Resources.cancelar;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(500, 518);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(113, 43);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "&Cancelar";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAceptar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(99)))), ((int)(((byte)(177)))));
            this.btnAceptar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAceptar.Enabled = false;
            this.btnAceptar.FlatAppearance.BorderSize = 0;
            this.btnAceptar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(92)))), ((int)(((byte)(133)))));
            this.btnAceptar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(50)))), ((int)(((byte)(97)))));
            this.btnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAceptar.Font = new System.Drawing.Font("Bahnschrift Condensed", 14.25F);
            this.btnAceptar.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnAceptar.Image = global::COVENTAF.Properties.Resources.comprobado;
            this.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAceptar.Location = new System.Drawing.Point(372, 518);
            this.btnAceptar.Margin = new System.Windows.Forms.Padding(2);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(112, 43);
            this.btnAceptar.TabIndex = 3;
            this.btnAceptar.Text = "&Aceptar";
            this.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAceptar.UseVisualStyleBackColor = false;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnActivarCheck
            // 
            this.btnActivarCheck.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(99)))), ((int)(((byte)(177)))));
            this.btnActivarCheck.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnActivarCheck.FlatAppearance.BorderSize = 0;
            this.btnActivarCheck.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(92)))), ((int)(((byte)(133)))));
            this.btnActivarCheck.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(50)))), ((int)(((byte)(97)))));
            this.btnActivarCheck.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnActivarCheck.Font = new System.Drawing.Font("Bahnschrift Condensed", 14.25F);
            this.btnActivarCheck.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnActivarCheck.Image = global::COVENTAF.Properties.Resources.comprobado;
            this.btnActivarCheck.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnActivarCheck.Location = new System.Drawing.Point(15, 121);
            this.btnActivarCheck.Margin = new System.Windows.Forms.Padding(2);
            this.btnActivarCheck.Name = "btnActivarCheck";
            this.btnActivarCheck.Size = new System.Drawing.Size(81, 45);
            this.btnActivarCheck.TabIndex = 0;
            this.btnActivarCheck.Text = "F2";
            this.btnActivarCheck.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip1.SetToolTip(this.btnActivarCheck, "Activar el check de toda la lista de articulos");
            this.btnActivarCheck.UseVisualStyleBackColor = false;
            this.btnActivarCheck.Click += new System.EventHandler(this.btnActivarCheck_Click);
            // 
            // btnQuitarCheck
            // 
            this.btnQuitarCheck.BackColor = System.Drawing.Color.Maroon;
            this.btnQuitarCheck.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnQuitarCheck.FlatAppearance.BorderSize = 0;
            this.btnQuitarCheck.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(92)))), ((int)(((byte)(133)))));
            this.btnQuitarCheck.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(50)))), ((int)(((byte)(97)))));
            this.btnQuitarCheck.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnQuitarCheck.Font = new System.Drawing.Font("Bahnschrift Condensed", 14.25F);
            this.btnQuitarCheck.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnQuitarCheck.Image = global::COVENTAF.Properties.Resources.cancelar;
            this.btnQuitarCheck.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnQuitarCheck.Location = new System.Drawing.Point(114, 121);
            this.btnQuitarCheck.Margin = new System.Windows.Forms.Padding(2);
            this.btnQuitarCheck.Name = "btnQuitarCheck";
            this.btnQuitarCheck.Size = new System.Drawing.Size(81, 45);
            this.btnQuitarCheck.TabIndex = 1;
            this.btnQuitarCheck.Text = "F3";
            this.btnQuitarCheck.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip1.SetToolTip(this.btnQuitarCheck, "Quitar el check de toda la lista");
            this.btnQuitarCheck.UseVisualStyleBackColor = false;
            this.btnQuitarCheck.Click += new System.EventHandler(this.btnQuitarCheck_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.Location = new System.Drawing.Point(30, 531);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 19);
            this.label1.TabIndex = 217;
            this.label1.Text = "Descuento % - F6";
            // 
            // panel25
            // 
            this.panel25.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(91)))), ((int)(((byte)(13)))));
            this.panel25.Location = new System.Drawing.Point(208, 557);
            this.panel25.Name = "panel25";
            this.panel25.Size = new System.Drawing.Size(117, 2);
            this.panel25.TabIndex = 219;
            // 
            // txtDescuentoLinea
            // 
            this.txtDescuentoLinea.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtDescuentoLinea.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.txtDescuentoLinea.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDescuentoLinea.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescuentoLinea.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescuentoLinea.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.txtDescuentoLinea.Location = new System.Drawing.Point(208, 530);
            this.txtDescuentoLinea.Name = "txtDescuentoLinea";
            this.txtDescuentoLinea.Size = new System.Drawing.Size(117, 22);
            this.txtDescuentoLinea.TabIndex = 2;
            this.txtDescuentoLinea.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtDescuentoLinea.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDescuento_KeyPress);
            // 
            // tmTransition
            // 
            this.tmTransition.Enabled = true;
            this.tmTransition.Interval = 20;
            this.tmTransition.Tick += new System.EventHandler(this.tmTransition_Tick);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.Navy;
            this.label18.Location = new System.Drawing.Point(238, 150);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(263, 16);
            this.label18.TabIndex = 220;
            this.label18.Text = "Ubicar el cursor Detalles de Factura -F4";
            // 
            // Marcado
            // 
            this.Marcado.HeaderText = "Marcado";
            this.Marcado.Name = "Marcado";
            this.Marcado.Width = 83;
            // 
            // Articulo
            // 
            this.Articulo.HeaderText = "Articulo";
            this.Articulo.Name = "Articulo";
            this.Articulo.Width = 90;
            // 
            // Cantidad
            // 
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.Name = "Cantidad";
            this.Cantidad.Width = 102;
            // 
            // Descuento
            // 
            this.Descuento.HeaderText = "Descuento";
            this.Descuento.Name = "Descuento";
            this.Descuento.Width = 112;
            // 
            // Descripcion
            // 
            this.Descripcion.HeaderText = "Descripcion";
            this.Descripcion.Name = "Descripcion";
            this.Descripcion.Width = 122;
            // 
            // DescuentoAplicado
            // 
            this.DescuentoAplicado.HeaderText = "DescuentoAplicado";
            this.DescuentoAplicado.Name = "DescuentoAplicado";
            this.DescuentoAplicado.ReadOnly = true;
            this.DescuentoAplicado.Visible = false;
            this.DescuentoAplicado.Width = 181;
            // 
            // frmDescuentoArticulo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(627, 592);
            this.ControlBox = false;
            this.Controls.Add(this.label18);
            this.Controls.Add(this.panel25);
            this.Controls.Add(this.txtDescuentoLinea);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnQuitarCheck);
            this.Controls.Add(this.btnActivarCheck);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.barraTitulo);
            this.Controls.Add(this.pnlIzquierdo);
            this.Controls.Add(this.pnlAbajo);
            this.Controls.Add(this.pnlDerecho);
            this.Controls.Add(this.dgvDetalleFactura);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "frmDescuentoArticulo";
            this.Opacity = 0D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmDescuentoArticulo";
            this.Load += new System.EventHandler(this.frmDescuentoArticulo_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmDescuentoArticulo_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleFactura)).EndInit();
            this.barraTitulo.ResumeLayout(false);
            this.barraTitulo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox26)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox11)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDetalleFactura;
        private System.Windows.Forms.Panel pnlDerecho;
        private System.Windows.Forms.Panel pnlAbajo;
        private System.Windows.Forms.Panel pnlIzquierdo;
        private System.Windows.Forms.Panel barraTitulo;
        private System.Windows.Forms.PictureBox btnCerrar;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.PictureBox pictureBox26;
        private System.Windows.Forms.Label lblEtiquetaCoventaf;
        private System.Windows.Forms.Label lblEtiquetaPuntoVenta;
        private System.Windows.Forms.PictureBox pictureBox11;
        private System.Windows.Forms.Button btnEliminarProductos;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnActivarCheck;
        private System.Windows.Forms.Button btnQuitarCheck;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel25;
        private System.Windows.Forms.TextBox txtDescuentoLinea;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Timer tmTransition;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Marcado;
        private System.Windows.Forms.DataGridViewTextBoxColumn Articulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descuento;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn DescuentoAplicado;
    }
}