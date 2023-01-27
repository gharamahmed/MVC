using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC2.Migrations
{
    /// <inheritdoc />
    public partial class v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Departments_DepartmentNumber",
                table: "Projects");

            migrationBuilder.RenameColumn(
                name: "DepartmentNumber",
                table: "Projects",
                newName: "DepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Projects_DepartmentNumber",
                table: "Projects",
                newName: "IX_Projects_DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Departments_DepartmentId",
                table: "Projects",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Number");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Departments_DepartmentId",
                table: "Projects");

            migrationBuilder.RenameColumn(
                name: "DepartmentId",
                table: "Projects",
                newName: "DepartmentNumber");

            migrationBuilder.RenameIndex(
                name: "IX_Projects_DepartmentId",
                table: "Projects",
                newName: "IX_Projects_DepartmentNumber");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Departments_DepartmentNumber",
                table: "Projects",
                column: "DepartmentNumber",
                principalTable: "Departments",
                principalColumn: "Number");
        }
    }
}
