using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DealerShipApi.Migrations
{
    /// <inheritdoc />
    public partial class ColocandoCampoDeVendedorEmCarro : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carros_Vendedores_VendedorId",
                table: "Carros");

            migrationBuilder.AlterColumn<Guid>(
                name: "VendedorId",
                table: "Carros",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldNullable: true)
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AddForeignKey(
                name: "FK_Carros_Vendedores_VendedorId",
                table: "Carros",
                column: "VendedorId",
                principalTable: "Vendedores",
                principalColumn: "VendedorId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carros_Vendedores_VendedorId",
                table: "Carros");

            migrationBuilder.AlterColumn<Guid>(
                name: "VendedorId",
                table: "Carros",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)")
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AddForeignKey(
                name: "FK_Carros_Vendedores_VendedorId",
                table: "Carros",
                column: "VendedorId",
                principalTable: "Vendedores",
                principalColumn: "VendedorId");
        }
    }
}
