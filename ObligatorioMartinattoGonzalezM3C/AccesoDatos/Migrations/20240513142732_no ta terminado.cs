using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Papeleria.AccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class notaterminado : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Direccion_Ciudad",
                table: "Clientes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "Direccion_DistanciaKm",
                table: "Clientes",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Direccion_NombreCalle",
                table: "Clientes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Direccion_NumeroPuerta",
                table: "Clientes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Direccion_Ciudad",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "Direccion_DistanciaKm",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "Direccion_NombreCalle",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "Direccion_NumeroPuerta",
                table: "Clientes");
        }
    }
}
