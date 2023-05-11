namespace capaPresentacion
{
    partial class frmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblAcceso = new System.Windows.Forms.Label();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.lblContrasena = new System.Windows.Forms.Label();
            this.pnlUser = new System.Windows.Forms.Panel();
            this.iconPictureUsuario = new FontAwesome.Sharp.IconPictureBox();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.iconPictureCandado = new FontAwesome.Sharp.IconPictureBox();
            this.txtContrasena = new System.Windows.Forms.TextBox();
            this.pnlLinea = new System.Windows.Forms.Panel();
            this.pnlLinea2 = new System.Windows.Forms.Panel();
            this.btnClose = new FontAwesome.Sharp.IconPictureBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnlUser.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureUsuario)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureCandado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(46)))), ((int)(((byte)(56)))));
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(262, 322);
            this.panel1.TabIndex = 2;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(29, 68);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(196, 162);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 34;
            this.pictureBox1.TabStop = false;
            // 
            // lblAcceso
            // 
            this.lblAcceso.AutoSize = true;
            this.lblAcceso.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAcceso.ForeColor = System.Drawing.Color.White;
            this.lblAcceso.Location = new System.Drawing.Point(346, 54);
            this.lblAcceso.Name = "lblAcceso";
            this.lblAcceso.Size = new System.Drawing.Size(164, 25);
            this.lblAcceso.TabIndex = 25;
            this.lblAcceso.Text = "Acceso al Sistema";
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuario.ForeColor = System.Drawing.Color.White;
            this.lblUsuario.Location = new System.Drawing.Point(291, 101);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(59, 20);
            this.lblUsuario.TabIndex = 27;
            this.lblUsuario.Text = "Usuario";
            // 
            // lblContrasena
            // 
            this.lblContrasena.AutoSize = true;
            this.lblContrasena.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContrasena.ForeColor = System.Drawing.Color.White;
            this.lblContrasena.Location = new System.Drawing.Point(291, 159);
            this.lblContrasena.Name = "lblContrasena";
            this.lblContrasena.Size = new System.Drawing.Size(83, 20);
            this.lblContrasena.TabIndex = 29;
            this.lblContrasena.Text = "Contraseña";
            // 
            // pnlUser
            // 
            this.pnlUser.BackColor = System.Drawing.Color.White;
            this.pnlUser.Controls.Add(this.iconPictureUsuario);
            this.pnlUser.Controls.Add(this.txtUsuario);
            this.pnlUser.Location = new System.Drawing.Point(295, 124);
            this.pnlUser.Name = "pnlUser";
            this.pnlUser.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.pnlUser.Size = new System.Drawing.Size(240, 26);
            this.pnlUser.TabIndex = 11;
            // 
            // iconPictureUsuario
            // 
            this.iconPictureUsuario.BackColor = System.Drawing.Color.White;
            this.iconPictureUsuario.Cursor = System.Windows.Forms.Cursors.Hand;
            this.iconPictureUsuario.Dock = System.Windows.Forms.DockStyle.Left;
            this.iconPictureUsuario.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.iconPictureUsuario.IconChar = FontAwesome.Sharp.IconChar.UserSecret;
            this.iconPictureUsuario.IconColor = System.Drawing.SystemColors.ControlDarkDark;
            this.iconPictureUsuario.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureUsuario.IconSize = 24;
            this.iconPictureUsuario.Location = new System.Drawing.Point(0, 2);
            this.iconPictureUsuario.Name = "iconPictureUsuario";
            this.iconPictureUsuario.Size = new System.Drawing.Size(26, 24);
            this.iconPictureUsuario.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.iconPictureUsuario.TabIndex = 34;
            this.iconPictureUsuario.TabStop = false;
            // 
            // txtUsuario
            // 
            this.txtUsuario.BackColor = System.Drawing.Color.White;
            this.txtUsuario.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUsuario.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuario.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtUsuario.Location = new System.Drawing.Point(32, 3);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(205, 20);
            this.txtUsuario.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.iconPictureCandado);
            this.panel2.Controls.Add(this.txtContrasena);
            this.panel2.Location = new System.Drawing.Point(295, 182);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.panel2.Size = new System.Drawing.Size(240, 26);
            this.panel2.TabIndex = 14;
            // 
            // iconPictureCandado
            // 
            this.iconPictureCandado.BackColor = System.Drawing.Color.White;
            this.iconPictureCandado.Cursor = System.Windows.Forms.Cursors.Hand;
            this.iconPictureCandado.Dock = System.Windows.Forms.DockStyle.Left;
            this.iconPictureCandado.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.iconPictureCandado.IconChar = FontAwesome.Sharp.IconChar.Unlock;
            this.iconPictureCandado.IconColor = System.Drawing.SystemColors.ControlDarkDark;
            this.iconPictureCandado.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureCandado.IconSize = 24;
            this.iconPictureCandado.Location = new System.Drawing.Point(0, 2);
            this.iconPictureCandado.Name = "iconPictureCandado";
            this.iconPictureCandado.Size = new System.Drawing.Size(26, 24);
            this.iconPictureCandado.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.iconPictureCandado.TabIndex = 35;
            this.iconPictureCandado.TabStop = false;
            // 
            // txtContrasena
            // 
            this.txtContrasena.BackColor = System.Drawing.Color.White;
            this.txtContrasena.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtContrasena.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContrasena.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtContrasena.Location = new System.Drawing.Point(32, 3);
            this.txtContrasena.Name = "txtContrasena";
            this.txtContrasena.Size = new System.Drawing.Size(205, 20);
            this.txtContrasena.TabIndex = 2;
             // 
            // pnlLinea
            // 
            this.pnlLinea.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(133)))), ((int)(((byte)(3)))));
            this.pnlLinea.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlLinea.Location = new System.Drawing.Point(0, 327);
            this.pnlLinea.Name = "pnlLinea";
            this.pnlLinea.Size = new System.Drawing.Size(577, 5);
            this.pnlLinea.TabIndex = 31;
            // 
            // pnlLinea2
            // 
            this.pnlLinea2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(133)))), ((int)(((byte)(3)))));
            this.pnlLinea2.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlLinea2.Location = new System.Drawing.Point(0, 0);
            this.pnlLinea2.Name = "pnlLinea2";
            this.pnlLinea2.Size = new System.Drawing.Size(577, 5);
            this.pnlLinea2.TabIndex = 32;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(58)))), ((int)(((byte)(71)))));
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.IconChar = FontAwesome.Sharp.IconChar.Xmark;
            this.btnClose.IconColor = System.Drawing.Color.White;
            this.btnClose.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnClose.IconSize = 31;
            this.btnClose.Location = new System.Drawing.Point(543, 11);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(34, 31);
            this.btnClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnClose.TabIndex = 33;
            this.btnClose.TabStop = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(133)))), ((int)(((byte)(3)))));
            this.btnLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogin.FlatAppearance.BorderSize = 0;
            this.btnLogin.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(133)))), ((int)(((byte)(3)))));
            this.btnLogin.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(100)))), ((int)(((byte)(2)))));
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.Location = new System.Drawing.Point(295, 229);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(103, 32);
            this.btnLogin.TabIndex = 34;
            this.btnLogin.Text = "Inicia sesión";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(58)))), ((int)(((byte)(71)))));
            this.ClientSize = new System.Drawing.Size(577, 332);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pnlUser);
            this.Controls.Add(this.lblContrasena);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.lblAcceso);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlLinea);
            this.Controls.Add(this.pnlLinea2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmLogin_MouseDown);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnlUser.ResumeLayout(false);
            this.pnlUser.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureUsuario)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureCandado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblAcceso;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Label lblContrasena;
        private System.Windows.Forms.Panel pnlUser;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtContrasena;
        private System.Windows.Forms.Panel pnlLinea;
        private System.Windows.Forms.Panel pnlLinea2;
        private FontAwesome.Sharp.IconPictureBox btnClose;
        private FontAwesome.Sharp.IconPictureBox iconPictureUsuario;
        private FontAwesome.Sharp.IconPictureBox iconPictureCandado;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnLogin;
    }
}