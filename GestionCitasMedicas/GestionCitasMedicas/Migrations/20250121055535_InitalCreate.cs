﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionCitasMedicas.Migrations
{
    public partial class InitalCreate : Migration
    {
        // Definir constantes para evitar duplicación de literales
        private const string SqlServerIdentity = "SqlServer:Identity";
        private const string Nvarchar100 = "nvarchar(100)";
        private const string TableCitas = "Citas";

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Doctores",
                columns: table => new
                {
                    IdDoctor = table.Column<int>(type: "int", nullable: false)
                        .Annotation(SqlServerIdentity, "1, 1"),
                    Nombre = table.Column<string>(type: Nvarchar100, maxLength: 100, nullable: false),
                    Especialidad = table.Column<string>(type: Nvarchar100, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctores", x => x.IdDoctor);
                });

            migrationBuilder.CreateTable(
                name: "Pacientes",
                columns: table => new
                {
                    IdPaciente = table.Column<int>(type: "int", nullable: false)
                        .Annotation(SqlServerIdentity, "1, 1"),
                    Nombre = table.Column<string>(type: Nvarchar100, maxLength: 100, nullable: false),
                    Apellido = table.Column<string>(type: Nvarchar100, maxLength: 100, nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacientes", x => x.IdPaciente);
                });

            migrationBuilder.CreateTable(
                name: TableCitas,
                columns: table => new
                {
                    IdCita = table.Column<int>(type: "int", nullable: false)
                        .Annotation(SqlServerIdentity, "1, 1"),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdPaciente = table.Column<int>(type: "int", nullable: false),
                    IdDoctor = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Citas", x => x.IdCita);
                    table.ForeignKey(
                        name: "FK_Citas_Doctores_IdDoctor",
                        column: x => x.IdDoctor,
                        principalTable: "Doctores",
                        principalColumn: "IdDoctor",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Citas_Pacientes_IdPaciente",
                        column: x => x.IdPaciente,
                        principalTable: "Pacientes",
                        principalColumn: "IdPaciente",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Procedimientos",
                columns: table => new
                {
                    IdProcedimiento = table.Column<int>(type: "int", nullable: false)
                        .Annotation(SqlServerIdentity, "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Costo = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    IdCita = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Procedimientos", x => x.IdProcedimiento);
                    table.ForeignKey(
                        name: "FK_Procedimientos_Citas_IdCita",
                        column: x => x.IdCita,
                        principalTable: TableCitas,
                        principalColumn: "IdCita",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Citas_IdDoctor",
                table: TableCitas,
                column: "IdDoctor");

            migrationBuilder.CreateIndex(
                name: "IX_Citas_IdPaciente",
                table: TableCitas,
                column: "IdPaciente");

            migrationBuilder.CreateIndex(
                name: "IX_Procedimientos_IdCita",
                table: "Procedimientos",
                column: "IdCita");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Procedimientos");

            migrationBuilder.DropTable(
                name: TableCitas);

            migrationBuilder.DropTable(
                name: "Doctores");

            migrationBuilder.DropTable(
                name: "Pacientes");
        }
    }
}
