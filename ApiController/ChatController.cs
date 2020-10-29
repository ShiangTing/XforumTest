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
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {

        //private readonly IHubContext<ChatHub,IChat> _



    }
}
