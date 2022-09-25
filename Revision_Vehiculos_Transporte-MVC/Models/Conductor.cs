namespace Revision_Vehiculos_Transporte_MVC.Models
{
    public partial class Conductor
    {
        public Conductor()
        {
            Vehiculos = new HashSet<Vehiculo>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public string Direccion { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string NumeroTelefono { get; set; } = null!;
        public DateTime FechaNacimiento { get; set; }
        public string TipoLicencia { get; set; } = null!;
        public string NumeroDocumento { get; set; } = null!;

        public virtual ICollection<Vehiculo> Vehiculos { get; set; }
    }
}
