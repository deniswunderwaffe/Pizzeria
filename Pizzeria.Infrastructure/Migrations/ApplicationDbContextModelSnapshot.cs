﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Pizzeria.Infrastructure.Data;

namespace Pizzeria.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Pizzeria.Core.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool?>("IsConfirmed")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("0");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.HasKey("Id");

                    b.HasIndex("Phone")
                        .IsUnique();

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "seed@mail.ru",
                            Name = "Denis",
                            Phone = "069353632"
                        });
                });

            modelBuilder.Entity("Pizzeria.Core.Models.DeliveryAddress", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Apartment")
                        .HasColumnType("int");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("DeliveryAddress");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Apartment = 5,
                            CustomerId = 1,
                            Street = "Test Street"
                        });
                });

            modelBuilder.Entity("Pizzeria.Core.Models.FoodCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.HasKey("Id");

                    b.ToTable("FoodCategories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Pizza"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Snack"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Drink"
                        });
                });

            modelBuilder.Entity("Pizzeria.Core.Models.FoodItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("FoodCategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("Price")
                        .HasPrecision(5, 2)
                        .HasColumnType("decimal(5,2)");

                    b.HasKey("Id");

                    b.HasIndex("FoodCategoryId");

                    b.ToTable("FoodItems");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Best pizza",
                            FoodCategoryId = 1,
                            Name = "Margarita",
                            Price = 100m
                        });
                });

            modelBuilder.Entity("Pizzeria.Core.Models.FoodItemExtra", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int?>("FoodItemId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("Price")
                        .HasPrecision(4, 2)
                        .HasColumnType("decimal(4,2)");

                    b.HasKey("Id");

                    b.HasIndex("FoodItemId");

                    b.ToTable("FoodItemExtras");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Best pizza",
                            FoodItemId = 1,
                            Name = "Margarita",
                            Price = 10m
                        });
                });

            modelBuilder.Entity("Pizzeria.Core.Models.JoinTables.OrderFoodItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("FoodItemId")
                        .HasColumnType("int");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FoodItemId");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderFoodItem");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FoodItemId = 1,
                            OrderId = 1,
                            Quantity = 0
                        });
                });

            modelBuilder.Entity("Pizzeria.Core.Models.JoinTables.OrderFoodItemExtra", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("FoodItemExtraId")
                        .HasColumnType("int");

                    b.Property<int>("OrderFoodItemId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FoodItemExtraId");

                    b.HasIndex("OrderFoodItemId");

                    b.ToTable("OrderFoodItemExtra");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FoodItemExtraId = 1,
                            OrderFoodItemId = 1,
                            Quantity = 0
                        });
                });

            modelBuilder.Entity("Pizzeria.Core.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DesiredDeliveryDateTime")
                        .HasColumnType("datetime");

                    b.Property<bool?>("IsCash")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("0");

                    b.Property<string>("Note")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<Guid>("OrderIdentifier")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<int>("OrderStatusId")
                        .HasColumnType("int");

                    b.Property<DateTime>("OrderedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("getdate()");

                    b.Property<int?>("PromotionalCodeId")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalPrice")
                        .HasPrecision(6, 2)
                        .HasColumnType("decimal(6,2)");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("OrderStatusId");

                    b.HasIndex("PromotionalCodeId");

                    b.ToTable("Orders");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CustomerId = 1,
                            DesiredDeliveryDateTime = new DateTime(2021, 10, 4, 2, 0, 0, 0, DateTimeKind.Local),
                            Note = "Second floor",
                            OrderIdentifier = new Guid("00000000-0000-0000-0000-000000000000"),
                            OrderStatusId = 1,
                            OrderedAt = new DateTime(2021, 10, 4, 10, 15, 7, 716, DateTimeKind.Local).AddTicks(895),
                            PromotionalCodeId = 1,
                            TotalPrice = 100m
                        });
                });

            modelBuilder.Entity("Pizzeria.Core.Models.OrderStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("OrderStatus");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Pending"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Confirmed"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Delivered"
                        });
                });

            modelBuilder.Entity("Pizzeria.Core.Models.PromotionalCode", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.Property<decimal>("Discount")
                        .HasPrecision(4, 2)
                        .HasColumnType("decimal(4,2)");

                    b.Property<DateTime>("ExpirationDate")
                        .HasColumnType("datetime");

                    b.Property<bool?>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("0");

                    b.Property<int>("MaximumUses")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("PromotionalCodes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Code = "MP100",
                            Discount = 5m,
                            ExpirationDate = new DateTime(2022, 1, 12, 0, 0, 0, 0, DateTimeKind.Local),
                            IsActive = true,
                            MaximumUses = 1000,
                            Name = "Discount"
                        });
                });

            modelBuilder.Entity("Pizzeria.Core.Models.DeliveryAddress", b =>
                {
                    b.HasOne("Pizzeria.Core.Models.Customer", "Customer")
                        .WithMany("DeliveryAddressees")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("Pizzeria.Core.Models.FoodItem", b =>
                {
                    b.HasOne("Pizzeria.Core.Models.FoodCategory", "FoodCategory")
                        .WithMany()
                        .HasForeignKey("FoodCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FoodCategory");
                });

            modelBuilder.Entity("Pizzeria.Core.Models.FoodItemExtra", b =>
                {
                    b.HasOne("Pizzeria.Core.Models.FoodItem", "FoodItem")
                        .WithMany()
                        .HasForeignKey("FoodItemId");

                    b.Navigation("FoodItem");
                });

            modelBuilder.Entity("Pizzeria.Core.Models.JoinTables.OrderFoodItem", b =>
                {
                    b.HasOne("Pizzeria.Core.Models.FoodItem", "FoodItem")
                        .WithMany("OrderFoodItems")
                        .HasForeignKey("FoodItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Pizzeria.Core.Models.Order", "Order")
                        .WithMany("OrderFoodItems")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FoodItem");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("Pizzeria.Core.Models.JoinTables.OrderFoodItemExtra", b =>
                {
                    b.HasOne("Pizzeria.Core.Models.FoodItemExtra", "FoodItemExtra")
                        .WithMany("OrderFoodItemExtras")
                        .HasForeignKey("FoodItemExtraId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Pizzeria.Core.Models.JoinTables.OrderFoodItem", "OrderFoodItem")
                        .WithMany("OrderFoodItemExtras")
                        .HasForeignKey("OrderFoodItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FoodItemExtra");

                    b.Navigation("OrderFoodItem");
                });

            modelBuilder.Entity("Pizzeria.Core.Models.Order", b =>
                {
                    b.HasOne("Pizzeria.Core.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Pizzeria.Core.Models.OrderStatus", "OrderStatus")
                        .WithMany()
                        .HasForeignKey("OrderStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Pizzeria.Core.Models.PromotionalCode", "PromotionalCode")
                        .WithMany()
                        .HasForeignKey("PromotionalCodeId");

                    b.Navigation("Customer");

                    b.Navigation("OrderStatus");

                    b.Navigation("PromotionalCode");
                });

            modelBuilder.Entity("Pizzeria.Core.Models.Customer", b =>
                {
                    b.Navigation("DeliveryAddressees");
                });

            modelBuilder.Entity("Pizzeria.Core.Models.FoodItem", b =>
                {
                    b.Navigation("OrderFoodItems");
                });

            modelBuilder.Entity("Pizzeria.Core.Models.FoodItemExtra", b =>
                {
                    b.Navigation("OrderFoodItemExtras");
                });

            modelBuilder.Entity("Pizzeria.Core.Models.JoinTables.OrderFoodItem", b =>
                {
                    b.Navigation("OrderFoodItemExtras");
                });

            modelBuilder.Entity("Pizzeria.Core.Models.Order", b =>
                {
                    b.Navigation("OrderFoodItems");
                });
#pragma warning restore 612, 618
        }
    }
}
