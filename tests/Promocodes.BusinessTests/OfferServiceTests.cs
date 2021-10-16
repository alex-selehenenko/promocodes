using Moq;
using Promocodes.Business.Exceptions;
using Promocodes.Business.Managers;
using Promocodes.Business.Services.Implementation;
using Promocodes.Business.Services.Interfaces;
using Promocodes.Data.Core.Entities;
using Promocodes.Data.Core.RepositoryInterfaces;
using System.Threading.Tasks;
using Xunit;

namespace Promocodes.BusinessTests
{
    public class OfferServiceTests
    {
        private readonly IOfferService _offerService;

        private readonly Mock<IOfferRepository> _offerRepositoryMock = new();
        private readonly Mock<IShopRepository> _shopRepositoryMock = new();
        private readonly Mock<ICustomerRepository> _customerRepositoryMock = new();
        private readonly Mock<IUserManager> _userManagerMock = new();
        private readonly Mock<IUnitOfWork> _unitOfWorkMock = new();

        public OfferServiceTests()
        {
            _offerService = new OfferService(
                _offerRepositoryMock.Object,
                _shopRepositoryMock.Object,
                _userManagerMock.Object);
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
            var expectedId = 1;
            var expectedShopId = 2;

            _offerRepositoryMock
                .Setup(r => r.AddAsync(It.IsAny<Offer>()))
                .ReturnsAsync(new Offer() { Id = 1, ShopId = 2 });

            _offerRepositoryMock
                .Setup(r => r.UnitOfWork)
                .Returns(_unitOfWorkMock.Object);

            _shopRepositoryMock
                .Setup(r => r.ExistsAsync(It.IsAny<int>()))
                .ReturnsAsync(true);

            var offer = new Offer() { Id = 1, ShopId = 2 };
            var entity = await _offerService.CreateAsync(offer);

            Assert.Equal(expectedId, entity.Id);
            Assert.Equal(expectedShopId, entity.ShopId.Value);
        }
    }
}
