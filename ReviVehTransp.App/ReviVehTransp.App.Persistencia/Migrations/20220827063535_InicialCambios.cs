using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReviVehTransp.App.Persistencia.Migrations
{
    public partial class InicialCambios : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehiculos_Personas_ConductorId",
                table: "Vehiculos");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehiculos_Personas_DuenhoVehiculoId",
                table: "Vehiculos");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehiculos_Personas_MecanicoId",
                table: "Vehiculos");

            migrationBuilder.DropIndex(
                name: "IX_Vehiculos_ConductorId",
                table: "Vehiculos");

            migrationBuilder.DropIndex(
                name: "IX_Vehiculos_MecanicoId",
                table: "Vehiculos");

            migrationBuilder.DropColumn(
                name: "ConductorId",
                table: "Vehiculos");

            migrationBuilder.DropColumn(
                name: "MecanicoId",
                table: "Vehiculos");

            migrationBuilder.AlterColumn<int>(
                name: "DuenhoVehiculoId",
                table: "Vehiculos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Vehiculos_Personas_DuenhoVehiculoId",
                table: "Vehiculos",
                column: "DuenhoVehiculoId",
                principalTable: "Personas",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personas_Vehiculos_IdVehiculoId",
                table: "Personas");

            migrationBuilder.DropForeignKey(
                name: "FK_Personas_Vehiculos_VehiculoId",
                table: "Personas");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehiculos_Personas_DuenhoVehiculoId",
                table: "Vehiculos");

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

            migrationBuilder.AlterColumn<int>(
                name: "DuenhoVehiculoId",
                table: "Vehiculos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ConductorId",
                table: "Vehiculos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MecanicoId",
                table: "Vehiculos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Vehiculos_ConductorId",
                table: "Vehiculos",
                column: "ConductorId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehiculos_MecanicoId",
                table: "Vehiculos",
                column: "MecanicoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehiculos_Personas_ConductorId",
                table: "Vehiculos",
                column: "ConductorId",
                principalTable: "Personas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehiculos_Personas_DuenhoVehiculoId",
                table: "Vehiculos",
                column: "DuenhoVehiculoId",
                principalTable: "Personas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehiculos_Personas_MecanicoId",
                table: "Vehiculos",
                column: "MecanicoId",
                principalTable: "Personas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
