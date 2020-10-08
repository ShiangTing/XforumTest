using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using XforumTest.DTO;
using XforumTest.Services;

namespace XforumTest.ApiController
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ForumController : ControllerBase
    {
        private static ForumService forumservice = new ForumService();
        /// <summary>
        /// Create新版資料
        /// </summary>
        /// <param name="create"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Create([FromBody]ForumCreate create)
        {

            if (ModelState.IsValid)
            {
                forumservice.Create(create);
                return Ok();
            }
            return Ok();
        }

        /// <summary>
        /// Edit getsingle取得各版資料，edit post 以編輯的資料回DB
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IQueryable GetSingle(string id)
        {
            var edit = forumservice.GetSingle(id);
            return edit;
        }
        //public IQueryable GetSingle()
        //{
        //    var edit = forumservice.GetSingle("bfacfa2c-dca9-4efb-8554-daed27024913");
        //    return edit;
        //}
        [HttpPost]
        public void Edit(ForumCreate json)
        {
            forumservice.Edit(json);
        }

        /// <summary>
        /// 取得所有版名字與Id
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IQueryable<ForumGetAllDTO> GetAll()
        {
            var getall = new ForumService().GetAll();
            return getall;
        }
        /// <summary>
        /// 取得板塊文章 作者、title、routename、date、content
        /// </summary>
        [HttpGet]
        public IQueryable GetAllForums()
        {
            var forums = "";
            return forums;
        }
    }
}
