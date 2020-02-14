using System;
using System.Collections.Generic;

namespace HEF.Core
{
    /// <summary>
    /// 分页数据
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class HEFPageData<T> where T : class
    {
        /// <summary>
        /// 页号
        /// </summary>
        public int PageIndex { get; set; }

        /// <summary>
        /// 每页数量
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// 总记录数
        /// </summary>
        public long Total { get; set; }

        /// <summary>
        /// 总页数
        /// </summary>
        public int PageCount
        {
            get
            {
                if (PageSize <= 0) return 0;

                return (int)Math.Ceiling((double)Total / PageSize);
            }
        }

        /// <summary>
        /// 列表数据
        /// </summary>
        public IList<T> Data { get; set; }
    }
}
