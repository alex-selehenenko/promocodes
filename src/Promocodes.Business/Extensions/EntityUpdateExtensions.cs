using Promocodes.Business.Services.Models;
using Promocodes.Data.Core.Entities;
using System;
namespace Promocodes.Business.Extensions
{
    public static class EntityUpdateExtensions
    {
        public static Offer ApplyUpdate(this Offer offer, OfferUpdate update)
        {
            if (update is null)
                throw new ArgumentNullException(nameof(update));

            offer.Title = update.Title;
            offer.Description = update.Description;
            offer.Discount = update.Discount;
            offer.Promocode = update.Promocode;
            offer.StartDate = update.StartDate;
            offer.ExpirationDate = update.ExpirationDate;

            return offer;
        }
    }
}
