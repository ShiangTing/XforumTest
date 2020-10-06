using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XforumTest.DTO;

namespace XforumTest.Interface
{
    public interface IPostService
    {
        void Create(PostDto po);
        void Delete();
        void Edit();
        void GetAll();
        void GetSingle();
    }
}
