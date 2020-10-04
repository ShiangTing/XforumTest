using System;
using System.Collections.Generic;

namespace XforumTest.DataTable
{
    public partial class ReposiveMessages
    {
        public Guid MessageId { get; set; }
        public Guid? PostId { get; set; }
        public string Context { get; set; }
        public int? LikeNumber { get; set; }
        public int? DisLikeNumber { get; set; }
        public DateTime? CreatedDate { get; set; }
        public Guid? UserId { get; set; }

        public virtual Posts Post { get; set; }
    }
}
