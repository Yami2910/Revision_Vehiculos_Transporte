using System;

namespace ReviVehTransp.App.Dominio
{
    public class ConductorVehiculo
    {
        public DateTime FechaAsignacion { get; set; }

        public Vehiculo Vehiculo { get; set; }
        public int VehiculoId { get; set; }

        public int ConductorId { get; set; }//LLaves foaneas
        public Conductor Conductor { get; set; }
        
    }
}