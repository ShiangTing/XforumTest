using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XforumTest.DTO
{
    public class MatchOutput
    {
        public Guid? UserId { get; set; }
        public Guid? MatchedUserId { get; set; }

        public string imgLink { get; set; }
        public string MatchimgLink { get; set; }

        public string Name { get; set; }

        public string MatchedName { get; set; }

    }
}
