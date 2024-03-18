﻿// <auto-generated />
using System;
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
    [Migration("20240317080538_product-color")]
    partial class productcolor
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

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SubgroupId")
                        .HasColumnType("int");

                    b.Property<string>("image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("price")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SubgroupId");

                    b.ToTable("ProductModels");
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
                });

            modelBuilder.Entity("pajo22.Models.newproduct", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Image")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SubgroupId")
                        .HasColumnType("int");

                    b.Property<int?>("price")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SubgroupId");

                    b.ToTable("newproduct");
                });

            modelBuilder.Entity("pajo22.Models.product2", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Image")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SubgroupId")
                        .HasColumnType("int");

                    b.Property<string>("color")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("price")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SubgroupId");

                    b.ToTable("product2");
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

            modelBuilder.Entity("pajo22.Models.newproduct", b =>
                {
                    b.HasOne("pajo22.Models.SubgroupModels", "Subgroup")
                        .WithMany()
                        .HasForeignKey("SubgroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Subgroup");
                });

            modelBuilder.Entity("pajo22.Models.product2", b =>
                {
                    b.HasOne("pajo22.Models.SubgroupModels", "Subgroup")
                        .WithMany()
                        .HasForeignKey("SubgroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Subgroup");
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
