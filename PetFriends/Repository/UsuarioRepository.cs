using MySql.Data.MySqlClient;
using PetFriends.Models;
using System;
using System.Collections.Generic;
using System.Configuration;

using System.Windows.Forms;
using System.Data;


namespace PetFriends.Repository
{
    public class UsuarioRepository
    {
        public List<Usuario> ObtenerTodos()
        {
            List<Usuario> usuarios = new List<Usuario>();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlDB"].ConnectionString))
                {
                    conn.Open();
                    string query = "CALL sp_obtener_todos_usuarios()";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                usuarios.Add(new Usuario
                                {
                                    Id = reader.GetInt32("id"),
                                    NombreCompleto = reader.GetString("nombre_completo"),
                                    Contraseña = reader.GetString("contraseña"),
                                    Administrador = reader.GetBoolean("administrador"),
                                    Telefono = reader.GetString("telefono"),
                                    Email = reader.GetString("email"),
                                    Imagen = reader.IsDBNull(reader.GetOrdinal("imagen")) ? null : reader.GetString("imagen")
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            return usuarios;
        }

        public Usuario ObtenerUsuarioPorEmailYContraseña(string email, string contraseña)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlDB"].ConnectionString))
                {
                    conn.Open();
                    string query = "CALL sp_obtener_usuario_por_email_contraseña(@Email, @Contraseña)";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@Contraseña", contraseña);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new Usuario
                                {
                                    Id = reader.GetInt32("id"),
                                    NombreCompleto = reader.GetString("nombre_completo"),
                                    Contraseña = reader.GetString("contraseña"),
                                    Administrador = reader.GetBoolean("administrador"),
                                    Telefono = reader.GetString("telefono"),
                                    Email = reader.GetString("email"),
                                    Imagen = reader.IsDBNull(reader.GetOrdinal("imagen")) ? null : reader.GetString("imagen")

                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            return null;
        }

        public bool GuardarUsuario(string nombreCompleto, string contraseña, bool administrador, string telefono, string email)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlDB"].ConnectionString))
                {
                    conn.Open();
                    string query = "CALL sp_guardar_usuario(@NombreCompleto, @Contraseña, @Administrador, @Telefono, @Email)";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@NombreCompleto", nombreCompleto);
                        cmd.Parameters.AddWithValue("@Contraseña", contraseña);
                        cmd.Parameters.AddWithValue("@Administrador", administrador);
                        cmd.Parameters.AddWithValue("@Telefono", telefono);
                        cmd.Parameters.AddWithValue("@Email", email);

                        int result = cmd.ExecuteNonQuery();
                        return result > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return false;
            }
        }

        public bool UsuarioExiste(string email)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlDB"].ConnectionString))
                {
                    conn.Open();
                    string query = "CALL sp_verificar_usuario_existe(@Email)";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Email", email);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return reader.GetInt32("total") > 0;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            return false;
        }


        // ------------------------ Tabla Usuarios ------------------------

        public DataTable GetUserByEmail(string email)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlDB"].ConnectionString))
                {
                    conn.Open();
                    string query = "SELECT * FROM Usuarios WHERE email = @Email";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Email", email);

                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            return dt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener los datos del usuario: " + ex.Message);
                return null;
            }
        }

        public void UpdateUserProfileImage(string email, string imagePath)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlDB"].ConnectionString))
                {
                    conn.Open();
                    string query = "UPDATE Usuarios SET imagen = @Image WHERE email = @Email";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Image", imagePath);
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar la imagen del perfil: " + ex.Message);
            }
        }


        public bool EliminarUsuario(int idUsuario)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlDB"].ConnectionString))
                {
                    conn.Open();

                    using (MySqlCommand cmd = new MySqlCommand("EliminarUsuario", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@idUsuario", idUsuario);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string mensaje = reader.GetString("mensaje");
                                MessageBox.Show(mensaje);

                                return mensaje == "Usuario eliminado correctamente";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar el usuario: " + ex.Message);
                return false; 
            }

            return false; 
        }


        //Aqui estoy utilizando una stored function 
        public decimal CalcularIngresoTotalEmpleado(int idEmpleado)
        {
            using (var conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlDB"].ConnectionString))
            {
                conn.Open();

                string query = "SELECT calcularIngresoTotal(@idEmpleado);";

                using (var command = new MySqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@idEmpleado", idEmpleado);

                    var result = command.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        return Convert.ToDecimal(result);
                    }

                    return 0m;
                }
            }
        }
    }
}
