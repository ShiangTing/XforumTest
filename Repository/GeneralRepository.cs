using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XforumTest.Context;

using XforumTest.Models;
using XforumTest.NewFolder;

namespace XforumTest.Repository
{
    public class GeneralRepository<T> : IRepository<T> where T : class
    {
        private static MyDBContext context;

        protected MyDBContext Context
        {
            get { return context; }
        }

        public GeneralRepository(MyDBContext contexts)
        {
            if (contexts == null)
            {
                throw new ArgumentNullException();
            }
            context = contexts;
        }


        public void Create(T entity)
        {
            context.Entry(entity).State = EntityState.Added;
        }

        public void Delete(T entity)
        {
            context.Entry(entity).State = EntityState.Deleted;
        }

        public IQueryable<T> GetAll()
        {
            return context.Set<T>();
        }

        public T GetFirst(System.Linq.Expressions.Expression<Func<T, bool>> entity)
        {
            return context.Set<T>().FirstOrDefault<T>(entity);
        }

        public void SaveContext()
        {
            context.SaveChanges();
        }

        public void Update(T entity)
        {
            context.Entry(entity).State = EntityState.Modified;
        }
    }
}
