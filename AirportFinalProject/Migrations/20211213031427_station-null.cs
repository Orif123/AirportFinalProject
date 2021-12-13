using Microsoft.EntityFrameworkCore.Migrations;

namespace AirportFinalProject.Migrations
{
    public partial class stationnull : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flights_Stations_StationId",
                table: "Flights");

            migrationBuilder.DropIndex(
                name: "IX_Flights_StationId",
                table: "Flights");

            migrationBuilder.AlterColumn<int>(
                name: "StationId",
                table: "Flights",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flights_Stations_StationId",
                table: "Flights");

            migrationBuilder.DropIndex(
                name: "IX_Flights_StationId",
                table: "Flights");

            migrationBuilder.AlterColumn<int>(
                name: "StationId",
                table: "Flights",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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
    }
}
