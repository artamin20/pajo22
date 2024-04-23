using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace pajo22.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GroupModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubgroupModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GroupID = table.Column<int>(type: "int", nullable: false),
                    ParentSubGroupId = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubgroupModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubgroupModels_GroupModels_GroupID",
                        column: x => x.GroupID,
                        principalTable: "GroupModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubgroupModels_SubgroupModels_ParentSubGroupId",
                        column: x => x.ParentSubGroupId,
                        principalTable: "SubgroupModels",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Attributes",
                columns: table => new
                {
                    AttributeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AttributeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubgroupId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attributes", x => x.AttributeID);
                    table.ForeignKey(
                        name: "FK_Attributes_SubgroupModels_SubgroupId",
                        column: x => x.SubgroupId,
                        principalTable: "SubgroupModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubgroupId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductModels_SubgroupModels_SubgroupId",
                        column: x => x.SubgroupId,
                        principalTable: "SubgroupModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AttributeValues",
                columns: table => new
                {
                    AttributeValueID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AttributeID = table.Column<int>(type: "int", nullable: false),
                    ProductModelId = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AttributesAttributeID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttributeValues", x => x.AttributeValueID);
                    table.ForeignKey(
                        name: "FK_AttributeValues_Attributes_AttributeID",
                        column: x => x.AttributeID,
                        principalTable: "Attributes",
                        principalColumn: "AttributeID");
                    table.ForeignKey(
                        name: "FK_AttributeValues_Attributes_AttributesAttributeID",
                        column: x => x.AttributesAttributeID,
                        principalTable: "Attributes",
                        principalColumn: "AttributeID");
                    table.ForeignKey(
                        name: "FK_AttributeValues_ProductModels_ProductModelId",
                        column: x => x.ProductModelId,
                        principalTable: "ProductModels",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "GroupModels",
                columns: new[] { "Id", "Name", "Status" },
                values: new object[,]
                {
                    { 22, "لوازم خانگی", 0 },
                    { 111, "کالا های دیجیتال", 0 },
                    { 323, "کالا های پوشیدنی", 0 }
                });

            migrationBuilder.InsertData(
                table: "SubgroupModels",
                columns: new[] { "Id", "GroupID", "Name", "ParentSubGroupId", "Status" },
                values: new object[,]
                {
                    { 22, 22, "ماشین لباس شویی", null, 0 },
                    { 33, 111, "لب تاب", null, 0 },
                    { 36, 323, "ساعت", null, 0 },
                    { 39, 323, "  عینک", null, 0 },
                    { 111, 111, "گوشی موبایل", null, 0 }
                });

            migrationBuilder.InsertData(
                table: "ProductModels",
                columns: new[] { "Id", "Color", "Description", "Image", "Name", "Price", "Status", "SubgroupId" },
                values: new object[,]
                {
                    { 199, "black", "iconix glasses", "/images/RB1.png", "عینک کلاسیک rayban", 20000000m, 0, 39 },
                    { 278, "Blue", "flagship Samsung", "/images/ph3.png", "سامسونگ Samsung S23", 2300000m, 0, 111 },
                    { 378, "Green", "it's iPhone, just buy it", "/images/ph1.png", "Iphone 13 آیفون", 4000000m, 0, 111 },
                    { 478, "Green", "it's cheap, why not", "/images/ph5.png", "Xiaomi Redmi شیائومی", 6000000m, 0, 111 },
                    { 578, "Green", "the classic from the past", "/images/ph6.png", "Classic Gold Phone گوشی کلاسیک", 1000000m, 0, 111 },
                    { 678, "Green", "Iranian made cheap", "/images/p7.png", "GPlus 128 gig جی پلاس", 4000000m, 0, 111 },
                    { 778, "Green", "Asus TUFF gaming", "~/images/f2.png", "Asus TUF Gaming ایسوس تاف", 64000000m, 0, 33 },
                    { 878, "black", "Acer regular laptop", "/images/f3.png", "Acer Aspire ایسر", 35000000m, 0, 33 },
                    { 978, "black", "Lenovo gaming laptop", "/images/f1.png", "Lenovo Legion لنوو", 48000000m, 0, 33 },
                    { 1780, "black", "Snowa Iranian made washing machine", "/images/a1.png", "Snowa اسنوا لباس شویی", 45000000m, 0, 22 },
                    { 1781, "blue", "normal watch", "/images/ap2.png", "ساعت معمولی Q&Q", 2000000m, 0, 36 },
                    { 8788, "black", "msi expensive laptop", "/images/f33.png", "لپ تاپ 15.6 اینچی ام اس آی مدل Katana 15 B12VEK", 95000000m, 0, 33 },
                    { 8789, "black", "macbook from apple ", "/images/f43.png", "لپ تاپ 14.2 اینچی اپل مدل MacBook Pro MTL73 2023-M3 8GB 512SSD", 86000000m, 0, 33 },
                    { 17811, "gray", "mid-range Samsung", "/images/ph6.png", "سامسونگ Samsung A54", 13000000m, 0, 111 }
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Attributes_SubgroupId",
                table: "Attributes",
                column: "SubgroupId");

            migrationBuilder.CreateIndex(
                name: "IX_AttributeValues_AttributeID",
                table: "AttributeValues",
                column: "AttributeID");

            migrationBuilder.CreateIndex(
                name: "IX_AttributeValues_AttributesAttributeID",
                table: "AttributeValues",
                column: "AttributesAttributeID");

            migrationBuilder.CreateIndex(
                name: "IX_AttributeValues_ProductModelId",
                table: "AttributeValues",
                column: "ProductModelId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductModels_SubgroupId",
                table: "ProductModels",
                column: "SubgroupId");

            migrationBuilder.CreateIndex(
                name: "IX_SubgroupModels_GroupID",
                table: "SubgroupModels",
                column: "GroupID");

            migrationBuilder.CreateIndex(
                name: "IX_SubgroupModels_ParentSubGroupId",
                table: "SubgroupModels",
                column: "ParentSubGroupId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AttributeValues");

            migrationBuilder.DropTable(
                name: "Attributes");

            migrationBuilder.DropTable(
                name: "ProductModels");

            migrationBuilder.DropTable(
                name: "SubgroupModels");

            migrationBuilder.DropTable(
                name: "GroupModels");
        }
    }
}
