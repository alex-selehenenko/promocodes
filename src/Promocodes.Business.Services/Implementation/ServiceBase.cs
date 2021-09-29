using AutoMapper;
using FluentValidation;
using Promocodes.Data.Core.Entities;
using Promocodes.Data.Core.RepositoryInterfaces;
using System;

namespace Promocodes.Business.Services.Implementation
{
    public class ServiceBase<T> where T : IEntity
    {
        protected IUnitOfWork UnitOfWork { get; }

        protected IMapper Mapper { get; }

        protected IValidator<T> Validator { get; }

        public ServiceBase(IMapper mapper, IUnitOfWork unitOfWork, IValidator<T> validator)
        {
            Mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            UnitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            Validator = validator ?? throw new ArgumentNullException(nameof(validator));
        }
    }
}
