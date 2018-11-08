using System;

namespace HEF.Entity.Mapper
{
    public interface IEntityMapperProvider
    {
        /// <summary>
        /// 获取实体Mapper
        /// </summary>
        /// <param name="entityType"></param>
        /// <returns></returns>
        IEntityMapper GetEntityMapper(Type entityType);

        IEntityMapper GetEntityMapper<TEntity>() where TEntity : class;
    }
}
