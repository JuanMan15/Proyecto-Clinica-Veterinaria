using System;

public class Cita
{
    public int IdCita { get; set; }
    public int IdEmpleado { get; set; }
    public int IdMascota { get; set; }
    public DateTime FechaHora { get; set; }
    public string Servicio { get; set; }
    public string Notas { get; set; }

    public Cita(int idCita, int idEmpleado, int idMascota, DateTime fechaHora, string servicio, string notas)
    {
        IdCita = idCita;
        IdEmpleado = idEmpleado;
        IdMascota = idMascota;
        FechaHora = fechaHora;
        Servicio = servicio;
        Notas = notas;
    }

    public Cita() { }
}