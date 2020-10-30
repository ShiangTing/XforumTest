using System;
using System.Collections.Generic;

namespace XforumTest.DataTable
{
    public partial class Chats
    {
        public Guid ChatId { get; set; }
        public Guid? UserId { get; set; }
        public Guid? FriendId { get; set; }
        public string Message { get; set; }
        public DateTime? DateTime { get; set; }
        public string RoomId { get; set; }

        public virtual ForumMembers User { get; set; }
    }
}
