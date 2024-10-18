using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineEducationPlatform.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddIsDeletedColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExamResult_StudentProgress_StudentProgressId",
                table: "ExamResult");

            migrationBuilder.DropForeignKey(
                name: "FK_QuizResult_StudentProgress_StudentProgressId",
                table: "QuizResult");

            migrationBuilder.DropTable(
                name: "StudentProgress");

            migrationBuilder.DropIndex(
                name: "IX_QuizResult_StudentProgressId",
                table: "QuizResult");

            migrationBuilder.DropIndex(
                name: "IX_ExamResult_StudentProgressId",
                table: "ExamResult");

            migrationBuilder.DropIndex(
                name: "IX_Enrollment_StudentId",
                table: "Enrollment");

            migrationBuilder.DropColumn(
                name: "StudentProgressId",
                table: "QuizResult");

            migrationBuilder.DropColumn(
                name: "StudentProgressId",
                table: "ExamResult");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Video",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "QuizResult",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "StudentId",
                table: "QuizResult",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Quiz",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Question",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "PdfFile",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Lecture",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ExamResult",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "StudentId",
                table: "ExamResult",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Exam",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Enrollment",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Course",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "AnswerResult",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Answer",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_QuizResult_StudentId_QuizId",
                table: "QuizResult",
                columns: new[] { "StudentId", "QuizId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExamResult_StudentId_ExamId",
                table: "ExamResult",
                columns: new[] { "StudentId", "ExamId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Enrollment_StudentId_CourseId",
                table: "Enrollment",
                columns: new[] { "StudentId", "CourseId" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ExamResult_AspNetUsers_StudentId",
                table: "ExamResult",
                column: "StudentId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QuizResult_AspNetUsers_StudentId",
                table: "QuizResult",
                column: "StudentId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExamResult_AspNetUsers_StudentId",
                table: "ExamResult");

            migrationBuilder.DropForeignKey(
                name: "FK_QuizResult_AspNetUsers_StudentId",
                table: "QuizResult");

            migrationBuilder.DropIndex(
                name: "IX_QuizResult_StudentId_QuizId",
                table: "QuizResult");

            migrationBuilder.DropIndex(
                name: "IX_ExamResult_StudentId_ExamId",
                table: "ExamResult");

            migrationBuilder.DropIndex(
                name: "IX_Enrollment_StudentId_CourseId",
                table: "Enrollment");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Video");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "QuizResult");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "QuizResult");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Quiz");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Question");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "PdfFile");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Lecture");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ExamResult");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "ExamResult");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Exam");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Enrollment");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "AnswerResult");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Answer");

            migrationBuilder.AddColumn<int>(
                name: "StudentProgressId",
                table: "QuizResult",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StudentProgressId",
                table: "ExamResult",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "StudentProgress",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    EnrollmentId = table.Column<int>(type: "int", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LectureId = table.Column<int>(type: "int", nullable: true),
                    OverallProgress = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentProgress", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentProgress_Course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentProgress_Enrollment_EnrollmentId",
                        column: x => x.EnrollmentId,
                        principalTable: "Enrollment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentProgress_Lecture_LectureId",
                        column: x => x.LectureId,
                        principalTable: "Lecture",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_QuizResult_StudentProgressId",
                table: "QuizResult",
                column: "StudentProgressId");

            migrationBuilder.CreateIndex(
                name: "IX_ExamResult_StudentProgressId",
                table: "ExamResult",
                column: "StudentProgressId");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollment_StudentId",
                table: "Enrollment",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentProgress_CourseId",
                table: "StudentProgress",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentProgress_EnrollmentId",
                table: "StudentProgress",
                column: "EnrollmentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StudentProgress_LectureId",
                table: "StudentProgress",
                column: "LectureId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExamResult_StudentProgress_StudentProgressId",
                table: "ExamResult",
                column: "StudentProgressId",
                principalTable: "StudentProgress",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_QuizResult_StudentProgress_StudentProgressId",
                table: "QuizResult",
                column: "StudentProgressId",
                principalTable: "StudentProgress",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
