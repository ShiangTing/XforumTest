using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XforumTest.Context;
using XforumTest.DataTable;
using XforumTest.Interface;
using XforumTest.Repository;
using XforumTest.DTO;

namespace XforumTest.Services
{
    public class ForumService : IForumService
    {
        static MyDBContext db = new MyDBContext();
        GeneralRepository<Forums> forums = new GeneralRepository<Forums>(db);
        GeneralRepository<ForumMembers> forummembers = new GeneralRepository<ForumMembers>(db);

        public void Create()
        {
            throw new NotImplementedException();
        }

        public void Delete()
        {
            //使用軟刪除 修改狀態
            throw new NotImplementedException();
        }

        public IQueryable Edit(string forumid)
        {
            var forum = from f in forums.GetAll()
                        select new
                        {
                            title = f.ForumName,
                            date = f.CreatedDate,
                            name = f.ModeratorId,
                            content = f.Description
                        };
            return forum;
        }
        
        public void Find()
        {
            throw new NotImplementedException();
        }

        public IQueryable<ForumGetAllDTO> GetAll()
        {
            //var getall = from f in forums.GetAll()
            //             join fm in forummembers.GetAll()
            //             on f.ModeratorId equals fm.UserId
            //             select new ForumGetAllDTO
            //             {
            //                 UserName = fm.Name,
            //                 Age = fm.Age
            //             };
            var getall = from fm in forummembers.GetAll()
                         select new ForumGetAllDTO
                         {
                             UserName = fm.Name,
                             Age = fm.Age
                         };

            //forums.GetAll();
            return getall;
        }
    }
}
