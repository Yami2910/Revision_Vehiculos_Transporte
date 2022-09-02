using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReviVehTransp.App.Persistencia.Migrations
{
    public partial class BaseDatos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Personas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellidos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumeroDocumento = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rol = table.Column<int>(type: "int", nullable: true),
                    TipoLicencia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumeroTelefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CiudadResidencia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaComprador = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NivelEstudio = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vehiculos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Placa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Marca = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModeloAnio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CapacidadPasajeros = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CilindrajeMotor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaisOrigen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DescripcionGeneral = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OtrasCaracteristicas = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehiculos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ConductorVehiculos",
                columns: table => new
                {
                    VehiculoId = table.Column<int>(type: "int", nullable: false),
                    ConductorId = table.Column<int>(type: "int", nullable: false),
                    FechaAsignacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConductorVehiculos", x => new { x.VehiculoId, x.ConductorId });
                    table.ForeignKey(
                        name: "FK_ConductorVehiculos_Personas_ConductorId",
                        column: x => x.ConductorId,
                        principalTable: "Personas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ConductorVehiculos_Vehiculos_VehiculoId",
                        column: x => x.VehiculoId,
                        principalTable: "Vehiculos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MecanicoVehiculos",
                columns: table => new
                {
                    VehiculoId = table.Column<int>(type: "int", nullable: false),
                    MecanicoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MecanicoVehiculos", x => new { x.VehiculoId, x.MecanicoId });
                    table.ForeignKey(
                        name: "FK_MecanicoVehiculos_Personas_MecanicoId",
                        column: x => x.MecanicoId,
                        principalTable: "Personas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MecanicoVehiculos_Vehiculos_VehiculoId",
                        column: x => x.VehiculoId,
                        principalTable: "Vehiculos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PropietarioVehiculos",
                columns: table => new
                {
                    IdVehiculo = table.Column<int>(type: "int", nullable: false),
                    IdDuenhoVehiculo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropietarioVehiculos", x => new { x.IdVehiculo, x.IdDuenhoVehiculo });
                    table.ForeignKey(
                        name: "FK_PropietarioVehiculos_Personas_IdDuenhoVehiculo",
                        column: x => x.IdDuenhoVehiculo,
                        principalTable: "Personas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PropietarioVehiculos_Vehiculos_IdVehiculo",
                        column: x => x.IdVehiculo,
                        principalTable: "Vehiculos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConductorVehiculos_ConductorId",
                table: "ConductorVehiculos",
                column: "ConductorId");

            migrationBuilder.CreateIndex(
                name: "IX_MecanicoVehiculos_MecanicoId",
                table: "MecanicoVehiculos",
                column: "MecanicoId");

            migrationBuilder.CreateIndex(
                name: "IX_Personas_NumeroDocumento",
                table: "Personas",
                column: "NumeroDocumento",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PropietarioVehiculos_IdDuenhoVehiculo",
                table: "PropietarioVehiculos",
                column: "IdDuenhoVehiculo");

            migrationBuilder.CreateIndex(
                name: "IX_PropietarioVehiculos_IdVehiculo",
                table: "PropietarioVehiculos",
                column: "IdVehiculo",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConductorVehiculos");

            migrationBuilder.DropTable(
                name: "MecanicoVehiculos");

            migrationBuilder.DropTable(
                name: "PropietarioVehiculos");

            migrationBuilder.DropTable(
                name: "Personas");

            migrationBuilder.DropTable(
                name: "Vehiculos");
        }
    }
}
