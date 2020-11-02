using Microsoft.AspNetCore.Authentication.JwtBearer;
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
       // private readonly IRepository<Msg> _Msg;

        private static List<OnlineListDto> ConnectList = new List<OnlineListDto>();
        public ChatHub(IRepository<ForumMembers> member, IRepository<Chats> chats, IRepository<ChatDetails> details)
        {
            _members = member;
            _chats = chats;
            _details = details;
          //  _Msg = Msg;
        }



        public async Task JoinGroup(string chatroomId)
        {
            //if (chatroomId != roomName)
            //{
            //    await LeaveGroup(roomName);
            //}

            //  _chatGroupService.RemoveConnectionfromGroups(Context.ConnectionId);
            await  Groups.AddToGroupAsync(Context.ConnectionId, chatroomId);
           

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

        public async Task SendInfoToUser(PMDto dto)
        {
            //確認該Id 是否在線
            //check dictionary if same
            //將dictionary 裡同userId的connectionId蓋過去
            var user = ConnectList.FirstOrDefault(x => x.UserName == dto.UserName);
   
           
            if (user != null)
            {
              //  var connctionId = Context.ConnectionId;
                await Clients.Client(user.ConnectionId).ReceiveMessage(dto.UserName, dto.UserMessage);
            }

            else
            {
                var message = $"此使用者目前不在線 {dto.UserName}";
                await Clients.Caller.ReceiveMessage(dto.UserName, message);
            }
            //將message傳給connectionId
            
            

        }

        // 連線
        public override async Task OnConnectedAsync()
        {
    

            ConnectList.Add(new OnlineListDto { UserName = "", ConnectionId = GetConnectionId() });
            Debug.WriteLine("UserConnected---"+ Context.ConnectionId);
            //測試
          //  await Clients.Caller.SendMessage("UserConnected", GetConnectionId());
            
            await base.OnConnectedAsync();
        }


        // 斷線
        public override async Task OnDisconnectedAsync(Exception exception)
        {
            var user = ConnectList.FirstOrDefault(x => x.ConnectionId == GetConnectionId());

            ConnectList.Remove(user);
            //測試
            Debug.WriteLine("UserDisConnected---" + Context.ConnectionId);
           // await Clients.All.SendMessage("UserDisConnected", Context.ConnectionId);
            await base.OnDisconnectedAsync(exception);
        }


        /// <summary>
        /// 補充在線資料
        /// </summary>
        /// <param name="dto"></param>
   

        public void AddOnlineInList(OnlineListDto dto)
        {
            var user = ConnectList.FirstOrDefault(x => x.ConnectionId == dto.ConnectionId);
            if (user != null)
            {
                user.UserName = dto.UserName;
            }
            else
            {
                OnlineListDto onlineList = new OnlineListDto()
                {
                    UserName = dto.UserName,
                    ConnectionId = GetConnectionId()
                };
                ConnectList.Add(onlineList);
            }
        }

        /// <summary>
        /// 使用者上線時確認是否有資料沒送到
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        //public async Task CheckRemainMsg(string userName)
        //{
        //    //進資料庫找
        //    var msg = _Msg.GetAll().Where(x => x.UserName == userName);
           
               
            
        //    if (msg != null)
        //    {
        //        var userMsgs = _Msg.GetAll().Where(x => x.UserName == dto.UserName);
        //        foreach (var u in userMsgs)
        //        {
        //            await Clients.Client(user.ConnectionId).ReceiveMessage(dto.UserName, dto.UserMessage);
        //        }
                
        //    }
        //    else
        //    {
                
        //    }
        //}

        public string GetConnectionId()
        {
            return Context.ConnectionId;
        }
        

        

        
    }
}
