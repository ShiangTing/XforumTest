using System;
using System.Collections.Generic;
using System.Linq;
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
        public void Match(MatchDto dto)
        {
            //var user = 
            //if()
        }
    }
}
