using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XforumTest.Context;
using XforumTest.DataTable;
using XforumTest.DTO;
using XforumTest.Interface;
using XforumTest.Repository;

namespace XforumTest.Services
{
    public class FourmService : IForumService
    {
        static MyDBContext db = new MyDBContext();
        GeneralRepository<Forums> forums = new GeneralRepository<Forums>(db);

        public void Create()
        {
            throw new NotImplementedException();
        }

        public void Delete()
        {
            //使用軟刪除 修改狀態
            throw new NotImplementedException();
        }

        public void Edit()
        {
            throw new NotImplementedException();
        }

        public IQueryable Edit(string forumid)
        {
            throw new NotImplementedException();
        }

        public void Find()
        {
            throw new NotImplementedException();
        }

        public void GetAll()
        {
            throw new NotImplementedException();
        }

        IQueryable<ForumGetAllDTO> IForumService.GetAll()
        {
            throw new NotImplementedException();
        }

        //public  GetAll()
        //{
        //    forums.GetAll();
        //}
    }
}
