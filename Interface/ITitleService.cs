using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XforumTest.DTO;

namespace XforumTest.Interface
{
    interface ITitleService
    {
        void CreateTitile(TitleCreateDto model);
        void EditTitle();
        void DeleteTitile();
        void GetAllTitles();
        void GetHasTitles();
        void BuyTitle(string titleid);
        void ChangeTitle();
    }
}
