using MySql.Data.MySqlClient;
using PetFriends.Models;
using System;
using System.Collections.Generic;
using System.Configuration;


namespace PetFriends.Repository
{
    internal class VentasRepository
    {
        public Venta RegistrarVenta(int idEmpleado, List<ProductoVenta> productos)
        {
            using (var conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlDB"].ConnectionString))
            {
                conn.Open();

                using (var transaction = conn.BeginTransaction())
                {
                    try
                    {
                        decimal total = 0;

                        foreach (var producto in productos)
                        {
                            string queryPrecio = "SELECT precio FROM Productos WHERE id_producto = @idProducto;";
                            using (var commandPrecio = new MySqlCommand(queryPrecio, conn, transaction))
                            {
                                commandPrecio.Parameters.AddWithValue("@idProducto", producto.ProductId);
                                var precio = commandPrecio.ExecuteScalar();

                                if (precio == null)
                                {
                                    throw new Exception($"Producto con ID {producto.ProductId} no encontrado en la base de datos.");
                                }

                                total += Convert.ToDecimal(precio) * producto.Quantity;
                            }
                        }

                        // Insertar la venta y obtener el ID generado
                        int idVenta = 0;
                        using (var commandVenta = new MySqlCommand("CALL RegistrarVenta(@idEmpleado, @total);", conn, transaction))
                        {
                            commandVenta.Parameters.AddWithValue("@idEmpleado", idEmpleado);
                            commandVenta.Parameters.AddWithValue("@total", total);

                            using (var reader = commandVenta.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    idVenta = reader.GetInt32("idVenta");
                                }
                            }

                            if (idVenta == 0)
                            {
                                throw new Exception("No se pudo registrar la venta. ID de venta no generado.");
                            }
                        }

                        // Registrar los detalles de la venta
                        foreach (var producto in productos)
                        {
                            string queryNombre = "SELECT nombre FROM Productos WHERE id_producto = @idProducto;";
                            string nombreProducto = "";
                            using (var commandNombre = new MySqlCommand(queryNombre, conn, transaction))
                            {
                                commandNombre.Parameters.AddWithValue("@idProducto", producto.ProductId);
                                nombreProducto = commandNombre.ExecuteScalar()?.ToString() ?? "Desconocido";
                            }

                            using (var commandDetalle = new MySqlCommand("CALL RegistrarDetalleVenta(@idVenta, @productId, @cantidad, @nombreProducto);", conn, transaction))
                            {
                                commandDetalle.Parameters.AddWithValue("@idVenta", idVenta);
                                commandDetalle.Parameters.AddWithValue("@productId", producto.ProductId);
                                commandDetalle.Parameters.AddWithValue("@cantidad", producto.Quantity);
                                commandDetalle.Parameters.AddWithValue("@nombreProducto", nombreProducto); 
                                commandDetalle.ExecuteNonQuery();
                            }
                        }

                        transaction.Commit();

                        return new Venta
                        {
                            IdVenta = idVenta,
                            IdEmpleado = idEmpleado,
                            Fecha = DateTime.Now,
                            Total = total
                        };
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw new Exception($"Error al registrar la venta: {ex.Message}", ex);
                    }
                }
            }
        }

        // utilizando una view
        public List<Venta> ObtenerVentasConProductosYPrecios()
        {
            List<Venta> ventas = new List<Venta>();

            using (var conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlDB"].ConnectionString))
            {
                conn.Open();

                string queryVentas = "SELECT id_venta, id_empleado, total, fecha, nombre_completo FROM VistaVentas;";

                using (var commandVentas = new MySqlCommand(queryVentas, conn))
                {
                    using (var readerVentas = commandVentas.ExecuteReader())
                    {
                        while (readerVentas.Read())
                        {
                            var venta = new Venta
                            {
                                IdVenta = readerVentas.GetInt32("id_venta"),
                                IdEmpleado = readerVentas.GetInt32("id_empleado"),
                                Total = readerVentas.GetDecimal("total"),
                                Fecha = readerVentas.GetDateTime("fecha"),
                                NombreEmpleado = readerVentas.GetString("nombre_completo")
                            };

                            ventas.Add(venta);
                        }
                    }
                }

                // Obtener los productos y precios de cada venta
                foreach (var venta in ventas)
                {
                    string queryProductos = "SELECT id_producto, cantidad, nombre_producto, precio FROM VistaProductosPorVenta WHERE id_venta = @idVenta;";

                    using (var commandProductos = new MySqlCommand(queryProductos, conn))
                    {
                        commandProductos.Parameters.AddWithValue("@idVenta", venta.IdVenta);

                        using (var readerProductos = commandProductos.ExecuteReader())
                        {
                            while (readerProductos.Read())
                            {
                                var productoVenta = new ProductoVenta
                                {
                                    ProductId = readerProductos.GetInt32("id_producto"),
                                    NombreProducto = readerProductos.GetString("nombre_producto"),
                                    Quantity = readerProductos.GetInt32("cantidad"),
                                    Precio = readerProductos.GetDecimal("precio")
                                };

                                venta.Productos.Add(productoVenta);
                            }
                        }
                    }
                }
            }

            return ventas;
        }

    }
}
