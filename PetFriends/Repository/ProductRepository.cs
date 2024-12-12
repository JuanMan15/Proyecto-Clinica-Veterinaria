using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PetFriends.Repository
{
    public class ProductRepository
    {
        private readonly string connectionString;

        public ProductRepository()
        {
            connectionString = ConfigurationManager.ConnectionStrings["MySqlDB"].ConnectionString;
        }

        // Obtener Producto por ID
        public Producto ObtenerProductoPorID(int idProducto)
        {
            Producto producto = null;
            using (var connection = new MySqlConnection(connectionString))
            using (var command = new MySqlCommand("ObtenerProductoPorID", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("p_id_producto", idProducto);

                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        producto = new Producto
                        {
                            IdProducto = reader.GetInt32("id_producto"),
                            Nombre = reader.GetString("nombre"),
                            Descripcion = reader.GetString("descripcion"),
                            Precio = reader.GetDecimal("precio"),
                            Cantidad = reader.GetInt32("cantidad"),
                            Imagen = reader.GetString("imagen"),
                            Categoria = reader.GetString("categoria")
                        };
                    }
                }
            }

            return producto;
        }

        // Obtener todos los productos
        public List<Producto> ObtenerProductos()
        {
            var productos = new List<Producto>();

            try
            {
                using (var connection = new MySqlConnection(connectionString))
                using (var command = new MySqlCommand("SELECT * FROM productos_view", connection))
                {
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            productos.Add(new Producto
                            {
                                IdProducto = reader.GetInt32("id_producto"),
                                Nombre = reader.GetString("nombre"),
                                Descripcion = reader.GetString("descripcion"),
                                Precio = reader.GetDecimal("precio"),
                                Cantidad = reader.GetInt32("cantidad"),
                                Imagen = reader.GetString("imagen"),
                                Categoria = reader.GetString("categoria")
                            });
                        }
                    }
                }
            }
            catch (MySqlException)
            {
                return null;  
            }

            return productos;
        }

        // Guardar un producto
        public bool GuardarProducto(Producto producto)
        {
            try
            {
                using (var connection = new MySqlConnection(connectionString))
                using (var command = new MySqlCommand("GuardarProducto", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("p_nombre", producto.Nombre);
                    command.Parameters.AddWithValue("p_descripcion", producto.Descripcion);
                    command.Parameters.AddWithValue("p_precio", producto.Precio);
                    command.Parameters.AddWithValue("p_cantidad", producto.Cantidad);
                    command.Parameters.AddWithValue("p_imagen", producto.Imagen);
                    command.Parameters.AddWithValue("p_categoria", producto.Categoria);

                    connection.Open();
                    command.ExecuteNonQuery();
                }

                return true; 
            }
            catch (Exception)
            {
                return false; 
            }
        }


        // Eliminar un producto
        public bool EliminarProducto(int idProducto)
        {
            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    // Crear el comando para el procedimiento almacenado
                    using (var command = new MySqlCommand("EliminarProducto", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("p_id_producto", idProducto);

                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }

                return true; 
            }
            catch (MySqlException ex) when (ex.Number == 1644) 
            {
                Console.WriteLine($"Error: {ex.Message}");
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error general al eliminar el producto: {ex.Message}");
                return false;
            }
        }


        public bool ActualizarCantidad(int idProducto, int nuevaCantidad)
        {
            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "UPDATE Productos SET cantidad = @nuevaCantidad WHERE id_producto = @idProducto";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@nuevaCantidad", nuevaCantidad);
                    cmd.Parameters.AddWithValue("@idProducto", idProducto);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al actualizar la cantidad: {ex.Message}");
                return false;
            }
        }


        public decimal CalcularTotalVentas(int productId)
        {
            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    // Prepara el comando para ejecutar la función
                    using (var command = new MySqlCommand("SELECT CalcularTotalVentas(@ProductId);", connection))
                    {
                        command.Parameters.AddWithValue("@ProductId", productId);

                        // Ejecuta el comando y obtiene el resultado
                        object result = command.ExecuteScalar();

                        if (result != null && decimal.TryParse(result.ToString(), out decimal totalVentas))
                        {
                            return totalVentas;
                        }
                        else
                        {
                            throw new Exception("El resultado de la función fue nulo o inválido.");
                        }
                    }
                }
            }
            catch (MySqlException sqlEx)
            {
                throw new Exception($"Error de base de datos: {sqlEx.Message}", sqlEx);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error inesperado al calcular el total de ventas: {ex.Message}", ex);
            }
        }




    }
}
