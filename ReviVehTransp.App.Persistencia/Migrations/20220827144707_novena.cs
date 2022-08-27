using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReviVehTransp.App.Persistencia.Migrations
{
    public partial class novena : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MecanicoVehiculo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MecanicoId = table.Column<int>(type: "int", nullable: false),
                    VehiculoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MecanicoVehiculo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MecanicoVehiculo_Personas_MecanicoId",
                        column: x => x.MecanicoId,
                        principalTable: "Personas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MecanicoVehiculo_Vehiculos_VehiculoId",
                        column: x => x.VehiculoId,
                        principalTable: "Vehiculos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MecanicoVehiculo_MecanicoId",
                table: "MecanicoVehiculo",
                column: "MecanicoId");

            migrationBuilder.CreateIndex(
                name: "IX_MecanicoVehiculo_VehiculoId",
                table: "MecanicoVehiculo",
                column: "VehiculoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MecanicoVehiculo");
        }
    }
}
