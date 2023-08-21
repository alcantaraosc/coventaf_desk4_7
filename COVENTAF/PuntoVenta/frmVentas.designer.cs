
namespace COVENTAF.PuntoVenta
{
    partial class frmVentas
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
            //cerrar la conexion del scaner
            CerrarConexionScanner();
            //cerrar la conexion de la bascula
            CerrarConexionBascula();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVentas));
            this.barraTitulo = new System.Windows.Forms.Panel();
            this.btnRestaurar = new System.Windows.Forms.PictureBox();
            this.btnCerrar = new System.Windows.Forms.PictureBox();
            this.btnMminizar = new System.Windows.Forms.PictureBox();
            this.btnMaximizar = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnCobrar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.btnEditarCantidad = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnDescuentoLinea = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.btnEliminarArticulo = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnLimpiarFactura = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.btnCambiarPrecio = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.label2 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.lblNoFactura = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.lblTipoCambio = new System.Windows.Forms.Label();
            this.pictureBox26 = new System.Windows.Forms.PictureBox();
            this.lblCodigoCliente = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.txtCodigoCliente = new System.Windows.Forms.TextBox();
            this.txtNombreCliente = new System.Windows.Forms.TextBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.txtDisponibleCliente = new System.Windows.Forms.TextBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.txtDescuentoCliente = new System.Windows.Forms.TextBox();
            this.panel7 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.panel9 = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.panel11 = new System.Windows.Forms.Panel();
            this.cboBodega = new System.Windows.Forms.ComboBox();
            this.lblCodigoArticulo = new System.Windows.Forms.Label();
            this.txtCodigoBarra = new System.Windows.Forms.TextBox();
            this.panel12 = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.txtDescripcionArticulo = new System.Windows.Forms.TextBox();
            this.panel13 = new System.Windows.Forms.Panel();
            this.txtObservaciones = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.chkDescuentoGeneral = new System.Windows.Forms.CheckBox();
            this.txtSubTotalCordobas = new System.Windows.Forms.TextBox();
            this.panel14 = new System.Windows.Forms.Panel();
            this.panel15 = new System.Windows.Forms.Panel();
            this.txtDescuentoCordobas = new System.Windows.Forms.TextBox();
            this.panel16 = new System.Windows.Forms.Panel();
            this.txtSubTotalDescuentoCordobas = new System.Windows.Forms.TextBox();
            this.panel17 = new System.Windows.Forms.Panel();
            this.txtIVACordobas = new System.Windows.Forms.TextBox();
            this.panel18 = new System.Windows.Forms.Panel();
            this.txtTotalCordobas = new System.Windows.Forms.TextBox();
            this.panel19 = new System.Windows.Forms.Panel();
            this.txtTotalDolares = new System.Windows.Forms.TextBox();
            this.panel20 = new System.Windows.Forms.Panel();
            this.txtIVADolares = new System.Windows.Forms.TextBox();
            this.panel21 = new System.Windows.Forms.Panel();
            this.txtSubTotalDescuentoDolares = new System.Windows.Forms.TextBox();
            this.panel22 = new System.Windows.Forms.Panel();
            this.txtDescuentoDolares = new System.Windows.Forms.TextBox();
            this.panel23 = new System.Windows.Forms.Panel();
            this.txtSubTotalDolares = new System.Windows.Forms.TextBox();
            this.panel24 = new System.Windows.Forms.Panel();
            this.txtPorcenDescuentGeneral = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel25 = new System.Windows.Forms.Panel();
            this.txtCreditoCortoPlazo = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.cboTipoDescuento = new System.Windows.Forms.ComboBox();
            this.lblCaja = new System.Windows.Forms.Label();
            this.dgvDetalleFactura = new System.Windows.Forms.DataGridView();
            this.Consecutivo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ArticuloId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodigoBarra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PorcentDescuentArticulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Unidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Existencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Lote = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnidadFraccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrecioCordobas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrecioDolar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Moneda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BodegaId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NombreBodega = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubTotalCordobas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubTotalDolar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DescuentoPorLineaCordoba = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DescuentoPorLineaDolar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MontoDescGeneralCordoba = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MontoDescGeneralDolar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalCordobas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalDolar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cost_Prom_Loc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cost_Prom_Dol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad_d = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PorcentDescuentArticulo_d = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblDescripcionPeso = new System.Windows.Forms.Label();
            this.lblPesoKg = new System.Windows.Forms.Label();
            this.pnlInfBascula = new System.Windows.Forms.Panel();
            this.barraTitulo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnRestaurar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMminizar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMaximizar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox26)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleFactura)).BeginInit();
            this.pnlInfBascula.SuspendLayout();
            this.SuspendLayout();
            // 
            // barraTitulo
            // 
            this.barraTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(57)))), ((int)(((byte)(85)))));
            this.barraTitulo.Controls.Add(this.btnRestaurar);
            this.barraTitulo.Controls.Add(this.btnCerrar);
            this.barraTitulo.Controls.Add(this.btnMminizar);
            this.barraTitulo.Controls.Add(this.btnMaximizar);
            this.barraTitulo.Controls.Add(this.pictureBox1);
            this.barraTitulo.Controls.Add(this.lblTitulo);
            this.barraTitulo.Cursor = System.Windows.Forms.Cursors.Default;
            this.barraTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.barraTitulo.Location = new System.Drawing.Point(0, 0);
            this.barraTitulo.Name = "barraTitulo";
            this.barraTitulo.Size = new System.Drawing.Size(1207, 28);
            this.barraTitulo.TabIndex = 31;
            this.barraTitulo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.barraTitulo_MouseDown);
            // 
            // btnRestaurar
            // 
            this.btnRestaurar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRestaurar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRestaurar.Image = global::COVENTAF.Properties.Resources.Icono_Restaurar;
            this.btnRestaurar.Location = new System.Drawing.Point(1145, 3);
            this.btnRestaurar.Margin = new System.Windows.Forms.Padding(2);
            this.btnRestaurar.Name = "btnRestaurar";
            this.btnRestaurar.Size = new System.Drawing.Size(28, 22);
            this.btnRestaurar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnRestaurar.TabIndex = 83;
            this.btnRestaurar.TabStop = false;
            this.btnRestaurar.Click += new System.EventHandler(this.btnRestaurar_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrar.Image = global::COVENTAF.Properties.Resources.close_login;
            this.btnCerrar.Location = new System.Drawing.Point(1179, 3);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(21, 21);
            this.btnCerrar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnCerrar.TabIndex = 80;
            this.btnCerrar.TabStop = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // btnMminizar
            // 
            this.btnMminizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMminizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMminizar.Image = global::COVENTAF.Properties.Resources.Icono_Minimizar;
            this.btnMminizar.Location = new System.Drawing.Point(1112, 3);
            this.btnMminizar.Name = "btnMminizar";
            this.btnMminizar.Size = new System.Drawing.Size(28, 22);
            this.btnMminizar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnMminizar.TabIndex = 82;
            this.btnMminizar.TabStop = false;
            this.btnMminizar.Click += new System.EventHandler(this.btnMminizar_Click);
            // 
            // btnMaximizar
            // 
            this.btnMaximizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMaximizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMaximizar.Image = global::COVENTAF.Properties.Resources.Icono_Maximizar;
            this.btnMaximizar.Location = new System.Drawing.Point(1145, 3);
            this.btnMaximizar.Margin = new System.Windows.Forms.Padding(2);
            this.btnMaximizar.Name = "btnMaximizar";
            this.btnMaximizar.Size = new System.Drawing.Size(28, 22);
            this.btnMaximizar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnMaximizar.TabIndex = 81;
            this.btnMaximizar.TabStop = false;
            this.btnMaximizar.Visible = false;
            this.btnMaximizar.Click += new System.EventHandler(this.btnMaximizar_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = global::COVENTAF.Properties.Resources.close_login;
            this.pictureBox1.Location = new System.Drawing.Point(2019, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(21, 21);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblTitulo.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(12, 3);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(127, 19);
            this.lblTitulo.TabIndex = 8;
            this.lblTitulo.Text = "Punto de Venta";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(57)))), ((int)(((byte)(85)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(1202, 28);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(5, 638);
            this.panel2.TabIndex = 130;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(57)))), ((int)(((byte)(85)))));
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(5, 638);
            this.panel1.TabIndex = 131;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(57)))), ((int)(((byte)(85)))));
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(5, 661);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1197, 5);
            this.panel3.TabIndex = 146;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnCobrar,
            this.toolStripSeparator5,
            this.btnEditarCantidad,
            this.toolStripSeparator2,
            this.btnDescuentoLinea,
            this.toolStripSeparator6,
            this.btnEliminarArticulo,
            this.toolStripSeparator3,
            this.btnCambiarPrecio,
            this.toolStripSeparator4,
            this.btnLimpiarFactura,
            this.toolStripSeparator7});
            this.toolStrip1.Location = new System.Drawing.Point(5, 28);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1197, 39);
            this.toolStrip1.TabIndex = 147;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnCobrar
            // 
            this.btnCobrar.Font = new System.Drawing.Font("Bahnschrift Condensed", 14.25F);
            this.btnCobrar.ForeColor = System.Drawing.Color.Maroon;
            this.btnCobrar.Image = global::COVENTAF.Properties.Resources.salario;
            this.btnCobrar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnCobrar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCobrar.Name = "btnCobrar";
            this.btnCobrar.Size = new System.Drawing.Size(116, 36);
            this.btnCobrar.Text = "Cobrar - F1";
            this.btnCobrar.ToolTipText = "Cobrar al cliente";
            this.btnCobrar.Click += new System.EventHandler(this.btnCobrar_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 39);
            // 
            // btnEditarCantidad
            // 
            this.btnEditarCantidad.Font = new System.Drawing.Font("Bahnschrift Condensed", 14.25F);
            this.btnEditarCantidad.ForeColor = System.Drawing.Color.Maroon;
            this.btnEditarCantidad.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEditarCantidad.Name = "btnEditarCantidad";
            this.btnEditarCantidad.Size = new System.Drawing.Size(143, 36);
            this.btnEditarCantidad.Text = "Editar Cantidad - F2";
            this.btnEditarCantidad.ToolTipText = "Editar Cantidad del articulo";
            this.btnEditarCantidad.Click += new System.EventHandler(this.btnEditarCantidad_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 39);
            // 
            // btnDescuentoLinea
            // 
            this.btnDescuentoLinea.Font = new System.Drawing.Font("Bahnschrift Condensed", 14.25F);
            this.btnDescuentoLinea.ForeColor = System.Drawing.Color.Maroon;
            this.btnDescuentoLinea.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnDescuentoLinea.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDescuentoLinea.Name = "btnDescuentoLinea";
            this.btnDescuentoLinea.Size = new System.Drawing.Size(135, 36);
            this.btnDescuentoLinea.Text = "Descuento Linea F3";
            this.btnDescuentoLinea.ToolTipText = "Descuento Linea";
            this.btnDescuentoLinea.Click += new System.EventHandler(this.btnDescuentoLinea_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 39);
            // 
            // btnEliminarArticulo
            // 
            this.btnEliminarArticulo.Font = new System.Drawing.Font("Bahnschrift Condensed", 14.25F);
            this.btnEliminarArticulo.ForeColor = System.Drawing.Color.Maroon;
            this.btnEliminarArticulo.Image = global::COVENTAF.Properties.Resources.quitar_del_carrito;
            this.btnEliminarArticulo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnEliminarArticulo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEliminarArticulo.Name = "btnEliminarArticulo";
            this.btnEliminarArticulo.Size = new System.Drawing.Size(181, 36);
            this.btnEliminarArticulo.Text = "Eliminar Articulo - F7";
            this.btnEliminarArticulo.ToolTipText = "Eliminar Articulo (Supr)";
            this.btnEliminarArticulo.Click += new System.EventHandler(this.btnEliminarArticulo_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 39);
            // 
            // btnLimpiarFactura
            // 
            this.btnLimpiarFactura.Font = new System.Drawing.Font("Bahnschrift Condensed", 14.25F);
            this.btnLimpiarFactura.ForeColor = System.Drawing.Color.Maroon;
            this.btnLimpiarFactura.Image = global::COVENTAF.Properties.Resources.reset;
            this.btnLimpiarFactura.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnLimpiarFactura.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLimpiarFactura.Name = "btnLimpiarFactura";
            this.btnLimpiarFactura.Size = new System.Drawing.Size(167, 36);
            this.btnLimpiarFactura.Text = "Limpiar Factura F8";
            this.btnLimpiarFactura.Click += new System.EventHandler(this.btnLimpiarFactura_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 39);
            // 
            // btnCambiarPrecio
            // 
            this.btnCambiarPrecio.Font = new System.Drawing.Font("Bahnschrift Condensed", 14.25F);
            this.btnCambiarPrecio.ForeColor = System.Drawing.Color.Maroon;
            this.btnCambiarPrecio.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCambiarPrecio.Name = "btnCambiarPrecio";
            this.btnCambiarPrecio.Size = new System.Drawing.Size(111, 36);
            this.btnCambiarPrecio.Text = "Cambiar Precio";
            this.btnCambiarPrecio.Click += new System.EventHandler(this.btnCambiarPrecio_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 39);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(45)))), ((int)(((byte)(64)))));
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(13)))), ((int)(((byte)(66)))));
            this.label2.Location = new System.Drawing.Point(5, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(1197, 74);
            this.label2.TabIndex = 148;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(45)))), ((int)(((byte)(64)))));
            this.label10.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold);
            this.label10.ForeColor = System.Drawing.Color.Gold;
            this.label10.Location = new System.Drawing.Point(24, 71);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(121, 30);
            this.label10.TabIndex = 149;
            this.label10.Text = "COVENTAF";
            // 
            // label20
            // 
            this.label20.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label20.AutoSize = true;
            this.label20.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(45)))), ((int)(((byte)(64)))));
            this.label20.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold);
            this.label20.ForeColor = System.Drawing.Color.SeaShell;
            this.label20.Location = new System.Drawing.Point(60, 102);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(151, 23);
            this.label20.TabIndex = 150;
            this.label20.Text = "Punto de Venta";
            // 
            // lblNoFactura
            // 
            this.lblNoFactura.AutoSize = true;
            this.lblNoFactura.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(45)))), ((int)(((byte)(64)))));
            this.lblNoFactura.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoFactura.ForeColor = System.Drawing.Color.White;
            this.lblNoFactura.Location = new System.Drawing.Point(260, 77);
            this.lblNoFactura.Name = "lblNoFactura";
            this.lblNoFactura.Size = new System.Drawing.Size(102, 19);
            this.lblNoFactura.TabIndex = 151;
            this.lblNoFactura.Text = "No. Factura:";
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(45)))), ((int)(((byte)(64)))));
            this.lblFecha.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.lblFecha.ForeColor = System.Drawing.Color.White;
            this.lblFecha.Location = new System.Drawing.Point(295, 104);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(62, 19);
            this.lblFecha.TabIndex = 152;
            this.lblFecha.Text = "Fecha:";
            // 
            // lblTipoCambio
            // 
            this.lblTipoCambio.AutoSize = true;
            this.lblTipoCambio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(45)))), ((int)(((byte)(64)))));
            this.lblTipoCambio.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.lblTipoCambio.ForeColor = System.Drawing.Color.White;
            this.lblTipoCambio.Location = new System.Drawing.Point(506, 77);
            this.lblTipoCambio.Name = "lblTipoCambio";
            this.lblTipoCambio.Size = new System.Drawing.Size(113, 19);
            this.lblTipoCambio.TabIndex = 153;
            this.lblTipoCambio.Text = "Tipo Cambio:";
            // 
            // pictureBox26
            // 
            this.pictureBox26.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox26.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox26.Image = global::COVENTAF.Properties.Resources.logo;
            this.pictureBox26.Location = new System.Drawing.Point(796, 83);
            this.pictureBox26.Name = "pictureBox26";
            this.pictureBox26.Size = new System.Drawing.Size(403, 48);
            this.pictureBox26.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox26.TabIndex = 154;
            this.pictureBox26.TabStop = false;
            // 
            // lblCodigoCliente
            // 
            this.lblCodigoCliente.AutoSize = true;
            this.lblCodigoCliente.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblCodigoCliente.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblCodigoCliente.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblCodigoCliente.Location = new System.Drawing.Point(32, 177);
            this.lblCodigoCliente.Name = "lblCodigoCliente";
            this.lblCodigoCliente.Size = new System.Drawing.Size(125, 18);
            this.lblCodigoCliente.TabIndex = 157;
            this.lblCodigoCliente.Text = "Codigo Cliente:";
            this.lblCodigoCliente.Click += new System.EventHandler(this.lblCodigoCliente_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Navy;
            this.label6.Location = new System.Drawing.Point(238, 177);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(157, 18);
            this.label6.TabIndex = 158;
            this.label6.Text = "Nombre del Cliente:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Navy;
            this.label8.Location = new System.Drawing.Point(452, 176);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(90, 18);
            this.label8.TabIndex = 163;
            this.label8.Text = "Disponible:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Navy;
            this.label7.Location = new System.Drawing.Point(563, 177);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(91, 18);
            this.label7.TabIndex = 164;
            this.label7.Text = "Descuento:";
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.DimGray;
            this.panel8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel8.Location = new System.Drawing.Point(16, 162);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(787, 4);
            this.panel8.TabIndex = 167;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(51, 154);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 19);
            this.label1.TabIndex = 168;
            this.label1.Text = "Cliente";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(13)))), ((int)(((byte)(66)))));
            this.panel4.Location = new System.Drawing.Point(26, 230);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(147, 2);
            this.panel4.TabIndex = 155;
            // 
            // txtCodigoCliente
            // 
            this.txtCodigoCliente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(191)))), ((int)(((byte)(215)))));
            this.txtCodigoCliente.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCodigoCliente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCodigoCliente.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.txtCodigoCliente.ForeColor = System.Drawing.Color.Indigo;
            this.txtCodigoCliente.Location = new System.Drawing.Point(29, 204);
            this.txtCodigoCliente.Name = "txtCodigoCliente";
            this.txtCodigoCliente.Size = new System.Drawing.Size(147, 22);
            this.txtCodigoCliente.TabIndex = 156;
            this.txtCodigoCliente.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCodigoCliente.Enter += new System.EventHandler(this.txtCodigoCliente_Enter);
            this.txtCodigoCliente.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigoCliente_KeyPress);
            this.txtCodigoCliente.Leave += new System.EventHandler(this.txtCodigoCliente_Leave);
            // 
            // txtNombreCliente
            // 
            this.txtNombreCliente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(191)))), ((int)(((byte)(215)))));
            this.txtNombreCliente.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNombreCliente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNombreCliente.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombreCliente.ForeColor = System.Drawing.Color.Indigo;
            this.txtNombreCliente.Location = new System.Drawing.Point(180, 204);
            this.txtNombreCliente.Name = "txtNombreCliente";
            this.txtNombreCliente.ReadOnly = true;
            this.txtNombreCliente.Size = new System.Drawing.Size(260, 20);
            this.txtNombreCliente.TabIndex = 159;
            this.txtNombreCliente.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(13)))), ((int)(((byte)(66)))));
            this.panel5.Location = new System.Drawing.Point(180, 230);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(260, 2);
            this.panel5.TabIndex = 160;
            // 
            // txtDisponibleCliente
            // 
            this.txtDisponibleCliente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(191)))), ((int)(((byte)(215)))));
            this.txtDisponibleCliente.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDisponibleCliente.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDisponibleCliente.ForeColor = System.Drawing.Color.Indigo;
            this.txtDisponibleCliente.Location = new System.Drawing.Point(446, 203);
            this.txtDisponibleCliente.Name = "txtDisponibleCliente";
            this.txtDisponibleCliente.ReadOnly = true;
            this.txtDisponibleCliente.Size = new System.Drawing.Size(106, 20);
            this.txtDisponibleCliente.TabIndex = 161;
            this.txtDisponibleCliente.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip1.SetToolTip(this.txtDisponibleCliente, "Monto disponible mensual para el descuento");
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(13)))), ((int)(((byte)(66)))));
            this.panel6.Location = new System.Drawing.Point(446, 230);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(106, 2);
            this.panel6.TabIndex = 162;
            // 
            // txtDescuentoCliente
            // 
            this.txtDescuentoCliente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(191)))), ((int)(((byte)(215)))));
            this.txtDescuentoCliente.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDescuentoCliente.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescuentoCliente.ForeColor = System.Drawing.Color.Indigo;
            this.txtDescuentoCliente.Location = new System.Drawing.Point(558, 202);
            this.txtDescuentoCliente.Name = "txtDescuentoCliente";
            this.txtDescuentoCliente.ReadOnly = true;
            this.txtDescuentoCliente.Size = new System.Drawing.Size(106, 20);
            this.txtDescuentoCliente.TabIndex = 165;
            this.txtDescuentoCliente.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip1.SetToolTip(this.txtDescuentoCliente, "Corresponde al % de descuento que tiene cada cliente");
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(45)))), ((int)(((byte)(64)))));
            this.panel7.Location = new System.Drawing.Point(558, 230);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(106, 2);
            this.panel7.TabIndex = 166;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Navy;
            this.label9.Location = new System.Drawing.Point(871, 176);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(71, 18);
            this.label9.TabIndex = 169;
            this.label9.Text = "Bodega:";
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.DimGray;
            this.panel9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel9.Location = new System.Drawing.Point(16, 236);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(787, 4);
            this.panel9.TabIndex = 170;
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.Color.Transparent;
            this.panel10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel10.Location = new System.Drawing.Point(800, 163);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(5, 77);
            this.panel10.TabIndex = 172;
            // 
            // panel11
            // 
            this.panel11.BackColor = System.Drawing.Color.DimGray;
            this.panel11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel11.Location = new System.Drawing.Point(15, 164);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(5, 75);
            this.panel11.TabIndex = 173;
            // 
            // cboBodega
            // 
            this.cboBodega.BackColor = System.Drawing.Color.Silver;
            this.cboBodega.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBodega.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold);
            this.cboBodega.ForeColor = System.Drawing.Color.Indigo;
            this.cboBodega.FormattingEnabled = true;
            this.cboBodega.Location = new System.Drawing.Point(862, 202);
            this.cboBodega.Name = "cboBodega";
            this.cboBodega.Size = new System.Drawing.Size(289, 28);
            this.cboBodega.TabIndex = 174;
            // 
            // lblCodigoArticulo
            // 
            this.lblCodigoArticulo.AutoSize = true;
            this.lblCodigoArticulo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblCodigoArticulo.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblCodigoArticulo.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblCodigoArticulo.Location = new System.Drawing.Point(21, 250);
            this.lblCodigoArticulo.Name = "lblCodigoArticulo";
            this.lblCodigoArticulo.Size = new System.Drawing.Size(194, 18);
            this.lblCodigoArticulo.TabIndex = 175;
            this.lblCodigoArticulo.Text = "Código del Artículo - F12:";
            this.lblCodigoArticulo.Click += new System.EventHandler(this.lblCodigoArticulo_Click);
            // 
            // txtCodigoBarra
            // 
            this.txtCodigoBarra.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(191)))), ((int)(((byte)(215)))));
            this.txtCodigoBarra.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCodigoBarra.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCodigoBarra.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.txtCodigoBarra.ForeColor = System.Drawing.Color.Indigo;
            this.txtCodigoBarra.Location = new System.Drawing.Point(21, 276);
            this.txtCodigoBarra.Name = "txtCodigoBarra";
            this.txtCodigoBarra.Size = new System.Drawing.Size(260, 22);
            this.txtCodigoBarra.TabIndex = 176;
            this.txtCodigoBarra.Enter += new System.EventHandler(this.txtCodigoBarra_Enter);
            this.txtCodigoBarra.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigoBarra_KeyPress);
            this.txtCodigoBarra.Leave += new System.EventHandler(this.txtCodigoBarra_Leave);
            // 
            // panel12
            // 
            this.panel12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(13)))), ((int)(((byte)(66)))));
            this.panel12.Location = new System.Drawing.Point(21, 302);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(260, 2);
            this.panel12.TabIndex = 177;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Navy;
            this.label11.Location = new System.Drawing.Point(306, 249);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(186, 18);
            this.label11.TabIndex = 178;
            this.label11.Text = "Descripción del Artículo";
            // 
            // txtDescripcionArticulo
            // 
            this.txtDescripcionArticulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(191)))), ((int)(((byte)(215)))));
            this.txtDescripcionArticulo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDescripcionArticulo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescripcionArticulo.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescripcionArticulo.ForeColor = System.Drawing.Color.Indigo;
            this.txtDescripcionArticulo.Location = new System.Drawing.Point(306, 275);
            this.txtDescripcionArticulo.Name = "txtDescripcionArticulo";
            this.txtDescripcionArticulo.ReadOnly = true;
            this.txtDescripcionArticulo.Size = new System.Drawing.Size(395, 20);
            this.txtDescripcionArticulo.TabIndex = 179;
            // 
            // panel13
            // 
            this.panel13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(13)))), ((int)(((byte)(66)))));
            this.panel13.Location = new System.Drawing.Point(306, 302);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(395, 2);
            this.panel13.TabIndex = 180;
            // 
            // txtObservaciones
            // 
            this.txtObservaciones.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtObservaciones.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtObservaciones.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold);
            this.txtObservaciones.ForeColor = System.Drawing.Color.Indigo;
            this.txtObservaciones.Location = new System.Drawing.Point(15, 556);
            this.txtObservaciones.Multiline = true;
            this.txtObservaciones.Name = "txtObservaciones";
            this.txtObservaciones.Size = new System.Drawing.Size(354, 98);
            this.txtObservaciones.TabIndex = 182;
            this.txtObservaciones.Enter += new System.EventHandler(this.txtObservaciones_Enter);
            this.txtObservaciones.Leave += new System.EventHandler(this.txtObservaciones_Leave);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Navy;
            this.label4.Location = new System.Drawing.Point(20, 524);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(148, 18);
            this.label4.TabIndex = 183;
            this.label4.Text = "Observaciones - F5";
            // 
            // label17
            // 
            this.label17.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold);
            this.label17.ForeColor = System.Drawing.Color.Navy;
            this.label17.Location = new System.Drawing.Point(1062, 555);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(126, 18);
            this.label17.TabIndex = 188;
            this.label17.Text = "TOTAL A PAGAR:";
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold);
            this.label16.ForeColor = System.Drawing.Color.Navy;
            this.label16.Location = new System.Drawing.Point(982, 555);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(38, 18);
            this.label16.TabIndex = 187;
            this.label16.Text = "IVA:";
            // 
            // label15
            // 
            this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold);
            this.label15.ForeColor = System.Drawing.Color.Navy;
            this.label15.Location = new System.Drawing.Point(832, 537);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(91, 36);
            this.label15.TabIndex = 186;
            this.label15.Text = "Sub Total \r\nDescuento:";
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold);
            this.label14.ForeColor = System.Drawing.Color.Navy;
            this.label14.Location = new System.Drawing.Point(700, 560);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(91, 18);
            this.label14.TabIndex = 185;
            this.label14.Text = "Descuento:";
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold);
            this.label13.ForeColor = System.Drawing.Color.Navy;
            this.label13.Location = new System.Drawing.Point(577, 559);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(77, 18);
            this.label13.TabIndex = 184;
            this.label13.Text = "Sub Total:";
            // 
            // chkDescuentoGeneral
            // 
            this.chkDescuentoGeneral.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkDescuentoGeneral.AutoSize = true;
            this.chkDescuentoGeneral.Enabled = false;
            this.chkDescuentoGeneral.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkDescuentoGeneral.ForeColor = System.Drawing.Color.DarkGreen;
            this.chkDescuentoGeneral.Location = new System.Drawing.Point(373, 517);
            this.chkDescuentoGeneral.Name = "chkDescuentoGeneral";
            this.chkDescuentoGeneral.Size = new System.Drawing.Size(171, 23);
            this.chkDescuentoGeneral.TabIndex = 0;
            this.chkDescuentoGeneral.Text = "(F6) - Descuento %";
            this.chkDescuentoGeneral.UseVisualStyleBackColor = true;
            this.chkDescuentoGeneral.Click += new System.EventHandler(this.chkDescuentoGeneral_Click);
            // 
            // txtSubTotalCordobas
            // 
            this.txtSubTotalCordobas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSubTotalCordobas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(191)))), ((int)(((byte)(215)))));
            this.txtSubTotalCordobas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSubTotalCordobas.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.txtSubTotalCordobas.ForeColor = System.Drawing.Color.Indigo;
            this.txtSubTotalCordobas.Location = new System.Drawing.Point(548, 583);
            this.txtSubTotalCordobas.Name = "txtSubTotalCordobas";
            this.txtSubTotalCordobas.ReadOnly = true;
            this.txtSubTotalCordobas.Size = new System.Drawing.Size(123, 22);
            this.txtSubTotalCordobas.TabIndex = 190;
            this.txtSubTotalCordobas.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel14
            // 
            this.panel14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(13)))), ((int)(((byte)(66)))));
            this.panel14.Location = new System.Drawing.Point(547, 610);
            this.panel14.Name = "panel14";
            this.panel14.Size = new System.Drawing.Size(123, 2);
            this.panel14.TabIndex = 191;
            // 
            // panel15
            // 
            this.panel15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(13)))), ((int)(((byte)(66)))));
            this.panel15.Location = new System.Drawing.Point(684, 610);
            this.panel15.Name = "panel15";
            this.panel15.Size = new System.Drawing.Size(123, 2);
            this.panel15.TabIndex = 193;
            // 
            // txtDescuentoCordobas
            // 
            this.txtDescuentoCordobas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescuentoCordobas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(191)))), ((int)(((byte)(215)))));
            this.txtDescuentoCordobas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDescuentoCordobas.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.txtDescuentoCordobas.ForeColor = System.Drawing.Color.Indigo;
            this.txtDescuentoCordobas.Location = new System.Drawing.Point(684, 583);
            this.txtDescuentoCordobas.Name = "txtDescuentoCordobas";
            this.txtDescuentoCordobas.ReadOnly = true;
            this.txtDescuentoCordobas.Size = new System.Drawing.Size(123, 22);
            this.txtDescuentoCordobas.TabIndex = 192;
            this.txtDescuentoCordobas.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel16
            // 
            this.panel16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(13)))), ((int)(((byte)(66)))));
            this.panel16.Location = new System.Drawing.Point(821, 608);
            this.panel16.Name = "panel16";
            this.panel16.Size = new System.Drawing.Size(123, 2);
            this.panel16.TabIndex = 195;
            // 
            // txtSubTotalDescuentoCordobas
            // 
            this.txtSubTotalDescuentoCordobas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSubTotalDescuentoCordobas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(191)))), ((int)(((byte)(215)))));
            this.txtSubTotalDescuentoCordobas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSubTotalDescuentoCordobas.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.txtSubTotalDescuentoCordobas.ForeColor = System.Drawing.Color.Indigo;
            this.txtSubTotalDescuentoCordobas.Location = new System.Drawing.Point(819, 581);
            this.txtSubTotalDescuentoCordobas.Name = "txtSubTotalDescuentoCordobas";
            this.txtSubTotalDescuentoCordobas.ReadOnly = true;
            this.txtSubTotalDescuentoCordobas.Size = new System.Drawing.Size(123, 22);
            this.txtSubTotalDescuentoCordobas.TabIndex = 194;
            this.txtSubTotalDescuentoCordobas.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel17
            // 
            this.panel17.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(13)))), ((int)(((byte)(66)))));
            this.panel17.Location = new System.Drawing.Point(959, 608);
            this.panel17.Name = "panel17";
            this.panel17.Size = new System.Drawing.Size(93, 2);
            this.panel17.TabIndex = 197;
            // 
            // txtIVACordobas
            // 
            this.txtIVACordobas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtIVACordobas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(191)))), ((int)(((byte)(215)))));
            this.txtIVACordobas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtIVACordobas.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.txtIVACordobas.ForeColor = System.Drawing.Color.Indigo;
            this.txtIVACordobas.Location = new System.Drawing.Point(959, 581);
            this.txtIVACordobas.Name = "txtIVACordobas";
            this.txtIVACordobas.ReadOnly = true;
            this.txtIVACordobas.Size = new System.Drawing.Size(93, 22);
            this.txtIVACordobas.TabIndex = 196;
            this.txtIVACordobas.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel18
            // 
            this.panel18.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel18.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(13)))), ((int)(((byte)(66)))));
            this.panel18.Location = new System.Drawing.Point(1064, 608);
            this.panel18.Name = "panel18";
            this.panel18.Size = new System.Drawing.Size(123, 2);
            this.panel18.TabIndex = 199;
            // 
            // txtTotalCordobas
            // 
            this.txtTotalCordobas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTotalCordobas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(191)))), ((int)(((byte)(215)))));
            this.txtTotalCordobas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTotalCordobas.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.txtTotalCordobas.ForeColor = System.Drawing.Color.Indigo;
            this.txtTotalCordobas.Location = new System.Drawing.Point(1064, 581);
            this.txtTotalCordobas.Name = "txtTotalCordobas";
            this.txtTotalCordobas.ReadOnly = true;
            this.txtTotalCordobas.Size = new System.Drawing.Size(123, 22);
            this.txtTotalCordobas.TabIndex = 198;
            this.txtTotalCordobas.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel19
            // 
            this.panel19.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel19.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(13)))), ((int)(((byte)(66)))));
            this.panel19.Location = new System.Drawing.Point(1064, 650);
            this.panel19.Name = "panel19";
            this.panel19.Size = new System.Drawing.Size(123, 2);
            this.panel19.TabIndex = 209;
            // 
            // txtTotalDolares
            // 
            this.txtTotalDolares.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTotalDolares.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(191)))), ((int)(((byte)(215)))));
            this.txtTotalDolares.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTotalDolares.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.txtTotalDolares.ForeColor = System.Drawing.Color.Indigo;
            this.txtTotalDolares.Location = new System.Drawing.Point(1064, 624);
            this.txtTotalDolares.Name = "txtTotalDolares";
            this.txtTotalDolares.ReadOnly = true;
            this.txtTotalDolares.Size = new System.Drawing.Size(123, 22);
            this.txtTotalDolares.TabIndex = 208;
            this.txtTotalDolares.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel20
            // 
            this.panel20.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel20.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(13)))), ((int)(((byte)(66)))));
            this.panel20.Location = new System.Drawing.Point(959, 650);
            this.panel20.Name = "panel20";
            this.panel20.Size = new System.Drawing.Size(93, 2);
            this.panel20.TabIndex = 207;
            // 
            // txtIVADolares
            // 
            this.txtIVADolares.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtIVADolares.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(191)))), ((int)(((byte)(215)))));
            this.txtIVADolares.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtIVADolares.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIVADolares.ForeColor = System.Drawing.Color.Indigo;
            this.txtIVADolares.Location = new System.Drawing.Point(959, 624);
            this.txtIVADolares.Name = "txtIVADolares";
            this.txtIVADolares.ReadOnly = true;
            this.txtIVADolares.Size = new System.Drawing.Size(93, 22);
            this.txtIVADolares.TabIndex = 206;
            this.txtIVADolares.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel21
            // 
            this.panel21.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel21.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(13)))), ((int)(((byte)(66)))));
            this.panel21.Location = new System.Drawing.Point(821, 650);
            this.panel21.Name = "panel21";
            this.panel21.Size = new System.Drawing.Size(123, 2);
            this.panel21.TabIndex = 205;
            // 
            // txtSubTotalDescuentoDolares
            // 
            this.txtSubTotalDescuentoDolares.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSubTotalDescuentoDolares.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(191)))), ((int)(((byte)(215)))));
            this.txtSubTotalDescuentoDolares.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSubTotalDescuentoDolares.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSubTotalDescuentoDolares.ForeColor = System.Drawing.Color.Indigo;
            this.txtSubTotalDescuentoDolares.Location = new System.Drawing.Point(819, 624);
            this.txtSubTotalDescuentoDolares.Name = "txtSubTotalDescuentoDolares";
            this.txtSubTotalDescuentoDolares.ReadOnly = true;
            this.txtSubTotalDescuentoDolares.Size = new System.Drawing.Size(123, 22);
            this.txtSubTotalDescuentoDolares.TabIndex = 204;
            this.txtSubTotalDescuentoDolares.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel22
            // 
            this.panel22.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel22.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(13)))), ((int)(((byte)(66)))));
            this.panel22.Location = new System.Drawing.Point(690, 650);
            this.panel22.Name = "panel22";
            this.panel22.Size = new System.Drawing.Size(123, 2);
            this.panel22.TabIndex = 203;
            // 
            // txtDescuentoDolares
            // 
            this.txtDescuentoDolares.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescuentoDolares.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(191)))), ((int)(((byte)(215)))));
            this.txtDescuentoDolares.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDescuentoDolares.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.txtDescuentoDolares.ForeColor = System.Drawing.Color.Indigo;
            this.txtDescuentoDolares.Location = new System.Drawing.Point(689, 624);
            this.txtDescuentoDolares.Name = "txtDescuentoDolares";
            this.txtDescuentoDolares.ReadOnly = true;
            this.txtDescuentoDolares.Size = new System.Drawing.Size(123, 22);
            this.txtDescuentoDolares.TabIndex = 202;
            this.txtDescuentoDolares.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel23
            // 
            this.panel23.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel23.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(13)))), ((int)(((byte)(66)))));
            this.panel23.Location = new System.Drawing.Point(550, 650);
            this.panel23.Name = "panel23";
            this.panel23.Size = new System.Drawing.Size(123, 2);
            this.panel23.TabIndex = 201;
            // 
            // txtSubTotalDolares
            // 
            this.txtSubTotalDolares.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSubTotalDolares.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(191)))), ((int)(((byte)(215)))));
            this.txtSubTotalDolares.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSubTotalDolares.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.txtSubTotalDolares.ForeColor = System.Drawing.Color.Indigo;
            this.txtSubTotalDolares.Location = new System.Drawing.Point(547, 624);
            this.txtSubTotalDolares.Name = "txtSubTotalDolares";
            this.txtSubTotalDolares.ReadOnly = true;
            this.txtSubTotalDolares.Size = new System.Drawing.Size(123, 22);
            this.txtSubTotalDolares.TabIndex = 200;
            this.txtSubTotalDolares.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel24
            // 
            this.panel24.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel24.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(57)))), ((int)(((byte)(85)))));
            this.panel24.Location = new System.Drawing.Point(696, 548);
            this.panel24.Name = "panel24";
            this.panel24.Size = new System.Drawing.Size(93, 2);
            this.panel24.TabIndex = 211;
            // 
            // txtPorcenDescuentGeneral
            // 
            this.txtPorcenDescuentGeneral.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPorcenDescuentGeneral.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(191)))), ((int)(((byte)(215)))));
            this.txtPorcenDescuentGeneral.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPorcenDescuentGeneral.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPorcenDescuentGeneral.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.txtPorcenDescuentGeneral.Location = new System.Drawing.Point(693, 514);
            this.txtPorcenDescuentGeneral.Name = "txtPorcenDescuentGeneral";
            this.txtPorcenDescuentGeneral.Size = new System.Drawing.Size(93, 29);
            this.txtPorcenDescuentGeneral.TabIndex = 2;
            this.txtPorcenDescuentGeneral.Text = "0";
            this.txtPorcenDescuentGeneral.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPorcenDescuentGeneral.TextChanged += new System.EventHandler(this.TxtPorcenDescuentGeneral_TextChanged);
            this.txtPorcenDescuentGeneral.Enter += new System.EventHandler(this.txtPorcenDescuentGeneral_Enter);
            this.txtPorcenDescuentGeneral.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPorcenDescuentGeneral_KeyDown);
            this.txtPorcenDescuentGeneral.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPorcenDescuentGeneral_KeyPress);
            this.txtPorcenDescuentGeneral.Leave += new System.EventHandler(this.txtPorcenDescuentGeneral_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label3.Location = new System.Drawing.Point(670, 177);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 18);
            this.label3.TabIndex = 213;
            this.label3.Text = "Cred. Cort Plz:";
            // 
            // panel25
            // 
            this.panel25.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(45)))), ((int)(((byte)(64)))));
            this.panel25.Location = new System.Drawing.Point(675, 230);
            this.panel25.Name = "panel25";
            this.panel25.Size = new System.Drawing.Size(106, 2);
            this.panel25.TabIndex = 216;
            // 
            // txtCreditoCortoPlazo
            // 
            this.txtCreditoCortoPlazo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(191)))), ((int)(((byte)(215)))));
            this.txtCreditoCortoPlazo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCreditoCortoPlazo.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCreditoCortoPlazo.ForeColor = System.Drawing.Color.Indigo;
            this.txtCreditoCortoPlazo.Location = new System.Drawing.Point(675, 203);
            this.txtCreditoCortoPlazo.Name = "txtCreditoCortoPlazo";
            this.txtCreditoCortoPlazo.ReadOnly = true;
            this.txtCreditoCortoPlazo.Size = new System.Drawing.Size(106, 20);
            this.txtCreditoCortoPlazo.TabIndex = 215;
            this.txtCreditoCortoPlazo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip1.SetToolTip(this.txtCreditoCortoPlazo, "2do Credito disponible para clientes Militares, \r\nEmpleados y otros, disponible s" +
        "olo para super");
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.Navy;
            this.label18.Location = new System.Drawing.Point(16, 314);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(134, 16);
            this.label18.TabIndex = 217;
            this.label18.Text = "Detalles de la Factura";
            // 
            // cboTipoDescuento
            // 
            this.cboTipoDescuento.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cboTipoDescuento.BackColor = System.Drawing.Color.Silver;
            this.cboTipoDescuento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoDescuento.Enabled = false;
            this.cboTipoDescuento.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold);
            this.cboTipoDescuento.ForeColor = System.Drawing.Color.Indigo;
            this.cboTipoDescuento.FormattingEnabled = true;
            this.cboTipoDescuento.Items.AddRange(new object[] {
            "General",
            "Autorizado"});
            this.cboTipoDescuento.Location = new System.Drawing.Point(548, 514);
            this.cboTipoDescuento.Name = "cboTipoDescuento";
            this.cboTipoDescuento.Size = new System.Drawing.Size(140, 28);
            this.cboTipoDescuento.TabIndex = 1;
            this.toolTip1.SetToolTip(this.cboTipoDescuento, "Seleccionar el Tipo de Descuento");
            this.cboTipoDescuento.SelectedIndexChanged += new System.EventHandler(this.cboTipoDescuento_SelectedIndexChanged);
            // 
            // lblCaja
            // 
            this.lblCaja.AutoSize = true;
            this.lblCaja.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(45)))), ((int)(((byte)(64)))));
            this.lblCaja.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.lblCaja.ForeColor = System.Drawing.Color.White;
            this.lblCaja.Location = new System.Drawing.Point(562, 106);
            this.lblCaja.Name = "lblCaja";
            this.lblCaja.Size = new System.Drawing.Size(51, 19);
            this.lblCaja.TabIndex = 219;
            this.lblCaja.Text = "Caja:";
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
            this.dgvDetalleFactura.BackgroundColor = System.Drawing.SystemColors.InactiveCaption;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Snow;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(13)))), ((int)(((byte)(66)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetalleFactura.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDetalleFactura.ColumnHeadersHeight = 25;
            this.dgvDetalleFactura.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Consecutivo,
            this.ArticuloId,
            this.CodigoBarra,
            this.Cantidad,
            this.PorcentDescuentArticulo,
            this.Descripcion,
            this.Unidad,
            this.Existencia,
            this.Lote,
            this.UnidadFraccion,
            this.PrecioCordobas,
            this.PrecioDolar,
            this.Moneda,
            this.BodegaId,
            this.NombreBodega,
            this.SubTotalCordobas,
            this.SubTotalDolar,
            this.DescuentoPorLineaCordoba,
            this.DescuentoPorLineaDolar,
            this.MontoDescGeneralCordoba,
            this.MontoDescGeneralDolar,
            this.TotalCordobas,
            this.TotalDolar,
            this.Cost_Prom_Loc,
            this.Cost_Prom_Dol,
            this.Cantidad_d,
            this.PorcentDescuentArticulo_d});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.DarkGoldenrod;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDetalleFactura.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDetalleFactura.EnableHeadersVisualStyles = false;
            this.dgvDetalleFactura.GridColor = System.Drawing.Color.DarkGoldenrod;
            this.dgvDetalleFactura.Location = new System.Drawing.Point(9, 335);
            this.dgvDetalleFactura.MultiSelect = false;
            this.dgvDetalleFactura.Name = "dgvDetalleFactura";
            this.dgvDetalleFactura.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetalleFactura.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvDetalleFactura.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgvDetalleFactura.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetalleFactura.Size = new System.Drawing.Size(1190, 172);
            this.dgvDetalleFactura.TabIndex = 220;
            this.dgvDetalleFactura.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetalleFactura_CellEndEdit);
            this.dgvDetalleFactura.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetalleFactura_CellEnter);
            this.dgvDetalleFactura.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetalleFactura_CellLeave);
            this.dgvDetalleFactura.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvDetalleFactura_EditingControlShowing);
            // 
            // Consecutivo
            // 
            this.Consecutivo.HeaderText = "Consecutivo";
            this.Consecutivo.Name = "Consecutivo";
            this.Consecutivo.ReadOnly = true;
            this.Consecutivo.Visible = false;
            this.Consecutivo.Width = 125;
            // 
            // ArticuloId
            // 
            this.ArticuloId.HeaderText = "ArticuloId";
            this.ArticuloId.Name = "ArticuloId";
            this.ArticuloId.ReadOnly = true;
            this.ArticuloId.Width = 104;
            // 
            // CodigoBarra
            // 
            this.CodigoBarra.HeaderText = "CodigoBarra";
            this.CodigoBarra.Name = "CodigoBarra";
            this.CodigoBarra.ReadOnly = true;
            this.CodigoBarra.Visible = false;
            this.CodigoBarra.Width = 128;
            // 
            // Cantidad
            // 
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.MaxInputLength = 50;
            this.Cantidad.Name = "Cantidad";
            this.Cantidad.Width = 102;
            // 
            // PorcentDescuentArticulo
            // 
            this.PorcentDescuentArticulo.HeaderText = "Descuento %";
            this.PorcentDescuentArticulo.MaxInputLength = 50;
            this.PorcentDescuentArticulo.Name = "PorcentDescuentArticulo";
            this.PorcentDescuentArticulo.ReadOnly = true;
            this.PorcentDescuentArticulo.Width = 129;
            // 
            // Descripcion
            // 
            this.Descripcion.HeaderText = "Descripcion";
            this.Descripcion.Name = "Descripcion";
            this.Descripcion.ReadOnly = true;
            this.Descripcion.Width = 122;
            // 
            // Unidad
            // 
            this.Unidad.HeaderText = "Unidad";
            this.Unidad.Name = "Unidad";
            this.Unidad.ReadOnly = true;
            this.Unidad.Width = 86;
            // 
            // Existencia
            // 
            this.Existencia.HeaderText = "Existencia";
            this.Existencia.Name = "Existencia";
            this.Existencia.ReadOnly = true;
            this.Existencia.Width = 106;
            // 
            // Lote
            // 
            this.Lote.HeaderText = "Lote";
            this.Lote.Name = "Lote";
            this.Lote.ReadOnly = true;
            this.Lote.Width = 64;
            // 
            // UnidadFraccion
            // 
            this.UnidadFraccion.HeaderText = "UnidadFraccion";
            this.UnidadFraccion.Name = "UnidadFraccion";
            this.UnidadFraccion.ReadOnly = true;
            this.UnidadFraccion.Visible = false;
            this.UnidadFraccion.Width = 151;
            // 
            // PrecioCordobas
            // 
            this.PrecioCordobas.HeaderText = "Precio C$";
            this.PrecioCordobas.Name = "PrecioCordobas";
            this.PrecioCordobas.ReadOnly = true;
            this.PrecioCordobas.Width = 104;
            // 
            // PrecioDolar
            // 
            this.PrecioDolar.HeaderText = "Precio U$";
            this.PrecioDolar.Name = "PrecioDolar";
            this.PrecioDolar.ReadOnly = true;
            this.PrecioDolar.Width = 102;
            // 
            // Moneda
            // 
            this.Moneda.HeaderText = "Moneda";
            this.Moneda.Name = "Moneda";
            this.Moneda.ReadOnly = true;
            this.Moneda.Visible = false;
            this.Moneda.Width = 96;
            // 
            // BodegaId
            // 
            this.BodegaId.HeaderText = "BodegaId";
            this.BodegaId.Name = "BodegaId";
            this.BodegaId.ReadOnly = true;
            this.BodegaId.Visible = false;
            this.BodegaId.Width = 106;
            // 
            // NombreBodega
            // 
            this.NombreBodega.HeaderText = "NombreBodega";
            this.NombreBodega.Name = "NombreBodega";
            this.NombreBodega.ReadOnly = true;
            this.NombreBodega.Visible = false;
            this.NombreBodega.Width = 152;
            // 
            // SubTotalCordobas
            // 
            this.SubTotalCordobas.HeaderText = "Sub Total C$";
            this.SubTotalCordobas.Name = "SubTotalCordobas";
            this.SubTotalCordobas.ReadOnly = true;
            this.SubTotalCordobas.Width = 122;
            // 
            // SubTotalDolar
            // 
            this.SubTotalDolar.HeaderText = "Sub Total U$";
            this.SubTotalDolar.Name = "SubTotalDolar";
            this.SubTotalDolar.ReadOnly = true;
            this.SubTotalDolar.Width = 120;
            // 
            // DescuentoPorLineaCordoba
            // 
            this.DescuentoPorLineaCordoba.HeaderText = "Descuento C$";
            this.DescuentoPorLineaCordoba.Name = "DescuentoPorLineaCordoba";
            this.DescuentoPorLineaCordoba.ReadOnly = true;
            this.DescuentoPorLineaCordoba.Width = 136;
            // 
            // DescuentoPorLineaDolar
            // 
            this.DescuentoPorLineaDolar.HeaderText = "Descuento U$";
            this.DescuentoPorLineaDolar.Name = "DescuentoPorLineaDolar";
            this.DescuentoPorLineaDolar.ReadOnly = true;
            this.DescuentoPorLineaDolar.Width = 134;
            // 
            // MontoDescGeneralCordoba
            // 
            this.MontoDescGeneralCordoba.HeaderText = "MontoDescGeneralCordoba";
            this.MontoDescGeneralCordoba.Name = "MontoDescGeneralCordoba";
            this.MontoDescGeneralCordoba.ReadOnly = true;
            this.MontoDescGeneralCordoba.Visible = false;
            this.MontoDescGeneralCordoba.Width = 245;
            // 
            // MontoDescGeneralDolar
            // 
            this.MontoDescGeneralDolar.HeaderText = "MontoDescGeneralDolar";
            this.MontoDescGeneralDolar.Name = "MontoDescGeneralDolar";
            this.MontoDescGeneralDolar.ReadOnly = true;
            this.MontoDescGeneralDolar.Visible = false;
            this.MontoDescGeneralDolar.Width = 218;
            // 
            // TotalCordobas
            // 
            this.TotalCordobas.HeaderText = "Total C$";
            this.TotalCordobas.Name = "TotalCordobas";
            this.TotalCordobas.ReadOnly = true;
            this.TotalCordobas.Width = 91;
            // 
            // TotalDolar
            // 
            this.TotalDolar.HeaderText = "Total U$";
            this.TotalDolar.Name = "TotalDolar";
            this.TotalDolar.ReadOnly = true;
            this.TotalDolar.Width = 89;
            // 
            // Cost_Prom_Loc
            // 
            this.Cost_Prom_Loc.HeaderText = "Cost_Prom_Loc";
            this.Cost_Prom_Loc.Name = "Cost_Prom_Loc";
            this.Cost_Prom_Loc.ReadOnly = true;
            this.Cost_Prom_Loc.Visible = false;
            this.Cost_Prom_Loc.Width = 145;
            // 
            // Cost_Prom_Dol
            // 
            this.Cost_Prom_Dol.HeaderText = "Cost_Prom_Dol";
            this.Cost_Prom_Dol.Name = "Cost_Prom_Dol";
            this.Cost_Prom_Dol.ReadOnly = true;
            this.Cost_Prom_Dol.Visible = false;
            this.Cost_Prom_Dol.Width = 143;
            // 
            // Cantidad_d
            // 
            this.Cantidad_d.HeaderText = "Cantidadd";
            this.Cantidad_d.Name = "Cantidad_d";
            this.Cantidad_d.ReadOnly = true;
            this.Cantidad_d.Visible = false;
            this.Cantidad_d.Width = 112;
            // 
            // PorcentDescuentArticulo_d
            // 
            this.PorcentDescuentArticulo_d.HeaderText = "PorcentDescuentArticulo_d";
            this.PorcentDescuentArticulo_d.Name = "PorcentDescuentArticulo_d";
            this.PorcentDescuentArticulo_d.ReadOnly = true;
            this.PorcentDescuentArticulo_d.Visible = false;
            this.PorcentDescuentArticulo_d.Width = 233;
            // 
            // lblDescripcionPeso
            // 
            this.lblDescripcionPeso.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDescripcionPeso.AutoSize = true;
            this.lblDescripcionPeso.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblDescripcionPeso.Font = new System.Drawing.Font("Arial Narrow", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescripcionPeso.ForeColor = System.Drawing.Color.Maroon;
            this.lblDescripcionPeso.Location = new System.Drawing.Point(9, 28);
            this.lblDescripcionPeso.Name = "lblDescripcionPeso";
            this.lblDescripcionPeso.Size = new System.Drawing.Size(161, 29);
            this.lblDescripcionPeso.TabIndex = 221;
            this.lblDescripcionPeso.Text = "Peso Kg (Alt+P)";
            this.lblDescripcionPeso.Click += new System.EventHandler(this.lblDescripcionPeso_Click);
            // 
            // lblPesoKg
            // 
            this.lblPesoKg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPesoKg.AutoSize = true;
            this.lblPesoKg.Font = new System.Drawing.Font("Arial Narrow", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPesoKg.ForeColor = System.Drawing.Color.Maroon;
            this.lblPesoKg.Location = new System.Drawing.Point(181, 12);
            this.lblPesoKg.Name = "lblPesoKg";
            this.lblPesoKg.Size = new System.Drawing.Size(209, 57);
            this.lblPesoKg.TabIndex = 222;
            this.lblPesoKg.Text = "00.000 Kg";
            // 
            // pnlInfBascula
            // 
            this.pnlInfBascula.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlInfBascula.BackColor = System.Drawing.Color.Azure;
            this.pnlInfBascula.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlInfBascula.Controls.Add(this.lblDescripcionPeso);
            this.pnlInfBascula.Controls.Add(this.lblPesoKg);
            this.pnlInfBascula.Location = new System.Drawing.Point(787, 250);
            this.pnlInfBascula.Name = "pnlInfBascula";
            this.pnlInfBascula.Size = new System.Drawing.Size(408, 80);
            this.pnlInfBascula.TabIndex = 223;
            this.pnlInfBascula.Visible = false;
            // 
            // frmVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(191)))), ((int)(((byte)(215)))));
            this.ClientSize = new System.Drawing.Size(1207, 666);
            this.ControlBox = false;
            this.Controls.Add(this.pnlInfBascula);
            this.Controls.Add(this.cboTipoDescuento);
            this.Controls.Add(this.dgvDetalleFactura);
            this.Controls.Add(this.lblCaja);
            this.Controls.Add(this.txtPorcenDescuentGeneral);
            this.Controls.Add(this.panel24);
            this.Controls.Add(this.chkDescuentoGeneral);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.panel25);
            this.Controls.Add(this.txtCreditoCortoPlazo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel19);
            this.Controls.Add(this.txtTotalDolares);
            this.Controls.Add(this.panel20);
            this.Controls.Add(this.txtIVADolares);
            this.Controls.Add(this.panel21);
            this.Controls.Add(this.txtSubTotalDescuentoDolares);
            this.Controls.Add(this.panel22);
            this.Controls.Add(this.txtDescuentoDolares);
            this.Controls.Add(this.panel23);
            this.Controls.Add(this.txtSubTotalDolares);
            this.Controls.Add(this.panel18);
            this.Controls.Add(this.txtTotalCordobas);
            this.Controls.Add(this.panel17);
            this.Controls.Add(this.txtIVACordobas);
            this.Controls.Add(this.panel16);
            this.Controls.Add(this.txtSubTotalDescuentoCordobas);
            this.Controls.Add(this.panel15);
            this.Controls.Add(this.txtDescuentoCordobas);
            this.Controls.Add(this.panel14);
            this.Controls.Add(this.txtSubTotalCordobas);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtObservaciones);
            this.Controls.Add(this.panel13);
            this.Controls.Add(this.txtDescripcionArticulo);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.panel12);
            this.Controls.Add(this.txtCodigoBarra);
            this.Controls.Add(this.lblCodigoArticulo);
            this.Controls.Add(this.cboBodega);
            this.Controls.Add(this.panel11);
            this.Controls.Add(this.panel10);
            this.Controls.Add(this.panel9);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel8);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.txtDescuentoCliente);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.txtDisponibleCliente);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.txtNombreCliente);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblCodigoCliente);
            this.Controls.Add(this.txtCodigoCliente);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.pictureBox26);
            this.Controls.Add(this.lblNoFactura);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.lblTipoCambio);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.barraTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmVentas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ventas";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmVentas_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmVentas_KeyDown);
            this.barraTitulo.ResumeLayout(false);
            this.barraTitulo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnRestaurar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMminizar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMaximizar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox26)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleFactura)).EndInit();
            this.pnlInfBascula.ResumeLayout(false);
            this.pnlInfBascula.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel barraTitulo;
        private System.Windows.Forms.PictureBox btnRestaurar;
        private System.Windows.Forms.PictureBox btnCerrar;
        private System.Windows.Forms.PictureBox btnMminizar;
        private System.Windows.Forms.PictureBox btnMaximizar;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnCobrar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label lblNoFactura;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Label lblTipoCambio;
        private System.Windows.Forms.PictureBox pictureBox26;
        private System.Windows.Forms.Label lblCodigoCliente;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox txtCodigoCliente;
        private System.Windows.Forms.TextBox txtNombreCliente;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TextBox txtDisponibleCliente;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.TextBox txtDescuentoCliente;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.ComboBox cboBodega;
        private System.Windows.Forms.Label lblCodigoArticulo;
        private System.Windows.Forms.TextBox txtCodigoBarra;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtDescripcionArticulo;
        private System.Windows.Forms.Panel panel13;
        private System.Windows.Forms.TextBox txtObservaciones;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.CheckBox chkDescuentoGeneral;
        private System.Windows.Forms.TextBox txtSubTotalCordobas;
        private System.Windows.Forms.Panel panel14;
        private System.Windows.Forms.Panel panel15;
        private System.Windows.Forms.TextBox txtDescuentoCordobas;
        private System.Windows.Forms.Panel panel16;
        private System.Windows.Forms.TextBox txtSubTotalDescuentoCordobas;
        private System.Windows.Forms.Panel panel17;
        private System.Windows.Forms.TextBox txtIVACordobas;
        private System.Windows.Forms.Panel panel18;
        private System.Windows.Forms.TextBox txtTotalCordobas;
        private System.Windows.Forms.Panel panel19;
        private System.Windows.Forms.TextBox txtTotalDolares;
        private System.Windows.Forms.Panel panel20;
        private System.Windows.Forms.TextBox txtIVADolares;
        private System.Windows.Forms.Panel panel21;
        private System.Windows.Forms.TextBox txtSubTotalDescuentoDolares;
        private System.Windows.Forms.Panel panel22;
        private System.Windows.Forms.TextBox txtDescuentoDolares;
        private System.Windows.Forms.Panel panel23;
        private System.Windows.Forms.TextBox txtSubTotalDolares;
        private System.Windows.Forms.Panel panel24;
        private System.Windows.Forms.TextBox txtPorcenDescuentGeneral;
        private System.Windows.Forms.ToolStripButton btnEliminarArticulo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btnLimpiarFactura;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel25;
        private System.Windows.Forms.TextBox txtCreditoCortoPlazo;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label lblCaja;
        private System.Windows.Forms.DataGridView dgvDetalleFactura;
        private System.Windows.Forms.ToolStripButton btnDescuentoLinea;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton btnEditarCantidad;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ComboBox cboTipoDescuento;
        private System.Windows.Forms.ToolStripButton btnCambiarPrecio;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.Label lblDescripcionPeso;
        private System.Windows.Forms.Label lblPesoKg;
        private System.Windows.Forms.Panel pnlInfBascula;
        private System.Windows.Forms.DataGridViewTextBoxColumn Consecutivo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ArticuloId;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoBarra;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn PorcentDescuentArticulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Unidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Existencia;
        private System.Windows.Forms.DataGridViewTextBoxColumn Lote;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnidadFraccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrecioCordobas;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrecioDolar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Moneda;
        private System.Windows.Forms.DataGridViewTextBoxColumn BodegaId;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreBodega;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubTotalCordobas;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubTotalDolar;
        private System.Windows.Forms.DataGridViewTextBoxColumn DescuentoPorLineaCordoba;
        private System.Windows.Forms.DataGridViewTextBoxColumn DescuentoPorLineaDolar;
        private System.Windows.Forms.DataGridViewTextBoxColumn MontoDescGeneralCordoba;
        private System.Windows.Forms.DataGridViewTextBoxColumn MontoDescGeneralDolar;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalCordobas;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalDolar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cost_Prom_Loc;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cost_Prom_Dol;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad_d;
        private System.Windows.Forms.DataGridViewTextBoxColumn PorcentDescuentArticulo_d;
    }
}