using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XforumTest.DTO;

using XforumTest.Services;

namespace XforumTest.Interface
{
    public interface IForumService
    {
        void Create(ForumCreate create);
        IEnumerable<ForumGetAllDTO> GetAll();
        ForumGetSingleDto GetSingle(GetSingle get);   
        void Delete(GetSingle get);
        void Edit(ForumCreate json);
    }
}
