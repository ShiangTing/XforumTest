using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XforumTest.Services
{
    public class ApiResult<T> 
    {

        /// <summary>
        /// 是否成功
        /// </summary>
        public bool Success { get; set; } 


        /// <summary>
        /// 成功為0000
        /// </summary>
        public string Status { get; set; } 

        /// <summary>
        /// 錯誤訊息
        /// </summary>
        public string ErrorMsg { get; set; } 

        public T Data { get; set; }

        public ApiResult()
        {
            Success = true;
            Status = "0000";
            ErrorMsg = "no error";
        }
    

        //public class ApiError : ApiResult<object>
        //{
        //    /// <summary>
        //    /// 建立失敗結果
        //    /// </summary>
        //    /// <param name="code"></param>
        //    /// <param name="message"></param>
        //    public ApiError(string code, string message)
        //    {
        //        Status = code;
        //        Succ = false;

        //        ErrorMsg = message;
        //    }
        //}
    }
}
