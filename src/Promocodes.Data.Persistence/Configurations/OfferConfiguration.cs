using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Promocodes.Data.Core.Entities;
using Promocodes.Data.Core.Validation;

namespace Promocodes.Data.Persistence.Configurations
{
    public class OfferConfiguration : IEntityTypeConfiguration<Offer>
    {
        public void Configure(EntityTypeBuilder<Offer> builder)
        {
            builder.HasKey(o => o.Id);

            builder.Property(o => o.Id)
                .UseIdentityColumn();

            builder.Property(o => o.Title)
                .HasMaxLength(OfferValidator.MaxTitleLength)
                .IsRequired();

            builder.Property(o => o.Promocode)
                .HasMaxLength(OfferValidator.MaxPromocodeLength)
                .IsRequired();

            builder.Property(o => o.Description)
                .HasMaxLength(OfferValidator.MaxDescriptionLength)
                .IsRequired();

            builder.Property(o => o.Enabled)
                .IsRequired();

            builder.Property(o => o.IsDeleted)
                .IsRequired();

            builder.Property(o => o.StartDate)
                .IsRequired();

            builder.Property(o => o.ExpirationDate)
                .IsRequired();
        }
    }
}
