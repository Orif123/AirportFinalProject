using Microsoft.EntityFrameworkCore.Migrations;

namespace AirportFinalProject.Migrations
{
    public partial class anotherentities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Stations",
                columns: new[] { "StationId", "FlightId", "StationName" },
                values: new object[] { 1, null, "kaki" });

            migrationBuilder.InsertData(
                table: "Stations",
                columns: new[] { "StationId", "FlightId", "StationName" },
                values: new object[] { 7, null, "kaki" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Stations",
                keyColumn: "StationId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Stations",
                keyColumn: "StationId",
                keyValue: 7);
        }
    }
}
