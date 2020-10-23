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
        public bool Issuccessful { get; set; } 


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
            Issuccessful = true;
            Status = "0000";
            ErrorMsg = "no error";
        }
        
        public ApiResult(string error)
        {
            Issuccessful = false;
            Status = "0001";
            ErrorMsg = $"{error}" ;
        }

        public enum ErrorMessage
        {
            Error =0 ,Error2
        }
           

    }
}
