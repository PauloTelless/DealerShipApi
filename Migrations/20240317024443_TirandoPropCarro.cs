using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DealerShipApi.Migrations
{
    /// <inheritdoc />
    public partial class TirandoPropCarro : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QuantidadeDisponivel",
                table: "Carros");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "QuantidadeDisponivel",
                table: "Carros",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
