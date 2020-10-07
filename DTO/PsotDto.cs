using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XforumTest.DTO
{
    public class PostDto
    {
        public string ForumId { get; set; }
        public Guid? PostId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        //public string Img { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UserId { get; set; }
        //public bool State { get; set; }
    }
}
