using System;
using Microsoft.EntityFrameworkCore;
using ReviVehTransp.App.Dominio;

namespace ReviVehTransp.App.Persistencia
{
    public class AppContext : DbContext
    {
        public DbSet<Persona> Personas { get; set; }
        public DbSet<DuenhoVehiculo> DuenhoVehiculos { get; set; }
        public DbSet<Auxiliar> Auxiliares { get; set; }
        public DbSet<Conductor> Conductores { get; set; }
        public DbSet<Mecanico> Mecanicos { get; set; }
        public DbSet<Vehiculo> Vehiculos { get; set; }
        public DbSet<MecanicoVehiculo> MecanicoVehiculo { get; set; }
        public DbSet<DuenhoVehiculo> DuenhoVehiculo { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuider)
        {
            if (!optionsBuider.IsConfigured)
            {
                optionsBuider.UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = RevisionVehiculosPrueba");
            }
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Persona>().HasIndex(u => u.Id).IsUnique();
            builder.Entity<Mecanico>().HasIndex(u => u.NumeroDocumento).IsUnique();
            builder.Entity<Conductor>().HasIndex(u => u.NumeroDocumento).IsUnique();
            builder.Entity<DuenhoVehiculo>().HasIndex(u => u.NumeroDocumento).IsUnique();
        }
    }
}