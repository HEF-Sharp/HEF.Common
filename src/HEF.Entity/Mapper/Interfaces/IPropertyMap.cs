using System.Reflection;

namespace HEF.Entity.Mapper
{
    public interface IPropertyMap
    {
        string Name { get; }

        string ColumnName { get; }

        KeyType KeyType { get; }

        bool Ignored { get; }

        /// <summary>
        /// 是否只读(update排除字段)
        /// </summary>
        bool IsReadOnly { get; }

        /// <summary>
        /// 是否删除标识
        /// </summary>
        bool IsDeleteFlag { get; }

        /// <summary>
        /// 删除标识True值
        /// </summary>
        object DeleteFlagTrueValue { get; }        

        PropertyInfo PropertyInfo { get; }
    }
}
