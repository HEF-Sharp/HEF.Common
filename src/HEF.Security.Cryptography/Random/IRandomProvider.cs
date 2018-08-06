namespace HEF.Security.Cryptography
{
    /// <summary>
    /// 随机数提供程序接口
    /// </summary>
    public interface IRandomProvider
    {
        /// <summary>
        /// 返回一个非负随机整数
        /// </summary>
        /// <returns></returns>
        int Next();

        /// <summary>
        /// 返回一个小于所指定最大值的非负随机整数
        /// </summary>
        /// <param name="maxValue">要生成的随机数字不含上限</param>
        /// <returns></returns>
        int Next(int maxValue);

        /// <summary>
        /// 返回在指定范围内的任意整数
        /// </summary>
        /// <param name="minValue">返回的随机数字包含下限</param>
        /// <param name="maxValue">返回随机数的不含上限</param>
        /// <returns></returns>
        int Next(int minValue, int maxValue);

        /// <summary>
        /// 返回一个大于或等于 0.0 且小于 1.0 的随机浮点数
        /// </summary>
        /// <returns></returns>
        double NextDouble();

        /// <summary>
        /// 用随机数填充指定字节数组的元素
        /// </summary>
        /// <param name="buffer"></param>
        void NextBytes(byte[] buffer);
    }
}
