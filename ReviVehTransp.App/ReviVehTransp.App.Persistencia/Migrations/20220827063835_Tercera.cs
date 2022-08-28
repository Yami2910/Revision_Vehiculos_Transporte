using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReviVehTransp.App.Persistencia.Migrations
{
    public partial class Tercera : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehiculos_Personas_DuenhoVehiculoId",
                table: "Vehiculos");

            migrationBuilder.DropIndex(
                name: "IX_Vehiculos_DuenhoVehiculoId",
                table: "Vehiculos");

            migrationBuilder.DropColumn(
                name: "DuenhoVehiculoId",
                table: "Vehiculos");

            migrationBuilder.AddColumn<int>(
                name: "VehiculosId",
                table: "Personas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Personas_VehiculosId",
                table: "Personas",
                column: "VehiculosId");

            migrationBuilder.AddForeignKey(
                name: "FK_Personas_Vehiculos_VehiculosId",
                table: "Personas",
                column: "VehiculosId",
                principalTable: "Vehiculos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personas_Vehiculos_VehiculosId",
                table: "Personas");

            migrationBuilder.DropIndex(
                name: "IX_Personas_VehiculosId",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "VehiculosId",
                table: "Personas");

            migrationBuilder.AddColumn<int>(
                name: "DuenhoVehiculoId",
                table: "Vehiculos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vehiculos_DuenhoVehiculoId",
                table: "Vehiculos",
                column: "DuenhoVehiculoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehiculos_Personas_DuenhoVehiculoId",
                table: "Vehiculos",
                column: "DuenhoVehiculoId",
                principalTable: "Personas",
                principalColumn: "Id");
        }
    }
}
