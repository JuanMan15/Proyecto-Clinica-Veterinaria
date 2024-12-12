using PetFriends.ExtraConfig;
using PetFriends.Models;
using PetFriends.Repository;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PetFriends.Controllers
{
    internal class VentaController
    {
        private readonly UserDash _userDash;
        private readonly VentasRepository _ventasRepository;
        private readonly Usuario usuarioLoggedIn;
      

        public event EventHandler<VentaEventArgs> VentaConcretada;

        public List<Venta> ObtenerVentas()
        {
            return _ventasRepository.ObtenerVentasConProductosYPrecios();
        }


        public VentaController(UserDash userDash, Usuario usuario)
        {
            _ventasRepository = new VentasRepository();
            usuarioLoggedIn = usuario;
         
            _userDash = userDash;


            foreach (Control control in _userDash.flowLayoutPanel1.Controls)
            {
                if (control is ProductUserControl productControl)
                {
                    productControl.QuantityChanged += ProductControl_QuantityChanged;
                }
            }
        }

        private void ProductControl_QuantityChanged(object sender, EventArgs e)
        {
            decimal total = 0;

            foreach (Control control in _userDash.flowLayoutPanel1.Controls)
            {
                if (control is ProductUserControl productControl)
                {
                    if (productControl.IsSelected && productControl.SelectedQuantity > 0)
                    {
                        total += productControl.ProductTotal;
                    }
                }
            }

            // Actualiza la etiqueta de total en el dashboard
            _userDash.totalLabel.Text = $"Total: ${total:F2}MXN";
        }

        public void ConcretarVenta()
        {
            var productosSeleccionados = new List<ProductoVenta>();

            foreach (Control control in _userDash.flowLayoutPanel1.Controls)
            {
                if (control is ProductUserControl productControl)
                {
                    var producto = productControl.GetSelectedProduct();

                    if (producto.productId > 0 && producto.quantity > 0)
                    {
                        productosSeleccionados.Add(new ProductoVenta
                        {
                            ProductId = producto.productId,
                            Quantity = producto.quantity,
                            NombreProducto = producto.nombreProducto
                        });
                    }
                }
            }

            if (productosSeleccionados.Count == 0)
            {
                MessageBox.Show("No hay productos seleccionados para la venta.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var result = MessageBox.Show("¿Está seguro de que desea concretar la venta?", "Confirmar Venta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    var nuevaVenta = _ventasRepository.RegistrarVenta(usuarioLoggedIn.Id, productosSeleccionados);

                    OnVentaConcretada(nuevaVenta.IdVenta, nuevaVenta.Total);

                    foreach (var productoVenta in productosSeleccionados)
                    {
                        foreach (Control control in _userDash.flowLayoutPanel1.Controls)
                        {
                            if (control is ProductUserControl productControl && productControl.ProductId == productoVenta.ProductId)
                            {
                                productControl.ProductQuantity -= productoVenta.Quantity;

                              
                            }
                        }
                    }

                    ReiniciarSelecciones();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al registrar la venta: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        protected virtual void OnVentaConcretada(int ventaId, decimal total)
        {
            VentaConcretada?.Invoke(this, new VentaEventArgs { VentaId = ventaId, Total = total });
        }

        // Método para reiniciar las selecciones de productos
        public void ReiniciarSelecciones()
        {
            foreach (Control control in _userDash.flowLayoutPanel1.Controls)
            {
                if (control is ProductUserControl productControl)
                {
                    productControl.checkBoxArticulo.Checked = false;
                    productControl.numericUpArticulo.Value = 0;
                }
            }
        }

    }
}
