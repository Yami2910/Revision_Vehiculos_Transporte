﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ReviVehTransp.App.Persistencia;

#nullable disable

namespace ReviVehTransp.App.Persistencia.Migrations
{
    [DbContext(typeof(AppContext))]
    [Migration("20220827062155_Inicial")]
    partial class Inicial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ReviVehTransp.App.Dominio.Persona", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Apellidos")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaNacimiento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Personas");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Persona");
                });

            modelBuilder.Entity("ReviVehTransp.App.Dominio.Vehiculo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CapacidadPasajeros")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CilindrajeMotor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ConductorId")
                        .HasColumnType("int");

                    b.Property<string>("DescripcionGeneral")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DuenhoVehiculoId")
                        .HasColumnType("int");

                    b.Property<string>("Marca")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MecanicoId")
                        .HasColumnType("int");

                    b.Property<string>("ModeloAnio")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OtrasCaracteristicas")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PaisOrigen")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Placa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ConductorId");

                    b.HasIndex("DuenhoVehiculoId");

                    b.HasIndex("MecanicoId");

                    b.ToTable("Vehiculos");
                });

            modelBuilder.Entity("ReviVehTransp.App.Dominio.Auxiliar", b =>
                {
                    b.HasBaseType("ReviVehTransp.App.Dominio.Persona");

                    b.Property<int>("Rol")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("Auxiliar");
                });

            modelBuilder.Entity("ReviVehTransp.App.Dominio.Conductor", b =>
                {
                    b.HasBaseType("ReviVehTransp.App.Dominio.Persona");

                    b.Property<string>("NumeroTelefono")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TipoLicencia")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Conductor");
                });

            modelBuilder.Entity("ReviVehTransp.App.Dominio.DuenhoVehiculo", b =>
                {
                    b.HasBaseType("ReviVehTransp.App.Dominio.Persona");

                    b.Property<string>("CiudadResidencia")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("DuenhoVehiculo");
                });

            modelBuilder.Entity("ReviVehTransp.App.Dominio.Mecanico", b =>
                {
                    b.HasBaseType("ReviVehTransp.App.Dominio.Persona");

                    b.Property<string>("NivelEstudio")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Mecanico");
                });

            modelBuilder.Entity("ReviVehTransp.App.Dominio.Vehiculo", b =>
                {
                    b.HasOne("ReviVehTransp.App.Dominio.Conductor", "Conductor")
                        .WithMany()
                        .HasForeignKey("ConductorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ReviVehTransp.App.Dominio.DuenhoVehiculo", "DuenhoVehiculo")
                        .WithMany()
                        .HasForeignKey("DuenhoVehiculoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ReviVehTransp.App.Dominio.Mecanico", "Mecanico")
                        .WithMany()
                        .HasForeignKey("MecanicoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Conductor");

                    b.Navigation("DuenhoVehiculo");

                    b.Navigation("Mecanico");
                });
#pragma warning restore 612, 618
        }
    }
}
