using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XforumTest.DTO;
using XforumTest.NewFolder;
using XforumTest.Services;

namespace XforumTest.Interface
{
    public interface IForumService
    {
        //創建論壇
        void Create(ForumCreate create);
        void Find();
        void Delete();

        //編輯修改論壇資料
        void Edit(ForumCreate json);
        IQueryable GetSingle(string forumid);  //測試
        //IQueryable Edit(Guid forumid);

        IQueryable<ForumGetAllDTO> GetAll();
    }
}
