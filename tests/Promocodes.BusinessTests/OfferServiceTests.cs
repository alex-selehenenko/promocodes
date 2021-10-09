using Moq;
using Promocodes.Business.Exceptions;
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
        [Fact]
        public async Task CreateAsync_ShopDoesNotExist_OperationExceptionThrown()
        {
            var service = SetupCreateMethod(false);
            var offer = new Offer() { ShopId = 1 };

            async Task action() => await service.CreateAsync(offer);

            await Assert.ThrowsAsync<OperationException>(action);
        }

        private static IOfferService SetupCreateMethod(bool shopExist)
        {
            var offerRepoMock = new Mock<IOfferRepository>();
            var shopRepoMock = new Mock<IShopRepository>();
            var userRepoMock = new Mock<IUserRepository>();

            shopRepoMock.Setup(r => r.ExistsAsync(It.IsAny<int>())).ReturnsAsync(shopExist);

            return new OfferService(offerRepoMock.Object, userRepoMock.Object, shopRepoMock.Object);
        }
    }
}
