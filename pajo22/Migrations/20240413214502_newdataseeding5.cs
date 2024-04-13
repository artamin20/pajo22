using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace pajo22.Migrations
{
    /// <inheritdoc />
    public partial class newdataseeding5 : Migration
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

            migrationBuilder.InsertData(
                table: "GroupModels",
                columns: new[] { "Id", "Name", "Status" },
                values: new object[] { 323, "کالا های پوشیدنی", 0 });

            migrationBuilder.UpdateData(
                table: "ProductModels",
                keyColumn: "Id",
                keyValue: 1781,
                columns: new[] { "Color", "Description", "Image", "Name", "Price", "SubgroupId" },
                values: new object[] { "blue", "normal watch", "/images/ap2.png", "ساعت معمولی Q&Q", 2000000m, 36 });

            migrationBuilder.InsertData(
                table: "SubgroupModels",
                columns: new[] { "Id", "GroupID", "Name", "ParentSubGroupId", "Status" },
                values: new object[,]
                {
                    { 36, 323, "ساعت", null, 0 },
                    { 39, 323, "  عینک", null, 0 }
                });

            migrationBuilder.InsertData(
                table: "ProductModels",
                columns: new[] { "Id", "Color", "Description", "Image", "Name", "Price", "Status", "SubgroupId" },
                values: new object[] { 199, "black", "iconix glasses", "/images/RB1.png", "عینک کلاسیک rayban", 20000000m, 0, 39 });

            migrationBuilder.InsertData(
                table: "SubgroupModels",
                columns: new[] { "Id", "GroupID", "Name", "ParentSubGroupId", "Status" },
                values: new object[,]
                {
                    { 37, 323, "ساعت هوشمند", 36, 0 },
                    { 40, 323, "  عینک های rayban", 39, 0 },
                    { 38, 323, "  ساعت هوشمند اپل", 37, 0 }
                });

            migrationBuilder.InsertData(
                table: "ProductModels",
                columns: new[] { "Id", "Color", "Description", "Image", "Name", "Price", "Status", "SubgroupId" },
                values: new object[] { 1881, "orange", "apple smart watch", "/images/ap1.png", "apple watch ساعت اپل", 42000000m, 0, 38 });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductModels_SubgroupModels_SubgroupId",
                table: "ProductModels");

            migrationBuilder.DropForeignKey(
                name: "FK_SubgroupModels_SubgroupModels_ParentSubGroupId",
                table: "SubgroupModels");

            migrationBuilder.DeleteData(
                table: "ProductModels",
                keyColumn: "Id",
                keyValue: 199);

            migrationBuilder.DeleteData(
                table: "ProductModels",
                keyColumn: "Id",
                keyValue: 1881);

            migrationBuilder.DeleteData(
                table: "SubgroupModels",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "SubgroupModels",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "SubgroupModels",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "SubgroupModels",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "SubgroupModels",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "GroupModels",
                keyColumn: "Id",
                keyValue: 323);

            migrationBuilder.UpdateData(
                table: "ProductModels",
                keyColumn: "Id",
                keyValue: 1781,
                columns: new[] { "Color", "Description", "Image", "Name", "Price", "SubgroupId" },
                values: new object[] { "Green", "Snowa fridge", "/images/a2.png", "Snowa اسنوا یخچال", 12000000m, 22 });

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
    }
}
