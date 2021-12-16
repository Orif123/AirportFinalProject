using Microsoft.EntityFrameworkCore.Migrations;

namespace AirportFinalProject.Migrations
{
    public partial class o : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: "ELA",
                column: "AirplanePath",
                value: "C:/Users/ZEN/source/repos/AirportFinalProject/AirportFinalProject/Assets/Lufthansa.png");

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: "luf",
                column: "AirplanePath",
                value: "C:/Users/ZEN/source/repos/AirportFinalProject/AirportFinalProject/Assets/Lufthansa.png");

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: "Ori",
                column: "AirplanePath",
                value: "C:/Users/ZEN/source/repos/AirportFinalProject/AirportFinalProject/Assets/Lufthansa.png");

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "StationId",
                keyValue: 1,
                column: "PhotoPath",
                value: "C:/Users/ZEN/source/repos/AirportFinalProject/AirportFinalProject/Assets/Lufthansa.png");

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "StationId",
                keyValue: 2,
                column: "PhotoPath",
                value: "C:/Users/ZEN/source/repos/AirportFinalProject/AirportFinalProject/Assets/Lufthansa.png");

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "StationId",
                keyValue: 3,
                column: "PhotoPath",
                value: "C:/Users/ZEN/source/repos/AirportFinalProject/AirportFinalProject/Assets/Lufthansa.png");

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "StationId",
                keyValue: 4,
                column: "PhotoPath",
                value: "C:/Users/ZEN/source/repos/AirportFinalProject/AirportFinalProject/Assets/Lufthansa.png");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: "ELA",
                column: "AirplanePath",
                value: "C:/Users/ZEN/source/repos/AirportFinalProject/AirportFinalProject/Assets/Iberia.jfif");

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: "luf",
                column: "AirplanePath",
                value: "C:/Users/ZEN/source/repos/AirportFinalProject/AirportFinalProject/Assets/Iberia.jfif");

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: "Ori",
                column: "AirplanePath",
                value: "C:/Users/ZEN/source/repos/AirportFinalProject/AirportFinalProject/Assets/Iberia.jfif");

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "StationId",
                keyValue: 1,
                column: "PhotoPath",
                value: "C:/Users/ZEN/source/repos/AirportFinalProject/AirportFinalProject/Assets/Iberia.jfif");

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "StationId",
                keyValue: 2,
                column: "PhotoPath",
                value: "C:/Users/ZEN/source/repos/AirportFinalProject/AirportFinalProject/Assets/Iberia.jfif");

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "StationId",
                keyValue: 3,
                column: "PhotoPath",
                value: "C:/Users/ZEN/source/repos/AirportFinalProject/AirportFinalProject/Assets/Iberia.jfif");

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "StationId",
                keyValue: 4,
                column: "PhotoPath",
                value: "C:/Users/ZEN/source/repos/AirportFinalProject/AirportFinalProject/Assets/Iberia.jfif");
        }
    }
}
