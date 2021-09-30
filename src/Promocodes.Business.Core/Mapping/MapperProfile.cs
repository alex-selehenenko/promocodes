using AutoMapper;
using Promocodes.Business.Core.Dto.Categories;
using Promocodes.Business.Core.Dto.Offers;
using Promocodes.Business.Core.Dto.Reviews;
using Promocodes.Business.Core.Dto.Shops;
using Promocodes.Business.Core.Dto.Users;
using Promocodes.Data.Core.Entities;

namespace Promocodes.Business.Core.Mapping
{
    public class MapperProfile : Profile 
    {
        public MapperProfile()
        {
            CreateOfferMaps();
            CreateCategoryMaps();
            CreateShopMaps();
            CreateReviewMaps();
            CreateUserMaps();
        }

        private void CreateOfferMaps()
        {
            CreateMap<OfferDto, Offer>();
            CreateMap<Offer, OfferDto>();
            CreateMap<CreateOfferDto, OfferDto>();
        }

        private void CreateReviewMaps()
        {
            CreateMap<ReviewDto, Review>();
            CreateMap<Review, ReviewDto>();
            CreateMap<CreateReviewDto, Review>();
        }

        private void CreateShopMaps()
        {
            CreateMap<ShopDto, Shop>();
            CreateMap<Shop, ShopDto>();
        }

        private void CreateUserMaps()
        {
            CreateMap<UserDto, User>();
            CreateMap<User, UserDto>();
        }

        private void CreateCategoryMaps()
        {
            CreateMap<CategoryDto, Category>();
            CreateMap<Category, CategoryDto>();
        }

        public static MapperProfile Create() => new();
    }
}
