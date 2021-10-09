using Promocodes.Business.Services.Interfaces;
using Moq;
using Xunit;
using Promocodes.Data.Core.Entities;
using Promocodes.Business.Services.Implementation;
using System.Threading.Tasks;
using Promocodes.Business.Exceptions;
using Promocodes.Data.Core.RepositoryInterfaces;
using Promocodes.Data.Core.Common.Specifications;

namespace Promocodes.BusinessTests
{
    public class ReviewServiceTests
    {
        [Fact]
        public async Task CreateAsync_ShopHasReviewFromUser_OperationExceptionThrown()
        {
            var service = SetupCreateMethod(reviewExists: true, userExists: true, shopExists: true);
            var review = new Review() { UserId = 1, ShopId = 1};

            async Task action() => await service.CreateAsync(review);

            await Assert.ThrowsAsync<OperationException>(action);
        }

        [Fact]
        public async Task CreateAsync_ShopDoesNotExist_OperationExceptionThrown()
        {
            var service = SetupCreateMethod(reviewExists: false, userExists: true, shopExists: false);
            var review = new Review() { UserId = 1, ShopId = 1 };

            async Task action() => await service.CreateAsync(review);

            await Assert.ThrowsAsync<OperationException>(action);
        }

        [Fact]
        public async Task CreateAsync_UserDoesNotExist_OperationExceptionThrown()
        {
            var service = SetupCreateMethod(reviewExists: false, userExists: false, shopExists: true);
            var review = new Review() { UserId = 1, ShopId = 1 };

            async Task action() => await service.CreateAsync(review);

            await Assert.ThrowsAsync<OperationException>(action);
        }

        private static IReviewService SetupCreateMethod(bool reviewExists, bool userExists, bool shopExists)
        {
            var reviewRepoMock = new Mock<IReviewRepository>();
            var userRepoMock = new Mock<IUserRepository>();
            var shopRepoMock = new Mock<IShopRepository>();

            reviewRepoMock.Setup(r => r.ExistsAsync(It.IsAny<ISpecification<Review>>())).ReturnsAsync(reviewExists);
            userRepoMock.Setup(r => r.ExistsAsync(It.IsAny<int>())).ReturnsAsync(userExists);
            shopRepoMock.Setup(r => r.ExistsAsync(It.IsAny<int>())).ReturnsAsync(shopExists);

            return new ReviewService(reviewRepoMock.Object, shopRepoMock.Object, userRepoMock.Object);
        }
    }
}
