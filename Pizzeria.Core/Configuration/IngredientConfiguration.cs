using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pizzeria.Core.Models;

namespace Pizzeria.Core
    .Configuration
{
    public class IngredientConfiguration:IEntityTypeConfiguration<Ingredient>
    {
        public void Configure(EntityTypeBuilder<Ingredient> builder)
        {
            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Type).IsRequired().HasMaxLength(50);
        }
    }
}