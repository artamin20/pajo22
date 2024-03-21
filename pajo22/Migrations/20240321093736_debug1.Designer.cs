﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using pajo22.Data;

#nullable disable

namespace pajo22.Migrations
{
    [DbContext(typeof(pajo22Context))]
    [Migration("20240321093736_debug1")]
    partial class debug1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("pajo22.Models.GroupModels", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("GroupModels");

                    b.HasData(
                        new
                        {
                            Id = 111,
                            Name = "کالا های دیجیتال"
                        },
                        new
                        {
                            Id = 22,
                            Name = "لوازم خانگی"
                        });
                });

            modelBuilder.Entity("pajo22.Models.ProductModels", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Color")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<int>("SubgroupId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SubgroupId");

                    b.ToTable("ProductModels");

                    b.HasData(
                        new
                        {
                            Id = 17811,
                            Color = "gray",
                            Description = "mid-range Samsung",
                            Image = "/images/ph6.png",
                            Name = "سامسونگ Samsung A54",
                            Price = 13000000,
                            SubgroupId = 111
                        },
                        new
                        {
                            Id = 278,
                            Color = "Blue",
                            Description = "flagship Samsung",
                            Image = "/images/ph3.png",
                            Name = "سامسونگ Samsung S23",
                            Price = 2300000,
                            SubgroupId = 111
                        },
                        new
                        {
                            Id = 378,
                            Color = "Green",
                            Description = "it's iPhone, just buy it",
                            Image = "/images/ph1.png",
                            Name = "Iphone 13 آیفون",
                            Price = 4000000,
                            SubgroupId = 111
                        },
                        new
                        {
                            Id = 478,
                            Color = "Green",
                            Description = "it's cheap, why not",
                            Image = "/images/ph5.png",
                            Name = "Xiaomi Redmi شیائومی",
                            Price = 6000000,
                            SubgroupId = 111
                        },
                        new
                        {
                            Id = 578,
                            Color = "Green",
                            Description = "the classic from the past",
                            Image = "/images/ph6.png",
                            Name = "Classic Gold Phone گوشی کلاسیک",
                            Price = 1000000,
                            SubgroupId = 111
                        },
                        new
                        {
                            Id = 678,
                            Color = "Green",
                            Description = "Iranian made cheap",
                            Image = "/images/p7.png",
                            Name = "GPlus 128 gig جی پلاس",
                            Price = 4000000,
                            SubgroupId = 111
                        },
                        new
                        {
                            Id = 778,
                            Color = "Green",
                            Description = "Asus TUFF gaming",
                            Image = "~/images/f2.png",
                            Name = "Asus TUF Gaming ایسوس تاف",
                            Price = 64000000,
                            SubgroupId = 33
                        },
                        new
                        {
                            Id = 878,
                            Color = "black",
                            Description = "Acer regular laptop",
                            Image = "/images/f3.png",
                            Name = "Acer Aspire ایسر",
                            Price = 35000000,
                            SubgroupId = 33
                        },
                        new
                        {
                            Id = 978,
                            Color = "black",
                            Description = "Lenovo gaming laptop",
                            Image = "/images/f1.png",
                            Name = "Lenovo Legion لنوو",
                            Price = 48000000,
                            SubgroupId = 33
                        },
                        new
                        {
                            Id = 1780,
                            Color = "black",
                            Description = "Snowa Iranian made washing machine",
                            Image = "/images/a1.png",
                            Name = "Snowa اسنوا لباس شویی",
                            Price = 45000000,
                            SubgroupId = 22
                        },
                        new
                        {
                            Id = 1781,
                            Color = "Green",
                            Description = "Snowa fridge",
                            Image = "/images/a2.png",
                            Name = "Snowa اسنوا یخچال",
                            Price = 12000000,
                            SubgroupId = 22
                        });
                });

            modelBuilder.Entity("pajo22.Models.SubgroupModels", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("GroupID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("GroupID");

                    b.ToTable("SubgroupModels");

                    b.HasData(
                        new
                        {
                            Id = 111,
                            GroupID = 111,
                            Name = "گوشی موبایل"
                        },
                        new
                        {
                            Id = 22,
                            GroupID = 22,
                            Name = "ماشین لباس شویی"
                        },
                        new
                        {
                            Id = 33,
                            GroupID = 111,
                            Name = "لب تاب"
                        });
                });

            modelBuilder.Entity("pajo22.Models.ProductModels", b =>
                {
                    b.HasOne("pajo22.Models.SubgroupModels", "Subgroup")
                        .WithMany("Product")
                        .HasForeignKey("SubgroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Subgroup");
                });

            modelBuilder.Entity("pajo22.Models.SubgroupModels", b =>
                {
                    b.HasOne("pajo22.Models.GroupModels", "GroupModels")
                        .WithMany("Subgroups")
                        .HasForeignKey("GroupID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GroupModels");
                });

            modelBuilder.Entity("pajo22.Models.GroupModels", b =>
                {
                    b.Navigation("Subgroups");
                });

            modelBuilder.Entity("pajo22.Models.SubgroupModels", b =>
                {
                    b.Navigation("Product");
                });
#pragma warning restore 612, 618
        }
    }
}
