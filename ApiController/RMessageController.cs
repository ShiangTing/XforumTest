using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using XforumTest.DataTable;
using XforumTest.DTO;
using XforumTest.Services;

namespace XforumTest.ApiController
{
    [Route("api/[controller]")]
    [ApiController]
    public class RMessageController : ControllerBase
    {

        //        [HttpPost]
        //public IActionResult CreateMessage(RMessageDTO dto)
        //{
        //    var service = new RMessageService();
        //    service.Create(dto);

        //    return 
        //}


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


    //}
}
}
