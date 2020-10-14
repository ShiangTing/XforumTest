using System;
using System.Collections.Generic;

namespace XforumTest.DataTable
{
    public partial class MemberTitle
    {
        public int MemberTitleId { get; set; }
        public Guid? UserId { get; set; }
        public Guid? HasTitleId { get; set; }

        public virtual Titles HasTitle { get; set; }
        public virtual ForumMembers User { get; set; }
    }
}
