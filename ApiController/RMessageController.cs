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
using static XforumTest.Services.ApiResult;

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
        public IActionResult CreateMessage(RMessageDTO dto)
        {
            if (!ModelState.IsValid)
            {
                var service = new RMessageService();
                service.Create(dto);

                return Ok(); //new ApiResult( 0,"none","none");
            }
            else
            {
                return BadRequest();    new ApiResult( 1, "a", "a");
            }
        }


        /// <summary>
        /// 依據傳入PostId去拿到所有的留言 api/RMessage/XXXX-XXXX
        /// </summary>
        /// <param name="postId"></param>
        /// <returns></returns>

        [HttpGet("{postId}")]
        public async Task<ActionResult<List<RMessageDTO>>> GetAllMessages(Guid postId)
        {
            if (postId!=null)
            {
                var service = new RMessageService();
                return await service.GetAllbyPostId(postId);
            }
            else
            {
                return BadRequest("postId is null");
            }
        }


        /// <summary>
        /// 永久刪除留言
        /// </summary>
        /// <param name="mId"></param>
        /// <returns></returns>
        [HttpDelete]
        public IActionResult DeleteMessages(Guid mId)
        {
            if (mId != null)
            {
                var service = new RMessageService();
                service.Delete(mId);
                return Ok("delete msg");
            }
            else
            {
                return BadRequest("Id is null");
            }
           
        }


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
