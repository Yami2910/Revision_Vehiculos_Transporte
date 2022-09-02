using System;

namespace ReviVehTransp.App.Dominio
{
    public class MecanicoVehiculo
    {
        
        public int VehiculoId { get; set; }
        public Vehiculo Vehiculo { get; set; }


        public int MecanicoId { get; set; }
        public Mecanico Mecanico { get; set; }
        
    }
}