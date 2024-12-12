using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class MascotaImagen
{
    public int IdImagen { get; set; }
    public int IdMascota { get; set; }
    public string PetImg1 { get; set; }
    public string PetImg2 { get; set; }
    public string PetImg3 { get; set; }
    public string PetImg4 { get; set; }

    public MascotaImagen() { }

    public MascotaImagen(int idImagen, int idMascota, string petImg1, string petImg2, string petImg3, string petImg4)
    {
        IdImagen = idImagen;
        IdMascota = idMascota;
        PetImg1 = petImg1;
        PetImg2 = petImg2;
        PetImg3 = petImg3;
        PetImg4 = petImg4;
    }
}
