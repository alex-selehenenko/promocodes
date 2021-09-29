using Microsoft.AspNetCore.Mvc;
using Promocodes.Business.Core.ServiceInterfaces;
using System;

namespace Promocodes.Api.Controllers
{
    [ApiController]
    [Route("api/offer")]
    public class OfferController : Controller
    {
        private readonly IOfferService _offerService;

        public OfferController(IOfferService offerService)
        {
            _offerService = offerService ?? throw new ArgumentNullException(nameof(offerService));
        }
    }
}
