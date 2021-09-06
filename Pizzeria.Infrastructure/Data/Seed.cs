using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pizzeria.Core.Models;
using Pizzeria.Core.Models.Drinks;
using Pizzeria.Core.Models.JoinTables;

namespace Pizzeria.Infrastructure.Data
{
    public static class Seed
    {
        public static void SeedData(this ModelBuilder modelBuilder)
        {
            var soda = new SodaDrink() { Id = 1, Name = "Classic", Brand = "CocaCola", IsSugarFree = false };
            var provider = new Provider() { Id = 1, Name = "Provider", FoundationDate = DateTime.Today, Country = "Moldova" };
            var ingredient = new Ingredient() { Id = 1, Name = "Ingredient", Type = "American", ProviderId = 1};
            var pizza = new Pizza() { Id = 1, Name = "Rancho", Price = 100, Type = "American"};
            var order = new Order()
            {
                Id = 1, Address = "moscow", Email = "test@mail.ru", Name = "Den", PaymentOption = "Cash",
                Priority = true, OrderedAt = DateTime.Now,Phone = "1234567890"
            };
            modelBuilder.Entity<Order>()
                .HasData(
                    order
                );
            modelBuilder.Entity<SodaDrink>()
                .HasData(
                    soda
                );
            modelBuilder.Entity<Provider>()
                .HasData(
                    provider
                );
            modelBuilder.Entity<Ingredient>()
                .HasData(
                    ingredient
                );
            modelBuilder.Entity<Pizza>()
                .HasData(
                    pizza
                );
            modelBuilder.Entity<OrderDrink>()
                .HasData(
                    new OrderDrink(){Id = 1,OrderId = 1,DrinkId = 1}
                );
            modelBuilder.Entity<OrderPizza>()
                .HasData(
                    new OrderPizza(){Id = 1,OrderId = 1,PizzaId = 1}
                );
            modelBuilder.Entity<PizzaIngredient>()
                .HasData(
                    new PizzaIngredient(){PizzaId = 1,IngredientId = 1}
                );
        }
    }
}