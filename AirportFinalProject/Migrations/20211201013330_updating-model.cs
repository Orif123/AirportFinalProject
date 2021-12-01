using Microsoft.EntityFrameworkCore.Migrations;

namespace AirportFinalProject.Migrations
{
    public partial class updatingmodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Stations",
                keyColumn: "StationId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Stations",
                keyColumn: "StationId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Stations",
                keyColumn: "StationId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Stations",
                keyColumn: "StationId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Stations",
                keyColumn: "StationId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Stations",
                keyColumn: "StationId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Stations",
                keyColumn: "StationId",
                keyValue: 7);

            migrationBuilder.InsertData(
                table: "Stations",
                columns: new[] { "StationId", "FlightId", "StationName" },
                values: new object[,]
                {
                    { 1, null, "kaki" },
                    { 2, null, "Hara" },
                    { 3, null, "Shilshul" },
                    { 4, null, "Schnitzel" },
                    { 5, null, "Pitzel" },
                    { 6, null, "Ori" },
                    { 7, null, "Pipi" }
                });
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
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Stations",
                keyColumn: "StationId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Stations",
                keyColumn: "StationId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Stations",
                keyColumn: "StationId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Stations",
                keyColumn: "StationId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Stations",
                keyColumn: "StationId",
                keyValue: 7);

            migrationBuilder.InsertData(
                table: "Stations",
                columns: new[] { "StationId", "FlightId", "StationName" },
                values: new object[,]
                {
                    { 1, null, "kaki" },
                    { 2, null, "Hara" },
                    { 3, null, "Shilshul" },
                    { 4, null, "Schnitzel" },
                    { 5, null, "Pitzel" },
                    { 6, null, "Ori" },
                    { 7, null, "Pipi" }
                });
        }
    }
}
