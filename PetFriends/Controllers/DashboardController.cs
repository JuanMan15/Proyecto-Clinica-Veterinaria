using PetFriends.Repository;
using System.Data;
using System;
using System.Windows.Forms;
using System.Drawing;
using PetFriends.Models;
using PetFriends.Controller;
using System.Collections.Generic;
using System.IO;

namespace PetFriends.Controllers
{
    public class DashboardController
    {
        private string emailActual;
        private UserDash _userDash;
        private readonly Usuario usuarioLoggedIn;
        private readonly CitaController citaController;
        private readonly MascotasController mascotasController;
        private readonly UsuarioRepository usuarioRepository;
        private readonly ProductController productController;
        private readonly VentaController ventaController;
        private readonly UsuarioController _usuarioController;

        public DashboardController(UserDash userDash, Usuario usuario)
        {
            
            usuarioRepository = new UsuarioRepository();
            usuarioLoggedIn = usuario;
            citaController = new CitaController();
            mascotasController = new MascotasController(userDash, usuario);
            ventaController = new VentaController(userDash, usuario);
            _userDash = userDash;

            productController = new ProductController(userDash, usuario); 

            _userDash.closeDetBtn.Click += new System.EventHandler(this.closeDetBtn_Click);
            _userDash.guna2GradientButton1.Click += new System.EventHandler(this.guna2GradientButton1_Click);
            _userDash.logoutBtn.Click += new System.EventHandler(this.logoutBtn_Click);
            _userDash.minimizeBtn.Click += new System.EventHandler(this.minimizeBtn_Click);
            _userDash.HomePageBtn.Click += new System.EventHandler(this.HomePageBtn_Click);
            _userDash.CrearCitaBtn.Click += new System.EventHandler(this.CrearCitaBtn_Click);
            _userDash.InventarioBtn.Click += new System.EventHandler(this.InventarioBtn_Click);
            _userDash.ProductBtn.Click += new System.EventHandler(this.ProductBtn_Click);
            _userDash.VerVentasBtn.Click += new System.EventHandler(this.VerVentasBtn_Click);
            _userDash.VerUsuariosBtn.Click += new System.EventHandler(this.VerUsuariosBtn_Click);
        }

        // Visible components
        public void VisibleComponents()
        {
            // Botones y funcionalidades del sistema
            _userDash.guna2GradientButton1.BringToFront();
            _userDash.minimizeBtn.BringToFront();
            _userDash.closImg1.Visible = false;
            _userDash.closImg2.Visible = false;
            _userDash.closImg3.Visible = false;
            _userDash.closImg4.Visible = false;
            _userDash.closeImg5.Visible = false;
            _userDash.webBrowser1.Visible = false;
           
            _userDash.webBrowser1.Location = new Point(263, 99);
           
            // Vista inicial panel de mascotas historial con citas
            mascotasController.GenerateDynamicPostControl();
            _userDash.flowLayoutPanel1.Location = new Point(264, 174);
            _userDash.flowLayoutPanel2.Location = new Point(307, 66);
            _userDash.flowLayoutPanel2.Visible = false;
            _userDash.panel2.Location = new Point(542, 19);
            _userDash.panelBuscar.Location = new Point(542, 19);
            _userDash.totalLabel.Visible = false;
            _userDash.totalLabel.Location = new Point(974, 125);
           
            //panel de crear cita
            _userDash.panel3.Location = new Point(398, 6);
            _userDash.panel13.Location = new Point(398, 6);
            _userDash.panel4.Location = new Point(357, 33);
            _userDash.panel4.Visible = false;
            _userDash.panel13.Visible = false;
            _userDash.panelBuscar.Visible = false;

            //panel de inventario
            _userDash.panel3.Visible = false;

            _userDash.ConcretarVentaBtn.Visible = false;
            _userDash.ConcretarVentaBtn.Location = new Point(955, 85);

            // Validar permisos de administrador
            if (!usuarioLoggedIn.Administrador)
            {
                _userDash.VerVentasBtn.Visible = false;
                _userDash.VerUsuariosBtn.Visible = false;
                _userDash.InventarioBtn.Visible = false;
            }

        }
        public DataRow GetUserData(string email)
        {
            DataTable userTable = usuarioRepository.GetUserByEmail(email);
            return userTable.Rows.Count > 0 ? userTable.Rows[0] : null;
        }

        // Página de inicio
        private void HomePageBtn_Click(object sender, EventArgs e)
        {
            _userDash.flowLayoutPanel2.Visible = false;
            _userDash.flowLayoutPanel1.Visible = true;
            mascotasController.GenerateDynamicPostControl();
            _userDash.flowLayoutPanel2.Visible = false;
            _userDash.panel4.Visible = false;
            _userDash.panel2.Visible = true;
            _userDash.panel3.Visible = false;
            _userDash.panelBuscar.Visible = false;
            _userDash.panel13.Visible = false;
            _userDash.webBrowser1.Visible = false;
          
            _userDash.ConcretarVentaBtn.Visible = false;
            _userDash.totalLabel.Visible = false;
            _userDash.flowLayoutPanel1.Location = new Point(264, 174);
        }

        // Mostrar el panel para crear cita
        private void CrearCitaBtn_Click(object sender, EventArgs e)
        {
            _userDash.flowLayoutPanel2.Visible = false;
            _userDash.flowLayoutPanel1.Visible = false;
            _userDash.flowLayoutPanel2.Visible = false;
            _userDash.panel4.Visible = false;
            _userDash.panel2.Visible = false;
            _userDash.panel13.Visible = false;
            _userDash.panelBuscar.Visible = false;
            _userDash.panel3.Visible = true;
            _userDash.webBrowser1.Visible = false;
           
            mascotasController.ResetData();
            _userDash.ConcretarVentaBtn.Visible = false;
            _userDash.totalLabel.Visible = false;

          
        }

        // Mostrar el panel para inventario
        private void InventarioBtn_Click(object sender, EventArgs e)
        {
            _userDash.flowLayoutPanel2.Visible = false;
            _userDash.flowLayoutPanel1.Visible = false;
            _userDash.flowLayoutPanel2.Visible = false;
            _userDash.panel4.Visible = false;
            _userDash.panel2.Visible = false;
            _userDash.panel3.Visible = false; 
            _userDash.panel13.Visible = true;
            _userDash.panelBuscar.Visible = false;
            _userDash.webBrowser1.Visible = false;
           
            _userDash.ConcretarVentaBtn.Visible = false;
            _userDash.totalLabel.Visible = false;
            productController.ResetData();

            
        }

        // Evento del botón ProductBtn para mostrar productos
        private void ProductBtn_Click(object sender, EventArgs e)
        {
            _userDash.flowLayoutPanel1.Location = new Point(264, 174);
            _userDash.flowLayoutPanel2.Visible = false;
            _userDash.flowLayoutPanel1.Visible = true;
            _userDash.panel4.Visible = false;
            _userDash.panel2.Visible = false;
            _userDash.panel3.Visible = false;
            _userDash.flowLayoutPanel1.Controls.Clear();
            _userDash.panel13.Visible = false;
            _userDash.panelBuscar.Visible = true;
            _userDash.ConcretarVentaBtn.Visible = true;
            _userDash.totalLabel.Visible = true;
            _userDash.totalLabel.BringToFront();

            productController.GenerateDynamicPostControl();
        }

        private void VerVentasBtn_Click(object sender, EventArgs e)
        {

            _userDash.panel4.Visible = false;
            _userDash.panel2.Visible = false;
            _userDash.panel3.Visible = false;
            _userDash.flowLayoutPanel1.Location = new Point(307, 66);
            _userDash.flowLayoutPanel2.Visible = false;
            _userDash.ConcretarVentaBtn.Visible = false;
            _userDash.totalLabel.Visible = false;
            _userDash.panelBuscar.Visible = false;
            _userDash.panel13.Visible = false;

            var ventas = ventaController.ObtenerVentas();

            _userDash.flowLayoutPanel1.Controls.Clear();

            foreach (var venta in ventas)
            {
                var ventaControl = new UserControlVenta();
                ventaControl.SetVentaData(venta);  

                _userDash.flowLayoutPanel1.Controls.Add(ventaControl);
            }

            _userDash.flowLayoutPanel1.Visible = true;
        }

        private void VerUsuariosBtn_Click(object sender, EventArgs e)
        {

            _userDash.flowLayoutPanel2.Visible = false;
            _userDash.flowLayoutPanel1.Visible = false;
            _userDash.panel4.Visible = false;
            _userDash.panel2.Visible = false;
            _userDash.panel3.Visible = false;
            _userDash.panel13.Visible = false;
            _userDash.panelBuscar.Visible = false;
            _userDash.ConcretarVentaBtn.Visible = false;
            _userDash.totalLabel.Visible = false;
            _userDash.webBrowser1.Visible = false;

            _userDash.flowLayoutPanel2.Controls.Clear();
            _userDash.flowLayoutPanel2.Visible = true;

            MostrarUsuarios(_userDash.flowLayoutPanel2);
        }

        // Actualizar imagen de perfil
        public void UpdateProfilePicture(string email, string imagePath)
        {
            usuarioRepository.UpdateUserProfileImage(email, imagePath);
        }

        // Cerrar imagen
        public void CerrarImagen(PictureBox pictureBox, Panel panel, Control closeButton)
        {
            pictureBox.Image = null;
            panel.Visible = true;
            closeButton.Visible = false;
        }

        // Método para cerrar el panel de detalles
        private void closeDetBtn_Click(object sender, EventArgs e)
        {
            _userDash.panel4.Visible = false;
            _userDash.panel2.Visible = true;
            _userDash.flowLayoutPanel1.Visible = true;
           
        }

        // Evento para cerrar sesión
        private void logoutBtn_Click(object sender, EventArgs e)
        {
            _userDash.Hide();
            RegLog loginForm = new RegLog();
            loginForm.Show();
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            Logout();
        }

        private void Logout()
        {
            _userDash.Hide();
            RegLog loginForm = new RegLog();
            loginForm.Show();
        }

        private void minimizeBtn_Click(object sender, EventArgs e)
        {
            _userDash.WindowState = FormWindowState.Minimized;
        }

        public List<Usuario> ObtenerUsuarios()
        {

            return usuarioRepository.ObtenerTodos();

        }

        public void MostrarUsuarios(FlowLayoutPanel flowLayoutPanel)
        {
            flowLayoutPanel.Controls.Clear();

            var usuarios = ObtenerUsuarios();

            foreach (var usuario in usuarios)
            {
                var userControl = new UserAccountControl(usuarioLoggedIn, this);

                userControl.ConfigurarUsuario(
                    usuario.Id,
                    usuario.NombreCompleto,
                    usuario.Telefono,
                    usuario.Administrador,
                    usuario.Email,
                    usuario.Imagen 
                );

                flowLayoutPanel.Controls.Add(userControl);
            }
        }


    }

}
