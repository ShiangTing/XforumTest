using System;
using System.Collections.Generic;

namespace XforumTest.Models
{
    public partial class Forum
    {
        public Forum()
        {
            Thread = new HashSet<Thread>();
        }

        public Guid ForumId { get; set; }
        public DateTime CreateDate { get; set; }
        public string Img { get; set; }
        public Guid? ModeratorId { get; set; }

        public virtual ForumMember Moderator { get; set; }
        public virtual ICollection<Thread> Thread { get; set; }
    }
}
