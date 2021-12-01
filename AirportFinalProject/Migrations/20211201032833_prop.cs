using Microsoft.EntityFrameworkCore.Migrations;

namespace AirportFinalProject.Migrations
{
    public partial class prop : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flights_Stations_StationId",
                table: "Flights");

            migrationBuilder.DropIndex(
                name: "IX_Flights_StationId",
                table: "Flights");

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

            migrationBuilder.AlterColumn<int>(
                name: "StationId",
                table: "Flights",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Stations",
                columns: new[] { "StationId", "FlightId", "StationName" },
                values: new object[,]
                {
                    { 1, null, "Garage" },
                    { 2, null, "Last Preperation" },
                    { 3, null, "Terminal" },
                    { 4, null, "Taking off" },
                    { 5, null, "Done" },
                    { 6, null, "Landing" },
                    { 7, null, "About to land" },
                    { 8, null, "preparing to land" },
                    { 9, null, "On Air" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Flights_StationId",
                table: "Flights",
                column: "StationId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Flights_Stations_StationId",
                table: "Flights",
                column: "StationId",
                principalTable: "Stations",
                principalColumn: "StationId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flights_Stations_StationId",
                table: "Flights");

            migrationBuilder.DropIndex(
                name: "IX_Flights_StationId",
                table: "Flights");

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

            migrationBuilder.DeleteData(
                table: "Stations",
                keyColumn: "StationId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Stations",
                keyColumn: "StationId",
                keyValue: 9);

            migrationBuilder.AlterColumn<int>(
                name: "StationId",
                table: "Flights",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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

            migrationBuilder.CreateIndex(
                name: "IX_Flights_StationId",
                table: "Flights",
                column: "StationId",
                unique: true,
                filter: "[StationId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Flights_Stations_StationId",
                table: "Flights",
                column: "StationId",
                principalTable: "Stations",
                principalColumn: "StationId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
