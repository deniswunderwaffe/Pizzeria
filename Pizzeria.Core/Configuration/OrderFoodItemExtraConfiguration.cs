using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pizzeria.Core.Models.JoinTables;

namespace Pizzeria.Core.Configuration
{
    public class OrderFoodItemExtraConfiguration : IEntityTypeConfiguration<OrderFoodItemExtra>
    {
        public void Configure(EntityTypeBuilder<OrderFoodItemExtra> builder)
        {
            builder.HasAlternateKey(x => new { x.OrderId, x.FoodItemExtraId });
        }
    }
}