using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XforumTest.DTO;

namespace XforumTest.Interface
{
    public interface ITitleService
    {
        decimal? GetPoints(string id);
        void CreateTitile(TitleCreateDto model);
        void EditTitle(string titleid);
        void DeleteTitile();
        List<TitleCreateDto> GetAllTitles();
        List<HasTitle> GetHasTitles(string id);
        string BuyTitle(string titleid, string userid);
        void ChangeTitle();
    }
}
