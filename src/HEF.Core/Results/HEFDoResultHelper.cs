using System.ComponentModel.DataAnnotations;

namespace HEF.Core
{
    public static class HEFDoResultHelper
    {
        #region 执行成功
        public static HEFDoResult DoSuccess()
        {
            return DoSuccess(null);
        }

        public static HEFDoResult DoSuccess(string resultMsg)
        {
            return HEFDoResult.Success<HEFDoResult>(resultMsg);
        }

        public static HEFDoResult<TResultData> DoSuccess<TResultData>()
        {
            return DoSuccess(default(TResultData));
        }

        public static HEFDoResult<TResultData> DoSuccess<TResultData>(TResultData resultData)
        {
            return DoSuccess(resultData, null);
        }

        public static HEFDoResult<TResultData> DoSuccess<TResultData>(TResultData resultData, string resultMsg)
        {
            return HEFDoResult.Success<HEFDoResult<TResultData>, TResultData>(resultData, resultMsg);
        }
        #endregion

        #region 执行失败
        public static HEFDoResult DoFail(string resultMsg)
        {
            return HEFDoResult.Fail<HEFDoResult>(resultMsg);
        }

        public static HEFDoResult<TResultData> DoFail<TResultData>(string resultMsg)
        {
            return HEFDoResult.Fail<HEFDoResult<TResultData>, TResultData>(resultMsg);
        }
        #endregion

        #region 执行验证
        public static HEFDoResult DoValidate(params ValidationResult[] validateResults)
        {
            return HEFDoResult.Validate<HEFDoResult>(validateResults);
        }

        public static HEFDoResult<TResultData> DoValidate<TResultData>(params ValidationResult[] validateResults)
        {
            return HEFDoResult.Validate<HEFDoResult<TResultData>, TResultData>(validateResults);
        }
        #endregion

        #region 执行未找到
        public static HEFDoResult DoNotFound(string resultMsg)
        {
            return HEFDoResult.NotFound<HEFDoResult>(resultMsg);
        }

        public static HEFDoResult<TResultData> DoNotFound<TResultData>(string resultMsg)
        {
            return HEFDoResult.NotFound<HEFDoResult<TResultData>, TResultData>(resultMsg);
        }
        #endregion
    }
}
