using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Promocodes.Data.Core.DataConstraints;
using Promocodes.Data.Core.Entities;

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
                .HasMaxLength(OfferConstraints.MaxTitleLength)
                .IsRequired();

            builder.Property(o => o.Promocode)
                .HasMaxLength(OfferConstraints.MaxPromocodeLength)
                .IsRequired();

            builder.Property(o => o.Description)
                .HasMaxLength(OfferConstraints.MaxDescriptionLength)
                .IsRequired();

            builder.Property(o => o.IsEnabled)
                .IsRequired();

            builder.Property(o => o.IsDeleted)
                .IsRequired();

            builder.Property(o => o.StartDate)
                .IsRequired();

            builder.Property(o => o.ExpirationDate)
                .IsRequired();

            builder.HasMany(o => o.Users)
                .WithMany(u => u.Offers);
        }
    }
}
