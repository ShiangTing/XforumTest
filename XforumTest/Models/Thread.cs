using System;
using System.Collections.Generic;

namespace XforumTest.Models
{
    public partial class Thread
    {
        public Guid ThreadId { get; set; }
        public string Context { get; set; }
        public string Img { get; set; }
        public Guid UserId { get; set; }
        public int? Votes { get; set; }
        public int? UnVotes { get; set; }
        public Guid FoutmId { get; set; }

        public virtual Forum Foutm { get; set; }
        public virtual ForumMember User { get; set; }
    }
}
