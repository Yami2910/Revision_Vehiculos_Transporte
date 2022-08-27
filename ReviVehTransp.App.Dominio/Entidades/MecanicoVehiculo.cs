using System;

namespace ReviVehTransp.App.Dominio
{
    public class MecanicoVehiculo
    {
        public int Id { get; set; }
        public Persona Mecanico { get; set; }
        public Vehiculo Vehiculo { get; set; }
    }
}