using HEF.Util;
using System;

namespace HEF.Entity.Mapper
{
    public class AutoEntityMapper<TEntity> : EntityMapper<TEntity>
        where TEntity : class
    {
        protected string DeleteFlagPropertyName { get; private set; }

        public virtual IEntityMapper<TEntity> DeleteFlag(string propertyName)
        {
            if (propertyName.IsNullOrWhiteSpace())
                throw new ArgumentNullException(nameof(propertyName));

            DeleteFlagPropertyName = propertyName;

            return this;
        }

        public virtual IEntityMapper<TEntity> AutoMap()
        {
            throw new NotImplementedException();
        }
    }
}
