using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XforumTest.Interface
{
    public interface IChat
    {

        Task ReceiveMessage(string userName, string message);
        Task ReceiveMessage(string message);

        Task SendMessage(string userId,string message);
        Task ReceiveGroupMessage(string roomId, string userName, string message,DateTime postTime);

        Task ReceiveGroupMessage(string chatroomId, string message, string userName);

        Task CheckConnnected(string userId);
    }
}
