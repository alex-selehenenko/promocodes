using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Promocodes.Data.Core.Entities;

namespace Promocodes.Data.Persistence.Configurations
{
    public class ShopConfiguration : IEntityTypeConfiguration<Shop>
    {
        public void Configure(EntityTypeBuilder<Shop> builder)
        {
            builder.HasKey(s => s.Id);

            builder.HasIndex(e => e.Name, "UQ_Shop_Name")
                .IsUnique();

            builder.Property(s => s.Name)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(s => s.Site)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
        }
    }
}
