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
        public static HEFDoResult DoSuccess()
        {
            return DoSuccess(null);
        }

        /// <summary>
        /// 执行成功
        /// </summary>
        /// <param name="resultMsg">结果消息</param>
        /// <returns></returns>
        public static HEFDoResult DoSuccess(string resultMsg)
        {
            return new HEFDoResult { Type = HEFDoResultType.success.ToString(), Msg = resultMsg };
        }

        /// <summary>
        /// 执行成功
        /// </summary>
        /// <returns></returns>
        public static HEFDoResult<TResultData> DoSuccess<TResultData>()
        {
            return DoSuccess<TResultData>(default);
        }

        /// <summary>
        /// 执行成功
        /// </summary>
        /// <param name="resultData">结果数据</param>
        /// <returns></returns>
        public static HEFDoResult<TResultData> DoSuccess<TResultData>(TResultData resultData)
        {
            return DoSuccess(resultData, null);
        }

        /// <summary>
        /// 执行成功
        /// </summary>
        /// <param name="resultData">结果数据</param>
        /// <param name="resultMsg">结果消息</param>       
        /// <returns></returns>
        public static HEFDoResult<TResultData> DoSuccess<TResultData>(TResultData resultData, string resultMsg)
        {
            return new HEFDoResult<TResultData> { Type = HEFDoResultType.success.ToString(), Msg = resultMsg, Data = resultData };
        }
        #endregion

        #region 执行失败
        /// <summary>
        /// 执行失败
        /// </summary>
        /// <param name="resultMsg">结果消息</param>
        /// <returns></returns>
        public static HEFDoResult DoFail(string resultMsg)
        {
            return new HEFDoResult { Type = HEFDoResultType.fail.ToString(), Msg = resultMsg };
        }

        /// <summary>
        /// 执行失败
        /// </summary>
        /// <param name="resultMsg">结果消息</param>
        /// <returns></returns>
        public static HEFDoResult<TResultData> DoFail<TResultData>(string resultMsg)
        {
            return new HEFDoResult<TResultData> { Type = HEFDoResultType.fail.ToString(), Msg = resultMsg };
        }
        #endregion

        #region 执行验证
        /// <summary>
        /// 执行验证
        /// </summary>
        /// <param name="validateResults">验证结果集合</param>
        /// <returns></returns>
        public static HEFDoResult DoValidate(params ValidationResult[] validateResults)
        {
            if (validateResults.IsEmpty())
            {
                return DoSuccess();
            }

            var validFailMsg = string.Join(Environment.NewLine, validateResults.Select(m => m.ErrorMessage));
            var validFailData = validateResults.ToDictionary(m => m.MemberNames.FirstOrDefault(), m => m.ErrorMessage);

            return new HEFDoResult { Type = HEFDoResultType.validFail.ToString(), Msg = validFailMsg, ValidFailResults = validFailData };
        }

        /// <summary>
        /// 执行验证
        /// </summary>        
        /// <param name="validateResults">验证结果集合</param>
        /// <returns></returns>
        public static HEFDoResult<TResultData> DoValidate<TResultData>(params ValidationResult[] validateResults)
        {
            if (validateResults.IsEmpty())
            {
                return DoSuccess<TResultData>();
            }

            var validFailMsg = string.Join(Environment.NewLine, validateResults.Select(m => m.ErrorMessage));
            var validFailData = validateResults.ToDictionary(m => m.MemberNames.FirstOrDefault(), m => m.ErrorMessage);

            return new HEFDoResult<TResultData> { Type = HEFDoResultType.validFail.ToString(), Msg = validFailMsg, ValidFailResults = validFailData };
        }
        #endregion

        #region 执行未找到
        /// <summary>
        /// 执行未找到
        /// </summary>
        /// <param name="resultMsg">结果消息</param>
        /// <returns></returns>
        public static HEFDoResult DoNotFound(string resultMsg)
        {
            return new HEFDoResult { Type = HEFDoResultType.notFound.ToString(), Msg = resultMsg };
        }

        /// <summary>
        /// 执行未找到
        /// </summary>
        /// <param name="resultMsg">结果消息</param>
        /// <returns></returns>
        public static HEFDoResult<TResultData> DoNotFound<TResultData>(string resultMsg)
        {
            return new HEFDoResult<TResultData> { Type = HEFDoResultType.notFound.ToString(), Msg = resultMsg };
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
