﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Shoppers12.Data;

#nullable disable

namespace Shoppers12.Migrations
{
    [DbContext(typeof(Shoppers12DbContext))]
    [Migration("20230228145513_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Shoppers12.Models.Data.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderId"));

                    b.Property<DateTime?>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("OrderLineId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("PromisedDeliveryDate")
                        .HasColumnType("datetime2");

                    b.HasKey("OrderId");

                    b.HasIndex("OrderLineId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Shoppers12.Models.Data.OrderLine", b =>
                {
                    b.Property<int>("OrderLineId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderLineId"));

                    b.HasKey("OrderLineId");

                    b.ToTable("OrderLines");
                });

            modelBuilder.Entity("Shoppers12.Models.Data.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"));

                    b.Property<int?>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("ProductCategoryId")
                        .HasColumnType("int");

                    b.Property<string>("ProductDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("ProductPrice")
                        .HasColumnType("float");

                    b.HasKey("ProductId");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductCategoryId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Shoppers12.Models.Data.ProductCategory", b =>
                {
                    b.Property<int>("ProductCategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductCategoryId"));

                    b.Property<string>("ProductCategoryName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProductCategoryId");

                    b.ToTable("ProductCategories");
                });

            modelBuilder.Entity("Shoppers12.Models.Data.Order", b =>
                {
                    b.HasOne("Shoppers12.Models.Data.OrderLine", "OrderLine")
                        .WithMany("Orders")
                        .HasForeignKey("OrderLineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("OrderLine");
                });

            modelBuilder.Entity("Shoppers12.Models.Data.Product", b =>
                {
                    b.HasOne("Shoppers12.Models.Data.Order", null)
                        .WithMany("Products")
                        .HasForeignKey("OrderId");

                    b.HasOne("Shoppers12.Models.Data.ProductCategory", "ProductCategory")
                        .WithMany("Products")
                        .HasForeignKey("ProductCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProductCategory");
                });

            modelBuilder.Entity("Shoppers12.Models.Data.Order", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("Shoppers12.Models.Data.OrderLine", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("Shoppers12.Models.Data.ProductCategory", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
