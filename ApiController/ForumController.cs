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
        [HttpPost]
        public IActionResult Create(ForumCreate create)
        {
            if (ModelState.IsValid)
            {

                return Ok();
            }
            return Ok();
        }

        [HttpGet]
        public IQueryable Edit()
        {
            var edit = new ForumService().Edit("e356a9a0-5f15-4c75-a2dc-19011a823fb3");
            return edit;
        }
        [HttpPost]
        public void Edit(ForumCreate model)
        {
            
        }

        [HttpGet]
        public IQueryable<ForumGetAllDTO> GetAll()
        {
            var getall = new ForumService().GetAll();
            return getall;
        }
    }
}
