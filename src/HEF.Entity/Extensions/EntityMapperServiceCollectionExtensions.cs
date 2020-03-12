using HEF.Entity.Mapper;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class EntityMapperServiceCollectionExtensions
    {
        public static IServiceCollection AddEntityMapperProvider(this IServiceCollection serviceCollection,
            Type defaultEntityMapper)
        {
            serviceCollection.TryAddSingleton<IEntityMapperProvider>(
                (provider) => new EntityMapperProvider(defaultEntityMapper));

            return serviceCollection;
        }
    }
}
