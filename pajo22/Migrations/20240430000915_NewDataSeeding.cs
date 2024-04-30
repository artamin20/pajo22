using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace pajo22.Migrations
{
    /// <inheritdoc />
    public partial class NewDataSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Attributes",
                columns: new[] { "AttributeID", "AttributeName", "SubgroupId" },
                values: new object[,]
                {
                    { 111, "os", 111 },
                    { 112, "Storage Capacity", 111 },
                    { 113, "Screen Size", 111 },
                    { 114, "Load Capacity", 22 },
                    { 115, "Energy Efficiency", 22 },
                    { 116, "Operating System", 33 },
                    { 117, "Battery Life", 33 },
                    { 118, "Material", 36 },
                    { 119, "Water Resistance", 37 },
                    { 1110, "Lens Type", 39 },
                    { 1111, "Processor Speed", 111 },
                    { 1112, "RAM Size", 111 },
                    { 1113, "Camera Resolution", 111 },
                    { 1114, "Washing Capacity", 22 },
                    { 1115, "Spin Speed", 22 },
                    { 1116, "Graphics Card", 33 },
                    { 1117, "Display Resolution", 33 },
                    { 1118, "Strap Material", 36 },
                    { 1119, "Operating System Compatibility", 37 },
                    { 1120, "Frame Material", 39 }
                });

            migrationBuilder.InsertData(
                table: "AttributeValues",
                columns: new[] { "AttributeValueID", "AttributeID", "AttributesAttributeID", "ProductModelId", "Value" },
                values: new object[,]
                {
                    { 111, 111, null, 17811, "Android" },
                    { 112, 112, null, 17811, "128GB" },
                    { 113, 113, null, 17811, "6.4 inches" },
                    { 114, 111, null, 278, "Android" },
                    { 115, 112, null, 278, "256GB" },
                    { 116, 113, null, 278, "6.7 inches" },
                    { 117, 111, null, 378, "iOS" },
                    { 118, 112, null, 378, "256GB" },
                    { 119, 113, null, 378, "6.1 inches" },
                    { 1110, 111, null, 478, "Android" },
                    { 1111, 112, null, 478, "64GB" },
                    { 1112, 113, null, 478, "6.3 inches" },
                    { 1113, 111, null, 578, "Android" },
                    { 1114, 112, null, 578, "32GB" },
                    { 1115, 113, null, 578, "5.5 inches" },
                    { 1116, 111, null, 678, "Android" },
                    { 1117, 112, null, 678, "128GB" },
                    { 1118, 113, null, 678, "6.2 inches" },
                    { 1119, 111, null, 778, "Windows 10" },
                    { 1120, 112, null, 778, "512GB SSD" },
                    { 1121, 113, null, 778, "15.6 inches" },
                    { 1122, 114, null, 1780, "8kg" },
                    { 1123, 115, null, 1780, "1200 RPM" },
                    { 1124, 114, null, 1781, "NA" },
                    { 1125, 115, null, 1781, "NA" },
                    { 1126, 116, null, 1881, "watchOS" },
                    { 1127, 117, null, 1881, "Up to 18 hours" },
                    { 1128, 118, null, 199, "Metal" },
                    { 1129, 119, null, 199, "UV Protection" },
                    { 1130, 1110, null, 199, "Plastic" },
                    { 1131, 1111, null, 17811, "2.3 GHz" },
                    { 1132, 1112, null, 17811, "6GB" },
                    { 1133, 1113, null, 17811, "48 MP" },
                    { 1134, 1114, null, 1780, "10kg" },
                    { 1135, 1115, null, 1780, "1400 RPM" },
                    { 1136, 1116, null, 778, "NVIDIA GeForce RTX 3070" },
                    { 1137, 1117, null, 778, "1920 x 1080 pixels" },
                    { 1138, 1118, null, 1781, "Stainless Steel" },
                    { 1139, 1119, null, 1881, "iOS 15" },
                    { 1140, 1120, null, 1881, "Aluminum" },
                    { 1141, 1110, null, 199, "Glass" },
                    { 1142, 1111, null, 278, "2.8 GHz" },
                    { 1143, 1112, null, 278, "8GB" },
                    { 1144, 1113, null, 278, "64 MP" },
                    { 1145, 1114, null, 1781, "NA" },
                    { 1146, 1115, null, 1781, "NA" },
                    { 1147, 1116, null, 878, "NVIDIA GeForce GTX 1650" },
                    { 1148, 1117, null, 878, "1366 x 768 pixels" },
                    { 1149, 1118, null, 199, "Plastic" },
                    { 1150, 1119, null, 199, "Android and iOS" },
                    { 1151, 1120, null, 199, "Titanium" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AttributeValues",
                keyColumn: "AttributeValueID",
                keyValue: 111);

            migrationBuilder.DeleteData(
                table: "AttributeValues",
                keyColumn: "AttributeValueID",
                keyValue: 112);

            migrationBuilder.DeleteData(
                table: "AttributeValues",
                keyColumn: "AttributeValueID",
                keyValue: 113);

            migrationBuilder.DeleteData(
                table: "AttributeValues",
                keyColumn: "AttributeValueID",
                keyValue: 114);

            migrationBuilder.DeleteData(
                table: "AttributeValues",
                keyColumn: "AttributeValueID",
                keyValue: 115);

            migrationBuilder.DeleteData(
                table: "AttributeValues",
                keyColumn: "AttributeValueID",
                keyValue: 116);

            migrationBuilder.DeleteData(
                table: "AttributeValues",
                keyColumn: "AttributeValueID",
                keyValue: 117);

            migrationBuilder.DeleteData(
                table: "AttributeValues",
                keyColumn: "AttributeValueID",
                keyValue: 118);

            migrationBuilder.DeleteData(
                table: "AttributeValues",
                keyColumn: "AttributeValueID",
                keyValue: 119);

            migrationBuilder.DeleteData(
                table: "AttributeValues",
                keyColumn: "AttributeValueID",
                keyValue: 1110);

            migrationBuilder.DeleteData(
                table: "AttributeValues",
                keyColumn: "AttributeValueID",
                keyValue: 1111);

            migrationBuilder.DeleteData(
                table: "AttributeValues",
                keyColumn: "AttributeValueID",
                keyValue: 1112);

            migrationBuilder.DeleteData(
                table: "AttributeValues",
                keyColumn: "AttributeValueID",
                keyValue: 1113);

            migrationBuilder.DeleteData(
                table: "AttributeValues",
                keyColumn: "AttributeValueID",
                keyValue: 1114);

            migrationBuilder.DeleteData(
                table: "AttributeValues",
                keyColumn: "AttributeValueID",
                keyValue: 1115);

            migrationBuilder.DeleteData(
                table: "AttributeValues",
                keyColumn: "AttributeValueID",
                keyValue: 1116);

            migrationBuilder.DeleteData(
                table: "AttributeValues",
                keyColumn: "AttributeValueID",
                keyValue: 1117);

            migrationBuilder.DeleteData(
                table: "AttributeValues",
                keyColumn: "AttributeValueID",
                keyValue: 1118);

            migrationBuilder.DeleteData(
                table: "AttributeValues",
                keyColumn: "AttributeValueID",
                keyValue: 1119);

            migrationBuilder.DeleteData(
                table: "AttributeValues",
                keyColumn: "AttributeValueID",
                keyValue: 1120);

            migrationBuilder.DeleteData(
                table: "AttributeValues",
                keyColumn: "AttributeValueID",
                keyValue: 1121);

            migrationBuilder.DeleteData(
                table: "AttributeValues",
                keyColumn: "AttributeValueID",
                keyValue: 1122);

            migrationBuilder.DeleteData(
                table: "AttributeValues",
                keyColumn: "AttributeValueID",
                keyValue: 1123);

            migrationBuilder.DeleteData(
                table: "AttributeValues",
                keyColumn: "AttributeValueID",
                keyValue: 1124);

            migrationBuilder.DeleteData(
                table: "AttributeValues",
                keyColumn: "AttributeValueID",
                keyValue: 1125);

            migrationBuilder.DeleteData(
                table: "AttributeValues",
                keyColumn: "AttributeValueID",
                keyValue: 1126);

            migrationBuilder.DeleteData(
                table: "AttributeValues",
                keyColumn: "AttributeValueID",
                keyValue: 1127);

            migrationBuilder.DeleteData(
                table: "AttributeValues",
                keyColumn: "AttributeValueID",
                keyValue: 1128);

            migrationBuilder.DeleteData(
                table: "AttributeValues",
                keyColumn: "AttributeValueID",
                keyValue: 1129);

            migrationBuilder.DeleteData(
                table: "AttributeValues",
                keyColumn: "AttributeValueID",
                keyValue: 1130);

            migrationBuilder.DeleteData(
                table: "AttributeValues",
                keyColumn: "AttributeValueID",
                keyValue: 1131);

            migrationBuilder.DeleteData(
                table: "AttributeValues",
                keyColumn: "AttributeValueID",
                keyValue: 1132);

            migrationBuilder.DeleteData(
                table: "AttributeValues",
                keyColumn: "AttributeValueID",
                keyValue: 1133);

            migrationBuilder.DeleteData(
                table: "AttributeValues",
                keyColumn: "AttributeValueID",
                keyValue: 1134);

            migrationBuilder.DeleteData(
                table: "AttributeValues",
                keyColumn: "AttributeValueID",
                keyValue: 1135);

            migrationBuilder.DeleteData(
                table: "AttributeValues",
                keyColumn: "AttributeValueID",
                keyValue: 1136);

            migrationBuilder.DeleteData(
                table: "AttributeValues",
                keyColumn: "AttributeValueID",
                keyValue: 1137);

            migrationBuilder.DeleteData(
                table: "AttributeValues",
                keyColumn: "AttributeValueID",
                keyValue: 1138);

            migrationBuilder.DeleteData(
                table: "AttributeValues",
                keyColumn: "AttributeValueID",
                keyValue: 1139);

            migrationBuilder.DeleteData(
                table: "AttributeValues",
                keyColumn: "AttributeValueID",
                keyValue: 1140);

            migrationBuilder.DeleteData(
                table: "AttributeValues",
                keyColumn: "AttributeValueID",
                keyValue: 1141);

            migrationBuilder.DeleteData(
                table: "AttributeValues",
                keyColumn: "AttributeValueID",
                keyValue: 1142);

            migrationBuilder.DeleteData(
                table: "AttributeValues",
                keyColumn: "AttributeValueID",
                keyValue: 1143);

            migrationBuilder.DeleteData(
                table: "AttributeValues",
                keyColumn: "AttributeValueID",
                keyValue: 1144);

            migrationBuilder.DeleteData(
                table: "AttributeValues",
                keyColumn: "AttributeValueID",
                keyValue: 1145);

            migrationBuilder.DeleteData(
                table: "AttributeValues",
                keyColumn: "AttributeValueID",
                keyValue: 1146);

            migrationBuilder.DeleteData(
                table: "AttributeValues",
                keyColumn: "AttributeValueID",
                keyValue: 1147);

            migrationBuilder.DeleteData(
                table: "AttributeValues",
                keyColumn: "AttributeValueID",
                keyValue: 1148);

            migrationBuilder.DeleteData(
                table: "AttributeValues",
                keyColumn: "AttributeValueID",
                keyValue: 1149);

            migrationBuilder.DeleteData(
                table: "AttributeValues",
                keyColumn: "AttributeValueID",
                keyValue: 1150);

            migrationBuilder.DeleteData(
                table: "AttributeValues",
                keyColumn: "AttributeValueID",
                keyValue: 1151);

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "AttributeID",
                keyValue: 111);

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "AttributeID",
                keyValue: 112);

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "AttributeID",
                keyValue: 113);

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "AttributeID",
                keyValue: 114);

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "AttributeID",
                keyValue: 115);

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "AttributeID",
                keyValue: 116);

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "AttributeID",
                keyValue: 117);

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "AttributeID",
                keyValue: 118);

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "AttributeID",
                keyValue: 119);

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "AttributeID",
                keyValue: 1110);

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "AttributeID",
                keyValue: 1111);

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "AttributeID",
                keyValue: 1112);

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "AttributeID",
                keyValue: 1113);

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "AttributeID",
                keyValue: 1114);

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "AttributeID",
                keyValue: 1115);

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "AttributeID",
                keyValue: 1116);

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "AttributeID",
                keyValue: 1117);

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "AttributeID",
                keyValue: 1118);

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "AttributeID",
                keyValue: 1119);

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "AttributeID",
                keyValue: 1120);
        }
    }
}
