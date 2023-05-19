using Microsoft.EntityFrameworkCore.Migrations;

namespace atividadeBDMVC.Migrations
{
    public partial class Inicio2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id",
                table: "Academicos",
                newName: "AcademicoID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AcademicoID",
                table: "Academicos",
                newName: "id");
        }
    }
}
