using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Bulky.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addsedingdatOfproduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Author", "CategoryId", "Description", "ISBN", "ListPrice", "Price", "Price100", "Price50", "Title" },
                values: new object[,]
                {
                    { 1, "Coffee Experts Co.", 1, "Specialized machine for cold brew coffee", "CM-1011", 150.0, 140.0, 120.0, 130.0, "Cold Brew Coffee Maker" },
                    { 2, "Coffee Experts Co.", 2, "Classic French press with stainless steel plunger", "CM-1012", 80.0, 75.0, 65.0, 70.0, "French Press Coffee Set" },
                    { 3, "Coffee Experts Co.", 3, "Coffee machine with built-in smart grinder", "CM-1013", 500.0, 480.0, 440.0, 460.0, "Smart Grinder Coffee Machine" },
                    { 4, "Coffee Experts Co.", 1, "Handheld espresso machine for coffee on the go", "CM-1014", 90.0, 85.0, 75.0, 80.0, "Portable Espresso Maker" },
                    { 5, "Coffee Experts Co.", 2, "Machine designed for barista practice and training", "CM-1015", 650.0, 620.0, 580.0, 600.0, "Barista Training Coffee Machine" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
