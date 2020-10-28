using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XforumTest.DTO
{
    public class BaseChatDto
    {
        public Guid UserId { get; set; }
        public Guid FriendId { get; set; }
    }
}
