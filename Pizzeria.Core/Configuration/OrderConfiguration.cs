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
            builder.HasMany(x => x.FoodItems)
                .WithMany(x => x.Orders)
                .UsingEntity<OrderFoodItem>(
                    x => x.HasOne(x => x.FoodItem)
                        .WithMany(x=>x.OrderFoodItems).HasForeignKey(x => x.FoodItemId),
                    x => x.HasOne(x => x.Order)
                        .WithMany(x=>x.OrderFoodItems).HasForeignKey(x => x.OrderId));

            builder.Property(x => x.Note).HasMaxLength(100);
            builder.Property(x => x.TotalPrice).HasPrecision(6,2);
            builder.Property(x => x.IsCash).HasDefaultValueSql("0");
            builder.Property(x => x.OrderIdentifier).ValueGeneratedOnAdd().HasDefaultValueSql("NEWID()");
            builder.Property(x => x.DesiredDeliveryDateTime).HasColumnType("datetime");
            builder.Property(x => x.OrderedAt).HasColumnType("datetime").HasDefaultValueSql("getdate()");
        }
    }
}