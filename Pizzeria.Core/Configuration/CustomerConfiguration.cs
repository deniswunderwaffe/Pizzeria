using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pizzeria.Core.Models;

namespace Pizzeria.Core.Configuration
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Email).HasMaxLength(50).IsRequired();
            builder.HasIndex(x => x.Phone).IsUnique();
            builder.Property(x => x.Phone).HasMaxLength(12).IsRequired();
            builder.Property(x => x.IsConfirmed).HasDefaultValueSql("0");
            builder.Property(x => x.Address).HasMaxLength(100).IsRequired();
        }
    }
}