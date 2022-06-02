using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyContactManagerData.Migrations
{
    public partial class StateandContactsMigrationSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "Id", "Abbreviation", "Name" },
                values: new object[,]
                {
                    { 1, "AT", "Attica" },
                    { 2, "AC", "Achaia" },
                    { 3, "TH", "Thessaloniki" },
                    { 4, "IR", "Irakleiou" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
