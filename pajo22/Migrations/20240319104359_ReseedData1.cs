using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace pajo22.Migrations
{
    /// <inheritdoc />
    public partial class ReseedData1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProductModels",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ProductModels",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ProductModels",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ProductModels",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ProductModels",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ProductModels",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "ProductModels",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "ProductModels",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "ProductModels",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "ProductModels",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "ProductModels",
                keyColumn: "Id",
                keyValue: 111);

            migrationBuilder.InsertData(
                table: "ProductModels",
                columns: new[] { "Id", "Color", "Description", "Image", "Name", "Price", "SubgroupId" },
                values: new object[,]
                {
                    { 27, "Blue", "flagship Samsung", "~/images/ph3.png", "سامسونگ Samsung S23", 2300000, 111 },
                    { 37, "Green", "it's iPhone, just buy it", "~/images/ph1.png", "Iphone 13 آیفون", 4000000, 111 },
                    { 47, "Green", "it's cheap, why not", "~/images/ph5.png", "Xiaomi Redmi شیائومی", 6000000, 111 },
                    { 57, "Green", "the classic from the past", "~/images/ph6.png", "Classic Gold Phone گوشی کلاسیک", 1000000, 111 },
                    { 67, "Green", "Iranian made cheap", "~/images/p7.png", "GPlus 128 gig جی پلاس", 4000000, 111 },
                    { 77, "Green", "Asus TUFF gaming", "~/images/f2.png", "Asus TUF Gaming ایسوس تاف", 64000000, 33 },
                    { 87, "black", "Acer regular laptop", "~/images/f3.png", "Acer Aspire ایسر", 35000000, 33 },
                    { 97, "black", "Lenovo gaming laptop", "~/images/f1.png", "Lenovo Legion لنوو", 48000000, 33 },
                    { 170, "black", "Snowa Iranian made washing machine", "~/images/a1.png", "Snowa اسنوا لباس شویی", 45000000, 22 },
                    { 171, "Green", "Snowa fridge", "~/images/a2.png", "Snowa اسنوا یخچال", 12000000, 22 },
                    { 1711, "gray", "mid-range Samsung", "~/images/ph6.png", "سامسونگ Samsung A54", 13000000, 111 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProductModels",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "ProductModels",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "ProductModels",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "ProductModels",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "ProductModels",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "ProductModels",
                keyColumn: "Id",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "ProductModels",
                keyColumn: "Id",
                keyValue: 87);

            migrationBuilder.DeleteData(
                table: "ProductModels",
                keyColumn: "Id",
                keyValue: 97);

            migrationBuilder.DeleteData(
                table: "ProductModels",
                keyColumn: "Id",
                keyValue: 170);

            migrationBuilder.DeleteData(
                table: "ProductModels",
                keyColumn: "Id",
                keyValue: 171);

            migrationBuilder.DeleteData(
                table: "ProductModels",
                keyColumn: "Id",
                keyValue: 1711);

            migrationBuilder.InsertData(
                table: "ProductModels",
                columns: new[] { "Id", "Color", "Description", "Image", "Name", "Price", "SubgroupId" },
                values: new object[,]
                {
                    { 2, "Blue", "flagship Samsung", "~/images/ph3.png", "سامسونگ Samsung S23", 2300000, 111 },
                    { 3, "Green", "it's iPhone, just buy it", "~/images/ph1.png", "Iphone 13 آیفون", 4000000, 111 },
                    { 4, "Green", "it's cheap, why not", "~/images/ph5.png", "Xiaomi Redmi شیائومی", 6000000, 111 },
                    { 5, "Green", "the classic from the past", "~/images/ph6.png", "Classic Gold Phone گوشی کلاسیک", 1000000, 111 },
                    { 6, "Green", "Iranian made cheap", "~/images/p7.png", "GPlus 128 gig جی پلاس", 4000000, 111 },
                    { 7, "Green", "Asus TUFF gaming", "~/images/f2.png", "Asus TUF Gaming ایسوس تاف", 64000000, 33 },
                    { 8, "black", "Acer regular laptop", "~/images/f3.png", "Acer Aspire ایسر", 35000000, 33 },
                    { 9, "black", "Lenovo gaming laptop", "~/images/f1.png", "Lenovo Legion لنوو", 48000000, 33 },
                    { 10, "black", "Snowa Iranian made washing machine", "~/images/a1.png", "Snowa اسنوا لباس شویی", 45000000, 22 },
                    { 11, "Green", "Snowa fridge", "~/images/a2.png", "Snowa اسنوا یخچال", 12000000, 22 },
                    { 111, "gray", "mid-range Samsung", "~/images/ph6.png", "سامسونگ Samsung A54", 13000000, 111 }
                });
        }
    }
}
