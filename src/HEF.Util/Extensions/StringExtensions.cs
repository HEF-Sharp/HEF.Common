using System;
using System.Text;
using System.Text.RegularExpressions;

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

        /// <summary>
        /// 获取字节长度
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static int GetBytesLength(this string str)
        {
            if (IsNullOrEmpty(str))
                return 0;

            return Encoding.Default.GetBytes(str).Length;
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

        #region 正则验证
        /// <summary>
        /// 正则验证
        /// </summary>
        /// <param name="str"></param>
        /// <param name="pattern">匹配项</param>
        /// <returns></returns>
        public static bool IsMatch(this string str, string pattern)
        {
            return IsMatch(str, pattern, RegexOptions.IgnoreCase);
        }

        /// <summary>
        /// 正则验证
        /// </summary>
        /// <param name="str"></param>
        /// <param name="pattern">匹配项</param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static bool IsMatch(this string str, string pattern, RegexOptions options)
        {
            if (str.IsNullOrEmpty() || pattern.IsNullOrEmpty())
                return false;

            var regex = new Regex(pattern, options);
            return regex.IsMatch(str);
        }
        #endregion

        #region Int
        /// <summary>
        /// 转换为整数
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static int ParseInt(this string str)
        {
            return ParseInt(str, default);
        }
        /// <summary>
        /// 转换为整数
        /// </summary>
        /// <param name="str"></param>
        /// <param name="defaultValue">默认值</param>
        /// <returns></returns>
        public static int ParseInt(this string str, int defaultValue)
        {
            if (str.IsNullOrEmpty())
                return defaultValue;

            if (int.TryParse(str, out int value))            
                return value;
            
            return defaultValue;
        }
        #endregion

        #region Long
        /// <summary>
        /// 转换为长整型
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static long ParseLong(this string str)
        {
            return ParseLong(str, default);
        }
        /// <summary>
        /// 转换为长整型
        /// </summary>
        /// <param name="str"></param>
        /// <param name="defaultValue">默认值</param>
        /// <returns></returns>
        public static long ParseLong(this string str, long defaultValue)
        {
            if (str.IsNullOrEmpty())
                return defaultValue;

            if (long.TryParse(str, out long value))
                return value;

            return defaultValue;
        }
        #endregion

        #region Decimal
        /// <summary>
        /// 转换为Decimal
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static decimal ParseDecimal(this string str)
        {
            return ParseDecimal(str, default);
        }
        /// <summary>
        /// 转换为Decimal
        /// </summary>
        /// <param name="str"></param>
        /// <param name="defaultValue">默认值</param>
        /// <returns></returns>
        public static decimal ParseDecimal(this string str, decimal defaultValue)
        {
            if (str.IsNullOrEmpty())
                return defaultValue;

            if (decimal.TryParse(str, out decimal value))
                return value;

            return defaultValue;
        }
        #endregion

        #region DateTime
        /// <summary>
        /// 转换为DateTime
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static DateTime ParseDateTime(this string str)
        {
            return ParseDateTime(str, default);
        }
        /// <summary>
        /// 转换为DateTime
        /// </summary>
        /// <param name="str"></param>
        /// <param name="defaultValue">默认值</param>
        /// <returns></returns>
        public static DateTime ParseDateTime(this string str, DateTime defaultValue)
        {
            if (str.IsNullOrEmpty())
                return defaultValue;

            if (DateTime.TryParse(str, out DateTime value))
                return value;

            return defaultValue;
        }
        #endregion
    }
}
