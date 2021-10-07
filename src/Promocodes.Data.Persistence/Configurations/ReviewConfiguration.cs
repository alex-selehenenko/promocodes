using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Promocodes.Data.Core.DataConstraints;
using Promocodes.Data.Core.Entities;

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
                .HasMaxLength(ReviewConstraints.MaxTextLength)
                .IsRequired();

            builder.Property(r => r.CreationTime)
                .IsRequired();
        }
    }
}
