using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XforumTest.DTO;

namespace XforumTest.Interface
{
    public interface IPostService
    {
        void Create(PostCreateDto po);
        IEnumerable<PostListDto> GetAll();
        PostListDto GetSingle(string id);
        IEnumerable<PostListDto> GetForum(string id);
        void Delete(string id);
        void Edit(PostListDto json);
      
    }
}
