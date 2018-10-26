using HEF.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace HEF.Entity.Mapper
{
    /// <summary>
    /// 实体映射
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public abstract class EntityMapper<TEntity> : IEntityMapper<TEntity>
        where TEntity : class
    {
        /// <summary>
        /// Gets or sets the schema to use when referring to the corresponding table name in the database.
        /// </summary>
        public string SchemaName { get; protected set; }

        /// <summary>
        /// Gets or sets the table to use in the database.
        /// </summary>
        public string TableName { get; protected set; }

        /// <summary>
        /// A collection of properties that will map to columns in the database table.
        /// </summary>
        public IList<IPropertyMap> Properties { get; private set; }

        public Type EntityType
        {
            get { return typeof(TEntity); }
        }

        public EntityMapper()
        {
            Properties = new List<IPropertyMap>();
            Table(typeof(TEntity).Name);
        }

        public virtual IEntityMapper<TEntity> Schema(string schemaName)
        {
            if (schemaName.IsNullOrWhiteSpace())
                throw new ArgumentNullException(nameof(schemaName));

            SchemaName = schemaName;

            return this;
        }

        public virtual IEntityMapper<TEntity> Table(string tableName)
        {
            if (tableName.IsNullOrWhiteSpace())
                throw new ArgumentNullException(nameof(tableName));

            TableName = tableName;

            return this;
        }

        public virtual PropertyMap MapProperty(PropertyInfo propertyInfo)
        {
            var propertyMap = new PropertyMap(propertyInfo);

            if (Properties.Any(p => string.Compare(p.Name, propertyMap.Name, true) == 0))
                throw new ArgumentException($"Duplicate mapping for property {propertyMap.Name} detected.");
            
            Properties.Add(propertyMap);

            return propertyMap;
        }

        public virtual PropertyMap MapProperty(Expression<Func<TEntity, object>> propertyExpression)
        {
            var propertyInfo = propertyExpression.ParseProperty();

            if (propertyInfo == null)
                throw new ArgumentException("parse property failed", nameof(propertyExpression));

            return MapProperty(propertyInfo);
        }
    }
}
