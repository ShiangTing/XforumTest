using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XforumTest.DTO
{
    public class ForumGetAllDTO
    {
        public string UserName { get; set; }
        public int Age { get; set; }
    }

    public class ForumCreate
    {
        //public Guid ForumId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string Img { get; set; }
        public Guid? ModeratorId { get; set; }
        public string Description { get; set; }
        public string ForumName { get; set; }
    }
}
