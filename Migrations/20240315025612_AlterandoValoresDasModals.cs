using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DealerShipApi.Migrations
{
    /// <inheritdoc />
    public partial class AlterandoValoresDasModals : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SalarioVendedor",
                table: "Vendedores");

            migrationBuilder.DropColumn(
                name: "QuantidadeDisponivel",
                table: "Carros");

            migrationBuilder.AddColumn<string>(
                name: "CidadeVendedor",
                table: "Vendedores",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "ContatoVendedor",
                table: "Vendedores",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "EstadoVendedor",
                table: "Vendedores",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "CorCarro",
                table: "Carros",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "QuilometragemCarro",
                table: "Carros",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CidadeVendedor",
                table: "Vendedores");

            migrationBuilder.DropColumn(
                name: "ContatoVendedor",
                table: "Vendedores");

            migrationBuilder.DropColumn(
                name: "EstadoVendedor",
                table: "Vendedores");

            migrationBuilder.DropColumn(
                name: "CorCarro",
                table: "Carros");

            migrationBuilder.DropColumn(
                name: "QuilometragemCarro",
                table: "Carros");

            migrationBuilder.AddColumn<decimal>(
                name: "SalarioVendedor",
                table: "Vendedores",
                type: "decimal(65,30)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "QuantidadeDisponivel",
                table: "Carros",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
