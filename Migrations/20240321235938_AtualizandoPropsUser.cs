using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DealerShipApi.Migrations
{
    /// <inheritdoc />
    public partial class AtualizandoPropsUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UsuarioContato",
                table: "Usuarios",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "UsuarioCpf",
                table: "Usuarios",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "UsuarioEmail",
                table: "Usuarios",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "UsuarioEndereco",
                table: "Usuarios",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "UsuarioNomeCompleto",
                table: "Usuarios",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UsuarioContato",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "UsuarioCpf",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "UsuarioEmail",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "UsuarioEndereco",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "UsuarioNomeCompleto",
                table: "Usuarios");
        }
    }
}
