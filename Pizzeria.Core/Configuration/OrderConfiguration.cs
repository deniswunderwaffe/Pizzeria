using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pizzeria.Core.Models;
using Pizzeria.Core.Models.JoinTables;

namespace Pizzeria.Core.Configuration
{
    public class OrderConfiguration:IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasMany(x => x.Drinks)
                .WithMany(x => x.Orders)
                .UsingEntity<OrderDrink>(
                    x => x.HasOne(x => x.Drink)
                        .WithMany(x=>x.OrderDrinks).HasForeignKey(x => x.DrinkId),
                    x => x.HasOne(x => x.Order)
                        .WithMany(x=>x.OrderDrinks).HasForeignKey(x => x.OrderId));
            builder.HasMany(x => x.Pizzas)
                .WithMany(x => x.Orders)
                .UsingEntity<OrderPizza>(
                    x => x.HasOne(x => x.Pizza)
                        .WithMany(x=>x.OrderPizzas).HasForeignKey(x => x.PizzaId),
                    x => x.HasOne(x => x.Order)
                        .WithMany(x=>x.OrderPizzas).HasForeignKey(x => x.OrderId));
            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
            builder.Property(x=>x.Address).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Email).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Phone).IsRequired().HasMaxLength(10);
            builder.Property(x => x.Priority).IsRequired();
            builder.Property(x => x.OrderedAt).IsRequired();
        }
    }
}