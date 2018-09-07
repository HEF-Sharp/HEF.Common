using HEF.Util;
using System;
using System.Reflection;

namespace HEF.Entity.Mapper
{
    /// <summary>
    /// 属性映射
    /// </summary>
    public class PropertyMap : IPropertyMap
    {
        public PropertyMap(PropertyInfo propertyInfo)
        {
            PropertyInfo = propertyInfo ?? throw new ArgumentNullException(nameof(propertyInfo));

            ColumnName = PropertyInfo.Name;
        }

        /// <summary>
        /// Gets the name of the property by using the specified propertyInfo.
        /// </summary>
        public string Name => PropertyInfo.Name;        

        /// <summary>
        /// Gets the column name for the current property.
        /// </summary>
        public string ColumnName { get; private set; }

        /// <summary>
        /// Gets the key type for the current property.
        /// </summary>
        public KeyType KeyType { get; private set; }

        /// <summary>
        /// Gets the ignore status of the current property. If ignored, the current property will not be included in queries.
        /// </summary>
        public bool Ignored { get; private set; }

        /// <summary>
        /// Gets the read-only status of the current property. If read-only, the current property will not be included in INSERT and UPDATE queries.
        /// </summary>
        public bool IsReadOnly { get; private set; }

        /// <summary>
        /// Gets the delete flag status of the current property
        /// </summary>
        public bool IsDeleteFlag { get; private set; }

        /// <summary>
        /// Gets the true value of the delete flag
        /// </summary>
        public object DeleteFlagTrueValue { get; private set; }

        /// <summary>
        /// Gets the property info for the current property.
        /// </summary>
        public PropertyInfo PropertyInfo { get; private set; }

        /// <summary>
        /// Fluently sets the column name for the property.
        /// </summary>
        /// <param name="columnName">The column name as it exists in the database.</param>
        public PropertyMap Column(string columnName)
        {
            if (columnName.IsNullOrWhiteSpace())
                throw new ArgumentNullException(nameof(columnName));

            ColumnName = columnName;
            return this;
        }

        /// <summary>
        /// Fluently sets the key type of the property.
        /// </summary>
        /// <param name="columnName">The column name as it exists in the database.</param>
        public PropertyMap Key(KeyType keyType)
        {
            if (Ignored)
                throw new ArgumentException($"'{Name}' is ignored and cannot be made a key field.");            

            if (IsReadOnly)            
                throw new ArgumentException($"'{Name}' is readonly and cannot be made a key field.");            

            if (IsDeleteFlag)            
                throw new ArgumentException($"'{Name}' is delete flag and cannot be made a key field.");            

            KeyType = keyType;
            return this;
        }

        /// <summary>
        /// Fluently sets the ignore status of the property.
        /// </summary>
        public PropertyMap Ignore()
        {
            if (KeyType != KeyType.NotAKey)
                throw new ArgumentException($"'{Name}' is a key field and cannot be ignored.");            

            Ignored = true;
            return this;
        }

        /// <summary>
        /// Fluently sets the read-only status of the property.
        /// </summary>
        public PropertyMap ReadOnly()
        {
            if (KeyType != KeyType.NotAKey)
                throw new ArgumentException($"'{Name}' is a key field and cannot be marked readonly.");            

            if (IsDeleteFlag)
                throw new ArgumentException($"'{Name}' is a delete flag field and cannot be marked readonly.");            

            IsReadOnly = true;
            return this;
        }

        /// <summary>
        /// Fluently sets the delete flag status of the property
        /// </summary>
        /// <returns></returns>
        public PropertyMap DeleteFlag(object trueValue)
        {
            if (KeyType != KeyType.NotAKey)
                throw new ArgumentException($"'{Name}' is a key field and cannot be marked delete flag.");            

            if (IsReadOnly)
                throw new ArgumentException($"'{Name}' is a readonly field and cannot be marked delete flag.");

            IsDeleteFlag = true;
            DeleteFlagTrueValue = trueValue ?? throw new ArgumentNullException(nameof(trueValue), $"'{Name}' field should provide true value to be marked delete flag.");

            return Ignore();
        }
    }
}
