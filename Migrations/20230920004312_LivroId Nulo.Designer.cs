﻿// <auto-generated />
using System;
using MeusLivrosAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MeusLivrosAPI.Migrations
{
    [DbContext(typeof(LivroContext))]
    [Migration("20230920004312_LivroId Nulo")]
    partial class LivroIdNulo
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("MeusLivrosAPI.Models.Endereco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Logradouro")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Numero")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Enderecos");
                });

            modelBuilder.Entity("MeusLivrosAPI.Models.Lancamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("LivrariaId")
                        .HasColumnType("int");

                    b.Property<int?>("LivroId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LivrariaId");

                    b.HasIndex("LivroId");

                    b.ToTable("Lancamento");
                });

            modelBuilder.Entity("MeusLivrosAPI.Models.Livraria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("EnderecoId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("EnderecoId")
                        .IsUnique();

                    b.ToTable("Livrarias");
                });

            modelBuilder.Entity("MeusLivrosAPI.Models.Livro", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime?>("AnoDePublicacao")
                        .IsRequired()
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Autor")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime?>("DataDeAlteracao")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DataDeGravacao")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Editora")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Genero")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<bool?>("Lido")
                        .IsRequired()
                        .HasColumnType("tinyint(1)");

                    b.Property<short?>("Nota")
                        .IsRequired()
                        .HasColumnType("smallint");

                    b.Property<int>("QtdPaginas")
                        .HasColumnType("int");

                    b.Property<string>("Review")
                        .HasMaxLength(5000)
                        .HasColumnType("varchar(5000)");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("id");

                    b.ToTable("Livros");
                });

            modelBuilder.Entity("MeusLivrosAPI.Models.Lancamento", b =>
                {
                    b.HasOne("MeusLivrosAPI.Models.Livraria", "Livraria")
                        .WithMany("Lancamentos")
                        .HasForeignKey("LivrariaId");

                    b.HasOne("MeusLivrosAPI.Models.Livro", "Livro")
                        .WithMany("Lancamentos")
                        .HasForeignKey("LivroId");

                    b.Navigation("Livraria");

                    b.Navigation("Livro");
                });

            modelBuilder.Entity("MeusLivrosAPI.Models.Livraria", b =>
                {
                    b.HasOne("MeusLivrosAPI.Models.Endereco", "Endereco")
                        .WithOne("Livraria")
                        .HasForeignKey("MeusLivrosAPI.Models.Livraria", "EnderecoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Endereco");
                });

            modelBuilder.Entity("MeusLivrosAPI.Models.Endereco", b =>
                {
                    b.Navigation("Livraria")
                        .IsRequired();
                });

            modelBuilder.Entity("MeusLivrosAPI.Models.Livraria", b =>
                {
                    b.Navigation("Lancamentos");
                });

            modelBuilder.Entity("MeusLivrosAPI.Models.Livro", b =>
                {
                    b.Navigation("Lancamentos");
                });
#pragma warning restore 612, 618
        }
    }
}
