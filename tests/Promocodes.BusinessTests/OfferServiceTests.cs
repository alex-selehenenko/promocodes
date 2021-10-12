using Moq;
using Promocodes.Business.Exceptions;
using Promocodes.Business.Services.Implementation;
using Promocodes.Business.Services.Interfaces;
using Promocodes.Data.Core.Entities;
using Promocodes.Data.Core.RepositoryInterfaces;
using Promocodes.Data.Persistence;
using System.Threading.Tasks;
using Xunit;

namespace Promocodes.BusinessTests
{
    public class OfferServiceTests
    {
        private readonly IOfferService _offerService;

        private readonly Mock<IOfferRepository> _offerRepositoryMock = new();
        private readonly Mock<IShopRepository> _shopRepositoryMock = new();
        private readonly Mock<IUserRepository> _userRepositoryMock = new();
        private readonly Mock<PromocodesDbContext> _dbContextMock = new();

        public OfferServiceTests()
        {
            _offerRepositoryMock.Setup(r => r.UnitOfWork).Returns(_dbContextMock.Object);
            _userRepositoryMock.Setup(r => r.UnitOfWork).Returns(_dbContextMock.Object);
            _shopRepositoryMock.Setup(r => r.UnitOfWork).Returns(_dbContextMock.Object);

            _offerService = new OfferService(_offerRepositoryMock.Object, _userRepositoryMock.Object, _shopRepositoryMock.Object);
        }

        [Fact]
        public async Task CreateAsync_ShopDoesNotExist_OperationExceptionThrown()
        {
            _shopRepositoryMock.Setup(r => r.ExistsAsync(It.IsAny<int>())).ReturnsAsync(false);
            var offer = new Offer() { ShopId = 1 };

            async Task action() => await _offerService.CreateAsync(offer);

            await Assert.ThrowsAsync<OperationException>(action);
        }

        [Fact]
        public async Task CreateAsync_ValidData()
        {
            var id = 1;
            var shopId = 2;

            _offerRepositoryMock
                .Setup(r => r.AddAsync(It.IsAny<Offer>()))
                .ReturnsAsync(new Offer() { Id = 1, ShopId = 2 });

            _shopRepositoryMock
                .Setup(r => r.ExistsAsync(It.IsAny<int>()))
                .ReturnsAsync(true);

            var offer = new Offer() { Id = 1, ShopId = 2 };
            var entity = await _offerService.CreateAsync(offer);

            var actual = entity.Id == id &&
                         entity.ShopId == shopId;

            Assert.True(actual);
        }
    }
}
