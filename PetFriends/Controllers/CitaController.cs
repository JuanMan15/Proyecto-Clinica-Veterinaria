using PetFriends.Repository;
using System;
using System.Collections.Generic;


namespace PetFriends.Controllers
{
    public class CitaController
    {
        private readonly CitaRepository _repository;

        public CitaController()
        {
            _repository = new CitaRepository();
        }

        public bool CrearCita(Cita nuevaCita)
        {
            if (nuevaCita == null || string.IsNullOrEmpty(nuevaCita.Servicio))
            {
                throw new ArgumentException("Los datos de la cita son inválidos.");
            }

            return _repository.GuardarCita(nuevaCita);
        }

        public List<Cita> ObtenerCitas(int idCliente, int? idMascota = null)
        {
            return _repository.ObtenerCitas(idCliente, idMascota);
        }

        // Método para eliminar una cita
        public bool EliminarCita(int idCita)
        {
            return _repository.EliminarCita(idCita);
        }
    }

}
