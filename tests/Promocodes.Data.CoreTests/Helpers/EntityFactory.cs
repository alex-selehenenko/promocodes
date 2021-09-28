using Promocodes.Data.Core.DataConstraints;
using Promocodes.Data.Core.Entities;
using System;
using System.Collections.Generic;

namespace Promocodes.Data.CoreTests.Helpers
{
    internal class EntityFactory
    {
        public static T Get<T>() where T : EntityBase
        {
            var factory = new Dictionary<Type, Func<object>>()
            {
                [typeof(Offer)] = () => GetOffer(),
                [typeof(Review)] = () => GetReview(),
                [typeof(Category)] = () => GetCategory(),
                [typeof(Shop)] = () => GetShop(),
                [typeof(User)] =() => GetUser()
            };
            return (T)factory[typeof(T)]();
        }

        public static Category GetCategory() => new()
        {
            Id = 1,
            Name = new('a', CategoryConstraints.NameMinLength)
        };

        public static Offer GetOffer() => new()
        {
            Id = 1,
            Description = new string('a', OfferConstraints.MinDescriptionLength),
            Discount = 0.5f,
            Enabled = true,
            ExpirationDate = new DateTime(2021, 01, 02),
            IsDeleted = false,
            Promocode = new('p', OfferConstraints.MinPromocodeLength),
            Title = new string('t', OfferConstraints.MinTitleLength),
            StartDate = new DateTime(2021, 01, 01)
        };

        public static Review GetReview() => new()
        {
            Id = 1,
            Text = new('t', ReviewConstraints.MinTextLength),
            Stars = 1
        };

        public static Shop GetShop() => new()
        {
            Id = 1,
            Name = new('n', ShopConstraints.NameMinLength),
            Description = new('d', ShopConstraints.DescriptionMinLength),
            Site = @"https://mysite.com",
            Rating = ShopConstraints.MinRating
        };

        public static User GetUser() => new()
        {
            Id = 1,
            UserName = new('n', UserConstraints.MinUserNameLength),
            Phone = "+380631112233"
        };
    }
}
