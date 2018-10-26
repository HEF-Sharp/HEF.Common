using System;
using System.Collections.Generic;
using System.Numerics;

namespace HEF.Entity.Mapper
{
    internal static class TypeMappingExtensions
    {
        #region Mapping Dictionary
        /// <summary>
        /// 属性类型与键类型对应字典
        /// </summary>
        private static IDictionary<Type, KeyType> _propertyTypeKeyTypeMapping = new Dictionary<Type, KeyType>
                                             {
                                                 { typeof(byte), KeyType.Identity }, { typeof(byte?), KeyType.Identity },
                                                 { typeof(sbyte), KeyType.Identity }, { typeof(sbyte?), KeyType.Identity },
                                                 { typeof(short), KeyType.Identity }, { typeof(short?), KeyType.Identity },
                                                 { typeof(ushort), KeyType.Identity }, { typeof(ushort?), KeyType.Identity },
                                                 { typeof(int), KeyType.Identity }, { typeof(int?), KeyType.Identity },
                                                 { typeof(uint), KeyType.Identity}, { typeof(uint?), KeyType.Identity },
                                                 { typeof(long), KeyType.Identity }, { typeof(long?), KeyType.Identity },
                                                 { typeof(ulong), KeyType.Identity }, { typeof(ulong?), KeyType.Identity },
                                                 { typeof(BigInteger), KeyType.Identity }, { typeof(BigInteger?), KeyType.Identity },
                                                 { typeof(Guid), KeyType.Guid }, { typeof(Guid?), KeyType.Guid },
                                             };

        /// <summary>
        /// 属性类型与删除标识True值对应字典
        /// </summary>
        private static IDictionary<Type, object> _propertyTypeDeleteFlagTrueValueMapping = new Dictionary<Type, object>
                                            {
                                                { typeof(bool), true }, { typeof(bool?), true },
                                                { typeof(byte), Convert.ToByte(1) }, { typeof(byte?), Convert.ToByte(1) },
                                                { typeof(sbyte), Convert.ToSByte(1) }, { typeof(sbyte?), Convert.ToSByte(1) },
                                                { typeof(short), Convert.ToInt16(1) }, { typeof(short?), Convert.ToInt16(1) },
                                                { typeof(ushort), Convert.ToUInt16(1) }, { typeof(ushort?), Convert.ToUInt16(1) },
                                                { typeof(string), "Y" }
                                            };
        #endregion

        internal static KeyType GetKeyType(this Type type)
        {
            if (_propertyTypeKeyTypeMapping.ContainsKey(type))            
                return _propertyTypeKeyTypeMapping[type];
            
            return KeyType.Assigned;
        }

        internal static object GetDeleteFlagTrueValue(this Type type)
        {
            if (_propertyTypeDeleteFlagTrueValueMapping.ContainsKey(type))
                return _propertyTypeDeleteFlagTrueValueMapping[type];

            throw new ArgumentException(string.Format("'{0}' Type cannot determine true value of delete flag", type.FullName));
        }
    }
}
