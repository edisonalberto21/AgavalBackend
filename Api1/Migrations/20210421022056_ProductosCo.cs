using Microsoft.EntityFrameworkCore.Migrations;

namespace Api1.Migrations
{
    public partial class ProductosCo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Descripccion",
                table: "Productos",
                newName: "Descripcion");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Descripcion",
                table: "Productos",
                newName: "Descripccion");
        }
    }
}
