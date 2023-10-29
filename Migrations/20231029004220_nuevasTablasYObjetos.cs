using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace API_ProyectoP1_Gimnasio_ProgramacionIV.Migrations
{
    /// <inheritdoc />
    public partial class nuevasTablasYObjetos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "caducidadTarjeta",
                table: "Pago",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "cvvTarjeta",
                table: "Pago",
                type: "nvarchar(4)",
                maxLength: 4,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "numeroTarjeta",
                table: "Pago",
                type: "nvarchar(19)",
                maxLength: 19,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "tipoTarjeta",
                table: "Pago",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "titularTarjeta",
                table: "Pago",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "idMembresia",
                table: "Miembro",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Membresia",
                columns: new[] { "idMembresia", "duracionMembresia", "nombreMembresia", "precioMembresia" },
                values: new object[,]
                {
                    { 1, 12, "Membresia Oro", 100.0 },
                    { 2, 6, "Membresia Plata", 60.0 },
                    { 3, 3, "Membresia Bronce", 30.0 }
                });

            migrationBuilder.UpdateData(
                table: "Miembro",
                keyColumn: "idMiembro",
                keyValue: 1,
                columns: new[] { "fechaInscripcion", "idMembresia" },
                values: new object[] { new DateTime(2024, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 });

            migrationBuilder.UpdateData(
                table: "Miembro",
                keyColumn: "idMiembro",
                keyValue: 2,
                columns: new[] { "fechaInscripcion", "idMembresia" },
                values: new object[] { new DateTime(2024, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 });

            migrationBuilder.InsertData(
                table: "Pago",
                columns: new[] { "idPago", "caducidadTarjeta", "cvvTarjeta", "fechaPago", "miembroId", "montoPago", "numeroTarjeta", "tipoTarjeta", "titularTarjeta" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "123", new DateTime(2023, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 193.0, "123456789048000", "Mastercard", "Diego Toscano" },
                    { 2, new DateTime(2024, 6, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "321", new DateTime(2023, 6, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 200.0, "123456789048975", "Visa", "Steeven Teran" }
                });

            migrationBuilder.InsertData(
                table: "Visita",
                columns: new[] { "idVisita", "descripcionVisita", "fechaVisita", "miembroId" },
                values: new object[,]
                {
                    { 1, "Descp Visita 1", new DateTime(2023, 11, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 2, "Descp Visita 2", new DateTime(2023, 11, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 3, "Descp Visita 3", new DateTime(2023, 11, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Miembro_idMembresia",
                table: "Miembro",
                column: "idMembresia");

            migrationBuilder.AddForeignKey(
                name: "FK_Miembro_Membresia_idMembresia",
                table: "Miembro",
                column: "idMembresia",
                principalTable: "Membresia",
                principalColumn: "idMembresia",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Miembro_Membresia_idMembresia",
                table: "Miembro");

            migrationBuilder.DropIndex(
                name: "IX_Miembro_idMembresia",
                table: "Miembro");

            migrationBuilder.DeleteData(
                table: "Membresia",
                keyColumn: "idMembresia",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Membresia",
                keyColumn: "idMembresia",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Membresia",
                keyColumn: "idMembresia",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Pago",
                keyColumn: "idPago",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Pago",
                keyColumn: "idPago",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Visita",
                keyColumn: "idVisita",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Visita",
                keyColumn: "idVisita",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Visita",
                keyColumn: "idVisita",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "caducidadTarjeta",
                table: "Pago");

            migrationBuilder.DropColumn(
                name: "cvvTarjeta",
                table: "Pago");

            migrationBuilder.DropColumn(
                name: "numeroTarjeta",
                table: "Pago");

            migrationBuilder.DropColumn(
                name: "tipoTarjeta",
                table: "Pago");

            migrationBuilder.DropColumn(
                name: "titularTarjeta",
                table: "Pago");

            migrationBuilder.DropColumn(
                name: "idMembresia",
                table: "Miembro");

            migrationBuilder.UpdateData(
                table: "Miembro",
                keyColumn: "idMiembro",
                keyValue: 1,
                column: "fechaInscripcion",
                value: new DateTime(2023, 10, 24, 19, 44, 22, 649, DateTimeKind.Local).AddTicks(914));

            migrationBuilder.UpdateData(
                table: "Miembro",
                keyColumn: "idMiembro",
                keyValue: 2,
                column: "fechaInscripcion",
                value: new DateTime(2023, 10, 24, 19, 44, 22, 649, DateTimeKind.Local).AddTicks(930));
        }
    }
}
