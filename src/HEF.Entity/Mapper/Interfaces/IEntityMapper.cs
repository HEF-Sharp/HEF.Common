﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;

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
        IEntityMapper<TEntity> Schema(string schemaName);

        IEntityMapper<TEntity> Table(string tableName);

        PropertyMap MapProperty(PropertyInfo propertyInfo);

        PropertyMap MapProperty(Expression<Func<TEntity, object>> propertyExpression);
    }
}
