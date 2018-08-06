using System;
using System.Security.Cryptography;

namespace HEF.Security.Cryptography
{
    /// <summary>
    /// 随机数生成器
    /// </summary>
    public class RandomGenerator : IRandomProvider, IDisposable
    {
        private readonly RandomNumberGenerator _generator;

        public RandomGenerator()
        {
            _generator = RandomNumberGenerator.Create();
        }

        /// <summary>
        /// 返回一个非负随机整数
        /// </summary>
        /// <returns></returns>
        public int Next()
        {
            return Next(Int32.MaxValue);
        }

        /// <summary>
        /// 返回一个小于所指定最大值的非负随机整数
        /// </summary>
        /// <param name="maxValue">要生成的随机数字不含上限</param>
        /// <returns></returns>
        public int Next(int maxValue)
        {
            return Next(0, maxValue);
        }

        /// <summary>
        /// 返回在指定范围内的任意整数
        /// </summary>
        /// <param name="minValue">返回的随机数字包含下限</param>
        /// <param name="maxValue">返回随机数的不含上限</param>
        /// <returns></returns>
        public int Next(int minValue, int maxValue)
        {
            if (minValue >= maxValue)
                throw new ArgumentException("maxValue should be greater than minValue", nameof(maxValue));

            var range = (long)(maxValue - minValue - 1);

            return minValue + (int)Math.Floor(NextDouble() * range);
        }

        /// <summary>
        /// 返回一个大于或等于 0.0 且小于 1.0 的随机浮点数
        /// </summary>
        /// <returns></returns>
        public double NextDouble()
        {
            var buffer = new byte[4];
            NextBytes(buffer);

            return (double)BitConverter.ToUInt32(buffer, 0) / UInt32.MaxValue;
        }

        /// <summary>
        /// 用随机数填充指定字节数组的元素
        /// </summary>
        /// <param name="buffer"></param>
        public void NextBytes(byte[] buffer)
        {
            _generator.GetBytes(buffer);
        }

        public void Dispose()
        {
            _generator.Dispose();
        }
    }
}
