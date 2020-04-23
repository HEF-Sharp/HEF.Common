using System;

namespace HEF.Util.Test
{
    public class Customer
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Phone { get; set; }

        public string City { get; set; }
        
        public decimal Balance { get; set; }

        public int ConsumeCount { get; set; }

        public DateTime CreateTime { get; set; }

        public string IsDel { get; set; }
    }
}
