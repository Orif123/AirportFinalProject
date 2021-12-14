using Microsoft.EntityFrameworkCore.Migrations;

namespace AirportFinalProject.Migrations
{
    public partial class Ima : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: "LUF");

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "CompanyId", "CompanyLogo", "CompanyName" },
                values: new object[] { "luf", "C:/Users/ZEN/source/repos/AirportFinalProject/AirportFinalProject/Assets/Lufthansa.png", "Lufthansa" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: "luf");

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "CompanyId", "CompanyLogo", "CompanyName" },
                values: new object[] { "LUF", "C:/Users/ZEN/source/repos/AirportFinalProject/AirportFinalProject/Assets/Lufthansa.png", "Lufthansa" });
        }
    }
}
