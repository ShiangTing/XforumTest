using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XforumTest.DTO
{
    public class ChatDetailDto
    {
        public string RoomId { get; set; }
        public string UserName { get; set; }
        public string Text { get; set; }
        public DateTime? DateTime { get; set; }
    }
}
