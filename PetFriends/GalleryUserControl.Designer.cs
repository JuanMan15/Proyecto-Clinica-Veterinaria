
namespace PetFriends
{
    partial class GalleryUserControl
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
            this.components = new System.ComponentModel.Container();
            this.GallPic1 = new System.Windows.Forms.PictureBox();
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.GallPic2 = new System.Windows.Forms.PictureBox();
            this.GallPic3 = new System.Windows.Forms.PictureBox();
            this.GallPic4 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.GallPic1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GallPic2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GallPic3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GallPic4)).BeginInit();
            this.SuspendLayout();
            // 
            // GallPic1
            // 
            this.GallPic1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.GallPic1.Location = new System.Drawing.Point(4, 3);
            this.GallPic1.Name = "GallPic1";
            this.GallPic1.Size = new System.Drawing.Size(191, 183);
            this.GallPic1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.GallPic1.TabIndex = 1;
            this.GallPic1.TabStop = false;
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.BorderRadius = 18;
            this.guna2Elipse1.TargetControl = this;
            // 
            // GallPic2
            // 
            this.GallPic2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.GallPic2.Location = new System.Drawing.Point(197, 3);
            this.GallPic2.Name = "GallPic2";
            this.GallPic2.Size = new System.Drawing.Size(191, 183);
            this.GallPic2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.GallPic2.TabIndex = 2;
            this.GallPic2.TabStop = false;
            // 
            // GallPic3
            // 
            this.GallPic3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.GallPic3.Location = new System.Drawing.Point(390, 3);
            this.GallPic3.Name = "GallPic3";
            this.GallPic3.Size = new System.Drawing.Size(191, 183);
            this.GallPic3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.GallPic3.TabIndex = 3;
            this.GallPic3.TabStop = false;
            // 
            // GallPic4
            // 
            this.GallPic4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.GallPic4.Location = new System.Drawing.Point(583, 3);
            this.GallPic4.Name = "GallPic4";
            this.GallPic4.Size = new System.Drawing.Size(191, 183);
            this.GallPic4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.GallPic4.TabIndex = 4;
            this.GallPic4.TabStop = false;
            // 
            // GalleryUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.Controls.Add(this.GallPic4);
            this.Controls.Add(this.GallPic3);
            this.Controls.Add(this.GallPic2);
            this.Controls.Add(this.GallPic1);
            this.Name = "GalleryUserControl";
            this.Size = new System.Drawing.Size(779, 192);
            this.Load += new System.EventHandler(this.GalleryUserControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GallPic1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GallPic2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GallPic3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GallPic4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.PictureBox GallPic1;
        public Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        public System.Windows.Forms.PictureBox GallPic4;
        public System.Windows.Forms.PictureBox GallPic3;
        public System.Windows.Forms.PictureBox GallPic2;
    }
}
