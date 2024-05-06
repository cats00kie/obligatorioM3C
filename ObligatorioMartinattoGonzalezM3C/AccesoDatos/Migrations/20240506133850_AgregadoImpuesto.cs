using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Papeleria.AccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class AgregadoImpuesto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Configuracion_ConfiguracionObjId",
                table: "Pedidos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Configuracion",
                table: "Configuracion");

            migrationBuilder.DropColumn(
                name: "Iva",
                table: "Configuracion");

            migrationBuilder.RenameTable(
                name: "Configuracion",
                newName: "Configuraciones");

            migrationBuilder.RenameColumn(
                name: "PlazoExpress",
                table: "Configuraciones",
                newName: "Valor");

            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "Configuraciones",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Configuraciones",
                table: "Configuraciones",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_Configuraciones_ConfiguracionObjId",
                table: "Pedidos",
                column: "ConfiguracionObjId",
                principalTable: "Configuraciones",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Configuraciones_ConfiguracionObjId",
                table: "Pedidos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Configuraciones",
                table: "Configuraciones");

            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "Configuraciones");

            migrationBuilder.RenameTable(
                name: "Configuraciones",
                newName: "Configuracion");

            migrationBuilder.RenameColumn(
                name: "Valor",
                table: "Configuracion",
                newName: "PlazoExpress");

            migrationBuilder.AddColumn<int>(
                name: "Iva",
                table: "Configuracion",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Configuracion",
                table: "Configuracion",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_Configuracion_ConfiguracionObjId",
                table: "Pedidos",
                column: "ConfiguracionObjId",
                principalTable: "Configuracion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
