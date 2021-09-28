using AutoMapper;
using Promocodes.Data.Core.RepositoryInterfaces;
using System;

namespace Promocodes.Business.Services.Implementation
{
    public class ServiceBase
    {
        protected IUnitOfWork UnitOfWork { get; }

        protected IMapper Mapper { get; }

        public ServiceBase(IMapper mapper, IUnitOfWork unitOfWork)
        {
            Mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            UnitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }
    }
}
