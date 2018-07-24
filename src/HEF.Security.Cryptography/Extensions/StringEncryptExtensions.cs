using HEF.Util;
using System;
using System.Security.Cryptography;
using System.Text;

namespace HEF.Security.Cryptography
{
    public static class StringEncryptExtensions
    {
        #region MD5
        /// <summary>
        /// MD5加密 字符串
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string ToMD5(this string str)
        {
            return ToMD5(str, "utf-8");
        }
        /// <summary>
        /// MD5加密 字符串
        /// </summary>
        /// <param name="str"></param>
        /// <param name="encodeName">编码格式</param>
        /// <returns></returns>
        public static string ToMD5(this string str, string encodeName)
        {
            if (str.IsNullOrEmpty())
                return string.Empty;

            var bytes = Encoding.GetEncoding(encodeName).GetBytes(str);

            return ToMD5(bytes);
        }

        /// <summary>
        /// MD5加密 二进制流
        /// </summary>
        /// <param name="bytes">二进制流</param>
        /// <returns></returns>
        public static string ToMD5(this byte[] bytes)
        {
            if (bytes.IsEmpty())            
                return string.Empty;

            using (var md5 = MD5.Create())
            {
                byte[] md5Hash = md5.ComputeHash(bytes);
                string result = BitConverter.ToString(md5Hash);

                return result.Replace("-", "");
            }
        }
        #endregion
    }
}
