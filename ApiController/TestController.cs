using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic.CompilerServices;
using XforumTest.Context;
using XforumTest.DTO;
using XforumTest.Interface;

namespace XforumTest.ApiController
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        //private readonly IPostService _postservice;
        //public TestController(IPostService postservice)
        //{
        //    _postservice = postservice;
        //}


        //private MyDBContext context;

        //public TestController(MyDBContext contexts)
        //{
        //    if (contexts == null)
        //    {
        //        throw new ArgumentNullException();
        //    }
        //    context = contexts;
        //}

        //[HttpGet]
        //public IEnumerable<string> GetAllPosts()
        //{
        //    var list = new List<string>();
        //    list.Add("abc");
        //    list.Add("def");

        //    //return from p in context.Posts.ToList()
        //    //       join u in context.ForumMembers.ToList()
        //    //       on p.UserId equals u.UserId
        //    //       join f in context.Forums.ToList()
        //    //       on p.ForumId equals f.ForumId
        //    //       orderby p.CreatedDate
        //    //       select new PostListDto
        //    //       {
        //    //           ForumName = f.ForumName,
        //    //           PostId = p.PostId,
        //    //           Title = p.Title,
        //    //           Description = p.Description,
        //    //           CreatedDate = p.CreatedDate,
        //    //           UserId = p.UserId,
        //    //           UserName = u.Name,
        //    //           LikeNumber = p.LikeNumber,
        //    //           DisLikeNumber = p.DisLikeNumber,
        //    //           State = p.State
        //    //       };
        //    return list;
        //}

        [HttpGet]
        public IEnumerable<string> LogArr()
        {
            Console.WriteLine("test");
            Debug.WriteLine("msg");
            var list = new List<string>();
            list.Add("abc");
            list.Add("def");
            return list;
        }


        [HttpGet]
        public string Log()
        {
            Console.WriteLine("test");
            Debug.WriteLine("msg");
            return "LogMsg";
        }

        [HttpGet]
        public int LogInt()
        {
            Console.WriteLine("test1");
            Debug.WriteLine("msg1");
            return 888;
        }

    }
}
