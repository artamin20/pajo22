using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pajo22.Migrations
{
    /// <inheritdoc />
    public partial class newsubgroups : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ParentSubGroupId",
                table: "SubgroupModels",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "SubgroupModels",
                keyColumn: "Id",
                keyValue: 22,
                column: "ParentSubGroupId",
                value: null);

            migrationBuilder.UpdateData(
                table: "SubgroupModels",
                keyColumn: "Id",
                keyValue: 33,
                column: "ParentSubGroupId",
                value: null);

            migrationBuilder.UpdateData(
                table: "SubgroupModels",
                keyColumn: "Id",
                keyValue: 111,
                column: "ParentSubGroupId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_SubgroupModels_ParentSubGroupId",
                table: "SubgroupModels",
                column: "ParentSubGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_SubgroupModels_SubgroupModels_ParentSubGroupId",
                table: "SubgroupModels",
                column: "ParentSubGroupId",
                principalTable: "SubgroupModels",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubgroupModels_SubgroupModels_ParentSubGroupId",
                table: "SubgroupModels");

            migrationBuilder.DropIndex(
                name: "IX_SubgroupModels_ParentSubGroupId",
                table: "SubgroupModels");

            migrationBuilder.DropColumn(
                name: "ParentSubGroupId",
                table: "SubgroupModels");
        }
    }
}
