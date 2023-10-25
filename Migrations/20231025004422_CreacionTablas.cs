using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace API_ProyectoP1_Gimnasio_ProgramacionIV.Migrations
{
    /// <inheritdoc />
    public partial class CreacionTablas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Membresia",
                columns: table => new
                {
                    idMembresia = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombreMembresia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    duracionMembresia = table.Column<int>(type: "int", nullable: false),
                    precioMembresia = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Membresia", x => x.idMembresia);
                });

            migrationBuilder.CreateTable(
                name: "Miembro",
                columns: table => new
                {
                    idMiembro = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombreMiembro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    apellidoMiembro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    emailMiembro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fechaInscripcion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Miembro", x => x.idMiembro);
                });

            migrationBuilder.CreateTable(
                name: "Pago",
                columns: table => new
                {
                    idPago = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    miembroId = table.Column<int>(type: "int", nullable: false),
                    fechaPago = table.Column<DateTime>(type: "datetime2", nullable: false),
                    montoPago = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pago", x => x.idPago);
                });

            migrationBuilder.CreateTable(
                name: "Visita",
                columns: table => new
                {
                    idVisita = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fechaVisita = table.Column<DateTime>(type: "datetime2", nullable: false),
                    miembroId = table.Column<int>(type: "int", nullable: false),
                    descripcionVisita = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visita", x => x.idVisita);
                });

            migrationBuilder.InsertData(
                table: "Miembro",
                columns: new[] { "idMiembro", "apellidoMiembro", "emailMiembro", "fechaInscripcion", "nombreMiembro" },
                values: new object[,]
                {
                    { 1, "Almeida", "oscar.almedia@udla.edu.ec", new DateTime(2023, 10, 24, 19, 44, 22, 649, DateTimeKind.Local).AddTicks(914), "Oscar" },
                    { 2, "Toscano", "diego.toscano@udla.edu.ec", new DateTime(2023, 10, 24, 19, 44, 22, 649, DateTimeKind.Local).AddTicks(930), "Diego" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Membresia");

            migrationBuilder.DropTable(
                name: "Miembro");

            migrationBuilder.DropTable(
                name: "Pago");

            migrationBuilder.DropTable(
                name: "Visita");
        }
    }
}
