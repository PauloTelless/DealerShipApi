using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DealerShipApi.Migrations
{
    /// <inheritdoc />
    public partial class ColocandoPropUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UsuarioRg",
                table: "Usuarios",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UsuarioRg",
                table: "Usuarios");
        }
    }
}
