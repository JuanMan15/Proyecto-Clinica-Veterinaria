using MySql.Data.MySqlClient;
using PetFriends.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PetFriends
{
    public partial class PetUserControl : UserControl
    {
        private Image _ico1, _ico2, _ico3, _ico4;
        private readonly UserDash _userDash;
        public int MascotaId { get; set; }
        private string _petName, _petSpecies, _petBreed, _petAge, _petWeight, _petNotes;
        public event EventHandler OnSelect = null;
        private readonly MascotasController _mascotasController;

        public PetUserControl(UserDash userDash, MascotasController mascotasController)
        {
            _userDash = userDash ?? throw new ArgumentNullException(nameof(userDash));
            _mascotasController = mascotasController ?? throw new ArgumentNullException(nameof(mascotasController));
            InitializeComponent();
        }

        // Propiedades para los iconos
        public Image Icon1
        {
            get { return _ico1; }
            set { _ico1 = value; PetPic.Image = value; }
        }

        public Image Icon2
        {
            get { return _ico2; }
            set { _ico2 = value; /*PetPic2.Image = value;*/ }
        }

        public Image Icon3
        {
            get { return _ico3; }
            set { _ico3 = value; /*PetPic3.Image = value;*/ }
        }

        public Image Icon4
        {
            get { return _ico4; }
            set { _ico4 = value; /*PetPic4.Image = value;*/ }
        }

        // Propiedades para los detalles de la mascota
        public string PetName
        {
            get => _petName;
            set { _petName = value; Pet_C.Text = value; }
        }

        public string PetSpecies
        {
            get => _petSpecies;
            set { _petSpecies = value; Pet_T.Text = value; }
        }

        public string PetBreed
        {
            get => _petBreed;
            set { _petBreed = value; Pet_D.Text = value; }
        }

        public string PetAge
        {
            get => _petAge;
            set { _petAge = value; Pet_L.Text = value; }
        }

        public string PetWeight
        {
            get => _petWeight;
            set { _petWeight = value; Post_P.Text = value; }
        }

        public string PetNotes
        {
            get => _petNotes;
            set { _petNotes = value; Post_C.Text = value; }
        }

        //Evento para "details"
        private void MoreInfoBtn_Click(object sender, EventArgs e)
        {
            OnSelect?.Invoke(this, e);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "¿Está seguro de que desea eliminar esta mascota y todas sus citas e imágenes asociadas?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result == DialogResult.Yes)
            {
                try
                {
                    bool eliminado = _mascotasController.EliminarMascotaPorId(MascotaId);

                    if (eliminado)
                    {
                        MessageBox.Show("¡Mascota, citas e imágenes eliminadas correctamente!",
                                        "Éxito",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);

                        _mascotasController.GenerateDynamicPostControl();
                    }
                    else
                    {
                        MessageBox.Show("Hubo un error al eliminar la mascota, citas o imágenes.",
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



    }
}
