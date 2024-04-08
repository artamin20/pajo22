using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pajo22.Migrations
{
    /// <inheritdoc />
    public partial class AddDecimalPriceColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "ProductModels",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "ProductModels",
                keyColumn: "Id",
                keyValue: 278,
                column: "Price",
                value: 2300000m);

            migrationBuilder.UpdateData(
                table: "ProductModels",
                keyColumn: "Id",
                keyValue: 378,
                column: "Price",
                value: 4000000m);

            migrationBuilder.UpdateData(
                table: "ProductModels",
                keyColumn: "Id",
                keyValue: 478,
                column: "Price",
                value: 6000000m);

            migrationBuilder.UpdateData(
                table: "ProductModels",
                keyColumn: "Id",
                keyValue: 578,
                column: "Price",
                value: 1000000m);

            migrationBuilder.UpdateData(
                table: "ProductModels",
                keyColumn: "Id",
                keyValue: 678,
                column: "Price",
                value: 4000000m);

            migrationBuilder.UpdateData(
                table: "ProductModels",
                keyColumn: "Id",
                keyValue: 778,
                column: "Price",
                value: 64000000m);

            migrationBuilder.UpdateData(
                table: "ProductModels",
                keyColumn: "Id",
                keyValue: 878,
                column: "Price",
                value: 35000000m);

            migrationBuilder.UpdateData(
                table: "ProductModels",
                keyColumn: "Id",
                keyValue: 978,
                column: "Price",
                value: 48000000m);

            migrationBuilder.UpdateData(
                table: "ProductModels",
                keyColumn: "Id",
                keyValue: 1780,
                column: "Price",
                value: 45000000m);

            migrationBuilder.UpdateData(
                table: "ProductModels",
                keyColumn: "Id",
                keyValue: 1781,
                column: "Price",
                value: 12000000m);

            migrationBuilder.UpdateData(
                table: "ProductModels",
                keyColumn: "Id",
                keyValue: 8788,
                column: "Price",
                value: 95000000m);

            migrationBuilder.UpdateData(
                table: "ProductModels",
                keyColumn: "Id",
                keyValue: 8789,
                column: "Price",
                value: 86000000m);

            migrationBuilder.UpdateData(
                table: "ProductModels",
                keyColumn: "Id",
                keyValue: 17811,
                column: "Price",
                value: 13000000m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Price",
                table: "ProductModels",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.UpdateData(
                table: "ProductModels",
                keyColumn: "Id",
                keyValue: 278,
                column: "Price",
                value: 2300000);

            migrationBuilder.UpdateData(
                table: "ProductModels",
                keyColumn: "Id",
                keyValue: 378,
                column: "Price",
                value: 4000000);

            migrationBuilder.UpdateData(
                table: "ProductModels",
                keyColumn: "Id",
                keyValue: 478,
                column: "Price",
                value: 6000000);

            migrationBuilder.UpdateData(
                table: "ProductModels",
                keyColumn: "Id",
                keyValue: 578,
                column: "Price",
                value: 1000000);

            migrationBuilder.UpdateData(
                table: "ProductModels",
                keyColumn: "Id",
                keyValue: 678,
                column: "Price",
                value: 4000000);

            migrationBuilder.UpdateData(
                table: "ProductModels",
                keyColumn: "Id",
                keyValue: 778,
                column: "Price",
                value: 64000000);

            migrationBuilder.UpdateData(
                table: "ProductModels",
                keyColumn: "Id",
                keyValue: 878,
                column: "Price",
                value: 35000000);

            migrationBuilder.UpdateData(
                table: "ProductModels",
                keyColumn: "Id",
                keyValue: 978,
                column: "Price",
                value: 48000000);

            migrationBuilder.UpdateData(
                table: "ProductModels",
                keyColumn: "Id",
                keyValue: 1780,
                column: "Price",
                value: 45000000);

            migrationBuilder.UpdateData(
                table: "ProductModels",
                keyColumn: "Id",
                keyValue: 1781,
                column: "Price",
                value: 12000000);

            migrationBuilder.UpdateData(
                table: "ProductModels",
                keyColumn: "Id",
                keyValue: 8788,
                column: "Price",
                value: 95000000);

            migrationBuilder.UpdateData(
                table: "ProductModels",
                keyColumn: "Id",
                keyValue: 8789,
                column: "Price",
                value: 86000000);

            migrationBuilder.UpdateData(
                table: "ProductModels",
                keyColumn: "Id",
                keyValue: 17811,
                column: "Price",
                value: 13000000);
        }
    }
}
