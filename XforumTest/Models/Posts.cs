using System;
using System.Collections.Generic;

namespace XforumTest.Models
{
    public partial class Posts
    {
        public Guid PostId { get; set; }
        public string Context { get; set; }
        public Guid UserId { get; set; }

        public virtual ForumMember User { get; set; }
    }
}
