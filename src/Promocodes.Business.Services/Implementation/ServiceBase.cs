using Promocodes.Data.Core.RepositoryInterfaces;
using System;

namespace Promocodes.Business.Services.Implementation
{
    public abstract class ServiceBase
    {
        protected IUnitOfWork UnitOfWork { get; }

        protected ServiceBase(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }        
    }
}
