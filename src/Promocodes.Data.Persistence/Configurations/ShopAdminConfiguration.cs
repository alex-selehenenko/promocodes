using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Promocodes.Data.Core.DataConstraints;
using Promocodes.Data.Core.Entities;

namespace Promocodes.Data.Persistence.Configurations
{
    class ShopAdminConfiguration : IEntityTypeConfiguration<ShopAdmin>
    {
        public void Configure(EntityTypeBuilder<ShopAdmin> builder)
        {
            builder.HasKey(admin => admin.Id);

            builder.Property(admin => admin.Id)
                   .HasMaxLength(UserConstraints.MaxUserIdLength);
        }
    }
}
