namespace Revision_Vehiculos_Transporte_MVC.Models
{
    public partial class Mecanico
    {
        public Mecanico()
        {
            MecanicoVehiculos = new HashSet<MecanicoVehiculo>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public string Direccion { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string NumeroTelefono { get; set; } = null!;
        public DateTime FechaNacimiento { get; set; }
        public string NivelEstudios { get; set; } = null!;
        public string NumeroDocumento { get; set; } = null!;

        public virtual ICollection<MecanicoVehiculo> MecanicoVehiculos { get; set; }
    }
}
