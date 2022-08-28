using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReviVehTransp.App.Persistencia.Migrations
{
    public partial class octova : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personas_Vehiculos_IdVehiculoId",
                table: "Personas");

            migrationBuilder.DropForeignKey(
                name: "FK_Personas_Vehiculos_VehiculoId",
                table: "Personas");

            migrationBuilder.DropIndex(
                name: "IX_Personas_IdVehiculoId",
                table: "Personas");

            migrationBuilder.DropIndex(
                name: "IX_Personas_VehiculoId",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "IdVehiculoId",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "VehiculoId",
                table: "Personas");

            migrationBuilder.AddColumn<string>(
                name: "Auxiliar_NumeroDocumento",
                table: "Personas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Conductor_NumeroDocumento",
                table: "Personas",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DuenhoVehiculo_NumeroDocumento",
                table: "Personas",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NumeroDocumento",
                table: "Personas",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Personas_Conductor_NumeroDocumento",
                table: "Personas",
                column: "Conductor_NumeroDocumento",
                unique: true,
                filter: "[Conductor_NumeroDocumento] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Personas_DuenhoVehiculo_NumeroDocumento",
                table: "Personas",
                column: "DuenhoVehiculo_NumeroDocumento",
                unique: true,
                filter: "[DuenhoVehiculo_NumeroDocumento] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Personas_NumeroDocumento",
                table: "Personas",
                column: "NumeroDocumento",
                unique: true,
                filter: "[NumeroDocumento] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Personas_Conductor_NumeroDocumento",
                table: "Personas");

            migrationBuilder.DropIndex(
                name: "IX_Personas_DuenhoVehiculo_NumeroDocumento",
                table: "Personas");

            migrationBuilder.DropIndex(
                name: "IX_Personas_NumeroDocumento",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "Auxiliar_NumeroDocumento",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "Conductor_NumeroDocumento",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "DuenhoVehiculo_NumeroDocumento",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "NumeroDocumento",
                table: "Personas");

            migrationBuilder.AddColumn<int>(
                name: "IdVehiculoId",
                table: "Personas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VehiculoId",
                table: "Personas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Personas_IdVehiculoId",
                table: "Personas",
                column: "IdVehiculoId");

            migrationBuilder.CreateIndex(
                name: "IX_Personas_VehiculoId",
                table: "Personas",
                column: "VehiculoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Personas_Vehiculos_IdVehiculoId",
                table: "Personas",
                column: "IdVehiculoId",
                principalTable: "Vehiculos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Personas_Vehiculos_VehiculoId",
                table: "Personas",
                column: "VehiculoId",
                principalTable: "Vehiculos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
