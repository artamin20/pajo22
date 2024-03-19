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

            // Add predefined data if the database is empty
            if (!Database.IsSqlServer()) // Assuming SQL Server, change if using a different database
            {
                return; // Predefined data seeding only for SQL Server
            }

            // Add predefined data for Groups
            modelBuilder.Entity<GroupModels>().HasData(
                new GroupModels { Id = 111, Name = "کالا های دیجیتال" },
                new GroupModels { Id = 22, Name = "لوازم خانگی" }
            );

            // Add predefined data for Subgroups
            modelBuilder.Entity<SubgroupModels>().HasData(
                new SubgroupModels { Id = 111, Name = "گوشی موبایل", GroupID = 111 },
                new SubgroupModels { Id = 22, Name = "ماشین لباس شویی", GroupID = 22 },
                new SubgroupModels { Id = 33, Name = "لب تاب", GroupID = 111 }
            );

            // Add predefined data for Products
            modelBuilder.Entity<ProductModels>().HasData(
                new ProductModels { Id = 17811, Name = "سامسونگ Samsung A54", Price = 13000000, Image = "/images/ph6.png", Description = "mid-range Samsung", Color = "gray", SubgroupId = 111 },
                new ProductModels { Id = 278, Name = "سامسونگ Samsung S23", Price = 2300000, Image = "/images/ph3.png", Description = "flagship Samsung", Color = "Blue", SubgroupId = 111 },
                new ProductModels { Id = 378, Name = "Iphone 13 آیفون", Price = 4000000, Image = "/images/ph1.png", Description = "it's iPhone, just buy it", Color = "Green", SubgroupId = 111 },
                new ProductModels { Id = 478, Name = "Xiaomi Redmi شیائومی", Price = 6000000, Image = "/images/ph5.png", Description = "it's cheap, why not", Color = "Green", SubgroupId = 111 },
                new ProductModels { Id = 578, Name = "Classic Gold Phone گوشی کلاسیک", Price = 1000000, Image = "/images/ph6.png", Description = "the classic from the past", Color = "Green", SubgroupId = 111 },
                new ProductModels { Id = 678, Name = "GPlus 128 gig جی پلاس", Price = 4000000, Image = "/images/p7.png", Description = "Iranian made cheap", Color = "Green", SubgroupId = 111 },
                new ProductModels { Id = 778, Name = "Asus TUF Gaming ایسوس تاف", Price = 64000000, Image = "~/images/f2.png", Description = "Asus TUFF gaming", Color = "Green", SubgroupId = 33 },
                new ProductModels { Id = 878, Name = "Acer Aspire ایسر", Price = 35000000, Image = "/images/f3.png", Description = "Acer regular laptop", Color = "black", SubgroupId = 33 },
                new ProductModels { Id = 978, Name = "Lenovo Legion لنوو", Price = 48000000, Image = "/images/f1.png", Description = "Lenovo gaming laptop", Color = "black", SubgroupId = 33 },
                new ProductModels { Id = 1780, Name = "Snowa اسنوا لباس شویی", Price = 45000000, Image = "/images/a1.png", Description = "Snowa Iranian made washing machine", Color = "black", SubgroupId = 22 },
                new ProductModels { Id = 1781, Name = "Snowa اسنوا یخچال", Price = 12000000, Image = "/images/a2.png", Description = "Snowa fridge", Color = "Green", SubgroupId = 22 }
            );
        }

    }
}
