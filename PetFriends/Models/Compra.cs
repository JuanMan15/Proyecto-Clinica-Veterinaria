

using System;

public class Compra
{
    public int IdCompra { get; set; }
    public int IdCliente { get; set; }
    public DateTime Fecha { get; set; }
    public int IdProducto { get; set; }
    public int Cantidad { get; set; }
    public decimal PrecioUnitario { get; set; }
    public decimal Total { get; set; }

    public Compra(int idCompra, int idCliente, DateTime fecha, int idProducto, int cantidad, decimal precioUnitario, decimal total)
    {
        IdCompra = idCompra;
        IdCliente = idCliente;
        Fecha = fecha;
        IdProducto = idProducto;
        Cantidad = cantidad;
        PrecioUnitario = precioUnitario;
        Total = total;
    }

    public Compra() { }
}