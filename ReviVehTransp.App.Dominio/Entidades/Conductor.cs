using System;

namespace ReviVehTransp.App.Dominio
{
    public class Conductor : Persona
    {
        public int Id { get; set; }    
        public string TipoLicencia { get; set; }
        public string Direccion { get; set; }
        public string NumeroTelefono { get; set; }
        public string NumeroDocumento { get; set; }
         
    }
}