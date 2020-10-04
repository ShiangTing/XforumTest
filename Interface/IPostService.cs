using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XforumTest.Interface
{
    public interface IPostService
    {
        void Create();
        void Find();
        void Delete();
        void Edit();
        void GetAll();
        void GetSingleByFourm();
        void GetLike();
        void GetDislike();
    }
}
