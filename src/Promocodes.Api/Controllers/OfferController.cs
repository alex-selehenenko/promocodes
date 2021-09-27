using Microsoft.AspNetCore.Mvc;
using Promocodes.Business.Core.Dto.Offers;
using Promocodes.Business.Core.ServiceInterfaces;
using System;
using System.Collections.Generic;

namespace Promocodes.Api.Controllers
{
    [ApiController]
    public class OfferController : Controller
    {
        private readonly IOfferService _offerService;

        public OfferController(IOfferService offerService)
        {
            _offerService = offerService ?? throw new ArgumentNullException(nameof(offerService));
        }
    }
}
