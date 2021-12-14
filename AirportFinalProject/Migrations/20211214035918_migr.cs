using Microsoft.EntityFrameworkCore.Migrations;

namespace AirportFinalProject.Migrations
{
    public partial class migr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: "ELA",
                column: "AirplanePath",
                value: "C:/Users/ZEN/source\repos/AirportFinalProject/AirportFinalProject/Assets/Iberia.jfif");

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: "luf",
                column: "AirplanePath",
                value: "C:/Users/ZEN/source\repos/AirportFinalProject/AirportFinalProject/Assets/Iberia.jfif");

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: "Ori",
                column: "AirplanePath",
                value: "C:/Users/ZEN/source\repos/AirportFinalProject/AirportFinalProject/Assets/Iberia.jfif");

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "StationId",
                keyValue: 1,
                column: "PhotoPath",
                value: "C:/Users/ZEN/source\repos/AirportFinalProject/AirportFinalProject/Assets/Iberia.jfif");

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "StationId",
                keyValue: 2,
                column: "PhotoPath",
                value: "C:/Users/ZEN/source\repos/AirportFinalProject/AirportFinalProject/Assets/Iberia.jfif");

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "StationId",
                keyValue: 3,
                column: "PhotoPath",
                value: "C:/Users/ZEN/source\repos/AirportFinalProject/AirportFinalProject/Assets/Iberia.jfif");

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "StationId",
                keyValue: 4,
                column: "PhotoPath",
                value: "C:/Users/ZEN/source\repos/AirportFinalProject/AirportFinalProject/Assets/Iberia.jfif");

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "StationId",
                keyValue: 5,
                column: "PhotoPath",
                value: "C:/Users/ZEN/source\repos/AirportFinalProject/AirportFinalProject/Assets/Iberia.jfif");

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "StationId",
                keyValue: 6,
                column: "PhotoPath",
                value: "C:/Users/ZEN/source\repos/AirportFinalProject/AirportFinalProject/Assets/Iberia.jfif");

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "StationId",
                keyValue: 7,
                column: "PhotoPath",
                value: "C:/Users/ZEN/source\repos/AirportFinalProject/AirportFinalProject/Assets/Iberia.jfif");

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "StationId",
                keyValue: 8,
                column: "PhotoPath",
                value: "C:/Users/ZEN/source\repos/AirportFinalProject/AirportFinalProject/Assets/Iberia.jfif");

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "StationId",
                keyValue: 9,
                column: "PhotoPath",
                value: "C:/Users/ZEN/source\repos/AirportFinalProject/AirportFinalProject/Assets/Iberia.jfif");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: "ELA",
                column: "AirplanePath",
                value: null);

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: "luf",
                column: "AirplanePath",
                value: null);

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: "Ori",
                column: "AirplanePath",
                value: null);

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "StationId",
                keyValue: 1,
                column: "PhotoPath",
                value: null);

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "StationId",
                keyValue: 2,
                column: "PhotoPath",
                value: null);

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "StationId",
                keyValue: 3,
                column: "PhotoPath",
                value: null);

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "StationId",
                keyValue: 4,
                column: "PhotoPath",
                value: null);

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "StationId",
                keyValue: 5,
                column: "PhotoPath",
                value: null);

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "StationId",
                keyValue: 6,
                column: "PhotoPath",
                value: null);

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "StationId",
                keyValue: 7,
                column: "PhotoPath",
                value: null);

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "StationId",
                keyValue: 8,
                column: "PhotoPath",
                value: null);

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "StationId",
                keyValue: 9,
                column: "PhotoPath",
                value: null);
        }
    }
}
