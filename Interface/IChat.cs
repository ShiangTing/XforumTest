using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XforumTest.Interface
{
    public interface IChat
    {

        Task ReceiveMessage(Guid userId, string message);
        Task ReceiveMessage(string message);
    }
}
