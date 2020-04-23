using System;
using Xunit;

namespace HEF.Util.Test
{
    public class DynamicConvertTest
    {
        [Fact]
        public void TestToDictionaryByExpression()
        {
            var custom = new Customer
            {
                Id = 10206060,
                Name = "张三",
                Phone = "15952623186",
                City = "Hangzhou",
                Balance = 5982m,
                ConsumeCount = 57,
                CreateTime = DateTime.UtcNow,
                IsDel = "N"
            };

            var dict = custom.ToDictionaryByExpression();

            Assert.NotNull(dict);
            Assert.Equal(8, dict.Count);
        }

        [Fact]
        public void TestToDictionaryByDynamicEmit()
        {
            var custom = new Customer
            {
                Id = 10206060,
                Name = "张三",
                Phone = "15952623186",
                City = "Hangzhou",
                Balance = 5982m,
                ConsumeCount = 57,
                CreateTime = DateTime.UtcNow,
                IsDel = "N"
            };

            var dict = custom.ToDictionaryByDynamicEmit();

            Assert.NotNull(dict);
            Assert.Equal(8, dict.Count);
        }
    }
}
