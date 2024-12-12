namespace PetFriends
{
    partial class UserControlVenta
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
            this.panelHeader = new System.Windows.Forms.Panel();
            this.labelVentaId = new System.Windows.Forms.Label();
            this.labelFecha = new System.Windows.Forms.Label();
            this.labelTotal = new System.Windows.Forms.Label();
            this.labelEmpleado = new System.Windows.Forms.Label();
            this.flowLayoutPanelProductos = new System.Windows.Forms.FlowLayoutPanel();
            this.panelHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            this.panelHeader.Controls.Add(this.labelVentaId);
            this.panelHeader.Controls.Add(this.labelFecha);
            this.panelHeader.Controls.Add(this.labelTotal);
            this.panelHeader.Controls.Add(this.labelEmpleado);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(781, 100);
            this.panelHeader.TabIndex = 0;
            // 
            // labelVentaId
            // 
            this.labelVentaId.AutoSize = true;
            this.labelVentaId.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.labelVentaId.ForeColor = System.Drawing.Color.White;
            this.labelVentaId.Location = new System.Drawing.Point(20, 20);
            this.labelVentaId.Name = "labelVentaId";
            this.labelVentaId.Size = new System.Drawing.Size(106, 32);
            this.labelVentaId.TabIndex = 0;
            this.labelVentaId.Text = "Venta #:";
            // 
            // labelFecha
            // 
            this.labelFecha.AutoSize = true;
            this.labelFecha.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.labelFecha.ForeColor = System.Drawing.Color.White;
            this.labelFecha.Location = new System.Drawing.Point(22, 60);
            this.labelFecha.Name = "labelFecha";
            this.labelFecha.Size = new System.Drawing.Size(53, 21);
            this.labelFecha.TabIndex = 1;
            this.labelFecha.Text = "Fecha:";
            // 
            // labelTotal
            // 
            this.labelTotal.AutoSize = true;
            this.labelTotal.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.labelTotal.ForeColor = System.Drawing.Color.White;
            this.labelTotal.Location = new System.Drawing.Point(516, 20);
            this.labelTotal.Name = "labelTotal";
            this.labelTotal.Size = new System.Drawing.Size(60, 25);
            this.labelTotal.TabIndex = 2;
            this.labelTotal.Text = "Total:";
            // 
            // labelEmpleado
            // 
            this.labelEmpleado.AutoSize = true;
            this.labelEmpleado.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.labelEmpleado.ForeColor = System.Drawing.Color.White;
            this.labelEmpleado.Location = new System.Drawing.Point(517, 60);
            this.labelEmpleado.Name = "labelEmpleado";
            this.labelEmpleado.Size = new System.Drawing.Size(82, 21);
            this.labelEmpleado.TabIndex = 3;
            this.labelEmpleado.Text = "Empleado:";
            // 
            // flowLayoutPanelProductos
            // 
            this.flowLayoutPanelProductos.AutoScroll = true;
            this.flowLayoutPanelProductos.BackColor = System.Drawing.Color.White;
            this.flowLayoutPanelProductos.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanelProductos.Location = new System.Drawing.Point(0, 100);
            this.flowLayoutPanelProductos.Name = "flowLayoutPanelProductos";
            this.flowLayoutPanelProductos.Padding = new System.Windows.Forms.Padding(20);
            this.flowLayoutPanelProductos.Size = new System.Drawing.Size(781, 244);
            this.flowLayoutPanelProductos.TabIndex = 1;
            this.flowLayoutPanelProductos.WrapContents = false;
            // 
            // UserControlVenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(247)))));
            this.Controls.Add(this.flowLayoutPanelProductos);
            this.Controls.Add(this.panelHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "UserControlVenta";
            this.Size = new System.Drawing.Size(781, 346);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label labelVentaId;
        private System.Windows.Forms.Label labelFecha;
        private System.Windows.Forms.Label labelTotal;
        private System.Windows.Forms.Label labelEmpleado;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelProductos;
    }
}

