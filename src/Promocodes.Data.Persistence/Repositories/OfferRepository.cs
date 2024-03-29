﻿using Promocodes.Data.Core.Entities;
using Promocodes.Data.Core.RepositoryInterfaces;

namespace Promocodes.Data.Persistence.Repositories
{
    public class OfferRepository : RepositoryBase<Offer, int>, IOfferRepository
    {
        public OfferRepository(PromocodesDbContext context) : base(context)
        {
        }
    }
}
