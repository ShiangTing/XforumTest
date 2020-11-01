﻿using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using XforumTest.DataTable;
using XforumTest.DTO;
using XforumTest.Interface;

namespace XforumTest.Hubs
{
    //[Authorize]
    public class ChatHub : Hub<IChat>
    {
        private readonly IRepository<ForumMembers> _members;
        private readonly IRepository<Chats> _chats;
        private readonly IRepository<ChatDetails> _details;
        private static Dictionary<string, string> ConnectionList;
        public ChatHub(IRepository<ForumMembers> member, IRepository<Chats> chats, IRepository<ChatDetails> details)
        {
            _members = member;
            _chats = chats;
            _details = details;
        }


     

        //public async Task Receive(string msg)
        //{
        //    await Clients.All.ReceiveMessage(msg);
        //}

        //public async Task SendGroupMessage(ChatGroupDto dto)
        //{
        //    var chatRoom = _chats.GetFirst(x => x.ChatId == dto.ChatId);
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
        //    //找是否有這個GroupId
        //    //if(room!=null){
        //    //將留言存進資料庫QQ
        //    //Conversation = new Conversation
        //    //{
        //    //    ....
        //    //}
        //    //_C.create....
        //    //}
        //    //創建一個group 然後將兩個id加進group
        //    //SendMessage to all(client)
        //    await Groups.AddToGroupAsync(Context.ConnectionId, chatId);
        //    // await Clients.All.ReceiveMessage(userId, message);
        //    //隊群組內所有人發送留言
        //    await Clients.Group(chatId).ReceiveGroupMessage(dto.UserId, dto.ChatId, dto.Message, dto.Time);


        //}


        public async Task JoinGroup(string chatroomId)
        {
            //if (chatroomId != roomName)
            //{
            //    await LeaveGroup(roomName);
            //}

            //  _chatGroupService.RemoveConnectionfromGroups(Context.ConnectionId);
            await  Groups.AddToGroupAsync(Context.ConnectionId, chatroomId);
            roomName = chatroomId;

        }
        

        public async Task LeaveGroup(string chatroomId)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, chatroomId);
        }
        //改成Dto
        public async Task SendMessageToGroup(ChatDetailDto dto)
        {
           // 聊天後就存入資料庫
            ChatDetails  details = new ChatDetails()
            {
                Id = Guid.NewGuid(),
                RoomId = dto.RoomId,
                UserName = dto.UserName,
                //DateTime =
                Text = dto.Text,
            };
            _details.Create(details);
            _details.SaveContext();


            await Clients.Group(dto.RoomId).ReceiveGroupMessage(dto.RoomId, dto.Text, dto.UserName);
        }


        //送交友通知給特定人
        // [Authorize]
      //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task SendMessageToMember(string userId,string userMsg)
        {



            Debug.WriteLine(Context.User.Identity.Name);
            await Clients.User(userId).SendMessage(userId,userMsg);
            Debug.WriteLine("id--" + userId + ", msg" + userMsg);
           // await  Clients.Client(stringId).SendMessage(stringId, dto.UserMessage);
            //var stringId = dto.UserId.ToString();
           // await Clients.All.SendMessage(dto.UserName, dto.UserMessage);
        }



        //給user特定Id

        public async Task SendInfoToUser(string userId, string message)
        {
            //check dictionary if same
            //將dictionary 裡同userId的connectionId蓋過去
            if (user != null)
            {
                var connctionId = Context.ConnectionId;
                await Clients.Client(userId).SendAsync("ReceiveMessage", message);
            }

            //將message傳給connectionId
            var message = $"Send message to you with user id {userId}";
            await Clients.Client(userId).SendAsync("ReceiveMessage", message);

        }






        // 連線
        public override async Task OnConnectedAsync()
        {
            await Clients.Caller.SendMessage("UserConnected", GetConnectionId());
            
            await base.OnConnectedAsync();
        }
        // 斷線
        public override async Task OnDisconnectedAsync(Exception exception)
        {
            //await Clients.All.SendMessage("UserDisConnected", Context.ConnectionId);
            await base.OnDisconnectedAsync(exception);
        }


        public string GetConnectionId()
        {
            return Context.ConnectionId;
        }
        

        public void CheckConnnected()
        {

        }
    }
}
