using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Pizzeria.Core.Configuration;
using Pizzeria.Core.Models;
using Pizzeria.Core.Models.Drinks;
using Pizzeria.Core.Models.JoinTables;

namespace Pizzeria.Infrastructure.Data
{
    public class ApplicationDbContext:DbContext
    {
        public DbSet<Client> Clients { get; set; } 
        public DbSet<Drink> Drinks { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<Provider> Providers { get; set; }
        public DbSet<Order> Orders { get; set; }
        // public DbSet<OrderPizza> OrderPizzas { get; set; }
        // public DbSet<OrderDrink> OrderDrinks { get; set; }
        // public DbSet<PizzaIngredient> PizzaIngredients { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClientConfiguration());
            modelBuilder.ApplyConfiguration(new DrinkConfiguration());
            modelBuilder.ApplyConfiguration(new IngredientConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new PizzaConfiguration());
            modelBuilder.ApplyConfiguration(new ProviderConfiguration());

            modelBuilder.Entity<AlcoholicDrink>().ToTable("AlcoholicDrinks");
            modelBuilder.Entity<SodaDrink>().ToTable("SodaDrinks");
            modelBuilder.Entity<PizzaIngredient>()
                .HasKey(x => new { x.PizzaId, x.IngredientId });
            
            modelBuilder.SeedData();
        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
            
        }

        public ApplicationDbContext()
        {
            
        }
    }
}