using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using XforumTest.DTO;
using XforumTest.Interface;

namespace XforumTest.ApiController
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ForumController : ControllerBase
    {
        private readonly IForumService _forumservice;
        public ForumController(IForumService Service)
        {
            _forumservice = Service;
        }
        /// <summary>
        /// Create新版資料
        /// </summary>
        /// <param name="create"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Create(ForumCreateDto create)
        {

            if (ModelState.IsValid)
            {
                _forumservice.Create(create);
                return Ok();
            }
            return Ok();
        }

        /// <summary>
        /// 編輯看板資料、回復軟刪除狀態
        /// </summary>
        /// <param name="json"></param>
        [HttpPost]
        public IActionResult Edit(ForumEditDto json)
        {
            if (ModelState.IsValid)
            {
                _forumservice.Edit(json);
                return Ok();
            }
            return Ok();
        }
        [HttpDelete]
        public void DeleteForum(ForumDeleteDto deletedForum)
        {
            if (ModelState.IsValid) { _forumservice.Delete(deletedForum); }
        }
        /// <summary>
        /// Edit getsingle取得各版資料，edit post 以編輯的資料回DB
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}")]
        public ForumGetSingleDto GetSingle(string id)
        {
            var edit = _forumservice.GetSingle(id);
            return edit;
        }
        /// <summary>
        /// 軟刪除 修改狀態隱藏看板
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public void ChangeForumState(ChangeForumState model)
        {
            if (ModelState.IsValid) { _forumservice.ChangeForumState(model); }
        }

        /// <summary>
        /// 取得所有 作者、title、routename、date、content
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<ForumGetAllDTO> GetAll()
        {
            return _forumservice.GetAll();
        }
        /// <summary>
        /// 查詢版主創建待審的版面
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpPost]
        public IEnumerable<GetUnauditedForum> GetModForumPage(AuditForumPageOfManagerAndMod pageOfMod)
        {
            return _forumservice.GetModForumPage(User.Identity.Name, pageOfMod);
        }
        /// <summary>
        /// 查詢管理者的待審、需重審、審核通過版面
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IEnumerable<GetUnauditedForum> GetManagerForumPage(AuditForumPageOfManagerAndMod pageOfManager)
        {
            return _forumservice.GetManagerForumPage(pageOfManager);
        }
        [HttpGet]
        public string GetImgLink(string id)
        {
            return _forumservice.GetImgLink(id);
        }
    }
}
