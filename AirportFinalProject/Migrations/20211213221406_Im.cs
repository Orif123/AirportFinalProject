using Microsoft.EntityFrameworkCore.Migrations;

namespace AirportFinalProject.Migrations
{
    public partial class Im : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhotoPath",
                table: "Flights");

            migrationBuilder.AddColumn<string>(
                name: "AirplanePath",
                table: "Stations",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AirplanePath",
                table: "Stations");

            migrationBuilder.AddColumn<string>(
                name: "PhotoPath",
                table: "Flights",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
