using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XforumTest.DTO
{
    public class PostLikeDto
    {
        public Guid? PostId { get; set; }
        public int? LikeNumber { get; set; }
        public int? DisLikeNumber { get; set; }
    }
}
