using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XforumTest.DTO;

namespace XforumTest.Interface
{
    public interface IPostService
    {
        string Create(PostCreateDto po);
        IEnumerable<PostListDto> GetAll();
        PostListDto GetSingle(GetSingle get);
        IEnumerable<PostListDto> GetForum(GetSingle get);
        void Delete(GetSingle get);
        void Edit(PostListDto json);
      
    }
}
