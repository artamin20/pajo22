using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pajo22.Migrations
{
    /// <inheritdoc />
    public partial class SeedData1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "price",
                table: "ProductModels",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "image",
                table: "ProductModels",
                newName: "Image");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Price",
                table: "ProductModels",
                newName: "price");

            migrationBuilder.RenameColumn(
                name: "Image",
                table: "ProductModels",
                newName: "image");
        }
    }
}
