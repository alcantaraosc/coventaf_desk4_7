﻿
namespace COVENTAF
{
    partial class frmMessageBox
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.btnYes = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtMensaje = new System.Windows.Forms.RichTextBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(156)))), ((int)(((byte)(4)))));
            this.panel1.Controls.Add(this.lblTitle);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(401, 44);
            this.panel1.TabIndex = 1;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.lblTitle.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblTitle.Location = new System.Drawing.Point(12, 13);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(95, 23);
            this.lblTitle.TabIndex = 9;
            this.lblTitle.Text = "Pago Pos";
            // 
            // btnCerrar
            // 
            this.btnCerrar.AutoEllipsis = true;
            this.btnCerrar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCerrar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnCerrar.FlatAppearance.BorderSize = 2;
            this.btnCerrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btnCerrar.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.GrayText;
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.Image = global::COVENTAF.Properties.Resources.Icono_cerrar_FN;
            this.btnCerrar.Location = new System.Drawing.Point(133, 6);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(64, 43);
            this.btnCerrar.TabIndex = 4;
            this.btnCerrar.UseVisualStyleBackColor = true;
            // 
            // btnYes
            // 
            this.btnYes.AutoEllipsis = true;
            this.btnYes.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.btnYes.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnYes.FlatAppearance.BorderSize = 2;
            this.btnYes.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btnYes.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.GrayText;
            this.btnYes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnYes.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnYes.ForeColor = System.Drawing.Color.White;
            this.btnYes.Location = new System.Drawing.Point(216, 6);
            this.btnYes.Name = "btnYes";
            this.btnYes.Size = new System.Drawing.Size(64, 43);
            this.btnYes.TabIndex = 4;
            this.btnYes.Text = "SI";
            this.btnYes.UseVisualStyleBackColor = true;
            this.btnYes.Click += new System.EventHandler(this.btnYes_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(156)))), ((int)(((byte)(4)))));
            this.panel2.Controls.Add(this.btnCerrar);
            this.panel2.Controls.Add(this.btnYes);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 167);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(401, 60);
            this.panel2.TabIndex = 5;
            // 
            // txtMensaje
            // 
            this.txtMensaje.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtMensaje.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMensaje.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMensaje.Font = new System.Drawing.Font("MS Reference Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMensaje.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.txtMensaje.Location = new System.Drawing.Point(0, 44);
            this.txtMensaje.Name = "txtMensaje";
            this.txtMensaje.ReadOnly = true;
            this.txtMensaje.ShowSelectionMargin = true;
            this.txtMensaje.Size = new System.Drawing.Size(401, 123);
            this.txtMensaje.TabIndex = 6;
            this.txtMensaje.Text = "¿Estas seguro de Guardar?";
            // 
            // frmMessageBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.ClientSize = new System.Drawing.Size(401, 227);
            this.Controls.Add(this.txtMensaje);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmMessageBox";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MessageBox";
            this.Load += new System.EventHandler(this.MessageBox_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Button btnYes;
        private System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.RichTextBox txtMensaje;
        public System.Windows.Forms.Label lblTitle;
    }
}