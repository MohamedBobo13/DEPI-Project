using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineEducationPlatform.DAL.Migrations
{
    /// <inheritdoc />
    public partial class addisdeleted : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                nullable: true);

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Video");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
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
        }
    }
}
