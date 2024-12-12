using MySql.Data.MySqlClient;
using PetFriends.Controller;
using PetFriends.Controllers;
using PetFriends.Models;
using System;
using System.Drawing;
using System.Windows.Forms;


namespace PetFriends
{
    public partial class ProductUserControl : UserControl
    {
        private readonly UserDash _userDash;
        private readonly ProductController _productController;
        private readonly Usuario _usuarioLoggedIn;

        public event EventHandler QuantityChanged;

        public string _productName, _productDescription, _productCategory, _productImage;
        private decimal _productPrice;
        private int _productQuantity;

        public bool IsSelected => checkBoxArticulo.Checked;
        public int SelectedQuantity => (int)numericUpArticulo.Value;
        public string NombreProducto { get; set; }
       
        public int ProductId { get; set; }

        public event EventHandler OnSelect;

        public decimal ProductTotal => IsSelected ? ProductPrice * SelectedQuantity : 0;

        public ProductUserControl(UserDash userDash, ProductController productController, Usuario usuario)
        {
            _userDash = userDash ?? throw new ArgumentNullException(nameof(userDash));
            _productController = productController ?? throw new ArgumentNullException(nameof(productController));
            _usuarioLoggedIn = usuario ?? throw new ArgumentNullException(nameof(usuario));

            InitializeComponent();

            btnEliminar.Visible = _usuarioLoggedIn.Administrador;

            if (!_usuarioLoggedIn.Administrador)
            {
                //cantidadTextBox.Enabled = false;
                cantidadTextBox.ReadOnly = true;
                cantidadTextBox.BackColor = SystemColors.Control;
                cantidadTextBox.ForeColor = SystemColors.GrayText; 
                cantidadTextBox.Cursor = Cursors.No;
                totalRecaudado.Visible = false;
            }

            numericUpArticulo.ValueChanged += numericUpArticulo_ValueChanged;
            checkBoxArticulo.CheckedChanged += checkBoxArticulo_CheckedChanged;


            if (_usuarioLoggedIn.Administrador)
            {
                cantidadTextBox.KeyDown += CantidadTextBox_KeyDown;
            }


        }

        // Propiedades de detalles del producto
        public string ProductName
        {
            get => _productName;
            set { _productName = value; Product_T.Text = value; }
        }

        public string ProductDescription
        {
            get => _productDescription;
            set { _productDescription = value; Product_D.Text = value; }
        }

        public string ProductCategory
        {
            get => _productCategory;
            set { _productCategory = value; Product_C.Text = value; }
        }

        public string ProductImage
        {
            get => _productImage;
            set { _productImage = value; ProductPic.ImageLocation = value; }
        }

        public decimal ProductPrice
        {
            get => _productPrice;
            set { _productPrice = value; Product_Price.Text = $"${value:F2}"; }
        }

        public int ProductQuantity
        {
            get => _productQuantity;
            set
            {
                _productQuantity = value;
                Product_Quantity.Text = $"Cantidad: {_productQuantity}";
                cantidadTextBox.Text = _productQuantity.ToString();
                numericUpArticulo.Maximum = _productQuantity;
                numericUpArticulo.Enabled = _productQuantity > 0;
            }
        }

        // Manejo del clic en el botón de eliminar
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "¿Está seguro de que desea eliminar este producto y todas sus imágenes o categorías asociadas?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result == DialogResult.Yes)
            {
                try
                {
                    bool eliminado = _productController.EliminarProducto(ProductId);

                    if (eliminado)
                    {
                        MessageBox.Show("¡Producto, imágenes y categorías asociadas eliminados correctamente!",
                                        "Éxito",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);

                        _productController.GenerateDynamicPostControl();
                    }
                    else
                    {
                        MessageBox.Show("Hubo un error al eliminar el producto o sus relaciones.",
                                        "Error",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}",
                                    "Error",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }
            }
        }

        // Obtener el producto seleccionado y su cantidad
        public (int productId, int quantity, string nombreProducto) GetSelectedProduct()
        {
            if (IsSelected && SelectedQuantity > 0)
            {
                return (ProductId, SelectedQuantity, ProductName);
            }
            return (0, 0, string.Empty);
        }

        private void checkBoxArticulo_CheckedChanged(object sender, EventArgs e)
        {
            if (IsSelected && SelectedQuantity > ProductQuantity)
            {
                MessageBox.Show($"Cantidad seleccionada ({SelectedQuantity}) excede la cantidad disponible ({ProductQuantity}).",
                                "Cantidad no disponible",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                checkBoxArticulo.Checked = false; // Restablece el checkbox
                return; // Detiene más acciones
            }

            QuantityChanged?.Invoke(this, EventArgs.Empty);
            ActualizarTotal();
        }



        private void numericUpArticulo_ValueChanged(object sender, EventArgs e)
        {
            
            if (SelectedQuantity > ProductQuantity)
            {
                MessageBox.Show("La cantidad solicitada excede la cantidad disponible.", "Cantidad no disponible",MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                numericUpArticulo.Value = ProductQuantity; 
            }
            else
            {
                QuantityChanged?.Invoke(this, EventArgs.Empty);
                ActualizarTotal();
            }
        }

        private void ActualizarTotal()
        {
            decimal total = 0;

            // Itera sobre todos los controles del flowLayoutPanel
            foreach (Control control in _userDash.flowLayoutPanel1.Controls)
            {
                if (control is ProductUserControl productControl)
                {
                    // Sumar el subtotal solo si el producto está seleccionado
                    if (productControl.IsSelected)
                    {
                        total += productControl.ProductTotal;
                    }
                }
            }

            _userDash.totalLabel.Text = $"Total: ${total:F2}MXN";
        }

      
        private void CantidadTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; 

                if (int.TryParse(cantidadTextBox.Text, out int nuevaCantidad))
                {
                    if (_productController.ActualizarCantidadProducto(ProductId, nuevaCantidad))
                    {
                        ProductQuantity = nuevaCantidad;
                        MessageBox.Show("Cantidad actualizada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Error al actualizar la cantidad.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        cantidadTextBox.Text = _productQuantity.ToString();
                    }
                }
                else
                {
                    MessageBox.Show("Ingrese un valor numérico válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cantidadTextBox.Text = _productQuantity.ToString(); 
                }
            }
        }

    }
}
