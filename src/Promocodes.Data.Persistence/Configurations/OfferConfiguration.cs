using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Promocodes.Data.Core.Entities;
using System;

namespace Promocodes.Data.Persistence.Configurations
{
    public class OfferConfiguration : IEntityTypeConfiguration<Offer>
    {
        public void Configure(EntityTypeBuilder<Offer> builder)
        {
            builder.HasKey(o => o.Id);

            builder.Property(o => o.Name)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(o => o.Promocode)
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(o => o.Description)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(o => o.Enabled)
                .IsRequired()
                .HasDefaultValue(true);

            builder.Property(o => o.IsDeleted)
                .IsRequired()
                .HasDefaultValue(false);

            builder.Property(o => o.StartDate)
                .IsRequired();

            builder.Property(o => o.ExpirationDate)
                .IsRequired();
        }
    }
}
