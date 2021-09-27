using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Promocodes.Business.Core.Mapping;

namespace Promocodes.Business.Core.DependencyInjection
{
    public static class BusinessCoreRegistrator
    {
        public static IServiceCollection AddMapper(this IServiceCollection services) =>
            services.AddSingleton(
                new MapperConfiguration(config =>
                {
                    config.AddProfile(MapperProfile.Create());
                })
                .CreateMapper());
    }
}
