using PetFriends.Controller;
using PetFriends.Models;
using PetFriends.Repository;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PetFriends.Controllers
{
    public class ProductController
    {
        private readonly ProductRepository _productRepository;
        private readonly UserDash _userDash;
        private readonly Usuario _usuarioLoggedIn;
        private readonly ProductUserControl _userControl;

        public ProductController(UserDash userDash, Usuario usuario)
        {
            _productRepository = new ProductRepository();
            _userDash = userDash;
            _usuarioLoggedIn = usuario;
    

            _userDash.JuguetesSearchBox.Click += new System.EventHandler(this.JuguetesSearchBox_Click);
            _userDash.SaludAlimentoSearchBox.Click += new System.EventHandler(this.SaludAlimentoSearchBox_Click);
            _userDash.SearchAll1.Click += new System.EventHandler(this.SearchAll1_Click);
            _userDash.SearchHigiene.Click += new System.EventHandler(this.SearchHigiene_Click);
            _userDash.searchBoxProduct.TextChanged += new System.EventHandler(this.searchBoxProduct_TextChanged);
        }

        public bool ActualizarCantidadProducto(int idProducto, int nuevaCantidad)
        {
            return _productRepository.ActualizarCantidad(idProducto, nuevaCantidad);
        }



        public bool EliminarProducto(int idProducto)
        {
            return _productRepository.EliminarProducto(idProducto);
        }

        public bool GuardarProducto(Producto producto)
        {
            return _productRepository.GuardarProducto(producto);
        }

        public decimal CalcularTotalVentas(int idProducto)
        {
            return _productRepository.CalcularTotalVentas(idProducto);
        }

        public void ActualizarTotalVentas(int productId, Label totalRecaudado)
        {
            try
            {

                decimal totalVentas = CalcularTotalVentas(productId);

                totalRecaudado.Text = $"Total recaudado: ${totalVentas:F2} MXN";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al calcular el total de ventas: {ex.Message}",
                                 "Error",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error);
                totalRecaudado.Text = "Total recaudado: N/A";
            }
        }



        public void CloseImage(PictureBox imgControl, Panel panControl, Control closControl)
        {
            imgControl.Image = null;
            panControl.Visible = true;
            closControl.Visible = false;
        }

        public void SelectImage(PictureBox imgControl, Panel panControl, Control closControl)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                imgControl.ImageLocation = openFileDialog.FileName;
                panControl.Visible = false;
                closControl.Visible = true;
            }
        }

        public void ResetData()
        {
            _userDash.txtNameProduct.Clear();
            _userDash.txtDescripcion.Clear();
            _userDash.numericPrecio.Value = _userDash.numericPrecio.Minimum;
            _userDash.numericCantidad.Value = _userDash.numericCantidad.Minimum;
            _userDash.cmbCategoria.SelectedIndex = -1;
            _userDash.img5.Image = null;
            _userDash.panImg5.Visible = true;
            _userDash.closeImg5.Visible = false;
        }

        public void GenerateDynamicPostControl()
        {
            _userDash.flowLayoutPanel1.Controls.Clear();

            List<Producto> productos = _productRepository.ObtenerProductos();

            if (productos != null && productos.Count > 0)
            {
                foreach (Producto producto in productos)
                {
                    ProductUserControl productControl = new ProductUserControl(_userDash, this, _usuarioLoggedIn)
                    {
                        ProductId = producto.IdProducto,
                        ProductName = producto.Nombre ?? "Sin nombre",
                        ProductDescription = producto.Descripcion ?? "Sin descripción",
                        ProductCategory = producto.Categoria ?? "Sin categoría",
                        ProductPrice = producto.Precio,
                        ProductQuantity = producto.Cantidad,

                        ProductImage = producto.Imagen ?? "ruta_default_imagen.png"
                    };

                    _userDash.flowLayoutPanel1.Controls.Add(productControl);

                    ActualizarTotalVentas(producto.IdProducto,productControl.totalRecaudado);
                }
            }
            else
            {
                Console.WriteLine("No hay productos disponibles para mostrar.");
            }
        }

        public bool PostProduct()
        {
            string nombre = _userDash.txtNameProduct.Text.Trim();
            decimal precio = _userDash.numericPrecio.Value;
            int cantidad = (int)_userDash.numericCantidad.Value;
            string descripcion = _userDash.txtDescripcion.Text.Trim();
            string categoria = _userDash.cmbCategoria.SelectedItem?.ToString()?.Trim();
            string imagen = _userDash.img5.ImageLocation;

            if (string.IsNullOrEmpty(imagen) || imagen == "ruta_default_imagen.png")
            {
                MessageBox.Show("Por favor, selecciona una imagen para el producto.");
                return false;
            }

            if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(descripcion) || string.IsNullOrEmpty(categoria) || _userDash.cmbCategoria.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, completa todos los campos.");
                return false;
            }

            Producto nuevoProducto = new Producto
            {
                Nombre = nombre,
                Descripcion = descripcion,
                Precio = precio,
                Cantidad = cantidad,
                Imagen = imagen,
                Categoria = categoria
            };

            // Guardar el producto usando el repositorio
            try
            {
                bool resultado = GuardarProducto(nuevoProducto);
                if (resultado)
                {
                    ResetData();
                  
                }
                return resultado;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar el producto: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void SearchAll1_Click(object sender, EventArgs e)
        {
            MostrarTodo(_userDash.flowLayoutPanel1);
        }

        private void SearchHigiene_Click(object sender, EventArgs e)
        {
            string categoriaHigiene = "Higiene";
            BuscarPorCategoria(_userDash.flowLayoutPanel1, categoriaHigiene);
        }

        private void JuguetesSearchBox_Click(object sender, EventArgs e)
        {
            string categoriaJuguetes = "Juguetes";
            BuscarPorCategoria(_userDash.flowLayoutPanel1, categoriaJuguetes);
        }

        private void SaludAlimentoSearchBox_Click(object sender, EventArgs e)
        {
            string categoriaSaludAlimentos = "Salud y alimento";
            BuscarPorCategoria(_userDash.flowLayoutPanel1, categoriaSaludAlimentos);
        }

        private void searchBoxProduct_TextChanged(object sender, EventArgs e)
        {
            BuscarPorTexto(_userDash.flowLayoutPanel1, _userDash.searchBoxProduct.Text);
        }

        public void MostrarTodo(FlowLayoutPanel panel)
        {
            foreach (Control control in panel.Controls)
            {
                control.Visible = true;
            }
        }

        public void BuscarPorTexto(FlowLayoutPanel panel, string texto)
        {
            foreach (Control control in panel.Controls)
            {
                if (control is ProductUserControl petControl)
                {
                    string petName = petControl.ProductName?.ToString() ?? string.Empty;
                    petControl.Visible = petName.IndexOf(texto, StringComparison.OrdinalIgnoreCase) >= 0;
                }
            }
        }

        public void BuscarPorCategoria(FlowLayoutPanel panel, string categoria)
        {
            MostrarTodo(panel);

            foreach (Control control in panel.Controls)
            {
                if (control is ProductUserControl petControl)
                {
                    petControl.Visible = string.Equals(petControl.ProductCategory, categoria, StringComparison.OrdinalIgnoreCase);
                }
            }
        }
    }
}
