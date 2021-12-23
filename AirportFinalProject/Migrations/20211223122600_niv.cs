using Microsoft.EntityFrameworkCore.Migrations;

namespace AirportFinalProject.Migrations
{
    public partial class niv : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: "luf",
                column: "AirplanePath",
                value: "C:/Users/ZEN/source/repos/AirportFinalProject/AirportFinalProject/Assets/png-clipart-boeing-737-next-generation-boeing-767-airplane-boeing-777-boeing-787-dreamliner-france-flights-flight-fundal.png");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: "luf",
                column: "AirplanePath",
                value: "C:/Users/ZEN/source/repos/AirportFinalProject/AirportFinalProject/Assets/Lufthansa.png");
        }
    }
}
