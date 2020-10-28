using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XforumTest.DataTable;
using XforumTest.Interface;

namespace XforumTest.Hubs
{
    public class ChatHub :Hub<IChat>
    {
        private readonly IRepository<ForumMembers> _members;
        private readonly IRepository<Chats> _chats;

        public ChatHub(IRepository<ForumMembers> member, IRepository<Chats> chats)
        {
            _members = member;
            _chats = chats;
        }


        public async Task SendMessage(Guid userId, string message)
        {
            await Clients.All.ReceiveMessage(userId, message);
        }



        //發送訊息給所有人
        //public async Task SendMessage(string user, string message)
        //{
        //    await Clients.All.SendAsync("ReceiveMessage", user, message);
        //}

        //
        //public Task SendMessageToGroups(string message,Guid? groupId)
        //{
        //    if (groupId != null)
        //    {
        //        //取得group名字?
        //        var 
        //        return Clients.Groups("a").ReceiveMessage(message);
        //    }
        //    //創建


            
        //}

        //給user特定Id

      //  public async Task SendPrivateMessage(string userId,string message)
     //   {
            //Clients.All.
            //find user
            //var user =
            //if (user!=null){
          //  var connctionId = Context.ConnectionId;
          //  await Clients.Client(userId).SendAsync("ReceiveMessage", message);
            //}
            // var message = $"Send message to you with user id {userId}";
            //await Clients.Client(userId).SendAsync("ReceiveMessage", message);

    //    }


        public async Task JoinGruop()
        {

        }

     //   public async Task SendMessaeToGroup(string user, string content, string recipientId, string chatRoomId)
     //   {
            // await Groups.AddToGroupAsync(Context.ConnectionId, chatRoomId);

           // await Clients.Group(chatRoomId).SendAsync("ReceiveMessage", user, content);
       // }

        // 連線
        public override async Task OnConnectedAsync()
        {
            await base.OnConnectedAsync();
        }
        // 斷線
        public override async Task OnDisconnectedAsync(Exception exception)
        {
            await base.OnDisconnectedAsync(exception);
        }


        public string GetConnectionId()
        {
            return Context.ConnectionId;
        }
        //
    }
}
