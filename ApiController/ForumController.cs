﻿using System;
using System.Collections.Generic;
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
        //private static ForumService forumservice = new ForumService();
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
        /// 編輯看板資料、回復軟刪除狀態
        /// </summary>
        /// <param name="json"></param>
        [HttpPost]
        public IActionResult Edit(ForumCreateDto json)
        {
            if (ModelState.IsValid)
            {
                _forumservice.Edit(json);
                return Ok();
            }
            return Ok();
        }
        /// <summary>
        /// 軟刪除 修改狀態隱藏看板
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public void ChangeForumState(ChangeForumState model)
        {
            _forumservice.ChangeForumState(model);
        }


        /// <summary>
        /// 取得所有 作者、title、routename、date、content
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public  IEnumerable<ForumGetAllDTO> GetAll()
        {
            //var getall = new ForumService().GetAll();
            return  _forumservice.GetAll();
        }
        [HttpGet]
        public IEnumerable<GetUnauditedForum> GetUnauditedForum()
        {
            return _forumservice.GetUnauditedForum();
        }
    }
}
