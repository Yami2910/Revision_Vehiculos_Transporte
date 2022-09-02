using System;

namespace ReviVehTransp.App.Dominio
{
    public class Conductor : Persona
    {
        
        public string TipoLicencia { get; set; }
        public string Direccion { get; set; }
        public string NumeroTelefono { get; set; }
         
        public List<ConductorVehiculo> ConductorVehiculos { get; set; }
         
    }
}