using System;
using System.Text;

namespace HEF.Util
{
    public static class StringExtensions
    {
        /// <summary>
        /// 判断空字符串
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsNullOrEmpty(this string str)
        {
            return (str ?? "").Length == 0;
        }

        #region Base64转换
        /// <summary>
        /// 转换为Base64字符串
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string ToBase64String(this string str)
        {
            return str.ToBase64String("utf-8");
        }

        /// <summary>
        /// 转换为Base64字符串
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string ToBase64String(this string str, string encodeName)
        {
            if (str.IsNullOrEmpty())
                return string.Empty;

            var bytes = Encoding.GetEncoding(encodeName).GetBytes(str);

            return Convert.ToBase64String(bytes);
        }

        /// <summary>
        /// 解密Base64字符串
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string FromBase64String(this string str)
        {
            return str.FromBase64String("utf-8");
        }

        /// <summary>
        /// 解密Base64字符串
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string FromBase64String(this string str, string encodeName)
        {
            if (str.IsNullOrEmpty())
                return string.Empty;

            var bytes = Convert.FromBase64String(str);

            return Encoding.GetEncoding(encodeName).GetString(bytes);
        }
        #endregion
    }
}
