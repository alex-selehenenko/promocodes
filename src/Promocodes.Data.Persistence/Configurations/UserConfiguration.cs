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

            builder.Property(u => u.Id)
                .UseIdentityColumn();

            builder.HasIndex(u => u.Phone, "UQ_User_Phone")
                .IsUnique();

            builder.Property(u => u.Phone)
                .IsRequired()
                .HasMaxLength(14)
                .IsUnicode(false);

            builder.Property(u => u.UserName)
                .HasMaxLength(50);
        }
    }
}
