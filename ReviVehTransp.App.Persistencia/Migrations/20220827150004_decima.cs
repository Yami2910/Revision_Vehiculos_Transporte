using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReviVehTransp.App.Persistencia.Migrations
{
    public partial class decima : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Personas_Id",
                table: "Personas",
                column: "Id",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Personas_Id",
                table: "Personas");
        }
    }
}
