using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using XforumTest.DTO;
using XforumTest.Hubs;
using XforumTest.Interface;
using XforumTest.Services;

namespace XforumTest.ApiController
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ChatController : ControllerBase
    {

      
        private readonly IHubContext<ChatHub, IChat> _hubContext;
        private readonly IMatchService _match;
        public ChatController(IHubContext<ChatHub, IChat> hubContext, IMatchService match)
        {
            _hubContext = hubContext;
            _match = match;
        }


        [HttpGet]
        public async Task GetMessage(string msg)
        {
            await _hubContext.Clients.All.ReceiveMessage(msg);
        }


        /// <summary>
        /// 拿到特定聊天室Id
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public ApiResult<string> GetChatRoomId([FromBody]BaseChatDto dto)
        {
            var result = new ApiResult<string>();
            if (ModelState.IsValid)
            {
                // var service = new RMessageService();
                result.Data = _match.GetSingleId(dto);
                return result;
            }
            else
            {
                return new ApiResult<string>("dto");
            }

            
        }


        [Authorize]
        [HttpPost]
        public async Task GetPrivateMessage(string user,string message)
        {
           // var user = User.Identity.Name;

            await _hubContext.Clients.User(user).SendMessage(user, message);
        }

    }
}
