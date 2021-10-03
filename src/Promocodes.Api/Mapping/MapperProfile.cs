using AutoMapper;
using Promocodes.Api.Dto.Offers;
using Promocodes.Api.Dto.Reviews;
using Promocodes.Api.Dto.Shops;
using Promocodes.Data.Core.Entities;

namespace Promocodes.Api.Mapping
{
    public class MapperProfile : Profile 
    {
        public MapperProfile()
        {
            CreateOfferMaps();
            CreateShopMaps();
            CreateReviewMaps();
        }

        private void CreateOfferMaps()
        {
            CreateMap<OfferPostDto, Offer>();
            CreateMap<OfferPutDto, Offer>();
            CreateMap<Offer, OfferGetDto>();            
        }

        private void CreateReviewMaps()
        {
            CreateMap<ReviewPostDto, Review>();
            CreateMap<ReviewPutDto, Review>();
            CreateMap<Review, ReviewGetDto>();
        }

        private void CreateShopMaps()
        {
            CreateMap<Shop, ShopGetDto>();
        }

        public static MapperProfile Create() => new();
    }
}
