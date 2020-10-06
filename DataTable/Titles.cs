using System;
using System.Collections.Generic;

namespace XforumTest.DataTable
{
    public partial class Titles
    {
        public Titles()
        {
            ForumMembers = new HashSet<ForumMembers>();
        }

        public Guid TitleId { get; set; }
        public string TitleName { get; set; }
        public decimal? Price { get; set; }

        public virtual ICollection<ForumMembers> ForumMembers { get; set; }
    }
}
