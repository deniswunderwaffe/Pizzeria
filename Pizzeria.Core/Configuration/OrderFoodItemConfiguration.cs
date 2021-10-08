using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pizzeria.Core.Models.JoinTables;

namespace Pizzeria.Core.Configuration
{
    public class OrderFoodItemConfiguration : IEntityTypeConfiguration<OrderFoodItem>
    {
        public void Configure(EntityTypeBuilder<OrderFoodItem> builder)
        {
            builder.HasAlternateKey(x => new { x.OrderId, x.FoodItemId });
            builder.HasCheckConstraint("quantity_constraint", "[quantity] > 0");
        }
    }
}