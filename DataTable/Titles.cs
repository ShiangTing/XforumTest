using System;
using System.Collections.Generic;

namespace XforumTest.DataTable
{
    public partial class Titles
    {
        public Titles()
        {
            ForumMembers = new HashSet<ForumMembers>();
            MemberTitle = new HashSet<MemberTitle>();
        }

        public Guid TitleId { get; set; }
        public string TitleName { get; set; }
        public decimal? Price { get; set; }
        public string RankColor { get; set; }

        public virtual ICollection<ForumMembers> ForumMembers { get; set; }
        public virtual ICollection<MemberTitle> MemberTitle { get; set; }
    }
}
