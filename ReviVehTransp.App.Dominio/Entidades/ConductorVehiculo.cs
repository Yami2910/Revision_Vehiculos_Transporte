using System;

namespace ReviVehTransp.App.Dominio
{
    public class ConductorVehiculo
    {
        public int Id { get; set; }
        public Persona Conductor { get; set; }
        public Vehiculo Vehiculo { get; set; }
    }
}