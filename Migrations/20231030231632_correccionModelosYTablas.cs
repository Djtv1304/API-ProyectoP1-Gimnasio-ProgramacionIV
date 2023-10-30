using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_ProyectoP1_Gimnasio_ProgramacionIV.Migrations
{
    /// <inheritdoc />
    public partial class correccionModelosYTablas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Miembro_Membresia_idMembresia",
                table: "Miembro");

            migrationBuilder.DropIndex(
                name: "IX_Miembro_idMembresia",
                table: "Miembro");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
