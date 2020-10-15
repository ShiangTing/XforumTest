﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using XforumTest.DataTable;
using XforumTest.DTO;
using XforumTest.Interface;


namespace XforumTest.Services
{
    public class TitleService : ITitleService
    {
        private readonly IRepository<ForumMembers> _users;
        private readonly IRepository<Titles> _titles;
        private readonly IRepository<MemberTitle> _usertitle;

        public TitleService(IRepository<ForumMembers> users, IRepository<Titles> titles, IRepository<MemberTitle> usertitle) 
        {
            _users = users;
            _titles = titles;
            _usertitle = usertitle;
        }
       
        public void CreateTitile(TitleCreateDto model)
        {
            try
            {
                var create = new Titles
                {
                    TitleId = Guid.NewGuid(),
                    TitleName = model.TitleName,
                    Price = model.Price
                };
                _titles.Create(create);
                _titles.SaveContext();
            } 
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// 先不做，如果新增功能就要在欄位增加state
        /// </summary>
        public void DeleteTitile()
        {
            throw new NotImplementedException();
        }

        public void EditTitle(string titleid)
        {
            var title = _titles.GetAll().FirstOrDefault(t => t.TitleId.ToString() == titleid);
            throw new NotImplementedException();
        }

        public void GetAllTitles()
        {
            throw new NotImplementedException();
        }

        public void GetHasTitles()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 購買稱號系統
        /// </summary>
        /// <param name="titleid"></param>
        /// <param name="userid"></param>
        /// <returns></returns>
        public string BuyTitle(string userid, string titleid)
        {
            var user = _users.GetAll().FirstOrDefault(u => u.UserId.ToString() == userid);
            var price = _titles.GetAll().FirstOrDefault(t => t.TitleId.ToString() == titleid).Price;
            if (user.Points > price)
            {
                user.Points = user.Points - price;
                _users.Update(user);
                _users.SaveContext();

                var newtitle = new MemberTitle
                {
                    UserId = Guid.Parse(userid),
                    HasTitleId = Guid.Parse(titleid)
                };

                _usertitle.Create(newtitle);
                _usertitle.SaveContext();
                return "稱號購買完成";
            }
            return "點數不足，請加把勁";

        }
        public void ChangeTitle()
        {
            throw new NotImplementedException();
        }
    }
}
