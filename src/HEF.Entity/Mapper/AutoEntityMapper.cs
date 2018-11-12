using HEF.Util;
using System;
using System.Linq;

namespace HEF.Entity.Mapper
{
    public abstract class AutoEntityMapper<TEntity> : EntityMapper<TEntity>
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
            bool hasDefinedKey = Properties.Any(p => p.KeyType != KeyType.NotAKey);

            bool hasDefinedDeleteFlag = Properties.Any(p => p.IsDeleteFlag);           

            foreach (var propertyInfo in EntityType.GetPublicProperties())
            {
                if (Properties.Any(p => string.Compare(p.Name, propertyInfo.Name, true) == 0))
                    continue;

                var propertyMap = MapProperty(propertyInfo);

                if (!hasDefinedKey)   //自动映射属性之前没有定义Key
                {
                    if (string.Compare(propertyMap.Name, "id", true) == 0)  //默认取属性名为id的作为key
                    {
                        propertyMap.Key(propertyInfo.PropertyType.GetKeyType());
                        hasDefinedKey = true;
                    }
                }

                if (!hasDefinedDeleteFlag)  //自动映射属性之前没有定义删除标识
                {
                    if (string.Compare(propertyMap.Name, DeleteFlagPropertyName, true) == 0)
                    {
                        propertyMap.DeleteFlag(propertyInfo.PropertyType.GetDeleteFlagTrueValue());
                        hasDefinedDeleteFlag = true;
                    }
                }
            }

            return this;
        }
    }
}
