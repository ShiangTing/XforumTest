using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XforumTest.Interface
{
    interface IBaseService<T> where T : class
    {
        void Create(T po);
        IQueryable<T> GetAll();
        IQueryable GetSingle(string id);
        void Delete(string id);
        void Edit(T json);
    }
}
