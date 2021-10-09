using Promocodes.Business.Services.Interfaces;
using System;
using Moq;
using Xunit;
using Promocodes.Data.Persistence;
using Microsoft.EntityFrameworkCore;
using Promocodes.Data.Core.Entities;
using Promocodes.Data.Persistence.Repositories;
using Promocodes.Business.Services.Implementation;
using System.Threading.Tasks;
using Promocodes.Business.Exceptions;
using Promocodes.Data.Core.RepositoryInterfaces;

namespace Promocodes.BusinessTests
{
    public class ReviewServiceTests
    {
        [Fact]
        public void CreateAsync_ShopHasReviewFromUser_OperationExceptionThrown()
        {
            
        }
    }
}
