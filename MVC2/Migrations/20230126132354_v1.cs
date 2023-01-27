using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC2.Migrations
{
    /// <inheritdoc />
    public partial class v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Number = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    startdate = table.Column<DateTime>(type: "date", nullable: true),
                    employeeSSN = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Number);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    SSN = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Minit = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Lname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Bdate = table.Column<DateTime>(type: "date", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Salary = table.Column<decimal>(type: "money", nullable: true),
                    super = table.Column<int>(type: "int", nullable: true),
                    Department2Number = table.Column<int>(type: "int", nullable: true),
                    deptid = table.Column<int>(type: "int", nullable: true),
                    employeeSSN = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.SSN);
                    table.ForeignKey(
                        name: "FK_Employees_Departments_Department2Number",
                        column: x => x.Department2Number,
                        principalTable: "Departments",
                        principalColumn: "Number");
                    table.ForeignKey(
                        name: "FK_Employees_Employees_employeeSSN",
                        column: x => x.employeeSSN,
                        principalTable: "Employees",
                        principalColumn: "SSN");
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    location = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    deptnum = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => new { x.deptnum, x.location });
                    table.ForeignKey(
                        name: "FK_Locations_Departments_deptnum",
                        column: x => x.deptnum,
                        principalTable: "Departments",
                        principalColumn: "Number",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Number = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Location = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DepartmentNumber = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Number);
                    table.ForeignKey(
                        name: "FK_Projects_Departments_DepartmentNumber",
                        column: x => x.DepartmentNumber,
                        principalTable: "Departments",
                        principalColumn: "Number");
                });

            migrationBuilder.CreateTable(
                name: "Dependents",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ESSN = table.Column<int>(type: "int", nullable: false),
                    Sex = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Birthdate = table.Column<DateTime>(type: "date", nullable: true),
                    Relationship = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dependents", x => new { x.Name, x.ESSN });
                    table.ForeignKey(
                        name: "FK_Dependents_Employees_ESSN",
                        column: x => x.ESSN,
                        principalTable: "Employees",
                        principalColumn: "SSN",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Works",
                columns: table => new
                {
                    ESSN = table.Column<int>(type: "int", nullable: false),
                    Pnum = table.Column<int>(type: "int", nullable: false),
                    Hours = table.Column<int>(type: "int", nullable: true),
                    ProjectNumber = table.Column<int>(type: "int", nullable: true),
                    EmployeeSSN = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Works", x => new { x.ESSN, x.Pnum });
                    table.ForeignKey(
                        name: "FK_Works_Employees_EmployeeSSN",
                        column: x => x.EmployeeSSN,
                        principalTable: "Employees",
                        principalColumn: "SSN");
                    table.ForeignKey(
                        name: "FK_Works_Projects_ProjectNumber",
                        column: x => x.ProjectNumber,
                        principalTable: "Projects",
                        principalColumn: "Number");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Departments_employeeSSN",
                table: "Departments",
                column: "employeeSSN",
                unique: true,
                filter: "[employeeSSN] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Dependents_ESSN",
                table: "Dependents",
                column: "ESSN");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_Department2Number",
                table: "Employees",
                column: "Department2Number");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_employeeSSN",
                table: "Employees",
                column: "employeeSSN");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_DepartmentNumber",
                table: "Projects",
                column: "DepartmentNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Works_EmployeeSSN",
                table: "Works",
                column: "EmployeeSSN");

            migrationBuilder.CreateIndex(
                name: "IX_Works_ProjectNumber",
                table: "Works",
                column: "ProjectNumber");

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Employees_employeeSSN",
                table: "Departments",
                column: "employeeSSN",
                principalTable: "Employees",
                principalColumn: "SSN");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Employees_employeeSSN",
                table: "Departments");

            migrationBuilder.DropTable(
                name: "Dependents");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "Works");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
