﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Teste_K2iP.Data;

namespace Teste_K2iP.Migrations
{
    [DbContext(typeof(BancoContext))]
    partial class BancoContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Teste_K2iP.Models.Adquirente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Codigo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Adquirente");
                });

            modelBuilder.Entity("Teste_K2iP.Models.Bandeira", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Codigo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Bandeira");
                });

            modelBuilder.Entity("Teste_K2iP.Models.Transacoes", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AdquirenteId")
                        .HasColumnType("int");

                    b.Property<int>("BandeiraId")
                        .HasColumnType("int");

                    b.Property<string>("CodigoAutorizacao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CodigoCliente")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DataTransacao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HoraTransacao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NSU")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumeroCartao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("TaxaAdmin")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("ValorBruto")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("ValorLiquido")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ID");

                    b.HasIndex("AdquirenteId");

                    b.HasIndex("BandeiraId");

                    b.ToTable("Transacoes");
                });

            modelBuilder.Entity("Teste_K2iP.Models.Transacoes", b =>
                {
                    b.HasOne("Teste_K2iP.Models.Adquirente", "Adquirente")
                        .WithMany("Transacoes")
                        .HasForeignKey("AdquirenteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Teste_K2iP.Models.Bandeira", "Bandeira")
                        .WithMany("Transacoes")
                        .HasForeignKey("BandeiraId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
