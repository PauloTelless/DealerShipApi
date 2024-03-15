﻿// <auto-generated />
using System;
using DealerShipApi.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DealerShipApi.Migrations
{
    [DbContext(typeof(DealerShipAppContext))]
    partial class DealerShipAppContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("DealerShipApi.Models.Carro", b =>
                {
                    b.Property<Guid>("CarroId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("AnoCarro")
                        .HasColumnType("longtext");

                    b.Property<string>("AnoLancamento")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<Guid>("CategoriaId")
                        .HasColumnType("char(36)");

                    b.Property<string>("CorCarro")
                        .HasColumnType("longtext");

                    b.Property<string>("DescricaoCarro")
                        .HasColumnType("longtext");

                    b.Property<string>("ImagemCarro")
                        .HasColumnType("longtext");

                    b.Property<string>("MarcaCarro")
                        .HasColumnType("longtext");

                    b.Property<string>("ModeloCarro")
                        .HasColumnType("longtext");

                    b.Property<string>("PlacaCarro")
                        .HasColumnType("longtext");

                    b.Property<string>("PrecoCarro")
                        .HasColumnType("longtext");

                    b.Property<string>("QuilometragemCarro")
                        .HasColumnType("longtext");

                    b.Property<Guid>("VendedorId")
                        .HasColumnType("char(36)");

                    b.HasKey("CarroId");

                    b.HasIndex("CategoriaId");

                    b.HasIndex("VendedorId");

                    b.ToTable("Carros");
                });

            modelBuilder.Entity("DealerShipApi.Models.CategoriaCarro", b =>
                {
                    b.Property<Guid>("CategoriaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("NomeCategoria")
                        .HasColumnType("longtext");

                    b.HasKey("CategoriaId");

                    b.ToTable("Categorias");
                });

            modelBuilder.Entity("DealerShipApi.Models.Vendedor", b =>
                {
                    b.Property<Guid>("VendedorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("CidadeVendedor")
                        .HasColumnType("longtext");

                    b.Property<string>("ContatoVendedor")
                        .HasColumnType("longtext");

                    b.Property<string>("CpfVendedor")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("DataNascimentoVendedor")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("EnderecoVendedor")
                        .HasColumnType("longtext");

                    b.Property<string>("EstadoVendedor")
                        .HasColumnType("longtext");

                    b.Property<string>("FotoVendedor")
                        .HasColumnType("longtext");

                    b.Property<string>("NomeVendedor")
                        .HasColumnType("longtext");

                    b.HasKey("VendedorId");

                    b.ToTable("Vendedores");
                });

            modelBuilder.Entity("DealerShipApi.Models.Carro", b =>
                {
                    b.HasOne("DealerShipApi.Models.CategoriaCarro", "Categoria")
                        .WithMany("Carros")
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DealerShipApi.Models.Vendedor", "Vendedor")
                        .WithMany()
                        .HasForeignKey("VendedorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categoria");

                    b.Navigation("Vendedor");
                });

            modelBuilder.Entity("DealerShipApi.Models.CategoriaCarro", b =>
                {
                    b.Navigation("Carros");
                });
#pragma warning restore 612, 618
        }
    }
}
