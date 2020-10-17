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
    [Route("api/[controller]/[action]")]
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

        [HttpGet("{id}")]
        public List<HasTitle> GetHasTitles(string id)
        {
            return _titleservice.GetHasTitles(id);
        }

        [HttpGet("{id}")]
        public decimal? GetPoints(string id)
        {
            return _titleservice.GetPoints(id);
        }
        [HttpGet]
        public List<TitleCreateDto> GetAllTitles()
        {
            return _titleservice.GetAllTitles();
        }
    }
}
