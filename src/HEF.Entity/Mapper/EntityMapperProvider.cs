using System;
using System.Collections.Concurrent;
using System.Reflection;
using System.Linq;
using System.Linq.Expressions;

namespace HEF.Entity.Mapper
{
    public class EntityMapperProvider : IEntityMapperProvider
    {
        /// <summary>
        /// 实体Mapper缓存
        /// </summary>
        private readonly ConcurrentDictionary<Type, IEntityMapper> _entityMappers = new ConcurrentDictionary<Type, IEntityMapper>();

        public EntityMapperProvider(Type defaultEntityMapper)
        {
            DefaultEntityMapper = defaultEntityMapper ?? throw new ArgumentNullException(nameof(defaultEntityMapper));
        }

        protected Type DefaultEntityMapper { get; private set; }

        public IEntityMapper GetEntityMapper<TEntity>() where TEntity : class
        {
            return GetEntityMapper(typeof(TEntity));
        }

        public IEntityMapper GetEntityMapper(Type entityType)
        {
            return _entityMappers.GetOrAdd(entityType, BuildEntityMapperInstance);
        }

        protected virtual IEntityMapper BuildEntityMapperInstance(Type entityType)
        {
            Type mapperType = GetMapperTypeFromAssembly(entityType) ?? DefaultEntityMapper.MakeGenericType(entityType);

            return BuildEntityMapperInstanceFactory(mapperType).Invoke();
        }

        /// <summary>
        /// 从程序集中搜索实体Mapper
        /// </summary>
        /// <param name="entityType"></param>
        /// <returns></returns>
        protected virtual Type GetMapperTypeFromAssembly(Type entityType)
        {
            Func<Assembly, Type> searchMapperTypeFromAssembly = a =>
            {
                Type[] types = a.GetTypes();
                return (from type in types
                        let interfaceType = type.GetInterface(typeof(IEntityMapper<>).FullName)
                        where
                            interfaceType != null &&
                            interfaceType.GetGenericArguments()[0] == entityType
                        select type).SingleOrDefault();
            };

            return searchMapperTypeFromAssembly(entityType.Assembly);
        }

        private static Func<IEntityMapper> BuildEntityMapperInstanceFactory(Type entityMapperType)
        {
            var newEntityMapperExpr = Expression.New(entityMapperType);
            var conversionExpr = Expression.Convert(newEntityMapperExpr, typeof(IEntityMapper));

            return Expression.Lambda<Func<IEntityMapper>>(conversionExpr).Compile();
        }
    }
}
