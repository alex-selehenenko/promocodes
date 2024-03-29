﻿using Promocodes.Business.Services.Dto;
using Promocodes.Data.Core.Entities;
using System;

namespace Promocodes.Business.Extensions
{
    public static class EntityUpdateExtensions
    {
        public static Offer ApplyUpdate(this Offer offer, OfferUpdate update)
        {
            if (update is null)
            {
                throw new ArgumentNullException(nameof(update));
            }

            offer.Title = update.Title;
            offer.Description = update.Description;
            offer.Discount = update.Discount;
            offer.Promocode = update.Promocode;
            offer.StartDate = update.StartDate;
            offer.ExpirationDate = update.ExpirationDate;

            return offer;
        }

        public static Review ApplyUpdate(this Review review, ReviewUpdate update)
        {
            review.Text = update.Text;
            review.Stars = update.Stars;
            review.LastUpdateTime = DateTime.Now;

            return review;
        }
    }
}
