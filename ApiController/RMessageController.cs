using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using XforumTest.DataTable;
using XforumTest.DTO;
using XforumTest.Interface;
using XforumTest.Services;

//using static XforumTest.Services.ApiResult;

namespace XforumTest.ApiController
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RMessageController : ControllerBase
    {
        /// <summary>
        /// 留言
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public ApiResult<RMessageDTO> CreateMessage(RMessageDTO dto)
        {
            var result = new ApiResult<RMessageDTO>();
            if (!ModelState.IsValid)
            {
                var service = new RMessageService();
                service.Create(dto);

                return  result;
            }
            else
            {
                result.Status="1111";
                result.Success=false;
                result.ErrorMsg = "dto is null";
                return result;
            }
        }


        /// <summary>
        /// 依據傳入PostId去拿到所有的留言 api/RMessage/XXXX-XXXX
        /// </summary>
        /// <param name="postId"></param>
        /// <returns></returns>

        [HttpGet("{postId}")]
        public async Task<ApiResult<List<RMessageDTO>>> GetAllMessages(Guid postId)
        {
            var result = new ApiResult<List<RMessageDTO>>();

            if (postId != null)
            {
                var service = new RMessageService();
                result.Data = await service.GetAllbyPostId(postId);
                return result;

            }
            else
            {
                result.Status = "1111";
                result.Success = false;
                result.ErrorMsg = "dto is null";
                return result;
            }
        }


        /// <summary>
        /// 永久刪除留言
        /// </summary>
        /// <param name="mId"></param>
        /// <returns></returns>
        [HttpDelete]
        //public ApiResult<RMessageDTO> DeleteMessages(Guid mId)
        //{
        //    if (mId != null)
        //    {
        //        var service = new RMessageService();
        //        service.Delete(mId);
        //        return new ApiResult<RMessageDTO>(mId);
        //    }
        //    else
        //    {
        //        return new ApiResult<RMessageDTO>("Id is null");
        //    }
           
        //}


        /// <summary>
        /// 按讚跟按倒讚功能
        /// </summary>
        /// <param name="Dto"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult PostLikeAndDisLike(MessageLikeDto Dto)
        {
            if (!ModelState.IsValid)
            {
                var service = new LikeService();
                service.PostLikeAndDisLike(Dto);
                return Ok("create msg");
            }
            else
            {
                return BadRequest("Dto wrong");
            }
           
        }
    
    }
}
