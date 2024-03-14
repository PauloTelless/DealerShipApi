using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DealerShipApi.Migrations
{
    /// <inheritdoc />
    public partial class ColocandoCampoFotoDoVendedor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carros_Categorias_CategoriaCarroCategoriaId",
                table: "Carros");

            migrationBuilder.DropIndex(
                name: "IX_Carros_CategoriaCarroCategoriaId",
                table: "Carros");

            migrationBuilder.DropColumn(
                name: "CategoriaCarroCategoriaId",
                table: "Carros");

            migrationBuilder.AddColumn<string>(
                name: "FotoVendedor",
                table: "Vendedores",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Carros_CategoriaId",
                table: "Carros",
                column: "CategoriaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Carros_Categorias_CategoriaId",
                table: "Carros",
                column: "CategoriaId",
                principalTable: "Categorias",
                principalColumn: "CategoriaId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carros_Categorias_CategoriaId",
                table: "Carros");

            migrationBuilder.DropIndex(
                name: "IX_Carros_CategoriaId",
                table: "Carros");

            migrationBuilder.DropColumn(
                name: "FotoVendedor",
                table: "Vendedores");

            migrationBuilder.AddColumn<Guid>(
                name: "CategoriaCarroCategoriaId",
                table: "Carros",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.CreateIndex(
                name: "IX_Carros_CategoriaCarroCategoriaId",
                table: "Carros",
                column: "CategoriaCarroCategoriaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Carros_Categorias_CategoriaCarroCategoriaId",
                table: "Carros",
                column: "CategoriaCarroCategoriaId",
                principalTable: "Categorias",
                principalColumn: "CategoriaId");
        }
    }
}
