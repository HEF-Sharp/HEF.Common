namespace HEF.Util
{
    public static class ObjectExtensions
    {
        /// <summary>
        /// 转换字符串
        /// </summary>
        /// <param name="obj">转换对象</param>
        /// <returns></returns>
        public static string ParseString(this object obj)
        {
            return obj?.ToString() ?? string.Empty;
        }

        #region Int
        /// <summary>
        /// 转换对象为Int型，默认返回0
        /// </summary>
        /// <param name="obj">原始对象</param>
        /// <returns></returns>
        public static int ParseInt(this object obj)
        {
            return ParseInt(obj, default);
        }
        /// <summary>
        /// 转换对象为Int型，需输入默认值
        /// </summary>
        /// <param name="obj">原始对象</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns></returns>
        public static int ParseInt(this object obj, int defaultValue)
        {
            string valueString = ParseString(obj);

            return valueString.ParseInt(defaultValue);
        }
        #endregion
    }
}
