using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DealerShipApi.Migrations
{
    /// <inheritdoc />
    public partial class MigracaoInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    CategoriaId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    NomeCategoria = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.CategoriaId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Vendedores",
                columns: table => new
                {
                    VendedorId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    NomeVendedor = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CpfVendedor = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EnderecoVendedor = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FotoVendedor = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DataNascimentoVendedor = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    SalarioVendedor = table.Column<decimal>(type: "decimal(65,30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendedores", x => x.VendedorId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Carros",
                columns: table => new
                {
                    CarroId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ModeloCarro = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MarcaCarro = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DescricaoCarro = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ImagemCarro = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PrecoCarro = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    PlacaCarro = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AnoCarro = table.Column<int>(type: "int", nullable: false),
                    QuantidadeDisponivel = table.Column<int>(type: "int", nullable: false),
                    AnoLancamento = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CategoriaId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    VendedorId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carros", x => x.CarroId);
                    table.ForeignKey(
                        name: "FK_Carros_Categorias_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categorias",
                        principalColumn: "CategoriaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Carros_Vendedores_VendedorId",
                        column: x => x.VendedorId,
                        principalTable: "Vendedores",
                        principalColumn: "VendedorId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Carros_CategoriaId",
                table: "Carros",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Carros_VendedorId",
                table: "Carros",
                column: "VendedorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Carros");

            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropTable(
                name: "Vendedores");
        }
    }
}
