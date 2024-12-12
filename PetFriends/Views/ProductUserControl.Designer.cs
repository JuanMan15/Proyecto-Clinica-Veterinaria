namespace PetFriends
{
    partial class ProductUserControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductUserControl));
            this.panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.ProductPic = new System.Windows.Forms.PictureBox();
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.guna2Elipse2 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.Product_C = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.Product_T = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.Product_D = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.Product_Price = new System.Windows.Forms.Label();
            this.guna2NumericUpDown1 = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.panel6 = new System.Windows.Forms.Panel();
            this.cantidadTextBox = new Guna.UI2.WinForms.Guna2TextBox();
            this.Product_Quantity = new System.Windows.Forms.Label();
            this.btnEliminar = new Guna.UI2.WinForms.Guna2Button();
            this.checkBoxArticulo = new Guna.UI2.WinForms.Guna2CustomCheckBox();
            this.numericUpArticulo = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.totalRecaudado = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ProductPic)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2NumericUpDown1)).BeginInit();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpArticulo)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderRadius = 10;
            this.panel1.Controls.Add(this.ProductPic);
            this.panel1.Location = new System.Drawing.Point(15, 30);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(130, 130);
            this.panel1.TabIndex = 0;
            // 
            // ProductPic
            // 
            this.ProductPic.BackColor = System.Drawing.Color.White;
            this.ProductPic.Location = new System.Drawing.Point(5, 5);
            this.ProductPic.Name = "ProductPic";
            this.ProductPic.Size = new System.Drawing.Size(120, 120);
            this.ProductPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ProductPic.TabIndex = 0;
            this.ProductPic.TabStop = false;
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
            this.panel2.Controls.Add(this.Product_C);
            this.panel2.Location = new System.Drawing.Point(151, 10);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(230, 30);
            this.panel2.TabIndex = 105;
            // 
            // Product_C
            // 
            this.Product_C.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Product_C.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.Product_C.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.Product_C.Location = new System.Drawing.Point(0, 0);
            this.Product_C.Name = "Product_C";
            this.Product_C.Size = new System.Drawing.Size(230, 30);
            this.Product_C.TabIndex = 0;
            this.Product_C.Text = "Category: None";
            this.Product_C.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.Product_T);
            this.panel3.Location = new System.Drawing.Point(151, 40);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(230, 30);
            this.panel3.TabIndex = 106;
            // 
            // Product_T
            // 
            this.Product_T.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Product_T.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Product_T.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.Product_T.Location = new System.Drawing.Point(0, 0);
            this.Product_T.Name = "Product_T";
            this.Product_T.Size = new System.Drawing.Size(230, 30);
            this.Product_T.TabIndex = 0;
            this.Product_T.Text = "Tipo: None";
            this.Product_T.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel4
            // 
            this.panel4.AutoSize = true;
            this.panel4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel4.Controls.Add(this.Product_D);
            this.panel4.Location = new System.Drawing.Point(151, 136);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(125, 19);
            this.panel4.TabIndex = 107;
            // 
            // Product_D
            // 
            this.Product_D.AutoSize = true;
            this.Product_D.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Product_D.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.Product_D.Location = new System.Drawing.Point(3, 0);
            this.Product_D.MaximumSize = new System.Drawing.Size(230, 0);
            this.Product_D.Name = "Product_D";
            this.Product_D.Size = new System.Drawing.Size(119, 19);
            this.Product_D.TabIndex = 0;
            this.Product_D.Text = "Descripcion: None";
            this.Product_D.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.Product_Price);
            this.panel5.Controls.Add(this.guna2NumericUpDown1);
            this.panel5.Location = new System.Drawing.Point(151, 100);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(230, 30);
            this.panel5.TabIndex = 108;
            // 
            // Product_Price
            // 
            this.Product_Price.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Product_Price.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Product_Price.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.Product_Price.Location = new System.Drawing.Point(0, 0);
            this.Product_Price.Name = "Product_Price";
            this.Product_Price.Size = new System.Drawing.Size(230, 30);
            this.Product_Price.TabIndex = 0;
            this.Product_Price.Text = "Precio: None";
            this.Product_Price.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // guna2NumericUpDown1
            // 
            this.guna2NumericUpDown1.BackColor = System.Drawing.Color.Transparent;
            this.guna2NumericUpDown1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.guna2NumericUpDown1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2NumericUpDown1.Location = new System.Drawing.Point(194, -9);
            this.guna2NumericUpDown1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.guna2NumericUpDown1.Name = "guna2NumericUpDown1";
            this.guna2NumericUpDown1.Size = new System.Drawing.Size(100, 36);
            this.guna2NumericUpDown1.TabIndex = 116;
            // 
            // panel6
            // 
            this.panel6.AutoSize = true;
            this.panel6.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel6.Controls.Add(this.cantidadTextBox);
            this.panel6.Controls.Add(this.Product_Quantity);
            this.panel6.Location = new System.Drawing.Point(155, 75);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(193, 28);
            this.panel6.TabIndex = 109;
            // 
            // cantidadTextBox
            // 
            this.cantidadTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.cantidadTextBox.DefaultText = "Quantity: None";
            this.cantidadTextBox.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.cantidadTextBox.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.cantidadTextBox.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.cantidadTextBox.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.cantidadTextBox.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cantidadTextBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cantidadTextBox.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cantidadTextBox.Location = new System.Drawing.Point(63, 0);
            this.cantidadTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cantidadTextBox.Name = "cantidadTextBox";
            this.cantidadTextBox.PasswordChar = '\0';
            this.cantidadTextBox.PlaceholderText = "";
            this.cantidadTextBox.SelectedText = "";
            this.cantidadTextBox.Size = new System.Drawing.Size(127, 24);
            this.cantidadTextBox.TabIndex = 117;
            // 
            // Product_Quantity
            // 
            this.Product_Quantity.AutoSize = true;
            this.Product_Quantity.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Product_Quantity.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.Product_Quantity.Location = new System.Drawing.Point(-4, -2);
            this.Product_Quantity.MaximumSize = new System.Drawing.Size(230, 0);
            this.Product_Quantity.Name = "Product_Quantity";
            this.Product_Quantity.Size = new System.Drawing.Size(104, 19);
            this.Product_Quantity.TabIndex = 0;
            this.Product_Quantity.Text = "Cantidad: None";
            this.Product_Quantity.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.btnEliminar.Location = new System.Drawing.Point(387, 100);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(43, 43);
            this.btnEliminar.TabIndex = 114;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // checkBoxArticulo
            // 
            this.checkBoxArticulo.BackColor = System.Drawing.Color.White;
            this.checkBoxArticulo.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.checkBoxArticulo.CheckedState.BorderRadius = 2;
            this.checkBoxArticulo.CheckedState.BorderThickness = 0;
            this.checkBoxArticulo.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.checkBoxArticulo.Location = new System.Drawing.Point(405, 10);
            this.checkBoxArticulo.Name = "checkBoxArticulo";
            this.checkBoxArticulo.Size = new System.Drawing.Size(22, 30);
            this.checkBoxArticulo.TabIndex = 115;
            this.checkBoxArticulo.Text = "guna2CustomCheckBox1";
            this.checkBoxArticulo.UncheckedState.BorderColor = System.Drawing.Color.Black;
            this.checkBoxArticulo.UncheckedState.BorderRadius = 2;
            this.checkBoxArticulo.UncheckedState.BorderThickness = 2;
            this.checkBoxArticulo.UncheckedState.FillColor = System.Drawing.Color.White;
            // 
            // numericUpArticulo
            // 
            this.numericUpArticulo.BackColor = System.Drawing.Color.Transparent;
            this.numericUpArticulo.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.numericUpArticulo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.numericUpArticulo.Location = new System.Drawing.Point(360, 58);
            this.numericUpArticulo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.numericUpArticulo.Maximum = new decimal(new int[] {
            1500,
            0,
            0,
            0});
            this.numericUpArticulo.Name = "numericUpArticulo";
            this.numericUpArticulo.Size = new System.Drawing.Size(67, 27);
            this.numericUpArticulo.TabIndex = 116;
            this.numericUpArticulo.UpDownButtonFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            // 
            // totalRecaudado
            // 
            this.totalRecaudado.AutoSize = true;
            this.totalRecaudado.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.totalRecaudado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.totalRecaudado.Location = new System.Drawing.Point(38, 210);
            this.totalRecaudado.MaximumSize = new System.Drawing.Size(230, 0);
            this.totalRecaudado.Name = "totalRecaudado";
            this.totalRecaudado.Size = new System.Drawing.Size(192, 20);
            this.totalRecaudado.TabIndex = 117;
            this.totalRecaudado.Text = "Recaudado producto: None";
            this.totalRecaudado.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ProductUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.totalRecaudado);
            this.Controls.Add(this.numericUpArticulo);
            this.Controls.Add(this.checkBoxArticulo);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.MinimumSize = new System.Drawing.Size(439, 250);
            this.Name = "ProductUserControl";
            this.Size = new System.Drawing.Size(439, 250);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ProductPic)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.guna2NumericUpDown1)).EndInit();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpArticulo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel panel1;
        private System.Windows.Forms.PictureBox ProductPic;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label Product_C;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label Product_T;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label Product_D;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label Product_Price;
        private System.Windows.Forms.Panel panel6;
        public Guna.UI2.WinForms.Guna2Button btnEliminar;
        public Guna.UI2.WinForms.Guna2CustomCheckBox checkBoxArticulo;
        public Guna.UI2.WinForms.Guna2NumericUpDown numericUpArticulo;
        public Guna.UI2.WinForms.Guna2NumericUpDown guna2NumericUpDown1;
        public Guna.UI2.WinForms.Guna2TextBox cantidadTextBox;
        public System.Windows.Forms.Label Product_Quantity;
        public System.Windows.Forms.Label totalRecaudado;
    }
}
