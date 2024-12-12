


public class Producto
{
    public int IdProducto { get; set; }
    public string Nombre { get; set; }
    public string Descripcion { get; set; }
    public decimal Precio { get; set; }
    public int Cantidad { get; set; }
    public string Imagen { get; set; }
    public string Categoria { get; set; }

    public Producto(int idProducto, string nombre, string descripcion, decimal precio, int cantidad, string imagen, string categoria)
    {
        IdProducto = idProducto;
        Nombre = nombre;
        Descripcion = descripcion;
        Precio = precio;
        Cantidad = cantidad;
        Imagen = imagen;
        Categoria = categoria;
    }

    public Producto() { }
}