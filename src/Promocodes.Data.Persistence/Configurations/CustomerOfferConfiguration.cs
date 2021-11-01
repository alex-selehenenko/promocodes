using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Promocodes.Data.Core.DataConstraints;
using Promocodes.Data.Core.Entities;

namespace Promocodes.Data.Persistence.Configurations
{
    public class CustomerOfferConfiguration : IEntityTypeConfiguration<CustomerOffer>
    {
        public void Configure(EntityTypeBuilder<CustomerOffer> builder)
        {
            builder.Property(customer => customer.CustomerId)
                   .HasMaxLength(UserConstraints.MaxUserIdLength)
                   .IsUnicode(false);
        }
    }
}
