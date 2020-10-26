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
        void Create(ForumCreateDto create);
        IEnumerable<ForumGetAllDTO> GetAll();
        ForumGetSingleDto GetSingle(string id);   
        void Delete(string id);
        void Edit(ForumCreateDto json);
    }
}
