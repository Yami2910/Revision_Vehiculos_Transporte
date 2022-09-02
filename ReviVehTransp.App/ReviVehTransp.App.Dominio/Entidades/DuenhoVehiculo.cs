using System;

namespace ReviVehTransp.App.Dominio
{
    public class DuenhoVehiculo : Persona
    {
          
        public string CiudadResidencia { get; set; }
       public DateTime FechaComprador { get; set; }
       
        
        public List<PropietarioVehiculo> PropietarioVehiculos { get; set; }
        
    }
}