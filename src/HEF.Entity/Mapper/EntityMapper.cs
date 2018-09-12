using HEF.Util;
using System;
using System.Collections.Generic;

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
    }
}
