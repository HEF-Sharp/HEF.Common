using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace HEF.Entity
{
    public static class TypeReflectionExtensions
    {
        private static readonly ConcurrentDictionary<Type, IDictionary<string, PropertyInfo>> _cachedProperties 
            = new ConcurrentDictionary<Type, IDictionary<string, PropertyInfo>>();

        #region Properties
        public static PropertyInfo[] GetPublicProperties(this Type type)
        {
            var propertyDict = GetPropertyDict(type);

            return propertyDict.Select(m => m.Value).ToArray();
        }

        private static IDictionary<string, PropertyInfo> GetPropertyDict(Type type)
        {
            return _cachedProperties.GetOrAdd(type, BuildPropertyDictionary);
        }

        private static IDictionary<string, PropertyInfo> BuildPropertyDictionary(Type type)
        {
            var result = new Dictionary<string, PropertyInfo>();

            var properties = type.GetTypeInfo().GetProperties();
            foreach (var property in properties)
            {
                result.Add(property.Name, property);
            }
            return result;
        }
        #endregion
    }
}
