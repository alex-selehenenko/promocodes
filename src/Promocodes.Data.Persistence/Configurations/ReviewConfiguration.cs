using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Promocodes.Data.Core.Entities;
using Promocodes.Data.Core.Validation;

namespace Promocodes.Data.Persistence.Configurations
{
    public class ReviewConfiguration : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder.HasKey(r => r.Id);

            builder.Property(r => r.Id)
                .UseIdentityColumn();

            builder.Property(r => r.Stars)
                .IsRequired();

            builder.Property(r => r.Text)
                .HasMaxLength(ReviewValidator.MaxTextLength)
                .IsRequired();

            builder.Property(r => r.CreationTime)
                .IsRequired();
        }
    }
}
