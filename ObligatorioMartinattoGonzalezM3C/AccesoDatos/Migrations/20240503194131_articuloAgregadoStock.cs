using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Papeleria.AccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class articuloAgregadoStock : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Stock",
                table: "Linea",
                newName: "CantUnidades");

            migrationBuilder.AddColumn<int>(
                name: "Stock",
                table: "Articulos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Stock",
                table: "Articulos");

            migrationBuilder.RenameColumn(
                name: "CantUnidades",
                table: "Linea",
                newName: "Stock");
        }
    }
}
