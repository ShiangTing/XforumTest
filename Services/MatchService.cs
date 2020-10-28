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
        public MatchService(IRepository<Chats> chats, IRepository<ForumMembers> members)
        {
            _chats = chats;
            _members = members;
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
                return new MatchOutput() {  };
            }
        }

        /// <summary>
        /// 將配對user加入好友中
        /// </summary>
        /// <param name="dto"></param>
  
        public void Add(BaseChatDto dto)
        {
            Chats chats = new Chats()
            {
                ChatId = Guid.NewGuid(),
                UserId = dto.UserId,
                FriendId = dto.FriendId,
            };
            _chats.Create(chats);
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
                           on c.UserId equals m.UserId
                           select new ChatListDto()
                           {
                               UserId = (Guid)c.FriendId,
                               ImgLink = m.ImgLink,
                               Name = m.ImgLink
                           };
                return list;




           // }

           // else
           // {
                
           // }
        }

    
    
    
    
    
    }
}
