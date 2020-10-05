using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XforumTest.DTO;
using XforumTest.NewFolder;

namespace XforumTest.Interface
{
    public interface IForumService
    {
        //創建論壇
        void Create();
        void Find();
        void Delete();

        //編輯修改論壇資料
        IQueryable Edit(string forumid);
       
        IQueryable<ForumGetAllDTO> GetAll();
    }
}
