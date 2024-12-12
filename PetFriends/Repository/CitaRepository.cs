using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;

using System.Configuration;
using System.Data;
namespace PetFriends.Repository
{
    public class CitaRepository
    {
        private readonly string connectionString;

        public CitaRepository()
        {
            connectionString = ConfigurationManager.ConnectionStrings["MySqlDB"].ConnectionString;
        }

        public bool GuardarCita(Cita cita)
        {
            using (var connection = new MySqlConnection(connectionString))
            using (var command = new MySqlCommand("GuardarCita", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("p_id_empleado", cita.IdEmpleado);  
                command.Parameters.AddWithValue("p_id_mascota", cita.IdMascota);
                command.Parameters.AddWithValue("p_fecha_hora", cita.FechaHora);
                command.Parameters.AddWithValue("p_servicio", cita.Servicio);
                command.Parameters.AddWithValue("p_notas", cita.Notas ?? (object)DBNull.Value);

                connection.Open();
                return command.ExecuteNonQuery() > 0;
            }
        }

        // Método para obtener citas
        public List<Cita> ObtenerCitas(int idEmpleado, int? idMascota = null)
        {
            var citas = new List<Cita>();

            using (var connection = new MySqlConnection(connectionString))
            using (var command = new MySqlCommand("ObtenerCitas", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("p_id_empleado", idEmpleado);  // Cambié a id_empleado
                command.Parameters.AddWithValue("p_id_mascota", idMascota.HasValue ? (object)idMascota.Value : DBNull.Value);

                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        citas.Add(new Cita
                        {
                            IdCita = reader.GetInt32("id_cita"),
                            IdEmpleado = reader.GetInt32("id_empleado"),  
                            IdMascota = reader.GetInt32("id_mascota"),
                            FechaHora = reader.GetDateTime("fecha_hora"),
                            Servicio = reader.GetString("servicio"),
                            Notas = reader.IsDBNull(reader.GetOrdinal("notas")) ? null : reader.GetString("notas")
                        });
                    }
                }
            }

            return citas;
        }

        // Método para eliminar una cita
        public bool EliminarCita(int idCita)
        {
            using (var connection = new MySqlConnection(connectionString))
            using (var command = new MySqlCommand("EliminarCita", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("p_id_cita", idCita);

                connection.Open();
                return command.ExecuteNonQuery() > 0;
            }
        }

        // Método para eliminar citas por mascota
        public bool EliminarCitasPorMascota(int idMascota)
        {
            try
            {
                string query = "DELETE FROM Citas WHERE id_mascota = @idMascota";

                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@idMascota", idMascota);
                        int rowsAffected = command.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (MySqlException sqlEx)
            {
                Console.WriteLine($"Error al eliminar las citas: {sqlEx.Message}");
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error general al eliminar citas: {ex.Message}");
                return false;
            }
        }

        // Método para obtener citas por mascota
        public List<Cita> ObtenerCitasPorMascota(int idMascota)
        {
            var citas = new List<Cita>();

            using (var connection = new MySqlConnection(connectionString))
            using (var command = new MySqlCommand("ObtenerCitasPorMascota", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("p_id_mascota", idMascota);

                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        citas.Add(new Cita
                        {
                            IdCita = reader.GetInt32("id_cita"),
                            IdEmpleado = reader.GetInt32("id_empleado"),  
                            IdMascota = reader.GetInt32("id_mascota"),
                            FechaHora = reader.GetDateTime("fecha_hora"),
                            Servicio = reader.GetString("servicio"),
                            Notas = reader.IsDBNull(reader.GetOrdinal("notas")) ? null : reader.GetString("notas")
                        });
                    }
                }
            }

            return citas;
        }
    }
}
