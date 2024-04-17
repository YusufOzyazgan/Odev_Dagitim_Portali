using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Odev_Dagitim_Portali.Migrations
{
    /// <inheritdoc />
    public partial class mig4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Homework_submissions_AspNetUsers_User_id",
                table: "Homework_submissions");

            migrationBuilder.DropForeignKey(
                name: "FK_Homework_submissions_Homeworks_Homework_id",
                table: "Homework_submissions");

            migrationBuilder.DropForeignKey(
                name: "FK_Homeworks_Lessons_Lesson_id",
                table: "Homeworks");

            migrationBuilder.DropForeignKey(
                name: "FK_Lessons_University_departments_Department_id",
                table: "Lessons");

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "Homeworks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Updated",
                table: "Homeworks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "Homework_submissions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Updated",
                table: "Homework_submissions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddForeignKey(
                name: "FK_Homework_submissions_AspNetUsers_User_id",
                table: "Homework_submissions",
                column: "User_id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Homework_submissions_Homeworks_Homework_id",
                table: "Homework_submissions",
                column: "Homework_id",
                principalTable: "Homeworks",
                principalColumn: "Homework_id",
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
                name: "FK_Homework_submissions_AspNetUsers_User_id",
                table: "Homework_submissions");

            migrationBuilder.DropForeignKey(
                name: "FK_Homework_submissions_Homeworks_Homework_id",
                table: "Homework_submissions");

            migrationBuilder.DropForeignKey(
                name: "FK_Homeworks_Lessons_Lesson_id",
                table: "Homeworks");

            migrationBuilder.DropForeignKey(
                name: "FK_Lessons_University_departments_Department_id",
                table: "Lessons");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "Homeworks");

            migrationBuilder.DropColumn(
                name: "Updated",
                table: "Homeworks");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "Homework_submissions");

            migrationBuilder.DropColumn(
                name: "Updated",
                table: "Homework_submissions");

            migrationBuilder.AddForeignKey(
                name: "FK_Homework_submissions_AspNetUsers_User_id",
                table: "Homework_submissions",
                column: "User_id",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Homework_submissions_Homeworks_Homework_id",
                table: "Homework_submissions",
                column: "Homework_id",
                principalTable: "Homeworks",
                principalColumn: "Homework_id");

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
