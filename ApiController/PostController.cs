using System;
using System.Collections.Generic;
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
        public IActionResult Create(PostCreateDto createpost)
        {
            if (ModelState.IsValid)
            {
                _postservice.Create(createpost);
                return Ok();
            }
            return Ok();
        }

        //軟刪除
        [HttpPost]
        public void Delete(string id)
        {
            _postservice.Delete(id);
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
        [HttpGet]
        public IEnumerable<PostListDto> GetAllPosts()
        {        

            return  _postservice.GetAll();
        }

        /// <summary>
        /// 取個單一看板PO文
        /// </summary>
        /// <returns></returns>
        [HttpGet("{route}")]
        public IEnumerable<PostListDto> GetForum(string route)
        {
            return _postservice.GetForum(route);
        }
    }
}
