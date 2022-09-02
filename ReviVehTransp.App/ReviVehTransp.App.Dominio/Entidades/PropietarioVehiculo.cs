using System;

namespace ReviVehTransp.App.Dominio
{
    public class PropietarioVehiculo
    {
        public int IdVehiculo   { get; set; }
        public Vehiculo Vehiculo { get; set; }

        public int IdDuenhoVehiculo { get; set; }
        public DuenhoVehiculo DuenhoVehiculo { get; set; }
    }
}