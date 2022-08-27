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
    [Migration("20220827063835_Tercera")]
    partial class Tercera
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

                    b.Property<string>("DescripcionGeneral")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Marca")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

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

                    b.Property<int>("VehiculoId")
                        .HasColumnType("int");

                    b.HasIndex("VehiculoId");

                    b.HasDiscriminator().HasValue("Conductor");
                });

            modelBuilder.Entity("ReviVehTransp.App.Dominio.DuenhoVehiculo", b =>
                {
                    b.HasBaseType("ReviVehTransp.App.Dominio.Persona");

                    b.Property<string>("CiudadResidencia")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("VehiculosId")
                        .HasColumnType("int");

                    b.HasIndex("VehiculosId");

                    b.HasDiscriminator().HasValue("DuenhoVehiculo");
                });

            modelBuilder.Entity("ReviVehTransp.App.Dominio.Mecanico", b =>
                {
                    b.HasBaseType("ReviVehTransp.App.Dominio.Persona");

                    b.Property<int>("IdVehiculoId")
                        .HasColumnType("int");

                    b.Property<string>("NivelEstudio")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasIndex("IdVehiculoId");

                    b.HasDiscriminator().HasValue("Mecanico");
                });

            modelBuilder.Entity("ReviVehTransp.App.Dominio.Conductor", b =>
                {
                    b.HasOne("ReviVehTransp.App.Dominio.Vehiculo", "Vehiculo")
                        .WithMany()
                        .HasForeignKey("VehiculoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Vehiculo");
                });

            modelBuilder.Entity("ReviVehTransp.App.Dominio.DuenhoVehiculo", b =>
                {
                    b.HasOne("ReviVehTransp.App.Dominio.Vehiculo", "Vehiculos")
                        .WithMany()
                        .HasForeignKey("VehiculosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Vehiculos");
                });

            modelBuilder.Entity("ReviVehTransp.App.Dominio.Mecanico", b =>
                {
                    b.HasOne("ReviVehTransp.App.Dominio.Vehiculo", "IdVehiculo")
                        .WithMany()
                        .HasForeignKey("IdVehiculoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("IdVehiculo");
                });
#pragma warning restore 612, 618
        }
    }
}