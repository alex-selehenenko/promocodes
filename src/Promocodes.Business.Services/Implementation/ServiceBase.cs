using AutoMapper;
using Promocodes.Data.Core.RepositoryInterfaces;
using System;

namespace Promocodes.Business.Services.Implementation
{
    public abstract class ServiceBase
    {
        protected IUnitOfWork UnitOfWork { get; }

        protected IMapper Mapper { get; }

        protected ServiceBase(IUnitOfWork unitOfWork, IMapper mapper)
        {
            UnitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            Mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }        
    }
}
