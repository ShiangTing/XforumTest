using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XforumTest.DTO
{
    public class UserLikeHistoryDto: BaseLikeEntity
    {
        public bool? IsLike { get; set; }
        public bool? IsDisLike { get; set; }

        //public Guid UserId { get; set; }

        //public Guid Id { get; set; }
    }
}
