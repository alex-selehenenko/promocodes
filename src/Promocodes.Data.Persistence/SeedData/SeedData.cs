using Microsoft.EntityFrameworkCore;
using Promocodes.Data.Core.Entities;
using System.Collections.Generic;

namespace Promocodes.Data.Persistence.SeedData
{
    public static class SeedData
    {
        public static void Seed(this ModelBuilder builder)
        {            
            SeedCategories(builder);
            SeedShops(builder);
            SeedShopAdmin(builder);
            SeedCategoryShops(builder);
        }       

        private static void SeedCategories(ModelBuilder builder)
        {

            builder.Entity<Category>().HasData(
                new Category()
                {
                    Id = 1,
                    Name = "Electronics"
                },
                new Category()
                {
                    Id = 2,
                    Name = "Baby",
                },
                new Category()
                {
                    Id = 3,
                    Name = "Clothes",
                });
        }       

        private static void SeedShops(ModelBuilder builder)
        {
            builder.Entity<Shop>().HasData(
                new Shop()
                {
                    Id = 1,
                    Name = "Electron Plus",
                    Site = "https://eee-plus.com.ua",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit"
                },
                new Shop()
                {
                    Id = 2,
                    Name = "Baby boom",
                    Site = "https://b-a-b-y-boom.com.ua",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit"
                },
                new Shop()
                {
                    Id = 3,
                    Name = "Zebra",
                    Site = "https://zebrrra.biz.ua",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit"
                });
        }

        private static void SeedShopAdmin(ModelBuilder builder)
        {
            builder.Entity<ShopAdmin>().HasData(
                new ShopAdmin()
                {
                    Id = "e71a1ef0-fcdc-4069-87bb-2b38bdde23ac",
                    ShopId = 1
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
                            new { ShopId = 1, CategoryId = 1 },
                            new { ShopId = 2, CategoryId = 2 },
                            new { ShopId = 3, CategoryId = 3 });
                    });
        }
    }
}
