using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace pajo22.Migrations
{
    /// <inheritdoc />
    public partial class newseeding1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ProductModels",
                columns: new[] { "Id", "Color", "Description", "Image", "Name", "Price", "SubgroupId" },
                values: new object[,]
                {
                    { 8788, "black", "msi expensive laptop", "/images/f33.png", "لپ تاپ 15.6 اینچی ام اس آی مدل Katana 15 B12VEK", 95000000, 33 },
                    { 8789, "black", "macbook from apple ", "/images/f43.png", "لپ تاپ 14.2 اینچی اپل مدل MacBook Pro MTL73 2023-M3 8GB 512SSD", 86000000, 33 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProductModels",
                keyColumn: "Id",
                keyValue: 8788);

            migrationBuilder.DeleteData(
                table: "ProductModels",
                keyColumn: "Id",
                keyValue: 8789);
        }
    }
}
