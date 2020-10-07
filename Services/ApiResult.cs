using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XforumTest.Services
{
   

    public class ApiResult
    {

        public ApiResult(int status,string err,Object result)
        {
            Status = status;
            ErrorMsg = err;
            Result = result;

        }

        public int Status { get; set; }
        public string ErrorMsg { get; set; }
        public Object Result { get; set; }

        public static class APIStatus
        {
            public static int Success = 0;
            public static int Error = 1;
        }
    }
 
}
