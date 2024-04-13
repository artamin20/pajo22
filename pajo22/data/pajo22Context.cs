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

        }

    }
}
