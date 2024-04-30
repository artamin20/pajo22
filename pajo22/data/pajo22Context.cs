using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using pajo22.Models;

namespace pajo22.Data
{
    public class pajo22Context : DbContext
    {
        public pajo22Context(DbContextOptions<pajo22Context> options)
            : base(options)
        {
        }

        public DbSet<pajo22.Models.ProductModels> ProductModels { get; set; } = default!;
        public DbSet<pajo22.Models.GroupModels> GroupModels { get; set; } = default!;
        public DbSet<pajo22.Models.SubgroupModels> SubgroupModels { get; set; } = default!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            {
                modelBuilder.Entity<AttributeValues>()
                    .HasOne(av => av.ProductModel)
                    .WithMany(p => p.AttributeValues)
                    .HasForeignKey(av => av.ProductModelId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                modelBuilder.Entity<AttributeValues>()
                    .HasOne(av => av.Attribute)
                    .WithMany()
                    .HasForeignKey(av => av.AttributeID)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                
            }
            base.OnModelCreating(modelBuilder);

            
            if (!Database.IsSqlServer()) 
            {
                return; 
            }

            
            modelBuilder.Entity<GroupModels>().HasData(
                new GroupModels { Id = 111, Name = "کالا های دیجیتال" },
                new GroupModels { Id = 22, Name = "لوازم خانگی" },
                new GroupModels { Id = 323, Name = "کالا های پوشیدنی" }
            );

           
            modelBuilder.Entity<SubgroupModels>().HasData(
                new SubgroupModels { Id = 111, Name = "گوشی موبایل", GroupID = 111 },
                new SubgroupModels { Id = 22, Name = "ماشین لباس شویی", GroupID = 22 },
                new SubgroupModels { Id = 33, Name = "لب تاب", GroupID = 111 },
                new SubgroupModels { Id = 36, Name = "ساعت", GroupID = 323, },
                new SubgroupModels { Id = 37, Name = "ساعت هوشمند", GroupID = 323, ParentSubGroupId = 36 },
                new SubgroupModels { Id = 38, Name = "  ساعت هوشمند اپل", GroupID = 323, ParentSubGroupId = 37 },
                new SubgroupModels { Id = 39, Name = "  عینک", GroupID = 323, },
                new SubgroupModels { Id = 40, Name = "  عینک های rayban", GroupID = 323, ParentSubGroupId = 39 }
            );

            modelBuilder.Entity<Attributes>().HasData(
                new Attributes { AttributeID = 111, AttributeName = "os", SubgroupId = 111 },
                new Attributes { AttributeID = 112, AttributeName = "Storage Capacity", SubgroupId = 111 },
                new Attributes { AttributeID = 113, AttributeName = "Screen Size", SubgroupId = 111 },
                new Attributes { AttributeID = 114, AttributeName = "Load Capacity", SubgroupId = 22 },
                new Attributes { AttributeID = 115, AttributeName = "Energy Efficiency", SubgroupId = 22 },
                new Attributes { AttributeID = 116, AttributeName = "Operating System", SubgroupId = 33 },
                new Attributes { AttributeID = 117, AttributeName = "Battery Life", SubgroupId = 33 },
                new Attributes { AttributeID = 118, AttributeName = "Material", SubgroupId = 36 },
                new Attributes { AttributeID = 119, AttributeName = "Water Resistance", SubgroupId = 37 },
                new Attributes { AttributeID = 1110, AttributeName = "Lens Type", SubgroupId = 39 },
                new Attributes { AttributeID = 1111, AttributeName = "Processor Speed", SubgroupId = 111 },
                new Attributes { AttributeID = 1112, AttributeName = "RAM Size", SubgroupId = 111 },
                new Attributes { AttributeID = 1113, AttributeName = "Camera Resolution", SubgroupId = 111 },
                new Attributes { AttributeID = 1114, AttributeName = "Washing Capacity", SubgroupId = 22 },
                new Attributes { AttributeID = 1115, AttributeName = "Spin Speed", SubgroupId = 22 },
                new Attributes { AttributeID = 1116, AttributeName = "Graphics Card", SubgroupId = 33 },
                new Attributes { AttributeID = 1117, AttributeName = "Display Resolution", SubgroupId = 33 },
                new Attributes { AttributeID = 1118, AttributeName = "Strap Material", SubgroupId = 36 },
                new Attributes { AttributeID = 1119, AttributeName = "Operating System Compatibility", SubgroupId = 37 },
                new Attributes { AttributeID = 1120, AttributeName = "Frame Material", SubgroupId = 39 }


            // Add more attribute seed data as needed
            );



            // دیتا ریزی
            modelBuilder.Entity<ProductModels>().HasData(
                new ProductModels { Id = 17811, Name = "سامسونگ Samsung A54", Price = 13000000, Image = "/images/ph6.png", Description = "mid-range Samsung", Color = "gray", SubgroupId = 111 },
                new ProductModels { Id = 278, Name = "سامسونگ Samsung S23", Price = 2300000, Image = "/images/ph3.png", Description = "flagship Samsung", Color = "Blue", SubgroupId = 111 },
                new ProductModels { Id = 378, Name = "Iphone 13 آیفون", Price = 4000000, Image = "/images/ph1.png", Description = "it's iPhone, just buy it", Color = "Green", SubgroupId = 111 },
                new ProductModels { Id = 478, Name = "Xiaomi Redmi شیائومی", Price = 6000000, Image = "/images/ph5.png", Description = "it's cheap, why not", Color = "Green", SubgroupId = 111 },
                new ProductModels { Id = 578, Name = "Classic Gold Phone گوشی کلاسیک", Price = 1000000, Image = "/images/ph6.png", Description = "the classic from the past", Color = "Green", SubgroupId = 111 },
                new ProductModels { Id = 678, Name = "GPlus 128 gig جی پلاس", Price = 4000000, Image = "/images/p7.png", Description = "Iranian made cheap", Color = "Green", SubgroupId = 111 },
                new ProductModels { Id = 778, Name = "Asus TUF Gaming ایسوس تاف", Price = 64000000, Image = "~/images/f2.png", Description = "Asus TUFF gaming", Color = "Green", SubgroupId = 33 },
                new ProductModels { Id = 878, Name = "Acer Aspire ایسر", Price = 35000000, Image = "/images/f3.png", Description = "Acer regular laptop", Color = "black", SubgroupId = 33 },
                new ProductModels { Id = 8789, Name = "لپ تاپ 14.2 اینچی اپل مدل MacBook Pro MTL73 2023-M3 8GB 512SSD", Price = 86000000, Image = "/images/f43.png", Description = "macbook from apple ", Color = "black", SubgroupId = 33 },
                new ProductModels { Id = 8788, Name = "لپ تاپ 15.6 اینچی ام اس آی مدل Katana 15 B12VEK", Price = 95000000, Image = "/images/f33.png", Description = "msi expensive laptop", Color = "black", SubgroupId = 33 },
                new ProductModels { Id = 978, Name = "Lenovo Legion لنوو", Price = 48000000, Image = "/images/f1.png", Description = "Lenovo gaming laptop", Color = "black", SubgroupId = 33 },
                new ProductModels { Id = 1780, Name = "Snowa اسنوا لباس شویی", Price = 45000000, Image = "/images/a1.png", Description = "Snowa Iranian made washing machine", Color = "black", SubgroupId = 22 },
                new ProductModels { Id = 1781, Name = "ساعت معمولی Q&Q", Price = 2000000, Image = "/images/ap2.png", Description = "normal watch", Color = "blue", SubgroupId = 36 },
                new ProductModels { Id = 1881, Name = "apple watch ساعت اپل", Price = 42000000, Image = "/images/ap1.png", Description = "apple smart watch", Color = "orange", SubgroupId = 38 },
                new ProductModels { Id = 199, Name = "عینک کلاسیک rayban", Price = 20000000, Image = "/images/RB1.png", Description = "iconix glasses", Color = "black", SubgroupId = 39 }
            );

            modelBuilder.Entity<AttributeValues>().HasData(
                new AttributeValues { AttributeValueID = 111, AttributeID = 111, ProductModelId = 17811, Value = "Android" },
                new AttributeValues { AttributeValueID = 112, AttributeID = 112, ProductModelId = 17811, Value = "128GB" },
                new AttributeValues { AttributeValueID = 113, AttributeID = 113, ProductModelId = 17811, Value = "6.4 inches" },
                new AttributeValues { AttributeValueID = 114, AttributeID = 111, ProductModelId = 278, Value = "Android" },
                new AttributeValues { AttributeValueID = 115, AttributeID = 112, ProductModelId = 278, Value = "256GB" },
                new AttributeValues { AttributeValueID = 116, AttributeID = 113, ProductModelId = 278, Value = "6.7 inches" },
                new AttributeValues { AttributeValueID = 117, AttributeID = 111, ProductModelId = 378, Value = "iOS" },
                new AttributeValues { AttributeValueID = 118, AttributeID = 112, ProductModelId = 378, Value = "256GB" },
                new AttributeValues { AttributeValueID = 119, AttributeID = 113, ProductModelId = 378, Value = "6.1 inches" },
                new AttributeValues { AttributeValueID = 1110, AttributeID = 111, ProductModelId = 478, Value = "Android" },
                new AttributeValues { AttributeValueID = 1111, AttributeID = 112, ProductModelId = 478, Value = "64GB" },
                new AttributeValues { AttributeValueID = 1112, AttributeID = 113, ProductModelId = 478, Value = "6.3 inches" },
                new AttributeValues { AttributeValueID = 1113, AttributeID = 111, ProductModelId = 578, Value = "Android" },
                new AttributeValues { AttributeValueID = 1114, AttributeID = 112, ProductModelId = 578, Value = "32GB" },
                new AttributeValues { AttributeValueID = 1115, AttributeID = 113, ProductModelId = 578, Value = "5.5 inches" },
                new AttributeValues { AttributeValueID = 1116, AttributeID = 111, ProductModelId = 678, Value = "Android" },
                new AttributeValues { AttributeValueID = 1117, AttributeID = 112, ProductModelId = 678, Value = "128GB" },
                new AttributeValues { AttributeValueID = 1118, AttributeID = 113, ProductModelId = 678, Value = "6.2 inches" },
                new AttributeValues { AttributeValueID = 1119, AttributeID = 111, ProductModelId = 778, Value = "Windows 10" },
                new AttributeValues { AttributeValueID = 1120, AttributeID = 112, ProductModelId = 778, Value = "512GB SSD" },
                new AttributeValues { AttributeValueID = 1121, AttributeID = 113, ProductModelId = 778, Value = "15.6 inches" },
                new AttributeValues { AttributeValueID = 1122, AttributeID = 114, ProductModelId = 1780, Value = "8kg" },
                new AttributeValues { AttributeValueID = 1123, AttributeID = 115, ProductModelId = 1780, Value = "1200 RPM" },
                new AttributeValues { AttributeValueID = 1124, AttributeID = 114, ProductModelId = 1781, Value = "NA" },
                new AttributeValues { AttributeValueID = 1125, AttributeID = 115, ProductModelId = 1781, Value = "NA" },
                new AttributeValues { AttributeValueID = 1126, AttributeID = 116, ProductModelId = 1881, Value = "watchOS" },
                new AttributeValues { AttributeValueID = 1127, AttributeID = 117, ProductModelId = 1881, Value = "Up to 18 hours" },
                new AttributeValues { AttributeValueID = 1128, AttributeID = 118, ProductModelId = 199, Value = "Metal" },
                new AttributeValues { AttributeValueID = 1129, AttributeID = 119, ProductModelId = 199, Value = "UV Protection" },
                new AttributeValues { AttributeValueID = 1130, AttributeID = 1110, ProductModelId = 199, Value = "Plastic" },
                new AttributeValues { AttributeValueID = 1131, AttributeID = 1111, ProductModelId = 17811, Value = "2.3 GHz" },
                new AttributeValues { AttributeValueID = 1132, AttributeID = 1112, ProductModelId = 17811, Value = "6GB" },
                new AttributeValues { AttributeValueID = 1133, AttributeID = 1113, ProductModelId = 17811, Value = "48 MP" },
                new AttributeValues { AttributeValueID = 1134, AttributeID = 1114, ProductModelId = 1780, Value = "10kg" },
                new AttributeValues { AttributeValueID = 1135, AttributeID = 1115, ProductModelId = 1780, Value = "1400 RPM" },
                new AttributeValues { AttributeValueID = 1136, AttributeID = 1116, ProductModelId = 778, Value = "NVIDIA GeForce RTX 3070" },
                new AttributeValues { AttributeValueID = 1137, AttributeID = 1117, ProductModelId = 778, Value = "1920 x 1080 pixels" },
                new AttributeValues { AttributeValueID = 1138, AttributeID = 1118, ProductModelId = 1781, Value = "Stainless Steel" },
                new AttributeValues { AttributeValueID = 1139, AttributeID = 1119, ProductModelId = 1881, Value = "iOS 15" },
                new AttributeValues { AttributeValueID = 1140, AttributeID = 1120, ProductModelId = 1881, Value = "Aluminum" },
                new AttributeValues { AttributeValueID = 1141, AttributeID = 1110, ProductModelId = 199, Value = "Glass" },
                new AttributeValues { AttributeValueID = 1142, AttributeID = 1111, ProductModelId = 278, Value = "2.8 GHz" },
                new AttributeValues { AttributeValueID = 1143, AttributeID = 1112, ProductModelId = 278, Value = "8GB" },
                new AttributeValues { AttributeValueID = 1144, AttributeID = 1113, ProductModelId = 278, Value = "64 MP" },
                new AttributeValues { AttributeValueID = 1145, AttributeID = 1114, ProductModelId = 1781, Value = "NA" },
                new AttributeValues { AttributeValueID = 1146, AttributeID = 1115, ProductModelId = 1781, Value = "NA" },
                new AttributeValues { AttributeValueID = 1147, AttributeID = 1116, ProductModelId = 878, Value = "NVIDIA GeForce GTX 1650" },
                new AttributeValues { AttributeValueID = 1148, AttributeID = 1117, ProductModelId = 878, Value = "1366 x 768 pixels" },
                new AttributeValues { AttributeValueID = 1149, AttributeID = 1118, ProductModelId = 199, Value = "Plastic" },
                new AttributeValues { AttributeValueID = 1150, AttributeID = 1119, ProductModelId = 199, Value = "Android and iOS" },
                new AttributeValues { AttributeValueID = 1151, AttributeID = 1120, ProductModelId = 199, Value = "Titanium" }

            );



        }
        public DbSet<pajo22.Models.Attributes> Attributes { get; set; } = default!;
        public DbSet<pajo22.Models.AttributeValues> AttributeValues { get; set; } = default!;

    }
}
