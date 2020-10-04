using System;
using System.Collections.Generic;

namespace XforumTest.DataTable
{
    public partial class ForumRoles
    {
        public ForumRoles()
        {
            ForumMembers = new HashSet<ForumMembers>();
        }

        public Guid RoleId { get; set; }
        public string RoleName { get; set; }

        public virtual ICollection<ForumMembers> ForumMembers { get; set; }
    }
}
