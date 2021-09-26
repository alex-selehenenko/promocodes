using Microsoft.EntityFrameworkCore;
using Promocodes.Data.Core.Entities;
using System.Collections.Generic;

namespace Promocodes.Data.Persistence.SeedData
{
    public static class SeedData
    {
        public static void Seed(this ModelBuilder builder)
        {
            SeedUsers(builder);
            SeedCategories(builder);
            SeedShops(builder);
            SeedCategoryShops(builder);
        }

        private static void SeedUsers(ModelBuilder builder)
        {
            builder.Entity<User>()
                .HasData(
                new User()
                {
                    Id = -1,
                    UserName = "alex",
                    Phone = "+380991234567"
                },
                new User()
                {
                    Id = -2,
                    UserName = "serg",
                    Phone = "+380931112233"
                },
                new User()
                {
                    Id = -3,
                    UserName = "jess",
                    Phone = "+380661234545"
                },
                new User()
                {
                    Id = -4,
                    UserName = "qwerty",
                    Phone = "+380501112233"
                });
        }

        private static void SeedCategories(ModelBuilder builder)
        {

            builder.Entity<Category>().HasData(
                new Category()
                {
                    Id = -1,
                    Name = "Electronics"
                },
                new Category()
                {
                    Id = -2,
                    Name = "Baby",
                },
                new Category()
                {
                    Id = -3,
                    Name = "Clothes",
                });
        }

        private static void SeedShops(ModelBuilder builder)
        {
            builder.Entity<Shop>().HasData(
                new Shop()
                {
                    Id = -1,
                    Name = "Electron Plus",
                    Site = "https://eee-plus.com.ua",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit"
                },
                new Shop()
                {
                    Id = -2,
                    Name = "Baby boom",
                    Site = "https://b-a-b-y-boom.com.ua",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit"
                },
                new Shop()
                {
                    Id = -3,
                    Name = "Zebra",
                    Site = "https://zebrrra.biz.ua",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit"
                });
        }

        private static void SeedCategoryShops(ModelBuilder builder)
        {
            builder.Entity<Category>()
                .HasMany(c => c.Shops)
                .WithMany(s => s.Categories)
                .UsingEntity<Dictionary<string, object>>(
                    "CategoryShop",
                    right => right.HasOne<Shop>().WithMany().HasForeignKey("ShopId"),
                    left => left.HasOne<Category>().WithMany().HasForeignKey("CategoryId"),
                    je =>
                    {
                        je.HasKey("ShopId", "CategoryId");
                        je.HasData(
                            new { ShopId = -1, CategoryId = -1 },
                            new { ShopId = -2, CategoryId = -2 },
                            new { ShopId = -3, CategoryId = -3 });
                    });
        }
    }
}
