using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Odev_Dagitim_Portali.Migrations
{
    /// <inheritdoc />
    public partial class mig2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_University_departments_Department_id",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens");

            migrationBuilder.DropForeignKey(
                name: "FK_Homeworks_AspNetUsers_User_id",
                table: "Homeworks");

            migrationBuilder.DropForeignKey(
                name: "FK_Homeworks_Lessons_Lesson_id",
                table: "Homeworks");

            migrationBuilder.DropForeignKey(
                name: "FK_Lessons_University_departments_Department_id",
                table: "Lessons");

            migrationBuilder.AddColumn<string>(
                name: "Department_name",
                table: "University_departments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_University_departments_Department_id",
                table: "AspNetUsers",
                column: "Department_id",
                principalTable: "University_departments",
                principalColumn: "Department_id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Homeworks_AspNetUsers_User_id",
                table: "Homeworks",
                column: "User_id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Homeworks_Lessons_Lesson_id",
                table: "Homeworks",
                column: "Lesson_id",
                principalTable: "Lessons",
                principalColumn: "Lesson_id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Lessons_University_departments_Department_id",
                table: "Lessons",
                column: "Department_id",
                principalTable: "University_departments",
                principalColumn: "Department_id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_University_departments_Department_id",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens");

            migrationBuilder.DropForeignKey(
                name: "FK_Homeworks_AspNetUsers_User_id",
                table: "Homeworks");

            migrationBuilder.DropForeignKey(
                name: "FK_Homeworks_Lessons_Lesson_id",
                table: "Homeworks");

            migrationBuilder.DropForeignKey(
                name: "FK_Lessons_University_departments_Department_id",
                table: "Lessons");

            migrationBuilder.DropColumn(
                name: "Department_name",
                table: "University_departments");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_University_departments_Department_id",
                table: "AspNetUsers",
                column: "Department_id",
                principalTable: "University_departments",
                principalColumn: "Department_id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Homeworks_AspNetUsers_User_id",
                table: "Homeworks",
                column: "User_id",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Homeworks_Lessons_Lesson_id",
                table: "Homeworks",
                column: "Lesson_id",
                principalTable: "Lessons",
                principalColumn: "Lesson_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Lessons_University_departments_Department_id",
                table: "Lessons",
                column: "Department_id",
                principalTable: "University_departments",
                principalColumn: "Department_id");
        }
    }
}
