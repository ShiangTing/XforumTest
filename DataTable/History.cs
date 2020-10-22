using System;
using System.Collections.Generic;

namespace XforumTest.DataTable
{
    public partial class History
    {
        public Guid HistoryId { get; set; }
        public Guid? UserId { get; set; }
        public DateTime? DateTime { get; set; }
        public int? CategoryId { get; set; }
        public decimal? PointChanged { get; set; }

        public virtual Category Category { get; set; }
        public virtual ForumMembers User { get; set; }
    }
}
