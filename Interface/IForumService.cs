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
        void Create(ForumCreate create);
        IEnumerable<ForumGetAllDTO> GetAll();
        ForumGetSingleDto GetSingle(string forumid);   
        void Delete(string id);
        void Edit(ForumCreate json);
    }
}
