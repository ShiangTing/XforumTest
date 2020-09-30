using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XforumTest.Interface
{
    public interface IFourmService
    {
        //創建論壇
        void Create();

        //編輯修改論壇資料
        void Edit();

        void SoftDelete();

        void Delete();

        void GetAll();

        void GetFirst();
    }
}
