using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AcademyManager.Migrations
{
    /// <inheritdoc />
    public partial class Relacion_Academy_Teacher_1aN : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Teachers_AcademyId",
                table: "Teachers",
                column: "AcademyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_Academies_AcademyId",
                table: "Teachers",
                column: "AcademyId",
                principalTable: "Academies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_Academies_AcademyId",
                table: "Teachers");

            migrationBuilder.DropIndex(
                name: "IX_Teachers_AcademyId",
                table: "Teachers");
        }
    }
}
