using System;
using System.Collections.Generic;

namespace XforumTest.DataTable
{
    public partial class Forums
    {
        public Guid ForumId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string Img { get; set; }
        public Guid? ModeratorId { get; set; }
        public string Description { get; set; }
        public string ForumName { get; set; }
    }
}
