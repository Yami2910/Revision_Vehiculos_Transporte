using System;

namespace ReviVehTransp.App.Dominio
{
    public class Vehiculo
    {
        public int Id { get; set; }
        public string Placa { get; set; }
        public string Tipo { get; set; }
        public string Marca { get; set; }
        public string ModeloAnio { get; set; }
        public string CapacidadPasajeros { get; set; }
        public string CilindrajeMotor { get; set; }
        public string PaisOrigen { get; set; }
        public string DescripcionGeneral { get; set; }
        public string OtrasCaracteristicas { get; set; }

        public PropietarioVehiculo PropietarioVehiculo { get; set; }

        public List<ConductorVehiculo> ConductorVehiculos { get; set; }

        public List<MecanicoVehiculo> MecanicoVehiculos { get; set; }

        
    }
}