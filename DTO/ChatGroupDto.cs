using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XforumTest.DTO
{
    public class ChatGroupDto:BaseChatDto
    {

        public Guid ChatId { get; set; }

        public string Message { get; set; }
        public DateTime Time { get; set; }
    }
}
