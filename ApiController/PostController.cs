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
        public void Delete(string id)
        {
            post.Delete(id);
        }

        //編輯 留言資訊
        [HttpGet]
        public IQueryable GetSingle(string id)
        {
            var singlepost =  post.GetSingle(id);
            return singlepost;
        }
        [HttpPost]
        public IActionResult Edit(PostListDto json)
        {
            if (ModelState.IsValid)
            {
                post.Edit(json);
                return Ok();
            }
            return Ok();
        }
    
        
        /// <summary>
        /// 取得所有的留言資訊
        /// </summary>

        [HttpGet]
        public ActionResult<IEnumerable<PostListDto>> GetAllPosts()
        {
           
                
                return  post.GetAll();
        
        }



    }
}
