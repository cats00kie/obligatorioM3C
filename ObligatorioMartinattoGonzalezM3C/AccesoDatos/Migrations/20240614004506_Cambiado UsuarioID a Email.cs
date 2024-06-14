using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Papeleria.AccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class CambiadoUsuarioIDaEmail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movimientos_Usuario_UsuarioId",
                table: "Movimientos");

            migrationBuilder.DropIndex(
                name: "IX_Movimientos_UsuarioId",
                table: "Movimientos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Usuario",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Movimientos");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Usuario");

            migrationBuilder.RenameTable(
                name: "Usuario",
                newName: "Encargados");

            migrationBuilder.RenameIndex(
                name: "IX_Usuario_Email",
                table: "Encargados",
                newName: "IX_Encargados_Email");

            migrationBuilder.AddColumn<string>(
                name: "EmailUsuario",
                table: "Movimientos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Encargados",
                table: "Encargados",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    PasswordSinEncript = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    NombreCompleto_Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NombreCompleto_Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Admins_Email",
                table: "Admins",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Encargados",
                table: "Encargados");

            migrationBuilder.DropColumn(
                name: "EmailUsuario",
                table: "Movimientos");

            migrationBuilder.RenameTable(
                name: "Encargados",
                newName: "Usuario");

            migrationBuilder.RenameIndex(
                name: "IX_Encargados_Email",
                table: "Usuario",
                newName: "IX_Usuario_Email");

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Movimientos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Usuario",
                type: "nvarchar(13)",
                maxLength: 13,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Usuario",
                table: "Usuario",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Movimientos_UsuarioId",
                table: "Movimientos",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movimientos_Usuario_UsuarioId",
                table: "Movimientos",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
