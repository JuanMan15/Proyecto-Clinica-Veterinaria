namespace PetFriends.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string NombreCompleto { get; set; }
        public string Contraseña { get; set; }
        public bool Administrador { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Imagen { get; set; } 

        public Usuario(int id, string nombreCompleto, string contraseña, bool administrador, string telefono, string email, string imagen)
        {
            Id = id;
            NombreCompleto = nombreCompleto;
            Contraseña = contraseña;
            Administrador = administrador;
            Telefono = telefono;
            Email = email;
            Imagen = imagen;  
        }

        public Usuario() { }
    }
}
