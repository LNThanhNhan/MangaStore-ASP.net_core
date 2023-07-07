﻿// <auto-generated />
using System;
using MangaStore.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MangaStore.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20230707091949_add_image_uuid_products_table")]
    partial class add_image_uuid_products_table
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("MangaStore.Models.Account", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("role")
                        .HasColumnType("int");

                    b.Property<string>("username")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("id");

                    b.HasIndex("email")
                        .IsUnique();

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("MangaStore.Models.Cart", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<int>("user_id")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("user_id")
                        .IsUnique();

                    b.ToTable("Carts");
                });

            modelBuilder.Entity("MangaStore.Models.CartDetail", b =>
                {
                    b.Property<int>("cart_id")
                        .HasColumnType("int");

                    b.Property<int>("product_id")
                        .HasColumnType("int");

                    b.Property<int>("quantity")
                        .HasColumnType("int");

                    b.HasKey("cart_id", "product_id");

                    b.HasIndex("product_id");

                    b.ToTable("CartDetails");
                });

            modelBuilder.Entity("MangaStore.Models.Order", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("delivery_date")
                        .HasColumnType("datetime2");

                    b.Property<long>("delivery_fee")
                        .HasColumnType("bigint");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("order_date")
                        .HasColumnType("datetime2");

                    b.Property<int>("payment_method")
                        .HasColumnType("int");

                    b.Property<string>("phone")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<int>("province")
                        .HasColumnType("int");

                    b.Property<int>("status")
                        .HasColumnType("int");

                    b.Property<long>("total_order")
                        .HasColumnType("bigint");

                    b.Property<long>("total_price")
                        .HasColumnType("bigint");

                    b.Property<int>("user_id")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("user_id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("MangaStore.Models.OrderDetail", b =>
                {
                    b.Property<int>("order_id")
                        .HasColumnType("int");

                    b.Property<int>("product_id")
                        .HasColumnType("int");

                    b.Property<long>("price")
                        .HasColumnType("bigint");

                    b.Property<int>("quantity")
                        .HasColumnType("int");

                    b.Property<long>("total_price")
                        .HasColumnType("bigint");

                    b.HasKey("order_id", "product_id");

                    b.HasIndex("product_id");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("MangaStore.Models.Product", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("author")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("author_slug")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("category")
                        .HasColumnType("int");

                    b.Property<string>("collection")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("collection_slug")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("discount_rate")
                        .HasColumnType("int");

                    b.Property<string>("image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("image_uuid")
                        .IsRequired()
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)");

                    b.Property<long>("list_price")
                        .HasColumnType("bigint");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<long>("price")
                        .HasColumnType("bigint");

                    b.Property<int>("publish_year")
                        .HasColumnType("int");

                    b.Property<int>("quantity")
                        .HasColumnType("int");

                    b.Property<string>("size")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("slug")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("id");

                    b.HasIndex("name")
                        .IsUnique();

                    b.HasIndex("slug")
                        .IsUnique();

                    b.ToTable("Products");
                });

            modelBuilder.Entity("MangaStore.Models.Sample", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("product_id")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("product_id");

                    b.ToTable("Sample");
                });

            modelBuilder.Entity("MangaStore.Models.User", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<int>("account_id")
                        .HasColumnType("int");

                    b.Property<string>("address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("gender")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("phone")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<int?>("province")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("account_id")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("MangaStore.Models.Cart", b =>
                {
                    b.HasOne("MangaStore.Models.User", "user")
                        .WithOne("cart")
                        .HasForeignKey("MangaStore.Models.Cart", "user_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("user");
                });

            modelBuilder.Entity("MangaStore.Models.CartDetail", b =>
                {
                    b.HasOne("MangaStore.Models.Cart", "cart")
                        .WithMany("cart_details")
                        .HasForeignKey("cart_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MangaStore.Models.Product", "product")
                        .WithMany("cart_details")
                        .HasForeignKey("product_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("cart");

                    b.Navigation("product");
                });

            modelBuilder.Entity("MangaStore.Models.Order", b =>
                {
                    b.HasOne("MangaStore.Models.User", "user")
                        .WithMany("orders")
                        .HasForeignKey("user_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("user");
                });

            modelBuilder.Entity("MangaStore.Models.OrderDetail", b =>
                {
                    b.HasOne("MangaStore.Models.Order", "Order")
                        .WithMany("order_details")
                        .HasForeignKey("order_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MangaStore.Models.Product", "product")
                        .WithMany("order_details")
                        .HasForeignKey("product_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("product");
                });

            modelBuilder.Entity("MangaStore.Models.Sample", b =>
                {
                    b.HasOne("MangaStore.Models.Product", "product")
                        .WithMany("samples")
                        .HasForeignKey("product_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("product");
                });

            modelBuilder.Entity("MangaStore.Models.User", b =>
                {
                    b.HasOne("MangaStore.Models.Account", "account")
                        .WithOne("user")
                        .HasForeignKey("MangaStore.Models.User", "account_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("account");
                });

            modelBuilder.Entity("MangaStore.Models.Account", b =>
                {
                    b.Navigation("user")
                        .IsRequired();
                });

            modelBuilder.Entity("MangaStore.Models.Cart", b =>
                {
                    b.Navigation("cart_details");
                });

            modelBuilder.Entity("MangaStore.Models.Order", b =>
                {
                    b.Navigation("order_details");
                });

            modelBuilder.Entity("MangaStore.Models.Product", b =>
                {
                    b.Navigation("cart_details");

                    b.Navigation("order_details");

                    b.Navigation("samples");
                });

            modelBuilder.Entity("MangaStore.Models.User", b =>
                {
                    b.Navigation("cart")
                        .IsRequired();

                    b.Navigation("orders");
                });
#pragma warning restore 612, 618
        }
    }
}
