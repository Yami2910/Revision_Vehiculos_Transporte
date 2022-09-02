using System;

namespace ReviVehTransp.App.Dominio
{
    public class Persona
    {
        public int Id { set; get;}
        
        public string Nombre { set; get; }
        public string Apellidos { set; get; }
        public string Direccion { set; get; }
        public string Email { set; get; }
        public string NumeroDocumento { get; set; }
        public string Telefono { set; get; }
        public DateTime FechaNacimiento { set; get; }

        
    }

}