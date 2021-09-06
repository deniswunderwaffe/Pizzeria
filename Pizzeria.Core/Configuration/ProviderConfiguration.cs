using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pizzeria.Core.Models;

namespace Pizzeria.Core.Configuration
{
    public class ProviderConfiguration:IEntityTypeConfiguration<Provider>
    {
        public void Configure(EntityTypeBuilder<Provider> builder)
        {
            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
            builder.Property(x=>x.Country).IsRequired().HasMaxLength(50);
        }
    }
}