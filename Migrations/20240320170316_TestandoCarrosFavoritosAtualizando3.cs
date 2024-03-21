using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DealerShipApi.Migrations
{
    /// <inheritdoc />
    public partial class TestandoCarrosFavoritosAtualizando3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carros_Usuarios_UserId",
                table: "Carros");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "Usuarios",
                newName: "UsuarioNome");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Usuarios",
                newName: "UsuarioId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Carros",
                newName: "UsuarioId");

            migrationBuilder.RenameIndex(
                name: "IX_Carros_UserId",
                table: "Carros",
                newName: "IX_Carros_UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Carros_Usuarios_UsuarioId",
                table: "Carros",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "UsuarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carros_Usuarios_UsuarioId",
                table: "Carros");

            migrationBuilder.RenameColumn(
                name: "UsuarioNome",
                table: "Usuarios",
                newName: "Nome");

            migrationBuilder.RenameColumn(
                name: "UsuarioId",
                table: "Usuarios",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "UsuarioId",
                table: "Carros",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Carros_UsuarioId",
                table: "Carros",
                newName: "IX_Carros_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Carros_Usuarios_UserId",
                table: "Carros",
                column: "UserId",
                principalTable: "Usuarios",
                principalColumn: "UserId");
        }
    }
}
