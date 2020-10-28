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

    public class MatchController : ControllerBase
    {
        private readonly IMatchService _matchService;

        public MatchController(IMatchService matchService)
        {
            _matchService = matchService;
        }

        [HttpPost]

        public ApiResult<MatchOutput> MatchUser(MatchDto dto)
        {
            var result = new ApiResult<MatchOutput>();
            if (ModelState.IsValid)
            {
                result.Data = _matchService.Match(dto);
                return result;
            }
           else
            {
                return new ApiResult<MatchOutput>("Dto");
            }

        }        




    }
}
