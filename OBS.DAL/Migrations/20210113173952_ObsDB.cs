using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OBS.DAL.Migrations
{
    public partial class ObsDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Obs");

            migrationBuilder.CreateTable(
                name: "Tbl_Login",
                schema: "Obs",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserName = table.Column<string>(maxLength: 150, nullable: false),
                    Password = table.Column<string>(maxLength: 150, nullable: false),
                    LastLogin = table.Column<DateTime>(maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Login", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Students",
                schema: "Obs",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    NameSurname = table.Column<string>(maxLength: 150, nullable: false),
                    Grade = table.Column<int>(nullable: false),
                    StudentNumber = table.Column<string>(nullable: true),
                    RegiteredDate = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Students", x => x.Id);
                });
            migrationBuilder.CreateTable(
                name: "Tbl_Teacher",
                schema: "Obs",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    NameSurname = table.Column<string>(maxLength: 150, nullable: false),
                    Tag = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Teacher", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Lessons",
                schema: "Obs",
                columns: table => new
                {
                    LessonId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 150, nullable: false),
                    Code = table.Column<string>(nullable: true),
                    TeacherId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Lessons", x => x.LessonId);
                    table.ForeignKey(
                        name: "FK_Tbl_Lessons_Tbl_Teacher_TeacherId",
                        column: x => x.TeacherId,
                        principalSchema: "Obs",
                        principalTable: "Tbl_Teacher",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_ExamGrade",
                schema: "Obs",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    StudentId = table.Column<Guid>(nullable: true),
                    LessonId = table.Column<Guid>(nullable: true),
                    Vize = table.Column<int>(nullable: false),
                    Final = table.Column<int>(nullable: false),
                    Average = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_ExamGrade", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tbl_ExamGrade_Tbl_Lessons_LessonId",
                        column: x => x.LessonId,
                        principalSchema: "Obs",
                        principalTable: "Tbl_Lessons",
                        principalColumn: "LessonId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tbl_ExamGrade_Tbl_Students_StudentId",
                        column: x => x.StudentId,
                        principalSchema: "Obs",
                        principalTable: "Tbl_Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Lessons_Student",
                schema: "Obs",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    StudentId = table.Column<Guid>(nullable: true),
                    LessonId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Lessons_Student", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tbl_Lessons_Student_Tbl_Lessons_LessonId",
                        column: x => x.LessonId,
                        principalSchema: "Obs",
                        principalTable: "Tbl_Lessons",
                        principalColumn: "LessonId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tbl_Lessons_Student_Tbl_Students_StudentId",
                        column: x => x.StudentId,
                        principalSchema: "Obs",
                        principalTable: "Tbl_Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_ExamGrade_LessonId",
                schema: "Obs",
                table: "Tbl_ExamGrade",
                column: "LessonId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_ExamGrade_StudentId",
                schema: "Obs",
                table: "Tbl_ExamGrade",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Lessons_TeacherId",
                schema: "Obs",
                table: "Tbl_Lessons",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Lessons_Student_LessonId",
                schema: "Obs",
                table: "Tbl_Lessons_Student",
                column: "LessonId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Lessons_Student_StudentId",
                schema: "Obs",
                table: "Tbl_Lessons_Student",
                column: "StudentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tbl_ExamGrade",
                schema: "Obs");

            migrationBuilder.DropTable(
                name: "Tbl_Lessons_Student",
                schema: "Obs");

            migrationBuilder.DropTable(
                name: "Tbl_Login",
                schema: "Obs");

            migrationBuilder.DropTable(
                name: "Tbl_Lessons",
                schema: "Obs");

            migrationBuilder.DropTable(
                name: "Tbl_Students",
                schema: "Obs");

            migrationBuilder.DropTable(
                name: "Tbl_Teacher",
                schema: "Obs");
        }
    }
}
