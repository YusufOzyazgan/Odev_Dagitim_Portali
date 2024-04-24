using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Odev_Dagitim_Portali.Migrations
{
    /// <inheritdoc />
    public partial class mig6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_University_departments_Department_id",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_Homework_submissions_User_id",
                table: "Homework_submissions");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_Department_id",
                table: "AspNetUsers");

            migrationBuilder.CreateTable(
                name: "AppUserUniversity_department",
                columns: table => new
                {
                    AppUsersId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    University_departmentsDepartment_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserUniversity_department", x => new { x.AppUsersId, x.University_departmentsDepartment_id });
                    table.ForeignKey(
                        name: "FK_AppUserUniversity_department_AspNetUsers_AppUsersId",
                        column: x => x.AppUsersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_AppUserUniversity_department_University_departments_University_departmentsDepartment_id",
                        column: x => x.University_departmentsDepartment_id,
                        principalTable: "University_departments",
                        principalColumn: "Department_id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Homework_submissions_User_id",
                table: "Homework_submissions",
                column: "User_id");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserUniversity_department_University_departmentsDepartment_id",
                table: "AppUserUniversity_department",
                column: "University_departmentsDepartment_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppUserUniversity_department");

            migrationBuilder.DropIndex(
                name: "IX_Homework_submissions_User_id",
                table: "Homework_submissions");

            migrationBuilder.CreateIndex(
                name: "IX_Homework_submissions_User_id",
                table: "Homework_submissions",
                column: "User_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_Department_id",
                table: "AspNetUsers",
                column: "Department_id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_University_departments_Department_id",
                table: "AspNetUsers",
                column: "Department_id",
                principalTable: "University_departments",
                principalColumn: "Department_id",
                onDelete: ReferentialAction.NoAction);
        }
    }
}
