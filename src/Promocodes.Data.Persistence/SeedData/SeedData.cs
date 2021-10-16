using Microsoft.EntityFrameworkCore;
using Promocodes.Data.Core.Entities;
using System.Collections.Generic;

namespace Promocodes.Data.Persistence.SeedData
{
    public static class SeedData
    {
        public static void Seed(this ModelBuilder builder)
        {
            SeedAdmins(builder);
            SeedCustomers(builder);
            SeedCategories(builder);
            SeedShops(builder);
            SeedCategoryShops(builder);
        }

        private static void SeedAdmins(ModelBuilder builder)
        {
            builder.Entity<ShopAdmin>().HasData(
                new ShopAdmin()
                {
                    Id = 6,
                    Phone = "+30632526897",
                    UserName = "Andrew Admin",
                    ShopId = 1
                },
                new ShopAdmin()
                {
                    Id = 7,
                    Phone = "+30632526899",
                    UserName = "Ben Admin",
                    ShopId = 1
                },
                new ShopAdmin()
                {
                    Id = 8,
                    Phone = "+30632526890",
                    UserName = "Alicia Admin",
                    ShopId = 1
                });
        }

        private static void SeedCustomers(ModelBuilder builder)
        {
            builder.Entity<Customer>()
                .HasData(
                new Customer()
                {
                    Id = 1,
                    UserName = "alex",
                    Phone = "+380631111111"
                },
                new Customer()
                {
                    Id = 2,
                    UserName = "serg",
                    Phone = "+380632222222"
                },
                new Customer()
                {
                    Id = 3,
                    UserName = "jess",
                    Phone = "+380633333333"
                },
                new Customer()
                {
                    Id = 4,
                    UserName = "qwerty",
                    Phone = "+380634444444"
                });
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
