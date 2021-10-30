using Moq;
using Promocodes.Business.Exceptions;
using Promocodes.Business.Services.Implementation;
using Promocodes.Business.Services.Interfaces;
using Promocodes.Data.Core.Entities;
using Promocodes.Data.Core.RepositoryInterfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Promocodes.BusinessTests
{
    public class OfferServiceTests
    {
        private readonly IOfferService _offerService;

        private readonly Mock<IOfferRepository> _offerRepositoryMock = new();
        private readonly Mock<IShopRepository> _shopRepositoryMock = new();
        private readonly Mock<IUserService> _userServiceMock = new();
        private readonly Mock<IShopAdminRepository> _shopAdminRepositoryMock = new();
        private readonly Mock<IUnitOfWork> _unitOfWorkMock = new();

        public OfferServiceTests()
        {
            _offerService = new OfferService(
                _offerRepositoryMock.Object,
                _shopRepositoryMock.Object,
                _shopAdminRepositoryMock.Object,
                _userServiceMock.Object);
        }

        [Fact]
        public async Task CreateAsync_NullShopId_OperationExceptionThrown()
        {
            var admin = new ShopAdmin() { ShopId = null };

            _shopAdminRepositoryMock.Setup(rep => rep.FindAsync(It.IsAny<string>()))
                .ReturnsAsync(admin);

            async Task action() => await _offerService.CreateAsync(new());

            await Assert.ThrowsAsync<OperationException>(action);
        }

        [Fact]
        public async Task CreateAsync_ShopDoesNotExist_OperationExceptionThrown()
        {
            var admin = new ShopAdmin() { ShopId = 1 };

            _shopAdminRepositoryMock.Setup(rep => rep.FindAsync(It.IsAny<string>()))
                .ReturnsAsync(admin);

            _shopRepositoryMock.Setup(r => r.ExistsAsync(It.IsAny<int>()))
                .ReturnsAsync(false);

            async Task action() => await _offerService.CreateAsync(new());

            await Assert.ThrowsAsync<OperationException>(action);
        }

        [Fact]
        public async Task CreateAsync_ValidData()
        {
            var admin = new ShopAdmin() { ShopId = 2 };
            var offers = new List<Offer>();

            _shopAdminRepositoryMock.Setup(r => r.FindAsync(It.IsAny<string>()))
                .ReturnsAsync(admin);

            _offerRepositoryMock.Setup(r => r.UnitOfWork)
                .Returns(_unitOfWorkMock.Object);

            _offerRepositoryMock.Setup(r => r.AddAsync(It.IsAny<Offer>()))
                .Callback<Offer>(offer => offers.Add(offer));

            _shopRepositoryMock.Setup(r => r.ExistsAsync(It.IsAny<int>()))
                .ReturnsAsync(true);

            var expectedId = 1;
            var expectedShopId = 2;
            var offer = new Offer() { Id = 1 };

            await _offerService.CreateAsync(offer);
            var actual = offers.FirstOrDefault();

            Assert.Equal(expectedId, actual.Id);
            Assert.Equal(expectedShopId, actual.ShopId.Value);
        }
    }
}
