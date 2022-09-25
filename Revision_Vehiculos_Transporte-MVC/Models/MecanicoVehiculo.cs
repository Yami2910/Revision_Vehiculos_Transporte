namespace Revision_Vehiculos_Transporte_MVC.Models
{
    public partial class MecanicoVehiculo
    {
        public int Id { get; set; }
        public int IdMecanico { get; set; }
        public int IdVehiculo { get; set; }

        public virtual Mecanico IdMecanicoNavigation { get; set; } = null!;
        public virtual Vehiculo IdVehiculoNavigation { get; set; } = null!;
    }
}
