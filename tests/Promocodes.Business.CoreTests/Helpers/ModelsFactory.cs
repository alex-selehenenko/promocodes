using Promocodes.Business.Core.Dto.Categories;
using Promocodes.Business.Core.Dto.Offers;
using Promocodes.Business.Core.Dto.Reviews;
using Promocodes.Business.Core.Dto.Shops;
using Promocodes.Business.Core.Dto.Users;
using Promocodes.Data.Core.Entities;
using System;
using System.Collections.Generic;

namespace Promocodes.Business.CoreTests.Helpers
{
    public class ModelsFactory
    {
        public static T GetEntity<T>()
        {
            var factory = new Dictionary<Type, Func<object>>()
            {
                [typeof(OfferDto)] = () => InitializeOfferDto(),
                [typeof(Offer)] = () => InitializeOffer(),
                
                [typeof(Review)] = () => InitializeReview(),
                [typeof(ReviewDto)] = () => InitializeReviewDto(),
                
                [typeof(Shop)] = () => InitializeShop(),
                [typeof(ShopDto)] = () => InitializeShopDto(),

                [typeof(Category)] = () => InitializeCategory(),
                [typeof(CategoryDto)] = () => InitializeCategoryDto(),

                [typeof(User)] = () => InitializeUser(),
                [typeof(UserDto)] = () => InitializeUserDto()
            };

            return (T)factory[typeof(T)]();
        }

        // Categories

        private static Category InitializeCategory() => new()
        {
            Id = 1,
            Name = "Name"
        };

        private static CategoryDto InitializeCategoryDto() => new()
        {
            Id = 1,
            Name = "Name"
        };


        // Shops

        private static Shop InitializeShop() => new()
        {
            Id = 1,
            Name = "Name",
            Description = "Description",
            Site = "https://mysite.com",
            Rating = 5
        };

        private static ShopDto InitializeShopDto() => new()
        {
            Id = 1,
            Name = "Name",
            Description = "Description",
            Site = "https://mysite.com",
            Rating = 5
        };


        //Reviews

        private static Review InitializeReview() => new()
        {
            Id = 1,
            Stars = 5,
            Text = "Text",
            UserId = 1,
            ShopId = 1
        };

        private static ReviewDto InitializeReviewDto() => new()
        {
            Id = 1,
            Stars = 5,
            Text = "Text",
            UserId = 1,
            ShopId = 1
        };


        // Offers

        private static Offer InitializeOffer() => new()
        {
            Id = 1,
            Name = "Name",
            Description = "Description",
            Promocode = "Promocode",
            Discount = 0.5f,
            StartDate = new System.DateTime(2021, 9, 27),
            ExpirationDate = new System.DateTime(2021, 9, 30),
            IsDeleted = false,
            Enabled = true,
            ShopId = 1,
        };

        private static OfferDto InitializeOfferDto() => new()
        {
            Id = 1,
            Name = "Name",
            Description = "Description",
            Promocode = "Promocode",
            Discount = 0.5f,
            StartDate = new System.DateTime(2021, 9, 27),
            ExpirationDate = new System.DateTime(2021, 9, 30),
            IsDeleted = false,
            Enabled = true,
            ShopId = 1,
        };


        // Users

        private static User InitializeUser() => new()
        {
            Id = 1,
            UserName = "UserName",
            Phone = "+380991112233"
        };

        private static UserDto InitializeUserDto() => new()
        {
            Id = 1,
            UserName = "UserName",
            Phone = "+380991112233"
        };
    }
}
