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
        public DbSet<MecanicoVehiculo> MecanicoVehiculos { get; set; }
        public DbSet<ConductorVehiculo> ConductorVehiculos { get; set; }
        public DbSet<PropietarioVehiculo> PropietarioVehiculos { get; set; }
        public DbSet<Vehiculo> Vehiculos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuider)
        {
            if (!optionsBuider.IsConfigured)
            {
                optionsBuider.UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = RevisionVehiculosPrueba");
            }
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Persona>().HasIndex(p => p.NumeroDocumento).IsUnique();
            /*
            -Crear tabla propietario vehiculos debido a que se esta generando circulazacion de datos en tb vehiculos por la relacion de 1 a * que tiene con dueñovehiculos
            */

            // LLave Foranea de DueñoVehiculo en Vehiculo
            builder.Entity<PropietarioVehiculo>()
            .HasKey(pv => new {pv.IdVehiculo, pv.IdDuenhoVehiculo});

            builder.Entity<PropietarioVehiculo>()
            .HasOne(pv => pv.Vehiculo)
            .WithOne(v => v.PropietarioVehiculo)
            .HasForeignKey<PropietarioVehiculo>(pv => pv.IdVehiculo)
            .OnDelete(DeleteBehavior.ClientSetNull);

            builder.Entity<PropietarioVehiculo>()
            .HasOne(pv => pv.DuenhoVehiculo)
            .WithMany(dv => dv.PropietarioVehiculos)
            .HasForeignKey(pv => pv.IdDuenhoVehiculo)
            .OnDelete(DeleteBehavior.ClientSetNull);

            //Llave foranea de Conductor y Vehiculo
            builder.Entity<ConductorVehiculo>()
            .HasKey(cv => new{cv.VehiculoId, cv.ConductorId});

            builder.Entity<ConductorVehiculo>()
            .HasOne(cv => cv.Conductor)
            .WithMany(c => c.ConductorVehiculos)
            .HasForeignKey(cv => cv.ConductorId)
            .OnDelete(DeleteBehavior.ClientSetNull);

            builder.Entity<ConductorVehiculo>()
            .HasOne(cv => cv.Vehiculo)
            .WithMany(v => v.ConductorVehiculos)
            .HasForeignKey(cv => cv.VehiculoId)
            .OnDelete(DeleteBehavior.ClientSetNull);

            //LLave Foranea MecanicoVehiculos

            builder.Entity<MecanicoVehiculo>()
            .HasKey(mv => new {mv.VehiculoId, mv.MecanicoId});

            builder.Entity<MecanicoVehiculo>()
            .HasOne(mv => mv.Vehiculo)
            .WithMany(v => v.MecanicoVehiculos)
            .HasForeignKey(mv => mv.VehiculoId)
            .OnDelete(DeleteBehavior.ClientSetNull);

            builder.Entity<MecanicoVehiculo>()
            .HasOne(mv => mv.Mecanico)
            .WithMany(m => m.MecanicoVehiculos)
            .HasForeignKey(mv => mv.MecanicoId)
            .OnDelete(DeleteBehavior.ClientSetNull);

        }
    }
}