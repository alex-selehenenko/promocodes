using Promocodes.Data.Core.Common;
using System;

namespace Promocodes.Business.Core.Dto.Offers
{
    public class EditOfferDto : IdentityBase<int>, IDto
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string Promocode { get; set; }

        public float Discount { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime ExpirationDate { get; set; }
    }
}
