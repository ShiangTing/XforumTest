﻿using System;
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
    }
}