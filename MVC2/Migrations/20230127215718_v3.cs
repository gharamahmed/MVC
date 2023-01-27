using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC2.Migrations
{
    /// <inheritdoc />
    public partial class v3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Works_Employees_EmployeeSSN",
                table: "Works");

            migrationBuilder.DropForeignKey(
                name: "FK_Works_Projects_ProjectNumber",
                table: "Works");

            migrationBuilder.DropIndex(
                name: "IX_Works_EmployeeSSN",
                table: "Works");

            migrationBuilder.DropIndex(
                name: "IX_Works_ProjectNumber",
                table: "Works");

            migrationBuilder.DropColumn(
                name: "EmployeeSSN",
                table: "Works");

            migrationBuilder.DropColumn(
                name: "ProjectNumber",
                table: "Works");

            migrationBuilder.CreateIndex(
                name: "IX_Works_Pnum",
                table: "Works",
                column: "Pnum");

            migrationBuilder.AddForeignKey(
                name: "FK_Works_Employees_ESSN",
                table: "Works",
                column: "ESSN",
                principalTable: "Employees",
                principalColumn: "SSN",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Works_Projects_Pnum",
                table: "Works",
                column: "Pnum",
                principalTable: "Projects",
                principalColumn: "Number",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Works_Employees_ESSN",
                table: "Works");

            migrationBuilder.DropForeignKey(
                name: "FK_Works_Projects_Pnum",
                table: "Works");

            migrationBuilder.DropIndex(
                name: "IX_Works_Pnum",
                table: "Works");

            migrationBuilder.AddColumn<int>(
                name: "EmployeeSSN",
                table: "Works",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProjectNumber",
                table: "Works",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Works_EmployeeSSN",
                table: "Works",
                column: "EmployeeSSN");

            migrationBuilder.CreateIndex(
                name: "IX_Works_ProjectNumber",
                table: "Works",
                column: "ProjectNumber");

            migrationBuilder.AddForeignKey(
                name: "FK_Works_Employees_EmployeeSSN",
                table: "Works",
                column: "EmployeeSSN",
                principalTable: "Employees",
                principalColumn: "SSN");

            migrationBuilder.AddForeignKey(
                name: "FK_Works_Projects_ProjectNumber",
                table: "Works",
                column: "ProjectNumber",
                principalTable: "Projects",
                principalColumn: "Number");
        }
    }
}
