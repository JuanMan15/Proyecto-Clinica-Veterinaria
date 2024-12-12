using System;
using System.Collections.Generic;
using PetFriends.Repository;
using System.Windows.Forms;
using PetFriends.Controllers;
using System.Drawing;
using System.IO;
using PetFriends.Models;
using MySql.Data.MySqlClient;
using System.Transactions;

namespace PetFriends.Controller
{
    public class MascotasController
    {
        private readonly MascotasRepository _mascotasRepository;
        private readonly UserDash _userDash;
        private readonly CitaRepository _citasRepository;
        private readonly Usuario usuarioLoggedIn;
        private readonly CitaController _citaController;

        public MascotasController(UserDash userDash, Usuario usuario)
        {
            usuarioLoggedIn = usuario;
            _citaController = new CitaController();
            _mascotasRepository = new MascotasRepository();
            _userDash = userDash;
            _citasRepository = new CitaRepository();
     
            _userDash.CatsSearchBox.Click += new System.EventHandler(this.CatsSearchBox_Click);
            _userDash.searchBoxType.TextChanged += new System.EventHandler(this.searchBoxType_TextChanged);
            _userDash.SearchDogs.Click += new System.EventHandler(this.SearchDogs_Click);
            _userDash.SearchOther.Click += new System.EventHandler(this.SearchOther_Click);
            _userDash.HomePageBtn.Click += new System.EventHandler(this.HomePageBtn_Click);
            _userDash.SearchAll.Click += new EventHandler(this.SearchAll_Click);
      
        }


        private void HomePageBtn_Click(object sender, EventArgs e)
        {
            MostrarTodo(_userDash.flowLayoutPanel1);

        }

        private void SearchAll_Click(object sender, EventArgs e)
        {
         
            MostrarTodo(_userDash.flowLayoutPanel1); 
        }


        // Guardar una nueva mascota
        public bool GuardarNuevaMascota(Mascota nuevaMascota)
        {
            return _mascotasRepository.GuardarMascota(nuevaMascota);
        }


        public bool EliminarMascotaPorId(int idMascota)
        {
            try
            {
                // Primero, eliminar las imágenes asociadas a la mascota
                bool imagenesEliminadas = _mascotasRepository.EliminarImagenesPorMascota(idMascota);
                if (!imagenesEliminadas)
                {
                    throw new Exception("No se pudieron eliminar las imágenes asociadas a la mascota.");
                }

                // Luego, eliminar las citas asociadas a la mascota
                bool citasEliminadas = _citasRepository.EliminarCitasPorMascota(idMascota);
                if (!citasEliminadas)
                {
                    throw new Exception("No se pudieron eliminar las citas asociadas a la mascota.");
                }

                // Finalmente, eliminar la mascota
                bool mascotaEliminada = _mascotasRepository.EliminarMascota(idMascota);
                if (!mascotaEliminada)
                {
                    throw new Exception("No se pudo eliminar la mascota.");
                }

                return true; 
            }
            catch (MySqlException sqlEx)
            {
                Console.WriteLine($"Error de MySQL: {sqlEx.Message}");
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error general: {ex.Message}");
                return false;
            }
        }


        // Guardar imagen para una mascota
        public bool GuardarImagenDeMascota(MascotaImagen nuevaImagen)
        {
            return _mascotasRepository.GuardarImagen(nuevaImagen);
        }

        public List<Mascota> GetMascotasWithImages()
        {
            // Obtener todas las mascotas
            var mascotas = _mascotasRepository.ObtenerTodas();

            // Para cada mascota, obtener sus imágenes
            foreach (var mascota in mascotas)
            {
                mascota.Imagenes = _mascotasRepository.ObtenerImagenesPorIdMascota(mascota.IdMascota);
            }

            return mascotas;
        }

        
        // Método general para cerrar imágenes
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

        public void BuscarPorCategoria(FlowLayoutPanel panel, string categoria)
        {
            MostrarTodo(panel); // Restaurar visibilidad antes de aplicar el filtro.

            foreach (Control control in panel.Controls)
            {
                if (control is PetUserControl petControl)
                {
                    petControl.Visible = string.Equals(petControl.PetSpecies, categoria, StringComparison.OrdinalIgnoreCase);
                }
            }
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
                if (control is PetUserControl petControl)
                {
                    string petName = petControl.PetName?.ToString() ?? string.Empty;  // Convertir a cadena
                    petControl.Visible = petName.IndexOf(texto, StringComparison.OrdinalIgnoreCase) >= 0;
                }
            }
        }

        // Buscar por texto
        private void searchBoxType_TextChanged(object sender, EventArgs e)
        {
            BuscarPorTexto(_userDash.flowLayoutPanel1, _userDash.searchBoxType.Text);
        }

        private void SearchDogs_Click(object sender, EventArgs e)
        {
            string categoriaPerro = "Perro";
            BuscarPorCategoria(_userDash.flowLayoutPanel1, categoriaPerro);
        }

        private void SearchOther_Click(object sender, EventArgs e)
        {
            MostrarTodo(_userDash.flowLayoutPanel1); 

            foreach (Control control in _userDash.flowLayoutPanel1.Controls)
            {
                if (control is PetUserControl petControl)
                {
                    string especie = petControl.PetSpecies?.ToLower() ?? string.Empty;
                    petControl.Visible = !(especie.Contains("perro") || especie.Contains("gato")); 
                }
            }
        }

        private void CatsSearchBox_Click(object sender, EventArgs e)
        {
            string categoriaGato = "Gato"; 
            BuscarPorCategoria(_userDash.flowLayoutPanel1, categoriaGato);
        }


        public bool GuardarImagenes(int idMascota, params Image[] images)
        {
            try
            {
                string basePath = @"C:\Images\Mascotas\"; 
                Directory.CreateDirectory(basePath);

                MascotaImagen imagen = new MascotaImagen { IdMascota = idMascota };

                for (int i = 0; i < images.Length; i++)
                {
                    if (images[i] != null)
                    {
                        string imagePath = Path.Combine(basePath, $"Mascota_{idMascota}_{i + 1}.jpg");
                        images[i].Save(imagePath);
                        switch (i)
                        {
                            case 0: imagen.PetImg1 = imagePath; break;
                            case 1: imagen.PetImg2 = imagePath; break;
                            case 2: imagen.PetImg3 = imagePath; break;
                            case 3: imagen.PetImg4 = imagePath; break;
                        }
                    }
                }

                return GuardarImagenDeMascota(imagen); 
            }
            catch
            {
                return false; 
            }
        }

        public List<Mascota> GetMascotasByUserId(int userId)
        {
            return _mascotasRepository.GetMascotasByUserId(userId);
        }


        public void DetailsControl_Click(object sender, EventArgs es)
        {
            PetUserControl obj = (PetUserControl)sender;

            // Obtener los detalles de la mascota
            Mascota mascota = _mascotasRepository.GetMascotaDetails(obj.MascotaId);

            if (mascota != null)
            {
                _userDash.Det_Cat.Text = mascota.Especie;
                _userDash.Det_Loc.Text = mascota.Edad?.ToString() ?? "Desconocida";
                _userDash.det_breed.Text = mascota.Raza;
                _userDash.Det_Post.Text = mascota.NombreEmpleado; // Asignar el nombre del usuario que registró la mascota
                _userDash.Det_Cont.Text = mascota.Peso?.ToString("F2") ?? "N/A";
                _userDash.Det_Desc.Text = mascota.Notas;

                List<Cita> citas = _citasRepository.ObtenerCitasPorMascota(mascota.IdMascota);

                if (citas != null && citas.Count > 0)
                {
                    _userDash.Det_Date.Text = citas[0].FechaHora.ToString("dd/MM/yyyy");
                    _userDash.det_service.Text = citas[0].Servicio;
                }

                _userDash.Det_Pic1.Image = obj.Icon1;
                _userDash.Det_Pic2.Image = obj.Icon2;
                _userDash.Det_Pic3.Image = obj.Icon3;

                _userDash.panel2.Visible = false;
                _userDash.flowLayoutPanel1.Visible = false;
                _userDash.panel4.Visible = true;
            }
            else
            {
                Console.WriteLine("No se pudieron cargar los detalles de la mascota.");
            }
        }

        public bool GuardarMascotaYCrearCita(string nombreMascota, string especie, string raza, int edad, decimal peso, string notas, DateTime fechaCita, string servicio, Image[] imagenes)
        {
            try
            {
                // Validaciones iniciales
                if (string.IsNullOrWhiteSpace(nombreMascota))
                {
                    MessageBox.Show("El campo 'Nombre' es requerido.",
                                    "Advertencia",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                    return false;
                }

                if (string.IsNullOrWhiteSpace(especie))
                {
                    MessageBox.Show("Debe seleccionar una 'Especie'.",
                                    "Advertencia",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                    return false;
                }

                Mascota nuevaMascota = new Mascota
                {
                    Nombre = nombreMascota.Trim(),
                    Especie = especie,
                    Raza = raza?.Trim(),
                    Edad = edad,
                    Peso = peso,
                    Notas = notas?.Trim(),
                    IdEmpleado = usuarioLoggedIn.Id // Usuario actualmente autenticado
                };

                using (var transaction = new TransactionScope())
                {
                    // Guardar Mascota
                    bool mascotaGuardada = GuardarNuevaMascota(nuevaMascota);
                    if (!mascotaGuardada)
                        throw new Exception("Error al guardar los datos de la mascota.");

                    // Guardar imágenes (si las hay)
                    bool imagenesGuardadas = GuardarImagenes(nuevaMascota.IdMascota, imagenes);
                    if (!imagenesGuardadas)
                        throw new Exception("Error al guardar las imágenes.");

                    // Crear y guardar Cita
                    Cita nuevaCita = new Cita
                    {
                        IdEmpleado = nuevaMascota.IdEmpleado,
                        IdMascota = nuevaMascota.IdMascota,
                        FechaHora = fechaCita,
                        Servicio = servicio,
                        Notas = notas?.Trim()
                    };

                    bool citaGuardada = _citaController.CrearCita(nuevaCita);
                    if (!citaGuardada)
                        throw new Exception("Error al guardar la cita.");

                    // Confirmar la transacción
                    transaction.Complete();

                    MessageBox.Show("¡Mascota y cita guardadas correctamente!",
                                    "Éxito",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);

                    return true; 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error: {ex.Message}",
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return false;
            }
        }

        public void ResetData()
        {
            _userDash.txtNombre.Clear();
            _userDash.txtRaza.Clear();
            _userDash.txtNotas.Clear();
            _userDash.cmbEspecie.SelectedIndex = -1;
            _userDash.numEdad.Value = _userDash.numEdad.Minimum;
            _userDash.numPeso.Value = _userDash.numPeso.Minimum;
            _userDash.Img1.Image = null;
            _userDash.Img2.Image = null;
            _userDash.Img3.Image = null;
            _userDash.Img4.Image = null;
            _userDash.panImg1.Visible = true;
            _userDash.closImg1.Visible = false;
            _userDash.panImg2.Visible = true;
            _userDash.closImg2.Visible = false;
            _userDash.panImg3.Visible = true;
            _userDash.closImg3.Visible = false;
            _userDash.panImg4.Visible = true;
            _userDash.closImg4.Visible = false;

            // Limpiar datos de cita
            _userDash.cmbServicio.SelectedIndex = -1;
            _userDash.dtpFechaHora.Value = DateTime.Now;
        }

        public Image CargarImagenDesdeRuta(List<string> rutas, int index)
        {
            if (index >= 0 && index < rutas.Count)
            {
                string ruta = rutas[index];
                if (File.Exists(ruta))
                {
                    return Image.FromFile(ruta);
                }
            }
            return null; 
        }

        public List<string> ObtenerRutasDeImagenes(int idMascota)
        {
            var imagenes = _mascotasRepository.ObtenerImagenesPorIdMascota(idMascota);
            var rutasImagenes = new List<string>();

            if (imagenes != null && imagenes.Count > 0)
            {
                foreach (var imagen in imagenes)
                {
                    // Agregamos cada imagen si existe.
                    if (!string.IsNullOrEmpty(imagen.PetImg1))
                        rutasImagenes.Add(imagen.PetImg1);

                    if (!string.IsNullOrEmpty(imagen.PetImg2))
                        rutasImagenes.Add(imagen.PetImg2);

                    if (!string.IsNullOrEmpty(imagen.PetImg3))
                        rutasImagenes.Add(imagen.PetImg3);

                    if (!string.IsNullOrEmpty(imagen.PetImg4))
                        rutasImagenes.Add(imagen.PetImg4);
                }
            }

            return rutasImagenes;
        }


        public void GenerateDynamicPostControl()
        {
            _userDash.flowLayoutPanel1.Controls.Clear();

            List<Mascota> mascotas;

            if (usuarioLoggedIn.Administrador)
            {
                mascotas = GetMascotasWithImages();
            }
            else
            {
                mascotas = GetMascotasByUserId(usuarioLoggedIn.Id);
            }

            if (mascotas != null && mascotas.Count > 0)
            {
                foreach (Mascota mascota in mascotas)
                {

                    PetUserControl petControl = new PetUserControl(_userDash,this  )
                    {
                        MascotaId = mascota.IdMascota,
                        PetName = mascota.Nombre ?? "Sin nombre",
                        PetSpecies = mascota.Especie ?? "Especie desconocida",
                        PetBreed = !string.IsNullOrEmpty(mascota.Raza) ? mascota.Raza : "No especificada",
                        PetAge = mascota.Edad.HasValue ? $"{mascota.Edad.Value} años" : "Edad desconocida",
                        PetWeight = mascota.Peso.HasValue ? $"{mascota.Peso.Value:0.00} kg" : "Peso desconocido",
                        PetNotes = mascota.Notas ?? "Sin notas"
                    };

                    // Obtener las rutas de las imágenes asociadas a la mascota
                    List<string> imagenesRutas = ObtenerRutasDeImagenes(mascota.IdMascota);
                    if (imagenesRutas != null && imagenesRutas.Count > 0)
                    {
                        petControl.Icon1 = CargarImagenDesdeRuta(imagenesRutas, 0);
                        petControl.Icon2 = CargarImagenDesdeRuta(imagenesRutas, 1);
                        petControl.Icon3 = CargarImagenDesdeRuta(imagenesRutas, 2);
                        petControl.Icon4 = CargarImagenDesdeRuta(imagenesRutas, 3);
                    }

                    // Agregar el evento para "Más información"
                    petControl.OnSelect += new EventHandler(DetailsControl_Click);

                    // Agregar el control dinámico al contenedor
                    _userDash.flowLayoutPanel1.Controls.Add(petControl);
                }
            }
            else
            {
                Console.WriteLine("No hay mascotas disponibles para mostrar.");
            }
        }

    }
}
