namespace PetFriends
{
    partial class UserAccountControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserAccountControl));
            this.panel1 = new System.Windows.Forms.Panel();
            this.UsuarioPic = new System.Windows.Forms.PictureBox();
            this.btnEliminar = new Guna.UI2.WinForms.Guna2Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.Usuario_Nombre = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.Usuario_Telefono = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.Usuario_Privilegio = new System.Windows.Forms.Label();
            this.Usuario_Email = new System.Windows.Forms.Label();
            this.IngresosLabel = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UsuarioPic)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.UsuarioPic);
            this.panel1.Location = new System.Drawing.Point(24, 20);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(195, 170);
            this.panel1.TabIndex = 1;
            // 
            // UsuarioPic
            // 
            this.UsuarioPic.BackColor = System.Drawing.Color.White;
            this.UsuarioPic.Location = new System.Drawing.Point(8, 4);
            this.UsuarioPic.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.UsuarioPic.Name = "UsuarioPic";
            this.UsuarioPic.Size = new System.Drawing.Size(176, 155);
            this.UsuarioPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.UsuarioPic.TabIndex = 0;
            this.UsuarioPic.TabStop = false;
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.White;
            this.btnEliminar.BorderRadius = 60;
            this.btnEliminar.FillColor = System.Drawing.Color.Transparent;
            this.btnEliminar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnEliminar.ForeColor = System.Drawing.Color.White;
            this.btnEliminar.HoverState.FillColor = System.Drawing.Color.Transparent;
            this.btnEliminar.Image = ((System.Drawing.Image)(resources.GetObject("btnEliminar.Image")));
            this.btnEliminar.ImageSize = new System.Drawing.Size(40, 40);
            this.btnEliminar.Location = new System.Drawing.Point(510, 159);
            this.btnEliminar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(41, 42);
            this.btnEliminar.TabIndex = 115;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.Usuario_Nombre);
            this.panel2.Location = new System.Drawing.Point(227, 26);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(307, 37);
            this.panel2.TabIndex = 116;
            // 
            // Usuario_Nombre
            // 
            this.Usuario_Nombre.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.Usuario_Nombre.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.Usuario_Nombre.Location = new System.Drawing.Point(4, -6);
            this.Usuario_Nombre.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Usuario_Nombre.Name = "Usuario_Nombre";
            this.Usuario_Nombre.Size = new System.Drawing.Size(307, 37);
            this.Usuario_Nombre.TabIndex = 0;
            this.Usuario_Nombre.Text = "Nombre: ";
            this.Usuario_Nombre.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.Usuario_Telefono);
            this.panel3.Location = new System.Drawing.Point(227, 70);
            this.panel3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(307, 37);
            this.panel3.TabIndex = 117;
            // 
            // Usuario_Telefono
            // 
            this.Usuario_Telefono.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Usuario_Telefono.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.Usuario_Telefono.Location = new System.Drawing.Point(4, 0);
            this.Usuario_Telefono.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Usuario_Telefono.Name = "Usuario_Telefono";
            this.Usuario_Telefono.Size = new System.Drawing.Size(307, 37);
            this.Usuario_Telefono.TabIndex = 0;
            this.Usuario_Telefono.Text = "Telefono: None";
            this.Usuario_Telefono.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.Usuario_Privilegio);
            this.panel4.Location = new System.Drawing.Point(231, 114);
            this.panel4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(307, 37);
            this.panel4.TabIndex = 118;
            // 
            // Usuario_Privilegio
            // 
            this.Usuario_Privilegio.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Usuario_Privilegio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.Usuario_Privilegio.Location = new System.Drawing.Point(4, -4);
            this.Usuario_Privilegio.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Usuario_Privilegio.Name = "Usuario_Privilegio";
            this.Usuario_Privilegio.Size = new System.Drawing.Size(307, 37);
            this.Usuario_Privilegio.TabIndex = 0;
            this.Usuario_Privilegio.Text = "Privilegio: None";
            this.Usuario_Privilegio.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Usuario_Email
            // 
            this.Usuario_Email.AutoSize = true;
            this.Usuario_Email.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Usuario_Email.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.Usuario_Email.Location = new System.Drawing.Point(231, 155);
            this.Usuario_Email.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Usuario_Email.MaximumSize = new System.Drawing.Size(307, 0);
            this.Usuario_Email.Name = "Usuario_Email";
            this.Usuario_Email.Size = new System.Drawing.Size(102, 23);
            this.Usuario_Email.TabIndex = 119;
            this.Usuario_Email.Text = "Email: None";
            this.Usuario_Email.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // IngresosLabel
            // 
            this.IngresosLabel.AutoSize = true;
            this.IngresosLabel.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IngresosLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.IngresosLabel.Location = new System.Drawing.Point(231, 190);
            this.IngresosLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.IngresosLabel.MaximumSize = new System.Drawing.Size(307, 0);
            this.IngresosLabel.Name = "IngresosLabel";
            this.IngresosLabel.Size = new System.Drawing.Size(147, 25);
            this.IngresosLabel.TabIndex = 120;
            this.IngresosLabel.Text = "Ingresos: None";
            this.IngresosLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // UserAccountControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.IngresosLabel);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.Usuario_Email);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "UserAccountControl";
            this.Size = new System.Drawing.Size(555, 230);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.UsuarioPic)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox UsuarioPic;
        private Guna.UI2.WinForms.Guna2Button btnEliminar;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label Usuario_Nombre;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label Usuario_Telefono;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label Usuario_Privilegio;
        private System.Windows.Forms.Label Usuario_Email;
        public System.Windows.Forms.Label IngresosLabel;
    }
}
