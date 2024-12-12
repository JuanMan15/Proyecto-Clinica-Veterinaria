namespace PetFriends
{
    partial class PetUserControl
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PetUserControl));
            this.panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.PetPic = new System.Windows.Forms.PictureBox();
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.guna2Elipse2 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.Pet_C = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.Pet_T = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.Pet_D = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.Pet_L = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.Post_P = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.Post_C = new System.Windows.Forms.Label();
            this.MoreInfoBtn = new System.Windows.Forms.PictureBox();
            this.btnEliminar = new Guna.UI2.WinForms.Guna2Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PetPic)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.panel6.SuspendLayout();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MoreInfoBtn)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderRadius = 10;
            this.panel1.Controls.Add(this.PetPic);
            this.panel1.Location = new System.Drawing.Point(15, 10);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(130, 182);
            this.panel1.TabIndex = 0;
            // 
            // PetPic
            // 
            this.PetPic.BackColor = System.Drawing.Color.White;
            this.PetPic.Location = new System.Drawing.Point(0, 9);
            this.PetPic.Name = "PetPic";
            this.PetPic.Size = new System.Drawing.Size(127, 170);
            this.PetPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PetPic.TabIndex = 0;
            this.PetPic.TabStop = false;
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.BorderRadius = 10;
            this.guna2Elipse1.TargetControl = this;
            // 
            // guna2Elipse2
            // 
            this.guna2Elipse2.BorderRadius = 10;
            this.guna2Elipse2.TargetControl = this.panel1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.Pet_C);
            this.panel2.Location = new System.Drawing.Point(151, 10);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(230, 30);
            this.panel2.TabIndex = 105;
            // 
            // Pet_C
            // 
            this.Pet_C.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Pet_C.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.Pet_C.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.Pet_C.Location = new System.Drawing.Point(0, 0);
            this.Pet_C.Name = "Pet_C";
            this.Pet_C.Size = new System.Drawing.Size(230, 30);
            this.Pet_C.TabIndex = 0;
            this.Pet_C.Text = "Nombre: None";
            this.Pet_C.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.Pet_T);
            this.panel3.Location = new System.Drawing.Point(151, 40);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(230, 30);
            this.panel3.TabIndex = 106;
            // 
            // Pet_T
            // 
            this.Pet_T.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Pet_T.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Pet_T.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.Pet_T.Location = new System.Drawing.Point(0, 0);
            this.Pet_T.Name = "Pet_T";
            this.Pet_T.Size = new System.Drawing.Size(230, 30);
            this.Pet_T.TabIndex = 0;
            this.Pet_T.Text = "Especie: None";
            this.Pet_T.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.Pet_D);
            this.panel4.Location = new System.Drawing.Point(151, 70);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(230, 30);
            this.panel4.TabIndex = 107;
            // 
            // Pet_D
            // 
            this.Pet_D.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Pet_D.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.Pet_D.Location = new System.Drawing.Point(0, 3);
            this.Pet_D.Name = "Pet_D";
            this.Pet_D.Size = new System.Drawing.Size(230, 30);
            this.Pet_D.TabIndex = 0;
            this.Pet_D.Text = "Descripcion: None";
            this.Pet_D.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(156, 100);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(16, 16);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 108;
            this.pictureBox2.TabStop = false;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.Pet_L);
            this.panel5.Location = new System.Drawing.Point(151, 100);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(230, 30);
            this.panel5.TabIndex = 108;
            // 
            // Pet_L
            // 
            this.Pet_L.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Pet_L.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Pet_L.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.Pet_L.Location = new System.Drawing.Point(0, 0);
            this.Pet_L.Name = "Pet_L";
            this.Pet_L.Size = new System.Drawing.Size(230, 30);
            this.Pet_L.TabIndex = 0;
            this.Pet_L.Text = "Edad: None";
            this.Pet_L.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(156, 130);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(16, 16);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 109;
            this.pictureBox3.TabStop = false;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.Post_P);
            this.panel6.Location = new System.Drawing.Point(151, 130);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(230, 30);
            this.panel6.TabIndex = 110;
            // 
            // Post_P
            // 
            this.Post_P.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Post_P.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Post_P.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.Post_P.Location = new System.Drawing.Point(0, 0);
            this.Post_P.Name = "Post_P";
            this.Post_P.Size = new System.Drawing.Size(230, 30);
            this.Post_P.TabIndex = 0;
            this.Post_P.Text = "Peso: None";
            this.Post_P.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel7
            // 
            this.panel7.AutoSize = true;
            this.panel7.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel7.Controls.Add(this.Post_C);
            this.panel7.Location = new System.Drawing.Point(151, 160);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(91, 19);
            this.panel7.TabIndex = 112;
            // 
            // Post_C
            // 
            this.Post_C.AutoSize = true;
            this.Post_C.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Post_C.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.Post_C.Location = new System.Drawing.Point(3, 0);
            this.Post_C.MaximumSize = new System.Drawing.Size(230, 0);
            this.Post_C.Name = "Post_C";
            this.Post_C.Size = new System.Drawing.Size(85, 19);
            this.Post_C.TabIndex = 0;
            this.Post_C.Text = "Notas: None";
            this.Post_C.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // MoreInfoBtn
            // 
            this.MoreInfoBtn.Image = ((System.Drawing.Image)(resources.GetObject("MoreInfoBtn.Image")));
            this.MoreInfoBtn.Location = new System.Drawing.Point(375, 9);
            this.MoreInfoBtn.Name = "MoreInfoBtn";
            this.MoreInfoBtn.Size = new System.Drawing.Size(52, 31);
            this.MoreInfoBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.MoreInfoBtn.TabIndex = 113;
            this.MoreInfoBtn.TabStop = false;
            this.MoreInfoBtn.Click += new System.EventHandler(this.MoreInfoBtn_Click);
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
            this.btnEliminar.Location = new System.Drawing.Point(375, 49);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(52, 51);
            this.btnEliminar.TabIndex = 114;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // PetUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.MoreInfoBtn);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.MinimumSize = new System.Drawing.Size(439, 244);
            this.Name = "PetUserControl";
            this.Size = new System.Drawing.Size(439, 244);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PetPic)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.panel6.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MoreInfoBtn)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel panel1;
        private System.Windows.Forms.PictureBox PetPic;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label Pet_C;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label Pet_D;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label Pet_T;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label Pet_L;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label Post_C;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label Post_P;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox MoreInfoBtn;
        private Guna.UI2.WinForms.Guna2Button btnEliminar;
    }
}
