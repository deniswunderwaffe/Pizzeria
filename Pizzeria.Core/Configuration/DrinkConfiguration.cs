using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pizzeria.Core.Models.Drinks;

namespace Pizzeria.Core.Configuration
{
    public class DrinkConfiguration:IEntityTypeConfiguration<Drink>
    {
        public void Configure(EntityTypeBuilder<Drink> builder)
        {
            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Brand).IsRequired().HasMaxLength(50);
        }
    }
}