using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pajo22.Migrations
{
    /// <inheritdoc />
    public partial class deletesystem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductModels_SubgroupModels_SubgroupId",
                table: "ProductModels");

            migrationBuilder.DropForeignKey(
                name: "FK_SubgroupModels_SubgroupModels_ParentSubGroupId",
                table: "SubgroupModels");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductModels_SubgroupModels_SubgroupId",
                table: "ProductModels",
                column: "SubgroupId",
                principalTable: "SubgroupModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SubgroupModels_SubgroupModels_ParentSubGroupId",
                table: "SubgroupModels",
                column: "ParentSubGroupId",
                principalTable: "SubgroupModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductModels_SubgroupModels_SubgroupId",
                table: "ProductModels");

            migrationBuilder.DropForeignKey(
                name: "FK_SubgroupModels_SubgroupModels_ParentSubGroupId",
                table: "SubgroupModels");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductModels_SubgroupModels_SubgroupId",
                table: "ProductModels",
                column: "SubgroupId",
                principalTable: "SubgroupModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubgroupModels_SubgroupModels_ParentSubGroupId",
                table: "SubgroupModels",
                column: "ParentSubGroupId",
                principalTable: "SubgroupModels",
                principalColumn: "Id");
        }
    }
}
