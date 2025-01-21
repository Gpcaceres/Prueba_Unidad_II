﻿// <auto-generated />
using System;
using GestionCitasMedicas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GestionCitasMedicas.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250121055535_InitalCreate")]
    partial class InitalCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GestionCitasMedicas.Entidades+Cita", b =>
                {
                    b.Property<int>("IdCita")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCita"));

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2")
                        .HasAnnotation("Relational:JsonPropertyName", "fecha");

                    b.Property<int>("IdDoctor")
                        .HasColumnType("int")
                        .HasAnnotation("Relational:JsonPropertyName", "id_doctor");

                    b.Property<int>("IdPaciente")
                        .HasColumnType("int")
                        .HasAnnotation("Relational:JsonPropertyName", "id_paciente");

                    b.HasKey("IdCita");

                    b.HasIndex("IdDoctor");

                    b.HasIndex("IdPaciente");

                    b.ToTable("Citas", (string)null);

                    b.HasAnnotation("Relational:JsonPropertyName", "cita");
                });

            modelBuilder.Entity("GestionCitasMedicas.Entidades+Doctor", b =>
                {
                    b.Property<int>("IdDoctor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdDoctor"));

                    b.Property<string>("Especialidad")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasAnnotation("Relational:JsonPropertyName", "especialidad");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasAnnotation("Relational:JsonPropertyName", "nombre");

                    b.HasKey("IdDoctor");

                    b.ToTable("Doctores", (string)null);
                });

            modelBuilder.Entity("GestionCitasMedicas.Entidades+Paciente", b =>
                {
                    b.Property<int>("IdPaciente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPaciente"));

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasAnnotation("Relational:JsonPropertyName", "apellido");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasAnnotation("Relational:JsonPropertyName", "nombre");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("IdPaciente");

                    b.ToTable("Pacientes", (string)null);
                });

            modelBuilder.Entity("GestionCitasMedicas.Entidades+Procedimiento", b =>
                {
                    b.Property<int>("IdProcedimiento")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdProcedimiento"));

                    b.Property<decimal>("Costo")
                        .HasColumnType("decimal(10,2)")
                        .HasAnnotation("Relational:JsonPropertyName", "costo");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .HasAnnotation("Relational:JsonPropertyName", "descripcion");

                    b.Property<int>("IdCita")
                        .HasColumnType("int")
                        .HasAnnotation("Relational:JsonPropertyName", "id_cita");

                    b.HasKey("IdProcedimiento");

                    b.HasIndex("IdCita");

                    b.ToTable("Procedimientos", (string)null);
                });

            modelBuilder.Entity("GestionCitasMedicas.Entidades+Cita", b =>
                {
                    b.HasOne("GestionCitasMedicas.Entidades+Doctor", "Doctor")
                        .WithMany("Citas")
                        .HasForeignKey("IdDoctor")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GestionCitasMedicas.Entidades+Paciente", "Paciente")
                        .WithMany("Citas")
                        .HasForeignKey("IdPaciente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doctor");

                    b.Navigation("Paciente");
                });

            modelBuilder.Entity("GestionCitasMedicas.Entidades+Procedimiento", b =>
                {
                    b.HasOne("GestionCitasMedicas.Entidades+Cita", "Cita")
                        .WithMany("Procedimientos")
                        .HasForeignKey("IdCita")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cita");
                });

            modelBuilder.Entity("GestionCitasMedicas.Entidades+Cita", b =>
                {
                    b.Navigation("Procedimientos");
                });

            modelBuilder.Entity("GestionCitasMedicas.Entidades+Doctor", b =>
                {
                    b.Navigation("Citas");
                });

            modelBuilder.Entity("GestionCitasMedicas.Entidades+Paciente", b =>
                {
                    b.Navigation("Citas");
                });
#pragma warning restore 612, 618
        }
    }
}
