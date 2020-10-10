using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using XforumTest.Services;

namespace XforumTest.ApiController
{
    [Route("api/[controller]")]
    [ApiController]
    public class ErrorController : ControllerBase
    {


        //public ActionResult<ApiResult> Error()
        //{
        //    var ex = HttpContext.Features.Get<IExceptionHandlerFeature>();
        //    if (ex != null)
        //    {
        //        return StatusCode(
        //            (int)HttpStatusCode.InternalServerError,
        //            new ApiResult(999, err, Object result)
        //            {
        //                Status = 999,
        //                ErrorMsg = ex.Error.Message,
        //                Result = 
        //            });
        //    }
        //    else
        //    {
        //        return StatusCode(
        //       (int)HttpStatusCode.InternalServerError,
        //       new ErrorResponseVM()
        //       {
        //           errorno = 999,
        //           message = "ERROR OCCURRED!"
        //       });
        //    }
    
        //}
    }
}
