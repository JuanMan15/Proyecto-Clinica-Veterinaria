using PetFriends.Models;
using System;
using System.Collections.Generic;


public class Venta
{
    public int IdVenta { get; set; }
    public int IdEmpleado { get; set; }
    public DateTime Fecha { get; set; }
    public decimal Total { get; set; }

    public string NombreEmpleado { get; set; }
    public List<ProductoVenta> Productos { get; set; }

    public Venta(int idVenta, int idEmpleado, DateTime fecha, decimal total)
    {
        IdVenta = idVenta;
        IdEmpleado = idEmpleado;
        Fecha = fecha;
        Total = total;
        Productos = new List<ProductoVenta>(); 
    }

    public Venta()
    {
        Productos = new List<ProductoVenta>(); 
    }
}