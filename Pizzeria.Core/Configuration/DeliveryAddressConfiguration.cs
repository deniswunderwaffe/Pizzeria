using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pizzeria.Core.Models;

namespace Pizzeria.Core.Configuration
{
    public class DeliveryAddressConfiguration:IEntityTypeConfiguration<DeliveryAddress>
    {
        public void Configure(EntityTypeBuilder<DeliveryAddress> builder)
        {
            builder.Property(x => x.Street).HasMaxLength(100).IsRequired();
        }
    }
}