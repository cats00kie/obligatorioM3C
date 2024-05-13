using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Papeleria.AccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class terminadopedidosv2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ModificadorMismoDia",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "ModificadorRecargo",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "PedidoExpress_ModificadorRecargo",
                table: "Pedidos");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ModificadorMismoDia",
                table: "Pedidos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ModificadorRecargo",
                table: "Pedidos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PedidoExpress_ModificadorRecargo",
                table: "Pedidos",
                type: "int",
                nullable: true);
        }
    }
}
