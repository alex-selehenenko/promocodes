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
        private readonly Mock<IUserService> _userManagerMock = new();
        private readonly Mock<IShopAdminRepository> _shopAdminRepositoryMock = new();
        private readonly Mock<IUnitOfWork> _unitOfWorkMock = new();

        public OfferServiceTests()
        {
            _offerService = new OfferService(
                _offerRepositoryMock.Object,
                _shopRepositoryMock.Object,
                null,
                _userManagerMock.Object);
        }

        //[Fact]
        //public async Task CreateAsync_NotAdmin_AccessForbiddenExceptionThrown()
        //{
        //    var customer = new Customer() { Role = Role.Customer };

        //    _userManagerMock
        //        .Setup(m => m.GetCurrentUserAsync(It.IsAny<bool>()))
        //        .ReturnsAsync(customer);

        //    async Task action() => await _offerService.CreateAsync(new());

        //    await Assert.ThrowsAsync<AccessForbiddenException>(action);
        //}

        //[Fact]
        //public async Task CreateAsync_NullShopId_OperationExceptionThrown()
        //{
        //    var admin = new ShopAdmin() { Role = Role.ShopAdmin, ShopId = null };

        //    _userManagerMock
        //        .Setup(m => m.GetCurrentUserAsync(It.IsAny<bool>()))
        //        .ReturnsAsync(admin);

        //    async Task action() => await _offerService.CreateAsync(new());

        //    await Assert.ThrowsAsync<OperationException>(action);
        //}

        //[Fact]
        //public async Task CreateAsync_ShopDoesNotExist_OperationExceptionThrown()
        //{
        //    var admin = new ShopAdmin() { ShopId = 1, Role = Role.ShopAdmin };

        //    _userManagerMock
        //        .Setup(m => m.GetCurrentUserAsync(It.IsAny<bool>()))
        //        .ReturnsAsync(admin);

        //    _shopRepositoryMock
        //        .Setup(r => r.ExistsAsync(It.IsAny<int>()))
        //        .ReturnsAsync(false);

        //    async Task action() => await _offerService.CreateAsync(new());

        //    await Assert.ThrowsAsync<OperationException>(action);
        //}

        //[Fact]
        //public async Task CreateAsync_ValidData()
        //{
        //    var admin = new ShopAdmin() { Id = 12, Role = Role.ShopAdmin, ShopId = 2 };
        //    var offers = new List<Offer>();            

        //    _offerRepositoryMock
        //        .Setup(r => r.UnitOfWork)
        //        .Returns(_unitOfWorkMock.Object);

        //    _offerRepositoryMock
        //        .Setup(r => r.AddAsync(It.IsAny<Offer>()))
        //        .Callback<Offer>(offer => offers.Add(offer));

        //    _userManagerMock
        //        .Setup(m => m.GetCurrentUserAsync(It.IsAny<bool>()))
        //        .ReturnsAsync(admin);

        //    _shopRepositoryMock
        //        .Setup(r => r.ExistsAsync(It.IsAny<int>()))
        //        .ReturnsAsync(true);

        //    var expectedId = 1;
        //    var expectedShopId = 2;
        //    var offer = new Offer() { Id = 1 };

        //    await _offerService.CreateAsync(offer);
        //    var actual = offers.FirstOrDefault();

        //    Assert.Equal(expectedId, actual.Id);
        //    Assert.Equal(expectedShopId, actual.ShopId.Value);
        //}
    }
}
