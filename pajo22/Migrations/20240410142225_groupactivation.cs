using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pajo22.Migrations
{
    /// <inheritdoc />
    public partial class groupactivation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "SubgroupModels",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "ProductModels",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "GroupModels",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "GroupModels",
                keyColumn: "Id",
                keyValue: 22,
                column: "Status",
                value: 0);

            migrationBuilder.UpdateData(
                table: "GroupModels",
                keyColumn: "Id",
                keyValue: 111,
                column: "Status",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ProductModels",
                keyColumn: "Id",
                keyValue: 278,
                column: "Status",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ProductModels",
                keyColumn: "Id",
                keyValue: 378,
                column: "Status",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ProductModels",
                keyColumn: "Id",
                keyValue: 478,
                column: "Status",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ProductModels",
                keyColumn: "Id",
                keyValue: 578,
                column: "Status",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ProductModels",
                keyColumn: "Id",
                keyValue: 678,
                column: "Status",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ProductModels",
                keyColumn: "Id",
                keyValue: 778,
                column: "Status",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ProductModels",
                keyColumn: "Id",
                keyValue: 878,
                column: "Status",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ProductModels",
                keyColumn: "Id",
                keyValue: 978,
                column: "Status",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ProductModels",
                keyColumn: "Id",
                keyValue: 1780,
                column: "Status",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ProductModels",
                keyColumn: "Id",
                keyValue: 1781,
                column: "Status",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ProductModels",
                keyColumn: "Id",
                keyValue: 8788,
                column: "Status",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ProductModels",
                keyColumn: "Id",
                keyValue: 8789,
                column: "Status",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ProductModels",
                keyColumn: "Id",
                keyValue: 17811,
                column: "Status",
                value: 0);

            migrationBuilder.UpdateData(
                table: "SubgroupModels",
                keyColumn: "Id",
                keyValue: 22,
                column: "Status",
                value: 0);

            migrationBuilder.UpdateData(
                table: "SubgroupModels",
                keyColumn: "Id",
                keyValue: 33,
                column: "Status",
                value: 0);

            migrationBuilder.UpdateData(
                table: "SubgroupModels",
                keyColumn: "Id",
                keyValue: 111,
                column: "Status",
                value: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "SubgroupModels");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "ProductModels");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "GroupModels");
        }
    }
}
