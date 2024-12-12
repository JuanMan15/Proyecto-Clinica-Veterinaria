using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System;
using System.Data;

namespace PetFriends.Repository
{
    public class MascotasRepository
    {
        // Obtener todas las mascotas (View)
        public List<Mascota> ObtenerTodas()
        {
            List<Mascota> mascotas = new List<Mascota>();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlDB"].ConnectionString))
                {
                    conn.Open();
                    string query = "SELECT * FROM v_mascotas"; 
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Mascota mascota = new Mascota
                                {
                                    IdMascota = reader.GetInt32("id_mascota"),
                                    IdEmpleado = reader.GetInt32("id_empleado"),
                                    Nombre = reader.GetString("nombre"),
                                    Especie = reader.GetString("especie"),
                                    Raza = reader.IsDBNull(reader.GetOrdinal("raza")) ? null : reader.GetString("raza"),
                                    Edad = reader.IsDBNull(reader.GetOrdinal("edad")) ? (int?)null : reader.GetInt32("edad"),
                                    Peso = reader.IsDBNull(reader.GetOrdinal("peso")) ? (decimal?)null : reader.GetDecimal("peso"),
                                    Notas = reader.IsDBNull(reader.GetOrdinal("notas")) ? null : reader.GetString("notas")
                                };
                                mascotas.Add(mascota);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return mascotas;
        }

        // Obtener mascota por ID (View)
        public Mascota ObtenerPorId(int idMascota)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlDB"].ConnectionString))
                {
                    conn.Open();
                    string query = "SELECT * FROM v_mascotas WHERE id_mascota = @IdMascota"; 
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@IdMascota", idMascota);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new Mascota
                                {
                                    IdMascota = reader.GetInt32("id_mascota"),
                                    IdEmpleado = reader.GetInt32("id_empleado"),
                                    Nombre = reader.GetString("nombre"),
                                    Especie = reader.GetString("especie"),
                                    Raza = reader.IsDBNull(reader.GetOrdinal("raza")) ? null : reader.GetString("raza"),
                                    Edad = reader.IsDBNull(reader.GetOrdinal("edad")) ? (int?)null : reader.GetInt32("edad"),
                                    Peso = reader.IsDBNull(reader.GetOrdinal("peso")) ? (decimal?)null : reader.GetDecimal("peso"),
                                    Notas = reader.IsDBNull(reader.GetOrdinal("notas")) ? null : reader.GetString("notas")
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return null;
        }

        // Guardar una nueva mascota (Stored Procedure)
        public bool GuardarMascota(Mascota mascota)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlDB"].ConnectionString))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand("sp_guardar_mascota", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("p_id_empleado", mascota.IdEmpleado);
                        cmd.Parameters.AddWithValue("p_nombre", mascota.Nombre);
                        cmd.Parameters.AddWithValue("p_especie", mascota.Especie);
                        cmd.Parameters.AddWithValue("p_raza", (object)mascota.Raza ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("p_edad", (object)mascota.Edad ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("p_peso", (object)mascota.Peso ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("p_notas", (object)mascota.Notas ?? DBNull.Value);

                        int result = cmd.ExecuteNonQuery();

                        if (result > 0)
                        {
                            string lastInsertedIdQuery = "SELECT LAST_INSERT_ID()";
                            using (MySqlCommand lastIdCmd = new MySqlCommand(lastInsertedIdQuery, conn))
                            {
                                mascota.IdMascota = Convert.ToInt32(lastIdCmd.ExecuteScalar());
                            }
                            return true;
                        }
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
        }

        // Actualizar una mascota existente (Stored Procedure)
        public bool ActualizarMascota(Mascota mascota)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlDB"].ConnectionString))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand("sp_actualizar_mascota", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("p_id_mascota", mascota.IdMascota);
                        cmd.Parameters.AddWithValue("p_nombre", mascota.Nombre);
                        cmd.Parameters.AddWithValue("p_especie", mascota.Especie);
                        cmd.Parameters.AddWithValue("p_raza", (object)mascota.Raza ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("p_edad", (object)mascota.Edad ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("p_peso", (object)mascota.Peso ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("p_notas", (object)mascota.Notas ?? DBNull.Value);

                        int result = cmd.ExecuteNonQuery();
                        return result > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
        }


        public bool EliminarMascota(int idMascota)
        {
            try
            {
                string query = "DELETE FROM Mascotas WHERE id_mascota = @idMascota";

                using (MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlDB"].ConnectionString))
                {
                    conn.Open();
                    using (var command = new MySqlCommand(query, conn))
                    {
                        command.Parameters.AddWithValue("@idMascota", idMascota);
                        int rowsAffected = command.ExecuteNonQuery();
                        return rowsAffected > 0; 
                    }
                }
            }
            catch (MySqlException sqlEx)
            {
                Console.WriteLine($"Error al eliminar la mascota: {sqlEx.Message}");
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error general al eliminar la mascota: {ex.Message}");
                return false;
            }
        }


        public bool EliminarImagenesPorMascota(int idMascota)
        {
            try
            {
                string query = "DELETE FROM MascotasImagenes WHERE id_mascota = @idMascota";

                using (var conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlDB"].ConnectionString))
                {
                    conn.Open();
                    using (var command = new MySqlCommand(query, conn))
                    {
                        command.Parameters.AddWithValue("@idMascota", idMascota);
                        int rowsAffected = command.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al eliminar imágenes: {ex.Message}");
                return false;
            }
        }



        // Obtener las imágenes de una mascota por ID (View)
        public List<MascotaImagen> ObtenerImagenesPorIdMascota(int idMascota)
        {
            var imagenes = new List<MascotaImagen>();
            try
            {
                using (var conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlDB"].ConnectionString))
                {
                    conn.Open();
                    string query = "SELECT * FROM v_mascotas_imagenes WHERE id_mascota = @IdMascota";
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@IdMascota", idMascota);
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var imagen = new MascotaImagen
                                {
                                    IdImagen = reader.GetInt32("id_imagen"),
                                    IdMascota = reader.GetInt32("id_mascota"),
                                    PetImg1 = reader.IsDBNull(reader.GetOrdinal("pet_img1")) ? null : reader.GetString("pet_img1"),
                                    PetImg2 = reader.IsDBNull(reader.GetOrdinal("pet_img2")) ? null : reader.GetString("pet_img2"),
                                    PetImg3 = reader.IsDBNull(reader.GetOrdinal("pet_img3")) ? null : reader.GetString("pet_img3"),
                                    PetImg4 = reader.IsDBNull(reader.GetOrdinal("pet_img4")) ? null : reader.GetString("pet_img4")
                                };
                                imagenes.Add(imagen);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener las imágenes: {ex.Message}");
            }
            return imagenes;
        }

        public List<Mascota> GetMascotasByUserId(int userId)
        {
            var mascotas = new List<Mascota>();

            try
            {
                using (MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlDB"].ConnectionString))
                {
                    conn.Open();
                    // Consulta SQL para obtener las mascotas del usuario
                    string query = "SELECT id_mascota, nombre, especie, raza, edad, peso, notas " +
                                   "FROM Mascotas WHERE id_empleado = @userId";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@userId", userId);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var mascota = new Mascota
                                {
                                    IdMascota = reader.GetInt32("id_mascota"),
                                    Nombre = reader.GetString("nombre"),
                                    Especie = reader.GetString("especie"),
                                    Raza = reader.IsDBNull(reader.GetOrdinal("raza")) ? null : reader.GetString("raza"),
                                    Edad = reader.IsDBNull(reader.GetOrdinal("edad")) ? (int?)null : reader.GetInt32("edad"),
                                    Peso = reader.IsDBNull(reader.GetOrdinal("peso")) ? (decimal?)null : reader.GetDecimal("peso"),
                                    Notas = reader.IsDBNull(reader.GetOrdinal("notas")) ? null : reader.GetString("notas")
                                };

                                mascotas.Add(mascota);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener las mascotas: " + ex.Message);
            }

            return mascotas;
        }

        // Guardar las imágenes de una mascota (Stored Procedure)
        public bool GuardarImagen(MascotaImagen imagen)
        {
            try
            {
                using (var conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlDB"].ConnectionString))
                {
                    conn.Open();
                    using (var cmd = new MySqlCommand("sp_guardar_imagen", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("p_id_mascota", imagen.IdMascota);
                        cmd.Parameters.AddWithValue("p_pet_img1", imagen.PetImg1 ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("p_pet_img2", imagen.PetImg2 ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("p_pet_img3", imagen.PetImg3 ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("p_pet_img4", imagen.PetImg4 ?? (object)DBNull.Value);

                        int result = cmd.ExecuteNonQuery();
                        return result > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al guardar imágenes: {ex.Message}");
                return false;
            }
        }

        public Mascota GetMascotaDetails(int mascotaId)
        {
            Mascota mascota = null;

            try
            {
                using (MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlDB"].ConnectionString))
                {
                    conn.Open();

                    string query = "SELECT * FROM VistaMascotasConUsuarios WHERE id_mascota = @mascotaId";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@mascotaId", mascotaId);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                mascota = new Mascota
                                {
                                    IdMascota = reader.GetInt32("id_mascota"),
                                    Nombre = reader.GetString("nombre"),
                                    Especie = reader.GetString("especie"),
                                    Raza = reader.IsDBNull(reader.GetOrdinal("raza")) ? null : reader.GetString("raza"),
                                    Edad = reader.IsDBNull(reader.GetOrdinal("edad")) ? (int?)null : reader.GetInt32("edad"),
                                    Peso = reader.IsDBNull(reader.GetOrdinal("peso")) ? (decimal?)null : reader.GetDecimal("peso"),
                                    Notas = reader.IsDBNull(reader.GetOrdinal("notas")) ? null : reader.GetString("notas"),
                                    NombreEmpleado = reader.GetString("nombre_empleado") // Nuevo campo
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener los detalles de la mascota: " + ex.Message);
            }

            return mascota;
        }


    }
}
