using Microsoft.EntityFrameworkCore;
using Promocodes.Data.Core.Entities;
using System;
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
            SeedOffers(builder);
            SeedReviews(builder);
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

        private static void SeedReviews(ModelBuilder builder)
        {
            builder.Entity<Review>()
                .HasData(
                new Review()
                {
                    Id = 1,
                    Text = "Very good shop!",
                    Stars = 10,
                    UserId = "698306d9-4478-4a58-8b38-b547e85e2289",
                    ShopId = 1,
                    CreationTime = DateTime.Now,
                    LastUpdateTime = DateTime.Now.AddMilliseconds(1)
                },
                new
                {
                    Id = 2,
                    Text = "Like baby boom. But delivery taskes a wile",
                    Stars = 8,
                    UserId = "698306d9-4478-4a58-8b38-b547e85e2289",
                    ShopId = 2,
                    CreationTime = DateTime.Now,
                    LastUpdateTime = DateTime.Now.AddMilliseconds(1)
                },
                new
                {
                    Id = 3,
                    Text = "Awful service!",
                    Stars = 1,
                    UserId = "698306d9-4478-4a58-8b38-b547e85e2289",
                    ShopId = 3,
                    CreationTime = DateTime.Now,
                    LastUpdateTime = DateTime.Now.AddMilliseconds(1)
                },
                new
                {
                    Id = 4,
                    Text = "Excellent!",
                    Stars = 9,
                    UserId = "82b4753f-8f7f-43d1-a67d-13b531d9512b",
                    ShopId = 3,
                    CreationTime = DateTime.Now,
                    LastUpdateTime = DateTime.Now.AddMilliseconds(1)
                });
        }

        private static void SeedShopAdmin(ModelBuilder builder)
        {
            builder.Entity<ShopAdmin>()
                .HasData(
                new()
                {
                    Id = "e71a1ef0-fcdc-4069-87bb-2b38bdde23ac",
                    ShopId = 1
                },
                new()
                {
                    Id = "b466992a-5ad2-4f8b-ab92-cd1abbbe22e9",
                    ShopId = 2
                },
                new()
                {
                    Id = "766fdfbf-119d-45f7-a148-995bbe1009d0",
                    ShopId = 3
                });
        }

        private static void SeedOffers(ModelBuilder builder)
        {
            builder.Entity<Offer>()
                .HasData(
                new()
                {
                    Id = 1,
                    Title = "Electron Plus October GRAND SALE",
                    Description = "Get 30% discount!",
                    Promocode = "OCTOBER",
                    Discount = 0.3f,
                    StartDate = DateTime.Now,
                    ExpirationDate = DateTime.Now.AddDays(30),
                    ShopId = 1
                },
                new()
                {
                    Id = 2,
                    Title = "Baby Boom FRESH discount",
                    Description = "Hurry up to get 70% discount on TOYS!",
                    Promocode = "OCTOBER",
                    Discount = 0.7f,
                    StartDate = DateTime.Now,
                    ExpirationDate = DateTime.Now.AddDays(10),
                    ShopId = 2
                },
                new()
                {
                    Id = 3,
                    Title = "Zebra SALE",
                    Promocode = "OCTOBER",
                    Description = "Get 50% discount on summer collection!",
                    Discount = 0.5f,
                    StartDate = DateTime.Now,
                    ExpirationDate = DateTime.Now.AddDays(30),
                    ShopId = 3
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
