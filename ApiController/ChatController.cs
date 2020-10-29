using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using XforumTest.Hubs;
using XforumTest.Interface;

namespace XforumTest.ApiController
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ChatController : ControllerBase
    {

        private readonly IHubContext<ChatHub, IChat> _hubContext;

        public ChatController(IHubContext<ChatHub, IChat> hubContext)
        {
            _hubContext = hubContext;
        }




        [HttpGet]
        public async Task GetMessage(string msg)
        {
            await _hubContext.Clients.All.ReceiveMessage(msg);
        }
    }
}
