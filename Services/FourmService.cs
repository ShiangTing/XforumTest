using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XforumTest.Context;
using XforumTest.DataTable;
using XforumTest.Interface;
using XforumTest.Repository;

namespace XforumTest.Services
{
    public class FourmService : IFourmService
    {
        static MyDBContext db = new MyDBContext();
        GeneralRepository<Forums> forums = new GeneralRepository<Forums>(db);

        public void Create()
        {
            throw new NotImplementedException();
        }

        public void Delete()
        {
            //使用軟刪除 修改狀態
            throw new NotImplementedException();
        }

        public void Edit()
        {
            throw new NotImplementedException();
        }

        public void Find()
        {
            throw new NotImplementedException();
        }

        public  GetAll()
        {
            forums.GetAll();
        }
    }
}
