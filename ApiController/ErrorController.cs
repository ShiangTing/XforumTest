using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using XforumTest.Services;
using Microsoft.AspNetCore.Authorization;
using XforumTest.Models;

namespace XforumTest.ApiController
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ErrorController : ControllerBase
    {
        [HttpPost]
        public ActionResult<ErrorReponseModel> Error()
        {
            var ex = HttpContext.Features.Get<IExceptionHandlerFeature>();
            if (ex != null)
            {
                return StatusCode(
                    (int)HttpStatusCode.InternalServerError,
                    new ErrorReponseModel()
                    {
                        Status = "500",
                        ErrorMsg = ex.Error.Message
                    });
            }
            else
            {
                return StatusCode(
                    (int)HttpStatusCode.InternalServerError,
                    new ErrorReponseModel()
                    {
                        Status = "500",
                        ErrorMsg = "ERROR OCCURRED!"
                    });
            }

        }

        //public ApiResult<ErrorReponseModel> Error()
        //{
        //    //var ex = HttpContext.Features.Get<IExceptionHandlerFeature>();
        //    //if (ex != null)
        //    //{
        //    //    return StatusCode(
        //    //        (int)HttpStatusCode.InternalServerError,
        //    //        new ErrorReponseModel()
        //    //        {
        //    //            ErrorNumber = 999,
        //    //            Message = ex.Error.Message
        //    //        });
        //    //}
        //    var ex = HttpContext.Features.Get<IExceptionHandlerFeature>();
        //    var result = new ApiResult<ErrorReponseModel>();
        //    if (ex != null)
        //    {

        //        return
        //            new ApiResult<ErrorReponseModel>
        //            {
        //                Status = "500",
        //                ErrorMsg = ex.Error.Message

        //            };
        //    }
        //    else
        //    {
        //        return new ApiResult<ErrorReponseModel>()
        //        {
        //            Status = "500",
        //            ErrorMsg = "SOME ERROR OCCURRED!"
        //        });
        //    }

        //}

    }
}
