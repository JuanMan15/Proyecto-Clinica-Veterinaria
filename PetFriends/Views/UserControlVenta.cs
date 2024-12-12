using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System;
using System.Drawing;
using System.Windows.Forms;
using PetFriends.Models;

namespace PetFriends
{
    public partial class UserControlVenta : UserControl
    {
        public UserControlVenta()
        {
            InitializeComponent();
            this.Resize += UserControlVenta_Resize;
        }

        public void SetVentaData(Venta venta)
        {
            labelVentaId.Text = $"Venta #: {venta.IdVenta}";
            labelFecha.Text = $"Fecha: {venta.Fecha.ToString("dd/MM/yyyy")}";
            labelTotal.Text = $"Total: {venta.Total:C2}";
            labelEmpleado.Text = $"Empleado: {venta.NombreEmpleado}";

            flowLayoutPanelProductos.Controls.Clear();

            foreach (var producto in venta.Productos)
            {
                AddProductPanel(producto);
            }
        }

        private void AddProductPanel(ProductoVenta productoVenta)
        {
            // Crear un Producto a partir de ProductoVenta
            Producto producto = new Producto
            {
                Nombre = productoVenta.NombreProducto,
                Cantidad = productoVenta.Quantity,
                Precio = productoVenta.Precio
            };

            // Ahora llama a AddProductPanel con el objeto Producto
            Panel productPanel = new Panel
            {
                Width = flowLayoutPanelProductos.ClientSize.Width - 40, 
                Height = 60,
                Margin = new Padding(0, 0, 0, 10),
                BackColor = Color.White
            };

            Label nameLabel = new Label
            {
                Text = producto.Nombre,
                AutoSize = true,
                Location = new Point(10, 5),
                Font = new Font("Segoe UI", 11F, FontStyle.Bold)
            };

            Label quantityLabel = new Label
            {
                Text = $"Cantidad: {producto.Cantidad}",
                AutoSize = true,
                Location = new Point(10, 30),
                Font = new Font("Segoe UI", 9F, FontStyle.Regular)
            };

            Label priceLabel = new Label
            {
                Text = $"Precio: {producto.Precio:C2}",
                AutoSize = true,
                Location = new Point(productPanel.Width - 120, 15),
                Font = new Font("Segoe UI", 10F, FontStyle.Regular)
            };

            productPanel.Controls.Add(nameLabel);
            productPanel.Controls.Add(quantityLabel);
            productPanel.Controls.Add(priceLabel);

            flowLayoutPanelProductos.Controls.Add(productPanel);
        }

        private void UserControlVenta_Resize(object sender, EventArgs e)
        {
            int rightMargin = 20;
            labelTotal.Left = this.Width - labelTotal.Width - rightMargin;
            labelEmpleado.Left = this.Width - labelEmpleado.Width - rightMargin;

            foreach (Control control in flowLayoutPanelProductos.Controls)
            {
                if (control is Panel productPanel)
                {
                    productPanel.Width = flowLayoutPanelProductos.ClientSize.Width - 40;
                    Label priceLabel = productPanel.Controls.OfType<Label>().FirstOrDefault(l => l.Text.StartsWith("Precio:"));
                    if (priceLabel != null)
                    {
                        priceLabel.Left = productPanel.Width - 120;
                    }
                }
            }

            panelHeader.Invalidate();
        }
    }
}

