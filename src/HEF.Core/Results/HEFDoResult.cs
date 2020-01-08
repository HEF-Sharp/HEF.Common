using HEF.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace HEF.Core
{
    /// <summary>
    /// 处理结果类型
    /// </summary>
    public enum HEFDoResultType
    {
        /// <summary>
        /// 成功
        /// </summary>
        success,
        /// <summary>
        /// 失败
        /// </summary>
        fail,
        /// <summary>
        /// 验证失败
        /// </summary>
        validFail,
        /// <summary>
        /// 未找到
        /// </summary>
        notFound
    }

    public class HEFDoResult : HEFResult<HEFDoResultType>
    {
        /// <summary>
        /// 是否成功
        /// </summary>
        public bool IsSuc => string.Compare(Type, HEFDoResultType.success.ToString()) == 0;

        /// <summary>
        /// 是否验证失败
        /// </summary>
        public bool IsValidFail => string.Compare(Type, HEFDoResultType.validFail.ToString()) == 0;

        /// <summary>
        /// 验证失败结果
        /// </summary>
        public IDictionary<string, string> ValidFailResults { get; set; }

        #region Helper Functions

        #region 执行成功
        /// <summary>
        /// 执行成功
        /// </summary>
        /// <returns></returns>
        public static TDoResult DoSuccess<TDoResult>()
            where TDoResult : HEFDoResult, new()
        {
            return DoSuccess<TDoResult>(null);
        }

        /// <summary>
        /// 执行成功
        /// </summary>
        /// <param name="resultMsg">结果消息</param>
        /// <returns></returns>
        public static TDoResult DoSuccess<TDoResult>(string resultMsg)
            where TDoResult : HEFDoResult, new()
        {
            return new TDoResult { Type = HEFDoResultType.success.ToString(), Msg = resultMsg };
        }

        /// <summary>
        /// 执行成功
        /// </summary>
        /// <returns></returns>
        public static TDoResult DoSuccess<TDoResult, TResultData>()
            where TDoResult : HEFDoResult<TResultData>, new()
        {
            return DoSuccess<TDoResult, TResultData>(default);
        }

        /// <summary>
        /// 执行成功
        /// </summary>
        /// <param name="resultData">结果数据</param>
        /// <returns></returns>
        public static TDoResult DoSuccess<TDoResult, TResultData>(TResultData resultData)
            where TDoResult : HEFDoResult<TResultData>, new()
        {
            return DoSuccess<TDoResult, TResultData>(resultData, null);
        }

        /// <summary>
        /// 执行成功
        /// </summary>
        /// <param name="resultData">结果数据</param>
        /// <param name="resultMsg">结果消息</param>       
        /// <returns></returns>
        public static TDoResult DoSuccess<TDoResult, TResultData>(TResultData resultData, string resultMsg)
            where TDoResult : HEFDoResult<TResultData>, new()
        {
            return new TDoResult { Type = HEFDoResultType.success.ToString(), Msg = resultMsg, Data = resultData };
        }
        #endregion

        #region 执行失败
        /// <summary>
        /// 执行失败
        /// </summary>
        /// <param name="resultMsg">结果消息</param>
        /// <returns></returns>
        public static TDoResult DoFail<TDoResult>(string resultMsg)
            where TDoResult : HEFDoResult, new()
        {
            return new TDoResult { Type = HEFDoResultType.fail.ToString(), Msg = resultMsg };
        }

        /// <summary>
        /// 执行失败
        /// </summary>
        /// <param name="resultMsg">结果消息</param>
        /// <returns></returns>
        public static TDoResult DoFail<TDoResult, TResultData>(string resultMsg)
            where TDoResult : HEFDoResult<TResultData>, new()
        {
            return new TDoResult { Type = HEFDoResultType.fail.ToString(), Msg = resultMsg };
        }
        #endregion

        #region 执行验证
        /// <summary>
        /// 执行验证
        /// </summary>
        /// <param name="validateResults">验证结果集合</param>
        /// <returns></returns>
        public static TDoResult DoValidate<TDoResult>(params ValidationResult[] validateResults)
            where TDoResult : HEFDoResult, new()
        {
            if (validateResults.IsEmpty())
            {
                return DoSuccess<TDoResult>();
            }

            var validFailMsg = string.Join(Environment.NewLine, validateResults.Select(m => m.ErrorMessage));
            var validFailData = validateResults.ToDictionary(m => m.MemberNames.FirstOrDefault(), m => m.ErrorMessage);

            return new TDoResult { Type = HEFDoResultType.validFail.ToString(), Msg = validFailMsg, ValidFailResults = validFailData };
        }

        /// <summary>
        /// 执行验证
        /// </summary>
        /// <param name="validateResults">验证结果集合</param>
        /// <returns></returns>
        public static TDoResult DoValidate<TDoResult, TResultData>(params ValidationResult[] validateResults)
            where TDoResult : HEFDoResult<TResultData>, new()
        {
            if (validateResults.IsEmpty())
            {
                return DoSuccess<TDoResult, TResultData>();
            }

            var validFailMsg = string.Join(Environment.NewLine, validateResults.Select(m => m.ErrorMessage));
            var validFailData = validateResults.ToDictionary(m => m.MemberNames.FirstOrDefault(), m => m.ErrorMessage);

            return new TDoResult { Type = HEFDoResultType.validFail.ToString(), Msg = validFailMsg, ValidFailResults = validFailData };
        }
        #endregion

        #region 执行未找到
        /// <summary>
        /// 执行未找到
        /// </summary>
        /// <param name="resultMsg">结果消息</param>
        /// <returns></returns>
        public static TDoResult DoNotFound<TDoResult>(string resultMsg)
            where TDoResult : HEFDoResult, new()
        {
            return new TDoResult { Type = HEFDoResultType.notFound.ToString(), Msg = resultMsg };
        }

        /// <summary>
        /// 执行未找到
        /// </summary>
        /// <param name="resultMsg">结果消息</param>
        /// <returns></returns>
        public static TDoResult DoNotFound<TDoResult, TResultData>(string resultMsg)
            where TDoResult : HEFDoResult<TResultData>, new()
        {
            return new TDoResult { Type = HEFDoResultType.notFound.ToString(), Msg = resultMsg };
        }
        #endregion

        #endregion
    }

    public class HEFDoResult<TResultData> : HEFDoResult
    {
        /// <summary>
        /// 结果数据
        /// </summary>
        public TResultData Data { get; set; } = default;
    }
}
