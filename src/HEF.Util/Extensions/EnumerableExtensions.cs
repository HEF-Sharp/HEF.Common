using System.Collections.Generic;
using System.Linq;

namespace HEF.Util
{
    public static class EnumerableExtensions
    {
        /// <summary>
        /// 序列（或集合）不包含元素
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static bool IsEmpty<T>(this IEnumerable<T> source)
        {
            if (source == null)
            {
                return true;
            }
            return !source.Any();
        }

        /// <summary>
        /// 序列（或集合）包含元素
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static bool IsNotEmpty<T>(this IEnumerable<T> source)
        {
            if (source == null)
            {
                return false;
            }
            return source.Any();
        }
    }
}
