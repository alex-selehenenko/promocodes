using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Promocodes.Data.Core.Entities;
using Promocodes.Data.Core.Validation;

namespace Promocodes.Data.Persistence.Configurations
{
    public class ShopConfiguration : IEntityTypeConfiguration<Shop>
    {
        public void Configure(EntityTypeBuilder<Shop> builder)
        {
            builder.HasKey(s => s.Id);

            builder.Property(s => s.Id)
                .UseIdentityColumn();

            builder.HasIndex(e => e.Name, "UQ_Shop_Name")
                .IsUnique();

            builder.Property(s => s.Name)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .IsRequired()
                .HasMaxLength(ShopValidator.NameMaxLength);

            builder.Property(s => s.Site)
                .IsRequired()
                .IsUnicode(false);

            builder.Property(s => s.Description)
                .IsRequired()
                .HasMaxLength(ShopValidator.DescriptionMaxLength);

            builder.Property(s => s.Rating)
                .IsRequired();

            builder.HasMany(s => s.Offers)
                .WithOne(s => s.Shop)
                .HasForeignKey(o => o.ShopId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(s => s.Reviews)
                .WithOne(r => r.Shop)
                .HasForeignKey(r => r.ShopId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
