using System;
using System.Collections.Generic;

namespace XforumTest.Models
{
    public partial class Role
    {
        public Role()
        {
            ForumMember = new HashSet<ForumMember>();
        }

        public int RoleId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ForumMember> ForumMember { get; set; }
    }
}
