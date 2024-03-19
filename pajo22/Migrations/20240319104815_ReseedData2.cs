using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pajo22.Migrations
{
    /// <inheritdoc />
    public partial class ReseedData2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ProductModels",
                keyColumn: "Id",
                keyValue: 27,
                column: "Image",
                value: "/images/ph3.png");

            migrationBuilder.UpdateData(
                table: "ProductModels",
                keyColumn: "Id",
                keyValue: 37,
                column: "Image",
                value: "/images/ph1.png");

            migrationBuilder.UpdateData(
                table: "ProductModels",
                keyColumn: "Id",
                keyValue: 47,
                column: "Image",
                value: "/images/ph5.png");

            migrationBuilder.UpdateData(
                table: "ProductModels",
                keyColumn: "Id",
                keyValue: 57,
                column: "Image",
                value: "/images/ph6.png");

            migrationBuilder.UpdateData(
                table: "ProductModels",
                keyColumn: "Id",
                keyValue: 67,
                column: "Image",
                value: "/images/p7.png");

            migrationBuilder.UpdateData(
                table: "ProductModels",
                keyColumn: "Id",
                keyValue: 87,
                column: "Image",
                value: "/images/f3.png");

            migrationBuilder.UpdateData(
                table: "ProductModels",
                keyColumn: "Id",
                keyValue: 97,
                column: "Image",
                value: "/images/f1.png");

            migrationBuilder.UpdateData(
                table: "ProductModels",
                keyColumn: "Id",
                keyValue: 170,
                column: "Image",
                value: "/images/a1.png");

            migrationBuilder.UpdateData(
                table: "ProductModels",
                keyColumn: "Id",
                keyValue: 171,
                column: "Image",
                value: "/images/a2.png");

            migrationBuilder.UpdateData(
                table: "ProductModels",
                keyColumn: "Id",
                keyValue: 1711,
                column: "Image",
                value: "/images/ph6.png");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ProductModels",
                keyColumn: "Id",
                keyValue: 27,
                column: "Image",
                value: "~/images/ph3.png");

            migrationBuilder.UpdateData(
                table: "ProductModels",
                keyColumn: "Id",
                keyValue: 37,
                column: "Image",
                value: "~/images/ph1.png");

            migrationBuilder.UpdateData(
                table: "ProductModels",
                keyColumn: "Id",
                keyValue: 47,
                column: "Image",
                value: "~/images/ph5.png");

            migrationBuilder.UpdateData(
                table: "ProductModels",
                keyColumn: "Id",
                keyValue: 57,
                column: "Image",
                value: "~/images/ph6.png");

            migrationBuilder.UpdateData(
                table: "ProductModels",
                keyColumn: "Id",
                keyValue: 67,
                column: "Image",
                value: "~/images/p7.png");

            migrationBuilder.UpdateData(
                table: "ProductModels",
                keyColumn: "Id",
                keyValue: 87,
                column: "Image",
                value: "~/images/f3.png");

            migrationBuilder.UpdateData(
                table: "ProductModels",
                keyColumn: "Id",
                keyValue: 97,
                column: "Image",
                value: "~/images/f1.png");

            migrationBuilder.UpdateData(
                table: "ProductModels",
                keyColumn: "Id",
                keyValue: 170,
                column: "Image",
                value: "~/images/a1.png");

            migrationBuilder.UpdateData(
                table: "ProductModels",
                keyColumn: "Id",
                keyValue: 171,
                column: "Image",
                value: "~/images/a2.png");

            migrationBuilder.UpdateData(
                table: "ProductModels",
                keyColumn: "Id",
                keyValue: 1711,
                column: "Image",
                value: "~/images/ph6.png");
        }
    }
}
