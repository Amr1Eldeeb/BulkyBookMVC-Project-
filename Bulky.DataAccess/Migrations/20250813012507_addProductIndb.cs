using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Bulky.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addProductIndb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Categories",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ISBN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ListPrice = table.Column<double>(type: "float", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Price50 = table.Column<double>(type: "float", nullable: false),
                    Price100 = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Author", "Description", "ISBN", "ListPrice", "Price", "Price100", "Price50", "Title" },
                values: new object[,]
                {
                    { 1, "Amr ELdeeb", "No Now Pro", "7332", 80.0, 75.0, 65.0, 70.0, "Coffee Machine" },
                    { 2, "Sara Khaled", "Fast boil 1.7L", "4821", 50.0, 45.0, 35.0, 40.0, "Electric Kettle" },
                    { 3, "Mohamed Ali", "600W with glass jar", "9154", 120.0, 110.0, 90.0, 100.0, "Blender" },
                    { 4, "Omar Fathy", "20L compact microwave", "6723", 200.0, 190.0, 170.0, 180.0, "Microwave Oven" },
                    { 5, "Nour Hassan", "3.5L oil-free cooking", "8439", 150.0, 140.0, 120.0, 130.0, "Air Fryer" },
                    { 6, "Amr ELdeeb", "15 bar pump pressure", "2948", 250.0, 240.0, 220.0, 230.0, "Espresso Machine" },
                    { 7, "Ali Ahmed", "2-slice stainless steel", "3572", 40.0, 38.0, 32.0, 35.0, "Toaster" },
                    { 8, "Huda Samir", "1.8L automatic keep warm", "7810", 90.0, 85.0, 75.0, 80.0, "Rice Cooker" },
                    { 9, "Khaled Mansour", "5L bowl, 6-speed settings", "5264", 300.0, 290.0, 270.0, 280.0, "Stand Mixer" },
                    { 10, "Aya Adel", "Variable speed control", "6491", 60.0, 55.0, 45.0, 50.0, "Hand Blender" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);
        }
    }
}
