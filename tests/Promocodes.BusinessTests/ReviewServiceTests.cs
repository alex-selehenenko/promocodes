using Promocodes.Business.Services.Interfaces;
using Moq;
using Xunit;
using Promocodes.Data.Core.Entities;
using Promocodes.Business.Services.Implementation;
using System.Threading.Tasks;
using Promocodes.Business.Exceptions;
using Promocodes.Data.Core.RepositoryInterfaces;
using Promocodes.Data.Core.Common.Specifications;
using Promocodes.Business.Managers;

namespace Promocodes.BusinessTests
{
    public class ReviewServiceTests
    {
        private readonly IReviewService _reviewService;

        private readonly Mock<IReviewRepository> _reviewRepositoryMock = new();
        private readonly Mock<IUserRepository> _userRepositoryMock = new();
        private readonly Mock<IShopRepository> _shopRepositoryMock = new();
        private readonly Mock<IUserManager> _userManager = new();
        private readonly Mock<IUnitOfWork> _unitOfWorkMock = new();

        public ReviewServiceTests()
        {
            _reviewService = new ReviewService(
                _reviewRepositoryMock.Object,
                _shopRepositoryMock.Object,
                _userManager.Object);
        }

        [Fact]
        public async Task CreateAsync_ValidData()
        {
            var expectedId = 1;
            var expectedShopId = 2;
            var expectedUserId = 3;

            _reviewRepositoryMock
                .Setup(r => r.AddAsync(It.IsAny<Review>()))
                .ReturnsAsync(new Review() { Id = 1, ShopId = 2, UserId = 3 });

            _reviewRepositoryMock
                .Setup(r => r.UnitOfWork)
                .Returns(_unitOfWorkMock.Object);

            _reviewRepositoryMock
                .Setup(r => r.ExistsAsync(It.IsAny<ISpecification<Review>>()))
                .ReturnsAsync(false);

            _shopRepositoryMock
                .Setup(r => r.ExistsAsync(It.IsAny<int>()))
                .ReturnsAsync(true);

            _userRepositoryMock
                .Setup(r => r.ExistsAsync(It.IsAny<int>()))
                .ReturnsAsync(true);

            var review = new Review() { Id = 1, ShopId = 2, UserId = 3 };
            var entity = await _reviewService.CreateAsync(review);

            Assert.Equal(expectedId, entity.Id);
            Assert.Equal(expectedUserId, entity.UserId.Value);
            Assert.Equal(expectedShopId, entity.ShopId);
        }

        [Fact]
        public async Task CreateAsync_ShopHasReviewFromUser_OperationExceptionThrown()
        {
            _reviewRepositoryMock
                .Setup(r => r.ExistsAsync(It.IsAny<ISpecification<Review>>()))
                .ReturnsAsync(true);

            _shopRepositoryMock
                .Setup(r => r.ExistsAsync(It.IsAny<int>()))
                .ReturnsAsync(true);

            _userRepositoryMock
                .Setup(r => r.ExistsAsync(It.IsAny<int>()))
                .ReturnsAsync(true);

            var review = new Review() { UserId = 1, ShopId = 1};

            async Task action() => await _reviewService.CreateAsync(review);

            await Assert.ThrowsAsync<OperationException>(action);
        }

        [Fact]
        public async Task CreateAsync_ShopDoesNotExist_OperationExceptionThrown()
        {
            _reviewRepositoryMock
                .Setup(r => r.ExistsAsync(It.IsAny<ISpecification<Review>>()))
                .ReturnsAsync(false);

            _shopRepositoryMock
                .Setup(r => r.ExistsAsync(It.IsAny<int>()))
                .ReturnsAsync(false);

            _userRepositoryMock
                .Setup(r => r.ExistsAsync(It.IsAny<int>()))
                .ReturnsAsync(true);

            var review = new Review() { UserId = 1, ShopId = 1 };

            async Task action() => await _reviewService.CreateAsync(review);

            await Assert.ThrowsAsync<OperationException>(action);
        }

        [Fact]
        public async Task CreateAsync_UserDoesNotExist_OperationExceptionThrown()
        {
            _reviewRepositoryMock
                .Setup(r => r.ExistsAsync(It.IsAny<ISpecification<Review>>()))
                .ReturnsAsync(false);

            _shopRepositoryMock
                .Setup(r => r.ExistsAsync(It.IsAny<int>()))
                .ReturnsAsync(true);

            _userRepositoryMock
                .Setup(r => r.ExistsAsync(It.IsAny<int>()))
                .ReturnsAsync(false);

            var review = new Review() { UserId = 1, ShopId = 1 };

            async Task action() => await _reviewService.CreateAsync(review);

            await Assert.ThrowsAsync<OperationException>(action);
        }
    }
}
