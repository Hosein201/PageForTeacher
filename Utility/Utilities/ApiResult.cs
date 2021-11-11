using System;
using System.Collections.Generic;
using System.Text;

namespace Utility.Utilities
{
    public class ApiResult
    {
        public bool IsSuccess { get; set; }
        public ApiResultStatusCode StatusCode { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
        public ApiResult(bool isSuccess , ApiResultStatusCode statusCode ,object data = null, string message=null)
        {
            IsSuccess = isSuccess;
            StatusCode = statusCode;
            Message = message ?? statusCode.ToDisplay();
            Data = data;
        }
    }

}
