﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pajo22.Migrations
{
    /// <inheritdoc />
    public partial class Updatenullableproduct10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "newproduct",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    price = table.Column<int>(type: "int", nullable: true),
                    Image = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubgroupId = table.Column<int>(type: "int", nullable: false)
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

            migrationBuilder.CreateIndex(
                name: "IX_newproduct_SubgroupId",
                table: "newproduct",
                column: "SubgroupId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "newproduct");
        }
    }
}
