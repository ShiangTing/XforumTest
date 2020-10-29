using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XforumTest.DataTable;
using XforumTest.DTO;
using XforumTest.Interface;

namespace XforumTest.Hubs
{
    public class ChatHub : Hub<IChat>
    {
        private readonly IRepository<ForumMembers> _members;
        private readonly IRepository<Chats> _chats;

        public ChatHub(IRepository<ForumMembers> member, IRepository<Chats> chats)
        {
            _members = member;
            _chats = chats;
        }


        public async Task Receive(string msg)
        {
            await Clients.All.ReceiveMessage(msg);
        }

        public async Task SendGroupMessage(ChatGroupDto dto)
        {
            var chatRoom = _chats.GetFirst(x => x.ChatId == dto.ChatId);
            string chatId = dto.ChatId.ToString();
            if (chatRoom != null)
            {
                chatRoom.FriendId = dto.FriendId;
                chatRoom.Message = dto.Message;
                chatRoom.DateTime = dto.Time;

                chatRoom.UserId = dto.UserId;
                _chats.Update(chatRoom);
                _chats.SaveContext();
                // _chats.Update()
            }
            //找是否有這個GroupId
            //if(room!=null){
            //將留言存進資料庫QQ
            //Conversation = new Conversation
            //{
            //    ....
            //}
            //_C.create....
            //}
            //創建一個group 然後將兩個id加進group
            //SendMessage to all(client)
            await Groups.AddToGroupAsync(Context.ConnectionId, chatId);
            // await Clients.All.ReceiveMessage(userId, message);
            //隊群組內所有人發送留言
            await Clients.Group(chatId).ReceiveGroupMessage(dto.UserId, dto.ChatId, dto.Message, dto.Time);


        }

        //public async Task SendGroupMessages(Guid userId,string Message,Guid chatId)
        //{
        //    var chatRoom = _chats.GetFirst(x => x.ChatId == chat);
        //    string chatId = dto.ChatId.ToString();
        //    if (chatRoom != null)
        //    {
        //        chatRoom.FriendId = dto.FriendId;
        //        chatRoom.Message = dto.Message;
        //        chatRoom.DateTime = dto.Time;

        //        chatRoom.UserId = dto.UserId;
        //        _chats.Update(chatRoom);
        //        _chats.SaveContext();
        //        // _chats.Update()
        //    }




        //    await Groups.AddToGroupAsync(Context.ConnectionId, chatId);





        //    // await Clients.All.ReceiveMessage(userId, message);
        //    //隊群組內所有人發送留言
        //    await Clients.Group(chatId).ReceiveGroupMessage(dto.UserId, dto.ChatId, dto.Message, dto.Time);


        //}
        public async Task JoinGroup(string chatroomId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, chatroomId);
        }

        public async Task SendMessageToGroup(string chatroomId, string message, string userName)
        {
            await Clients.Group(chatroomId).ReceiveGroupMessage(chatroomId, message, userName);
        }


        //送交友通知給特定人
        public async Task SendMessageToMember(ProdcastDto dto)
        {
            //var stringId = dto.UserId.ToString();
            await Clients.Client(dto.UserId).SendMessage(dto.UserId, dto.UserMessage);
        }

        //   public Task SendInforToUser(string userId, string userMessage)
        // {
        // userId = Context.ConnectionId;
        //return Clients.Client(userId).SendAsync("sendToUser", userId, userMessage);
        //}


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




        //   public async Task SendMessaeToGroup(string user, string content, string recipientId, string chatRoomId)
        //   {
        // await Groups.AddToGroupAsync(Context.ConnectionId, chatRoomId);

        // await Clients.Group(chatRoomId).SendAsync("ReceiveMessage", user, content);
        // }

        // 連線
        public override async Task OnConnectedAsync()
        {
            await Clients.All.SendMessage("UserConnected", Context.ConnectionId);
            await base.OnConnectedAsync();
        }
        // 斷線
        public override async Task OnDisconnectedAsync(Exception exception)
        {
            await Clients.All.SendMessage("UserDisConnected", Context.ConnectionId);
            await base.OnDisconnectedAsync(exception);
        }


        public string GetConnectionId()
        {
            return Context.ConnectionId;
        }
        //
    }
}
