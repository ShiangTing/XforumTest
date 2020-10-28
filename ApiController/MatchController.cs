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
        
        [HttpPost]
        public ApiResult<BaseChatDto> AddToChatList(BaseChatDto dto)
        {
            if (ModelState.IsValid)
            {
                _matchService.Add(dto);
                return new ApiResult<BaseChatDto>();
            }
            else
            {
                return new ApiResult<BaseChatDto>("Dto");
            }
        }

        [HttpPost]
        public ApiResult<IEnumerable<ChatListDto>> GetAllChatList(UserIdDto dto)
        {
            var result = new ApiResult<IEnumerable<ChatListDto>>();
            if (ModelState.IsValid)
            {
                result.Data = _matchService.GetAll(dto);

                return result;
            }
            else
            {
                return new ApiResult<IEnumerable<ChatListDto>>("Dto");
            }
        }






    }
}
