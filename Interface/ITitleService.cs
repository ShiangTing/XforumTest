using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XforumTest.DTO;

namespace XforumTest.Interface
{
    public interface ITitleService
    {
        decimal? GetPoints(GetSingle get);
        void CreateTitile(TitleCreateDto model);
        void EditTitle(GetSingle get);
        void DeleteTitile();
        List<TitleCreateDto> GetAllTitles();
        List<HasTitle> GetHasTitles(GetSingle get);
        string BuyTitle(BuyTitle buy);
        void ChangeTitle();
    }
}
