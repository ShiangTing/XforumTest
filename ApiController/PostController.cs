using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using XforumTest.Context;
using XforumTest.DTO;
using XforumTest.Services;

namespace XforumTest.ApiController
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private static PostService post = new PostService();
        [HttpPost]
        public IActionResult Create(PostDto po)
        {
            if (ModelState.IsValid)
            {
                post.Create(po);
                return Ok();
            }
            return Ok();
        }

        //軟刪除
        [HttpPost]
        void Delete()
        {
        }

        //編輯 留言資訊
        [HttpGet]
        void GetSingle()
        {

        }
        [HttpPost]
        void Edit()
        {

        }
        //取得所有留言資訊
        [HttpGet]
        void GetAll()
        {

        }

    }
}
