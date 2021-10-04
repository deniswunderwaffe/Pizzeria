using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pizzeria.Core.Models;

namespace Pizzeria.Core.Configuration
{
    public class FoodItemConfiguration:IEntityTypeConfiguration<FoodItem>
    {
        public void Configure(EntityTypeBuilder<FoodItem> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Price).HasPrecision(5,2).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(200);
        }
    }
}