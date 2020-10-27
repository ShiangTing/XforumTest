using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using XforumTest.Context;
using XforumTest.DTO;
using XforumTest.Interface;
using XforumTest.Services;

namespace XforumTest.ApiController
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostService _postservice;
        public PostController(IPostService postservice)
        {
            _postservice = postservice;
        }

        [HttpPost]
        public string Create(PostCreateDto createpost)
        {
            if (ModelState.IsValid)
            {
                return _postservice.Create(createpost);
            }
            return "Po文失敗";
        }

        //軟刪除
        [HttpPost]
        public IActionResult Delete([FromBody] PostListDto json)
        {
            _postservice.Delete(json.PostId.ToString());
            return Ok();
        }

        //編輯 留言資訊
        [HttpGet("{id}")]
        public PostListDto GetSingle(string id)
        {
            return _postservice.GetSingle(id);
        }

        [HttpPost]
        public IActionResult Edit(PostListDto json)
        {
            if (ModelState.IsValid)
            {
                _postservice.Edit(json);
                return Ok();
            }
            return Ok();
        }

        /// <summary>
        /// 取得所有的留言資訊
        /// </summary>
        //  [Route("/")]
        [HttpGet]
        public List<PostListDto> GetAllPosts()
        {

            return _postservice.GetAll();
        }


        /// <summary>
        /// 取個單一看板PO文
        /// </summary>
        /// <returns></returns>

        //  [Route("/")]
        [HttpGet("{route}")]
        public List<PostListDto> GetForum(string route)
        {
            return _postservice.GetForum(route);
        }
    }
}
