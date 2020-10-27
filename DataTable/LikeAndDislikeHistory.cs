using System;
using System.Collections.Generic;

namespace XforumTest.DataTable
{
    public partial class LikeAndDislikeHistory
    {
        public Guid? UserId { get; set; }
        public Guid? PostId { get; set; }
        public Guid? MessageId { get; set; }
        public Guid Id { get; set; }
        public bool? IsLike { get; set; }
        public bool? IsDisLike { get; set; }

        public virtual ReposiveMessages Message { get; set; }
        public virtual Posts Post { get; set; }
        public virtual ForumMembers User { get; set; }
    }
}
