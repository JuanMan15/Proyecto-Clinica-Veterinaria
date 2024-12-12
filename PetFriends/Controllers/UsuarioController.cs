using PetFriends.Models;
using PetFriends.Repository;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PetFriends.Controllers
{
    public class UsuarioController
    {
        private readonly RegLog _frmLogin;
        private readonly UsuarioRepository usuarioRepository;

        public UsuarioController(RegLog frmLogin)
        {
            this._frmLogin = frmLogin ?? throw new ArgumentNullException(nameof(frmLogin));
            usuarioRepository = new UsuarioRepository();


            _frmLogin.minimizeBtn.Click += new System.EventHandler(this.minimizeBtn_Click);
            _frmLogin.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
            _frmLogin.timerForm.Tick += new System.EventHandler(this.timerForm_Tick);
            _frmLogin.TimerError.Tick += new System.EventHandler(this.TimerError_Tick);
            _frmLogin.TimerError2.Tick += new System.EventHandler(this.TimerError2_Tick);
            _frmLogin.loginBtn.Click += new System.EventHandler(this.loginBtn_Click);
            _frmLogin.signIn.Click += new System.EventHandler(this.signIn_Click);
            _frmLogin.registerBtn.Click += new System.EventHandler(this.registerBtn_Click);
            _frmLogin.signUp.Click += new System.EventHandler(this.signUp_Click);
        }

        public void HandleClose()
        {
            Application.Exit();
        }

        private void AbrirMenuPrincipal(Usuario usuario)
        {
            if (usuario == null)
            {
                MessageBox.Show("Error: No se encontró el usuario.");
                return;
            }

            _frmLogin.Hide();

            var dashboard = new UserDash(usuario);
            dashboard.Show();
        }


        public void InitializeForm()
        {
            VisibleComponents();
        }

        private void VisibleComponents()
        {
            _frmLogin.regPanel.Visible = false;
            _frmLogin.uaeMess.Visible = false;
            _frmLogin.pdneMess.Visible = false;
            _frmLogin.siP.Visible = false;
            _frmLogin.suP.Location = new Point(578, 553);
            _frmLogin.suP.Visible = true;
        }

        public void HandleTimerFormTick()
        {
            if (_frmLogin.Opacity == 1)
            {
                _frmLogin.timerForm.Stop();
            }
            _frmLogin.Opacity += .2;
        } 

        public void HandleSignIn()
        {
            if (!_frmLogin.suP.Visible)
            {
                ResetLogin();
                _frmLogin.regPanel.Visible = false;
                _frmLogin.logPanel.Visible = true;
                _frmLogin.siP.Visible = false;
                _frmLogin.suP.Visible = true;
            }
            else
            {
                _frmLogin.logPanel.Visible = false;
                _frmLogin.regPanel.Visible = true;
                _frmLogin.suP.Visible = false;
            }
        }

        public void HandleSignUp()
        {
            if (!_frmLogin.siP.Visible)
            {
                ResetRegister();
                _frmLogin.logPanel.Visible = false;
                _frmLogin.regPanel.Location = new Point(503, 101);
                _frmLogin.regPanel.Visible = true;
                _frmLogin.suP.Visible = false;
                _frmLogin.siP.Location = new Point(596, 554);
                _frmLogin.siP.Visible = true;
            }
            else
            {
                _frmLogin.regPanel.Visible = false;
                _frmLogin.logPanel.Visible = true;
                _frmLogin.siP.Visible = false;
            }
        }

        public void RegisterUser()
        {
            if (string.IsNullOrEmpty(_frmLogin.FName.Text) || string.IsNullOrEmpty(_frmLogin.UEmail.Text) || string.IsNullOrEmpty(_frmLogin.UPass.Text) || string.IsNullOrEmpty(_frmLogin.UTel.Text))
            {
                MessageBox.Show("Escribe la informacion solicitada!");
                return;
            }

            var userExists = usuarioRepository.UsuarioExiste(_frmLogin.UEmail.Text);
            if (userExists)
            {
                _frmLogin.uaeMess.Visible = true;
                _frmLogin.TimerError.Start();
            }
            else if (_frmLogin.UPass.Text.Length < 6 || _frmLogin.UPass.Text.Length > 50)
            {
                MessageBox.Show("La contraseña tiene que tener un minimo de 6 y maximo 50 caracteres.");
            }
            else
            {
                usuarioRepository.GuardarUsuario(_frmLogin.FName.Text, _frmLogin.UPass.Text, false, _frmLogin.UTel.Text, _frmLogin.UEmail.Text);
                MessageBox.Show("Usuario Creado Exitosamente.");
                ResetRegister();
            }
        }

        public void IniciarSesion()
        {
            string email = _frmLogin.emLog.Text; // Correo electrónico
            string contraseña = _frmLogin.passLog.Text; // Contraseña

            if (string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Por favor, ingrese un correo electrónico válido.");
                return;
            }

            if (string.IsNullOrEmpty(contraseña))
            {
                MessageBox.Show("Por favor, ingrese una contraseña válida.");
                return;
            }

            try
            {
                Usuario usuario = usuarioRepository.ObtenerUsuarioPorEmailYContraseña(email, contraseña);

                if (usuario != null)
                {

                    MessageBox.Show("Sesión iniciada correctamente.");
                    AbrirMenuPrincipal(usuario); //  para abrir el dashboard
                }
                else
                {
                    MessageBox.Show("Credenciales incorrectas. Por favor, verifique su email y contraseña.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al iniciar sesión: {ex.Message}");
            }
        }

        private void ResetLogin()
        {
            _frmLogin.emLog.Clear();
            _frmLogin.passLog.Clear();
        }

        private void ResetRegister()
        {
            _frmLogin.FName.Clear();
            _frmLogin.UEmail.Clear();
            _frmLogin.UTel.Clear();
            _frmLogin.UPass.Clear();
        }

        public void HandleTimerError()
        {
            _frmLogin.uaeMess.Visible = false;
        }

        public void HandleTimerError2()
        {
            _frmLogin.pdneMess.Visible = false;
        }


        private void minimizeBtn_Click(object sender, EventArgs e)
        {
            _frmLogin.WindowState = FormWindowState.Minimized;
        }


        private void timerForm_Tick(object sender, EventArgs e)
        {
            HandleTimerFormTick();
        }


        private void TimerError_Tick(object sender, EventArgs e)
        {
            HandleTimerError();
        }

        private void TimerError2_Tick(object sender, EventArgs e)
        {
            HandleTimerError2();
        }


        private void closeBtn_Click(object sender, EventArgs e)
        {
            HandleClose();
        }


        private void signIn_Click(object sender, EventArgs e)
        {
            HandleSignIn();
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            IniciarSesion();
        }

        private void signUp_Click(object sender, EventArgs e)
        {
            HandleSignUp();
        }

        private void registerBtn_Click(object sender, EventArgs e)
        {
            RegisterUser();
        }

    }
}
