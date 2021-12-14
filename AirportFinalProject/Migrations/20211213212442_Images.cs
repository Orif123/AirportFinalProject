using Microsoft.EntityFrameworkCore.Migrations;

namespace AirportFinalProject.Migrations
{
    public partial class Images : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhotoPath",
                table: "Stations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhotoPath",
                table: "Flights",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: "Ori",
                column: "CompanyLogo",
                value: "C:/Users/ZEN/source/repos/AirportFinalProject/AirportFinalProject/Assets/Iberia.jfif");

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "CompanyId", "CompanyLogo", "CompanyName" },
                values: new object[] { "LUF", "C:/Users/ZEN/source/repos/AirportFinalProject/AirportFinalProject/Assets/Lufthansa.png", "Lufthansa" });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "CompanyId", "CompanyLogo", "CompanyName" },
                values: new object[] { "ELA", "C:/Users/ZEN/source/repos/AirportFinalProject/AirportFinalProject/Assets/EL AL.jpg", "ElAl" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: "ELA");

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: "LUF");

            migrationBuilder.DropColumn(
                name: "PhotoPath",
                table: "Stations");

            migrationBuilder.DropColumn(
                name: "PhotoPath",
                table: "Flights");

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: "Ori",
                column: "CompanyLogo",
                value: "Logo");
        }
    }
}
