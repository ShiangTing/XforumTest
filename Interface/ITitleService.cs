using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XforumTest.Interface
{
    interface ITitleService
    {
        void CreateTitile();
        void EditTitle();
        void DeleteTitile();
        void GetAllTitles();
        void GetHasTitles();
        void BuyTitle(string titleid);
        void ChangeTitle();
    }
}
