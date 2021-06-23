﻿// <auto-generated />
using System;
using API_MedicoPaciente.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace API_MedicoPaciente.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("API_MedicoPaciente.Models.Medico", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Crm")
                        .IsRequired()
                        .HasColumnType("varchar(10)");

                    b.Property<string>("CrmUf")
                        .IsRequired()
                        .HasColumnType("varchar(2)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Medicos");
                });

            modelBuilder.Entity("API_MedicoPaciente.Models.Paciente", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnType("varchar(14)");

                    b.Property<DateTime>("DataDeNascimento")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid?>("MedicoId")
                        .HasColumnType("uuid");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("MedicoId");

                    b.ToTable("Pacientes");
                });

            modelBuilder.Entity("API_MedicoPaciente.Models.Paciente", b =>
                {
                    b.HasOne("API_MedicoPaciente.Models.Medico", "Medico")
                        .WithMany("Pacientes")
                        .HasForeignKey("MedicoId");

                    b.Navigation("Medico");
                });

            modelBuilder.Entity("API_MedicoPaciente.Models.Medico", b =>
                {
                    b.Navigation("Pacientes");
                });
#pragma warning restore 612, 618
        }
    }
}