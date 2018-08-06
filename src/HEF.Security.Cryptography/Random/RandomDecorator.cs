using System;

namespace HEF.Security.Cryptography
{
    /// <summary>
    /// Random装饰器
    /// </summary>
    public class RandomDecorator : IRandomProvider
    {
        private readonly Random _random;

        public RandomDecorator(Random random)
        {
            _random = random ?? throw new ArgumentNullException(nameof(random));
        }

        public int Next()
        {
            return _random.Next();
        }

        public int Next(int maxValue)
        {
            return _random.Next(maxValue);
        }

        public int Next(int minValue, int maxValue)
        {
            return _random.Next(minValue, maxValue);
        }

        public double NextDouble()
        {
            return _random.NextDouble();
        }

        public void NextBytes(byte[] buffer)
        {
            _random.NextBytes(buffer);
        }
    }
}
