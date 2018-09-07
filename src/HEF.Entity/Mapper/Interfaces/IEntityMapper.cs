using System;
using System.Collections.Generic;

namespace HEF.Entity.Mapper
{
    /// <summary>
    /// 实体映射接口
    /// </summary>
    public interface IEntityMapper
    {
        string SchemaName { get; }

        string TableName { get; }

        IList<IPropertyMap> Properties { get; }

        Type EntityType { get; }
    }

    /// <summary>
    /// 泛型实体映射接口
    /// </summary>
    public interface IEntityMapper<TEntity> : IEntityMapper
        where TEntity : class
    {

    }
}
