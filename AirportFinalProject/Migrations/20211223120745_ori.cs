using Microsoft.EntityFrameworkCore.Migrations;

namespace AirportFinalProject.Migrations
{
    public partial class ori : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "StationId",
                keyValue: 1,
                column: "PhotoPath",
                value: "C:/Users/ZEN/source/repos/AirportFinalProject/AirportFinalProject/Assets/1-Number-PNG.png");

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "StationId",
                keyValue: 2,
                column: "PhotoPath",
                value: "C:/Users/ZEN/source/repos/AirportFinalProject/AirportFinalProject/Assets/2-Number-PNG.png");

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "StationId",
                keyValue: 3,
                column: "PhotoPath",
                value: "C:/Users/ZEN/source/repos/AirportFinalProject/AirportFinalProject/Assets/3-Number-PNG.png");

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "StationId",
                keyValue: 4,
                column: "PhotoPath",
                value: "C:/Users/ZEN/source/repos/AirportFinalProject/AirportFinalProject/Assets/4-Number-PNG.png");

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "StationId",
                keyValue: 5,
                column: "PhotoPath",
                value: "C:/Users/ZEN/source/repos/AirportFinalProject/AirportFinalProject/Assets/5-Number-PNG.png");

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "StationId",
                keyValue: 6,
                column: "PhotoPath",
                value: "C:/Users/ZEN/source/repos/AirportFinalProject/AirportFinalProject/Assets/6-Number-PNG.png");

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "StationId",
                keyValue: 7,
                column: "PhotoPath",
                value: "C:/Users/ZEN/source/repos/AirportFinalProject/AirportFinalProject/Assets/7-Number-PNG.png");

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "StationId",
                keyValue: 8,
                column: "PhotoPath",
                value: "C:/Users/ZEN/source/repos/AirportFinalProject/AirportFinalProject/Assets/8-Number-PNG.png");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "StationId",
                keyValue: 5,
                column: "PhotoPath",
                value: "C:/Users/ZEN/source/repos/AirportFinalProject/AirportFinalProject/Assets/Iberia.jfif");

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "StationId",
                keyValue: 6,
                column: "PhotoPath",
                value: "C:/Users/ZEN/source/repos/AirportFinalProject/AirportFinalProject/Assets/Iberia.jfif");

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "StationId",
                keyValue: 7,
                column: "PhotoPath",
                value: "C:/Users/ZEN/source/repos/AirportFinalProject/AirportFinalProject/Assets/Iberia.jfif");

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "StationId",
                keyValue: 8,
                column: "PhotoPath",
                value: "C:/Users/ZEN/source/repos/AirportFinalProject/AirportFinalProject/Assets/Iberia.jfif");
        }
    }
}
