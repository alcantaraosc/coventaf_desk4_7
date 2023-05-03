
namespace COVENTAF.PuntoVenta
{
    partial class frmBuscarCliente
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblTituloCaja = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel25 = new System.Windows.Forms.Panel();
            this.lblClave = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblSupervisor = new System.Windows.Forms.Label();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.dgvPuntoVenta = new System.Windows.Forms.DataGridView();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Identificacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cargo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Activo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.barraTitulo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnCierre)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPuntoVenta)).BeginInit();
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
            this.barraTitulo.Size = new System.Drawing.Size(652, 28);
            this.barraTitulo.TabIndex = 5;
            // 
            // btnCierre
            // 
            this.btnCierre.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCierre.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCierre.Image = global::COVENTAF.Properties.Resources.close_login;
            this.btnCierre.Location = new System.Drawing.Point(620, 3);
            this.btnCierre.Name = "btnCierre";
            this.btnCierre.Size = new System.Drawing.Size(21, 21);
            this.btnCierre.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnCierre.TabIndex = 81;
            this.btnCierre.TabStop = false;
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
            this.btnMinizar.Location = new System.Drawing.Point(1354, -26);
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
            this.btnCerrar.Location = new System.Drawing.Point(1379, -26);
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
            this.lblTitulo.Size = new System.Drawing.Size(124, 19);
            this.lblTitulo.TabIndex = 8;
            this.lblTitulo.Text = "Buscar Clientes";
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
            this.btnMinimizar.Location = new System.Drawing.Point(2088, -63);
            this.btnMinimizar.Name = "btnMinimizar";
            this.btnMinimizar.Size = new System.Drawing.Size(40, 40);
            this.btnMinimizar.TabIndex = 7;
            this.btnMinimizar.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(99)))), ((int)(((byte)(177)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(645, 28);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(7, 422);
            this.panel2.TabIndex = 132;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(99)))), ((int)(((byte)(177)))));
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 443);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(645, 7);
            this.panel3.TabIndex = 134;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(99)))), ((int)(((byte)(177)))));
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(7, 415);
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
            this.label2.Size = new System.Drawing.Size(638, 74);
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
            this.lblTituloCaja.Size = new System.Drawing.Size(150, 23);
            this.lblTituloCaja.TabIndex = 164;
            this.lblTituloCaja.Text = "Buscar Clientes";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(91)))), ((int)(((byte)(13)))));
            this.panel4.Location = new System.Drawing.Point(176, 183);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(237, 2);
            this.panel4.TabIndex = 224;
            // 
            // panel25
            // 
            this.panel25.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(91)))), ((int)(((byte)(13)))));
            this.panel25.Location = new System.Drawing.Point(176, 139);
            this.panel25.Name = "panel25";
            this.panel25.Size = new System.Drawing.Size(237, 2);
            this.panel25.TabIndex = 223;
            // 
            // lblClave
            // 
            this.lblClave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblClave.AutoSize = true;
            this.lblClave.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblClave.ForeColor = System.Drawing.Color.Maroon;
            this.lblClave.Location = new System.Drawing.Point(13, 164);
            this.lblClave.Name = "lblClave";
            this.lblClave.Size = new System.Drawing.Size(157, 18);
            this.lblClave.TabIndex = 222;
            this.lblClave.Text = "Nombre del Cliente:";
            // 
            // txtPassword
            // 
            this.txtPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(191)))), ((int)(((byte)(215)))));
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPassword.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold);
            this.txtPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.txtPassword.Location = new System.Drawing.Point(176, 158);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(236, 20);
            this.txtPassword.TabIndex = 221;
            // 
            // lblSupervisor
            // 
            this.lblSupervisor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSupervisor.AutoSize = true;
            this.lblSupervisor.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblSupervisor.ForeColor = System.Drawing.Color.Maroon;
            this.lblSupervisor.Location = new System.Drawing.Point(45, 118);
            this.lblSupervisor.Name = "lblSupervisor";
            this.lblSupervisor.Size = new System.Drawing.Size(114, 18);
            this.lblSupervisor.TabIndex = 220;
            this.lblSupervisor.Text = "Identificacion:";
            // 
            // txtUser
            // 
            this.txtUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(191)))), ((int)(((byte)(215)))));
            this.txtUser.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUser.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtUser.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold);
            this.txtUser.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.txtUser.Location = new System.Drawing.Point(176, 112);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(236, 20);
            this.txtUser.TabIndex = 219;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.panel5.Location = new System.Drawing.Point(10, 192);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(633, 4);
            this.panel5.TabIndex = 225;
            // 
            // dgvPuntoVenta
            // 
            this.dgvPuntoVenta.AllowUserToAddRows = false;
            this.dgvPuntoVenta.AllowUserToDeleteRows = false;
            this.dgvPuntoVenta.AllowUserToResizeColumns = false;
            this.dgvPuntoVenta.AllowUserToResizeRows = false;
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
            this.dgvPuntoVenta.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Codigo,
            this.Identificacion,
            this.Cliente,
            this.Cargo,
            this.Activo});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.DarkGoldenrod;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPuntoVenta.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvPuntoVenta.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvPuntoVenta.EnableHeadersVisualStyles = false;
            this.dgvPuntoVenta.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dgvPuntoVenta.Location = new System.Drawing.Point(7, 202);
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
            this.dgvPuntoVenta.Size = new System.Drawing.Size(638, 241);
            this.dgvPuntoVenta.TabIndex = 226;
            // 
            // Codigo
            // 
            this.Codigo.HeaderText = "Codigo";
            this.Codigo.Name = "Codigo";
            this.Codigo.ReadOnly = true;
            this.Codigo.Width = 89;
            // 
            // Identificacion
            // 
            this.Identificacion.HeaderText = "Identificacion";
            this.Identificacion.Name = "Identificacion";
            this.Identificacion.ReadOnly = true;
            this.Identificacion.Width = 135;
            // 
            // Cliente
            // 
            this.Cliente.HeaderText = "Cliente";
            this.Cliente.Name = "Cliente";
            this.Cliente.ReadOnly = true;
            this.Cliente.Width = 86;
            // 
            // Cargo
            // 
            this.Cargo.HeaderText = "Cargo";
            this.Cargo.Name = "Cargo";
            this.Cargo.ReadOnly = true;
            this.Cargo.Width = 80;
            // 
            // Activo
            // 
            this.Activo.HeaderText = "Activo";
            this.Activo.Name = "Activo";
            this.Activo.ReadOnly = true;
            this.Activo.Width = 80;
            // 
            // frmBuscarCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(191)))), ((int)(((byte)(215)))));
            this.ClientSize = new System.Drawing.Size(652, 450);
            this.ControlBox = false;
            this.Controls.Add(this.dgvPuntoVenta);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel25);
            this.Controls.Add(this.lblClave);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.lblSupervisor);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.lblTituloCaja);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.barraTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmBuscarCliente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Buscar Clientes";
            this.barraTitulo.ResumeLayout(false);
            this.barraTitulo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnCierre)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPuntoVenta)).EndInit();
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
        private System.Windows.Forms.Label lblClave;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblSupervisor;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.DataGridView dgvPuntoVenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Identificacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cargo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Activo;
    }
}