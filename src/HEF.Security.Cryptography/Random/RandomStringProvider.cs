using System;
using System.Text;

namespace HEF.Security.Cryptography
{
    /// <summary>
    /// 随机字符串提供程序
    /// </summary>
    public class RandomStringProvider
    {
        private readonly IRandomProvider _randomProvider;

        public const string Characters = "abcdefghijklmnopqrstuvwxyz0123456789";

        public RandomStringProvider(IRandomProvider randomProvider)
        {
            _randomProvider = randomProvider ?? throw new ArgumentNullException(nameof(randomProvider));
        }

        /// <summary>
        /// 返回纯数字 字符串
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        public string Number(int length)
        {
            var sb = new StringBuilder();

            for (int i = 0; i < length; i++)
            {
                sb.Append(_randomProvider.Next(10).ToString());
            }

            return sb.ToString();
        }

        /// <summary>
        /// 返回纯字母 字符串
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        public string Letter(int length)
        {
            var sb = new StringBuilder();

            for (int i = 0; i < length; i++)
            {
                sb.Append(Characters[_randomProvider.Next(26)]);
            }

            return sb.ToString();
        }

        /// <summary>
        /// 返回数字和字母 字符串
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        public string NumberWithLetter(int length)
        {
            var sb = new StringBuilder();
            var charLength = Characters.Length;

            for (int i = 0; i < length; i++)
            {
                sb.Append(Characters[_randomProvider.Next(charLength)]);
            }

            return sb.ToString();
        }
    }
}
