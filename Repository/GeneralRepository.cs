using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XforumTest.Context;

using XforumTest.Models;
using XforumTest.Interface;

namespace XforumTest.Repository
{
    public class GeneralRepository<T> : IRepository<T> where T : class
    {
        private readonly MyDBContext _context;

        //protected MyDBContext Context
        //{
        //    get { return context; }
        //}

        public GeneralRepository(MyDBContext contexts)
        {
            if (contexts == null)
            {
                throw new ArgumentNullException();
            }
            _context = contexts;
        }


        public void Create(T entity)
        {
            _context.Entry(entity).State = EntityState.Added;
        }

        public void Delete(T entity)
        {
            _context.Entry(entity).State = EntityState.Deleted;
        }

        public IEnumerable<T> GetAll2()
        {
            return _context.Set<T>().ToList();
        }

        public T GetFirst(System.Linq.Expressions.Expression<Func<T, bool>> entity)
        {
            return _context.Set<T>().FirstOrDefault<T>(entity);
        }

        public void SaveContext()
        {
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public IQueryable<T> GetAll()
        {
            return _context.Set<T>();
        }
    }
}
