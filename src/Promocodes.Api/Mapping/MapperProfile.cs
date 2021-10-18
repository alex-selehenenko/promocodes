using AutoMapper;
using Promocodes.Api.Dto.Offers;
using Promocodes.Api.Dto.Reviews;
using Promocodes.Api.Dto.Shops;
using Promocodes.Business.Services.Dto;
using Promocodes.Data.Core.Entities;
using Promocodes.Data.Core.QueryFilters;

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
            CreateMap<OfferDto, Offer>();
            CreateMap<OfferDto, OfferUpdate>();
            CreateMap<Offer, OfferGetDto>();      
        }

        private void CreateReviewMaps()
        {
            CreateMap<ReviewPostDto, Review>();
            CreateMap<ReviewDto, ReviewUpdate>();
            CreateMap<Review, ReviewGetDto>();            
        }

        private void CreateShopMaps()
        {
            CreateMap<Shop, ShopGetDto>();
            CreateMap<ShopFilterDto, ShopFilter>();
        }

        public static MapperProfile Create() => new();
    }
}
