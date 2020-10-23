using System;
using System.Collections.Generic;

namespace XforumTest.DataTable
{
    public partial class Chats
    {
        public Guid ChatId { get; set; }
        public Guid? UserId { get; set; }
        public Guid? FriendId { get; set; }

        public virtual ForumMembers User { get; set; }
    }
}
