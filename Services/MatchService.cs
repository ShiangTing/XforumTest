using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using XforumTest.DataTable;
using XforumTest.DTO;
using XforumTest.Interface;

namespace XforumTest.Services
{
    public class MatchService : IMatchService
    {
        private readonly IRepository<Chats> _chats;
        private readonly IRepository<ForumMembers> _members;
        private readonly IRepository<ChatDetails> _details;
        public MatchService(IRepository<Chats> chats, IRepository<ForumMembers> members, IRepository<ChatDetails> details)
        {
            _chats = chats;
            _members = members;
            _details = details;
        }
        /// <summary>
        /// 抓一個人來配對
        /// </summary>
        /// <param name="dto"></param>
        public MatchOutput Match(MatchDto dto)
        {
           var user = _members.GetFirst(x => x.UserId == dto.UserId);
     
            if (user != null)
            {
                //隨機產生亂數字
                Random random = new Random();
                //int number = rnd.Next(1,10);

                //找到contain該數字的第一個
                var userList = _members.GetAll().ToList();//.Find(x => x.UserId.ToString().Contains(number.ToString()));
                int index = random.Next(userList.Count);

                if(userList[index]!= user)
                {
                    return new MatchOutput()
                    {
                        UserId = user.UserId,
                        MatchedUserId = userList[index].UserId,
                        imgLink = user.ImgLink,
                        MatchimgLink = userList[index].ImgLink,
                        Name = user.Name,
                        MatchedName = userList[index].Name

                    };
                }
                else
                {
                    return new MatchOutput()
                    {
                        UserId = user.UserId,
                        MatchedUserId = userList[0].UserId,
                        imgLink = user.ImgLink,
                        MatchimgLink = userList[0].ImgLink,
                        Name = user.Name,
                        MatchedName = userList[0].Name

                    };
                }
               
            }


            else
            {
                return new MatchOutput() {  };
            }
        }

        /// <summary>
        /// 將配對user加入好友中
        /// </summary>
        /// <param name="dto"></param>
  
        public void Add(BaseChatDto dto)
        {
            string roomId = DateTime.Now.ToString("yyyyMMddff");


            Chats chats = new Chats()
            {
                RoomId = roomId,
                ChatId = Guid.NewGuid(),
                UserId = dto.UserId,
                FriendId = dto.FriendId,
            };
            Chats friendChats = new Chats()
            {
                RoomId = roomId,
                ChatId = Guid.NewGuid(),
                UserId = dto.FriendId,
                FriendId = dto.UserId,
            };

            _chats.Create(chats);
            _chats.Create(friendChats);
            _chats.SaveContext();
        }

        public IEnumerable<ChatListDto> GetAll(UserIdDto dto)
        {
            var user = _members.GetFirst(x => x.UserId == dto.UserId);

         //   if (user != null)
           // {

                var list = from c in _chats.GetAll2()
                           where dto.UserId == c.UserId
                           join m in _members.GetAll2()
                           on c.FriendId equals m.UserId
                           select new ChatListDto()
                           {
                               UserId = (Guid)c.FriendId,
                               ImgLink = m.ImgLink,
                               Name = m.Name
                           };
                return list;




           // }

           // else
           // {
                
           // }
        }

    
        public string GetSingleId(BaseChatDto dto)
        {
            var chatRoom = _chats.GetFirst(x => x.FriendId == dto.FriendId && x.UserId == dto.UserId);
            return chatRoom.RoomId;
        }
    
        public List<ChatDetailDto> GetDetails(RoomDto dto)
        {
            //var chat = _details.GetAll().Where(x => x.RoomId == roomId).Select;

            var chatList = from d in _details.GetAll()
                           where d.RoomId == dto.RoomId
                           orderby d.DateTime 
                           select new ChatDetailDto()
                           {
                               RoomId = dto.RoomId,
                               Text = d.Text,
                               DateTime = d.DateTime,
                               UserName = d.UserName
                           };


            return chatList.ToList();
        }
    
    }
}
