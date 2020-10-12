﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XforumTest.DataTable;
using XforumTest.Interface;
using XforumTest.NewFolder;

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
       
        public void CreateTitile()
        {
            throw new NotImplementedException();
        }

        public void DeleteTitile()
        {
            throw new NotImplementedException();
        }

        public void EditTitle()
        {
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
        public void BuyTitle(string titleid)
        {
            throw new NotImplementedException();
        }
        public void ChangeTitle()
        {
            throw new NotImplementedException();
        }
    }
}
