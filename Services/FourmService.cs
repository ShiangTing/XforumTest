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

        public void Create()
        {
            var contenxt = new MyDBContext();
            var frepo = new GeneralRepository<Forums>(contenxt);

        }

        public void Delete()
        {
            throw new NotImplementedException();
        }

        public void Edit()
        {
            throw new NotImplementedException();
        }

        public void GetAll()
        {
            throw new NotImplementedException();
        }

        public void GetFirst()
        {
            throw new NotImplementedException();
        }

        public void SoftDelete()
        {
            throw new NotImplementedException();
        }
    }
}
