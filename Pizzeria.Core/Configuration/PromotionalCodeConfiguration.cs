using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pizzeria.Core.Models;

namespace Pizzeria.Core.Configuration
{
    public class PromotionalCodeConfiguration:IEntityTypeConfiguration<PromotionalCode>
    {
        public void Configure(EntityTypeBuilder<PromotionalCode> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(20).IsRequired();
            builder.HasIndex(x=>x.Code).IsUnique();
            builder.Property(x => x.Code).HasMaxLength(5).IsRequired();
            builder.Property(x => x.Discount).HasPrecision(4,2).IsRequired();
            builder.Property(x => x.IsActive).HasDefaultValueSql("0");
            builder.Property(x => x.MaximumUses).IsRequired();
            builder.Property(x=>x.ExpirationDate).HasColumnType("datetime");
        }
    }
}