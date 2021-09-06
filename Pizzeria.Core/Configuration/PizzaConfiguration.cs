using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pizzeria.Core.Models;
using Pizzeria.Core.Models.JoinTables;

namespace Pizzeria.Core.Configuration
{
    public class PizzaConfiguration:IEntityTypeConfiguration<Pizza>
    {
        public void Configure(EntityTypeBuilder<Pizza> builder)
        {
            builder.HasMany(x => x.Ingredients)
                .WithMany(x => x.Pizzas)
                .UsingEntity<PizzaIngredient>(
                    x => x.HasOne(x => x.Ingredient)
                        .WithMany(x=>x.PizzaIngredient).HasForeignKey(x => x.IngredientId),
                    x => x.HasOne(x => x.Pizza)
                        .WithMany(x=>x.PizzaIngredient).HasForeignKey(x => x.PizzaId));

            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
            builder.Property(x=>x.Type).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Price).IsRequired();
        }
    }
}