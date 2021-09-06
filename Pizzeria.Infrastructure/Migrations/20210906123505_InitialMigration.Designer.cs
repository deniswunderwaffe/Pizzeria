﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Pizzeria.Infrastructure.Data;

namespace Pizzeria.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210906123505_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Pizzeria.Core.Models.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("Id");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("Pizzeria.Core.Models.Drinks.Drink", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Drinks");
                });

            modelBuilder.Entity("Pizzeria.Core.Models.Ingredient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("ProviderId")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("ProviderId");

                    b.ToTable("Ingredients");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Ingredient",
                            ProviderId = 1,
                            Type = "American"
                        });
                });

            modelBuilder.Entity("Pizzeria.Core.Models.JoinTables.OrderDrink", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DrinkId")
                        .HasColumnType("int");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DrinkId");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderDrink");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DrinkId = 1,
                            OrderId = 1
                        });
                });

            modelBuilder.Entity("Pizzeria.Core.Models.JoinTables.OrderPizza", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("PizzaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("PizzaId");

                    b.ToTable("OrderPizza");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            OrderId = 1,
                            PizzaId = 1
                        });
                });

            modelBuilder.Entity("Pizzeria.Core.Models.JoinTables.PizzaIngredient", b =>
                {
                    b.Property<int>("PizzaId")
                        .HasColumnType("int");

                    b.Property<int>("IngredientId")
                        .HasColumnType("int");

                    b.HasKey("PizzaId", "IngredientId");

                    b.HasIndex("IngredientId");

                    b.ToTable("PizzaIngredient");

                    b.HasData(
                        new
                        {
                            PizzaId = 1,
                            IngredientId = 1
                        });
                });

            modelBuilder.Entity("Pizzeria.Core.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("NumberOfPersons")
                        .HasColumnType("int");

                    b.Property<DateTime>("OrderedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("PaymentOption")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<bool>("Priority")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Orders");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "moscow",
                            Email = "test@mail.ru",
                            Name = "Den",
                            OrderedAt = new DateTime(2021, 9, 6, 15, 35, 4, 972, DateTimeKind.Local).AddTicks(8571),
                            PaymentOption = "Cash",
                            Phone = "1234567890",
                            Priority = true
                        });
                });

            modelBuilder.Entity("Pizzeria.Core.Models.Pizza", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Pizzas");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Rancho",
                            Price = 100,
                            Type = "American"
                        });
                });

            modelBuilder.Entity("Pizzeria.Core.Models.Provider", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("FoundationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Providers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Country = "Moldova",
                            FoundationDate = new DateTime(2021, 9, 6, 0, 0, 0, 0, DateTimeKind.Local),
                            Name = "Provider"
                        });
                });

            modelBuilder.Entity("Pizzeria.Core.Models.Drinks.AlcoholicDrink", b =>
                {
                    b.HasBaseType("Pizzeria.Core.Models.Drinks.Drink");

                    b.Property<double>("Concentration")
                        .HasColumnType("float");

                    b.ToTable("AlcoholicDrinks");
                });

            modelBuilder.Entity("Pizzeria.Core.Models.Drinks.SodaDrink", b =>
                {
                    b.HasBaseType("Pizzeria.Core.Models.Drinks.Drink");

                    b.Property<bool>("IsSugarFree")
                        .HasColumnType("bit");

                    b.ToTable("SodaDrinks");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Brand = "CocaCola",
                            Name = "Classic",
                            IsSugarFree = false
                        });
                });

            modelBuilder.Entity("Pizzeria.Core.Models.Ingredient", b =>
                {
                    b.HasOne("Pizzeria.Core.Models.Provider", "Provider")
                        .WithMany("Ingredients")
                        .HasForeignKey("ProviderId");

                    b.Navigation("Provider");
                });

            modelBuilder.Entity("Pizzeria.Core.Models.JoinTables.OrderDrink", b =>
                {
                    b.HasOne("Pizzeria.Core.Models.Drinks.Drink", "Drink")
                        .WithMany("OrderDrinks")
                        .HasForeignKey("DrinkId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Pizzeria.Core.Models.Order", "Order")
                        .WithMany("OrderDrinks")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Drink");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("Pizzeria.Core.Models.JoinTables.OrderPizza", b =>
                {
                    b.HasOne("Pizzeria.Core.Models.Order", "Order")
                        .WithMany("OrderPizzas")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Pizzeria.Core.Models.Pizza", "Pizza")
                        .WithMany("OrderPizzas")
                        .HasForeignKey("PizzaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Pizza");
                });

            modelBuilder.Entity("Pizzeria.Core.Models.JoinTables.PizzaIngredient", b =>
                {
                    b.HasOne("Pizzeria.Core.Models.Ingredient", "Ingredient")
                        .WithMany("PizzaIngredient")
                        .HasForeignKey("IngredientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Pizzeria.Core.Models.Pizza", "Pizza")
                        .WithMany("PizzaIngredient")
                        .HasForeignKey("PizzaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ingredient");

                    b.Navigation("Pizza");
                });

            modelBuilder.Entity("Pizzeria.Core.Models.Drinks.AlcoholicDrink", b =>
                {
                    b.HasOne("Pizzeria.Core.Models.Drinks.Drink", null)
                        .WithOne()
                        .HasForeignKey("Pizzeria.Core.Models.Drinks.AlcoholicDrink", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Pizzeria.Core.Models.Drinks.SodaDrink", b =>
                {
                    b.HasOne("Pizzeria.Core.Models.Drinks.Drink", null)
                        .WithOne()
                        .HasForeignKey("Pizzeria.Core.Models.Drinks.SodaDrink", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Pizzeria.Core.Models.Drinks.Drink", b =>
                {
                    b.Navigation("OrderDrinks");
                });

            modelBuilder.Entity("Pizzeria.Core.Models.Ingredient", b =>
                {
                    b.Navigation("PizzaIngredient");
                });

            modelBuilder.Entity("Pizzeria.Core.Models.Order", b =>
                {
                    b.Navigation("OrderDrinks");

                    b.Navigation("OrderPizzas");
                });

            modelBuilder.Entity("Pizzeria.Core.Models.Pizza", b =>
                {
                    b.Navigation("OrderPizzas");

                    b.Navigation("PizzaIngredient");
                });

            modelBuilder.Entity("Pizzeria.Core.Models.Provider", b =>
                {
                    b.Navigation("Ingredients");
                });
#pragma warning restore 612, 618
        }
    }
}
