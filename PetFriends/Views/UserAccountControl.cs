using PetFriends.Controllers;
using PetFriends.Models;
using PetFriends.Repository;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace PetFriends
{
    public partial class UserAccountControl : UserControl
    {
        public int UsuarioId { get; set; }
        private string _userName, _userEmail, _userPhone, _userPrivilege;
        private Image _userImage;
        private UserDash _userDash;

        private Usuario _usuarioLoggedIn;
        private UsuarioRepository _usuarioRepository;
        private DashboardController _dashboardController;

        public event EventHandler OnSelect;

        public UserAccountControl(Usuario usuarioLoggedIn, DashboardController dashboardController)
        {
            InitializeComponent();

            _userDash = new UserDash(usuarioLoggedIn);
            _usuarioLoggedIn = usuarioLoggedIn;
            _usuarioRepository = new UsuarioRepository();
            _dashboardController = dashboardController;

        }

        // Propiedad para la imagen de usuario
        public Image UserImage
        {
            get => _userImage;
            set
            {
                _userImage = value;
                UsuarioPic.Image = value;
            }
        }

        // Propiedad para el nombre del usuario
        public string UserName
        {
            get => _userName;
            set
            {
                _userName = value;
                Usuario_Nombre.Text = value;
            }
        }

        // Propiedad para el teléfono del usuario
        public string UserPhone
        {
            get => _userPhone;
            set
            {
                _userPhone = value;
                Usuario_Telefono.Text = value;
            }
        }

        // Propiedad para el privilegio del usuario
        public string UserPrivilege
        {
            get => _userPrivilege;
            set
            {
                _userPrivilege = value;
                Usuario_Privilegio.Text = value;
            }
        }

        // Propiedad para el email del usuario
        public string UserEmail
        {
            get => _userEmail;
            set
            {
                _userEmail = value;
                Usuario_Email.Text = value;
            }
        }

        public void ConfigurarUsuario(int id, string nombreCompleto, string telefono, bool administrador, string email, string rutaImagen)
        {
            UsuarioId = id;
            UserName = nombreCompleto;
            UserPhone = telefono;
            UserEmail = email;

            if (!string.IsNullOrEmpty(rutaImagen) && System.IO.File.Exists(rutaImagen))
            {
                UserImage = Image.FromFile(rutaImagen);
            }
            else
            {
                UserImage = Properties.Resources.Default;
            }

            UserPrivilege = administrador ? "Administrador" : "No Administrador";

            MostrarIngresos(UsuarioId);
        }

        public void MostrarIngresos(int idEmpleado)
        {
            decimal ingresos = _usuarioRepository.CalcularIngresoTotalEmpleado(idEmpleado);
            IngresosLabel.Text = $"Ventas Totales: {ingresos:C}";
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (_usuarioLoggedIn == null || !_usuarioLoggedIn.Administrador)
            {
                MessageBox.Show("No tienes permiso para realizar esta acción.", "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (UsuarioId == _usuarioLoggedIn.Id)
            {
                MessageBox.Show("No puedes eliminar tu propia cuenta de administrador.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("¿Está seguro de que desea eliminar este usuario?", "Confirmación", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                bool eliminado = _usuarioRepository.EliminarUsuario(UsuarioId);

                if (eliminado)
                {
                    MessageBox.Show("Usuario y sus ventas eliminados correctamente.");

                    _userDash.flowLayoutPanel2.Controls.Clear();
                    _dashboardController.MostrarUsuarios(_userDash.flowLayoutPanel2);
                }
                else
                {
                    MessageBox.Show("Hubo un error al eliminar el usuario.");
                }
            }
        }
    }
}
