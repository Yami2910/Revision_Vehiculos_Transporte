using System;

namespace ReviVehTransp.App.Dominio
{
    public class Mecanico : Persona
    {
         
        public string Direccion { get; set; }
        public string NivelEstudio { get; set; } 
        public List<MecanicoVehiculo> MecanicoVehiculos { get; set; }
        
    }
}