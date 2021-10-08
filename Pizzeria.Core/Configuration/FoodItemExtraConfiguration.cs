using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pizzeria.Core.Models;
using Pizzeria.Core.Models.JoinTables;

namespace Pizzeria.Core.Configuration
{
    public class FoodItemExtraConfiguration : IEntityTypeConfiguration<FoodItemExtra>
    {
        public void Configure(EntityTypeBuilder<FoodItemExtra> builder)
        {
            builder.HasMany(x => x.Orders)
                .WithMany(x => x.FoodItemExtras)
                .UsingEntity<OrderFoodItemExtra>(
                    x => x.HasOne(x => x.Order)
                        .WithMany(x => x.OrderFoodItemExtras).HasForeignKey(x => x.OrderId),
                    x => x.HasOne(x => x.FoodItemExtra)
                        .WithMany(x => x.OrderFoodItemExtras).HasForeignKey(x => x.FoodItemExtraId));

            builder.Property(x => x.Name).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Price).HasPrecision(4, 2).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(200);
        }
    }
}