using System;

namespace ReviVehTransp.App.Dominio
{
    public class Mecanico : Persona
    {
        public int Id { get; set; }
        public string Direccion { get; set; }
        public string NivelEstudio { get; set; } 
        public string NumeroDocumento { get; set; }
    }
}