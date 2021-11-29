using Microsoft.EntityFrameworkCore.Migrations;

namespace AirportFinalProject.Migrations
{
    public partial class addentities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "CompanyId", "CompanyLogo", "CompanyName" },
                values: new object[] { "Ori", "Logo", "Iberia" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: "Ori");
        }
    }
}
