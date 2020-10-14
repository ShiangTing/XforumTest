using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XforumTest.DTO;

namespace XforumTest.Interface
{
    public interface ITitleService
    {
        void CreateTitile(TitleCreateDto model);
        void EditTitle(string titleid);
        void DeleteTitile();
        void GetAllTitles();
        void GetHasTitles();
        string BuyTitle(string titleid, string userid);
        void ChangeTitle();
    }
}
