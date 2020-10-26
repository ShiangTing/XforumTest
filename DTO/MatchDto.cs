using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XforumTest.DTO
{
    public class MatchDto
    {
        public Guid? UserId { get; set; }
        public Guid? MatchedUserId { get; set; }
    }
}
