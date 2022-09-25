using Microsoft.EntityFrameworkCore;

namespace Revision_Vehiculos_Transporte_MVC.Models
{
    public partial class REVIVEHTRANSPContext : DbContext
    {
        public REVIVEHTRANSPContext()
        {
        }

        public REVIVEHTRANSPContext(DbContextOptions<REVIVEHTRANSPContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Conductor> Conductors { get; set; } = null!;
        public virtual DbSet<DuenoVehiculo> DuenoVehiculos { get; set; } = null!;
        public virtual DbSet<Mecanico> Mecanicos { get; set; } = null!;
        public virtual DbSet<MecanicoVehiculo> MecanicoVehiculos { get; set; } = null!;
        public virtual DbSet<Vehiculo> Vehiculos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                //optionsBuilder.UseSqlServer("server=localhost;database = REVIVEHTRANSP; integrated security= true; ");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Conductor>(entity =>
            {
                entity.ToTable("Conductor");

                entity.Property(e => e.Apellido)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Direccion)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.FechaNacimiento).HasColumnType("date");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.NumeroDocumento)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.NumeroTelefono)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.TipoLicencia)
                    .HasMaxLength(25)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<DuenoVehiculo>(entity =>
            {
                entity.ToTable("DuenoVehiculo");

                entity.Property(e => e.Apellido)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CiudadResidencia)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Direccion)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.FechaNacimiento).HasColumnType("date");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.NumeroDocumento)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.NumeroTelefono)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Mecanico>(entity =>
            {
                entity.ToTable("Mecanico");

                entity.Property(e => e.Apellido)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Direccion)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.FechaNacimiento).HasColumnType("date");

                entity.Property(e => e.NivelEstudios)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Nombre)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.NumeroDocumento)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.NumeroTelefono)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<MecanicoVehiculo>(entity =>
            {
                entity.ToTable("MecanicoVehiculo");

                entity.HasOne(d => d.IdMecanicoNavigation)
                    .WithMany(p => p.MecanicoVehiculos)
                    .HasForeignKey(d => d.IdMecanico)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_MecanicoMVV");

                entity.HasOne(d => d.IdVehiculoNavigation)
                    .WithMany(p => p.MecanicoVehiculos)
                    .HasForeignKey(d => d.IdVehiculo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_VehiculoMV");
            });

            modelBuilder.Entity<Vehiculo>(entity =>
            {
                entity.ToTable("Vehiculo");

                entity.Property(e => e.CapacidadPasajeros)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CilindrajeMotor)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.DescripcionGeneral)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Marca)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Modelo)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.OtrasCaracteristicas)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.PaisOrigen)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Placa)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Tipo)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.HasOne(d => d.IdConductorNavigation)
                    .WithMany(p => p.Vehiculos)
                    .HasForeignKey(d => d.IdConductor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_ConductorV");

                entity.HasOne(d => d.IdDuenoVehiculoNavigation)
                    .WithMany(p => p.Vehiculos)
                    .HasForeignKey(d => d.IdDuenoVehiculo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_DuenoV");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
