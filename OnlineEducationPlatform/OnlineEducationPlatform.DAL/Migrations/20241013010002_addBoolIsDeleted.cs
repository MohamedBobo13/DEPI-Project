using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineEducationPlatform.DAL.Migrations
{
    /// <inheritdoc />
    public partial class addBoolIsDeleted : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Course_AspNetUsers_InstructorId",
                table: "Course");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Video",
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

            migrationBuilder.AlterColumn<string>(
                name: "InstructorId",
                table: "Course",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Course",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_Course_AspNetUsers_InstructorId",
                table: "Course",
                column: "InstructorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Course_AspNetUsers_InstructorId",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Video");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "PdfFile");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Lecture");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Course");

            migrationBuilder.AlterColumn<string>(
                name: "InstructorId",
                table: "Course",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_Course_AspNetUsers_InstructorId",
                table: "Course",
                column: "InstructorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
