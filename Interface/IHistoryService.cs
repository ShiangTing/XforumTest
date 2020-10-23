using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XforumTest.DTO;

namespace XforumTest.Interface
{
    interface IHistoryService
    {
        void GetAllHistory();
        void GetSingleHistory(string id);
        void GetPoint(int id);
        void Record(HistoryDto model);

    }
}
