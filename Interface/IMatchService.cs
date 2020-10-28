using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XforumTest.DTO;

namespace XforumTest.Interface
{
    public interface IMatchService
    {
        //隨機抓人
        MatchOutput Match(MatchDto dto);


        void Add(BaseChatDto dto);

    }
}
