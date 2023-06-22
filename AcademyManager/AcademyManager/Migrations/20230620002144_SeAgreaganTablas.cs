using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AcademyManager.Migrations
{
    /// <inheritdoc />
    public partial class SeAgreaganTablas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AcademyId",
                table: "Teachers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "Teachers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "Teachers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "Academies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Enabled = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Academies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clasrooms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<int>(type: "int", nullable: false),
                    AcademyId = table.Column<int>(type: "int", nullable: true),
                    Enabled = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clasrooms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clasrooms_Academies_AcademyId",
                        column: x => x.AcademyId,
                        principalTable: "Academies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AcademyId = table.Column<int>(type: "int", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    TeacherId = table.Column<int>(type: "int", nullable: false),
                    Enabled = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subjects_Academies_AcademyId",
                        column: x => x.AcademyId,
                        principalTable: "Academies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Section = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AcademyId = table.Column<int>(type: "int", nullable: false),
                    SubjectId = table.Column<int>(type: "int", nullable: false),
                    ClassroomId1 = table.Column<int>(type: "int", nullable: true),
                    Enabled = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Courses_Academies_AcademyId",
                        column: x => x.AcademyId,
                        principalTable: "Academies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Courses_Clasrooms_ClassroomId1",
                        column: x => x.ClassroomId1,
                        principalTable: "Clasrooms",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SubjectTeacher",
                columns: table => new
                {
                    SubjectsId = table.Column<int>(type: "int", nullable: false),
                    TeachersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubjectTeacher", x => new { x.SubjectsId, x.TeachersId });
                    table.ForeignKey(
                        name: "FK_SubjectTeacher_Subjects_SubjectsId",
                        column: x => x.SubjectsId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubjectTeacher_Teachers_TeachersId",
                        column: x => x.TeachersId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clasrooms_AcademyId",
                table: "Clasrooms",
                column: "AcademyId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_AcademyId",
                table: "Courses",
                column: "AcademyId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_ClassroomId1",
                table: "Courses",
                column: "ClassroomId1");

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_AcademyId",
                table: "Subjects",
                column: "AcademyId");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectTeacher_TeachersId",
                table: "SubjectTeacher",
                column: "TeachersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "SubjectTeacher");

            migrationBuilder.DropTable(
                name: "Clasrooms");

            migrationBuilder.DropTable(
                name: "Subjects");

            migrationBuilder.DropTable(
                name: "Academies");

            migrationBuilder.DropColumn(
                name: "AcademyId",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "Teachers");
        }
    }
}
