﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using atividadeBDMVC.Data;

namespace atividadeBDMVC.Migrations
{
    [DbContext(typeof(IESContext))]
    partial class IESContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("atividadeBDMVC.Models.Curso", b =>
                {
                    b.Property<long?>("CursoID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<long?>("DepartamentoID")
                        .HasColumnType("bigint");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumeroAlunos")
                        .HasColumnType("int");

                    b.Property<string>("Turno")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CursoID");

                    b.HasIndex("DepartamentoID");

                    b.ToTable("Cursos");
                });

            modelBuilder.Entity("atividadeBDMVC.Models.Departamento", b =>
                {
                    b.Property<long?>("DepartamentoID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<string>("Campus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("InstituicaoID")
                        .HasColumnType("bigint");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("DepartamentoID");

                    b.HasIndex("InstituicaoID");

                    b.ToTable("Departamentos");
                });

            modelBuilder.Entity("atividadeBDMVC.Models.Disciplina", b =>
                {
                    b.Property<long?>("DisciplinaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DisciplinaID");

                    b.ToTable("Disciplinas");
                });

            modelBuilder.Entity("atividadeBDMVC.Models.Instituicao", b =>
                {
                    b.Property<long?>("InstituicaoID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("InstituicaoID");

                    b.ToTable("Instituicoes");
                });

            modelBuilder.Entity("atividadeBDMVC.Models.Curso", b =>
                {
                    b.HasOne("atividadeBDMVC.Models.Departamento", "Departamento")
                        .WithMany("Cursos")
                        .HasForeignKey("DepartamentoID");

                    b.Navigation("Departamento");
                });

            modelBuilder.Entity("atividadeBDMVC.Models.Departamento", b =>
                {
                    b.HasOne("atividadeBDMVC.Models.Instituicao", "Instituicao")
                        .WithMany("Departamentos")
                        .HasForeignKey("InstituicaoID");

                    b.Navigation("Instituicao");
                });

            modelBuilder.Entity("atividadeBDMVC.Models.Departamento", b =>
                {
                    b.Navigation("Cursos");
                });

            modelBuilder.Entity("atividadeBDMVC.Models.Instituicao", b =>
                {
                    b.Navigation("Departamentos");
                });
#pragma warning restore 612, 618
        }
    }
}
