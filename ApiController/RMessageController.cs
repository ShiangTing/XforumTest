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
            var service = new RMessageService();
            service.Create(dto);

            return Ok("create msg");
        }


        /// <summary>
        /// 依據傳入PostId去拿到所有的留言 api/RMessage/XXXX-XXXX
        /// </summary>
        /// <param name="postId"></param>
        /// <returns></returns>

        [HttpGet("{id}")]
        public async Task<ActionResult<List<RMessageDTO>>> GetAllMessages(Guid postId)
        {
            var service = new RMessageService();
            return await service.GetAllbyPostId(postId);
        }


        /// <summary>
        /// 永久刪除留言
        /// </summary>
        /// <param name="mId"></param>
        /// <returns></returns>
        [HttpDelete]
        public IActionResult DeleteMessages(Guid mId)
        {
            var service = new RMessageService();
            service.Delete(mId);
            return Ok("delete msg");
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="Dto"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult PostLikeAndDisLike(MessageLikeDto Dto)
        {
            var service = new LikeService2();
            service.PostLikeAndDisLike(Dto);

            return Ok("delete msg");
        }
    //}
}
}
