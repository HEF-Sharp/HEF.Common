using System;

namespace HEF.Core
{
    public abstract class HEFResult<TResultType>
        where TResultType : Enum
    {
        /// <summary>
        /// 结果类型
        /// </summary>
        public string Type { get; set; } = default(TResultType).ToString();

        /// <summary>
        /// 结果消息
        /// </summary>
        public string Msg { get; set; }
    }

    public abstract class HEFResult<TResultType, TResultData> : HEFResult<TResultType>
        where TResultType : Enum
    {
        /// <summary>
        /// 结果数据
        /// </summary>
        public TResultData Data { get; set; } = default;
    }
}
