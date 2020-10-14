using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using XforumTest.DTO;
using XforumTest.Interface;
using XforumTest.Services;

namespace XforumTest.ApiController
{
    [Route("api/[controller]")]
    [ApiController]
    public class TitleController : ControllerBase
    {
        private readonly ITitleService _titleservice;

        public TitleController(ITitleService titleservice)
        {
            _titleservice = titleservice;
        }

        [HttpPost]
        public string BuyTitle(string userid, string titleid)
        {
            return _titleservice.BuyTitle(userid,titleid);
        }
    }
}
