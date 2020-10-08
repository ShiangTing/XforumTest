using System;
using System.Collections.Generic;

namespace XforumTest.DataTable
{
    public partial class Forums
    {
        public Forums()
        {
            Posts = new HashSet<Posts>();
        }

        public Guid ForumId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string Img { get; set; }
        public Guid? ModeratorId { get; set; }
        public string Description { get; set; }
        public string ForumName { get; set; }
        public string RouteName { get; set; }
        public bool? State { get; set; }

        public virtual ForumMembers Moderator { get; set; }
        public virtual ICollection<Posts> Posts { get; set; }
    }
}
