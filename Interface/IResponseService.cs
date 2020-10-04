using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XforumTest.Interface
{
    public interface IResponseService
    {
        void Create();
        void Find();
        void Edit();
        void GetAll();
        void GetSingleByPost();
        void GetLike();
        void GetDislike();
    }
}
