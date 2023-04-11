using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DCT1205.Presistence.Migrations
{
    /// <inheritdoc />
    public partial class InitDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateJoined = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Designation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NationalInsuranceNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaymentMethod = table.Column<int>(type: "int", nullable: false),
                    StudentLoan = table.Column<int>(type: "int", nullable: false),
                    UnionMember = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Postcode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TaxYear",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    YearOfTax = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxYear", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PaymentRecord",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    TaxYearId = table.Column<int>(type: "int", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NiNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PayDated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PayMonth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TaxCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HourlyRated = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    HourlyWorked = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    OvertimeHours = table.Column<decimal>(type: "money", nullable: false),
                    ContractualEarnings = table.Column<decimal>(type: "money", nullable: false),
                    OvertimeEarnings = table.Column<decimal>(type: "money", nullable: false),
                    Tax = table.Column<decimal>(type: "money", nullable: false),
                    NIC = table.Column<decimal>(type: "money", nullable: false),
                    UnionFees = table.Column<decimal>(type: "money", nullable: false),
                    SLC = table.Column<decimal>(type: "money", nullable: true),
                    TotalsEarnings = table.Column<decimal>(type: "money", nullable: false),
                    TotalsDeductions = table.Column<decimal>(type: "money", nullable: false),
                    NetPayment = table.Column<decimal>(type: "money", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentRecord", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PaymentRecord_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PaymentRecord_TaxYear_TaxYearId",
                        column: x => x.TaxYearId,
                        principalTable: "TaxYear",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PaymentRecord_EmployeeId",
                table: "PaymentRecord",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentRecord_TaxYearId",
                table: "PaymentRecord",
                column: "TaxYearId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PaymentRecord");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "TaxYear");
        }
    }
}
