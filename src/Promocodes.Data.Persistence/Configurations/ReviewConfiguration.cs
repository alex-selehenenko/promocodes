using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Promocodes.Data.Core.Entities;

namespace Promocodes.Data.Persistence.Configurations
{
    public class ReviewConfiguration : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder.HasKey(r => r.Id);

            builder.Property(r => r.Stars)
                .IsRequired()
                .HasDefaultValue(5);

            builder.Property(r => r.Text)
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(r => r.CreationTime)
                .IsRequired();
        }
    }
}
