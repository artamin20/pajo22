using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pajo22.Migrations
{
    /// <inheritdoc />
    public partial class productremoval : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "newproduct");

            migrationBuilder.DropTable(
                name: "product2");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "newproduct",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubgroupId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    price = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_newproduct", x => x.Id);
                    table.ForeignKey(
                        name: "FK_newproduct_SubgroupModels_SubgroupId",
                        column: x => x.SubgroupId,
                        principalTable: "SubgroupModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "product2",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubgroupId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    price = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product2", x => x.Id);
                    table.ForeignKey(
                        name: "FK_product2_SubgroupModels_SubgroupId",
                        column: x => x.SubgroupId,
                        principalTable: "SubgroupModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_newproduct_SubgroupId",
                table: "newproduct",
                column: "SubgroupId");

            migrationBuilder.CreateIndex(
                name: "IX_product2_SubgroupId",
                table: "product2",
                column: "SubgroupId");
        }
    }
}
