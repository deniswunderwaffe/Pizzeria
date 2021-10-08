using Microsoft.EntityFrameworkCore;
using Pizzeria.Core.Models;


namespace Pizzeria.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<FoodCategory> FoodCategories { get; set; }
        public DbSet<FoodItem> FoodItems { get; set; }
        public DbSet<FoodItemExtra> FoodItemExtras { get; set; }
        public DbSet<OrderStatus> OrderStatus { get; set; }
        public DbSet<PromotionalCode> PromotionalCodes { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BaseEntity).Assembly);

            modelBuilder.SeedData();
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public ApplicationDbContext()
        {
        }
    }
}