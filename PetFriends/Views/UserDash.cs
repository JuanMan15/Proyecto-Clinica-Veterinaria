using System;
using System.Collections.Generic;

using System.Drawing;
using System.Windows.Forms;
using System.IO;
using PetFriends.Controllers;
using PetFriends.Models;
using PetFriends.Controller;
using System.Linq;
using PetFriends.Repository;
using System.Drawing.Text;
using PetFriends.ExtraConfig;


namespace PetFriends
{
    public partial class UserDash : Form
    {
        private string emailActual;
        private int userId;
        private readonly Usuario usuarioLoggedIn;
        private readonly MascotasController _mascotasController;
        private readonly CitaController _citaController;
        private readonly DashboardController _dashboardController;
        private readonly ProductController _productController;
        private readonly VentaController _ventaController;

        public UserDash(Usuario usuario)
        {

            usuarioLoggedIn = usuario;
            InitializeComponent();
            _mascotasController = new MascotasController(this, usuario);
            _citaController = new CitaController();
            _dashboardController = new DashboardController(this, usuarioLoggedIn);
            _productController = new ProductController(this, usuario);
            _ventaController = new VentaController(this, usuario);

            _ventaController.VentaConcretada += VentaController_VentaConcretada;

        }

        private void UserDash_Load(object sender, EventArgs e)
        {
            _dashboardController.VisibleComponents();
            CargarUsuario();
           
        }

        // Actualizar imagen de perfil
        private void addProfilePicBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string imagePath = dialog.FileName;
                profilePic.ImageLocation = imagePath;

                try
                {
                    _dashboardController.UpdateProfilePicture(emailActual, imagePath);
                    MessageBox.Show("Imagen de perfil actualizada.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al actualizar imagen: {ex.Message}");
                }
            }
        }

        private void CargarUsuario()
        {
            try
            {
                emailActual = usuarioLoggedIn.Email;
                var userData = _dashboardController.GetUserData(emailActual);

                if (userData != null)
                {
                    FullN.Text = userData["nombre_completo"].ToString();
                    userId = Convert.ToInt32(userData["id"]);

                    // Verifica si hay una imagen o usa la predeterminada
                    if (userData["imagen"] != DBNull.Value && !string.IsNullOrEmpty(userData["imagen"].ToString()))
                    {
                        string imagePath = userData["imagen"].ToString();
                        profilePic.ImageLocation = imagePath;
                    }
                }
                else
                {
                    MessageBox.Show("No se encontraron datos para este usuario.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar usuario: {ex.Message}");
            }
        }

        private void PostProductBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (!usuarioLoggedIn.Administrador)
                {
                    MessageBox.Show("Solo los administradores pueden crear productos.");
                    return;
                }

                bool resultado = _productController.PostProduct();

                if (resultado)
                {
                    MessageBox.Show("Producto guardado exitosamente.");


                }
                else
                {
                    MessageBox.Show("Hubo un error al guardar el producto.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void postBtn_Click(object sender, EventArgs e)
        {
            string nombreMascota = txtNombre.Text;
            string especie = cmbEspecie.SelectedItem?.ToString();
            string raza = txtRaza.Text;
            int edad = (int)numEdad.Value;
            decimal peso = numPeso.Value;
            string notas = txtNotas.Text;
            DateTime fechaCita = dtpFechaHora.Value;
            string servicio = cmbServicio.SelectedItem?.ToString();

            Image[] imagenes = {
              Img1.Image,
              Img2.Image,
              Img3.Image,
              Img4.Image
            };

            bool success = _mascotasController.GuardarMascotaYCrearCita(nombreMascota, especie, raza, edad, peso, notas, fechaCita, servicio, imagenes);

            if (success)
            {
                _mascotasController.ResetData();
                _mascotasController.GenerateDynamicPostControl();
            }
        }


        private void brImg1_Click(object sender, EventArgs e)
        {
            _mascotasController.SelectImage(Img1, panImg1, closImg1);

        }

        private void brImg2_Click(object sender, EventArgs e)
        {
            _mascotasController.SelectImage(Img2, panImg2, closImg2);

        }

        private void brImg3_Click(object sender, EventArgs e)
        {
            _mascotasController.SelectImage(Img3, panImg3, closImg3);

        }

        private void brImg4_Click(object sender, EventArgs e)
        {
            _mascotasController.SelectImage(Img4, panImg4, closImg4);

        }

        private void closImg1_Click(object sender, EventArgs e)
        {
           _mascotasController.CloseImage(Img1, panImg1, closImg1);

        }

        private void closImg2_Click(object sender, EventArgs e)
        {
            _mascotasController.CloseImage(Img2, panImg2, closImg2);
        }

        private void closImg3_Click(object sender, EventArgs e)
        {
            _mascotasController.CloseImage(Img3, panImg3, closImg3);
        }

        private void closImg4_Click(object sender, EventArgs e)
        {
            _mascotasController.CloseImage(Img4, panImg4, closImg4);
        }

        //Productos /Inventario
        private void brImg5_Click(object sender, EventArgs e)
        {
            _productController.SelectImage(img5, panImg5, closeImg5);

        }

        private void closeImg5_Click(object sender, EventArgs e)
        {
            _productController.CloseImage(img5, panImg5, closeImg5);

        }

        private void ConcretarVentaBtn_Click(object sender, EventArgs e)
        {
            _ventaController.ConcretarVenta();
        }

        private void VentaController_VentaConcretada(object sender, VentaEventArgs e)
        {
            MessageBox.Show($"Venta registrada exitosamente:\nID: {e.VentaId}\nTotal: ${e.Total:F2}", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //_productController.GenerateDynamicPostControl();
        }
    }
}
