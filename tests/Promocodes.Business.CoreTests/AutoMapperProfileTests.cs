using AutoMapper;
using NUnit.Framework;
using Promocodes.Business.Core.Dto.Categories;
using Promocodes.Business.Core.Dto.Offers;
using Promocodes.Business.Core.Dto.Reviews;
using Promocodes.Business.Core.Dto.Shops;
using Promocodes.Business.Core.Dto.Users;
using Promocodes.Business.Core.Mapping;
using Promocodes.Business.CoreTests.Helpers;
using Promocodes.Data.Core.Entities;

namespace Promocodes.Business.CoreTests
{
    [TestFixture]
    public class Tests
    {
        private IMapper _mapper;

        [SetUp]
        public void Setup()
        {
            var configProfile = MapperProfile.Create();

            _mapper = new MapperConfiguration(config =>
                config.AddProfile(configProfile))
                .CreateMapper();
        }

        [Test]
        public void MapOffer_EntityToDto()
        {
            var entity = ModelsFactory.GetEntity<Offer>();
            var dto = _mapper.Map<OfferDto>(entity);

            var actual = CheckOffer(entity, dto);

            Assert.IsTrue(actual);
        }

        [Test]
        public void MapOffer_DtoToEntity()
        {
            var dto = ModelsFactory.GetEntity<OfferDto>();
            var entity = _mapper.Map<Offer>(dto);

            var actual = CheckOffer(entity, dto);

            Assert.IsTrue(actual);
        }

        [Test]
        public void MapReview_EntityToDto()
        {
            var entity = ModelsFactory.GetEntity<Review>();
            var dto = _mapper.Map<ReviewDto>(entity);

            var actual = CheckReview(entity, dto);

            Assert.IsTrue(actual);
        }

        [Test]
        public void MapReview_DtoToEntity()
        {
            var dto = ModelsFactory.GetEntity<ReviewDto>();
            var entity = _mapper.Map<Review>(dto);

            var actual = CheckReview(entity, dto);

            Assert.IsTrue(actual);
        }

        [Test]
        public void MapShop_EntityToDto()
        {
            var entity = ModelsFactory.GetEntity<Shop>();
            var dto = _mapper.Map<ShopDto>(entity);

            var actual = CheckShop(entity, dto);

            Assert.IsTrue(actual);
        }

        [Test]
        public void MapShop_DtoToEntity()
        {
            var dto = ModelsFactory.GetEntity<ShopDto>();
            var entity = _mapper.Map<Shop>(dto);

            var actual = CheckShop(entity, dto);

            Assert.IsTrue(actual);
        }

        [Test]
        public void MapCategory_EntityToDto()
        {
            var entity = ModelsFactory.GetEntity<Category>();
            var dto = _mapper.Map<CategoryDto>(entity);

            var actual = CheckCategory(entity, dto);

            Assert.IsTrue(actual);
        }

        [Test]
        public void MapCategory_DtoToEntity()
        {
            var dto = ModelsFactory.GetEntity<CategoryDto>();
            var entity = _mapper.Map<Category>(dto);

            var actual = CheckCategory(entity, dto);

            Assert.IsTrue(actual);
        }

        [Test]
        public void MapUser_EntityToDto()
        {
            var entity = ModelsFactory.GetEntity<User>();
            var dto = _mapper.Map<UserDto>(entity);

            var actual = CheckUser(entity, dto);

            Assert.IsTrue(actual);
        }

        [Test]
        public void MapUser_DtoToEntity()
        {
            var dto = ModelsFactory.GetEntity<UserDto>();
            var entity = _mapper.Map<User>(dto);

            var actual = CheckUser(entity, dto);

            Assert.IsTrue(actual);
        }

        private static bool CheckOffer(Offer entity, OfferDto dto) =>
            dto.Id == entity.Id &&
            dto.Title == entity.Title &&
            dto.Promocode == entity.Promocode &&
            dto.ShopId == entity.ShopId &&
            dto.StartDate == entity.StartDate &&
            dto.ExpirationDate == entity.ExpirationDate &&
            dto.Description == entity.Description &&
            dto.Discount == entity.Discount &&
            dto.Enabled == entity.Enabled;

        private static bool CheckUser(User entity, UserDto dto) =>
            dto.Id == entity.Id &&
            dto.UserName == entity.UserName &&
            dto.Phone == entity.Phone;

        private static bool CheckReview(Review entity, ReviewDto dto) =>
            dto.Id == entity.Id &&
            dto.CreationTime == entity.CreationTime &&
            dto.ShopId == entity.ShopId &&
            dto.Stars == entity.Stars &&
            dto.Text == entity.Text &&
            dto.UserId == entity.UserId;

        private static bool CheckShop(Shop entity, ShopDto dto) =>
            dto.Id == entity.Id &&
            dto.Description == entity.Description &&
            dto.Name == entity.Name &&
            dto.Rating == entity.Rating &&
            dto.Site == entity.Site;

        private static bool CheckCategory(Category entity, CategoryDto dto) =>
            dto.Id == entity.Id &&
            dto.Name == entity.Name;
    }
}