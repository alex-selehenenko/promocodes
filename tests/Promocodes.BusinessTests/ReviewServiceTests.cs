using Promocodes.Business.Services.Interfaces;
using Moq;
using Xunit;
using Promocodes.Data.Core.Entities;
using Promocodes.Business.Services.Implementation;
using System.Threading.Tasks;
using Promocodes.Business.Exceptions;
using Promocodes.Data.Core.RepositoryInterfaces;
using Promocodes.Data.Core.Common.Specifications;
using System.Collections.Generic;
using System.Linq;

namespace Promocodes.BusinessTests
{
    public class ReviewServiceTests
    {
        private readonly IReviewService _reviewService;

        private readonly Mock<IReviewRepository> _reviewRepositoryMock = new();
        private readonly Mock<IShopRepository> _shopRepositoryMock = new();
        private readonly Mock<IUserService> _userServiceMock = new();
        private readonly Mock<IUnitOfWork> _unitOfWorkMock = new();

        public ReviewServiceTests()
        {
            _reviewService = new ReviewService(
                _reviewRepositoryMock.Object,
                _shopRepositoryMock.Object,
                _userServiceMock.Object);
        }

        [Fact]
        public async Task CreateAsync_ValidData()
        {
            var expectedId = 1;
            var expectedShopId = 2;
            string expectedUserId = "abc";

            var reviews = new List<Review>();

            _userServiceMock.Setup(s => s.GetCurrentUserId())
                .Returns("abc");

            _reviewRepositoryMock.Setup(r => r.AddAsync(It.IsAny<Review>()))
                .Callback<Review>(r => reviews.Add(r));

            _reviewRepositoryMock.Setup(r => r.UnitOfWork)
                .Returns(_unitOfWorkMock.Object);

            _reviewRepositoryMock.Setup(r => r.ExistsAsync(It.IsAny<ISpecification<Review>>()))
                .ReturnsAsync(false);

            _shopRepositoryMock.Setup(r => r.ExistsAsync(It.IsAny<int>()))
                .ReturnsAsync(true);

            var review = new Review() { Id = 1, ShopId = 2 };
            await _reviewService.CreateAsync(review);

            var actual = reviews.FirstOrDefault();

            Assert.Equal(expectedId, actual.Id);
            Assert.Equal(expectedUserId, actual.UserId);
            Assert.Equal(expectedShopId, actual.ShopId);
        }

        [Fact]
        public async Task CreateAsync_ShopHasReviewFromUser_OperationExceptionThrown()
        {
            _reviewRepositoryMock.Setup(r => r.ExistsAsync(It.IsAny<ISpecification<Review>>()))
                .ReturnsAsync(true);

            var review = new Review() { ShopId = 1 };

            async Task action() => await _reviewService.CreateAsync(review);

            await Assert.ThrowsAsync<OperationException>(action);
        }

        [Fact]
        public async Task CreateAsync_ShopDoesNotExist_OperationExceptionThrown()
        {
            _reviewRepositoryMock.Setup(r => r.ExistsAsync(It.IsAny<ISpecification<Review>>()))
                .ReturnsAsync(false);

            _shopRepositoryMock.Setup(r => r.ExistsAsync(It.IsAny<int>()))
                .ReturnsAsync(false);

            var review = new Review() { UserId = "abc", ShopId = 1 };

            async Task action() => await _reviewService.CreateAsync(review);

            await Assert.ThrowsAsync<OperationException>(action);
        }
    }
}
