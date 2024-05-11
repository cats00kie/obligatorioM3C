using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Papeleria.AccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class cosodelcosito : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Linea_Articulos_ArticuloObjId",
                table: "Linea");

            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Clientes_ClienteObjId",
                table: "Pedidos");

            migrationBuilder.RenameColumn(
                name: "ClienteObjId",
                table: "Pedidos",
                newName: "ClienteId");

            migrationBuilder.RenameIndex(
                name: "IX_Pedidos_ClienteObjId",
                table: "Pedidos",
                newName: "IX_Pedidos_ClienteId");

            migrationBuilder.RenameColumn(
                name: "ArticuloObjId",
                table: "Linea",
                newName: "ArticuloId");

            migrationBuilder.RenameIndex(
                name: "IX_Linea_ArticuloObjId",
                table: "Linea",
                newName: "IX_Linea_ArticuloId");

            migrationBuilder.AddForeignKey(
                name: "FK_Linea_Articulos_ArticuloId",
                table: "Linea",
                column: "ArticuloId",
                principalTable: "Articulos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_Clientes_ClienteId",
                table: "Pedidos",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Linea_Articulos_ArticuloId",
                table: "Linea");

            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Clientes_ClienteId",
                table: "Pedidos");

            migrationBuilder.RenameColumn(
                name: "ClienteId",
                table: "Pedidos",
                newName: "ClienteObjId");

            migrationBuilder.RenameIndex(
                name: "IX_Pedidos_ClienteId",
                table: "Pedidos",
                newName: "IX_Pedidos_ClienteObjId");

            migrationBuilder.RenameColumn(
                name: "ArticuloId",
                table: "Linea",
                newName: "ArticuloObjId");

            migrationBuilder.RenameIndex(
                name: "IX_Linea_ArticuloId",
                table: "Linea",
                newName: "IX_Linea_ArticuloObjId");

            migrationBuilder.AddForeignKey(
                name: "FK_Linea_Articulos_ArticuloObjId",
                table: "Linea",
                column: "ArticuloObjId",
                principalTable: "Articulos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_Clientes_ClienteObjId",
                table: "Pedidos",
                column: "ClienteObjId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
