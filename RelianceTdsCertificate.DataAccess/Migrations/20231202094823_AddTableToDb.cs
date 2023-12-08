using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RelianceTdsCertificate.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddTableToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LoginInfo",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeePanNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    EmployeeName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EmployeeRole = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EmployeeEmailId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoginInfo", x => x.EmployeeId);
                });

            migrationBuilder.CreateTable(
                name: "OtpInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeePanNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HashedOTP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpirationTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OtpInfo", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OtpInfo_EmployeePanNumber",
                table: "OtpInfo",
                column: "EmployeePanNumber",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LoginInfo");

            migrationBuilder.DropTable(
                name: "OtpInfo");
        }
    }
}
