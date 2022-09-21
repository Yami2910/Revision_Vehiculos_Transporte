using System;
using System.Collections.Generic;

namespace Revision_Vehiculos_Transporte_MVC.Models
{
    public partial class Vehiculo
    {
        public Vehiculo()
        {
            MecanicoVehiculos = new HashSet<MecanicoVehiculo>();
        }

        public int Id { get; set; }
        public string Placa { get; set; } = null!;
        public string Tipo { get; set; } = null!;
        public string Marca { get; set; } = null!;
        public int? Modelo { get; set; }
        public int? CapacidadPasajeros { get; set; }
        public int? CilindrajeMotor { get; set; }
        public string PaisOrigen { get; set; } = null!;
        public string DescripcionGeneral { get; set; } = null!;
        public string OtrasCaracteristicas { get; set; } = null!;
        public int IdDuenoVehiculo { get; set; }
        public int IdConductor { get; set; }

        public virtual Conductor IdConductorNavigation { get; set; } = null!;
        public virtual DuenoVehiculo IdDuenoVehiculoNavigation { get; set; } = null!;
        public virtual ICollection<MecanicoVehiculo> MecanicoVehiculos { get; set; }
    }
}
