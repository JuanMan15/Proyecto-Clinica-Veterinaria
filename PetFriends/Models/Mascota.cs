using PetFriends.Models;
using System.Collections.Generic;

public class Mascota
{
    public int IdMascota { get; set; }
    public int IdEmpleado { get; set; }
    public string NombreEmpleado { get; set; }
    public string Nombre { get; set; }
    public string Especie { get; set; }
    public string Raza { get; set; }
    public int? Edad { get; set; }
    public decimal? Peso { get; set; }
    public string Notas { get; set; }

    public List<MascotaImagen> Imagenes { get; set; }

    public Mascota()
    {
        Imagenes = new List<MascotaImagen>();
    }
}
