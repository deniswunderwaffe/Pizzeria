using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Pizzeria.Core.HelperClasses;
using Pizzeria.Core.Models;
using Pizzeria.Core.Models.JoinTables;

namespace Pizzeria.Infrastructure.Data
{
    public static class Seed
    {
        public static void SeedData(this ModelBuilder modelBuilder)
        {
            var customer = new Customer
            {
                Id = 1,
                Email = "seed@mail.ru",
                Name = "Denis",
                Phone = "069353632",
                Address = "DELIVERY ADDRESS"
            };
            var foodCategoryPizza = new FoodCategory
            {
                Id = 1,
                Name = CategoryHelper.FoodCategories.Pizza.ToString()
            };
            var foodCategoryDrink = new FoodCategory
            {
                Id = 2,
                Name = CategoryHelper.FoodCategories.Drink.ToString()
            };
            var foodCategorySnack = new FoodCategory
            {
                Id = 3,
                Name = CategoryHelper.FoodCategories.Snack.ToString()
            };
            var orderStatusPending = new OrderStatus
            {
                Id = 1,
                Name = "Pending"
            };
            var orderStatusConfirmed = new OrderStatus
            {
                Id = 2,
                Name = "Confirmed"
            };
            var orderStatusDelivered = new OrderStatus
            {
                Id = 3,
                Name = "Delivered"
            };
            var promotionalCode = new PromotionalCode
            {
                Id = 1,
                Code = "MP100",
                Discount = 5,
                IsActive = true,
                MaximumUses = 1000,
                Name = "Discount",
                ExpirationDate = DateTime.Today + TimeSpan.FromDays(100)
            };
            var foodItem = new FoodItem
            {
                Id = 1,
                Name = "Margarita",
                Description =
                    "Pizza Margherita (more commonly known in English as Margherita pizza) is a typical Neapolitan pizza, made with San Marzano tomatoes, mozzarella cheese, fresh basil, salt, and extra-virgin olive oil. ",
                FoodCategoryId = 1,
                Price = 50
            };
            var foodItem2 = new FoodItem
            {
                Id = 2,
                Name = "Coca-Cola",
                Description = "Coca-Cola, or Coke, is a carbonated soft drink manufactured by The Coca-Cola Company. ",
                FoodCategoryId = 2,
                Price = 5
            };
            var foodItem3 = new FoodItem
            {
                Id = 3,
                Name = "Chips",
                Description =
                    "Potato chips form a large part of the snack food and convenience food market in Western countries.",
                FoodCategoryId = 3,
                Price = 5
            };
            var foodItemExtra = new FoodItemExtra
            {
                Id = 1,
                Name = "Сырный бортик",
                Description = "Очень вкусно",
                FoodItemId = 1,
                Price = 10
            };
            var foodItems = new List<FoodItem> { foodItem };
            var order = new Order
            {
                Id = 1,
                CustomerId = 1,
                DesiredDeliveryDateTime = DateTime.Today + TimeSpan.FromHours(2),
                OrderedAt = DateTime.Now,
                Note = "Second floor",
                OrderStatusId = 1,
                TotalPrice = foodItems.Sum(x => x.Price),
                PromotionalCodeId = 1
            };
            var orderFoodItems = new OrderFoodItem
            {
                Id = 1,
                FoodItemId = 1,
                OrderId = 1,
                Quantity = 1
            };
            var orderFoodItemExtras = new OrderFoodItemExtra
            {
                Id = 1,
                FoodItemExtraId = 1,
                OrderId = 1
            };

            modelBuilder.Entity<Customer>().HasData(customer);
            modelBuilder.Entity<PromotionalCode>().HasData(promotionalCode);
            modelBuilder.Entity<FoodCategory>().HasData(foodCategoryPizza, foodCategorySnack, foodCategoryDrink);
            modelBuilder.Entity<FoodItem>().HasData(foodItem);
            modelBuilder.Entity<FoodItemExtra>().HasData(foodItemExtra);
            modelBuilder.Entity<OrderStatus>().HasData(orderStatusPending, orderStatusConfirmed, orderStatusDelivered);
            modelBuilder.Entity<Order>().HasData(order);
            modelBuilder.Entity<OrderFoodItem>().HasData(orderFoodItems);
            modelBuilder.Entity<OrderFoodItemExtra>().HasData(orderFoodItemExtras);
        }
    }
}