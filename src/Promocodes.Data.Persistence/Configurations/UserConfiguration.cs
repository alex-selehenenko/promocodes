using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Promocodes.Data.Core.Entities;

namespace Promocodes.Data.Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);

            builder.HasIndex(u => u.Phone, "UQ_User_Phone")
                .IsUnique();

            builder.Property(u => u.Phone)
                .IsRequired()
                .HasMaxLength(11)
                .IsUnicode(false);
        }
    }
}
