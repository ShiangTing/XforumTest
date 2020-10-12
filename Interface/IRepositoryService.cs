using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace XforumTest.Interface
{
    public interface IRepository<T> where T:class
    {
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);

        IQueryable<T> GetAll();

        T GetFirst(Expression<Func<T, bool>> entity);
        void SaveContext();


    }
}
