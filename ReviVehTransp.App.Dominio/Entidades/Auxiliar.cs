using System;

namespace ReviVehTransp.App.Dominio
{
    public class Auxiliar : Persona
    {
        public int Id { get; set; }
        public Rol Rol { get; set; }
        public string NumeroDocumento { get; set; }

    }
}