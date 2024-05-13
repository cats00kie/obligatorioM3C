using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Papeleria.AccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class aversiahoraanda : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Configuraciones_ConfiguracionObjId",
                table: "Pedidos");

            migrationBuilder.DropIndex(
                name: "IX_Pedidos_ConfiguracionObjId",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "ConfiguracionObjId",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "DistanciaKm",
                table: "Pedidos");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ConfiguracionObjId",
                table: "Pedidos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "DistanciaKm",
                table: "Pedidos",
                type: "float",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_ConfiguracionObjId",
                table: "Pedidos",
                column: "ConfiguracionObjId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_Configuraciones_ConfiguracionObjId",
                table: "Pedidos",
                column: "ConfiguracionObjId",
                principalTable: "Configuraciones",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
