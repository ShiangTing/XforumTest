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
        List<PostListDto> GetAll();
        PostListDto GetSingle(string id);
        List<PostListDto> GetForum(string id);
        void Delete(string id);
        void Edit(PostListDto json);
      
    }
}
