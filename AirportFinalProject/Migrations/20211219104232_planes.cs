using Microsoft.EntityFrameworkCore.Migrations;

namespace AirportFinalProject.Migrations
{
    public partial class planes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: "Ori");

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "CompanyId", "AirplanePath", "CompanyLogo", "CompanyName" },
                values: new object[,]
                {
                    { "Ind", "C:/Users/ZEN/source/repos/AirportFinalProject/AirportFinalProject/Assets/png-transparent-boeing-737-next-generation-boeing-787-dreamliner-boeing-777-boeing-c-32-boeing-767-air-india-mode-of-transport-flight-airplane.png", "C:/Users/ZEN/source/repos/AirportFinalProject/AirportFinalProject/Assets/Air India.png", "Air India" },
                    { "Bri", "C:/Users/ZEN/source/repos/AirportFinalProject/AirportFinalProject/Assets/png-clipart-boeing-737-next-generation-boeing-767-airplane-boeing-777-boeing-787-dreamliner-france-flights-flight-fundal.png", "C:/Users/ZEN/source/repos/AirportFinalProject/AirportFinalProject/Assets/British-Airways-Logo-1997-present.jpg", "British Airways" },
                    { "Wiz", "C:/Users/ZEN/source/repos/AirportFinalProject/AirportFinalProject/Assets/png-transparent-airplane-flight-david-the-builder-kutaisi-international-airport-wizz-air-air-travel-airport-transfer-transport-vehicle-volaris-thumbnail.png", "C:/Users/ZEN/source/repos/AirportFinalProject/AirportFinalProject/Assets/WizzAir.png", "Wizzair" },
                    { "Fly", "C:/Users/ZEN/source/repos/AirportFinalProject/AirportFinalProject/Assets/png-clipart-boeing-737-next-generation-boeing-777-airbus-a380-airbus-a330-boeing-767-emirates-airline-mode-of-transport-airplane.png", "C:/Users/ZEN/source/repos/AirportFinalProject/AirportFinalProject/Assets/Emirates.png", "Emirates" },
                    { "Uni", "C:/Users/ZEN/source/repos/AirportFinalProject/AirportFinalProject/Assets/united-airlines-png-download-wide-body-aircraft-11562996046xxkz9rk4h2.png", "C:/Users/ZEN/source/repos/AirportFinalProject/AirportFinalProject/Assets/UnitedLogo.png", "United" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: "Bri");

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: "Fly");

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: "Ind");

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: "Uni");

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: "Wiz");

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "CompanyId", "AirplanePath", "CompanyLogo", "CompanyName" },
                values: new object[] { "Ori", "C:/Users/ZEN/source/repos/AirportFinalProject/AirportFinalProject/Assets/Lufthansa.png", "C:/Users/ZEN/source/repos/AirportFinalProject/AirportFinalProject/Assets/Iberia.jfif", "Iberia" });
        }
    }
}
